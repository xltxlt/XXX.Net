<template>
    <div class="company-dep-page" ref="companyDepPageRef">
        <div class="search-div" style="display: flex;">
            <el-select v-model="companyId" placeholder="请选择公司" class="search-company">
                <el-option v-for="item in companyListData" :key="item.id" :label="item.name" :value="item.id" />
            </el-select>
            <input type="text" placeholder="搜索部门名称" v-model="companyTitle" class="searchText"></input>
            <el-button type="button" id="search-btn" @click="pageFun['loadData']">
            </el-button>
        </div>
        <div class="orgPage" id="draggablePage" ref="orgPageEle"
            :style="{ transform: `scale(${zoomSize / 100})`, transformOrigin: 'center center' }"
            style="display: inline-block;">
            <TreeDep @btn-click="handleBtnFun" @content-click="openDepInfo" :org-tree="depData||[]" :draging="draging"
                :allow-drop="pageFun.allowDrop" :drop="pageFun.drop" :drag="pageFun.drag" :root="true"></TreeDep>
        </div>
        <div class="scale-div">
            <div class="scale-val">{{ zoomSize }}%</div>
            <div class="scale-reduce" @click="scalePage(false)"></div>
            <div class="scale-add" @click="scalePage(true)"></div>
            <button type="button" class="scale-reload" @click="zoomSize = 100">重置</button>
        </div>
    </div>
    <YzPopup ref="yzPopupRef" class="" @close-dialog="" @refresh-list="()=>{pageFun['loadData']}"></YzPopup>
</template>
<script setup lang='ts'>
import { ref, onUnmounted, onMounted } from 'vue'
import TreeDep, { type OrgItem } from '@/components/common/TreeDep/TreeDep.vue';
import { getQueryByName } from '@/utils/pcRouter';
import { ElMessageBox } from 'element-plus';
import { handleSumbitResTip } from '@/utils/common';
import YzPopup from '@/components/common/YzPopup/YzPopup.vue';
import DepUser from './DepUser.vue';
import SetDepManage from './SetDepManage.vue';
import DepMemberManage from './DepMemberManage.vue';
import type { YzDialogPars } from '@/components/common/YzPopup';
import DepEdit from './DepEdit.vue';
import { depService, tenantService, userDepRoleService } from '@/api/index.ts';
import type { DepUserSummaryOutput, SysTenantDto } from '@/api-services/generated/index.ts';
const companyDepPageRef = ref<HTMLElement | null>(null)
const orgPageEle = ref<HTMLElement | null>(null)
const draging = ref<boolean>(false)
const companyTitle = ref<string>('')
const companyId = ref<string>('')
const companyListData = ref<SysTenantDto[]>();
const menuId = getQueryByName('menuId')

const depData = ref<OrgItem[]>([])
const oldDepData = ref<DepUserSummaryOutput[]>([])

const yzPopupRef = ref()
const yzPopupPars: YzDialogPars = {
    title: '',
    comp: null,
    height: '80%',
    width: '1000px',
    pars: {}
}
/**
 * 打开部门信息
 * @param id 
 */
