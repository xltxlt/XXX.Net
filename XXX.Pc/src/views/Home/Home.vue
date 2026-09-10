<script setup lang="ts">
import homeHader from '@/views/home/homeHader.vue';
import homeLeft from '@/views/Home/homeLeft.vue';
import type { PageTabData } from '.';
import { computed, onMounted, ref, watch, onBeforeUnmount } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import type { TabPaneName } from 'element-plus';
import { getCookie } from '@/utils/cookie';
import { useUserStore } from '@/store/modules/user';
import { isEmptyVal } from '@/utils/is';
const router = useRouter()
const route = useRoute()


const editableTabsValue = ref('tab-1')
const editableTabs = ref([{
  title: '首页',
  name: '/home',
  query: {},
  content: '首页内容',
}] as PageTabData[])

const handleTabsEdit = (
  targetName: TabPaneName | undefined,
  action: 'remove' | 'add'
) => {
  if (action === 'remove') {
    const tabs = editableTabs.value
    let activeName = editableTabsValue.value
    let tabIndex = tabs.findIndex(tab => tab.name === targetName)
    tabs.splice(tabIndex, 1)
    // 如果关闭的是当前tab，切换到前一个或第一个
    if (activeName === targetName) {
      const nextTab = tabs[tabIndex] || tabs[tabIndex - 1]
      if (nextTab) {
        editableTabsValue.value = nextTab.name
      }
    }
  }
}
const AddPageTab = (title: string, path: string, item: any) => {
  const tabName = path; // 只用 path 作为 name
  const query = { menuId: item.id };
  // 检查是否已存在
  if (editableTabs.value.some(tab => tab.name === tabName && JSON.stringify(tab.query) === JSON.stringify(query))) {
    editableTabsValue.value = tabName;
    return;
  }
  editableTabs.value.push({
    title,
    name: tabName,
    query,
    content: tabName
  });
  editableTabsValue.value = tabName;
  // 跳转
  router.push({ path: tabName, query });
};
const onTopMenu = (m: any) => {
}
// 监听tab切换，跳转路由
watch(editableTabsValue, (val) => {
  const tab = editableTabs.value.find(tab => tab.name === val);
  if (tab) {
    router.push({ path: tab.name, query: tab.query });
  }
  // if (val !== route.path) {
  //   router.push(val as string)
  // }
})
const pageConfig = ref({
})
let leftMenuHide = ref(false)
// getPageConfig().then((res: any) => {
//   console.log(res)
//   if (res.code === 200) {
//     pageConfig.value = res.data;
//   }
// })
pageConfig.value = {
  "name": "TData",
  "roles": [
    "admin",
    "user"
  ],
  "logo": "https://example.com/logo.png",
  "homePage": "/home"
};
const pageFun = {
  ToggleLeftMenu: (hideCollapsed: boolean) => {
    leftMenuHide.value = hideCollapsed;
  },
}
const headerImg = ref('/imgs/logo.png')
const barTitle = ref('')
const leftData = ref<any>({})


watch(editableTabs, (val: any[], oldVal: any[]) => {
  if (val != oldVal && val.length == 0) {
    val.push({
      title: '首页',
      name: '/home',
      query: {},
      content: '首页内容',
    })
  }
})
computed(() => {

})
const homePageRef = ref();
const changeResize = ref(false);
const rowMaxSearch = computed(() => {
  const len = changeResize.value ?? 0;
  if (homePageRef.value) {
    const width = homePageRef.value?.$el?.offsetWidth || 0;
    return width;
  }
  return 1920;
});
function handleResize() {
  // 触发响应式更新
  changeResize.value = !changeResize.value;
}


onBeforeUnmount(() => {
  window.removeEventListener('resize', handleResize);
});
const userStore = useUserStore()

onMounted(async () => {
  if (isEmptyVal(userStore.accessToken)) {
    userStore.setToken(getCookie('authorization')!);
  }
  window.addEventListener('resize', handleResize);

  // headerImg.value = data.indexLogo ?? '/imgs/logo.png';
  // leftData.value = {
  //   logo: data.profilePhotoUrl, name: data.name, role: data.roleNames.join('、')
  // }
  // barTitle.value = data.title;
})

</script>
<template>
  <el-container class="home-page" ref="homePageRef">
    <el-header>
      <homeHader :page-size="rowMaxSearch" @onTopMenu="onTopMenu" :logo="headerImg" :title="barTitle" />
    </el-header>
    <el-container class="home-content">
      <el-aside :class="{
        'left-menu': true,
        'left-menu-hide': leftMenuHide,
      }">
        <homeLeft :logo="leftData.logo" :name="leftData.name ?? leftData.mobilePhone" :role="leftData.role" :add-page-tab="AddPageTab" @toggleCollapsed="pageFun.ToggleLeftMenu" />
      </el-aside>
      <el-main>
        <el-tabs v-model="editableTabsValue" type="border-card" closable class="demo-tabs" @edit="handleTabsEdit">
          <el-tab-pane v-for="item in editableTabs" :key="item.name" :label="item.title" :name="item.name">
          </el-tab-pane>
          <transition name="fade" mode="out-in">
            <router-view></router-view>
          </transition>
        </el-tabs>

      </el-main>
    </el-container>
  </el-container>
</template>
<style lang="less">
.demo-tabs {
  border: none;

  >.el-tabs__content {
    padding: 5px;
  }

  .el-tabs__header {

    .el-tabs__item,
    .is-active {
      color: #000 !important;
      font-weight: 400;

      .is-icon-close {
        top: 1px;
      }
    }
  }


  .el-tabs__header {
    .el-icon.is-icon-close {
      color: #c2c2c2;
      font-size: 16px;
      top: 1px;
      transition: none;

      :hover {
        background-color: #FF5722;
        color: #fff;
      }
    }

    background-color: #f2f2f2;
  }

}
</style>
<style scoped lang="less">
.demo-tabs {
  height: calc(100%);

}

.home-content {
  height: calc(100% - 65px);

  .left-menu {
    overflow: hidden;
    transition: all 0.2s;
  }

  .left-menu-hide {
    width: 50px;


  }
}

.home-page {
  height: 100vh;
}

.el-header {
  height: 65px;
  padding: 0;
  background-color: #001529;
  border-bottom: 3px solid #2299ee;
}

.el-aside {
  width: 180px;
  background-color: #001529;
}

.el-main {
  background-color: #fff;
  padding: 0px;
}
</style>