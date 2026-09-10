<template>
    <yz-popup ref="yzPopupRef" :custom="true" @close-dialog="emtis('update:show', false)">
        <div class="yz-pay-page">
            <div style="margin-top: 40px;">
                <div class="yz-pay-page-bg"></div>
                <div class="yz-pay-header">
                    <div class="yz-pay-header-left">
                        <div class="yz-pay-header-title"> {{ pageDetail?.title ?? '' }}</div>
                        <div class="yz-pay-header-desc">{{ pageDetail?.description ?? '' }}</div>
                    </div>
                    <div class="yz-pay-header-right">
                        <div class="yz-pay-header-amount">
                            ￥<span>{{ props?.totalTransferMoney }}</span>元
                        </div>
                    </div>
                </div>
            </div>

            <div class="yz-pay-content">
                <div class="yz-pay-content-title">
                    支付方式
                </div>
                <div class="yz-pay-types">
                    <div class="yz-pay-type" :class="{
                        'yz-pay-type-checked': m.value == (payTypeData?.code)
                    }" v-for="m, i in payType" :key="i" @click="payTypeData = m">
                        <img :src="m.icon ?? '/imgs/common/kjpay.png'" alt="" srcset="">
                        {{ m.label }}
                    </div>
                </div>
                <div style="text-align: right;">
                    <el-button class="payBtn" @click.stop="onPayBondClick">确认支付</el-button>
                </div>
            </div>
        </div>
    </yz-popup>

</template>
<script setup lang='ts'>
import { computed, ref, watch } from 'vue';
import { payStautsMessage } from '@/api/pay';
import YzPopup from '../YzPopup/YzPopup.vue';
import type { YzDialogPars } from '@/components/common/YzPopup';

import { isArray } from '@/utils/is';
import { ElMessage } from 'element-plus';
import { orderPay, placeTransferAccountOrder, getPayGoodsDetailById } from '@/api/pay';
const emtis = defineEmits(['update:show', 'paySuccess'])
const payTypeData = ref<any>()
const otherPayData = ref<any>()
const orderNo = ref('')
const yzPopupRef = ref();
const props = withDefaults(defineProps<{
    title?: string,
    goodsId?: string,
    tranDesc?: string,
    oilTransferDTOS?: any[],
    tranNum?: string,
    allocationType?: number,
    back?: number,
    show: boolean,
    totalTransferMoney: string
}>(), {
    goodsId: '',
    back: 0,
    allocationType: 1,
    tranNum: '',
    show: false
})

