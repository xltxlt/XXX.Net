<script setup>
import { onBeforeUnmount, ref, shallowRef, onMounted, watch } from 'vue'
import { Editor, Toolbar } from '@wangeditor/editor-for-vue'
import { uploadFileToService } from '@/api/common/oss'
const props = defineProps({
    modelValue: String,
})
// 编辑器实例，必须用 shallowRef，重要！
const editorRef = shallowRef()
const emit = defineEmits(['update:modelValue'])
const valueHtml = ref('')

onMounted(() => {
    valueHtml.value = props.modelValue
})

watch(() => props.modelValue, (newVal, oldVal) => {
    console.log(newVal)
    if (newVal != undefined && oldVal != newVal) {
        valueHtml.value = newVal
    }
}, {
    immediate: true
})
// 编辑器配置
const editorConfig = {
    placeholder: '',
    MENU_CONF: {
        uploadImage: {
            // 自定义图片上传逻辑
            // file 即选中的文件，async customUpload 返回的是一个数组 [{ url, alt, href }]
            async customUpload(file, insertFn) {
                try {
                    await uploadFileToService(file, 'common/editor', true).then(res => {
                        insertFn(
                            res.ossUrl,
                            '图片',
                            res.ossUrl
                        )
                    })
                } catch (error) {
                    alert('图片上传失败：' + (error.message || '未知错误'))
                }

            },
            allowedFileTypes: ['image/*'],
            maxFileSize: 10 * 1024 * 1024, // 10M
            base64LimitSize: 5 * 1024, // 5KB 以下转 base64
        },
        uploadVideo: {
            async customUpload(file, insertFn) {
                try {
                    const result = await uploadFileToService(file, 'common/editor', true).then(res => {
                        insertFn(
                            res.ossUrl,
                        )
                    })
                } catch (error) {
                    alert('视频上传失败：' + (error.message || '未知错误'))
                }
            },
            allowedFileTypes: ['video/*'],
            maxFileSize: 100 * 1024 * 1024, // 100M
        }
    }
}
// 工具栏配置
const toolbarConfig = {}
const handleCreated = (editor) => {
    editorRef.value = editor // 记录 editor 实例，重要！
    console.log(editor)
}

// 组件销毁时，及时销毁编辑器
onBeforeUnmount(() => {
    const editor = editorRef.value
    if (editor == null) return
    editor.destroy()
})
watch(valueHtml, (newVal, oldVal) => {
    if (newVal != oldVal) {
        console.log(newVal)
        emit('update:modelValue', newVal)
    }
})
const mode = 'default'
</script>

<template>
    <div style="border: 1px solid #ccc">
        <!-- 工具栏 -->
        <Toolbar style="border-bottom: 1px solid #ccc" :editor="editorRef" :defaultConfig="toolbarConfig"
            :mode="mode" />
        <!-- 编辑器 -->
        <Editor v-model="valueHtml" :defaultConfig="editorConfig" style="height: 500px; overflow-y: hidden;"
            @onCreated="handleCreated" />
    </div>
</template>

<!-- 别忘了引入样式 -->
<style src="@wangeditor/editor/dist/css/style.css"></style>