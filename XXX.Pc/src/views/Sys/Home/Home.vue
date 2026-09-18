<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import { ArrowRight, Bell, Calendar, Check, Clock, DocumentChecked, Files, TrendCharts } from '@element-plus/icons-vue'
import { workflowTaskService } from '@/api/pm.ts'

interface TodoItem {
  id?: string
  nodeName?: string
  workflowId?: string
  workflowDefinitionId?: string
  instanceId?: string
  dueTime?: string
  status?: string
}

interface NoticeItem {
  id: number
  title: string
  summary: string
  time: string
  type: 'notice' | 'system' | 'holiday'
  unread?: boolean
}

const loading = ref(false)
const activeTodoTab = ref<'all' | 'workflow' | 'approval'>('all')
const todoList = ref<TodoItem[]>([])

const notices = ref<NoticeItem[]>([
  {
    id: 1,
    title: '关于国庆节前安全检查的通知',
    summary: '各部门请做好节前安全检查及相关工作安排，确保假期期间公司运行平稳。',
    time: '09-18 09:20',
    type: 'notice',
    unread: true,
  },
  {
    id: 2,
    title: '系统升级维护通知',
    summary: '系统将于 9 月 20 日 20:00—22:00 进行升级维护，期间部分功能可能暂时不可用。',
    time: '09-17 16:35',
    type: 'system',
    unread: true,
  },
  {
    id: 3,
    title: '关于调整考勤制度的通知',
    summary: '为进一步规范考勤管理，现对考勤制度进行调整，请各部门及时了解相关内容。',
    time: '09-16 14:12',
    type: 'notice',
  },
  {
    id: 4,
    title: '中秋节放假安排通知',
    summary: '根据国务院办公厅通知，现将 2026 年中秋节放假安排通知如下。',
    time: '09-15 10:28',
    type: 'holiday',
  },
  {
    id: 5,
    title: '关于开展员工培训的通知',
    summary: '为提升员工专业技能，公司将于 9 月 25 日组织开展业务培训。',
    time: '09-14 09:17',
    type: 'notice',
  },
])

const filteredTodos = computed(() => {
  if (activeTodoTab.value === 'all') return todoList.value
  return todoList.value.filter(item => {
    const text = `${item.nodeName ?? ''}${item.workflowId ?? ''}`
    const isApproval = /审批|审核|申请|请示|报销|请假/.test(text)
    return activeTodoTab.value === 'approval' ? isApproval : !isApproval
  })
})

const workflowCount = computed(() =>
  todoList.value.filter(item => !/审批|审核|申请|请示|报销|请假/.test(`${item.nodeName ?? ''}${item.workflowId ?? ''}`)).length
)

const approvalCount = computed(() =>
  todoList.value.filter(item => /审批|审核|申请|请示|报销|请假/.test(`${item.nodeName ?? ''}${item.workflowId ?? ''}`)).length
)

const noticeCount = computed(() => notices.value.filter(item => item.unread).length)

const todayText = computed(() => {
  const date = new Date()
  const week = ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六']
  return `${date.getFullYear()}年${date.getMonth() + 1}月${date.getDate()}日 · ${week[date.getDay()]}`
})

const formatTime = (value?: string) => {
  if (!value) return '--'
  const date = new Date(value)
  if (Number.isNaN(date.getTime())) return value
  return date.toLocaleString('zh-CN', { hour12: false }).replace(/\//g, '-').slice(0, 16)
}

const todoTitle = (item: TodoItem) => item.nodeName || item.workflowId || '待处理事项'

const todoType = (item: TodoItem) => {
  const text = `${item.nodeName ?? ''}${item.workflowId ?? ''}`
  return /审批|审核|申请|请示|报销|请假/.test(text) ? '审批流' : '工作流'
}

const loadTodos = async () => {
  loading.value = true
  try {
    const res = await workflowTaskService.apiWorkflowTaskTodoListGet()
    todoList.value = (res.data?.data ?? []) as TodoItem[]
  } catch (e: any) {
    todoList.value = []
    ElMessage.error(e?.message ?? '待办事项加载失败')
  } finally {
    loading.value = false
  }
}

const navigate = (path: string) => {
  window.location.hash = `#${path}`
}

const openTodo = (item?: TodoItem) => {
  }
  navigate('/workflow/todo')
}

