import { getAPI } from "@/api-services";
import {InventoryStockApi,InventorystockmanageApi, InventoryDomainApi,InventoryTypeApi,InventoryAttributeDefinitionApi,InventoryItemApi,InventoryWarehouseApi,InventoryLocationApi,InventoryDocumentApi} from "@/api-services/generated";
export const inventoryDomainService = getAPI(InventoryDomainApi);
export const inventoryTypeService = getAPI(InventoryTypeApi);
export const inventoryAttributeDefinitionService=getAPI(InventoryAttributeDefinitionApi);
export const inventoryItemService=getAPI(InventoryItemApi);
export const inventoryWarehouseService=getAPI(InventoryWarehouseApi);
export const inventoryLocationService=getAPI(InventoryLocationApi);
export const inventoryDocumentService=getAPI(InventoryDocumentApi);
export const inventoryStockService=getAPI(InventoryStockApi);
export const inventoryStockManagerService=getAPI(InventorystockmanageApi);




