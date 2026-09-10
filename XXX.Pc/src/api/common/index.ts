import service, { post, get } from "../../axios";

const getPageConfig = () => {
    return service.get('src/tData/pageConfig.json');
};
//获取左侧菜单资源
const getMenuData = () => {
    return get('auth-center/api/menu/manage/pc/getPcLeftMenuTree', {
    })
}
//获取顶部菜单
const getTopMenuData = () => {
    return get('auth-center/api/menu/manage/pc/getPcTopMenuTree', {
        parentId: 63
    })
}
/**
 * 获取页面渲染数据
 * @param menuId   菜单ID
 * @returns 
 */
const getPageRenderDataById =async (menuId:string) =>{
    return await post('auth-center/api/menu/manage/pc/render',{menuId:menuId}).then((res)=>res.data)

} 
/**
 * 获取导出字段
 * @param code 
 * @returns 
 */
export const getExportFields=async (code:string,tableName:string) =>{
    return await post('config-center/api/config/data/getExportFiledList',{bizCode:code,tableName:tableName}).then((res)=>res.data)
}
const getPageListDataById = () => get(`src/tData/dicListData.json`)
// const getPageListByUrl=(url:string,pageListPars:PageListPars)=>post(url,pageListPars)
const getPageListByUrl=(url:string,pageListPars:any)=>post(url,pageListPars)

interface PageListPars{
    menuId:string,
    listWhere?:any,
    pageSize:number,
    page:number
}
interface SysMenuTree {
    icon: string,
    title: string,
    parentId: string,
    imgUrl: string,
    checkedIcon: string,
    children: SysMenuTree[]
}
export type { SysMenuTree,PageListPars }
export {
    getMenuData,
    getPageConfig,
    getPageRenderDataById,
    getPageListDataById,
    getTopMenuData,
    getPageListByUrl
}