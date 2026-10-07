<template>
    <div class="sub-page">
        <div class="sub-page-header sub-page-card">
            <div class="sub-page-header-title">
                <el-button text type="primary" @click="router.back()">
                    <el-icon style="padding-right: 5px;">
                        <Back />
                    </el-icon>
                    返回
                </el-button>
                项目立项审批流程
            </div>
            <div class="sub-page-header-info">
                <el-tag type="success"><el-icon>
                        <Clock />
                    </el-icon>进行中</el-tag>
                <span>流程编码：WF2610000001</span>
                <span>发起时间：2026-10-01 10:00:00 </span>
                <div class="sub-page-header-tools">
                    <el-button type="primary" :icon="Bell">催办</el-button>
                    <el-button :icon="Switch">转办</el-button>
                    <el-button type="danger" :icon="Delete">撤回</el-button>
                    <el-button :icon="Delete">延期</el-button>
                    <el-button :icon="Delete">回退</el-button>
                    <el-button type="danger" :icon="Delete">终止</el-button>
                    <el-button :icon="Operation">更多</el-button>
                </div>
            </div>
        </div>
        <div class="sub-page-content">
            <div>
                <Card :title="'流程基本信息'" style="margin-top: 10px;">
                    <div class="info-content">
                        <span><label>流程名称：</label>XXX项目</span>
                        <span><label>流程编号：</label>XXX20231001</span>
                        <span><label>流程类型：</label>研发项目</span>
                        <span><label>发起人：</label>张三</span>
                        <span><label>发起时间：</label>2023-10-01 10:00</span>
                        <span><label>当前步骤：</label>部门经理审批</span>
                        <span><label>所属部门：</label>研发部</span>
                        <span><label>流程状态：</label>
                            <el-tag type="success">进行中</el-tag>
                        </span>
                        <span><label>紧急程度：</label>
                            <el-tag type="info">一般</el-tag>
                        </span>
                        <span><label>预计完成时间：</label>2023-10-15 10:00</span>
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
                                        审批人：李四（研发部）
                                    </p>
                                    <p>
                                        处理时限：2026-10-01 10:00（剩余2天）
                                    </p>
                                    <p>
                                        审批意见：
                                        <el-input type="textarea" placeholder="请输入审批意见" v-model="approvalOpinion"
                                            :rows="4" maxlength="500"></el-input>
                                    </p>
                                    <div class="wf-apply-tools">
                                        <el-button type="primary">同意</el-button>
                                        <el-button type="danger">驳回</el-button>
                                        <el-button>回退</el-button>
                                        <el-button>转交</el-button>
                                    </div>
                                </div>
                            </div>


                        </el-tab-pane>
                        <el-tab-pane label="流程记录">
                            <div>
                                <table width="100%" class="setup-handle-record">
                                    <tbody>
                                        <tr>
                                            <td width="80px">
                                                <span>1</span>
                                            </td>
                                            <td>
                                                原辅料确认
                                            </td>
                                            <td width="160px">
                                                张三（项目部）
                                            </td>
                                            <td width="160px">
                                                2026-10-01 10:00
                                            </td>
                                            <td width="160px">
                                                <el-button type="success" plain round>已完成</el-button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="80px">
                                                <span>2</span>
                                            </td>
                                            <td>
                                                原辅料确认
                                            </td>
                                            <td width="160px">
                                                张三（项目部）
                                            </td>
                                            <td width="160px">
                                                2026-10-01 10:00
                                            </td>
                                            <td width="160px">
                                                <el-button type="success" plain round>已完成</el-button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="80px">
                                                <span>3</span>
                                            </td>
                                            <td>
                                                原辅料确认
                                            </td>
                                            <td width="160px">
                                                张三（项目部）
                                            </td>
                                            <td width="160px">
                                                2026-10-01 10:00
                                            </td>
                                            <td width="160px">
                                                <el-button type="success" plain round>已完成</el-button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="80px">
                                                <span>4</span>
                                            </td>
                                            <td>
                                                原辅料确认
                                            </td>
                                            <td width="160px">
                                                张三（项目部）
                                            </td>
                                            <td width="160px">
                                                2026-10-01 10:00
                                            </td>
                                            <td width="160px">
                                                <el-button type="success" plain round>已完成</el-button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
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
import { Back, Bell, Clock, Delete, Loading, More, Operation, Position, Right, Switch } from '@element-plus/icons-vue';
import { MoreFilled } from '@element-plus/icons-vue'
import type { TimelineItemProps } from 'element-plus'
import { workflowNodeFormService, workflowTaskService } from '@/api/pm';
import { onMounted, ref } from 'vue';
import { getQueryByName } from '@/utils/pcRouter';
import PageFormEnhanced from '@/components/PageForm/PageFormEnhanced.vue';
import { ElMessage } from 'element-plus';
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
const nodeId = getQueryByName('nodeId');
const taskId = getQueryByName('taskId');


const approvalOpinion = ref('');
const startFormRef = ref()
const startFormData = ref<ReleaseData>({ form: [], attrData: {} });
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
         ElMessage({ message: '操作成功', type: 'success', plain: true });
    }
}
onMounted(async () => {
    const formRes = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
        String(getQueryByName('workflowDefinitionId')),
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