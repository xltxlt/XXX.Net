<template>
    <div class="bottom" @click="goToCopyrightPage">Copyright皖ICP备16002104号-1 © 2026 <img src="/imgs/gb.png"
            class="img_icon" alt="">地址:安徽省宣城市经济技术开发区</div>

    <div class="bady" :style="{ backgroundImage: `url(${customImg})` }">
        <div class="bady_right">

            <div class="login_content">
                <!-- 图标 -->
                <div class="img_icon_top">
                    <div class="img_icon_div">
                        <img :src="loginImg" alt="Logo" class="img_icon" />
                    </div>
                    <div class="img_icon_title">{{ orgTitle }}</div>
                </div>
                <!-- form 登录表单-->
                <div class="form_top">
                    <el-tabs v-model="activeTab" class="login-tabs" @tab-click="onTabChange">
                        <!-- 密码登录 -->
                        <el-tab-pane label="密码登录" name="password">
                            <el-form :model="loginForm" :rules="passwordRules" ref="passwordFormRef" label-width=""
                                class="login-form" @keyup.enter="onSubmitLogin('password')">
                                <el-form-item label="" prop="username">
                                    <el-input v-model="loginForm.username" placeholder="请输入账号" autocomplete="off"
                                        class="login-form-item">
                                        <template #prefix>
                                            <img src="/imgs/loginIcon/phone.png" alt="search"
                                                class="input-search-icon" />
                                        </template>
                                    </el-input>
                                </el-form-item>

                                <el-form-item label="" prop="password">
                                    <el-input v-model="loginForm.password" :show-password="loginForm.showPwd"
                                        placeholder="请输入密码" type="password" autocomplete="off" class="login-form-item">
                                        <template #prefix>
                                            <img src="/imgs/loginIcon/password.png" alt="search"
                                                class="input-search-icon" />
                                        </template>
                                    </el-input>
                                </el-form-item>

                                <!-- <el-form-item label="" prop="captcha" class="captcha-content"
                                    style="margin-bottom: 8px !important;">
                                    <el-input v-model="loginForm.captcha" placeholder="请输入验证码" autocomplete="off"
                                        style="width: 64.3%;border-radius: 4px 0 0 4px;"> <template #prefix>
                                            <img src="/imgs/loginIcon/search.png" alt="search"
                                                class="input-search-icon" />
                                        </template>
                                    </el-input>
                                    <img :src="codeImgUrl" @click="getCaptcha" class="captcha-item" alt="验证码" style="width: 35%;height: 44px;margin-left: 10px;border-radius: 0px 4px 4px 0px;cursor: pointer;border: 1.2px solid #dcdfe6;" />
                                </el-form-item> -->

                                <el-form-item class="pwd-helper">
                                    <el-checkbox v-model="loginForm.rememberMe" class="remember-pwd">记住密码</el-checkbox>
                                </el-form-item>

                                <el-form-item class="sumbit-content">
                                    <el-button type="primary" @click="onSubmitLogin('password')">登录</el-button>
                                </el-form-item>
                            </el-form>
                        </el-tab-pane>
                        <!-- 手机号登录 -->
                        <el-tab-pane label="手机号登录" name="phone">
                            <el-form :model="loginForm" :rules="phoneRules" ref="phoneFormRef" label-width=""
                                class="login-form" @keyup.enter="onSubmitLogin('phone')">
                                <el-form-item label="" prop="username">
                                    <el-input v-model="loginForm.username" placeholder="请输入手机号" autocomplete="off"
                                        class="login-form-item">
                                        <template #prefix>
                                            <img src="/imgs/loginIcon/phone.png" alt="search"
                                                class="input-search-icon" />
                                        </template>
                                    </el-input>
                                </el-form-item>

                                <el-form-item label="" prop="captcha">
                                    <el-input v-model="loginForm.captcha" placeholder="请输入验证码" autocomplete="off"
                                        style="width: 100%">
                                        <template #prefix>
                                            <img src="/imgs/loginIcon/search.png" alt="search"
                                                class="input-search-icon" />
                                        </template>
                                        <template #suffix>
                                            <span class="sms-code-text" :class="{ 'disabled': countdown > 0 }"
                                                @click="countdown <= 0 && sendSmsCode()">
                                                {{ countdown > 0 ? `${countdown}s 后重发` : '获取验证码' }}
                                            </span>
                                        </template>
                                    </el-input>
                                </el-form-item>

                                <el-form-item class="sumbit-content yzbtn">
                                    <el-button type="primary" @click="onSubmitLogin('phone')">登录</el-button>
                                </el-form-item>
                            </el-form>
                        </el-tab-pane>




                    </el-tabs>

                </div>
                <!-- 其他登录方式 -->
                <div class="other-login">
                    <div class="xian">
                        <div class="left-xian"></div>
                        <div class="other-title">其他登录方式</div>
                        <div class="right-xian"></div>
                    </div>
                    <div class="login-icons">
                        <span @click="switchToScanLogin('dingding')">
                            <img src="/imgs/loginIcon/dingding.png" alt="钉钉" class="login-icon" />
                            <span class="login-text">钉钉 </span>
                        </span>
                        <span @click="switchToScanLogin('wechat')">
                            <img src="/imgs/loginIcon/wx.png" alt="微信" class="login-icon" />
                            <span class="login-text">微信 </span>
                        </span>
                        <span @click="switchToScanLogin('alipay')">
                            <img src="/imgs/loginIcon/zfb.png" alt="支付宝" class="login-icon" />
                            <span class="login-text">支付宝</span>
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <!-- 扫码登录弹窗 -->

    </div>
