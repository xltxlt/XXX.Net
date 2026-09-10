import AMapLoader from '@amap/amap-jsapi-loader'

/**
 * 
 * @param plugins 
 */
export const initMap = (cb:Function,plugins:string[]=['AMap.Autocomplete', 'AMap.PlaceSearch', 'AMap.Geocoder']) => {
    (window as typeof window & { _AMapSecurityConfig: any })._AMapSecurityConfig = {
        securityJsCode: "59ad9a771eabe2dd604397b8709c8dab",
    };
    AMapLoader.load({
        key: '181f91008df3cd652fc4ede22757f1f6', // 替换为你的高德Key
        version: '2.0',
        plugins: plugins
    }).then((AMap:any)=>{
        cb&&cb(AMap)
    })
}