<template>
  <div class="message-box">
    <ChatFlyOutHeader
      :online-user-count="users.length"
      @click.native="toggleBody"
    />
    <div
      v-if="!bodyHidden"
      class="message-box-content"
    >
      <ChatUserCard
        v-for="(user, index) in users"
        :key="index"
        :user="user"
        class="online-user-list"
        @click.native="addToChatUserList(user)"
      />
      <ChatFlyOutSearchInput />
    </div>
  </div>
</template>
<script>
import ChatFlyOutSearchInput from "./ChatFlyOutSearchInput.vue"
import ChatFlyOutHeader from "./ChatFlyOutHeader.vue"
import ChatUserCard from "./ChatUserCard.vue"
import * as SignalR from "@aspnet/signalr"
export default {
  components: {
    ChatFlyOutSearchInput,
    ChatFlyOutHeader,
    ChatUserCard
  },
  data () {
    return {
      connection: null,
      bodyHidden: true,
      users: []
    }
  },
  computed: {
    auth () {
      return this.$store.getters.auth
    },
    usersToChatWith() {
      // ToDo get online users from store
      return this.$store.getters.usersToChatWith
    }
  },
  created () {
    let vm = this
    let tokenValue = `?token=${vm.auth.accessToken}`
    vm.connection = new SignalR.HubConnectionBuilder()
      .withUrl(`/signalr/notification-hub${tokenValue}`)
      .configureLogging(SignalR.LogLevel.Information)
      .build()
    vm.connection.start().then(() => {
      vm.connection.invoke("RegisterUser", vm.auth.userDetails)
    })
    vm.connection.on("UpdatedUserList", function (users) {
      vm.users = users.filter(user => user.id !== vm.auth.userDetails.id)
    })
    vm.connection.on("MessageToUser", function (incommingMessage) {
      vm.$store.dispatch("addChatMessage", incommingMessage);
      if (incommingMessage.fromId != vm.auth.userDetails.id) {
        if (!vm.usersToChatWith.find(x => x.id == chatMessage.fromId)) {
          console.log("chat notification")
          // this.$noty.info("New version of the app is available!")
          Notification.success({
            message: `You have a new message from ${chatMessage.fromUserName}`,
            position: 'top-right',
            duration: 0,
            customClass: "custom-notification"
          });
        }
      }
    })
  },
  methods: {
    //...mapActions(["addUserToChatlist", "addChatMessage"]),
    toggleBody () {
      this.bodyHidden = !this.bodyHidden
    },
    addToChatUserList (user) {
      this.$store.dispatch("addUserToChatlist", user)
    }
  }
}
</script>
<style lang="scss">
.message-box {
  max-height: 400px;
  min-width: 400px;
  position: relative;
  bottom: -3px;
  border-top-right-radius: 10px;
  border-top-left-radius: 10px;
  box-shadow: 0 2px 8px 0 rgba(0, 0, 0, 0.3);
  background-color: #f3f3f3;
  .message-box-head {
    position: relative;
  }

  .message-box-content {
    position: relative;
    height: 100%;
  }
}
</style>
