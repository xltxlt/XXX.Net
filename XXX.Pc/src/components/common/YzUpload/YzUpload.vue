<template>
    <div class="yz-upload">
        <el-upload
            ref="elUploadRef"
            v-model:file-list="uploadList"
            :accept="props.accept ?? imageAccept.join(',')"
            :limit="props.limit"
            :multiple="props.multiple"
            :list-type="'picture-card'"
            :http-request="customUpload"
            :on-exceed="handleUploadExceed"
            :on-remove="handleRemove"
            :on-preview="handlePictureCardPreview"
            v-bind="props.uploadProps"
        >
            <el-icon><Plus /></el-icon>
        </el-upload>

        <el-image-viewer
            v-if="dialogVisible"
            :url-list="[dialogImageUrl]"
            @close="dialogVisible = false"
        />
    </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
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

type UploadValue = {
    url: string
    id?: string | number
    name?: string
}

const imageAccept = [
    '.jpg', '.jpeg', '.png', '.gif', '.bmp', '.svg', '.webp',
    '.JPG', '.JPEG', '.PNG', '.GIF', '.BMP', '.SVG', '.WEBP',
]

const props = withDefaults(defineProps<{
    modelValue?: UploadValue | UploadValue[] | null
    files?: UploadValue[]
    limit?: number
    multiple?: boolean
    accept?: string
    uploadProps?: Record<string, any>
}>(), {
    modelValue: undefined,
    files: undefined,
    limit: 1,
    multiple: false,
    accept: undefined,
    uploadProps: undefined,
})

const emits = defineEmits<{
    (e: 'update:modelValue', value: UploadValue | UploadValue[] | null): void
}>()

const uploadList = ref<UploadUserFile[]>([])
const dialogVisible = ref(false)
const dialogImageUrl = ref('')

const normalizeValues = (value: UploadValue | UploadValue[] | null | undefined): UploadValue[] => {
    if (!value) return []
    return Array.isArray(value) ? value : [value]
}

const toUploadFiles = (value: UploadValue | UploadValue[] | null | undefined): UploadUserFile[] => {
    return normalizeValues(value)
        .filter(v => !!v?.url)
        .map(v => ({
            url: v.url,
            uid: v.id ?? v.url,
            name: v.name ?? v.url.split('/').pop() ?? 'image',
            status: 'success',
        }))
}

const getValue = (): UploadValue[] => {
    return uploadList.value
        .filter(file => file.status === 'success' && !!file.url)
        .map(file => ({
            url: file.url as string,
            id: file.uid,
            name: file.name,
        }))
}

const emitValue = () => {
    const values = getValue()
    if (props.multiple) {
        emits('update:modelValue', values)
    } else {
        emits('update:modelValue', values[0] ?? null)
    }
}

watch(
    () => props.modelValue,
    value => {
        uploadList.value = toUploadFiles(value)
    },
    { immediate: true, deep: true }
)

watch(
    () => props.files,
    value => {
        if (props.modelValue === undefined) {
            uploadList.value = toUploadFiles(value)
        }
    },
    { immediate: true, deep: true }
)

const customUpload = async (options: UploadRequestOptions) => {
    try {
        const res = await fielService.apiSysFileUploadSinglePost(options.file)
        const url = res.data?.url

        if (!url) {
            throw new Error('上传成功但未返回文件地址')
        }

        const file = uploadList.value.find(f => f.uid === options.file.uid)
        if (file) {
            file.url = url
            file.status = 'success'
            file.response = res
        }

        options.onSuccess(res)
        emitValue()
        ElMessage.success('上传成功')
    } catch (error) {
        options.onError(error as any)
        ElMessage.error(error instanceof Error ? error.message : '上传失败，请重试')
    }
}

const handleRemove: UploadProps['onRemove'] = (_file, _fileList) => {
    emitValue()
}

const handleUploadExceed = () => {
    ElMessage.warning(`最多只能上传 ${props.limit} 个文件`)
}

const handlePictureCardPreview: UploadProps['onPreview'] = (uploadFile) => {
    if (!uploadFile.url) return
    dialogImageUrl.value = uploadFile.url
    dialogVisible.value = true
}
</script>

<style lang="less" scoped>
.yz-upload {
    width: 100%;
}
</style>
