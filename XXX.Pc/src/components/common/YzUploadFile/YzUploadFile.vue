<template>
    <el-upload ref="elUploadRef" class="yz-upload-file" drag multiple :accept="props.accept ?? fileAccept.join(',')"
        v-model:file-list="uploadList" :limit="limit" v-bind="$attrs" :http-request="async (options: UploadRequestOptions) => {
            return await fielService.apiSysFileUploadSinglePost(options.file);
        }" :on-change="(file: any, files: UploadFiles) => {
            console.log(file);
            if (file?.status == 'success') {
                file.response.url = file.response.url;
            }
            else if(file?.response!=null){
                ElMessage.error(file?.response.message??'')
            }
        }" :on-success="(res: any, file: UploadFile, files: UploadFiles) => {
            handleUploadSuccess(res, file, files)
        }
            " :on-exceed="(files: File[], uploadFiles: UploadUserFile[]) => handleUploadExceed(files, uploadFiles)"
        :tip="'文件上传中请稍等'" :on-preview="handlePictureCardPreview">
        <el-icon class="el-icon--upload"><upload-filled /></el-icon>
        <div class="el-upload__text">
            拖动文件到此处或 <em>点击上传文件</em>
            <br />
            {{ limit ? `最多可上传${limit}个文件` : '' }}
            {{ props.accept ? `支持的文件类型：${props.accept}` : '' }}
        </div>
    </el-upload>
    <el-dialog v-model="dialogVisible">
        <img w-full :src="dialogImageUrl" alt="Preview Image" />
    </el-dialog>
</template>
<script setup lang='ts'>
import { onMounted, ref, watch, nextTick } from 'vue';
import { ElMessage } from 'element-plus';

import { fielService } from '@/api';
import type { UploadFile, UploadFiles, UploadProps, UploadRequestOptions, UploadUserFile } from 'element-plus'
const fileAccept = ['.pdf', '.doc', '.docx', '.xls', '.xlsx', '.ppt', '.pptx', '.jpg', '.png', '.jpeg', '.gif', '.bmp', '.svg', '.webp', '.JPG', '.PNG', '.JPEG', '.GIF', '.BMP', '.SVG', '.WEBP']
const elUploadRef = ref()
const uploadList = ref<any[]>()
const dialogVisible = ref<boolean>(false)
const dialogImageUrl = ref<string>('')
let uidOssUrl: Record<number, string> = {

}
const emits = defineEmits<{
    (e: 'update:listData', value: string[]): void
}>()
let props = defineProps<{
    files?: any[],
    limit?: number,
    accept?: string,
}>();

onMounted(async () => {
    if (props.files && props.files.length > 0) {
        const data = await Promise.all((props.files.map(async (v, i) => {
            let url = v.url;
           
            return {
                url: url,
                uid: v.id,
                response: {
                    url: v,
                    ossUrl: url
                },
                name: v.name
            }
        })));
        uploadList.value = data
    }
})
const handlePictureCardPreview: UploadProps['onPreview'] =async (uploadFile) => {
    // await previewFile(uploadFile.url ?? '')
}
const handleUploadSuccess = (res: any, file: UploadFile, fileList: UploadFiles) => {
    // // elUploadRef.value.clearFiles()
    // if (res.status == 'success') {
    //     // file.url = res.ossUrl;
    // }
    // else {
    //     ElMessage.error(res.message)
    // }
}
const handleUploadExceed = (files: File[], uploadFiles: UploadUserFile[]) => {
    ElMessage.error(`最多只能上传${props.limit}个文件`)
}
</script>
<style lang='less' scoped>
.yz-upload-file {
    width: 100%;
}
</style>