<script setup lang='ts'>
</script>
<template>
    <el-upload class="upload-demo" drag action="https://run.mocky.io/v3/9d059bf9-4660-45f2-925d-ce80ad6c4d15" multiple>
        <el-icon class="el-icon--upload"><upload-filled /></el-icon>
        <div class="el-upload__text">
            拖动文件到此处或 <em>选择文件上传</em>
        </div>
        <template #tip>
            <slot name="tip">
                <router-link  :to="'https://'">点击下载上传模板</router-link> 
            </slot>
        </template>
        
    </el-upload>
</template>
<style lang='less' scoped></style>