<template>
  <div>
    <router-view>
      <sidemenu slot="sidemenu"/>
      <top-nav-bar slot="top-nav-bar"/> 
    </router-view>
  </div>
</template>
<script>
    import sidemenu from "../components/Home/SideNav";
    import TopNavBar from "../components/Home/TopNav";
export default {
  components: {
      sidemenu,
      "top-nav-bar": TopNavBar
  },
  name: "App",
  data () {
    return {
      message:
        "Asp net core Chat application written purely using Vue Js and SignalR"
    }
  },
  mounted () {
    //navigator.serviceWorker.register("/vue-app-service-worker.js", { scope: '/' })
  }
}
</script>
