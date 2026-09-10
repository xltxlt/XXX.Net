// utils/qrcodeGenerator.ts
import QRCode from 'qrcode'

/**
 * 将文本生成 Data URL（Base64）格式的二维码图片
 * @param text 要编码的内容，如 https://example.com/scan?code=123
 * @param options 可选配置
 * @returns Promise<string> data:image/png;base64,...
 */
export const generateQrCodeDataUrl = async (
  text: string,
  options: {
    width?: number
    margin?: number
    color?: { light: string; dark: string }
  } = {}
): Promise<string> => {
  const defaultOptions = {
    width: 180,
    margin: 2,
    color: {
      light: '#ffffff',
      dark: '#000000'
    },
    ...options
  }

  try {
    const dataUrl = await QRCode.toDataURL(text, defaultOptions)
    return dataUrl
  } catch (error) {
    console.error('生成二维码失败:', error)
    throw error
  }
}