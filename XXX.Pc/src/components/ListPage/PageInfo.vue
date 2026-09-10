<template>
    <div class="top-search xlt-custom " :class="{ 'page-info-tree-content': props.pageConfig.showLeftSearch }">
        <div class="page-info-tree-content-left" v-if="props.pageConfig.showLeftSearch">
            <!-- 搜索 -->
            <div class="tree-search">
                <el-input v-model="leftTreeKeyword" placeholder="请输入关键字" clearable :prefix-icon="Search" />
            </div>

            <!-- 树 -->
            <div class="tree-content">
                <el-tree ref="leftTreeRef" node-key="id" :data="leftTreeData" :props="treeProps"
                    :filter-node-method="filterLeftTree" :highlight-current="true" :expand-on-click-node="false"
                    :default-expand-all="true" :current-node-key="leftTreeCurrentKey" @node-click="handleLeftTreeClick">
                    <template #default="{ node, data }">
                        <div class="tree-node">
                            <span class="tree-node-label">
                                {{ node.label }}
                            </span>

                            <span v-if="data.count != null" class="tree-node-count">
                                {{ data.count }}
                            </span>
                        </div>
                    </template>
                </el-tree>
            </div>
        </div>
        <div class="page-info-tree-content-right">
            <xlt-collapse ref="topSearchRef" :label="'综合查询'" :show="true" v-if='pageConfig.hideSearch != true'>
                <template #content>
                    <el-form>
                        <el-row class="top-search-content">
                            <el-col class="top-search-item" :style="{
                                flex: '0 0 ' + 100 / (24 / rowMaxSearch) + '%'
                            }" v-for="(m, i) in searchItems" :key="i">
                                <template v-if="m.searchType == PagedSearchType.Input">
                                    <el-form-item :label="m.label">
                                        <el-input clearable v-model="m.value" />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.NumberRange">
                                    <el-form-item :label="m.label">
                                        <el-input-number v-model="m.value" :min="1" :max="10" />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.OneSelect">
                                    <el-form-item :label="m.label">
                                        <el-select placeholder="请选择" suffix-icon="CaretBottom" v-model="m.value"
                                            clearable>
                                            <el-option v-for="item in m.option" :key="item.value" :label="item.label"
                                                :value="item.value ?? ''" />
                                        </el-select>
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.OneSelectSearch">
                                    <el-form-item :label="m.label">
                                        <el-select filterable suffix-icon="CaretBottom" placeholder="请选择"
                                            v-model="m.value" collapse-tags collapse-tags-tooltip clearable>
                                            <el-option v-for="item in m.option" :key="item.value" :label="item.label"
                                                :value="item.value" />
                                        </el-select>
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.MultSelect">
                                    <el-form-item :label="m.label">
                                        <el-select filterable suffix-icon="CaretBottom" placeholder="请选择"
                                            v-model="m.value" collapse-tags collapse-tags-tooltip clearable>
                                            <el-option v-for="item in m.option" :key="item.value" :label="item.label"
                                                :value="item.value" />
                                        </el-select>
                                    </el-form-item>
                                </template>

                                <template
                                    v-else-if="m.fieldName != props.pageConfig.showLeftSearch && (m.searchType == PagedSearchType.TreeSelect || m.searchType == PagedSearchType.SelfTreeSelect)">
                                    <el-form-item :label="m.label">
                                        <el-cascader suffix-icon="CaretBottom" filterable v-model="m.value"
                                            placeholder="请选择" :options="m.option" />
                                    </el-form-item>
                                </template>
                                <template
                                    v-else-if="m.searchType == PagedSearchType.MultTreeSelect || m.searchType == PagedSearchType.MultSelfTreeSelect">
                                    <el-form-item :label="m.label">
                                        <el-cascader suffix-icon="CaretBottom" collapse-tags collapse-tags-tooltip
                                            clearable v-model="m.value" placeholder="请选择" :options="m.option" />
                                    </el-form-item>
                                </template>



                                <template v-else-if="m.searchType == PagedSearchType.DateSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="date" suffix-icon="CaretBottom" date-format="yyyy-MM-dd "
                                            :shortcuts="shortcuts" v-model="m.value" placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.MultDateSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="dates" suffix-icon="CaretBottom" :shortcuts="shortcuts"
                                            v-model="m.value" placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.DateTimeSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker v-model="m.value" suffix-icon="CaretBottom" type="datetimerange"
                                            start-placeholder="开始时间" end-placeholder="结束时间"
                                            date-format="yyyy-MM-dd HH:mm:ss" />
                                    </el-form-item>
                                </template>

                                <template v-else-if="m.searchType == PagedSearchType.DateRangeSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="daterange" range-separator="至" start-placeholder="开始日期"
                                            end-placeholder="结束日期" suffix-icon="CaretBottom"
                                            date-format="yyyy-MM-dd HH:mm:ss" v-model="m.value" placeholder="请选择"
                                            clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.TimeSelect">
                                    <el-form-item :label="m.label">
                                        <el-time-select v-model="m.value" start="00:00" step="00:5" end="23:59"
                                            placeholder="请选择" />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.YaerSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="year" suffix-icon="CaretBottom" v-model="m.value"
                                            placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.MultYaerSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="years" v-model="m.value" placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.YaerRangeSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="yearrange" range-separator="至" start-placeholder="开始年份"
                                            end-placeholder="结束年份" suffix-icon="CaretBottom" v-model="m.value"
                                            placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.MonthSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker t type="month" suffix-icon="CaretBottom" v-model="m.value"
                                            placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.MultMonthSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="months" suffix-icon="CaretBottom" v-model="m.value"
                                            placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.MonthRangeSelect">
                                    <el-form-item :label="m.label">
                                        <el-date-picker type="monthrange" range-separator="至" start-placeholder="开始年月"
                                            end-placeholder="结束年月" suffix-icon="CaretBottom" v-model="m.value"
                                            placeholder="请选择" clearable />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.ProvinceSelect">
                                    <el-form-item :label="m.label">
                                        <el-select placeholder="请选择" suffix-icon="CaretBottom" v-model="m.value"
                                            clearable>
                                            <el-option v-for="item in m.option" :key="item.value" :label="item.label"
                                                :value="item.value ?? ''" />
                                        </el-select>
                                    </el-form-item>
                                </template>
                                <!-- TODO 将CitySelect 和 CitySelect option改为默认数据 -->
                                <template v-else-if="m.searchType == PagedSearchType.CitySelect">
                                    <el-form-item :label="m.label">
                                        <el-cascader suffix-icon="CaretBottom" filterable v-model="m.value"
                                            placeholder="请选择" :options="m.option" />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.searchType == PagedSearchType.AreaSelect">
                                    <el-form-item :label="m.label">
                                        <el-cascader suffix-icon="CaretBottom" filterable v-model="m.value"
                                            placeholder="请选择" :options="m.option" />
                                    </el-form-item>
                                </template>
                                <template v-else-if="m.fieldName != props.pageConfig.showLeftSearch">
                                    <el-form-item :label="m.label">
                                        <el-input clearable :value="m.value" />
                                    </el-form-item>
                                </template>
                            </el-col>
                        </el-row>
                    </el-form>
                </template>

                <template #tools>

                    <el-button type="primary" @click.stop="pageFun.searchBtnClick" color='#28a745'
                        size="small">搜索</el-button>
                    <el-button type="primary" @click="pageFun.resetBtnClick" color="#cf851a" style="color:#ffffff"
                        size="small">重置</el-button>
                </template>
            </xlt-collapse>
            <xlt-collapse :label="'数据列表'" :show="true" class="data-list-content">
                <template #content>
                    <div class="data-list-div">
                        <!-- :style="{ flex: 1 }"  -->
                        <DataList ref="dataListRef" :data="dataListRes.list" :pagePars="{
                            fields: pagePars.fields,
                            tableBtns: pagePars.tableBtns,
                        }" :pageConfig="pageConfig" :changeRows="pageFun.changeRows" :openDialog="pageFun.openDialog"
                            :options="pageOptions" :tableProps="pageConfig.tableProps" :table-on="pageConfig.tableOn">
                            <template #custom="{ row, scope, item }">
                                <slot name="custom" :row="row" :scope="scope" :item="item"></slot>
                            </template>
                        </DataList>

                        <div class="data-list-pagination" v-if="pageConfig.isPage !== false">
                            <el-pagination v-model:current-page="currentPage" v-model:page-size="pageSize"
                                :page-sizes="[50, 100, 200, 300, 400, 500]" :total="dataListRes.total"
                                class="page-pagination" size="small" background
                                layout="total, sizes, prev, pager, next, jumper" @size-change="handleSizeChange"
                                @current-change="handleCurrentChange" />
                        </div>
                    </div>
                </template>
                <template #tools>
                    <el-button type="primary" v-for="item in pagePars.btns" :key="item.eventName" style="color:#ffffff"
                        :color="item.bgColor ?? '#1485EE'" @click="pageFun.handleBtnClick('' + item.eventName)"
                        size="small">{{
                            item.label }}</el-button>
                </template>
            </xlt-collapse>
        </div>

        <!-- FullScreen -->
        <!-- Close -->
        <!-- Minus -->
        <!-- 动态渲染所有弹框 -->
        <el-dialog v-model="showDialog" class="page-dialog" :class="dialogSetting.class ?? ''" :show-close="false"
            :destroy-on-close="true" draggable align-center :width="isFullScreen ? '100%' : (dialogSetting.width ?? '')"
            :style="{
                height: isMin ? '60px' : (isFullScreen ? '100%' : dialogSetting.height ?? '60%'),
                top: isMin ? '0' : '',
                left: isFullScreen ? '0' : '',
                margin: isFullScreen ? '0' : ''
            }">
            <template #header>
                {{ dialogFormTitle }}
                <div class="dialog-tools">
                    <el-button @click="isMin = !isMin">
                        <el-icon>
                            <Minus />
                        </el-icon>
                    </el-button>
                    <el-button @click="isFullScreen = !isFullScreen; isMin = false">
                        <el-icon>
                            <FullScreen />
                        </el-icon>
                    </el-button>
                    <el-button @click="pageFun.colseDialog">
                        <el-icon>
                            <Close />
                        </el-icon>
                    </el-button>
                </div>
            </template>
            <component :key="dialogKey" :is="currentDialogComp" :pars="{ ...dialogForm }"
                @refreshList="pageFun.searchBtnClick" @closeDialog="pageFun.colseDialog"
                v-on="dialogSetting.funs ?? {}" />
        </el-dialog>
    </div>
