<template>
  <div class="received-message" @click="alertSomething">
    <img
      height="32px"
      width="32px"
      src="https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_960_720.png"
      alt=""
    />
    <img class="img-message" v-if="message.type=='img'" :src="message.message">
     <video type="video/mp4" controls class="img-message" v-else-if="message.type=='video'" :src="message.message"/>
    <div v-else class="received-message-body">{{ message.message }}</div>
  </div>
</template>
<script>
export default {
  props: {
    message: {
      type: Object,
      default: null
    }
  },
  methods: {
    alertSomething () {
      // window.alert("Hey There");
    }
  }
}
</script>

<style lang="scss">
.received-message {
  display: flex;
  align-items: center;
  img {
    border-radius: 50%;
  }
.img-message{
    border-radius: 0px;
    width: 100px;
    height: 100px;
    margin: 10px;
  }
  .received-message-body {
    min-height: 25px;
    min-width: 0px;
    max-width: 170px;
    margin: 10px;
    border-radius: 16px;
    overflow-wrap: break-word;
    background-color: #f1f0f0;
    padding: 16px;
  }
}
</style>
