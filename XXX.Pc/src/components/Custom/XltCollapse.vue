<script setup lang="ts">
import { ArrowDownBold, ArrowRightBold } from '@element-plus/icons-vue'
import { ref } from 'vue';
defineProps<{ label: string }>()
const hide = ref(false)


</script>
<template>
    <div class="xlt-collapse">
        <div class="xlt-collapse-item">
            <div class="xlt-collapse-header" @click.self="hide = !hide">
                <el-icon size="13px">
                    <ArrowDownBold v-if="!hide" />
                    <ArrowRightBold v-else />
                </el-icon>
                <span>{{ label }}</span>
                <div class="xlt-collapse-tools">
                    <slot name="tools">
                    </slot>
                </div>
            </div>
            <div class="xlt-collapse-content" :class="{ 'xlt-content-hide': hide }">
                <slot name="content"></slot>
            </div>
        </div>
    </div>
</template>
<style scoped>
.xlt-collapse {
    border-radius: 0;
    background-color: #fff;
    border: #e6e6e6 1px solid;

    .el-form-item {
        margin-bottom: 0;
    }

    .xlt-collapse-header {
        position: relative;
        height: 32px;
        line-height: 32px;
        text-align: left;
        padding: 0 15px 0 15px;
        color: #333;
        background-color: #f2f2f2;
        cursor: pointer;
        font-size: 14px;
        overflow: hidden;
        border-bottom: #e6e6e6 1px solid;

        span {
            padding-left: 5px;

        }

        .xlt-collapse-tools {
            position: absolute;
            right: 15px;
            top: 0;
            display: flex;
            height: 100%;
            align-items: center;
            justify-content: flex-end;
        }
    }

    .xlt-collapse-item {
        /* display: flex; */
        /* flex-direction: column; */
        height: 100%;
    }



    .xlt-collapse-content {
        overflow: hidden;
        transition: all 0.2s;
        height: calc(100% - 32px);
    }

    .xlt-content-hide {
        height: 0;
    }


}
</style>
<style>
.xlt-collapse {
    .xlt-content-hide {
        .data-list-pagination {
            display: none;
        }
    }

}
</style>