</template>
<script setup lang="ts">
import { ref, shallowRef, onMounted, markRaw, watch, computed, onBeforeUnmount, compile } from 'vue'
import dayjs from 'dayjs'
import DataList from '@/components/ListPage/DataList.vue'
import XltCollapse from '@/components/Custom/XltCollapse.vue'
import type { TempListPageConfig, TableField, SearchItem } from './index'
import { menuService } from '@/api'
import { getPageListByUrl, getPageOptionByUrl, getPageRenderByUrl } from '@/api-services'
import type { PagedOptions, PagedSearchWhere, SysMenuTableButtonDto } from '@/api-services/generated'
import { FieldType, PagedSearchType } from './index'
import { getQueryByName } from '@/utils/pcRouter'
import { Search } from '@element-plus/icons-vue'
import { isArray, isFunction, isNullOrUnDef, isNumber, isString } from '@/utils/is'
const shortcuts = [
    {
        text: 'jin',
        value: new Date(),
    },
    {
        text: 'Yesterday',
        value: () => {
            const date = new Date()
            date.setTime(date.getTime() - 3600 * 1000 * 24)
            return date
        },
    },
    {
        text: 'A week ago',
        value: () => {
            const date = new Date()
            date.setTime(date.getTime() - 3600 * 1000 * 24 * 7)
            return date
        },
    },
]
const topSearchRef = ref();
const changeResize = ref(false)
const rowMaxSearch = computed(() => {
    const len = changeResize.value ?? 0;
    if (topSearchRef.value) {
        const width = topSearchRef.value?.$el?.offsetWidth || 0;
        if (width >= 1920) {
            return 3;
        } else if (width >= 1400 && width < 1920) {
            return 4;
        } else if (width > 800 && width < 1400) {
            return 6;
        } else if (width <= 800) {
            return 12;
        } else if (width <= 300) {
            return 12;
        }
        else {
            return 6;
        }
    }
    return 6;
});

