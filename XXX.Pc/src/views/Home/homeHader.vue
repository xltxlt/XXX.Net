<script setup lang="ts">
import { reactive, ref, onMounted, onUnmounted } from 'vue';
import { ElMessageBox, ElNotification } from 'element-plus';
import { useUserStore } from '@/store/modules/user';
import { useRouter } from 'vue-router';
import { handleSumbitResTip } from '@/utils/common';
import { ElMessage } from 'element-plus';
import { setCookie } from '@/utils/cookie';
import { authService } from '@/api';
const router = useRouter()
const companyList = ref<any[]>()
const individualList = ref<any[]>()
const companyId = ref('')
const userStore = useUserStore()
const switchCompanyDialog = ref(false)
interface HeaderProps {
    title: string;
    logo: string;
    pageSize: number,
}
const headerProps = withDefaults(defineProps<HeaderProps>(), {
    title: 'Header Title',
    logo: '/imgs/agongyinglianindex.png'
});
const onTopMenu = (m: any) => {
    typeof topMenuFun[m.funName] === 'function' && topMenuFun[m.funName](m)
}
const topMenuFun: Record<string, Function> = {
    'exit': () => {
        ElMessageBox.confirm('确认退出登录吗', '提示', {
            confirmButtonText: '退出',
            cancelButtonText: '取消',
        }).then(() => {
            authService.apiSysAuthLogoutPost().then((res) => {
                setCookie('authorization','',1,'alongding.com');
                const userStore = useUserStore();
                userStore.clearUser();
                ElNotification.success({
                    title: '提示',
                    message: '退出登录成功',
                })
                userStore.$reset();
                router.push('/login');
            });
        })
    },
    'editPwd': () => {

    },
    'switchCompany': async () => {
        // switchCompanyDialog.value = true
        // const data = await getCompanyList()
        // companyList.value = data.company
        // individualList.value = data.individual
        // companyId.value = data.pltAndEntId
    }
}
const nowTime = ref('')
const weekDay = ref('')

function updateTime() {
    const date = new Date()
    const y = date.getFullYear()
    const m = String(date.getMonth() + 1).padStart(2, '0')
    const d = String(date.getDate()).padStart(2, '0')
    const h = String(date.getHours()).padStart(2, '0')
    const min = String(date.getMinutes()).padStart(2, '0')
    const s = String(date.getSeconds()).padStart(2, '0')
    nowTime.value = `${y}-${m}-${d} ${h}:${min}:${s}`
    const weekArr = ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六']
    weekDay.value = weekArr[date.getDay()]
}

let timer: number | undefined
onMounted(() => {
    updateTime()
    timer = window.setInterval(updateTime, 1000)
})
onUnmounted(() => {
    if (timer) clearInterval(timer)
})
let topMenuData = reactive<any[]>([])
// getTopMenuData().then((res) => {
//     if (res.code == 200) {
//         topMenuData = res.data;
//     }
// })
const switchCompany = async () => {
    if (!companyId.value) {
        ElMessage.error('请选择租户！')
        return;
    }
    // const res = await changeSlefComapny(companyId.value)
    // handleSumbitResTip(res, '切换租户成功', () => {
    //     switchCompanyDialog.value = false;
    //     window.location.href = window.origin + '/#/home'
    //     window.location.reload()
    // })
}
const activePlate = ref(0)
</script>
<template>
    <div class="header-content">
        <div class="header-left">
            <img :src="headerProps.logo" class="header-logo" alt="">
            <i class="home-bar-title">
                {{ headerProps.title }}
            </i>
        </div>

        <div class="header-right">
            <div class="now-time">

                <span>{{ nowTime }}</span>
                <span>{{ weekDay }}</span>
            </div>
            <template v-if='topMenuData.length > 0'>

                <el-icon color="#fff" size="17px" v-for="(m, i) in topMenuData" :key="i" @click="onTopMenu(m)">
                    <component :is="m.icon" />
                </el-icon>
            </template>
        </div>
        <el-dialog :class="'switch-company-dialog'" v-model="switchCompanyDialog" title="切换公司" width="400"
            style="height: 460px;">
            <div class="switch-company">
                <div @click="companyId = m.id" v-for="m in companyList" class="switch-company-item " :class="{
                    'switch-company-item-checked': m.id == companyId
                }">
                    <div class="switch-company-title">{{ m.name }}</div>
                    <div class="switch-company-content">{{ m.roles.join('、') }}</div>
                    <el-icon :size="20" class="switch-company-icon" v-if="m.id == companyId">
                        <Check />
                    </el-icon>
                </div>
                <div @click="companyId = m.id" v-for="m in individualList" class="switch-company-item " :class="{
                    'switch-company-item-checked': m.id == companyId
                }">
                    <div class="switch-company-title">{{ m.name }}</div>
                    <div class="switch-company-content">{{ m.roles.join('、') }}</div>
                    <el-icon :size="20" class="switch-company-icon" v-if="m.id == companyId">
                        <Check />
                    </el-icon>
                </div>
            </div>
            <el-button type="primary" @click="switchCompany"
                style="position: absolute;bottom: 15px;right: 15px;">确认保存</el-button>
        </el-dialog>
    </div>

