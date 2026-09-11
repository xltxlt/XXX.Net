<template>
    <div class="dep-user-card">

        <div class="dep-user-card-content">
            <div class="dep-user-card-header">
                <img class="dep-user-card-logo"
                    :src="userInfo.profilePhotoUrl??'https://ldbj-pubilc-files.oss-cn-hangzhou.aliyuncs.com/head/header.png'" alt="">
                <div class="dep-user-card-info">
                    <p class="dep-user-card-name">{{userInfo.realName}}</p>
                    <p class="dep-user-card-roles ldyz-text">{{(userInfo?.roleNames??[]).join('、')}}</p>
                </div>
            </div>
            <div class="dep-user-card-items">
                 <div class="dep-user-card-item">
                    <label for="">用户名</label>
                    <div class="dep-user-card-val ldyz-text">
                        {{userInfo.userName}}
                    </div>
                </div>
                <div class="dep-user-card-item">
                    <label for="">手机号码</label>
                    <div class="dep-user-card-val ldyz-text">
                        {{userInfo.mobilePhone}}
                    </div>
                </div>
                <div class="dep-user-card-item">
                    <label for="">员工工号</label>
                    <div class="dep-user-card-val ldyz-text">
                        {{userInfo.no}}
                    </div>
                </div>
            </div>

        </div>
        <div class="dep-user-card-footer">
            <el-button  type="" @click="emits('btn-click','contract',userInfo)">薪资合同</el-button>
            <!-- <el-button  type="danger" @click="emits('btn-click','delMember',userInfo)">移除部门</el-button> -->
            <el-button  type="primary" @click="emits('btn-click','attendanceLook',userInfo)" >考勤记录</el-button>
            <!-- <el-button  type=""  @click="emits('btn-click','setPermission',userInfo)">设置权限</el-button> -->
            <el-button  type=""  @click="emits('btn-click','roster',userInfo)">花名册</el-button>

        </div>
    </div>
</template>
<script setup lang='ts'>
import {ref} from 'vue'
interface UserInfoDto{
    id:string,
    name:string,
    roleNames:string[],
    orgDepName:string,
    mobilePhone:string,
    companyName:string,
    profilePhotoUrl:string
}

const {userInfo}= defineProps<{
    userInfo:any
}>()
const emits=defineEmits<{
    (e: 'btn-click', btnType: string, userInfo: UserInfoDto): void;
}>()
</script>
<style lang='less' scoped>
.dep-user-card {
    box-shadow: 0px 0px 2px 2px rgba(0, 0, 0, 0.05);
    padding: 10px 15px;
    width: 300px;
    min-height: 350px;
    background-color: #fff;
    border-radius: 5px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;

    &-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 10px 0;

        .dep-user-card-info {
            width: calc(100% - 100px);
            text-overflow: ellipsis;
            overflow: hidden;
            padding-left: 20px;
            text-align: left;
            flex: 1;
        }

        p {
            margin: 0;
            padding: 3px 0;
        }

        .dep-user-card-name {

            font-size: 18px;
        }
    }

    &-logo {
        width: 60px;
        height: 60px;
    }

    &-content {
        width: 100%;
    }
    .dep-user-card-items{
        margin-top: 10px;
    }
    &-item {
        display: flex;
        padding: 5px 0;

        label {
            text-align: left;
            width: 80px;
        }
    }

    &-val {
        text-align: left;
        width: calc(100% - 60px);
        flex: 1;
    }

    .dep-user-card-footer {}
}
</style>