</template>

<script setup lang="ts">
import { ref, reactive, onUnmounted, onBeforeUnmount } from 'vue'
import { useRouter } from 'vue-router';
import { useAccountStore } from '@/store/modules/account';
import type { FormInstance, FormRules } from 'element-plus';
import { ElMessage, ElNotification } from 'element-plus'
import { useUserStore } from '@/store/modules/user';

//#region 
import { authService } from '@/api';
//#endregion

const loginImg = ref('/imgs/loginIcon/logo.png')
const activeTab = ref('password') // 默认显示手机号登录
const orgTitle = ref('福元营销平台')
const onTabChange = (tab: any) => {
    if (tab.name === 'password') {
        // getCaptcha()
    }
}

const customImg = ref('/imgs/zy.png')

// 表单引用
const phoneFormRef = ref<FormInstance>()
const passwordFormRef = ref<FormInstance>()
// 验证码倒计时
const countdown = ref(0)
const smsTimer = ref<ReturnType<typeof setInterval> | null>(null)
const router = useRouter();
interface LoginForm {
    username: string;
    password: string;
    captcha: string;
    rememberMe: boolean;
    showPwd: boolean;
}
const accountStore = useAccountStore()
const userStore = useUserStore();
const loginForm = reactive<LoginForm>({
    username: accountStore.phone,
    password: accountStore.password,
    captcha: '',
    rememberMe: false,
    showPwd: true
});
const phoneRules = reactive<FormRules>({
    username: [
        { required: true, message: '请输入手机号', trigger: 'blur' },
        { pattern: /^1[3-9]\d{9}$/, message: '手机号格式不正确', trigger: 'blur' }
    ],
    captcha: [
        { required: true, message: '请输入验证码', trigger: 'blur' }
    ]
})
const passwordRules = reactive<FormRules>({
    username: [
        { required: true, message: '请输入账号', trigger: 'blur' },
        { min: 3, max: 20, message: '长度在 3 到 20 个字符', trigger: 'blur' }
    ],
    password: [
        { required: true, message: '请输入密码', trigger: 'blur' },
        { min: 5, max: 20, message: '长度在 5 到 20 个字符', trigger: 'blur' }
    ],
    captcha: [
        { required: true, message: '请输入验证码', trigger: 'blur' }
    ]
});
const sendSmsCode = () => {
    if (!phoneFormRef.value) return
    phoneFormRef.value.validateField('username', (isValid) => {
        if (isValid) {
            // sendLoginCode(loginForm.username).then((res) => {
            //     if (res.code == "200") {
            //         ElNotification({ title: '提示', message: '验证码已发送', type: 'success' })
            //         startCountdown();
            //     } else {
            //         ElNotification({
            //             title: '提示',
            //             message: res.message || '获取短信验证码失败',
            //             type: 'warning'
            //         })
            //     }
            // })
        }
    })
}
const startCountdown = () => {
    countdown.value = 60
    if (smsTimer.value) clearInterval(smsTimer.value)
    smsTimer.value = setInterval(() => {
        if (countdown.value > 0) {
            countdown.value--
        } else {
            clearInterval(smsTimer.value!)
        }
    }, 1000)
}
onUnmounted(() => {
    if (smsTimer.value) clearInterval(smsTimer.value)
})
const onSubmitLogin = (type: 'phone' | 'password') => {
    const formRef = type === 'phone' ? phoneFormRef.value : passwordFormRef.value
    if (!formRef) return

    formRef.validate((valid) => {
        if (!valid) return

        authService.apiSysAuthLoginPost({
            userName: loginForm.username,
            passWord: type === 'password' ? loginForm.password : ''
        }).then((res) => {
            if (res.data.statusCode == 200) {
                ElNotification({ title: '提示', message: '登录成功', type: 'success' })
                userStore.setToken(res.data.data?.accessToken??'')
                router.push({ path: '/Home' })

                if (loginForm.rememberMe && type === 'password') {
                    accountStore.rememberPwd = true
                    accountStore.phone = loginForm.username
                    accountStore.password = loginForm.password
                } else {
                    accountStore.clearAccountInfo()
                }
            } else {
                // if (type === 'password') {
                //     getCaptcha()
                // }
                ElNotification({ title: '提示', message: res.data.errors+'' , type: 'warning' })
            }
        });

    })
}
const switchToScanLogin = (type: string) => {
    if (type === 'dingding') {
        const path = `https://login.dingtalk.com/oauth2/auth?redirect_uri=${encodeURIComponent('http://localhost:5173/dingLogin.html')}&response_type=code&client_id=dingodpnoaeice5hdkvv&scope=openid corpid&state=login&prompt=consent`
        window.location.href = path;
        return;
    }
    else {
        ElMessage.warning('暂未开放该登录方式')
    }

}

