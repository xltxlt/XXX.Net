import { createPinia } from "pinia";
import piniaPluginPersistedstate from "pinia-plugin-persistedstate"; // 新增

const pinia  = createPinia();
pinia.use(piniaPluginPersistedstate); // 新增

export default pinia;

