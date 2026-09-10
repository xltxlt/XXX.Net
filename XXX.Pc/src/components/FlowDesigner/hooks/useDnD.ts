import { useVueFlow, type Node } from '@vue-flow/core'
import { ref, watch } from 'vue'
import { defaultNodeData, FLOW_ID } from '../config'
import type { WorkflowNodeType } from '../types'

let seq = 0

/**
 * 生成唯一 id（自增计数器避免同毫秒碰撞）
 */
function getId(type: string) {
  seq += 1
  return `${type}_${Date.now()}_${seq}`
}

const state = {
  draggedType: ref<WorkflowNodeType | null>(null),
  isDragOver: ref(false),
  isDragging: ref(false),
  draggedItem: ref<any>(),
}

export default function useDragAndDrop() {
  const { draggedType, isDragOver, isDragging, draggedItem } = state

  const { addNodes, screenToFlowCoordinate, onNodesInitialized, updateNode } = useVueFlow(FLOW_ID)

  watch(isDragging, (dragging) => {
    document.body.style.userSelect = dragging ? 'none' : ''
  })

  function onDragStart(event: DragEvent, item: any) {
    if (event.dataTransfer) {
      event.dataTransfer.setData('application/vueflow', item.type)
      event.dataTransfer.effectAllowed = 'move'
    }
    draggedItem.value = item
    draggedType.value = item.type
    isDragging.value = true

    document.addEventListener('drop', onDragEnd)
  }

  function onDragOver(event: DragEvent) {
    event.preventDefault()

    if (draggedType.value) {
      isDragOver.value = true

      if (event.dataTransfer) {
        event.dataTransfer.dropEffect = 'move'
      }
    }
  }

  function onDragLeave() {
    isDragOver.value = false
  }

  function onDragEnd() {
    isDragging.value = false
    isDragOver.value = false
    draggedType.value = null
    document.removeEventListener('drop', onDragEnd)
  }

  function onDrop(event: DragEvent) {
    if (!draggedType.value) return

    const position = screenToFlowCoordinate({
      x: event.clientX,
      y: event.clientY,
    })

    const nodeId = getId(draggedType.value)
    const newNode: Node = {
      id: nodeId,
      type: draggedType.value,
      position,
      data: defaultNodeData(draggedType.value),
    }

    if (draggedType.value === 'parent') {
      newNode.style = { width: '280px', height: '200px' }
    }

    // 拖入「父流程」节点容器时（整个容器区域，含标题栏与空白区），作为子节点
    const target = event.target as HTMLElement | null
    const parentEl = target?.closest<HTMLElement>('.vue-flow__node-parent')
    if (parentEl) {
      event.stopPropagation()
      const pId = parentEl.getAttribute('data-id')
      if (pId) {
        newNode.parentNode = pId
        newNode.expandParent = true
      }
    }

    // 落点后按节点中心对齐鼠标
    const { off } = onNodesInitialized(() => {
      if (parentEl) {
        const matrix = new DOMMatrix(getComputedStyle(parentEl).transform);
        updateNode(nodeId, (node) => ({
          position: {
            x: node.position.x-(matrix?.e??0) - (node.dimensions?.width ?? 0) / 2,
            y: node.position.y-(matrix?.f??0) - (node.dimensions?.height ?? 0) / 2,
          },
        }))
      }
      else {
        updateNode(nodeId, (node) => ({
          position: {
            x: node.position.x - (node.dimensions?.width ?? 0) / 2,
            y: node.position.y - (node.dimensions?.height ?? 0) / 2,
          },
        }))
      }


      off()
    })
    addNodes(newNode)
  }

  const getBaseNode = (event: DragEvent) => {
    const target = event.target as HTMLElement
    return target.closest<HTMLElement>('.base-node')
  }

  return {
    draggedType,
    isDragOver,
    isDragging,
    onDragStart,
    onDragLeave,
    onDragOver,
    onDrop,
    getBaseNode,
  }
}
