<template>
    <div class="settled-bond">
        <div class="settled-bond-content">
            <!-- 保证金信息 -->
            <div class="pay-bond-info">
                <div class="pay-bond-icon-wrapper">
                    <img src="/public/imgs/common/bond.png" class="pay-bond-icon" alt="" />
                </div>
                <div class="pay-bond-content">
                    <div class="pay-bond-title">
                        {{ pageDetail?.title ?? '缴纳验证保证金(元)' }}
                    </div>
                    <div class="pay-bond-amount">
                        <span class="pay-bond-currency">￥</span>
                        {{ getAmountVal(pageDetail?.payAmount) }}
                        <span class="pay-bond-decimal">.{{ getAmountDecimal(pageDetail?.payAmount) }}</span>
                    </div>
                    <div class="pay-bond-msg">
                        {{ pageDetail?.description ?? '保证金用于信息核验，入驻成功即全额原路退还至 您的支付账户；若因信息不实导致审核未通过，则作为服务费扣除，不予退还。' }}
                    </div>
                </div>
            </div>

            <!-- 支付方式选择 -->
            <div class="yz-radio-content">
                <div class="yz-radio-header">
                    请选择支付方式
                </div>
                <el-radio-group v-model="selectedPayment" class="payment-radio-group">
                    <label
                        v-for="option in paymentOptions"
                        :key="option.value"
                        class="custom-radio-item"
                    >
                        <div class="radio-label">{{ option.name }}</div>
                        <div class="radio-control">
                            <el-radio :label="option.value" />
                        </div>
                    </label>
                </el-radio-group>
            </div>

            <!-- 底部按钮（可自定义文字） -->
            <div class="payment-footer static-bottom">
                <el-button type="primary" class="payment-button" @click="onConfirm">
                    {{ buttonText }}
                </el-button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, defineProps, defineEmits } from 'vue';
import type { PageDetail, PaymentOption} from '.'
// ---------------------
// Props 接收外部数据
// ---------------------
const props = withDefaults(defineProps<{
    pageDetail?: PageDetail;
    paymentOptions?: PaymentOption[]; // 支付方式由父级传入
    buttonText?: string;               // 按钮文字
}>(), {
    buttonText: '确认支付',
    paymentOptions: () => [
       
    ]
    // pageDetail 可选，有默认值展示
});

// ---------------------
// Events 抛出事件
// ---------------------
const emit = defineEmits<{
    (e: 'confirm', paymentMethod: string): void; // 传出选中的支付方式
}>();

// ---------------------
// 本地数据
// ---------------------
// 当前选中的支付方式
const selectedPayment = ref<string>(props.paymentOptions[0]?.value || '1');


// 金额格式化
const getAmountVal = (val: string | number | undefined): string => {
    if (val == undefined) return "0";
    const strVal = String(val);
    const parts = strVal.split(".");
    return parts[0] || "0";
};

const getAmountDecimal = (val: string | number | undefined): string => {
    if (val == undefined) return "00";
    const strVal = String(val);
    const parts = strVal.split(".");
    return parts.length > 1 ? parts[1].padEnd(2, '0').slice(0, 2) : "00";
};

// ---------------------
// 点击确认按钮
// ---------------------
const onConfirm = () => {
    emit('confirm', selectedPayment.value); // 抛出事件 + 当前选中的支付方式
};
</script>

<style lang="less" scoped>
.settled-bond {
    margin: 0 auto;
    max-width: 400px; // 控制宽度
}

.settled-bond-content {
    background: linear-gradient(180deg, #226aff 20%, #f5f5f5 100%);
    background-size: 100% 150px;
    background-repeat: no-repeat;

    // 保证金信息区域
    .pay-bond-info {
        border-radius: 5px;
        margin: 0 15px 15px;
        position: relative;

        .pay-bond-title {
            padding: 10px 0 5px;
            text-align: center;
            font-weight: 500;
            font-size: 20px;
            color: #111111;
        }

        .pay-bond-amount {
            padding-top: 5px;
            line-height: 30px;
            text-align: center;
            font-size: 30px;
            color: #111111;
            font-weight: 500;

            .pay-bond-currency {
                font-size: 15px;
            }

            .pay-bond-decimal {
                font-size: 18px;
            }
        }

        .pay-bond-msg {
            padding-top: 15px;
            text-align: left;
            font-weight: 400;
            font-size: 14px;
            color: #111111;
            line-height: 22px;
        }

        .pay-bond-content {
            border-radius: 5px;
            padding: 55px 19px 20px;
            background-color: #ffffff;
        }

        .pay-bond-icon-wrapper {
            height: 50px;
            position: relative;
        }

        .pay-bond-icon {
            position: absolute;
            width: 80px;
            height: 80px;
            bottom: -50px;
            left: 50%;
            transform: translateX(-50%);
        }
    }

    // 支付方式区域
    .yz-radio-content {
        margin: 0 15px 15px;
        background: #fff;
        padding: 15px;
        border-radius: 5px;

        .yz-radio-header {
            font-size: 16px;
            color: #111;
            margin-bottom: 12px;
        }

        .payment-radio-group {
            display: flex;
            flex-direction: column;
            gap: 12px;
        }

        .custom-radio-item {
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100%;
            font-size: 18px;
            color: #111;
            cursor: pointer;
            user-select: none;
            padding: 6px 0;
        }

        .radio-label {
            float: left;
            line-height: 20px;
        }

        .radio-control {
            display: flex;
            align-items: center;
        }

        // 隐藏 el-radio 的默认文字
        ::v-deep(.el-radio__label) {
            display: none !important;
        }

        ::v-deep(.el-radio__input) {
            font-size: 14px;
        }
    }

    // 底部按钮
    .static-bottom {
        padding: 15px;
        box-sizing: border-box;
    }

    .payment-button {
        width: 100%;
        height: 48px;
        font-size: 16px;
        font-weight: 500;
    }
}
</style>