const openNotices = () => {
  ElMessage.info('工作通知中心可在后续接入通知列表接口')
}

const markNoticeRead = (item: NoticeItem) => {
  item.unread = false
}

onMounted(loadTodos)
</script>

<template>
  <div class="sys-home">
    <section class="welcome-card">
      <div class="welcome-decoration decoration-one"></div>
      <div class="welcome-decoration decoration-two"></div>

      <div class="welcome-main">
        <div class="welcome-icon">
          <DocumentChecked />
        </div>
        <div>
          <div class="welcome-title">您好，欢迎回来！</div>
          <div class="welcome-subtitle">高效协同 · 规范流程 · 让工作更简单</div>
        </div>
      </div>

      <div class="welcome-date">
        <Calendar />
        <span>{{ todayText }}</span>
      </div>
    </section>

    <section class="summary-grid">
      <button class="summary-card summary-blue" @click="activeTodoTab = 'workflow'">
        <div class="summary-icon"><Files /></div>
        <div class="summary-copy">
          <span>待办工作流</span>
          <strong>{{ workflowCount }}</strong>
          <small>项待处理</small>
        </div>
        <ArrowRight class="summary-arrow" />
      </button>

      <button class="summary-card summary-green" @click="activeTodoTab = 'approval'">
        <div class="summary-icon"><Check /></div>
        <div class="summary-copy">
          <span>待办审批流</span>
          <strong>{{ approvalCount }}</strong>
          <small>项待审批</small>
        </div>
        <ArrowRight class="summary-arrow" />
      </button>

      <button class="summary-card summary-orange" @click="openNotices">
        <div class="summary-icon"><Bell /></div>
        <div class="summary-copy">
          <span>工作通知</span>
          <strong>{{ noticeCount }}</strong>
          <small>条未读消息</small>
        </div>
        <ArrowRight class="summary-arrow" />
      </button>

      <div class="summary-card summary-indigo">
        <div class="summary-icon"><TrendCharts /></div>
        <div class="summary-copy">
          <span>今日已办</span>
          <strong>12</strong>
          <small>项已完成</small>
        </div>
        <ArrowRight class="summary-arrow" />
      </div>
    </section>

    <section class="content-grid">
      <div class="panel todo-panel">
        <div class="panel-header">
          <div class="panel-title">
            <span class="title-icon title-icon-blue"><Files /></span>
            <div>
              <h2>待办事项</h2>
              <p>需要您及时处理的工作</p>
            </div>
          </div>
          <button class="more-button" @click="openTodo()">全部待办 <ArrowRight /></button>
        </div>

        <div class="todo-tabs">
          <button :class="{ active: activeTodoTab === 'all' }" @click="activeTodoTab = 'all'">
            全部 <b>{{ todoList.length }}</b>
          </button>
          <button :class="{ active: activeTodoTab === 'workflow' }" @click="activeTodoTab = 'workflow'">
            工作流 <b>{{ workflowCount }}</b>
          </button>
          <button :class="{ active: activeTodoTab === 'approval' }" @click="activeTodoTab = 'approval'">
            审批流 <b>{{ approvalCount }}</b>
          </button>
        </div>

        <div class="todo-list" v-loading="loading">
          <div v-if="!loading && filteredTodos.length === 0" class="empty-state">
            <div class="empty-icon"><Check /></div>
            <strong>暂无待办事项</strong>
            <span>当前没有需要处理的流程</span>
          </div>

          <button
            v-for="item in filteredTodos.slice(0, 6)"
            :key="item.id || item.instanceId"
            class="todo-row"
            @click="openTodo(item)"
          >
            <span class="todo-tag" :class="todoType(item) === '审批流' ? 'approval' : 'workflow'">
              {{ todoType(item) }}
            </span>
            <span class="todo-name" :title="todoTitle(item)">{{ todoTitle(item) }}</span>
            <span class="todo-instance">{{ item.instanceId || '—' }}</span>
            <span class="todo-time">
              <Clock />
              {{ formatTime(item.dueTime) }}
            </span>
            <span class="todo-action">处理 <ArrowRight /></span>
          </button>
        </div>
      </div>

      <div class="panel notice-panel">
        <div class="panel-header">
          <div class="panel-title">
            <span class="title-icon title-icon-orange"><Bell /></span>
            <div>
              <h2>工作通知</h2>
              <p>及时掌握公司最新动态</p>
            </div>
          </div>
          <button class="more-button" @click="openNotices">全部通知 <ArrowRight /></button>
        </div>

        <div class="notice-list">
          <button
            v-for="item in notices"
            :key="item.id"
            class="notice-row"
            @click="markNoticeRead(item)"
          >
            <span class="notice-dot" :class="item.type"></span>
            <span class="notice-body">
              <span class="notice-title">{{ item.title }}</span>
              <span class="notice-summary">{{ item.summary }}</span>
            </span>
            <span class="notice-meta">
              <span>{{ item.time }}</span>
              <i v-if="item.unread">新</i>
            </span>
          </button>
        </div>
      </div>
    </section>

    <section class="quick-panel">
      <div class="quick-title">
        <span class="title-icon title-icon-purple"><TrendCharts /></span>
        <div>
          <h2>快捷入口</h2>
          <p>快速进入常用工作模块</p>
        </div>
      </div>
      <div class="quick-links">
        <button @click="navigate('/workflow/todo')">
          <Files />
          <span>待办中心</span>
          <small>查看并处理待办</small>
        </button>
        <button @click="navigate('/workflow/todo')">
          <DocumentChecked />
          <span>流程管理</span>
          <small>查看流程与实例</small>
        </button>
        <button @click="navigate('/sys/menu')">
          <TrendCharts />
          <span>系统设置</span>
          <small>管理系统基础配置</small>
        </button>
        <button @click="openNotices">
          <Bell />
          <span>通知中心</span>
          <small>查看工作通知</small>
        </button>
      </div>
    </section>
  </div>
