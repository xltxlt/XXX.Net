<template>
  <div class="comment-container">
    <div class="comment-header">
      <span>评论</span>
      <span class="comment-count">{{ comments.length }}</span>
    </div>

    <div class="comment-list">
      <div v-for="item in comments" :key="item.id" class="comment-item">
        <el-avatar :size="30" :src="item.avatar">
          {{ item.userName?.substring(0, 1) }}
        </el-avatar>

        <div class="comment-content">
          <div class="comment-top">
            <span class="user-name">{{ item.userName }}</span>
            <span class="comment-time">{{ item.createTime }}</span>
          </div>

          <div class="comment-text">
            {{ item.content }}
          </div>

          <div class="comment-actions">
            <span @click="reply(item)">回复</span>
            <span v-if="item.userId === currentUserId" @click="removeComment(item)">
              删除
            </span>
          </div>

          <!-- 回复 -->
          <div v-if="item.children?.length" class="reply-list">
            <div v-for="replyItem in item.children" :key="replyItem.id" class="reply-item">
              <el-avatar :size="30">
                {{ replyItem.userName?.substring(0, 1) }}
              </el-avatar>

              <div class="reply-content">
                <div class="reply-content-user">
                  <span class="user-name">
                    {{ replyItem.userName }}
                  </span>
                  <span class="comment-time">
                    {{ replyItem.createTime }}
                  </span>
                </div>

                <div class="comment-text">
                  {{ replyItem.content }}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <el-empty v-if="!comments.length" description="暂无评论" />
    </div>

    <!-- 发表评论 -->
    <div class="comment-editor">
      <el-avatar :size="30">
        {{ currentUserName.substring(0, 1) }}
      </el-avatar>

      <div class="editor-content">
        <el-input v-model="commentContent" type="textarea" :rows="3" maxlength="500" show-word-limit
          placeholder="请输入评论内容" />

        <div class="editor-footer">
          <el-button type="primary" :loading="submitLoading" :disabled="!commentContent.trim()" @click="submitComment">
            发表评论
          </el-button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { ElMessage, ElMessageBox } from 'element-plus'

interface CommentItem {
  id: number
  userId: number
  userName: string
  avatar?: string
  content: string
  createTime: string
  children?: CommentItem[]
}

const currentUserId = 10001
const currentUserName = '张三'

const commentContent = ref('')
const submitLoading = ref(false)

const comments = ref<CommentItem[]>([
  {
    id: 1,
    userId: 10002,
    userName: '李四',
    content: '项目需求已经确认，可以进入开发阶段。',
    createTime: '2026-10-06 09:32',
    children: [
      {
        id: 11,
        userId: 10001,
        userName: '张三',
        content: '好的，我这边马上处理。',
        createTime: '2026-10-06 09:45'
      }
    ]
  },
  {
    id: 2,
    userId: 10003,
    userName: '王五',
    content: '接口部分已经联调完成。',
    createTime: '2026-10-06 10:15'
  }
])

const submitComment = async () => {
  const content = commentContent.value.trim()

  if (!content) {
    ElMessage.warning('请输入评论内容')
    return
  }

  submitLoading.value = true

  try {
    // TODO: 调用后端接口
    // await addComment({
    //   businessId: props.businessId,
    //   content
    // })

    comments.value.unshift({
      id: Date.now(),
      userId: currentUserId,
      userName: currentUserName,
      content,
      createTime: formatDate(new Date())
    })

    commentContent.value = ''

    ElMessage.success('评论成功')
  } finally {
    submitLoading.value = false
  }
}

const reply = (item: CommentItem) => {
  console.log('回复', item)
  
}

const removeComment = async (item: CommentItem) => {
  await ElMessageBox.confirm(
    '确定删除这条评论吗？',
    '提示',
    {
      type: 'warning'
    }
  )

  comments.value = comments.value.filter(
    x => x.id !== item.id
  )

  ElMessage.success('删除成功')
}

const formatDate = (date: Date) => {
  const pad = (n: number) => String(n).padStart(2, '0')

  return `${date.getFullYear()}-${pad(date.getMonth() + 1)
    }-${pad(date.getDate())} ${pad(date.getHours())
    }:${pad(date.getMinutes())}`
}
</script>

<style scoped>
.comment-container {
  background: #fff;
  border-radius: 8px;
  padding: 20px;
}

.comment-header {
  display: flex;
  align-items: center;
  gap: 8px;
  padding-bottom: 16px;
  border-bottom: 1px solid #ebeef5;
  font-size: 16px;
  font-weight: 600;
}

.comment-count {
  color: #909399;
  font-size: 13px;
  font-weight: normal;
}

.comment-list {
  padding: 8px 0;
}

.comment-item {
  display: flex;
  gap: 12px;
  padding: 18px 0;
}

.comment-content {
  flex: 1;
  min-width: 0;
}

.comment-top {
  display: flex;
  align-items: center;
  gap: 12px;
}

.user-name {
  color: #303133;
  font-size: 14px;
  font-weight: 600;
}

.comment-time {
  color: #909399;
  font-size: 12px;
}

.comment-text {
  margin-top: 8px;
  color: #606266;
  font-size: 14px;
  line-height: 1.7;
  word-break: break-all;
  text-align: left;
}

.comment-actions {
  display: flex;
  gap: 16px;
  margin-top: 8px;
}

.comment-actions span {
  color: #909399;
  font-size: 12px;
  cursor: pointer;
}

.comment-actions span:hover {
  color: var(--el-color-primary);
}

.reply-list {
  margin-top: 14px;
  padding: 12px 16px;
  background: #f7f8fa;
  border-radius: 6px;
}

.reply-item {
  display: flex;
  gap: 10px;
  padding: 8px 0;
}

.reply-content {
  flex: 1;
}

.comment-editor {
  display: flex;
  gap: 12px;
  padding-top: 20px;
  border-top: 1px solid #ebeef5;
}

.editor-content {
  flex: 1;
}

.editor-footer {
  display: flex;
  justify-content: flex-end;
  margin-top: 10px;
}
.reply-content-user{
  display: flex;
  align-items: center;
  gap: 12px;
}
.user-name {
  margin-right: 15px;
}
</style>