const leftTreeItem = computed<SearchItem>(() => {
    var name = '';
    if (isString(props.pageConfig.showLeftSearch)) {
        name = props.pageConfig.showLeftSearch;
        return searchItems.value?.filter(m => m.fieldName == name)[0] ?? {} as SearchItem;
    }
    return {} as SearchItem;
})
const leftTreeRef = ref()

/**
 * 左侧树搜索关键字
 */
const leftTreeKeyword = ref('')

/**
 * 当前选中的节点
 */
const leftTreeCurrentKey = ref<any>(null)

/**
 * Tree 字段配置
 */
const treeProps = {
    children: 'children',
    label: 'label'
}

/**
 * 左侧 Tree 数据
 */
const leftTreeData = computed(() => {
    const data = leftTreeItem.value?.option ?? []

    return [
        {
            id: '__all__',
            label: '全部',
            value: null,
            isAll: true
        },
        ...data
    ]
})
/**
 * Tree 搜索
 */
const filterLeftTree = (
    value: string,
    data: any,
    node: any
) => {
    if (!value) {
        return true
    }

    const label = String(
        data.label ??
        data.name ??
        data.title ??
        ''
    )

    return label
        .toLowerCase()
        .includes(value.toLowerCase())
}
watch(leftTreeKeyword, (value) => {
    leftTreeRef.value?.filter(value)
})
const handleLeftTreeClick = (data: any) => {

    if (!searchItems.value) {
        return
    }

    const fieldName = props.pageConfig.showLeftSearch

    if (!isString(fieldName)) {
        return
    }

    const searchItem = searchItems.value.find(
        x => x.fieldName === fieldName
    )

    if (!searchItem) {
        return
    }

    /**
     * 点击全部
     */
    if (data.isAll) {
        searchItem.value = null
        leftTreeCurrentKey.value = '__all__'
    }
    else {
        /**
         * Tree 节点值
         */
        searchItem.value =
            data.value ??
            data.id

        leftTreeCurrentKey.value = data.id
    }

    /**
     * 重新查询
     */
    currentPage.value = 1

    pageFun.getDataList()
}
function handleResize() {
    // 触发响应式更新
    changeResize.value = !changeResize.value;
}