</template>

<style scoped lang="less">
.sys-home {
  min-height: 100%;
  box-sizing: border-box;
  padding: 18px 20px 28px;
  background:
    radial-gradient(circle at 92% 8%, rgba(42, 144, 255, .055), transparent 24%),
    linear-gradient(180deg, #f7faff 0%, #f4f7fb 100%);
  color: #1d2939;
  text-align: left;
}

button {
  font-family: inherit;
  border: 0;
  margin: 0;
  padding: 0;
  background: none;
  color: inherit;
}

.welcome-card {
  height: 138px;
  position: relative;
  overflow: hidden;
  display: flex;
  align-items: center;
  justify-content: space-between;
  box-sizing: border-box;
  padding: 0 34px;
  border: 1px solid #e3edf8;
  border-radius: 14px;
  background: linear-gradient(110deg, #eaf4ff 0%, #f7fbff 58%, #ffffff 100%);
  box-shadow: 0 5px 18px rgba(28, 78, 121, .045);
}

.welcome-card::after {
  content: '';
  position: absolute;
  right: 22%;
  bottom: -105px;
  width: 310px;
  height: 190px;
  border-radius: 50%;
  background: rgba(74, 154, 238, .055);
}

.welcome-decoration {
  position: absolute;
  border: 1px solid rgba(45, 141, 232, .10);
  border-radius: 50%;
  pointer-events: none;
}
.decoration-one { width: 210px; height: 210px; right: -56px; top: -130px; }
.decoration-two { width: 155px; height: 155px; right: 80px; bottom: -120px; }

.welcome-main, .welcome-date { position: relative; z-index: 2; display: flex; align-items: center; }
.welcome-main { gap: 18px; }
.welcome-icon {
  width: 62px;
  height: 62px;
  display: grid;
  place-items: center;
  border-radius: 16px;
  color: #fff;
  font-size: 31px;
  background: linear-gradient(145deg, #318fe9, #1672d8);
  box-shadow: 0 9px 22px rgba(29, 126, 221, .19);
}
.welcome-title { font-size: 25px; line-height: 1.25; font-weight: 650; letter-spacing: .2px; color: #13283d; }
.welcome-subtitle { margin-top: 8px; font-size: 14px; color: #7290aa; }
.welcome-date { gap: 8px; padding: 10px 15px; border: 1px solid #dce9f5; border-radius: 9px; background: rgba(255,255,255,.68); color: #6d849a; font-size: 13px; }

.summary-grid {
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 14px;
  margin-top: 14px;
}
.summary-card {
  min-height: 112px;
  position: relative;
  overflow: hidden;
  display: flex;
  align-items: center;
  padding: 20px 20px;
  box-sizing: border-box;
  text-align: left;
  border: 1px solid #e7edf5;
  border-radius: 12px;
  background: #fff;
  box-shadow: 0 4px 14px rgba(26, 62, 97, .035);
  cursor: pointer;
  transition: transform .18s ease, box-shadow .18s ease, border-color .18s ease;
}
.summary-card:hover { transform: translateY(-2px); box-shadow: 0 9px 24px rgba(26, 62, 97, .09); border-color: #d5e4f3; }
.summary-icon { width: 50px; height: 50px; flex: 0 0 50px; display: grid; place-items: center; border-radius: 13px; font-size: 23px; }
.summary-blue .summary-icon { color: #2489e8; background: #e9f4ff; }
.summary-green .summary-icon { color: #20b889; background: #e9faf5; }
.summary-orange .summary-icon { color: #f39a26; background: #fff4e3; }
.summary-indigo .summary-icon { color: #636be9; background: #eff0ff; }
.summary-copy { display: flex; flex-direction: column; margin-left: 14px; min-width: 0; }
.summary-copy span { color: #60788e; font-size: 14px; }
.summary-copy strong { margin-top: 4px; color: #172d43; font-size: 27px; line-height: 1; font-weight: 650; }
.summary-copy small { margin-top: 5px; color: #a2b0bc; font-size: 11px; }
.summary-arrow { position: absolute; right: 14px; top: 50%; transform: translateY(-50%); color: #9eb2c3; width: 15px; }

.content-grid { display: grid; grid-template-columns: minmax(0, 1.38fr) minmax(400px, .92fr); gap: 14px; margin-top: 14px; }
.panel, .quick-panel {
  border: 1px solid #e4ebf3;
  border-radius: 12px;
  background: #fff;
  box-shadow: 0 4px 15px rgba(26, 62, 97, .035);
}
.panel { min-width: 0; }
.todo-panel, .notice-panel { min-height: 438px; }
.panel-header { height: 79px; display: flex; align-items: center; justify-content: space-between; padding: 0 22px; box-sizing: border-box; border-bottom: 1px solid #eef2f6; }
.panel-title { display: flex; align-items: center; gap: 11px; }
.title-icon { width: 36px; height: 36px; display: grid; place-items: center; border-radius: 9px; font-size: 18px; }
.title-icon-blue { color: #258be9; background: #eaf5ff; }
.title-icon-orange { color: #f19a28; background: #fff4e4; }
.title-icon-purple { color: #6a6eea; background: #f0f0ff; }
.panel-title h2, .quick-title h2 { margin: 0; font-size: 17px; line-height: 1.2; color: #182d43; font-weight: 650; }
.panel-title p, .quick-title p { margin: 4px 0 0; color: #9aaaba; font-size: 11px; }
.more-button { display: flex; align-items: center; gap: 3px; color: #2389e6; font-size: 12px; cursor: pointer; }
.more-button svg { width: 13px; }

.todo-tabs { height: 52px; display: flex; align-items: end; gap: 5px; padding: 0 21px; border-bottom: 1px solid #f0f3f6; box-sizing: border-box; }
.todo-tabs button { height: 38px; padding: 0 17px; color: #778a9d; font-size: 13px; border-radius: 7px 7px 0 0; cursor: pointer; }
.todo-tabs button b { margin-left: 4px; font-weight: 500; color: #a8b5c0; }
.todo-tabs button.active { color: #167dd8; background: #edf7ff; font-weight: 600; }
.todo-tabs button.active b { color: #167dd8; }

.todo-list { min-height: 305px; }
.todo-row {
  width: 100%;
  height: 58px;
  display: grid;
  grid-template-columns: 72px minmax(180px, 1.35fr) minmax(110px, .75fr) 128px 58px;
  align-items: center;
  gap: 10px;
  padding: 0 20px;
  box-sizing: border-box;
  border-bottom: 1px solid #f0f3f6;
  text-align: left;
  cursor: pointer;
  transition: background .15s;
}
.todo-row:hover { background: #f8fbfe; }
.todo-tag { width: max-content; min-width: 54px; padding: 4px 8px; border-radius: 5px; text-align: center; font-size: 11px; }
.todo-tag.workflow { color: #2d91df; background: #eaf5ff; }
.todo-tag.approval { color: #17aa80; background: #e9faf4; }
.todo-name { overflow: hidden; white-space: nowrap; text-overflow: ellipsis; color: #354b60; font-size: 13px; }
.todo-instance { overflow: hidden; white-space: nowrap; text-overflow: ellipsis; color: #9aaaba; font-size: 12px; }
.todo-time { display: flex; align-items: center; gap: 4px; color: #92a3b2; font-size: 11px; white-space: nowrap; }
.todo-time svg { width: 13px; }
.todo-action { display: flex; justify-content: flex-end; align-items: center; gap: 2px; color: #248be8; font-size: 12px; }
.todo-action svg { width: 13px; }

.empty-state { height: 300px; display: flex; flex-direction: column; justify-content: center; align-items: center; color: #9aaaba; }
.empty-icon { width: 48px; height: 48px; display: grid; place-items: center; margin-bottom: 11px; border-radius: 50%; color: #43b993; background: #eaf9f4; font-size: 21px; }
.empty-state strong { color: #647a8d; font-size: 14px; font-weight: 600; }
.empty-state span { margin-top: 5px; font-size: 11px; }

.notice-list { padding: 0 20px; }
.notice-row { width: 100%; min-height: 70px; display: grid; grid-template-columns: 10px minmax(0, 1fr) 82px; align-items: center; gap: 10px; border-bottom: 1px solid #f0f3f6; text-align: left; cursor: pointer; }
.notice-row:last-child { border-bottom: 0; }
.notice-dot { width: 6px; height: 6px; border-radius: 50%; background: #298ee8; }
.notice-dot.system { background: #f0a034; }
.notice-dot.holiday { background: #6f73e7; }
.notice-body { min-width: 0; display: flex; flex-direction: column; }
.notice-title { overflow: hidden; text-overflow: ellipsis; white-space: nowrap; color: #31485d; font-size: 13px; font-weight: 550; }
.notice-summary { margin-top: 5px; overflow: hidden; text-overflow: ellipsis; white-space: nowrap; color: #9aaaba; font-size: 11px; }
.notice-meta { display: flex; align-items: center; justify-content: flex-end; gap: 8px; color: #9eacb9; font-size: 10px; white-space: nowrap; }
.notice-meta i { padding: 2px 5px; border-radius: 4px; color: #fff; background: #f45d67; font-size: 9px; font-style: normal; }

.quick-panel { margin-top: 14px; padding: 19px 22px 22px; }
.quick-title { display: flex; align-items: center; gap: 11px; }
.quick-links { display: grid; grid-template-columns: repeat(4, minmax(0, 1fr)); gap: 10px; margin-top: 16px; }
.quick-links button { min-height: 72px; display: grid; grid-template-columns: 34px 1fr; grid-template-rows: 24px 20px; column-gap: 10px; align-items: center; padding: 12px 14px; box-sizing: border-box; border: 1px solid #edf1f5; border-radius: 9px; text-align: left; cursor: pointer; transition: all .15s; }
.quick-links button:hover { border-color: #d7e8f7; background: #f8fbfe; }
.quick-links button > svg { grid-row: 1 / 3; width: 22px; height: 22px; padding: 6px; box-sizing: content-box; border-radius: 8px; color: #278ce8; background: #eaf5ff; }
.quick-links button:nth-child(2) > svg { color: #21ae84; background: #eafaf5; }
.quick-links button:nth-child(3) > svg { color: #6b70e8; background: #f0f1ff; }
.quick-links button:nth-child(4) > svg { color: #ee9a2c; background: #fff4e5; }
.quick-links span { color: #3b5064; font-size: 13px; font-weight: 550; }
.quick-links small { color: #a0adba; font-size: 10px; }

@media (max-width: 1200px) {
  .summary-grid { grid-template-columns: repeat(2, minmax(0, 1fr)); }
  .content-grid { grid-template-columns: 1fr; }
  .quick-links { grid-template-columns: repeat(2, minmax(0, 1fr)); }
}

@media (max-width: 760px) {
  .sys-home { padding: 12px; }
  .welcome-card { height: auto; min-height: 130px; padding: 22px; }
  .welcome-date { display: none; }
  .summary-grid, .quick-links { grid-template-columns: 1fr; }
  .todo-row { grid-template-columns: 64px minmax(0, 1fr) 52px; }
  .todo-instance, .todo-time { display: none; }
}
</style>
