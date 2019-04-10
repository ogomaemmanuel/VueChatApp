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
            {
                path: "/country_list",
                name: "country_list",
                component:()=> import("../components/SetUp/CountriesStatesZones/CountryList")
                    
            },

            {
                path: "/state-list",
                name: "state-list",
                component:()=> import("../components/SetUp/CountriesStatesZones/States/StateList")
                    
            },
            {
                path: "/zone-list",
                name: "zone-list",
                component:()=> import("../components/SetUp/CountriesStatesZones/Zones/ZoneList")
                    
            },
             //Users routes
        {
                path: "/user-list",
                name: "user-list",
            component: () => import("../components/Users/UserList")
            },
            {
                path: "/user-create",
                name: "user-create",
                component:()=> import("../components/Users/UserCreate")
            },
            {
                path: "/permission_list",
                name: "permission_list",
                component: () => import("../components/Users/Permissions/PermissionList")
           
            },
            ]
    }
  ],
  mode: "history"
})

export default routes
