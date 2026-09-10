<template>
    <div class="upload-file">
        <input type="file" ref="fileInput" hidden="hidden" @change="fileChange" style="display: none;">
    </div>
</template>

<script setup lang='ts'>
import { ref } from 'vue'

// 定义组件属性
interface Props {
    action?: string // 上传地址
    maxSize?: number // 最大文件大小(MB)
    accept?: string // 接受的文件类型
}

const emits= defineEmits(['error','uploadFile'])
const props = withDefaults(defineProps<Props>(), {
    action: '/api/upload',
    maxSize: 10,
    accept: '*'
})



// 响应式数据
const fileInput = ref<HTMLInputElement | null>(null)
const uploadProgress = ref<number>(0)
const uploadStatus = ref<'ready' | 'uploading' | 'success' | 'error'>('ready')

// 选择文件
const selectFile = () => {
    if (fileInput.value) {
        fileInput.value.click()
    }
}

// 清除已选择文件
const clearFile = () => {
    if (fileInput.value) {
        fileInput.value.value = ''
    }
    resetUploadStatus()
}
// 重置上传状态
const resetUploadStatus = () => {
    uploadProgress.value = 0
    uploadStatus.value = 'ready'
}

// 文件选择处理
const fileChange = (e: Event) => {
    const target = e.target as HTMLInputElement
    const files = target.files

    if (!files || files.length === 0) {
        return
    }

    const file = files[0]

    // 检查文件大小
    if (file.size > props.maxSize * 1024 * 1024) {
        clearFile()
        emits('error',{
            message: '文件大小超出限制',
        })
        return
    }
    emits('uploadFile',{
        file
    }) 
    resetUploadStatus()
}



// 暴露方法给父组件
defineExpose({
    selectFile,
    clearFile
})
</script>

<style lang='less' scoped>
.upload-file {
    .file-info {
        display: flex;
        align-items: center;
        margin-top: 10px;
        gap: 10px;

        span {
            flex: 1;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }
    }

    .progress-container {
        margin-top: 10px;
    }

    .success-message {
        color: #67c23a;
        margin-top: 10px;
    }

    .error-message {
        color: #f56c6c;
        margin-top: 10px;
    }
}
</style>