const openDepInfo = (id: string, item: any) => {
    yzPopupPars.height = '80%';
    yzPopupPars.width = '950px';
    yzPopupPars.comp = DepUser
    yzPopupPars.title = item?.title ?? '部门信息'
    yzPopupPars.pars = { id, type: 'openDepInfo',tenantId:companyId.value }
    yzPopupRef.value.open(yzPopupPars)
}
const handleBtnFun = (type: string, item: any) => {
    const fun = btnFuns[type];
    fun && fun(item)
}
const btnFuns: Record<string, Function> = {
    addDep: (item: any) => {
        yzPopupPars.comp = DepEdit
        yzPopupPars.height = '70%';
        yzPopupPars.width = '750px';
        yzPopupPars.title = `添加子部门（${item?.title ?? ''}）`;
        yzPopupPars.pars = { parentId: item.id,tenantId:companyId.value }
        yzPopupRef.value.open(yzPopupPars)
    },
    editDep: (item: any) => {
        yzPopupPars.comp = DepEdit
        yzPopupPars.height = '70%';
        yzPopupPars.width = '750px';
        yzPopupPars.title = `编辑部门（${item?.title ?? ''}）`;
        yzPopupPars.pars = { id: item.id, parentId: item.pId,tenantId:companyId.value }
        yzPopupRef.value.open(yzPopupPars)
    },
    setDepManage:(item:any)=>{
        yzPopupPars.comp = SetDepManage
        yzPopupPars.height = '80%';
        yzPopupPars.width = '900px';
        yzPopupPars.title = `设置负责人（${item?.title ?? ''}）`;
        yzPopupPars.pars = { id: item.id, parentId: item.pId,tenantId:companyId.value,depTitle:item?.name??'' }
        yzPopupRef.value.open(yzPopupPars)
    },
     addDepMember:(item:any)=>{
        yzPopupPars.comp = DepMemberManage
        yzPopupPars.height = '80%';
        yzPopupPars.width = '900px';
        yzPopupPars.title = `部门成员管理（${item?.name ?? ''}）`;
        yzPopupPars.pars = { id: item.id,tenantId:companyId.value, parentId: item.pId, depTitle:item?.name??'' }
        yzPopupRef.value.open(yzPopupPars)
    },
   
}
// 滚动到中间位置
const toCenter = () => {
    if (!orgPageEle.value || !companyDepPageRef.value) return;
    const offsetWidth = orgPageEle.value.offsetWidth - companyDepPageRef.value?.offsetWidth
    if (offsetWidth > 0) {
        companyDepPageRef.value?.scrollTo({
            left: offsetWidth / 2,
            top: 0,
            behavior: 'smooth'
        })
    }
}
const zoomSize = ref(100)
const scalePage = (zoom: boolean) => {
    if (zoomSize.value == 10 && !zoom) return;
    if (zoomSize.value == 500 && zoom) return;
    zoomSize.value = zoom ? zoomSize.value + 10 : zoomSize.value - 10;
}
const handleWheel = (event: WheelEvent) => {
    // 阻止默认滚动行为
    event.preventDefault()

    // 判断滚轮方向，向上放大，向下缩小
    if (event.deltaY < 0) {
        // 向上滚动，放大
        scalePage(true)
    } else {
        // 向下滚动，缩小
        scalePage(false)
    }
}
// 添加键盘事件处理函数
const handleKeyDown = (event: KeyboardEvent) => {
    // 检查是否按下了 Ctrl + 0
    if (event.ctrlKey && event.key === '0') {
        event.preventDefault()
        zoomSize.value = 100

        // 重置后重新居中
        setTimeout(() => {
            toCenter()
        }, 50)
    }
    // 检查是否按下了空格键
    else if (event.code === 'Space') {
        event.preventDefault()
        toCenter()
    }
}
// 拖拽功能相关变量
let startY = 0
let startScrollTop = 0
let startX = 0
let startScrollLeft = 0
let isDragging = false

// 存储事件处理器的引用
let mouseMoveHandler: ((event: MouseEvent) => void) | null = null
let mouseUpHandler: (() => void) | null = null
let contextMenuHandler: ((event: Event) => void) | null = null

// 拖拽处理
const dragg = () => {
    const draggable = document.getElementById('draggablePage')
    if (!draggable) return

    const handleMouseDown = (event: MouseEvent) => {
        if (event.button !== 2) { // 只处理右键
            return
        }

        isDragging = true
        draggable.classList.add("move-page")
        startY = event.clientY
        startScrollTop = companyDepPageRef.value?.scrollTop ?? 0
        startX = event.clientX
        startScrollLeft = companyDepPageRef.value?.scrollLeft ?? 0
        // 定义鼠标移动处理函数
        mouseMoveHandler = (event: MouseEvent) => {
            if (!isDragging) return

            const deltaY = event.clientY - startY
            const deltaX = event.clientX - startX
            companyDepPageRef.value?.scrollTo(startScrollLeft - deltaX, startScrollTop - deltaY)
        }

        // 定义鼠标松开处理函数
        mouseUpHandler = () => {
            isDragging = false
            draggable.classList.remove("move-page")

            // 清理事件监听器
            if (mouseMoveHandler) {
                document.removeEventListener('mousemove', mouseMoveHandler)
                mouseMoveHandler = null
            }
            if (mouseUpHandler) {
                document.removeEventListener('mouseup', mouseUpHandler)
                mouseUpHandler = null
            }
        }

        document.addEventListener('mousemove', mouseMoveHandler)
        document.addEventListener('mouseup', mouseUpHandler)
    }

    // 定义阻止右键菜单的处理函数
    contextMenuHandler = (event: Event) => {
        event.preventDefault()
    }

    draggable.addEventListener('mousedown', handleMouseDown)
    document.addEventListener('contextmenu', contextMenuHandler)
}

