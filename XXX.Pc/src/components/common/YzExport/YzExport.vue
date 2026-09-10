<template>
    <div class="yz-export-page">
        <div style="margin-top: 20px;text-align: left;padding: 0 20px;">
            <el-checkbox v-model="checkAll" :indeterminate="isIndeterminate" @change="handleCheckAllChange">
                全选
            </el-checkbox>
            <el-checkbox-group v-model="checkedFields" @change="handleCheckedCitiesChange">
                <el-checkbox  v-for="field in fieldList" :key="field" :label="field" :value="field.value">
                    {{ field.label }}
                </el-checkbox>
            </el-checkbox-group>
        </div>
        <div style="text-align: right;position: absolute;bottom: 20px;right: 30px;">
            <el-button class="payBtn" @click.stop="onClick">确认导出</el-button>
        </div>
    </div>
</template>
<script setup lang='ts'>
import { onMounted, ref } from 'vue';
import type { CheckboxValueType } from 'element-plus'
import { getExportFields } from '@/api/common'
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const emits = defineEmits(['export'])

const checkAll = ref(false)
const isIndeterminate = ref(true)
const checkedFields = ref<string[]>([])
const fieldList = ref<any[]>([])
const handleCheckAllChange = (val: CheckboxValueType) => {
    checkedFields.value = val ? fieldList.value.map(m => m.value) : []
    isIndeterminate.value = false
}
const handleCheckedCitiesChange = (value: CheckboxValueType[]) => {
    const checkedCount = value.length
    checkAll.value = checkedCount === fieldList.value.length
    isIndeterminate.value = checkedCount > 0 && checkedCount < fieldList.value.length
}
onMounted(async () => {
    const data = await getExportFields(pars?.code ?? '',pars?.tableName ?? '')
    fieldList.value = data ?? [];
});

const onClick = () => {
    emits('export', checkedFields.value)
};
</script>
<style lang='less' scoped>
.yz-export-page {
    height: 100%;
    overflow: hidden;
   

}
</style>