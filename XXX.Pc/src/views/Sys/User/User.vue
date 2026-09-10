<template>
  <PageInfo :pageConfig="pageConfig" ref="pageInfoRef" />
</template>
<script setup lang="ts">
import { ref } from "vue";
import PageInfo from "@/components/ListPage/PageInfo.vue";
import { menuService, userService, userDepRoleService } from "@/api/index.ts";
import { PagedSearchType, type TempListPageConfig } from "@/components/ListPage";
import UserDepRole from "./UserDepRole.vue";
const pageConfig: TempListPageConfig = {
  url: userDepRoleService.apiSysUserDepRoleDepusersPost.bind(menuService),
  optionUrl: userService.apiSysUserPageoptionGet.bind(menuService),
  showLeftSearch: 'depId_custom',
  pageFun: {
    setOrgRole: (data: any) => {
      return {
        title: "设置用户部门角色",
        comp: UserDepRole,
        height: "100%",
        width: "100%",
        pars: {
          userId: data?.id, // 使用行数据的 id
        },
      };
    }
  },
};
</script>
