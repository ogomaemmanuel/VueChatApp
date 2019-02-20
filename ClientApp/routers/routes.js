import Vue from "vue"
import Router from "vue-router"
const LandingPage = () => import("../components/Home/LandingPage.vue")
const Login = () => import("../components/Auth/Login.vue")
const Register = () => import("../components/Auth/Register.vue")
const WebRtcComponent=()=> import("../components/MessageBox/RealTime/WebRTCPeerConnection.vue")
const PaymentMethods = () => import("../components/SetUp/PaymentMethods/PaymentMethods.vue")
Vue.use(Router)

const routes = new Router({
  routes: [
    {
      path: "/",
      name: "login-page",
      component: Login
    },
    {
      path: "/register",
      name: "register",
      component: Register
      },

     
    {
      path: "/web-rtc",
      name: "web-rtc",
      component: WebRtcComponent
    },

    {
      path: "/home",
      name: "home",
        component: LandingPage,
        children: [
            {
                path: "/contact-information",
                name: "contact-information",
                component: () => import("../components/SetUp/ContactInfomation/ContactInformationCreate.vue")
                    
            },
            {
                path: "/payment-methods-list",
                name: "payment-methods-list",
                component: PaymentMethods,
            },
            ]
    }
  ],
  mode: "history"
})

export default routes