// 清理所有事件监听器
const cleanupEventListeners = () => {
    if (contextMenuHandler) {
        document.removeEventListener('contextmenu', contextMenuHandler)
        contextMenuHandler = null
    }

    if (mouseMoveHandler) {
        document.removeEventListener('mousemove', mouseMoveHandler)
        mouseMoveHandler = null
    }

    if (mouseUpHandler) {
        document.removeEventListener('mouseup', mouseUpHandler)
        mouseUpHandler = null
    }
    // 移除滚轮事件监听器
    if (companyDepPageRef.value) {
        companyDepPageRef.value.removeEventListener('wheel', handleWheel)
    }
    // 移除键盘事件监听器
    document.removeEventListener('keydown', handleKeyDown)
}
const dragId = ref('')
const dragOldPId = ref('')
const pageFun: Record<string, Function> = {
    handleBtn: (name: string, data: any) => {
        pageFun[name](data)
    },
    loadData: async () => {
        const res= await userDepRoleService.apiSysUserDepRoleDepusersummaryPost({
            where:{
                'tenantId':companyId.value
            }
        })
        if(res.data.statusCode!=200)return;
        depData.value = (res.data.data||[]) as OrgItem[];
    },
    allowDrop: (ev: any) => {
        ev.preventDefault();
    },
    drag: (ev: any, id: string, pid: string, root: boolean = false,item:any=null) => {
        dragId.value = id;
        dragOldPId.value = pid;
        draging.value = true;
        ev.dataTransfer.setData("Text", ev.target.id);
    },
    drop: (ev: any, targetElId: string, toId: string,item:any) => {
        ev.preventDefault();
        // var data = ev.dataTransfer.getData("Text");
        // const ulEl= pageFun.getChildUl(ev.target);
        // ulEl.appendChild(document.getElementById(data));

        // var data = ev.dataTransfer.getData("Text");
        // const liEl = document.getElementById(targetElId);

        // const ulEl = pageFun.getChildUl(liEl);
        // const draggedElement = document.getElementById(data);
        // if (ulEl && draggedElement) {
        //     ulEl.appendChild(draggedElement);
        // }
        pageFun.moveChildToParent(dragId.value, toId, dragOldPId.value);
        draging.value = false;

    },
    moveChildToParent: (thisId: string, toId: string, oldPId: string) => {
        if (!toId || thisId == toId || toId == oldPId) return;
        oldDepData.value = JSON.parse(JSON.stringify(depData.value));
        const item = pageFun.findItem(depData.value, thisId, null, true);
        const toItem = pageFun.findItem(depData.value, toId, null);
        if (!toItem.children) {
            toItem.children = [];
        }
        toItem.children.push(item);
        ElMessageBox.confirm('确定移动并修改公司部门结构吗？', '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning',
        }).then(async () => {
            // const res = await changeTreeDep(thisId, toId);
            // handleSumbitResTip(res, '移动成功');
            pageFun['loadData']()
        }).catch(() => {
            depData.value = oldDepData.value  as OrgItem[];
        });
    },
    findItem: (data: any[], id: string, parItem: any, del: boolean = false) => {
        let item: any = null;
        data.forEach(m => {
            if (item != null) { return; }
            if (m.id == id) {
                item = m;
                if (del && parItem) {
                    parItem.children.splice(parItem.children.indexOf(m), 1)
                };
                return;
            }
            if (m.children) {
                item = pageFun.findItem(m.children, id, m, del);
                return;
            }
        })
        return item;
    },
    getChildUl: (el: any) => {
        // 只查找直接子元素
        for (let i = 0; i < el.children.length; i++) {
            const child = el.children[i];
            if (child.classList && child.classList.contains('org-ul')) {
                return child as any;
            }
        }

        // 如果没找到，返回 null
        return null;
    }
}
// 组件挂载时初始化
onMounted(async () => {
    var res = await tenantService.apiSysTenantTenantlistPost();
    if(res.data.statusCode!=200)return;
    companyListData.value=res.data.data??[];
    companyId.value = companyListData.value[0].id??'';
    await pageFun.loadData();
    orgPageEle.value = document.querySelector(".orgPage")
    // 添加滚轮事件监听器
    if (companyDepPageRef.value) {
        companyDepPageRef.value.addEventListener('wheel', handleWheel, { passive: false })
    }
    // 添加键盘事件监听器
    document.addEventListener('keydown', handleKeyDown)
    toCenter()
    dragg()
})
// 组件卸载时清理事件监听器
onUnmounted(() => {
    cleanupEventListeners()
})
</script>
<style lang='less' scoped>
::-webkit-scrollbar {
    width: 0px;
    height: 5px;
    display: none;
}