</template>
<style lang="less">
.header-right {
    .el-icon {
        padding: 0 15px;
        font-weight: bold;
        font-size: 16px;
        cursor: pointer;
    }

}

.header-plate {
    height: 100%;

    display: flex;
    align-items: center;

    &-item {
        font-size: 21px;
        color: rgba(255, 255, 255, 1);
        padding: 0 30px;
        cursor: pointer;
        height: 100%;
        display: flex;
        align-items: center;

        &-active {
            color: rgba(77, 171, 237, 1);
            position: relative;

        }
    }

    .header-plate-item-down {
        transition: all 0.3s;
        position: absolute;
        height: 2px;
        width: 33.33%;
        background-color: rgba(77, 171, 237, 1);
        bottom: 0;
        left: 0;
    }

}

.header-plate-position {
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
}

.header-plate-right {
    position: relative;
}

.header-content {
    .el-dialog {
        .el-dialog__body {
            height: calc(100% - 51px);
            padding-top: 0;
        }
    }

    .el-dialog__title {
        text-align: left;
        font-size: 15px;
    }

    .switch-company-dialog {
        .el-dialog__body {
            overflow: auto;
        }
    }
}
</style>
<style scoped lang="less">
.header-content {
    position: relative;
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 100%;
    background-color: #001529;

    .switch-company-item {
        padding: 10px 0;
        position: relative;
        border-bottom: 1px solid #ddd;
        cursor: pointer;

        &-checked {
            color: #4da4e4;
        }

        text-align: left;
        letter-spacing: 1px;

        .switch-company-title {
            font-size: 16px;
        }

        .switch-company-content {
            margin-top: 5px;
            font-size: 14px;
        }

        .switch-company-icon {
            position: absolute;
            right: 0px;
            top: 50%;
            transform: translateY(-50%);
        }
    }
}

.header-left {

    display: flex;
    align-items: center; // 垂直居中
    height: 100%;

    .header-logo {
        height: 36px;
        padding: 10px 14px 10px 30px;
    }

    .home-bar-title {
        color: #F2DFC5;
        font-size: 26px;
        line-height: 40px;
        font-weight: normal;
    }
}


.header-right {
    margin-right: 30px;
    display: flex;
    align-items: center;
    height: 100%;

    .now-time {
        color: #2299ee;
        ;
        font-size: 16px;
        font-weight: bold;
        margin-right: 20px;

        span {
            margin-right: 15px;
        }
    }
}

.home-page {
    .header-logo {
        text-align: left;
        height: 36px;
        padding: 10px 14px 10px 30px;
    }
}
</style>