onMounted(() => {
    window.addEventListener('resize', handleResize);
});

onBeforeUnmount(() => {
    window.removeEventListener('resize', handleResize);
});
const menuId = getQueryByName('menuId') || null;
const dataListRef = ref()
const pagePars = ref({
    search: [] as SearchItem[],
    btns: [] as SysMenuTableButtonDto[],
    tableBtns: [] as SysMenuTableButtonDto[],
    fields: [] as TableField[]
})
const props = defineProps<{
    pageConfig: TempListPageConfig
}>()

const expandAllColumn = ref(false)
// 管理所有弹框的数组
const showDialog = ref(false)
const isFullScreen = ref(false)
const isMin = ref(false)
const currentDialogComp = shallowRef() // 当前弹窗组件
const dialogKey = ref(0)
const dialogForm = ref({}) // 弹窗表单数据
const dialogFormTitle = ref('') // 弹窗标题
const dialogSetting = ref({} as any)
const selectedRows = ref<any[]>([]) // 用于记录表格行变化
const pageOptions = ref<Record<string, PagedOptions[]>>({})

let dataListRes = ref<{
    list: any[], total?: number
}>({
    list: [],
    total: 0
})
const currentPage = ref(1)
const pageSize = ref(50)
const searchItems = ref<SearchItem[]>();
const pageFun = {
    getDataList: () => {
        if (props.pageConfig.customData) {
            dataListRef.value.list = props.pageConfig.customData.list;
            dataListRef.value.total = props.pageConfig.customData.total;
            return;
        }
        if (props.pageConfig.url) {
            if (isFunction(props.pageConfig.url)) {
                return props.pageConfig.url({
                    pageSize: pageSize.value,
                    pageIndex: currentPage.value, menuId: props.pageConfig.customListPage ? '' : menuId,
                    where: props.pageConfig.where,
                    searchWhere: [...pageFun.getSearchPars()],
                    customWhere: props.pageConfig?.customWhere,
                }).then((res: any) => {
                    if (res.data.statusCode == 200) {
                        var dataList = res.data?.data || [];
                        dataListRes.value.list = Array.isArray(dataList) ? dataList.slice() : (dataList.items || []);
                        if (res.data.data.total != null && res.data.data.total != undefined && isNumber(res.data.data.total)) dataListRes.value.total = res.data.data.total;
                        else props.pageConfig.isPage = false;
                        props.pageConfig.successCb && props.pageConfig.successCb(dataListRes.value);
                        props.pageConfig.expandAll && pageFun.expandAll(true);
                    }
                });
            }
            getPageListByUrl(props.pageConfig.url, {
                pageSize: pageSize.value, page: currentPage.value, menuId: props.pageConfig.customListPage ? '' : menuId,
                where: props.pageConfig.where,
                searchWhere: [...pageFun.getSearchPars()],
                customWhere: props.pageConfig.customWhere
            }).then((res: any) => {
                if (res.code == 0) {
                    dataListRes.value.list = Array.isArray(res.data) ? res.data.slice() : [];
                    if (res.total != null && res.total != undefined && isNumber(res.total)) dataListRes.value.total = res.total; else props.pageConfig.isPage = false;
                    props.pageConfig.successCb && props.pageConfig.successCb(res.data);
                    props.pageConfig.expandAll && pageFun.expandAll(true);
                }
            })
            return;
        }
        // getPageListDataById().then((res: any) => {
        //     if (res.code === 200) {
        //         // 处理数据列表
        //         dataListRes.value = res.data;
        //     }
        // })
    },
    getOptions: async () => {
        if (props.pageConfig.customData) {
            return;
        }
        if (props.pageConfig.optionUrl) {
            if (isFunction(props.pageConfig.optionUrl)) {
                var res = await props.pageConfig.optionUrl();
                if (res.data.statusCode == 200) {
                    pageOptions.value = res.data.data;
                }
                return;
            }
            var optionRes = await getPageOptionByUrl(props.pageConfig.optionUrl);
            if (res.code.statusCode == 200) {
                pageOptions.value = optionRes.data.data;
            }
            return;
        }
    },
    getRender: async () => {
        if (!props.pageConfig.customListPage || !props.pageConfig.customListPage.fields) {
            if (props.pageConfig.renderUrl) {
                if (isFunction(props.pageConfig.renderUrl)) {
                    var res = await props.pageConfig.renderUrl({ menuId: menuId, menuCode: '' });
                    if (res.data.statusCode == 200) {
                        pagePars.value = handleData({
                            search: [],
                            btns: res.data.data.buttons,
                            tableBtns: res.data.data.tableButtons,
                            fields: res.data.data.fields
                        });
                    }
                    return;
                }
                var renderRes = await getPageRenderByUrl(props.pageConfig.renderUrl, { menuId: menuId, menuCode: '' });
                if (res.code.statusCode == 200) {
                    pagePars.value = handleData({
                        search: [],
                        btns: renderRes.data.data.buttons,
                        tableBtns: renderRes.data.data.tableButtons,
                        fields: renderRes.data.data.fields
                    });
                }
                return;
            } else {
                var tempMenuRes = await menuService.apiSysMenuMenurenderPost({
                    menuId: menuId, menuCode: ''
                });
                if (tempMenuRes.data.statusCode == 200) {
                    pagePars.value = (handleData({
                        fields: tempMenuRes.data.data?.fields,
                        btns: tempMenuRes.data.data?.buttons,
                        tableBtns: tempMenuRes.data.data?.tableButtons,
                        search: []

                    }));
                }


            }
        }
        else {
            pagePars.value = (handleData(props.pageConfig.customListPage));

        }

    },
    setSearchImtes: () => {
        const searchs: SearchItem[] = [];

        if (props.pageConfig.customListPage && props.pageConfig.customListPage.search) {
            var items = props.pageConfig.customListPage.search;
            for (let i = 0; i < items.length; i++) {
                const item = items[i];
                searchs.push({
                    searchType: item.searchType,
                    value: item.value,
                    option: item.option || pageOptions.value?.[item.fieldName] || [],
                    label: item.label,
                    fieldName: item.fieldName
                })
            }
        }

        if (pagePars.value.fields) {
            var fields = pagePars.value.fields;
            for (let i = 0; i < fields.length; i++) {
                const item = fields[i];
                if (item.searchField != false && item.fieldType != FieldType.RightTools && !searchs.find(m => m.fieldName == item.fieldName)) {
                    var options = pageOptions.value[item.fieldName ?? ''];
                    searchs.push({
                        searchType: !!options ? PagedSearchType.OneSelectSearch : PagedSearchType.Input,
                        value: null,
                        option: options,
                        label: item.label ?? "",
                        fieldName: item.fieldName ?? ''
                    })
                }
            }
        }
        if (isString(props.pageConfig.showLeftSearch) && searchs.findIndex(x => x.fieldName == props.pageConfig.showLeftSearch) == -1) {
            searchs.push({
                searchType: PagedSearchType.TreeSelect,
                value: null,
                option: pageOptions.value[props.pageConfig.showLeftSearch ?? ''],
                label: '左侧搜索',
                fieldName: props.pageConfig.showLeftSearch
            })

        }

        searchItems.value = searchs;
    },
    getPars: () => {
        let pars: Record<string, any> = {};
        // Example: iterate and log each search item to use 'm' and avoid unused variable error
        (pagePars.value.search as Array<any>).forEach((m: any) => {
            // 单日期
            if (m.type === 4 && m.value instanceof Date) {
                m.value = dayjs(m.value).format('YYYY-MM-DD HH:mm:ss')
            }
            // 时间范围
            if (m.type === 5 && Array.isArray(m.value)) {
                m.value = m.value.map((v: Date) => dayjs(v).format('YYYY-MM-DD HH:mm:ss'))
            }
            pars['' + m.name] = m.value;
        });
        return pars;
    },
    getSearchPars: () => {
        let pars: Array<PagedSearchWhere> = [] as PagedSearchWhere[]
        // Example: iterate and log each search item to use 'm' and avoid unused variable error
        if (!searchItems.value) {
            return pars;
        }
        searchItems.value.forEach(m => {
            if (!isNullOrUnDef(m.value) && m.value != '') {
                pars.push({
                    fieldName: m.fieldName ?? '',
                    searchType: m.searchType ?? '',
                    fieldValue: Array.isArray(m.value) ? m.value.join(',') : (m.value ?? '').toString()
                });
            }

        });
        return pars;
    },
    searchBtnClick: () => {
        pageFun.getDataList();
    },
    resetBtnClick: () => {
        (pagePars.value.search as Array<any>).forEach((m: any) => {
            m.value = '';
        });
    },
    handleBtnClick: (type: string) => {
        const fun = props.pageConfig.pageFun['' + type];
        if (typeof fun != 'function') {
            // 如果是函数，则调用
            return;
        }
        const config = fun(selectedRows.value);
        if (config != null && config) {
            pageFun.openDialog(config as any)
        }

    },
    openDialog: (config: { comp?: Comment, pars: any, width?: string, height?: string, title?: string, class?: string, refreshList?: boolean, closeCb?: Function, funs?: Record<string, Function> }) => {
        if (typeof config !== 'object' || !config.comp) {
            return;
        }
        // 打开弹窗
        dialogKey.value++;
        currentDialogComp.value = markRaw(config.comp);
        dialogForm.value = config.pars;
        dialogSetting.value.width = config.width ?? '1000px';
        dialogSetting.value.height = config.height ?? '';
        dialogSetting.value.closeCb = config.closeCb ?? null;
        dialogSetting.value.funs = config.funs ?? null;
        dialogSetting.value.class = config.class ?? '';
        showDialog.value = true;
        dialogSetting.value.refreshList = config.refreshList ?? false;
        dialogFormTitle.value = config.title || '标题';
    },
    colseDialog: () => {
        // if (dialogSetting.value.refreshList) {
        //     pageFun.searchBtnClick()
        // }
        // dialogSetting.value.closeCb && dialogSetting.value.closeCb();
        // showDialog.value = false;
        if (dialogSetting.value.refreshList) {
            pageFun.searchBtnClick()
        }
        dialogSetting.value.closeCb && dialogSetting.value.closeCb();
        showDialog.value = false;
        // 延迟重置组件状态
        setTimeout(() => {
            currentDialogComp.value = null;
            dialogForm.value = {};
            dialogSetting.value = {};
        }, 100);
    },
    changeRows: (rows: Array<any>) => {
        selectedRows.value = rows;
    },
    getSelectionRows: () => {
        return dataListRef.value.getSelectionRows();
    },
    toggleRowSelection: (row: any, selected?: boolean) => {
        return dataListRef.value.toggleRowSelection(row, selected);
    },
    toggleRowExpansion: (row: any, expanded?: boolean) => {
        dataListRef.value.toggleRowExpansion(row, expanded);
    },
    setCustomData: (list: any[], total?: number) => {
        dataListRes.value = {
            list: list,
            total: undefined
        }
    },
    expandAll: (checked: boolean) => {
        dataListRef.value.expandAll(checked);
    },
    getTableData: () => {
        return dataListRes.value.list;
    },
    changeTableData: (handleCb: Function) => {
        handleCb(dataListRef.value);
    },
    resetTableRowData: (row: any, key: string = 'id', items: any[] = []) => {
        if (!(items && items.length > 0)) {
            items = dataListRes.value.list
        }
        items.forEach((item: any) => {
            if (item[key] == row[key]) {
                item = row;
                console.log('item', item);
                console.log('items', dataListRes.value.list);
            }
            else if (item.children && item.children.length > 0) {
                pageFun.resetTableRowData(row, key, item.children);
            }
        })
    }

}

