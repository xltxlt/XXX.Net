<template>
  <div class="base-node" @drop.stop="onDropT" @dragover.prevent="onDragOver" :class="[`node-${type}`, { selected }]"
    :style="{ borderColor: data.color || '#409eff' }" :data-node-type="type" :data-id="id">
    <div class="node-header" :style="{ background: data.color || '#409eff' }">
      <span class="node-icon">{{ data.icon || '●' }}</span>
      <span class="node-label">{{ data.label }}</span>
    </div>
    <div class="node-body">
      <slot />
    </div>

    <!-- 连接点 -->
    <Handle v-for="h in resolvedHandles" :key="`${h.position}-${h.type}`" :type="h.type"
      :style="['background: ' + (h.type === 'target' ? '#409eff': (h.bgColor??'#67C23A')+' !important' ) + ';']"
      :position="positionMap[h.position]" :id="h.id"   >
      <span v-if="h.title" style="color: #333;position: relative;left: 0px;top: 10px;font-size: 12px;">
        {{ h.title }}
      </span>
    </Handle>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { Handle, Position, useNode, type Position as PositionType } from '@vue-flow/core'
import useDragAndDrop from '../hooks/useDnD'

const { onDragOver, onDrop, getBaseNode } = useDragAndDrop()

const onDropT = (e: DragEvent) => {
  const baseNode = getBaseNode(e)
  if (!baseNode) return
  onDrop(e)
}

/** 单个连接点配置 */
interface HandleConfig {
  position: 'top' | 'bottom' | 'left' | 'right'
  /** 缺省时按 position 推断：top 为 target，其余为 source */
  type?: 'source' | 'target'
  /** 连接点 id（条件节点多出口时用于区分） */
  id?: string
  title?: string
  bgColor?: string,
}

const props = defineProps<{
  type: string
  data: Record<string, any>
  selected?: boolean
  /** 声明式连接点配置，优先于下方的布尔快捷 prop */
  handles?: HandleConfig[]
  bottomHandle?: boolean
  topHandle?: boolean
  leftHandle?: boolean
  rightHandle?: boolean
}>()

const positionMap: Record<HandleConfig['position'], PositionType> = {
  top: Position.Top,
  bottom: Position.Bottom,
  left: Position.Left,
  right: Position.Right,
}

// 缺省连接点方向：top 为入点，其余为出点
const inferType = (position: HandleConfig['position']): 'source' | 'target' =>
  position === 'top' ? 'target' : 'source'

const resolvedHandles = computed<HandleConfig[]>(() => {
  if (props.handles && props.handles.length) {
    return props.handles.map((h) => ({ type: inferType(h.position), id: h.position, ...h }))
  }
  const positions: HandleConfig['position'][] = []
  if (props.topHandle) positions.push('top')
  if (props.bottomHandle) positions.push('bottom')
  if (props.leftHandle) positions.push('left')
  if (props.rightHandle) positions.push('right')
  return positions.map((position) => ({ position, type: inferType(position), id: position }))
})

const { id } = useNode()
</script>

<style lang="less" scoped>
.base-node {
  min-width: 140px;
  border-radius: 8px;
  border: 2px solid #409eff;
  background: #fff;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.08);
  overflow: hidden;
  transition: box-shadow 0.2s, transform 0.2s;

  &.selected {
    box-shadow: 0 0 0 2px #67c23a, 0 4px 16px rgba(0, 0, 0, 0.15);
    transform: scale(1.02);
  }

  .node-header {
    display: flex;
    align-items: center;
    gap: 6px;
    padding: 6px 10px;
    color: #fff;
    font-size: 12px;
    font-weight: 600;

    .node-icon {
      font-size: 14px;
    }

    .node-label {
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
    }
  }

  .node-body {
    padding: 8px 10px;
    font-size: 11px;
    color: #666;
    min-height: 20px;
  }
}

.node-start {
  .node-header {
    background: #67c23a !important;
  }
}

.node-end {
  .node-header {
    background: #f56c6c !important;
  }
}

.node-condition {
  .node-header {
    background: #e6a23c !important;
  }
}

.node-approval {
  .node-header {
    background: #9c27b0 !important;
  }
}

.node-parent {
  width: 100%;
  background: transparent;
  border: none;
  box-shadow: none;

  .node-header {
    background: #13c2c2 !important;
  }
}

.node-parallel {
  .node-header {
    background: #409eff !important;
  }
}

.node-delay {
  .node-header {
    background: #909399 !important;
  }
}

.node-notification {
  .node-header {
    background: #67c23a !important;
  }
}

.node-service {
  .node-header {
    background: #e6a23c !important;
  }
}
</style>
