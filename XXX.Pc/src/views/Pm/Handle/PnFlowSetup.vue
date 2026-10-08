<template>
    <div class="sub-page">
        <div class="sub-page-header sub-page-card">
            <div>
                <div class="sub-page-header-title">
                    <el-button text type="primary" @click="router.back()">
                        <el-icon style="padding-right: 5px;">
                            <Back />
                        </el-icon>
                        返回
                    </el-button>
                    {{ flowItemDetail.name }}
                </div>
                <div class="sub-page-header-info">
                    <el-tag type="success"><el-icon>
                            <Clock />
                        </el-icon>进行中</el-tag>
                    <span>流程编码：{{ flowItemDetail.code }}</span>
                    <span>发起时间：{{ flowItemDetail.createdTime }}</span>

                </div>
            </div>

            <div class="sub-page-header-tools">
                <el-button type="primary" :icon="Bell">催办</el-button>
                <el-button :icon="Switch">转办</el-button>
                <el-button :icon="Clock">延期</el-button>
                <el-button :icon="RefreshLeft">回退</el-button>
                <el-button type="danger" :icon="Delete">终止</el-button>
            </div>
        </div>
        <div class="sub-page-content">
            <div>
                <Card :title="'流程基本信息'" style="margin-top: 10px;">
                    <div class="info-content">
                        <span><label>流程名称：</label>{{ flowItemDetail.name }}</span>
                        <span><label>流程编号：</label>{{ flowItemDetail.code }}</span>
                        <span><label>流程类型：</label>{{ flowItemDetail.flowName }}</span>
                        <span><label>发起人：</label>{{ flowItemDetail.createdByName }}</span>
                        <span><label>发起时间：</label>{{ flowItemDetail.createdTime }}</span>
                        <span><label>当前步骤：</label>{{ nodeName }}(剩余3天)</span>
                        <span><label>流程状态：</label>
                            <el-tag type="success">{{ flowItemDetail.flowStatus }}</el-tag>
                        </span>
                        <span><label>紧急程度：</label>
                            <el-tag type="info">一般</el-tag>
                        </span>
                        <span><label>预计完成时间：</label>{{ flowItemDetail.planEndTime }}</span>
                    </div>
                </Card>
                <div class="sub-page-card" style="padding:0 20px 15px 20px;">
                    <el-tabs style="min-height: 300px;">
                        <el-tab-pane label="流程处理">
                            <div>
                                <PageFormEnhanced :hide-btn="true" ref="startFormRef" :cols="2"
                                    :form="startFormData.form" :attr-data="startFormData.attrData"></PageFormEnhanced>
                            </div>
                            <div>
                                <el-button type="primary">保存</el-button>
                                <el-button type="success" @click.stop="pageFun.submit">保存并流转</el-button>
                            </div>
                        </el-tab-pane>
                        <el-tab-pane label="流程审批">
                            <div class="wf-apply">
                                <img src="/public/imgs/header.png" style="border-radius:50% ;width: 40px;height: 40px;"
                                    alt="" srcset="">
                                <div class="wf-apply-form">
                                    <p class="wf-apply-title">
                                        采购审批流程 <el-tag type="primary" style="margin-left: 10px;">当前步骤</el-tag>
                                    </p>
                                    <p>
                                        审批用户：李四（研发部）
                                    </p>
                                    <p>
                                        处理时限：2026-10-01 10:00（剩余2天）
                                    </p>
                                    <p>
                                        审批意见：
                                        <el-input type="textarea" placeholder="请输入审批意见" v-model="approvalOpinion"
                                            :rows="4" maxlength="500"></el-input>

                                    </p>
                                    <p>
                                        常用语句：
                                        <el-button size="small">同意</el-button>
                                        <el-button size="small">没问题</el-button>
                                        <el-button size="small">原则上同意</el-button>
                                        <el-button size="small">不同意</el-button>
                                        <el-button size="small">有问题</el-button>

                                    </p>
                                    <div class="wf-apply-tools">
                                        <el-button type="primary">同意</el-button>
                                        <el-button type="danger">驳回</el-button>
                                    </div>
                                </div>
                            </div>


                        </el-tab-pane>
                        <el-tab-pane label="流程记录">
                            <div>
                                <table width="100%" class="setup-handle-record">
                                    <tbody>
                                        <tr v-for="item, index in historyList" :key="index">
                                            <td width="80px">
                                                <span>{{ index + 1 }}</span>
                                            </td>
                                            <td>
                                                <el-button @click="pageFun.switchNode(item.nodeId ?? '')" text
                                                    type="primary">{{ item.nodeName }}</el-button>
                                            </td>
                                            <td width="300px">
                                                {{ item.operatorName }}（项目部）
                                            </td>
                                            <td width="260px">
                                                {{ item.operatedTime }}
                                            </td>
                                            <td width="100px">
                                                <el-button type="success" plain round>{{ item.action }}</el-button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <ElDialog  v-model="dialogTableVisible" :draggable="true" :title="'采购单明细'" width="60%" height="70%">
                                <PageFormEnhanced :hide-btn="true" :cols="2" :form="checkedFormData.form"
                                    :attr-data="checkedFormData.attrData" :formData="checkedFromDataValue">
                                </PageFormEnhanced>
                            </ElDialog>
                        </el-tab-pane>
                        <el-tab-pane label="相关附件">
                        </el-tab-pane>
                    </el-tabs>
                </div>
            </div>
            <div>
                <Card :title="'流程图'" style="margin-top: 10px;">
                    <div class="wf-items">
                        <div class="wf-item">
                            <div class="wf-item-status">
                                <el-icon>
                                    <Position></Position>
                                </el-icon>
                                <el-icon class="wf-item-line">
                                    <Right></Right>
                                </el-icon>
                            </div>

                            <label>发起流程</label>
                            <span>张三</span>
                            <el-button size="small" round type="success" plain>已完成</el-button>
                        </div>
                        <div class="wf-item">
                            <div class="wf-item-status">
                                <el-icon>
                                    <Position></Position>
                                </el-icon>
                                <el-icon class="wf-item-line">
                                    <Right></Right>
                                </el-icon>
                            </div>


                            <label>发起流程</label>
                            <span>张三</span>
                            <el-button size="small" round type="primary" plain>进行中</el-button>
                        </div>
                        <div class="wf-item">
                            <div class="wf-item-status">
                                <el-icon>
                                    <Position></Position>
                                </el-icon>
                                <el-icon class="wf-item-line">
                                    <Right></Right>
                                </el-icon>
                            </div>

                            <label>发起流程</label>
                            <span>张三</span>
                            <el-button size="small" round plain>未开始</el-button>
                        </div>
                    </div>
                </Card>
                <Card :title="'评论/留言'" style="margin-top: 10px;">
                    <Commnets></Commnets>
                </Card>
            </div>
        </div>

    </div>
