import Vue from 'vue'
import App from './App'
import router from './router'
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.min";
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import echarts from 'echarts'

Vue.prototype.$echarts = echarts
Vue.config.productionTip = false
Vue.use(ElementUI);
import './permission'
/* eslint-disable no-new */
new Vue({
    router,
    render: h => h(App)
}).$mount("#app");