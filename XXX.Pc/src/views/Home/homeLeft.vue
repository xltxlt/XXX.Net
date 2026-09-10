<script setup lang="ts">

import { reactive, ref, nextTick, onMounted } from 'vue'
import type { HomeLeftProps } from '.';
import { menuService } from '@/api';
const props = defineProps<{
    logo: string,
    name: string,
    role: string,
    addPageTab: (title: string, path: string, item: any) => void
}>()
const emit = defineEmits(['toggleCollapsed'])

const homeLeftProps = ref<HomeLeftProps>({
    logo: '',
    menuList: []
})


// 当前展开的一级菜单索引
const openIndex = ref<number | null>(0)
// 当前选中的菜单项
const activeMenu = ref<string>('')
// 缩放功能
const collapsed = ref(false)
function toggleCollapse() {
    collapsed.value = !collapsed.value
    emit('toggleCollapsed', collapsed.value);
}
// 切换展开菜单
async function handleOpenMenu(idx: number) {
    openIndex.value = openIndex.value === idx ? null : idx;
    await nextTick();
}

// 点击菜单项跳转
function handleMenuClick(item: any) {
    activeMenu.value = item.id as string;
    if (item.route) {
        props.addPageTab(item.name, item.route, item);
    }
}
onMounted(async()=>{
    const res = await menuService.apiSysMenuLeftmenuPost()
    if (res.data.statusCode == 200) {
        // console.log('menuList', res.data)
        // res.data[0].children=[];
        // res.data[0].children.push({ name: '自定义表单', icon: 'HomeFilled', route: '/Home/Matter' });
        // res.data[0].children.push({ name: '系统菜单管理', icon: 'HomeFilled', route: '/Home/Sys' });
    }
    if (res.data.statusCode === 200) {
        homeLeftProps.value.menuList = res.data.data ?? []
    }
}) 


defineExpose({

})
</script>

<template>
    <div class="left-content" :class="{ 'left-content-hide': collapsed }">
        <div class="header-logo">
            <img :src="logo" alt="">
            <div class="header-info">
                <p>{{ props.name }}</p>
                <p>{{ props.role }}</p>
            </div>
        </div>
        <div class="menu-list">
           
            <ul class="menu-items menu-items-first">
                <li v-for="(menu, idx) in homeLeftProps.menuList" :key="menu.id" class="menu-item">
                    <div class="menu-item-title" :class="{ opened: openIndex === idx }" @click="handleOpenMenu(idx)">
                        <el-icon size="15px" color="#fff" v-if="menu.icon">
                            <component :is="menu.icon" />
                        </el-icon>
                        <span>{{ menu.name }}</span>
                        <el-icon size="13px" color="#fff" class="menu-down-icon">
                            <ArrowRightBold v-if="openIndex !== idx" />
                            <ArrowDownBold v-else />
                        </el-icon>
                    </div>
                    <ul class="menu-items" v-show="openIndex === idx">
                        <li v-for="item in menu.children" :key="item.id" class="menu-item"
                            :class="{ active: activeMenu === item.id+'' }" @click.stop="handleMenuClick(item)">
                            <div class="menu-item-title">
                                <el-icon size="15px" color="#fff" v-if="item.icon">
                                    <component :is="item.icon" />
                                </el-icon>
                                <span>{{ item.name }}</span>
                            </div>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
        <!-- 缩放按钮 -->
        <div class="left-resize" @click="toggleCollapse">
            <el-icon>
                <Fold v-if="!collapsed" />
                <Expand v-else />
            </el-icon>
        </div>
    </div>
</template>

<style scoped lang="less">
.left-content {
    position: relative;
    width: 100%;
    background: #001529;
    height: 100%;

    .header-logo {
        padding: 30px 20px 0;
    }

    .header-logo img {
        width: 50px;
        height: 50px;
        border-radius: 50%;
    }


    .header-info p {
        margin: 0;
        padding-top: 5px;
        font-size: 11px;
        color: #2299ee;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }

    .menu-list {
        height: calc(100% - 190px);
        margin-top: 10px;
        overflow-x: hidden;
        overflow-y: auto;


    }

    .menu-items {
        list-style: none;
        padding: 8px 0;
        margin: 0;
        text-align: left;
    }



    .menu-item-title {
        display: flex;
        flex-direction: row;
        align-items: center;
        padding: 8px 25px;
        font-size: 14px;
        letter-spacing: 1px;
        color: #fff;
        cursor: pointer;
        transition: background 0.2s;
        position: relative;

        span {
            flex: 1;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .menu-down-icon {
            top: 1px;
        }
    }

    .menu-items-first>.menu-item>.menu-item-title {
        padding-left: 15px;
    }

    .menu-item-title>.el-icon:first-child {
        margin-right: 5px;
        flex-shrink: 0;
        /* 靠左，无需额外样式 */
    }

    .menu-item-title>span {
        flex: 1;
        margin-left: 0;
        margin-right: 0;
        /* 文字和第一个图标间距已由上面margin-right控制 */
        display: flex;
        align-items: center;
    }

    .menu-item-title>.el-icon:last-child {
        margin-left: auto;
        flex-shrink: 0;
        /* 靠右 */
    }

    .menu-item-title:hover {
        background-color: #4E5465;
    }

    .menu-items .menu-item.active .menu-item-title {
        background-color: #337ab7 !important;
        color: #fff;
    }

    .menu-items .menu-item .menu-item-title {
        font-size: 14px;
    }

    /* 缩放按钮样式 */
    .left-resize {
        position: unset;
        margin-top: 5px;
        padding: 8px 0;
        width: 100%;
        cursor: pointer;
        color: #fff;
        font-size: 17px;
        transition: background 0.2s;
        user-select: none;
    }

    .left-resize:hover {
        background: #444857;
    }
}




::-webkit-scrollbar-track {
    background-color: transparent;
}

::-webkit-scrollbar {
    display: none;
}


.left-content-hide {
    .menu-list {
        display: none;
    }

    .header-logo {
        display: none;
    }

    .left-resize {
        position: absolute;
        top: 50%;
        transform: translateY(-50%);
    }
}
</style>