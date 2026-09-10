<template>
  <section class="page-form-designer">
    <header class="designer-header">
      <div>
        <h2>表单设计器</h2>
        <p>从左侧添加控件，在画布中选择控件后配置属性。导出的结构可直接作为 <code>PageForm</code> 的 <code>tempForm</code> 使用。</p>
      </div>
      <div class="designer-actions">
        <el-button @click="previewVisible = true">预览</el-button>
        <el-button @click="showJson">导出 JSON</el-button>
        <el-button type="danger" plain @click="resetDesigner">重置</el-button>
        <el-button @click="save">保存</el-button>
      </div>
    </header>

    <main class="designer-body">
      <aside class="designer-panel component-panel">
        <h3>组件库</h3>
        <p class="panel-tip">可拖拽控件到画布；选中分组后点击控件会添加到该分组。</p>
        <el-divider content-position="left">基础字段</el-divider>
        <el-button v-for="item in fieldPalette" :key="item.formType" class="palette-button" draggable="true"
          @dragstart="startPaletteDrag($event, item)" @click="addField(item)">
          {{ item.label }}
        </el-button>
        <el-divider content-position="left">布局</el-divider>
        <el-button class="palette-button" draggable="true" @dragstart="startPaletteDrag($event, groupPaletteItem)"
          @click="addGroup">分组</el-button>
        <el-button class="palette-button" draggable="true" @dragstart="startPaletteDrag($event, tablePaletteItem)"
          @click="addTable">表格分组</el-button>
        <el-button class="palette-button" draggable="true" @dragstart="startPaletteDrag($event, listPaletteItem)"
          @click="addList">列表分组</el-button>

      </aside>

      <section class="canvas-panel" @click.self="selectedId = ''" @dragover.prevent @drop="dropOnRoot">
        <div class="canvas-title">
          <strong>表单画布</strong>
          <el-radio-group v-model="form.cols" size="small">
            <el-radio-button :value="1">1 列</el-radio-button>
            <el-radio-button :value="2">2 列</el-radio-button>
            <el-radio-button :value="3">3 列</el-radio-button>
          </el-radio-group>
        </div>
        <div v-if="form.form.length === 0" class="empty-canvas">请从左侧添加字段或布局组件。</div>
        <div v-else class="canvas-items">
          <template v-for="item in form.form" :key="item.ident">
            <div v-if="isContainer(item)" class="canvas-group" :class="{ selected: selectedId === item.ident }"
              @click.stop="select(item)" @dragover.prevent @drop.stop="dropInContainer($event, item)">
              <div class="canvas-group-title">
                <span>{{ item.label || '未命名分组' }}</span>
                <small>{{ item.formType === PageFormGroup.Table ? '表格分组' : '分组' }}</small>
              </div>
              <div class="canvas-group-fields">
                <template v-for="child in containerFields(item)" :key="child.ident">
                  <FieldCard :item="child" :selected="selectedId === child.ident" @select="select"
                    @drag-start="startItemDrag" />
                </template>
                <span v-if="containerFields(item).length === 0" class="empty-group">请选择此分组后添加字段</span>
              </div>
            </div>
            <FieldCard v-else :item="item" :selected="selectedId === item.ident" @select="select"
              @drag-start="startItemDrag" />
          </template>
        </div>
      </section>

      <aside class="designer-panel property-panel">
        <h3>属性配置</h3>
        <template v-if="selectedItem">
          <el-form label-position="top" size="default">
            <el-form-item label="组件标题"><el-input v-model="selectedItem.label" placeholder="请输入标题" /></el-form-item>
            <el-form-item v-if="!isContainer(selectedItem)" label="字段名">
              <el-input v-model="selectedItem.fieldName" placeholder="例如 name" />
            </el-form-item>
            <el-form-item v-if="!isContainer(selectedItem)" label="占位提示">
              <el-input v-model="selectedItem.placeholder" placeholder="为空时自动生成" />
            </el-form-item>
            <el-form-item v-if="!isContainer(selectedItem)" label="必填"><el-switch
                v-model="selectedItem.must" /></el-form-item>
            <el-form-item v-if="isChoice(selectedItem)" label="选项（每行：标签,值）">
              <el-input v-model="selectedItem.optionText" type="textarea" :rows="5" placeholder="启用,1&#10;停用,0"
                @change="syncOptions(selectedItem)" />
            </el-form-item>
          </el-form>
          <div class="property-actions">
            <el-button :disabled="!canMove(-1)" @click="moveSelected(-1)">上移</el-button>
            <el-button :disabled="!canMove(1)" @click="moveSelected(1)">下移</el-button>
            <el-button type="danger" @click="removeSelected">删除</el-button>
          </div>
        </template>
        <el-empty v-else description="请选择画布中的组件" :image-size="88" />
      </aside>
    </main>

    <el-dialog v-model="previewVisible" title="表单预览" width="860px" destroy-on-close>
      <PageForm :temp-form="previewForm" />
    </el-dialog>
    <el-dialog v-model="jsonVisible" title="PageForm 配置" width="860px">
      <el-input v-model="jsonText" type="textarea" :rows="26" readonly />
    </el-dialog>
  </section>
