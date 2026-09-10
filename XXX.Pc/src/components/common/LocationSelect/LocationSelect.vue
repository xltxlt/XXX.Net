<script setup lang='ts'>
// import AMapLoader from '@amap/amap-jsapi-loader'
import { initMap } from '@/utils/amap';
import { ref, watch, nextTick } from 'vue';
import YzDialog from '../YzDialog/YzDialog.vue';
import { Search } from '@element-plus/icons-vue'

let selectedLngLat = ref<{ lng: number; lat: number } | null>(null)
const props = defineProps<{
  show?: boolean
}>()
const mapContentRef = ref<HTMLDivElement | null>(null)
const searchVal = ref('')

let showDialog = ref(false)
let placeSearch: any = null;
let map: any = null;
let marker: any = null;
function doInitMap(AMap: any) {
  map = new AMap.Map(mapContentRef.value, { zoom: 12 })
  marker = new AMap.Marker({ map })
  AMap.plugin('AMap.PlaceSearch', function () {
    placeSearch = new AMap.PlaceSearch({ map })
  })
  // 监听地图点击事件
  map.on('click', (e: any) => {
    const lnglat = e.lnglat
    marker.setPosition(lnglat)
    selectedLngLat.value = { lng: lnglat.lng, lat: lnglat.lat }
  })
}
const emits = defineEmits(['update:show', 'confirm', 'cancel'])
watch(
  () => props.show,
  (val: any) => {
    if (val ) {
      nextTick(() => {
        if (mapContentRef.value) {
          initMap((AMap: any) => {
            doInitMap(AMap)
          })
        }
      })
    }
  },
  { immediate: true }
)
const onSearch = () => {
  if (!placeSearch || !searchVal.value) return;
  placeSearch.search(searchVal.value, function (status: string, result: any) {
    if (status === 'complete' && result.info === 'OK' && result.poiList.pois.length > 0) {
      const poi = result.poiList.pois[0]
      const lnglat = poi.location
      map.setCenter(lnglat)
      marker.setPosition(lnglat)
    }
  })
}


function onConfirm() {
  let lng = null, lat = null
  if (selectedLngLat.value) {
    lng = selectedLngLat.value.lng
    lat = selectedLngLat.value.lat
  } else if (marker) {
    const position = marker.getPosition()
    lng = position.lng
    lat = position.lat
  }
  if (lng && lat) {
    // 新增：逆地理编码获取详细地址
    (window as any).AMap.plugin('AMap.Geocoder', function () {
      const geocoder = new (window as any).AMap.Geocoder()
      geocoder.getAddress([lng, lat], function (status: string, result: any) {
        let address = '';
        let other: any = null;
        if (status === 'complete' && result.regeocode) {
          address = result.regeocode.formattedAddress;
          other = result.regeocode.addressComponent;
        }
        emits('confirm', { lng, lat, address, other })
        emits('update:show', false)
        showDialog.value=false;
      })
    })
  }
}

const yzDialogRef = ref()
const btns = ref([{
  text: '取消', color: '#BFBFBF'
}, {
  text: '确认'
}])
</script>
<template>
  <yz-dialog v-model:show="props.show" @colse-dialog="emits('update:show', false); emits('cancel')"  ref="yzDialogRef" title="地址选择" width="800">
    <div class="location-select" style="height: 100%">
      <div class="location-select-header">
        <el-input v-model="searchVal" style="" size="large" placeholder="请输入搜索关键词">
          <template #append>
            <el-button :icon="Search" @click="onSearch"></el-button>
          </template>
        </el-input>
      </div>
      <div class="location-select-content">
        <div class="map-content" ref="mapContentRef">

        </div>
      </div>
      <div class="location-select-footer">
        <el-button type="primary" @click="onConfirm">确认</el-button>
      </div>
    </div>
  </yz-dialog>
</template>
<style lang='less' scoped>
.location-select {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;

  .location-select-header {
    height: 50px;
    width: 100%;
  }

  .location-select-content {
    flex: 1;

    .map-content {
      height: 100%;
      width: 100%;
    }
  }

  .location-select-footer {
    position: relative;
    height: 50px;
    display: flex;
    width: 100%;
    align-items: flex-end;
    justify-content: flex-end;

  }
}
</style>