</template>

<script setup lang="ts">
import Card from '@/components/common/Card/Card.vue';
import Commnets from '@/components/common/Comments/Commnets.vue';
import type { ReleaseData } from '@/components/PageForm/enhancedIndex';
import router from '@/router';
import { Back, Bell, Clock, Delete, Loading, More, Operation, Position, RefreshLeft, Right, Switch } from '@element-plus/icons-vue';
import { MoreFilled } from '@element-plus/icons-vue'
import type { ElDialog, TimelineItemProps } from 'element-plus'
import { pmFlowItemService, workflowNodeFormService, workflowTaskService } from '@/api/pm';
import { onMounted, ref } from 'vue';
import { getQueryByName } from '@/utils/pcRouter';
import PageFormEnhanced from '@/components/PageForm/PageFormEnhanced.vue';
import { ElLoading, ElMessage } from 'element-plus';
import type { PmFlowItem, WorkflowHistory, WorkflowTask } from '@/api-services/generated';
import YzPopup from '@/components/common/YzPopup/YzPopup.vue';
import { ca } from 'element-plus/es/locale/index.mjs';
import type { title } from 'process';
interface ActivityType extends Partial<TimelineItemProps> {
    content: string
}
const activities: ActivityType[] = [
    {
        content: '发起申请',
        timestamp: '2018-04-12 20:46',
        size: 'large',
        type: 'primary',
        icon: MoreFilled,
    },
    {
        content: 'Custom color',
        timestamp: '2018-04-03 20:46',
        color: '#0bbd87',
    },
    {
        content: 'Custom size',
        timestamp: '2018-04-03 20:46',
        size: 'large',
    },
    {
        content: 'Custom hollow',
        timestamp: '2018-04-03 20:46',
        type: 'primary',
        hollow: true,
    },
    {
        content: 'Default node',
        timestamp: '2018-04-03 20:46',
    },
]
const dialogTableVisible = ref<boolean>(false)
const nodeId = getQueryByName('nodeId');
const nodeName = ref(getQueryByName('nodeName'));
const taskId = getQueryByName('taskId');
const pmFlowItemId = getQueryByName('pmFlowItemId');
const instanceId = getQueryByName('instanceId');
const workflowDefinitionId = getQueryByName('workflowDefinitionId');