const yzPopupPars = ref<YzDialogPars>({
    title: '支付',
    comp: null,
    height: '80%',
    width: '1000px',
    pars: {}
})
const onPayBondClick = async () => {
    const balanceType = payTypeData.value.balanceType;
    if (!payTypeData.value || !payTypeData.value.payType) {
        ElMessage.error('请选择支付方式');
        return;
    }
    if (payTypeData.value.payType == 'alipay' || payTypeData.value.payType == 'wechat') {
        ElMessage.error('暂不支持此支付方式');
    }
    else {
        const formData = {
            allocationType: props.allocationType,
            balanceType: balanceType,
            itemId: props.goodsId,
            oilTransferDTOS: props.oilTransferDTOS,
            tranNum: props.tranNum,
            tranDesc: props.tranDesc,
            payType: payTypeData.value.payType,
            transferPayWay: 1
        }
        try {
            const payRes = await placeTransferAccountOrder(formData);

            if (payRes.code == 200) {
                emtis('paySuccess', {
                    type: '2',
                    code: 200,
                    orderNo: payRes.data,
                    oilTransferDTOS: props.oilTransferDTOS,
                    message: "支付成功（本地账户）"
                })
            } else {
                ElMessage.error(`支付失败`);
            }
        }
        catch (error: any) {
             ElMessage.error(`支付失败`);
        }

    }

};
const pageDetail = ref<any>();
const init = async () => {
    // try {
    //     const formData = {
    //         allocationType: props.allocationType,
    //         balanceType: 1,
    //         itemId:  props.goodsId,
    //         oilTransferDTOS: props.oilTransferDTOS,
    //         tranNum:  props.tranNum,
    //         tranDesc:  props.tranDesc
    //     }
    //     const res = await placeTransferAccountOrder(formData);
    //     if (res.code != 200) {
    //         ElMessage.error(res.message);
    //         return;
    //     }
    //     orderNo.value = res.data;
    //     otherPayData.value = res.data.payData;
    // }
    // catch (error: any) {
    //     if (error.bizCode == '100001') {
    //         //已支付成功待处理
    //         emtis('paySuccess', {
    //             type: '1',
    //             code: 200,
    //             orderNo: error.data,
    //             goodsId: props.goodsId,
    //             message: "支付成功（已支付订单）"
    //         })
    //     }
    //     else {
    //         ElMessage.error(error.message);
    //     }
    // }
    const detailData = await getPayGoodsDetailById(props.goodsId, orderNo.value);
    pageDetail.value = detailData;

};
const iconUrl = ref<Record<string, string>>({
    'wx': '/imgs/common/wxpay.png',
    'zfb': '/imgs/common/zfbpay.png',
    'plate': '/imgs/common/kjpay.png'
})
const payType = computed(() => {
    return (pageDetail.value?.payTypeList ?? []).map((item: any) => {
        return {
            ...item,
            label: item.payName,
            value: item.code,
            msg: item.msg ?? "个人余额：<span style='color:#226AFF' >3.01</sapn>",
            icon: iconUrl.value[item.icon] ?? '/imgs/common/kjpay.png'
        }
    });
})
watch(() => props.show, (val: any) => {
    if (val) {
        yzPopupRef.value.open(yzPopupPars)
        init()
    }
})
</script>
<style lang='less' scoped>
.yz-pay-page {
    background: #F5F5F5;
    height: 100%;
    overflow: hidden;

    .yz-pay-page-bg {
        border-radius: 4px 4px 0px 0px;
        max-width: 900px;
        min-width: 900px;
        background: #226AFF;
        height: 4px;
        margin: 0 auto;
    }

    .yz-pay-header {
        max-width: 840px;
        min-width: 840px;
        margin: 0 auto;
        background-color: #ffffff;
        padding: 30px;
        display: flex;
        border-bottom-left-radius: 4px;
        border-bottom-right-radius: 4px;

        &-left {
            flex: 1;
        }

        &-title {
            text-align: left;
            font-size: 20px;
            color: #111111;
            font-weight: 500;
            margin-bottom: 5px;
        }

        &-desc {
            text-align: left;
            font-size: 15px;
            color: #999999;
        }

        &-right {
            width: 120px;
        }

        &-amount {
            font-size: 24px;
            color: #111111;

            span {
                color: #FF3000;
                font-size: 36px;
                font-weight: bold;
            }
        }
    }

    .yz-pay-content {
        max-width: 840px;
        min-width: 840px;
        margin: 20px auto 0;
        background: #FFFFFF;
        border-radius: 4px;
        padding: 25px 30px;
        min-height: 360px;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        flex-wrap: nowrap;

        &-title {
            text-align: left;
            padding-bottom: 20px;
            font-size: 16px;
            font-weight: 500;
            color: #111111;
        }

        .yz-pay-types {
            flex: 1;

        }

        .yz-pay-type {
            float: left;
            display: inline-block;
            margin-top: 15px;
            margin-right: 3.83%;
            width: calc(22% - 62px);
            cursor: pointer;
            display: flex;
            font-size: 16px;
            color: #111111;
            padding: 17px 30px;
            border: 1px solid #DDDDDD;
            border-radius: 4px;
            background: #FFFFFF;

            &:nth-of-type(4n) {
                margin-right: 0;
            }

            img {
                margin-right: 10px;
                width: 25px;
                height: 25px;
            }

            &-checked {
                border-bottom-right-radius: 6px;
                border: 1px solid #226AFF;
                background-color: #F1F6FF;
                background-image: url(/imgs/common/payChecked.png);
                background-repeat: no-repeat;
                background-position: 100% 100%;
                background-size: 24px 24px;

            }
        }
    }

    .payBtn {
        margin-top: 20px;
        height: 36px;
        background: #226AFF;
        color: #ffffff;

    }
}
</style>