<template>
    <div class="yz-import">
        <el-upload style="height: 100%;" class="upload-demo" drag :limit="1" :action="pars?.url"
        >
            <el-icon class="el-icon--upload"><upload-filled /></el-icon>
            <div class="el-upload__text">
                拖动文件到此处或 <em>点击上传excel文件</em>
                <br />
                <em v-if="pars?.tempUrl" @click.stop="downLoadTemplate">点击下载模板</em>
            </div>
        </el-upload>
    </div>
</template>
<script setup lang='ts'>
import { UploadFilled } from '@element-plus/icons-vue'
import { downloadFileByUrl } from '@/utils/common'
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const downLoadTemplate = () => {
    downloadFileByUrl(pars?.tempUrl)
}
</script>
<style lang='less' scoped>
.yz-import {
    height: 100%;
    width: 100%;

    .el-upload {
        height: 100%;
    }
}
</style>
<style lang='less'>
.yz-import {
    height: 100%;
    width: 100%;

    .el-upload,
    .el-upload-dragger {
        height: 100%;
    }

    .el-upload-dragger {
        display: flex;
        flex-direction: column;
        align-content: center;
        justify-content: center;
        align-items: center;
    }

}
</style>