</template>

<script setup lang="ts">
import { computed, defineComponent, h, onMounted, reactive, ref, type PropType } from 'vue'
import type { FormItemRule } from 'element-plus'
import PageForm from '@/components/PageForm/PageForm.vue'
import { PageFormGroup, PageFormType, type TempEditForm, type TempEditPageData } from '@/components/PageForm'
import { workflowNodeFormService } from '@/api/workflow';

const { nodeId, workflowDeginitionId } = defineProps<{ nodeId: string, workflowId: string, nodeType: string, workflowDeginitionId: string }>();

type DesignerItem = Omit<TempEditForm, 'child' | 'ident'> & { ident: string; child?: DesignerItem[]; must?: boolean; optionText?: string }
type PaletteItem = { label: string; formType: number; choice?: boolean }
var emits = defineEmits(['release'])
const fieldPalette: PaletteItem[] = [
  { label: '单行文本', formType: PageFormType.Input }, { label: '多行文本', formType: PageFormType.TextAreaInput },
  { label: '数字', formType: PageFormType.Number }, { label: '开关', formType: PageFormType.Switch },
  { label: '日期', formType: PageFormType.DateSelect }, { label: '日期时间', formType: PageFormType.DateTimeSelect },
  { label: '下拉选择', formType: PageFormType.OneSelectSearch, choice: true }, { label: '单选', formType: PageFormType.Radio, choice: true },
  { label: '多选', formType: PageFormType.MultSelect, choice: true },
]
const groupPaletteItem: PaletteItem = { label: '基础信息', formType: PageFormGroup.Group }
const tablePaletteItem: PaletteItem = { label: '明细信息', formType: PageFormGroup.Table }
const listPaletteItem: PaletteItem = { label: '明细信息', formType: PageFormGroup.List }


const FieldCard = defineComponent({
  props: { item: { type: Object as PropType<DesignerItem>, required: true }, selected: Boolean },
  emits: ['select', 'drag-start'],
  setup(props, { emit }) {
    return () => h('div', { class: ['field-card', { selected: props.selected }], draggable: true, onDragstart: (event: DragEvent) => emit('drag-start', event, props.item), onClick: (event: Event) => { event.stopPropagation(); emit('select', props.item) } }, [
      h('strong', props.item.label || '未命名字段'), h('span', props.item.fieldName || '请配置字段名'),
    ])
  },
})

const form = reactive({ cols: 2, form: [] as DesignerItem[] })
const selectedId = ref('')
const previewVisible = ref(false)
const jsonVisible = ref(false)
const jsonText = ref('')
const draggingPalette = ref<PaletteItem>()
const draggingItemId = ref('')
let id = 0
const nextId = () => `page-form-${Date.now()}-${++id}`
const isContainer = (item: DesignerItem) => [PageFormGroup.Group, PageFormGroup.Table, PageFormGroup.List].includes(item.formType)
const isChoice = (item: DesignerItem) => [PageFormType.OneSelect, PageFormType.OneSelectSearch, PageFormType.MultSelect, PageFormType.Radio, PageFormType.Checkbox].includes(item.formType)
const containerFields = (item: DesignerItem): DesignerItem[] => item.formType === PageFormGroup.Table || item.formType === PageFormGroup.List ? ((item.child?.[0]?.child ?? []) as DesignerItem[]) : ((item.child ?? []) as DesignerItem[])

