#生成ApiServices
openapi-generator-cli generate \
  -i ./swagger.json \
  -g typescript-axios \
  -o ./src/api-serivces/generated \
  --additional-properties=supportsES6=true,withSeparateModelsAndApi=true,apiPackage=api-services,modelPackage=models

# Vue 3 + TypeScript + Vite

This template should help get you started developing with Vue 3 and TypeScript in Vite. The template uses Vue 3 `<script setup>` SFCs, check out the [script setup docs](https://v3.vuejs.org/api/sfc-script-setup.html#sfc-script-setup) to learn more.

Learn more about the recommended Project Setup and IDE Support in the [Vue Docs TypeScript Guide](https://vuejs.org/guide/typescript/overview.html#project-setup).



formType 表单类型
1.输入框
2.选择框
3.日期选择框
4.时间选择框
5.日期时间选择框
6.开关
7.滑块
8.评分
9.步骤条

tableField 表格字段类型
1.自定义
2.序号
3.功能操作
4.颜色按钮
5.颜色文本
6.审核文本
7.状态颜色
8.启动状态颜色
9.切换
10.表格
11.oss图片预览
12.图片预览
13.oss文件预览
14.查看
14.文件预览


searchType 搜索框类型
1.文本框
2.下拉框
3.搜索下拉框
4.日期选择框
5.下拉多选框
6.搜索下拉多选框
7.搜索下拉层级单选框
8.搜索下拉层级多选框
9.下拉层级单选框
10.下拉层级多选框


配置表 选择配置表
数据编码 选择配置表中指定的编码


 ElMessageBox.confirm(
                '确认要做XXXX操作吗？',
                '提示',
                {
                    confirmButtonText: '确认',
                    cancelButtonText: '取消',
                    type: 'warning',
                }
            ).then(()=>{
                //确认操作
            }).catch(()=>{
                //取消操作
            });

pageInfoRef.value.onRefresh();
const emit = defineEmits(['closeDialog', 'refreshList'])
emit('closeDialog')
emit('refreshList')
handleSumbitResBox(res, '车辆解绑成功', () => {})

handleSumbitResTip(res, '车辆解绑成功', () => {})