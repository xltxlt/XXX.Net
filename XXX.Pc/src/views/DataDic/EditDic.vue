<template>
    <div class="edit-dic">
        修修改修改修改
    </div>
</template>
<script setup lang="ts">

const props= defineProps<{
    form: any
}>();
console.log(props.form.value); 
</script>
<style scoped>
.edit-dic {
    height: 100%;
    padding: 20px;
}
</style>