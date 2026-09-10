<template>
    <div class="user-card">
        <img :src="user.profilePhotoUrl?user.profilePhotoUrl:'https://ldbj-pubilc-files.oss-cn-hangzhou.aliyuncs.com/head/header.png'" class="logo" alt="" srcset="">
        <div class="user-card-info">
            <div class="user-card-name">{{user.title}}</div>
            <div class="user-card-msg">{{!user.roleNames?'':(user.roleNames??[]).join(', ')}}</div>
        </div>
        <img src="/imgs/common/delete.png" class="delete" @click="emits('delete',user)" alt="">
    </div>
</template>
<script setup lang='ts'>
const {user}= defineProps<{
    user: any
}>()
const emits=defineEmits(['delete'])
</script>
<style lang='less' scoped>
.user-card {
    width: 80%;
    margin: 0 auto 15px;
    max-width: calc(100% - 22px);
    display: flex;
    padding: 10px;
    border: 1px solid #eee;
    border-radius: 5px;
    align-items: center;

    .logo {
        width: 60px;
        height: 60px;
    }

    &-info {
        flex: 1;
        text-align: left;
        padding-left: 15px;
        padding-right: 15px;
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;

    }

    &-name {
        font-size: 16px;
        font-weight: 400;
    }

    .delete {
        width: 20px;
        height: 20px;
        cursor: pointer;
    }

}
</style>