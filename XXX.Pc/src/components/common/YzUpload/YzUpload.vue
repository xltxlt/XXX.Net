<template>
    <div>
        <el-upload ref="elUploadRef" :accept="props.accept ?? imageAccept.join(',')" v-model:file-list="uploadList"
            :limit="limit" :http-request="customUpload" :on-success="handleUploadSuccess" :on-error="handleUploadError"
            :on-exceed="handleUploadExceed" :on-remove="handleRemove" list-type="picture-card">
            <el-icon>
                <Plus />
            </el-icon>
        </el-upload>

        <!-- 图片预览 -->
        <el-image-viewer v-if="dialogVisible" :url-list="[dialogImageUrl]" @close="dialogVisible = false" />
    </div>
</template>

<script setup lang="ts">
import { ref, watch, onMounted, nextTick } from 'vue'
import { fielService } from '@/api'
import type {
    UploadFile,
    UploadFiles,
    UploadProps,
    UploadRequestOptions,
    UploadUserFile,
} from 'element-plus'
import { ElMessage } from 'element-plus'
import { Plus } from '@element-plus/icons-vue'

// ========== 常量 ==========
const imageAccept = [
    '.jpg', '.jpeg', '.png', '.gif', '.bmp', '.svg', '.webp',
    '.JPG', '.JPEG', '.PNG', '.GIF', '.BMP', '.SVG', '.WEBP',
]
const fileAccept = [
    '.pdf', '.doc', '.docx', '.xls', '.xlsx', '.ppt', '.pptx',
]

// ========== Props / Emits ==========
const props = defineProps<{
    files?: Array<{ url: string; id?: string | number; name?: string }>
    limit?: number
    accept?: string
}>()

const emits = defineEmits<{
    (e: 'update:listData', value: any[]): void
    (e: 'update:listUrl', value: string[]): void
    (e: 'update:lastUrl', value: string): void
}>()

// ========== 响应式数据 ==========
const uploadList = ref<UploadUserFile[]>([])
const dialogVisible = ref(false)
const dialogImageUrl = ref('')
const elUploadRef = ref()

// ========== 初始化回显 ==========
onMounted(async () => {
    if (props.files && props.files.length > 0) {
        const data: UploadUserFile[] = props.files.map((v) => ({
            url: v.url,
            uid: v.id ?? v.url,   // uid 必须唯一，没有 id 就用 url 兜底
            name: v.name ?? v.url.split('/').pop() ?? 'image',
            status: 'success',     // ✅ 关键：标记为成功，否则不会渲染为已上传图片
        }))
        uploadList.value = data
    }
})

// ========== 自定义上传 ==========
const customUpload = async (options: UploadRequestOptions) => {
    try {
        const res = await fielService.apiSysFileUploadSinglePost(options.file)
        // ✅ [NonUnify] 返回的是扁平 SysFileOutput，不是 { data: {...} }
        const url = res.data?.url
        if (!url) {
            ElMessage.error('上传成功但未返回文件地址')
            return
        }

        // ✅ 直接操作 fileList（通过 ref）
        const file = elUploadRef.value?.uploadFiles?.find(
            (f: any) => f.uid === options.file.uid
        )
        if (file) {
            file.url = url
            file.status = 'success'
        }

        // ✅ 通知父组件
        const urls = elUploadRef.value?.uploadFiles
            ?.filter((f: any) => f.status === 'success' && f.url)
            ?.map((f: any) => f.url) ?? []

        emits('update:listUrl', urls)
        emits('update:lastUrl', url)

        ElMessage.success('上传成功')

        // ✅ 标记成功（组件不会再触发 on-success）
        options.onSuccess(res)
    } catch (err) {
        options.onError(err as any)
    }
}

// ========== 上传成功 ==========
const handleUploadSuccess = (res: any, file: UploadFile, fileList: UploadFiles) => {
    // console.log('handleUploadSuccess:', res)

}

// ========== 删除文件 ==========
const handleRemove: UploadProps['onRemove'] = (file, fileList) => {
    const urls = fileList
        .filter((f) => f.status === 'success' && f.url)
        .map((f) => f.url as string)
    emits('update:listUrl', urls)
    emits('update:listData', fileList)
}

// ========== 超出限制 ==========
const handleUploadExceed = (files: File[], uploadFiles: UploadUserFile[]) => {
    ElMessage.warning(`最多只能上传 ${props.limit} 个文件`)
}

// ========== 上传失败 ==========
const handleUploadError = (error: any) => {
    console.error('上传失败:', error)
    ElMessage.error('上传失败，请重试')
}

// ========== 预览 ==========
const handlePictureCardPreview: UploadProps['onPreview'] = (uploadFile) => {
    console.log('handlePictureCardPreview:', uploadFile)
    dialogImageUrl.value = uploadFile.url || ''
    dialogVisible.value = true
}
</script>

<style lang="less" scoped>
/* 按需添加样式 */
</style>