<template>
  <div> <router-view></router-view></div>
</template>
<script>
export default {
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
