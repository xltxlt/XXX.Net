<script setup lang="ts">
import { ref, watch, defineProps, defineEmits, computed } from 'vue'
import { ElMessage } from 'element-plus'
import type { UploadProps, UploadRequestOptions } from 'element-plus'
import { getOssSignedAllUrl, elUploadToServiceDis } from '@/api/common/oss';
import { Picture } from '@element-plus/icons-vue'
import YzImage from '@/components/common/YzImage/YzImage.vue';
const props = defineProps<{
  imgTypes: Array<{ label: string, name: string, url: string, defUrl: string, typeId: number, signedUrl?: string, imgName?: string }>
  preview?: boolean
}>()

const emit = defineEmits(['change', 'reset','update:imgTypes'])
const localImgTypes = computed(()=>props.imgTypes)

const beforeUpload: UploadProps['beforeUpload'] = async (rawFile) => {
  if (!['image/jpeg', 'image/png'].includes(rawFile.type)) {
    ElMessage.error('仅支持 JPG/PNG 格式!')
    return false
  }
  if (rawFile.size / 1024 / 1024 > 6) {
    ElMessage.error('图片不能超过6MB!')
    return false
  }

  return true
}

async function handleSuccess(response: any, name: string) {
  emit('change', name, response)
}

function reset(name: string) {
  const item = localImgTypes.value.find(i => i.name === name)
  if (item) {
    item.url = ''
    item.signedUrl = ''
    emit('reset', name, null)
    emit('update:imgTypes', localImgTypes.value)
  }
}

const viewerVisible = ref(false)
const viewerUrlList = ref<string[]>([])

function previewImg(name: string) {
  const item = localImgTypes.value.find(i => i.name === name)
  if (item && item.signedUrl) {
    viewerUrlList.value = [item.signedUrl]
    viewerVisible.value = true
  }
}
</script>

<template>
  <div class="multi-img-upload" :class="{ 'single-center': localImgTypes.length === 1 }">
    <div v-for="item in localImgTypes" :key="item.name" class="img-upload-item">
      <div class="img-label">{{ item.label }}</div>
      <el-upload :disabled="preview === true" class="avatar-uploader" :class="item.name=='idBack' ? 'avatar-uploader-cover' : ''" action="" :http-request="async (options: UploadRequestOptions) => {
        const res = await elUploadToServiceDis(options, item.typeId);
        handleSuccess(res, item.name)
      }" :show-file-list="false" :before-upload="beforeUpload">
        <YzImage class="image-slot avatar" v-if="item.url" :src="item.url" :is-oss="true"></YzImage>
        <el-image v-else :src="item.defUrl" fit="cover" class="image-def">
          <template #error>
            <div class="image-slot">
              <el-icon>
                <Picture />
              </el-icon>
            </div>
          </template>
        </el-image>
      </el-upload>

      <div class="img-upload-tools">
        <el-button class="img-upload-tools-preview" size="small" @click="previewImg(item.name)" style="margin-top:4px;">
          预览
        </el-button>
        <el-button v-if="preview !== true" class="img-upload-tools-reset" size="small" @click="reset(item.name)"
          style="margin-top:4px;">
          重置
        </el-button>
      </div>

      <el-image-viewer v-if="viewerVisible" :url-list="viewerUrlList" @close="viewerVisible = false" />
    </div>
  </div>
</template>

<style lang="less" scoped>
.multi-img-upload {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 24px;
  justify-items: center;
  align-items: start;
  width: 100%;
  /* 确保占满父容器 */
}

/* 其余样式保持不变 */
.img-upload-item {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  /* 防止内容溢出 */
}

.img-label {
  margin-bottom: 8px;
  font-size: 14px;
  color: #333333;
  font-weight: 500;
}

.avatar-uploader {
  margin-bottom: 15px;
  width: 250px;
  height: 158px;

  .image-def {
    height: 100%;
    width: 100%;
  }
}
.avatar-uploader-cover{
  width: 180px !important;
  height: 254px !important;
}
.image-slot.avatar {
  width: 250px;
  height: 150px;
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  overflow: hidden;
}

.img-upload-tools {
  margin-top: 3px;
  display: flex;
  gap: 8px;
  justify-content: center;
  width: 100%;

  .img-upload-tools-preview,
  .img-upload-tools-reset {
    border: none;
    color: #ffffff;
    flex: 1;
    max-width: 80px;
  }

  .img-upload-tools-preview {
    background-color: var(--btn-color-6);
  }

  .img-upload-tools-reset {
    background-color: var(--btn-color-2);
  }
}
</style>

<style>
.avatar-uploader .el-upload {
  height: 100%;
  width: 100%;
}
</style>

<style>
.avatar-uploader {
  .el-upload {
    height: 100%;
  }
}
</style>
