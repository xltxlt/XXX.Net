
import { defineStore } from 'pinia'
export const useAccountStore = defineStore('account', {
    state: () => ({
        phone: '',
        password: '',
        rememberPwd: false,
    }),
    actions: {
        setAccountInfo(phone: string, password: string, rememberPwd: boolean) {
            this.phone = phone
            this.password = rememberPwd ? password : ''
            this.rememberPwd = rememberPwd
        },
        clearAccountInfo() {
            this.phone = ''
            this.password = ''
            this.rememberPwd = false
        }
    },
    persist: true // 需要 pinia-plugin-persistedstate 支持
})