const approvalOpinion = ref('');
const startFormRef = ref()
const startFormData = ref<ReleaseData>({ form: [], attrData: {} });
const checkedFormData = ref<ReleaseData>({ form: [], attrData: {} });
const checkedFromDataValue = ref({})



const getStartFormValues = () => {
    const data = startFormRef.value?.getData() ?? startFormData.value;
    return data;
};
const pageFun = {
    save: () => {
        const data = getStartFormValues();
        console.log('保存数据', data);
    },
    submit: async () => {
        const result = await startFormRef.value?.validate?.();
        if (result === false)
            return false;
        const data = getStartFormValues();
        const res = await workflowTaskService.apiWorkflowTaskPost({
            formData: data,
            taskId: taskId,
            action: 'complete',
            comment: ''
        });
        router.back();
        ElMessage({ message: '操作成功', type: 'success', plain: true });
    },
    switchNode: async (nodeId: string) => {
        const loading = ElLoading.service({
            lock: true,
            text: 'Loading',
            background: 'rgba(0, 0, 0, 0.7)',
        })
        dialogTableVisible.value = true;
        try {
            const formRes = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
                String(workflowDefinitionId),
                nodeId
            );
            var taskRes = await workflowTaskService.apiWorkflowTaskDetailNodeidGet(nodeId);

            const nodeForm = formRes.data?.data;
            if (!nodeForm) {
                return;
            }
            checkedFormData.value = {
                form: parseJson(nodeForm.formJson, []),
                attrData: parseJson(nodeForm.attrDataJson, {}),
            };
            let formDataJson = taskRes.data.data?.formDataJson;
            checkedFromDataValue.value = formDataJson ? JSON.parse(formDataJson) : {}

        }
        finally {
            loading.close()

        }

    }
}
const flowItemDetail = ref<PmFlowItem>({})
const historyList = ref<WorkflowHistory[]>([])
onMounted(async () => {
    const formRes = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
        String(workflowDefinitionId),
        nodeId
    );
    const nodeForm = formRes.data?.data;

    if (!nodeForm) {
        return;
    }

    startFormData.value = {
        form: parseJson(nodeForm.formJson, []),
        attrData: parseJson(nodeForm.attrDataJson, {}),
    };

    const detail = await pmFlowItemService.apiPmFlowItemDetailIdGet(pmFlowItemId);
    flowItemDetail.value = detail.data.data ?? {}

    const historyRes = await workflowTaskService.apiWorkflowTaskWfHistorydListInstanceidGet(instanceId)
    historyList.value = historyRes.data.data ?? []
})
const parseJson = (value: any, fallback: any) => {
    if (!value) return fallback;
    if (typeof value === 'object') return value;
    try { return JSON.parse(value); } catch { return fallback; }
};