onMounted(async () => {
    await pageFun.getRender();
    await pageFun.getOptions();
    pageFun.getDataList(); // 初始化数据列表
    pageFun.setSearchImtes();

})
const handleData = (data: any) => {
    if (!data.fields) return data;
    let autoWidthAny = data.fields.filter((item: any) => item.width == '').length > 0;
    if (!autoWidthAny && data.fields.length < 9) {
        const fields = data.fields.filter((item: any) => item.fieldType != FieldType.RightTools && !item.floatType);
        if (fields.length > 0) {
            const lastField = fields[fields.length - 1];
            if (lastField) lastField.width = '';
        }
    }
    let rightToolsWidth = 0;
    const maxBtn = props.pageConfig.maxBtn ?? 5;
    (data.tableBtns ?? []).forEach((item: any, index: number) => {
        if (index >= maxBtn) {
            return;
        }
        if ((index == maxBtn) && data.tableBtns.length > maxBtn) {
            rightToolsWidth += 50;
        }
        else {
            rightToolsWidth += 30 + item.label.length * 12;
        }
    });
    data.fields.filter((item: any) => item.template == 'rightTools' || item.fieldType == FieldType.RightTools).forEach((item: any) => {
        item.width = data.tableBtns.length == 0 ? '120' : (((rightToolsWidth + 24) < 120 ? 120 : (rightToolsWidth + 24)) + '')
    })
    return data
}
const handleSizeChange = (val: number) => {
    pageFun.getDataList();

}
const handleCurrentChange = (val: number) => {
    pageFun.getDataList();
}

