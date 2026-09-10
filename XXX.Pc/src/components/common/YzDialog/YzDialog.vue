<script setup lang='ts'>
import { readonly, ref } from 'vue'
const isFullScreen=ref(false) 
const isMin=ref(false) 

let props = defineProps<{
    width?: string,
    height?: string,
    title?: string,
    show?:boolean
}>()
const emit = defineEmits(['update:show','colseDialog'])
</script>

<template>
    <el-dialog v-model="props.show" @close="emit('colseDialog')" :class="['ldyz-dialog']" :show-close="false" :destroy-on-close="true" draggable
        align-center :width="isFullScreen ? '100%' : (width ?? '')" :style="{
            height: isMin ? '60px' : (isFullScreen ? '100%' : height ?? '60%'),
            top: isMin ? '0' : '',
            left: isFullScreen ? '0' : '',
            margin: isFullScreen ? '0' : ''
        }">
        <template #header>
            {{ title }}
            <div class="dialog-tools">
                    <el-button @click="isMin = !isMin">
                        <el-icon>
                            <Minus />
                        </el-icon>
                    </el-button>
                    <el-button @click="isFullScreen = !isFullScreen;isMin=false">
                        <el-icon>
                            <FullScreen />
                        </el-icon>
                    </el-button>
                    <el-button @click="emit('colseDialog')">
                        <el-icon>
                            <Close />
                        </el-icon>
                    </el-button>
            </div>
        </template>
        <slot>
        </slot>
    </el-dialog>

</template>
<style lang='less'>
.el-dialog {
    padding: 0;
    height: 60%;

    .el-dialog__body {
        height: calc(100% - 36px);
        padding: 0 20px;
        overflow-y: auto;
    }

    .el-dialog__headerbtn {
        height: 42px;
    }

    .el-dialog__header {
        text-align: left;
        font-size: 14px;
        height: 35px !important;
        line-height: 35px !important;
        background-color: #F8F8F8;
        color: #333;
        padding: 0 80px 0 20px;
        border-bottom: 1px solid #eee;
        border-radius: 2px 2px 0 0;
        position: relative;
    }

    .dialog-footer-div {
        padding-right: 20px;
    }

    .dialog-tools {
        position: absolute;
        top: 0px;
        right: 15px;
        display: flex;
        align-items: center;
        height: 100%;

        .el-button {
            border: none;
            background: unset;
            font-size: 17px;
            padding: 8px 5px;
        }
    }
}
</style>