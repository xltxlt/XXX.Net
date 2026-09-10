<script setup lang='ts'>
import { ref, watch } from 'vue'
import { getOssSignedAllUrl } from '@/api/common/oss';
import { isEmptyVal } from '@/utils/is';

const emtis = defineEmits(['update:ossUrl', 'click', 'change'])
const props = defineProps<{
    src: string,
    // ossUrl?: string,
    isOss?: boolean,
    preview?: boolean,
    round?: boolean,
    width?: string,
    height?: string,
    radius?: string,
}>()

// 1. 使用 ref 来存储最终的图片 URL
const imgUrl = ref('')

const getImgUrl = async () => {
    if (props.isOss && props.src.indexOf('OSSAccessKeyId') == -1) {
        imgUrl.value = await getOssSignedAllUrl(props.src)
        emtis('update:ossUrl', imgUrl.value)
        emtis('change', imgUrl.value)
    } else {
        emtis('update:ossUrl', props.src)
        imgUrl.value = props.src

    }
}
watch(() => props.src, async (newVal, oldVal) => {
    if (!isEmptyVal(newVal) && newVal !== oldVal) {
        await getImgUrl();
    }
}, {
    immediate: true, deep: true
})
const click = () => {
    emtis('click', imgUrl.value)
}
</script>

<template>
    <!-- 3. 模板中直接绑定 ref 的值 -->
    <el-image :width="width ?? ''" :height="height ?? ''" :radius="radius" :round="round" :src="imgUrl" @click="click">
    </el-image>
</template>
<style lang='less' scoped></style>