const goToCopyrightPage = () => {
    // 打开公司版权/备案信息页面（可根据需要替换为具体路由或 URL）
    window.open('https://beiancx.miit.gov.cn/#/Integrated/index', '_blank')
}

onBeforeUnmount(() => {
    const container = document.getElementById('wechat-login-container')
    if (container) container.innerHTML = ''
})
</script>

<style scoped>
.bady {
    height: 100vh;
    width: 100vw;
    background-color: #226AFF;
    background-image: v-bind('customImg');
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
}

.img_icon_top {
    margin-top: 20px;
}

.bady_right {
    width: 680px;
    height: 100vh;
    background-color: #fff;
    float: right;
    background-color: rgba(255, 255, 255, 0.9);
    /* ✅ 只让背景半透明，子元素不受影响 */
    display: flex;
    justify-content: center;
    /* 水平居中 */
    align-items: center;
    overflow: hidden;
    /* 垂直居中 */
}

.login_content {
    width: 100%;
    box-sizing: border-box;
}

.img_icon_div img {
    width: 168px;
    height: 48px;
}

.img_icon_div {
    height: 48px;
}

.img_icon_title {
    font-size: 36px;
    color: #111111;
    line-height: 36px;
    font-weight: 500;
    margin-top: 26px;
}
</style>

<style scoped>
.login-tabs {
    width: 400px;
    margin: 0 auto;
}

.login-form {
    margin-top: 24px;

    h2 {
        color: #0065CC;
    }

    .el-form-item__content {
        flex-wrap: nowrap
    }

    .captcha-content {
        overflow: hidden;
    }

    .captcha-item {
        cursor: pointer;
        height: 30px;
        position: absolute;
        right: 1px;
        border-radius: 2px;
    }

    .forget-pwd {
        cursor: pointer;
        color: #FF8400;
        font-size: 14px;
    }

    .remember-pwd {
        font-size: 14px !important;
    }
}

.app-qrcode {
    float: left;
    border-radius: 5px;
    width: 170px;
    padding: 16px 10px 10px;

    p {
        margin: 5px 0;
        font-size: 14px;
    }
}

.login-container {
    /* position: absolute; */
    /* top: 80px;
        right: 140px; */
    width: 580px;

}

/* 覆盖 Element Plus 的 Tab 样式 */
:deep(.login-tabs .el-tabs__header) {
    margin: 0;
}

:deep(.login-tabs .el-tabs__nav) {
    width: 100%;
}

:deep(.el-input__inner) {
    line-height: 44px !important;
    height: 44px !important;
    font-size: 16px !important;
}

/* 默认状态（未选中） */
:deep(.login-tabs .el-tabs__item) {
    width: 50% !important;
    text-align: center;
    font-size: 18px !important;
    color: #111111;
    font-weight: 400 !important;
    padding: 0 !important;
    box-sizing: border-box;
    transition: font-size 0.2s ease;
    line-height: 50px;
    height: 50px;
    /* 可选：平滑过渡 */
}

/* 选中状态 */
:deep(.login-tabs .el-tabs__item.is-active) {
    font-size: 20px !important;
    color: #226AFF;
    font-weight: 400 !important;
}

.input-search-icon {
    width: 20px;
    height: 20px;
    vertical-align: middle;
    display: inline-block;
    margin-right: 25px;
    margin-left: 10px;
}

.sumbit-content .el-button {
    width: 100%;
    height: 40px;
    font-size: 16px;
    background-color: #226aff;
}

/* 其他登录 */
.other-login {
    margin-top: 15px;
}

.other-title {
    font-size: 15px;
    color: #111111;
    line-height: 40px;
    width: 30%;
}

.xian {
    width: 400px;
    display: inline-flex;
    height: 40px;
    line-height: 40px;

}