const walk = (items: DesignerItem[], target: string): DesignerItem | undefined => {
  for (const item of items) { if (item.ident === target) return item; const found = walk((item.child ?? []) as DesignerItem[], target); if (found) return found }
}
const selectedItem = computed(() => selectedId.value ? walk(form.form, selectedId.value) : undefined)
const select = (item: DesignerItem) => { selectedId.value = item.ident }
const createField = (palette: PaletteItem): DesignerItem => {
  const base = palette.label.replace(/[^a-zA-Z]/g, '').toLowerCase() || 'field'
  return { ident: nextId(), formType: palette.formType, label: palette.label, fieldName: `${base}${id}`, must: false, optionText: palette.choice ? '选项一,option1\n选项二,option2' : '' }
}
const addField = (palette: PaletteItem) => {
  const item = createField(palette)
  const target = selectedItem.value
  if (target && isContainer(target)) containerFields(target).push(item)
  else form.form.push(item as never)
  select(item)
}
const addGroup = () => { const item: DesignerItem = { ident: nextId(), formType: PageFormGroup.Group, label: '基础信息', fieldName: '', child: [] }; form.form.push(item as never); select(item) }
const addTable = () => {
  const item: DesignerItem = { ident: nextId(), formType: PageFormGroup.Table, label: '明细信息', fieldName: `details${id}`, child: [{ ident: nextId(), formType: PageFormGroup.Group, label: '', fieldName: '', child: [] }] }
  form.form.push(item as never); select(item)
}
const addList = () => {
  const item: DesignerItem = { ident: nextId(), formType: PageFormGroup.List, label: '明细信息', fieldName: `list${id}`, child: [{ ident: nextId(), formType: PageFormGroup.Group, label: '', fieldName: '', child: [] }] }
  form.form.push(item as never); select(item)
}
const startPaletteDrag = (event: DragEvent, item: PaletteItem) => {
  draggingItemId.value = ''
  draggingPalette.value = item
  event.dataTransfer?.setData('text/plain', item.label)
  if (event.dataTransfer) event.dataTransfer.effectAllowed = 'copy'
}
const startItemDrag = (event: DragEvent, item: DesignerItem) => {
  draggingPalette.value = undefined
  draggingItemId.value = item.ident
  event.dataTransfer?.setData('text/plain', item.ident)
  if (event.dataTransfer) event.dataTransfer.effectAllowed = 'move'
}
const detachItem = (items: DesignerItem[], ident: string): DesignerItem | undefined => {
  const index = items.findIndex((item) => item.ident === ident)
  if (index >= 0) return items.splice(index, 1)[0]
  for (const item of items) { const detached = detachItem((item.child ?? []) as DesignerItem[], ident); if (detached) return detached }
}
const containsItem = (item: DesignerItem, ident: string): boolean => item.ident === ident || (item.child?.some((child) => containsItem(child, ident)) ?? false)
const takeDraggedItem = (): DesignerItem | undefined => {
  if (draggingPalette.value) {
    const palette = draggingPalette.value
    draggingPalette.value = undefined
    if (palette.formType === PageFormGroup.Group) return { ident: nextId(), formType: PageFormGroup.Group, label: palette.label, fieldName: '', child: [] }
    if (palette.formType === PageFormGroup.Table) return { ident: nextId(), formType: PageFormGroup.Table, label: palette.label, fieldName: `details${id}`, child: [{ ident: nextId(), formType: PageFormGroup.Group, label: '', fieldName: '', child: [] }] }
    if (palette.formType === PageFormGroup.List) return { ident: nextId(), formType: PageFormGroup.List, label: palette.label, fieldName: `list${id}`, child: [{ ident: nextId(), formType: PageFormGroup.Group, label: '', fieldName: '', child: [] }] }
    return createField(palette)
  }
  const ident = draggingItemId.value
  draggingItemId.value = ''
  return ident ? detachItem(form.form as DesignerItem[], ident) : undefined
}
const dropOnRoot = () => {
  const item = takeDraggedItem()
  if (item) { form.form.push(item as never); select(item) }
}
const dropInContainer = (_event: DragEvent, target: DesignerItem) => {
  if (draggingItemId.value === target.ident) return
  if (draggingPalette.value && [PageFormGroup.Group, PageFormGroup.Table, PageFormGroup.List].includes(draggingPalette.value.formType)) return
  const dragged = draggingItemId.value ? walk(form.form as DesignerItem[], draggingItemId.value) : undefined
  if (dragged && (isContainer(dragged) || containsItem(dragged, target.ident))) return
  const item = takeDraggedItem()
  if (!item) return
  containerFields(target).push(item)
  select(item)
}
const syncOptions = (item: DesignerItem) => { item.optionText = item.optionText ?? '' }
const parentAndIndex = (items: DesignerItem[], target: string): { items: DesignerItem[]; index: number } | undefined => {
  const index = items.findIndex((item) => item.ident === target)
  if (index >= 0) return { items, index }
  for (const item of items) { const found = parentAndIndex((item.child ?? []) as DesignerItem[], target); if (found) return found }
}
const canMove = (offset: number) => { const result = parentAndIndex(form.form, selectedId.value); return !!result && result.index + offset >= 0 && result.index + offset < result.items.length }
const moveSelected = (offset: number) => { const result = parentAndIndex(form.form, selectedId.value); if (result && canMove(offset)) [result.items[result.index], result.items[result.index + offset]] = [result.items[result.index + offset], result.items[result.index]] }
const removeSelected = () => { const result = parentAndIndex(form.form, selectedId.value); if (result) result.items.splice(result.index, 1); selectedId.value = '' }

