import { defineStore } from "pinia"
// 定义 State 类型
interface UserState {
  accessToken: string,
  expiresIn: number,
  imAccount: string,
  imAppId: string,
  imUserSign: string,
  userInfo: {
    id: number;
    name: string;
    avatar: string;
  } | null;
}

export const useUserStore = defineStore('user', {
  // State
  state: (): UserState => ({
    accessToken: '',
    expiresIn: 3600,
    imAccount: '',
    imAppId: '',
    imUserSign: '',
    userInfo: null,
  }),

  // Getters
  getters: {
    isLoggedIn: (state) => !!state.accessToken,
  },

  // Actions
  actions: {
    setToken(accessToken: string) {
      this.accessToken = accessToken;
    },
    clearUser() {
      this.accessToken = '';
      this.imAccount = '';
      this.imAppId = '';
      this.imUserSign = '';
      this.userInfo = null;
    },
  },
  persist: true, // 持久化存储
});