.left-xian {
    background: linear-gradient(-90deg, #BBBBBB 0%, rgba(255, 255, 255, 0) 100%);
    width: 35%;
    height: 1px;
    margin: auto 0;
    line-height: 40px;
}

.right-xian {
    background: linear-gradient(90deg, #BBBBBB 0%, rgba(255, 255, 255, 0) 100%);
    width: 35%;
    height: 1px;
    margin: auto 0;
    line-height: 40px;
}

.login-icons {
    display: flex;
    justify-content: center;
    gap: 100px;
    /* 图标组之间的间距 */
    margin-top: 4px;
}

.login-icons span {
    display: flex;
    flex-direction: column;
    align-items: center;
    cursor: pointer;
    transition: transform 0.2s;
}

.login-icons span:hover {
    transform: scale(1.05);
}

.login-icon {
    width: 30px;
    height: 30px;
    margin-bottom: 6px;
    /* 图标和文字间距 */
}

.form_top {
    margin-top: 45px;
}

.login-text {
    font-size: 14px;
    color: #333;
    white-space: nowrap;
    display: block;
    width: 72px;
    /* 关键：统一宽度 */
    text-align: center;
    margin-top: 4px;
    /* 可选：微调图标与文字间距 */
}

.ex_qrcode {
    margin-top: 45px;
}

.ex_qrcode_title {
    margin-top: 12px;
    font-size: 14px;
}

.ex_qrcode_img {
    height: 80px;

}

.ex_qrcode_img img {
    width: 80px;
    height: 80px;
}

.yzbtn {
    margin-top: 42px;
    margin-bottom: 98px;
}

.sms-code-text.disabled {
    color: #bbb;
    cursor: not-allowed;
}

.sms-code-text {
    color: #226AFF;
    font-size: 16px;
    cursor: pointer;
    user-select: none;
    padding: 0 5px;
}

:deep(.el-tabs__active-bar) {
    background-color: #226AFF;
}

/* 扫码登录弹窗遮罩 */
.scan-dialog-mask {
    position: fixed;
    top: 0;
    left: 0;
    width: 100vw;
    height: 100vh;
    /* ✅ 用 rgba 实现半透明黑色背景 */
    background: rgba(17, 17, 17, 0.6);
    /* #111111 的 rgba 表示 */
    z-index: 2000;
    display: flex;
    justify-content: center;
    align-items: center;
}

/* 弹窗内容 */
.scan-dialog {
    width: 600px;
    height: 600px;
    background: #ffffff;
    border-radius: 8px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 40px;
    box-sizing: border-box;
    position: relative;
    z-index: 2001;
}

.scan-qr-code {
    width: 300px;
    height: 300px;
    margin-bottom: 24px;
}

.scan-tip {
    font-size: 18px;
    color: #333;
    text-align: center;
}

/* 返回按钮 */
.back-to-login {
    width: 360px;
    height: 48px;
    line-height: 48px;
    background: #F5F5F5;
    border-radius: 4px;
    border: 1px solid #E8ECF2;
    margin-top: 84px;
}

/* 二维码区域 */
.qrcode-box {
    text-align: center;
}

.qrcode-box img {
    width: 180px;
    height: 180px;
    border: 1px solid #eee;
    border-radius: 8px;
}

.qrcode-box p {
    margin-top: 12px;
    font-size: 16px;
}

.qrcode-tip {
    font-weight: normal;
    font-size: 20px;
    color: #111111;
    line-height: 40px;
    height: 40px;
    margin-bottom: 35px;
}

/* 遮罩层：覆盖在 .qrcode-img 上 */
.qrcode-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 180px;
    height: 180px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    background: rgba(17, 17, 17, 0.8);
    /* #111111 的 rgba 表示 */
    border-radius: 8px;
    border: 1px solid #E8ECF2;
    color: white;
    cursor: pointer;
    box-sizing: border-box;
}

.overlay-icon {
    width: 32px !important;
    height: 32px !important;
    border: 0px !important;
    margin-bottom: 12px;
}

.overlay-text {
    text-align: center;
    color: white !important;
    font-size: 14px !important;
    line-height: 1.4 !important;
    margin: 0 !important;
    padding: 0 !important;
}

.ldyzQrCodeUrl {
    position: relative;
    display: inline-block;
}

.overlay-text-p {
    font-size: 18px;
    color: #F6F9FF;
    margin-top: 10px;
}

.bottom {
    position: absolute;
    bottom: 0;
    left: 360px;
    text-align: center;
    padding: 30px 0;
    font-weight: normal;
    font-size: 14px;
    color: #FFF;
    cursor: pointer;
}

.img_icon {
    width: 16px;
    height: 16px;
    margin: 0 4px;
    vertical-align: middle;
}
</style>