const optionsFromItem = (item: DesignerItem) => (item.optionText ?? '').split('\n').map((line) => line.trim()).filter(Boolean).map((line) => {
  const [label, ...rest] = line.split(','); return { label: label.trim(), value: (rest.join(',').trim() || label.trim()) }
})
const cloneItem = (item: DesignerItem): TempEditForm => ({ formType: item.formType, label: item.label, fieldName: item.fieldName, placeholder: item.placeholder || undefined, child: item.child?.map(cloneItem) })
const buildOptions = (items: DesignerItem[], result: TempEditPageData['options'] = {}) => { items.forEach((item) => { if (isChoice(item) && item.fieldName) result[item.fieldName] = optionsFromItem(item); if (item.child) buildOptions(item.child as DesignerItem[], result) }); return result }
const buildData = (items: DesignerItem[], result: Record<string, unknown> = {}) => { items.forEach((item) => { if (item.formType === PageFormGroup.Table || item.formType === PageFormGroup.List) { if (item.fieldName) result[item.fieldName] = [{}] } else if (!isContainer(item) && item.fieldName) result[item.fieldName] = item.formType === PageFormType.MultSelect || item.formType === PageFormType.Checkbox ? [] : item.formType === PageFormType.Switch ? false : ''; if (item.formType === PageFormGroup.Group) buildData((item.child ?? []) as DesignerItem[], result) }); return result }
const buildRules = (items: DesignerItem[], result: Record<string, FormItemRule[] | Record<string, FormItemRule[]>> = {}) => { items.forEach((item) => { if (item.formType === PageFormGroup.Table || item.formType === PageFormGroup.List) { const nested: Record<string, FormItemRule[]> = {}; buildRules(containerFields(item), nested); if (item.fieldName && Object.keys(nested).length) result[item.fieldName] = nested } else if (item.formType === PageFormGroup.Group) buildRules((item.child ?? []) as DesignerItem[], result); else if (item.must && item.fieldName) result[item.fieldName] = [{ required: true, message: `请${isChoice(item) ? '选择' : '输入'}${item.label}`, trigger: isChoice(item) ? 'change' : 'blur' }] }); return result }
const previewForm = computed<TempEditPageData>(() => ({ loading: false, hideBtn: true, cols: form.cols, form: form.form.map(cloneItem), formData: buildData(form.form), options: buildOptions(form.form), rules: buildRules(form.form) }))
const exportData = () => ({ ...previewForm.value, formData: buildData(form.form), options: buildOptions(form.form), rules: buildRules(form.form) })
const showJson = () => { jsonText.value = JSON.stringify(exportData(), null, 2); jsonVisible.value = true }
const resetDesigner = () => { form.form.splice(0); selectedId.value = '' }
const save = () => {
  var json = exportData();
  const pushData = {
    nodeId: nodeId ?? '',
    formJson: json,
  }
  emits('release', json);
}
onMounted(async () => {
  const res = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(workflowDeginitionId ?? '', nodeId ?? '');
  if (res.data.statusCode==200) {
    var data=res.data.data||{};
  }
})
</script>

<style scoped lang="less">
.page-form-designer {
  min-height: 720px;
  overflow: hidden;
  background: #f3f6fc;
}

