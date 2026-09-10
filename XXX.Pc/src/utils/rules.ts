import type { FormRules,FormItemRule } from 'element-plus'

export const mobilePhoneRules:any = [
    { required: true, message: '请输入手机号' },
    { pattern: /^1[3-9]\d{9}$/, message: '手机号格式不正确' }
]

export const idCardRules:any = [
    { required: true, message: '请输入身份证号' },
    { pattern: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/, message: '身份证号格式不正确' }
]

export const idCard:any = [
    { pattern: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/, message: '身份证号格式不正确' }
]


export const emailRules:any = [
    { required: true, message: '请输入邮箱' },
    { pattern: /^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z0-9]{2,6}$/, message: '邮箱格式不正确' }
]

export const requiredRules:any = [
    { required: true, message: '该项为必填项' }
]

export const percentRules:any = [
      { required: true, message: '请输入数字' },
    { pattern:/^0\.\d{1,2}$/, message: '税率大于0且小于1，且最多保留2位小数！' }
]
export const priceRules:any = [
      { required: true, message: '请输入数字' },
    { pattern:/^(?!0(\.0{1,2})?$)\d+(\.\d{1,2})?$/, message: '金额大于0，且最多保留2位小数！' }
]

export const numberRules:any = [
    { pattern: /^-?\d+(\.\d+)?$/, message: '请输入数字' }
]
export const numberRulesRequired:any = [
    { required: true, message: '请输入数字' },
    { pattern: /^-?\d+(\.\d+)?$/, message: '请输入数字' }
]
export const integerRules: any = [
    { required: true, message: '请输入整数' },
    { pattern: /^-?[1-9]\d*$|^0$/, message: '请输入有效的整数' }
]

export const integer: any = [
    { pattern: /^-?[1-9]\d*$|^0$/, message: '请输入有效的整数' }
]

export const passwordRules:any = [
    { required: true, message: '请输入密码' },
    { pattern: /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$/, message: '密码必须包含字母和数字，且长度为6-20位' }
]