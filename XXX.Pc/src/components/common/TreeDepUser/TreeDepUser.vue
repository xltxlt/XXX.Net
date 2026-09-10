<template>
    <div class="yz-tree-dep-user">
        <div class="search-div">
            <el-input v-model="filterText" class="search-input" placeholder="搜索用户或部门" />
        </div>
        <el-tree ref="treeRef" class="filter-tree" :data="data" :props="defaultProps" default-expand-all
            :filter-node-method="filterNode" @node-click="(data: any, node: any) => emits('itemClick', data, node)">
            <template #default="{ node, data }">
                <slot :data="{ node, data }">
                    <div class="tree-item-content" :class="{
                        'tree-item-checked': data.checked === true,
                        'tree-item-disabled': data.disabled === true,
                    }">
                        <div @click="" class="tree-item-text" :class="{
                            'tree-item-user': data.type == 2,
                            'tree-item-dep': data.type == 1,

                        }">
                            {{ data.title }}
                        </div>
                    </div>

                </slot>
            </template>
        </el-tree>
    </div>
</template>
<script setup lang='ts'>
import { inject, ref, watch, computed } from 'vue'
import type { Ref } from 'vue'
import type { FilterNodeMethodFunction, TreeInstance } from 'element-plus'
const filterText = ref('')
const treeRef = ref<TreeInstance>()
interface Tree {
    [key: string]: any
}
const defaultProps = {
    children: 'children',
    label: 'title',
}
const emits = defineEmits(['itemClick'])
watch(filterText, (val) => {
    treeRef.value!.filter(val)
})
const filterNode: FilterNodeMethodFunction = (value: string, data: Tree) => {
    if (!value) return true
    return data.label.includes(value)
}
const defData = ref<any[]>([])
const treeDepUserData = inject<Ref<any[]>>('treeDepUserData', defData)
const data = computed(() => {
    return treeDepUserData.value
});
</script>
<style lang='less' scoped>
.yz-tree-dep-user {
    height: 100%;

    .filter-tree {
        overflow: auto;
        height: calc(100% - 55px);
    }

    .search-input {

        font-size: 14px;
        height: 40px;

        input {
            background-image: url(/imgs/company/depUser/serach.png);
            background-size: 14px 14px;
            background-position: 0 50%;
            background-repeat: no-repeat;
            padding-left: 50px;
        }
    }

    .tree-item-text {
        background-size: 14px 14px;
        background-position: 0 50%;
        background-repeat: no-repeat;
        padding-left: 22px;
    }

    .tree-item-user {
        background-image: url(/imgs/company/depUser/user.png);

    }

    .tree-item-dep {
        background-image: url(/imgs/company/depUser/dep.png);
    }

    .tree-item-content {
        width: 100%;
        text-align: left;
    }

    .tree-item-checked {
        background-image: url(/imgs/company/depUser/checked.png);
        background-size: 14px 14px;
        background-position: calc(100% - 15px) 50%;
        background-repeat: no-repeat;
    }
}
</style>
<style lang="less">
.yz-tree-dep-user {
    .el-tree {
        margin-top: 20px;
        color: #222222;

        .el-tree-node__content {
            height: 30px;
            line-height: 30px;
        }

        .el-tree-node__expand-icon {
            color: #88939F;
            padding: unset;
            font-size: 15px !important;
            margin-right: 6px;
        }
    }

    .search-input {
        input {
            background-image: url(/imgs/company/depUser/search.png);
            background-size: 14px 14px;
            background-position: 5px 50%;
            background-repeat: no-repeat;
            padding-left: 35px;
        }
    }
}
</style>