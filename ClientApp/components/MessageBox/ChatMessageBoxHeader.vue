<template>
<div class="chat-message-box-header">
    <div class="controls">
        <div class="title" @click="toggleBody">{{ onlineUser.fullName }}</div>
        <div class="controls-icons">
            <i @click="startRealTimeConversation" class="fa fa-video-camera" />
            <i class="fa fa-phone" />
        <i class="fa fa-cog" />
        <i class="fa fa-times" @click="removeUserFromChatlist(onlineUser.id)" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
    props: {
        onlineUser: {
            type: Object,
            default: null
        },
        showBody: {
            type: Boolean,
            default: true
        }
    },
    methods: {
        removeUserFromChatlist (userId) {
            this.$store.dispatch("removeUserFromChatlist", userId)
        },
        startRealTimeConversation (){
            this.$router.push("/web-rtc")
        },
        toggleBody () {
            this.$emit("update:showBody", !this.showBody)
        }
    }
}
</script>

<style lang="scss">
.chat-message-box-header {
    background-color: #3578e5;
    margin-top: 0px;
    min-height: 40px;
    width: 100%;
    color: #ffffff;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
    z-index: 1;
    padding-right: 15px;
    padding-left: 15px;

    .controls {
        display: flex;
        width: 100%;
        align-items: center;

        .title {
            flex: 1;
        }
    }
}
</style>
