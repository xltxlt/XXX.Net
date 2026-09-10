<template>
    <div class="option-editor">

        <div class="option-header">
            <el-button type="primary" link :icon="Plus" @click="addOption">
                添加选项
            </el-button>
        </div>

        <!-- 表头 -->

        <!-- 选项 -->
        <div v-for="(item, index) in options" :key="index" class="option-row">
            <el-input v-model="item.label" placeholder="请输入选项名称" @input="handleChange" />

            <el-input v-model="item.value" placeholder="请输入选项值" @input="handleChange" />

            <el-button type="danger" link :icon="Delete" @click="removeOption(index)">
                删除
            </el-button>
        </div>

        <el-empty v-if="options.length === 0" description="暂无选项" :image-size="60" />

    </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import {
    Plus,
    Delete
} from '@element-plus/icons-vue'

interface SelectOption {
    label: string
    value: string | number
}

const props = withDefaults(
    defineProps<{
        modelValue?: string
    }>(),
    {
        modelValue: '[]'
    }
)

const emit = defineEmits<{
    'update:modelValue': [value: string]
    change: [value: string]
}>()

/**
 * JSON -> Array
 */
const options = computed<SelectOption[]>({
    get() {
        if (!props.modelValue) {
            return []
        }

        try {
            const value = JSON.parse(props.modelValue)

            return Array.isArray(value)
                ? value
                : []
        } catch {
            return []
        }
    },

    set(value) {
        updateValue(value)
    }
})

/**
 * 更新 JSON
 */
const updateValue = (value: SelectOption[]) => {

    const json = JSON.stringify(value)

    emit('update:modelValue', json)

    emit('change', json)
}

/**
 * 输入修改
 */
const handleChange = () => {

    updateValue([...options.value])
}

/**
 * 添加
 */
const addOption = () => {

    const index = options.value.length + 1

    const list = [
        ...options.value,
        {
            label: `选项${index}`,
            value: `option${index}`
        }
    ]

    updateValue(list)
}

/**
 * 删除
 */
const removeOption = (index: number) => {

    const list = options.value.filter(
        (_, i) => i !== index
    )

    updateValue(list)
}
</script>

<style scoped>
.option-editor {
    width: 100%;
    border: 1px solid #dcdee6;
    padding: 10px;
    border-radius: 3px;
}

.option-header {
    display: flex;
    justify-content: space-between;
    align-items: center;

    margin-bottom: 10px;
}

.title {
    font-size: 14px;
    font-weight: 500;
}

.option-table-header {
    display: grid;
    grid-template-columns: 1fr 1fr 60px;

    gap: 8px;

    margin-bottom: 6px;
    padding: 0 10px;
    text-align: left;
    font-size: 14px;
    color: var(--el-text-color-secondary);
}

.option-row {
    display: grid;
    grid-template-columns: 1fr 1fr 60px;

    gap: 8px;

    align-items: center;

    margin-bottom: 8px;
}
</style>