::-webkit-scrollbar-thumb {
    background-color: #888;
    /* 滚动条thumb颜色 */
}

.company-dep-page {
    height: 100%;
    width: 100%;
    background-color: #F8F9FB;
    overflow: auto;

    .orgPage {
        min-height: 100%;
        min-width: 100%;
    }

    .move-page {
        cursor: move;
    }

    .search-div {
        height: 50px;
        width: 80%;
        background-color: #FFFFFF;
        position: absolute;
        top: 30px;
        left: 50%;
        transform: translateX(-50%);
        z-index: 1;
        border-radius: 5px;
        box-shadow: 0px 4px 10px 0px rgba(206, 206, 206, 0.2);
    }

    .searchText {
        height: calc(100% - 2px);
        width: calc(100% - 200px);
        border-radius: 5px;
        border-bottom-left-radius: 0;
        border-top-left-radius: 0;
        padding-right: 150px;
        padding-left: 50px;
        border: unset;
        font-size: 15px;
    }

    #search-btn {
        background: #4A94FF;
        border-radius: 5px;
        height: 100%;
        width: 100px;
        position: absolute;
        right: 0;
        top: 0;
        border: unset;
        background-image: url(/imgs/company/search2.png);
        background-size: 20px 20px;
        background-position: 50% 50%;
        background-repeat: no-repeat;
        cursor: pointer;
    }

    .scale-div {
        position: fixed;
        right: 50px;
        bottom: 60px;
        width: 240px;
        height: 60px;
        background-color: #FFFFFF;
        padding: 0 20px;
        border-radius: 5px;
        box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
    }

    .scale-div div {
        display: inline-block;
        line-height: 60px;
        float: left;
    }

    .scale-val {
        padding-right: 20px;
        color: #222222;
        width: 60px;
        font-size: 17px;
    }

    .scale-reduce,
    .scale-add {
        width: 20px;
        height: 60px;
        background-position: 50% 50%;
        background-size: 14px 14px;
        background-repeat: no-repeat;
        padding: 0 10px;
        cursor: pointer;
    }

    .scale-add {
        background-image: url(/imgs/company/scaleAdd.png);
    }

    .scale-reduce {
        background-image: url(/imgs/company/scaleReduce.png);
    }

    .scale-reload {
        margin-top: 15px;
        border: unset;
        width: 75px;
        height: 30px;
        background-color: #FFFFFF;
        border: 1px solid #4A94FF;
        padding: 0;
        font-size: 14px;
        border-radius: 40px;
        color: #4A94FF;
        float: right;
        cursor: pointer;
    }
}
</style>
<style>
:root {
    /* --orgItemWidth: 260px;

    --orgItemLeft: 35px;
    --orgItemLeftLine: 35px;

    --orgItemTop: 80px;
    --orgItemTopLine: -40px;
    --orgItemTopLineHeight: 40px; */


    --orgItemWidth: 240px;

    --orgItemLeft: 20px;
    --orgItemLeftLine: 20px;

    --orgItemTop: 80px;
    --orgItemTopLine: -40px;
    --orgItemTopLineHeight: 40px;
}

.company-dep-page {
    .search-company {
        width: 300px;
        height: 100%;

        .el-select__wrapper {
            box-shadow: unset !important;
            height: 100%;
        }
    }
}
</style>
