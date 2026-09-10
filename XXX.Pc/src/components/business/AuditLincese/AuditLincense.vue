<script setup lang='ts'>
import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import type { TempEditPageData } from '@/components/PageForm';
import AuditImgs from './AuditImgs.vue';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const tempForm = ref<TempEditPageData>({
    loading: false,
    cols: 2,
    form: [
        {
            type: "group",
            title: "证件图片",
            name: 'audit-imgs',
            child: []
        },
        {
            type: "group",
            title: "用户信息",
            name: '',
            child: [{
                type: "input",
                title: "身份证姓名",
                name: 'driverLicenseName'
            }, {
                type: "input",
                title: "身份证号",
                name: 'driverLicenseNumber'
            },
            ]
        },
        {
            type: "group",
            title: "证件信息",
            name: '',
            child: [{
                type: "input",
                title: "驾驶证号",
                name: 'driverLicenseNumber'
            }, {
                type: "input",
                title: "姓名",
                name: 'driverLicenseName'
            }, {
                type: "input",
                title: "性别",
                name: 'driverLicenseGender'
            }, {
                type: "mulitSelect",
                title: "准驾车型",
                name: 'driverLicenseClass'
            }, {
                type: "input",
                title: "有效期起",
                name: 'driverLicenseValidPeriodStart'
            },
            {
                type: "input",
                title: "有效期至",
                name: 'driverLicenseValidPeriodEnd'
            },
            {
                type: "input",
                title: "出生日期",
                name: 'driverLicenseDateBirth'
            },
            {
                type: "input",
                title: "住址",
                name: 'driverLicenseNumber'
            },
            {
                type: "input",
                title: "国籍",
                name: 'driverLicenseNationality'
            },
            {
                type: "input",
                title: "发证机关",
                name: 'driverLicenseIssuingAgency'
            },
            {
                type: "input",
                title: "副页证号",
                name: 'driverLicenseBackNumber'
            },
            {
                type: "input",
                title: "档案编号",
                name: 'driverLicenseBackFileNumber'
            },
            {
                type: "input",
                title: "录入人",
                name: 'gmtCreated'
            },
            {
                type: "input",
                title: "录入时间",
                name: 'gmtCreated'
            },

            ]
        },
        {
            type: "group",
            title: "审核信息",
            name: '',
            child: [{
                type: "input",
                title: "审核状态",
                name: 'driverLicenseNumber'
            }, {
                type: "input",
                title: "审核人",
                name: 'driverLicenseName'
            }, {
                type: "input",
                title: "审核时间",
                name: 'driverLicenseGender'
            }, {
                type: "input",
                title: "审核意见",
                name: 'driverLicenseClass'
            },
            ]
        }
    ],
    rules: {
        title: [{ required: true, message: '请填写资源名称', trigger: 'blur' },],
        icon: [{ required: true, message: '请选择资源图标', trigger: 'blur' },],
        isOpen: [{ required: true }],
        isPage: [{ required: true }],
        isTree: [{ required: true }],

    },
    formData: {
        id: pars?.id ?? null,
        sortNum: 1,
        classList: [],
        currencyStatus: 1,
        isPage: 0,
        typeId: 1,
        isOpen: 0,
        isTree: 0,
    },
    options: {
        typeId: [{
            label: 'pc端',
            value: 1
        }, {
            label: 'H5端',
            value: 2
        }, {
            label: 'pc顶部导航',
            value: 3
        }, {
            label: 'app端',
            value: 4
        }, {
            label: '小程序端',
            value: 5
        }],
        isPage: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
        isOpen: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
        isTree: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
        currencyStatus: [{
            label: '平台专用',
            value: 0
        }, {
            label: '所有通用',
            value: 1
        }]
    },

})
const imgTypes = ref([
    { label: '驾驶证正面', name: 'idFront', url: '', defUrl: '/imgs/license/drivingLicense.png', typeId: 3 },
    { label: '驾驶证反面', name: 'idBack', url: '', defUrl: '/imgs/license/drivingLicenseBack.png', typeId: 4 },
])
function handleImgChange(name: string, url: string) {
    const item = imgTypes.value.find(i => i.name === name)
    if (item) item.url = url;
}
</script>
<template>
    <div class="audit-license">
        <div class="lincense-info">
            {{imgTypes}}
            <page-form :temp-form="tempForm">
                <template #group="{ item }">
                    <template v-if="item.name == 'audit-imgs'">
                        <audit-imgs v-model:imgTypes="imgTypes" @change="handleImgChange" />
                    </template>
                    <template v-else>
                        <!-- 兜底：渲染 PageForm 的默认 group 内容 -->
                        <slot />
                    </template>
                </template>
            </page-form>
        </div>
    </div>
</template>
<style lang='less' scoped>
.audit-license {
    height: 100%;
    width: 100%;
}
</style>