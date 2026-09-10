// utils/wechatLogin.ts
export const loadWxLoginScript = (): Promise<void> => {
  return new Promise((resolve, reject) => {
    if ((window as any).WxLogin) {
      // 已加载
      resolve()
      return
    }

    const script = document.createElement('script')
    script.src = 'https://res.wx.qq.com/connect/zh_CN/htmledition/js/wxLogin.js'
    script.async = true
    script.onload = () => resolve()
    script.onerror = () => reject(new Error('Failed to load WxLogin.js'))
    document.head.appendChild(script)
  })
}