.designer-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 20px 28px;
  color: #fff;
  background: linear-gradient(120deg, #1c64f2, #4f46e5);
  box-shadow: 0 3px 16px rgb(30 64 175 / 20%);

  h2 {
    margin: 0 0 6px;
    font-size: 22px;
    letter-spacing: .5px;
  }

  p {
    margin: 0;
    color: rgb(255 255 255 / 80%);
    font-size: 13px;
  }

  code {
    padding: 1px 4px;
    border-radius: 3px;
    background: rgb(255 255 255 / 16%);
  }

  .designer-actions :deep(.el-button) {
    border-color: rgb(255 255 255 / 45%);
  }

  .designer-actions :deep(.el-button:not(.el-button--danger)) {
    color: #1d4ed8;
  }
}

.designer-actions,
.property-actions {
  display: flex;
  gap: 8px;
}

.designer-body {
  display: grid;
  grid-template-columns: 220px minmax(460px, 1fr) 300px;
  min-height: 650px;
}

.designer-panel {
  padding: 20px;
  background: #fff;
  border-right: 1px solid #e5eaf3;

  h3 {
    margin: 0 0 8px;
    color: #172554;
    font-size: 16px;
  }
}

.property-panel {
  border-right: 0;
  border-left: 1px solid #e5eaf3;
}

.panel-tip {
  margin: 0;
  color: #7b879b;
  font-size: 12px;
  line-height: 1.6;
}

.palette-button {
  width: 100%;
  margin: 0 0 9px !important;
  color: #3b4b68;
  text-align: left;
  border-color: #dbe5f4;
  transition: transform .15s, box-shadow .15s;
  cursor: grab;

  &:hover {
    color: #1d4ed8;
    border-color: #93c5fd;
    background: #eff6ff;
    box-shadow: 0 4px 10px rgb(59 130 246 / 12%);
    transform: translateX(3px);
  }

  &:active {
    cursor: grabbing;
  }
}

.canvas-panel {
  padding: 24px;
  overflow: auto;
  background-image: radial-gradient(#d9e3f2 1px, transparent 1px);
  background-size: 18px 18px;
}

.canvas-title {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 16px;
  padding: 12px 16px;
  color: #1e3a5f;
  background: rgb(255 255 255 / 90%);
  border: 1px solid #e3ebf7;
  border-radius: 10px;
  box-shadow: 0 2px 8px rgb(55 85 130 / 7%);
}

.empty-canvas,
.empty-group {
  display: block;
  padding: 42px 16px;
  color: #7b879b;
  text-align: center;
  border: 2px dashed #b9c9df;
  border-radius: 10px;
  background: rgb(255 255 255 / 75%);
}

.canvas-items {
  display: grid;
  gap: 14px;
}

.canvas-group {
  padding: 18px;
  border: 1px solid #dce6f2;
  border-radius: 10px;
  background: #fff;
  box-shadow: 0 3px 12px rgb(56 88 130 / 8%);
  cursor: pointer;
  transition: border-color .15s, box-shadow .15s;
}

.canvas-group.selected,
.field-card.selected {
  border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgb(59 130 246 / 15%);
}

.canvas-group-title {
  display: flex;
  justify-content: space-between;
  padding-bottom: 12px;
  color: #1e3a5f;
  font-weight: 600;
  border-bottom: 1px solid #edf2f8;

  small {
    color: #7b879b;
    font-weight: normal;
  }
}

.canvas-group-fields {
  display: grid;
  grid-template-columns: repeat(2, minmax(0, 1fr));
  gap: 10px;
  padding-top: 12px;
}

.field-card {
  padding: 13px;
  border: 1px solid #e1eaf5;
  border-radius: 8px;
  background: #fff;
  cursor: grab;
  transition: border-color .15s, box-shadow .15s, transform .15s;

  &:hover {
    border-color: #93c5fd;
    box-shadow: 0 4px 10px rgb(59 130 246 / 10%);
    transform: translateY(-1px);
  }

  &:active {
    cursor: grabbing;
  }

  strong,
  span {
    display: block;
  }

  strong {
    color: #334155;
  }

  span {
    margin-top: 5px;
    color: #7b879b;
    font-size: 12px;
  }

  .property-actions {
    padding-top: 10px;
    flex-wrap: wrap;
  }

  @media (max-width: 1050px) {
    .designer-body {
      grid-template-columns: 190px minmax(360px, 1fr);
    }

    .property-panel {
      grid-column: 1 / -1;
      border-top: 1px solid #e5eaf3;
      border-left: 0;
    }

    .designer-header {
      align-items: flex-start;
      gap: 12px;
      flex-direction: column;
    }
  }
}
</style>