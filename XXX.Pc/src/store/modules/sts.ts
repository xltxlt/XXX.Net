import { defineStore } from "pinia";
interface StsToken {
    accessKeyId: string
    accessKeySecret: string
    securityToken: string
    expiration: number // 时间戳（毫秒）
    requestId: string
}
export const useStsStore = defineStore('sts', {
  state: (): { token: StsToken | null } => ({
    token: null
  }),
  actions: {
    setToken(token: StsToken) {
      this.token = token
    },
    clearToken() {
      this.token = null
    }
  },
  persist: true
})
