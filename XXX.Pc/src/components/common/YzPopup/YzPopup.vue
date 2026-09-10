<template>
    <el-dialog v-model="dto.show" class="yz-dialog" :show-close="false" :destroy-on-close="true" draggable align-center
        :width="dto.full ? '100%' : (dto.pars.width ?? '')" :style="{
            height: dto.min ? '60px' : (dto.full ? '100%' : dto.pars.height ?? '60%'),
            top: dto.min ? '0' : '',
            left: dto.full ? '0' : '',
            margin: dto.full ? '0' : ''
        }">
        <template #header>
            {{ dto.pars.title }}
            <div class="dialog-btns">
                <el-button @click="dto.min = !dto.min">
                    <el-icon>
                        <Minus />
                    </el-icon>
                </el-button>
                <el-button @click="dto.full = !dto.full; dto.min = false">
                    <el-icon>
                        <FullScreen />
                    </el-icon>
                </el-button>
                <el-button @click="closeDialog">
                    <el-icon>
                        <Close />
                    </el-icon>
                </el-button>
            </div>
        </template>
        <slot v-if="custom">
        </slot>
        <component v-if="!custom" :is="currentDialogComp" :pars="{ ...dto.pars.pars }" @closeDialog="closeDialog" @refreshList="refreshList" />
    </el-dialog>
</template>
<script setup lang='ts'>
import { ref, markRaw, watch, shallowRef, computed } from 'vue'
import type { YzDialogExpose, YzDialogDto, YzDialogPars } from '.'
const emits = defineEmits<{
    (e: 'closeDialog'): void,
    (e:'refreshList'): void
}>()
const currentDialogComp = ref(shallowRef())  // 当前弹窗组件
const {custom}= defineProps<{custom?:boolean}>()
const dto = ref<YzDialogDto>({
    show: false,
    full: false,
    min: false,
    pars: {
        title: '标题',
        hasClose: true,
        hasFull: true,
        hasMin: true,
        width: '50%',
        height: '50%',
        comp: null,
        pars: null
    }
})

const closeDialog = () => {
    currentDialogComp.value = null;
    dto.value.show = false;
    emits('closeDialog')
}
const refreshList = () => {
    emits('refreshList')
}
const openDialog = (pars: YzDialogPars) => {
    dto.value.pars = pars;
    if (pars.comp) currentDialogComp.value = markRaw(pars.comp)
    dto.value.show = true;
}
const minDialog = () => {
    dto.value.full = false;
    dto.value.min = true;
}
const fullDialog = () => {
    dto.value.full = true;
    dto.value.min = false;
}
defineExpose<YzDialogExpose>({
    close: closeDialog,
    open: openDialog,
    min: minDialog,
    full: fullDialog
})
</script>
<style lang='less' scoped></style>
<style>
.yz-dialog {
    .el-dialog__headerbtn {
        height: 42px;
    }
    .el-dialog__body{
        /* padding: 0 15px !important;  */
        padding: 0 !important;
        height: calc(100% - 36px) !important;
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

    .dialog-btns {
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

    &.el-dialog {
        padding: 0;
        height: 60%;
    }
}
</style>