<template>
    <ul class="org-ul" :class="{
        'org-ul-root': root
    }">
        <li v-for="(item, index) in orgTree" :draggable="!root"
            @dragstart.self="(event) => props.drag && props.drag(event, item.id, item.pId, root,item)" class="org-li "
            :key="index" :class="{
                'org-li-root': root,
                'org-li-range': draging

            }" :id="'org-li-id_' + item.id" :data-id="item.id" :data-pid="item.pId">
            <div class="org-item" @drop="(event) => props.drop && props.drop(event, 'org-li-id_' + item.id, item.id,item)"
                @dragover="(event) => props.allowDrop && props.allowDrop(event, 'org-li-id_' + item.id, item.id,item)"
                :id="'org-item-id_' + item.id" :data-pid="item.pId" :class="{
                    'org-no-children': !item.children || item.children.length == 0
                }">
                <div class="org-item-top-bg"></div>
                <div class="org-item-header">
                    <img src="/imgs/company/addDep.png" class="addDep" @click.stop="btnClick('addDep',item)" alt="">
                    {{ item.title }}
                    <div class="org-item-tools">
                        <el-dropdown @command="(funName:string)=>btnClick(funName,item)" ref="dropdownRef" type="primary" trigger="click">
                            <img src="/imgs/company/tools.png" class="toolsBtn" alt="">
                            <template #dropdown>
                                <el-dropdown-menu>
                                    <el-dropdown-item :command="'addDep'">添加子部门</el-dropdown-item>
                                    <el-dropdown-item :command="'editDep'">编辑部门</el-dropdown-item>
                                    <el-dropdown-item :command="'setDepManage'">设置负责人</el-dropdown-item>
                                    <el-dropdown-item :command="'addDepMember'">添加成员</el-dropdown-item>
                                    <el-dropdown-item :command="'inviteMember'">邀请入职</el-dropdown-item>
                                    <!-- <el-dropdown-item :command="'delDep'">移除部门</el-dropdown-item> -->
                                </el-dropdown-menu>
                            </template>
                        </el-dropdown>
                    </div>
                </div>
                <div class="org-item-content" @click="() => emits('contentClick', item.id, item)">
                    <div class="org-item-content-row">部门数：{{ item.orgCount }}</div>
                    <div class="org-item-content-row">员工数：{{ item.userCount }}</div>
                </div>

            </div>
            <div v-if="item.children && item.children.length > 0" class="org-item-show">
                <img :src="item.hide == true ? '/imgs/company/add.png' : '/imgs/company/reduce.png'" alt=""
                    @click.stop="item.hide = !item.hide">
            </div>
            <TreeDep @btn-click="btnClick" @content-click="(id, item) => emits('contentClick', id, item)" v-show="!item.hide"
                :draging="props.draging" :allow-drop="props.allowDrop" :drop="props.drop" :drag="props.drag"
                :org-tree="item.children" :root="false">
            </TreeDep>
        </li>
    </ul>
</template>
<script setup lang='ts'>
import { ref } from 'vue'
const tableBtns=ref([])
interface OrgItem {
    id: string,
    pId: string,
    title: string,
    pltAndEntId: string,
    orgCount: number,
    userCount: number,
    hide: boolean,
    children: OrgItem[]
}
const props = defineProps<{
    orgTree: OrgItem[],
    root: boolean,
    drop?: Function,
    allowDrop?: Function,
    drag?: Function,
    draging?: boolean,

}>()

const emits = defineEmits(['contentClick','btnClick'])
const btnClick=(type:string,item:any)=>{
    emits('btnClick',type,item)
}
</script>
<style lang="less" scoped>
ul,
li {
    list-style: none;
}

ul {
    padding-inline-start: 0;
}

.orgPage {
    min-width: calc(100% - 100px);
    min-height: 3000px;
    padding: 0 50px;
    margin-top: 50px;
    background-color: #F8F9FB;

}

.org-li {
    /* margin: 80px 35px; */
    margin: var(--orgItemTop) var(--orgItemLeft);

}

.org-ul>.org-li:first-child {
    margin-left: 0;
}

.org-ul>.org-li:last-child {
    margin-right: 0;
}

.org-item {
    margin: 0 auto;
    /* width: 260px; */
    width: var(--orgItemWidth);
    height: 100px;
    position: relative;
    box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
    border-radius: 0px 0px 4px 4px;
    background: #FFFFFF;
}

.org-item-top-bg {
    height: 4px;
    width: 100%;
    border-radius: 4px 4px 0px 0px;
    background: #88939F;
}

.org-item-header {
    position: relative;
    padding: 10px 15px;
    background-color: #F3F4F5;
    padding-right: 45px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    color: #88939F;
    padding-left: 45px;
}

.org-item-tools {
    position: absolute;
    right: 15px;
    top: 0;
    height: 100%;
    width: 30px;
    text-align: right;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: flex-end;
}

.org-item-tools img {
    cursor: pointer;
    width: 16px;
    height: 16px;
}
.addDep{
    position: absolute;
    cursor: pointer;
    width: 16px;
    height: 16px;
    left: 15px;
    top: 50%;
    transform: translateY(-50%);
}

