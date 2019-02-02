import Vue from "vue"
import VueRouter from "vue-router"
import BootstrapVue from "bootstrap-vue"
import "bootstrap/dist/css/bootstrap.min.css"
import 'material-icons/css/material-icons.min'
import "font-awesome/css/font-awesome.css"
import router from "./routers/routes"
import store from "./store/index"
import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale/lang/en'
import 'element-ui/lib/theme-chalk/index.css'
import "./config/axios_interceptor"
Vue.use(ElementUI,{locale})
Vue.use(VueRouter)
Vue.use(BootstrapVue)

new Vue({
  el: "#app-root",
  router,
  store,
  // eslint-disable-next-line no-undef
  render: h => h(require("./components/App.vue"))
})
