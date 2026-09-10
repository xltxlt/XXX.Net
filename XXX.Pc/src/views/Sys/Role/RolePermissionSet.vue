<template>
    <div class="company-permission">
        <PageInfo :pageConfig="pageConfig" ref="pageInfoRef">
            <template #custom="{ scope, row, item }">
                <template v-if="item.fieldType == FieldType.Custom && row[item.fieldName]?.length > 0">
                    <el-checkbox-group v-model="row[item.fieldName + 'All']" @change="(val: any) => {
                        var index = val.indexOf('all')
                        if (index > -1) {
                            row[item.fieldName + 'Values'] = row[item.fieldName].filter((item: any) => item.isCancelSelect !== false).map((item: any) => item.id)
                        }
                        else {
                            row[item.fieldName + 'Values'] = []
                        }
                    }">
                        <el-checkbox label="全选" value="all" />
                    </el-checkbox-group>
                    <el-checkbox-group v-model="row[item.fieldName + 'Values']">
                        <el-checkbox v-for="m, index in row[item.fieldName]" :label="m.label" :value="m.id" :key="index"
                            :disabled="m.isCancelSelect === false" :class="{
                                'el-checkbox-disabled': m.isCancelSelect === false
                            }" />
                    </el-checkbox-group>
                </template>
                <template v-else>
                </template>
            </template>
        </PageInfo>
        <el-button type="primary" style="z-index: 3;position: fixed;right: 60px;bottom: 30px;"
            @click="submit">确认</el-button>
    </div>
</template>

<script lang="ts" setup>
import { onMounted, ref, watch, nextTick } from 'vue'
import PageInfo from '@/components/ListPage/PageInfo.vue'
import { AlignTypeEnum, FieldType, type TempListPageConfig } from '@/components/ListPage'
// import { getRolePageData, setRolePermission } from '@/api/auth'
import { handleSumbitResTip } from '@/utils/common'
import { ElMessage } from 'element-plus'
import { menuService, roleService } from '@/api'
const emit = defineEmits(['closeDialog', 'refreshList'])

const pageInfoRef = ref()

const submit = async () => {
    const permissionSelections = pageInfoRef.value.getSelectionRows()
    const setRolePermissionDto: any = {};
    setRolePermissionDto.roleId = pars?.id ?? '';
    setRolePermissionDto.menuFieldIds = [];
    setRolePermissionDto.menuIds = [];
    setRolePermissionDto.menuButtonIds = [];
    permissionSelections.forEach((item: any) => {
        setRolePermissionDto.menuIds?.push(item.id);
        console.log(JSON.stringify(item.menuButtonsValues));
        setRolePermissionDto.menuButtonIds.push(...item.menuButtonsValues);
        setRolePermissionDto.menuFieldIds.push(...item.menuFieldsValues);
    })
    const res = await roleService.apiSysRoleSetrolepermissionPost(setRolePermissionDto);
    handleSumbitResTip(res, '设置成功', () => {
        emit('closeDialog')
        emit('refreshList')
    })
}
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const selectionList = ref<any[]>([])
const pageConfig = ref<TempListPageConfig>({
    url: menuService.apiSysMenuAllmenucomposePost.bind(menuService),
    treeProps: {
        checkStrictly: true,
    },
    treeField: 'name',
    rowKey: 'id',
    hideSearch: true,
    showTooltip: false,
    defChecked: true,
    tableProps: {
        children: 'children'
    },
    
    tableOn: {
        'select-all': (selection: any[]) => {
            selectionList.value = selection;

        },
        select: (selection: any[], row: any) => {
            selectionList.value = treeNodeTap(row, selection);
            let changeRow: any[] = []
            hasChildCheck(changeRow, permissionList, selectionList.value)
            changeRow.forEach(m => {
                pageInfoRef.value.toggleRowSelection(m, m.treeChecked)
            })
        },

    },
    customListPage: {
        search: [],
        btns: [
        ],
        fields: [
            {
                fieldName: "name",
                label: "标题",
                width: "150",
                fieldType: FieldType.Default,
                alignType: AlignTypeEnum.Center,
            },
            {
                fieldName: "menuFields",
                label: "表头字段",
                fieldType: FieldType.Custom,
                width: "",
            },
            {
                fieldName: "menuButtons",
                label: "操作按钮",
                fieldType: FieldType.Custom,
                width: "",
            },

        ],
        "tableBtns": [
        ]
    },
    pageFun: {
    },
    successCb:async (dataList:any) => {
       await setCheckedItem(dataList);
    }

})