/* .org-item .org-item-header::before {
            content: "";
            position: absolute;
            width: 100%;
            height: 4px;
            top: -4px;
            left: 0;
            z-index: 1;
            border-radius: 4px 4px 0px 0px;
            background: #88939F;
        } */

.org-item-content {
    cursor: pointer;
    position: relative;
    padding: 14px 40px 14px 15px;
    display: flex;
    align-items: center;
    justify-content: space-around;
    color: #222222;
}

.org-item-content-row {
    flex: 1;
    text-align: left;
}

.org-item-content::after {
    content: "";
    cursor: pointer;
    position: absolute;
    right: 18px;
    top: 0;
    height: 100%;
    width: 20px;
    background-image: url(/imgs/company/right.png);
    background-size: 8px 12px;
    background-repeat: no-repeat;
    background-position: 100% 50%;
}

.org-li-root>.org-item .org-item-top-bg {
    background: #4A94FF;
}

.org-li-root>.org-ul>.org-li>.org-item .org-item-top-bg {
    background: #F7B51C;
}

.org-li-root>.org-ul>.org-li>.org-ul>.org-li>.org-item .org-item-top-bg {
    background: #3CB4B2;
}

.org-li-root>.org-ul>.org-li>.org-ul>.org-li>.org-ul>.org-li>.org-item .org-item-top-bg {
    background: #6C68E7;
}


.org-li-root>.org-item>.org-item-header {
    background: #EDF4FF;
    color: #4A94FF;
}

.org-li-root>.org-ul>.org-li>.org-item>.org-item-header {
    background: #FEF7E8;
    color: #F7B51C;

}

.org-li-root>.org-ul>.org-li>.org-ul>.org-li>.org-item>.org-item-header {
    background: #EBF7F7;
    color: #3CB4B2;

}

.org-li-root>.org-ul>.org-li>.org-ul>.org-li>.org-ul>.org-li>.org-item>.org-item-header {
    background: #F0F0FD;
    color: #6C68E7;

}


.org-ul {
    display: flex;
    align-content: center;
    justify-content: center;
    align-items: flex-start;
    flex-direction: row;
    flex-wrap: nowrap;
}

.org-li {
    flex: 1;
    position: relative;
}

/* 纵向线  */

/* 控制纵向线向上的线 */
.org-li-root .org-li>.org-item::before {
    content: "";
    height: var(--orgItemTopLineHeight);
    position: absolute;
    top: var(--orgItemTopLine);
    left: calc(50% - 0.5px);
    width: 1px;
    background-color: #DADADA !important;
}

/* 控制纵向线向下的线 */
.org-li>.org-item::after {
    content: "";
    height: var(--orgItemTopLineHeight);
    position: absolute;
    top: 100%;
    left: calc(50% - 0.5px);
    width: 1px;
    background-color: #DADADA;
}

.org-no-children::after {
    content: unset !important;
}

/* 控制纵向线最后一级向下的线不显示 */
.org-li .org-item:last-child::after {
    content: none;
}




/* 横向线 */


.org-li-root .org-ul>.org-li:first-child::before {
    width: calc(50% + var(--orgItemLeftLine) + 1px);
    left: 50%;
}

.org-li-root .org-ul>.org-li:last-child::after {
    width: calc(50% + var(--orgItemLeftLine) + 1px);
    left: unset;
    right: 50%;
}

.org-li-root .org-li::before {
    content: "";
    position: absolute;
    top: var(--orgItemTopLine);
    width: calc(50% + var(--orgItemLeftLine) + 1px);
    left: 50%;
    height: 1px;
    background-color: #DADADA;
}

.org-li-root .org-li::after {
    content: "";
    position: absolute;
    top: var(--orgItemTopLine);
    width: calc(50% + var(--orgItemLeftLine) + 1px);
    left: unset;
    right: 50%;
    height: 1px;
    background-color: #DADADA;
}

/* 横向线每级 第一元素向左的线不显示 最后一元素向右的线不显示 */
.org-li-root .org-ul>.org-li:last-child::before {
    content: none;
}

.org-li-root .org-ul>.org-li:first-child::after {
    content: none;
}

.org-item-tools-div {
    padding: 8px 0;
    width: max-content;
    background-color: #FFFFFF;
}

.org-item-tools-row {
    color: #222222;
    padding: 8px 20px;
    cursor: pointer;
    border-radius: 2px;
}

.org-item-tools-row:hover {
    background-color: #EFEFEF;
}

.org-item-show {
    cursor: pointer;
    position: absolute;
    top: 128px;
    z-index: 1;
    left: 50%;
    transform: translateX(-50%);
}

.org-li-range {
    // --orgItemWidth: 240px;

    // --orgItemLeft: 20px;
    // --orgItemLeftLine: 20px;

    // --orgItemTop: 80px;
    // --orgItemTopLine: -10px;
    // --orgItemTopLineHeight: 70px;
    // .org-li > .org-item[data-v-69abcd9f]::before{
    //     top: -40px;
    // }
}
</style>