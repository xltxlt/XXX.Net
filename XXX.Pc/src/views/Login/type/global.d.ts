declare class WxLogin {
  constructor(options: {
    id: string
    appid: string
    scope: string
    redirect_uri: string
    state?: string
    style?: string
    href?: string
    self_redirect?: boolean
  })
}
interface Window {
  WxLogin: typeof WxLogin
}