const checkboxSelect = ref(false)
let permissionList: any[] = []
onMounted(async () => {

})
const setCheckedItem = async (dataList:any) => {
    const res = await roleService.apiSysRoleRolepermissionIdGet(pars?.id);
    if (res.data.statusCode != 200) {
        return;
    }
    var pageData: any[] = res.data?.data?.menus || [];
    setCheckList(pageData)
    pageInfoRef.value.changeTableData((data: any) => {
        pageData.forEach((item: any) => {
            var row = dataList.list.find((m: any) => m.id == item.id);
            if (row) {
                row.menuButtonsValues = item.menuButtons.map((item: any) => item.id)
                row.menuFieldsValues = item.menuFields.map((item: any) => item.id)
                pageInfoRef.value.toggleRowSelection(row);
            }
            else {
                dataList.list.map((m: any) => {
                    if (m.children && m.children.length > 0) {
                        var row = m.children.find((n: any) => n.id == item.id);
                        if (row) {
                            row.menuButtonsValues = item.menuButtons.map((item: any) => item.id)
                            row.menuFieldsValues = item.menuFields.map((item: any) => item.id)
                            pageInfoRef.value.toggleRowSelection(row);
                        }
                    }
                })
            }
        })
    })
    nextTick(() => {
        selectionList.value = pageInfoRef.value.getSelectionRows();
    })
}
const setDefChecked = (selections: any[], handleFun: Function) => {
    selections.forEach(item => {
        if (item.checked == 1) {
            console.log(item);
            handleFun(item, true);
        }
        if (item.children && item.children.length > 0) {
            setDefChecked(item.children, handleFun)
        }
    })
}

const setCheckList = (selections: any[]) => {
    selections.forEach(item => {
        if (item.checked != 0) {
            item.menuButtonsValues = item.menuButtons.map((item: any) => item.id)
            item.menuFieldsValues = item.menuFields.map((item: any) => item.id)
        }
        if (item.children && item.children.length > 0) {
            setCheckList(item.children)
        }
    })
}
//非叶子节点点击处理
const treeNodeTap = (row: any, selection: any[]): any[] => {
    const cancel = (!selection || selection.length == 0 || selection.filter(m => m.id == row.id).length == 0);
    let nList: any[] = JSON.parse(JSON.stringify(selection));
    if (!row || !row.children || row.children.length == 0) {
        return selection;
    }

    return handleTreeNodeTap(row, selection, cancel, nList);
}
const handleTreeNodeTap = (row: any, selection: any[], cancel: boolean, nList: any[]): any[] => {
    row.children.forEach((m: any) => {
        // selection = selection.filter(item => item.value != m.value);
        m.checked = !cancel;
        if (!cancel) {
            nList.push(m)
        }
        else {
            nList = nList.filter(item => item.id != m.id);
        }

        pageInfoRef.value.toggleRowSelection(m, !cancel)
        if (m.children && m.children.length > 0) {
            return handleTreeNodeTap(m, selection, cancel, nList);
        }
    })
    return nList
}

//获取后代叶子节点是否有选中
const hasChildCheck = (changeRow: any[], row: any[], allSelections: any[]) => {
    let hasCheck = false;
    row.forEach(m => {
        const checed = setCheckChecked(changeRow, m, allSelections)
        if (hasCheck == false) hasCheck = checed;
    });
    return hasCheck;
}
const setCheckChecked = (changeRow: any[], m: any, allSelections: any[]) => {
    if (m.children && m.children.length > 0) {
        const hasCheck = hasChildCheck(changeRow, m.children, allSelections);
        if (m.treeChecked != hasCheck) {
            m.treeChecked = hasCheck;
            changeRow.push(m);
        }
        return hasCheck;
    }
    return allSelections.filter((item: any) => item.id == m.id).length > 0;
}


watch(() => selectionList.value, (nVal: any[], oVal: any[]) => {
    if (checkboxSelect.value == false) {
        checkboxSelect.value = true;
        return;
    }
    oVal.forEach((row: any) => {

        if (nVal.find(item => item.id == row.id)) return;
        if (!!row.children && row.children.length > 0) return;
        row.menuFieldsValues = []
        row.menuButtonsValues = []
        row['menuFieldsAll'] = []
        row['menuButtonsAll'] = []

    })
    nVal.forEach((row: any) => {
        console.log(row)
        if (oVal.find(item => item.id == row.id)) return;
        if (!!row.children && row.children.length > 0) return;
        row['menuFieldsAll'] = ['all']
        row['menuButtonsAll'] = ['all']
        row.menuFieldsValues = row.menuFields.filter((item: any) => item.isCancelSelect !== false).map((item: any) => item.id)
        row.menuButtonsValues = row.menuButtons.filter((item: any) => item.isCancelSelect !== false).map((item: any) => item.id)

    });
})

</script>
<style lang="less" scoped>
.demo-tabs {
    width: 100%;
    min-height: calc(100% - 77px);
}
</style>

<style lang="less">
.company-permission {

    position: relative;

    .el-steps.el-steps--horizontal {
        width: 50%;
        margin: 0 auto
    }

    .el-step__title.is-process {
        font-weight: 400;
    }

    .el-tabs__header {
        display: none;
    }

    .el-checkbox__input.is-checked+.el-checkbox__label {
        color: #000;
    }
}
</style>