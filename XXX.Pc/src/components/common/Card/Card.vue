<script lang="ts" setup>
const props = defineProps<{
    title: string
}>()
</script>
<template>
    <div class="xxx-card">
        <div class="xxx-card-header">
            {{ props.title }}
            <div class="xxx-card-header-right">
                <slot name="right">
                </slot>
            </div>
        </div>
        <div class="xxx-card-content">
            <slot>

            </slot>
        </div>
    </div>
</template>
<style lang="less" scoped>
.xxx-card {
    background-color: #fefefe;
    border-radius: 10px;
    box-shadow: 0 10px 30px rgba(31, 62, 110, .10);
    padding: 15px 20px;
    &-header {
        font-weight: bold;
        font-size: 1rem;
        text-align: left;
        position: relative;
        padding-left: 15px;
        color: #091E48;
        display: flex;
        align-items: center;
    justify-content: space-between;
        &::before {
            position: absolute;
            content: "";
            width: 4px;
            height:calc(100% - 6px) ;
            top: 50%;
            left: 0;
            transform:translateY(-50%);
            border-radius: 4px;
            background-color: #2073ee;
        }
        &-right{

        }
    }
}
</style>