import { getAPI } from "@/api-services";
import {DocumentApi,SysUserDepRoleApi, SysTenantApi,  SysUserApi,SysAuthApi,SysMenuApi,SysDictTypeApi,SysFileApi,SysMenuButtonApi,SysMenuFieldApi,GenerateApi,SysRoleApi ,SysConfigApi,SysPositionApi,SysDepApi} from "@/api-services/generated";
export const tenantService = getAPI(SysTenantApi);
export const userService = getAPI(SysUserApi);
export const authService = getAPI(SysAuthApi);
export const menuService = getAPI(SysMenuApi);
export const dictTypeService = getAPI(SysDictTypeApi);
export const fielService = getAPI(SysFileApi);
export const roleService = getAPI(SysRoleApi);

export const menuButtonService=getAPI(SysMenuButtonApi);
export const menuFieldService=getAPI(SysMenuFieldApi);
export const generateService=getAPI(GenerateApi);

export const configService=getAPI(SysConfigApi);
export const positionService=getAPI(SysPositionApi);
export const depService=getAPI(SysDepApi);
export const documentService=getAPI(DocumentApi);
export const userDepRoleService=getAPI(SysUserDepRoleApi);