</script>
<style scoped lang="less">
.sub-page {
    overflow-y: auto;
    height: 100%;

    &-card {
        border-radius: 10px;
        box-shadow: inset 0 0 0 1px rgb(0 0 0 / 8%);
        background-color: #fff;
        padding: 15px 10px;
        margin-top: 10px;
    }

    &-header {
        &-info {
            display: flex;
            align-items: center;
            gap: 10px;
            font-size: 14px;
            color: #696969;
            padding-left: 15px;
            font-weight: 500;

            .sub-page-header-tools {
                margin-left: auto;
                display: flex;
                align-items: center;
                gap: 10px;
            }
        }
    }

    &-header-title {
        display: flex;
        align-items: center;
        gap: 10px;
        font-size: 20px;
        font-weight: 500;

    }

    &-content {
        display: flex;

        .info-content {
            margin-top: 10px;
            display: flex;
            font-size: 15px;
            color: #696969;
            padding-left: 15px;
            flex-direction: row;
            flex-wrap: wrap;
            justify-content: space-between;
            text-align: left;
            align-items: flex-start;

            label {
                padding-right: 5px;
                color: #888;
            }

            >span {
                padding: 7px 0;
                width: 50%;
                color: #333333;
            }
        }

        >div {
            &:first-child {
                margin-right: 15px;
                width: 70%;
            }

            &:last-child {
                flex: 1;
            }
        }
    }

    .setup-handle-record {
        tr {
            td {
                padding: 10px 0;
                text-align: left;
                border-bottom: 1px solid #eaeaea;
                padding-left: 5px;

                &:first-child {
                    border-bottom: unset;
                    text-align: center;
                    padding-left: 0;
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    width: 100%;
                    position: relative;

                    >span {
                        display: block;
                        width: 30px;
                        height: 30px;
                        background-color: #edeff4;
                        border-radius: 50%;
                        color: #000;
                        display: flex;
                        font-size: 14px;
                        font-weight: bold;
                        align-items: center;
                        justify-content: center;
                        z-index: 2;
                        border: 5px solid #fff;
                    }

                    &::after {
                        content: '';
                        display: block;
                        width: 2px;
                        height: 100%;
                        background-color: #ccc;
                        position: absolute;
                        z-index: 1;
                        top: 50%;
                        left: 50%;
                    }

                }


            }

            &:last-child {
                td:first-child::after {
                    display: none;
                }
            }

        }

        tr.success {
            td:first-child {
                >span {
                    background-color: #409eff;
                }
            }
        }

        tr.done {
            td:first-child {
                >span {
                    background-color: #0bbd87;
                }
            }
        }
    }

    .wf-items {
        margin-top: 10px;
        display: flex;

        .wf-item {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            gap: 10px;
            padding: 10px 15px;
            width: 100px;
            position: relative;

            &:last-child {
                border-right: none;
            }

            .wf-item-status {
                width: 46px;
                height: 46px;
                border-radius: 50%;
                background-color: #edeff4;
                display: flex;
                align-items: center;
                justify-content: center;
                font-size: 22px;

                svg {
                    width: 30px;
                    height: 30px;
                }
            }

            label {

                font-size: 15px;
                color: #333;
                font-weight: 500;

            }

            >span {
                font-size: 14px;
                color: #666666;
            }

            .wf-item-line {
                position: absolute;
                height: 2px;
                font-size: 30px;
                color: #999999;
                transform: translateY(-50%);
                right: -25%;
                transform: translateX(-50%);

            }

            &:last-child {
                .wf-item-line {
                    display: none;
                }
            }
        }
    }

    .wf-apply {
        display: flex;
        align-items: flex-start;
        gap: 10px;
        margin-top: 10px;
        padding: 15px;

        .wf-apply-form {
            text-align: left;
            flex: 1;

            .wf-apply-title {
                font-size: 16px;
                color: #333;
                font-weight: 500;
            }

            p {
                margin: unset;
                padding: 5px 0;
                font-size: 15px;
                display: flex;

                &:first-child {
                    padding-top: 0;
                }
            }

            .wf-apply-tools {
                margin-top: 30px;
                text-align: center;
            }
        }
    }

    .sub-page-header.sub-page-card {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: center;
    }

    @media (max-width: 1200px) {
        .sub-page-content {
            flex-direction: column;

            >div:first-child {
                width: unset;
                margin-right: unset;

            }
        }

        .sub-page-header.sub-page-card {
            display: flex;
            flex-direction: column;
            align-items: flex-start;

            .sub-page-header-tools {
                padding: 20px 0;
                text-align: right;
                width: 100%;

                button {
                    margin-bottom: 10px;
                }
            }
        }
    }
}
</style>
<style lang="less">
.sub-page {
    padding: 0 10px;

    .el-tabs__header {
        background-color: unset !important;
        margin-bottom: 0;
    }

    .el-tabs__item {
        font-size: 16px;
        padding: 15px;
        height: 56px;

        &.is-active {
            color: #409eff !important;
            font-weight: 500 !important;
        }
    }

    .el-tabs__nav-wrap:after {
        height: 1px;
    }

    .el-tabs__active-bar {
        height: 3px;
        border-radius: 3px;
    }

    .el-tabs__content {
        background-color: unset !important;
    }

    .wf-apply .el-textarea {
        width: unset;
        flex: 1;
    }
}
</style>