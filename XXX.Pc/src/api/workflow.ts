import { getAPI } from "@/api-services";
import { WorkflowDefinitionApi,WorkflowNodeFormApi,WorkflowInstanceApi,WorkflowTaskApi,PmFlowTempApi } from "@/api-services/generated";
export const workflowDefinitionService = getAPI(WorkflowDefinitionApi);
export const workflowNodeFormService = getAPI( WorkflowNodeFormApi);
export const workflowInstanceService = getAPI(WorkflowInstanceApi);
export const workflowTaskService = getAPI(WorkflowTaskApi);
export const pmFlowTempService = getAPI(PmFlowTempApi);