defineExpose({
    expandAll: pageFun.expandAll,
    openDialog: pageFun.openDialog,
    onRefresh: pageFun.searchBtnClick,
    getSelectionRows: pageFun.getSelectionRows,
    setCustomData: pageFun.setCustomData,
    toggleRowSelection: pageFun.toggleRowSelection,
    toggleRowExpansion: pageFun.toggleRowExpansion,
    getTableData: pageFun.getTableData,
    resetTableRowData: pageFun.resetTableRowData,
    changeTableData: pageFun.changeTableData

})
</script>
<style lang="less">
.home-page {
    .el-dialog__body {
        height: calc(100% - 36px);
        padding: 0 20px;
        overflow-y: auto;
    }

    .el-form-item {
        margin-bottom: 10px;
    }

    .page-dialog {
        .el-dialog {
            padding: 0;
            height: 60%;
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


    }

    .xlt-collapse-content {
        .el-form-item__label {
            /* width: 90px;- */
            /* justify-content: left; */
        }
    }


    .top-search-content {
        .el-select__caret.el-select__icon {
            font-size: 17px;
        }
    }
}
</style>
<style scoped lang="less">
.page-dialog {
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


.top-search {
    height: 100%;
    display: flex;
    flex-direction: column;
}

.top-search-collapse {
    border-radius: 0;

}

.top-search-content {
    margin: 25px 0 0px;
    padding: 0 15px;

    .top-search-item {
        padding: 0 10px;
        margin-bottom: 10px;
    }
}

.data-list-content {
    flex: 1;
    border-top: 0;
    overflow: hidden;

    .data-list-div {
        height: calc(100% - 12px);
        margin: 5px;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        border: 1px solid #e6e6e6;

        .data-list-table {
            flex: 1;
        }

        .data-list-pagination {
            padding: 5px 15px;
            border-top: 1px solid #e6e6e6;
        }
    }
}

.page-info-tree-content {
    display: flex;
    flex-direction: row;
    width: 100%;
    height: 100%;

    .page-info-tree-content-left {
        width: 260px;
        min-width: 260px;
        height: 100%;
        box-sizing: border-box;

        display: flex;
        flex-direction: column;

        background: #fff;
        border: 1px solid #e6e6e6;
        border-radius: 3px;

        margin-right: 6px;
        padding: 10px 6px;

        overflow: hidden;

        .tree-search {
            flex-shrink: 0;
            padding: 0 4px 10px;

            .el-input {
                width: 100%;
            }
        }

        .tree-content {
            flex: 1;
            min-height: 0;
            overflow: auto;

            .el-tree {
                background: transparent;
                font-size: 13px;
            }
        }
    }

    .page-info-tree-content-right {

        border: #e6e6e6 1px solid;
        padding: 5px;
        flex: 1;
    }
}

.tree-node {}

.page-info-tree-content-right {
    border: #e6e6e6 1px solid;
    padding: 5px;
    flex: 1;
    display: flex;
    height: 100%;
    flex-direction: column;
}

:deep(.page-info-tree-content-left .el-tree-node__content) {
    height: 34px;
    margin: 2px 0;
    padding: 0 6px;

    border-radius: 4px;

    transition:
        background-color .15s ease,
        color .15s ease;
}

:deep(.page-info-tree-content-left .el-tree-node__content:hover) {
    background-color: #f5f7fa;
}

:deep(.page-info-tree-content-left .el-tree-node.is-current > .el-tree-node__content) {
    color: #409eff;
    background-color: #ecf5ff;
    font-weight: 500;
}

:deep(.page-info-tree-content-left .el-tree-node.is-current > .el-tree-node__content::before) {
    content: '';
    width: 3px;
    height: 18px;

    position: absolute;
    left: 0;

    border-radius: 2px;

    background: #409eff;
}
</style>
<style lang="less">
.page-pagination {
    .el-pager li {
        background-color: unset !important;

        &.is-active {
            background-color: #409eff !important;
        }
    }

}
</style>