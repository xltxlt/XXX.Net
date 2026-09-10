import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'
// import { createHtmlPlugin } from 'vite-plugin-html'-
// import vueDevTools from 'vite-plugin-vue-devtools'
export default defineConfig({
    plugins: [
        vue(),
        // vueDevTools(),
        // createHtmlPlugin({})
    ],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, 'src'),
        },
    }
})
