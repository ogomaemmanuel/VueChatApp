<template>
  <div class="sent-message">
     <img class="img-message" v-if="message.type=='img'" :src="message.message">
     <video controls type="video/mp4" class="img-message" v-else-if="message.type=='video'" :src="message.message"/>
    <div v-else class="sent-message-body">{{ message.message }}</div>
  </div>
</template>
<script>
export default {
  props: {
    message: {
      type: Object,
      default: null
    }
  }
}
</script>

<style lang="scss">
.sent-message {
  display: flex;
  align-items: center;
  justify-content: flex-end;
  img {
    border-radius: 50%;
  }
  .img-message{
    border-radius: 0px;
    width: 100px;
    height: 100px;
    margin: 10px;
  }

  .sent-message-body {
    min-height: 25px;
    min-width: 0px;
    max-width: 170px;
    margin: 10px;
    border-radius: 16px;
    overflow-wrap: break-word;
    background-color: #3578E5;
    color: #ffffff;
    padding: 16px;
  }
}
</style>
