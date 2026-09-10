import { post, get, all } from '@/axios';


const center = 'auth-center';
const auditCenter = 'audit-center';

/**
 * 保存事项
 * @returns 
 */
export const saveMatter = async (data: any) => {
    return (await post(`${center}/api/matter/manage/saveMatter`, data))
}


/**
 * 删除事项
 * @param matterId 
 * @returns 
 */
export const delMatterTemp=async (matterId: string) => {
    return (get(`${center}/api/matter/manage/matter/del`, {
        id:matterId
    }))
}

/**
 * 获取事项分类层级
 * @returns 
 */
export const getMatterOptions = async () => {
    return (await get(`${center}/api/matter/manage/tree/getMatterLevel`))
}

/**
 * 事项页面数据
 * @param matterId 
 * @returns 
 */
export const getMatterInfo = (matterId: string) => {
    return get(center + '/api/matter/manage/saveMatter/fill', { id: matterId })
}

/**
 * 事项页面渲染
 * @param id 
 * @returns 
 */
export const getMatterPageRender = (id?: string) => {
    if (id)
        return all([getMatterOptions(), getMatterInfo(id)]);
    return all([getMatterOptions()])
}



/**
 * 保存事项模板
 * @returns 
 */
export const saveMatterTemp = async (menuId: string, data: any) => {
    return (await post(`${auditCenter}/api/matter/form/manage/set/matter/form/save`, { ...data, menuId: menuId }))
}

/**
 * 获取事项数据来源选项
 * @returns 
 */
export const getMatterCustomOptions = async () => {
    return (await get(`${auditCenter}/api/matter/form/manage/set/matter/form/select`))
}

/**
 * 获取事项模板详情
 * @param menuId 
 * @returns 
 */
export const getMatterTempFormDetail = async (menuId: string) => {
    return (await get(`${auditCenter}/api/matter/form/manage/set/matter/form/fill`, { menuId })).data
}