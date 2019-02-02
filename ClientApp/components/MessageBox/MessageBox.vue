<template>
  <div class="chat-message-box">
    <ChatMessageBoxHeader 
      :show-body.sync="showBody" 
      :online-user="onlineUser"/>
    <div 
      v-show="showBody" 
      class="chat-message-box-body">
      <div 
        ref="messages" 
        class="messages">
        <div 
          v-for="filtedMessage in fiteredChatMessages" 
          :key="filtedMessage.id">
          <ReceivedMessage 
            v-if="filtedMessage.toId==auth.userDetails.id" 
            :message="filtedMessage"/>
          <SentMessageCard 
            v-if="filtedMessage.fromId==auth.userDetails.id" 
            :message="filtedMessage"/>
        </div>
      </div>
      <MessageBoxFooter
        :online-user="onlineUser"/>
    </div>
  </div>
  
</template>

<script>
import ChatMessageBoxHeader from "./ChatMessageBoxHeader.vue"
import MessageBoxFooter from "./MessageBoxFooter.vue"
import ReceivedMessage from "./ReceivedMessageCard.vue"
import SentMessageCard from "./SentMessageCard.vue"
export default {
  components: {
    ChatMessageBoxHeader,
    MessageBoxFooter,
    ReceivedMessage,
    SentMessageCard
  },
  props: {
    onlineUser: {
      type: Object,
      default: null
    }
  },
  data () {
    return {
      showBody: true
    }
  },
  
  computed: {
    chatMessages () {
      return this.$store.getters.chatMessages
    },
    auth () {
      return this.$store.getters.auth
    },
    fiteredChatMessages () {
      let vm = this
      return this.chatMessages
        .filter(message => {
          return (
            (message.toId == vm.onlineUser.id &&
              message.fromId == vm.auth.userDetails.id) ||
            (message.toId == vm.auth.userDetails.id &&
              message.fromId == vm.onlineUser.id)
          )
        })
        .sort(function (messageA, messageB) {
          return messageA.updatedAt == messageB.updatedAt
            ? 0
            : +(messageA.updatedAt > messageB.updatedAt) || -1
        })
    }
  },
   watch: {
    fiteredChatMessages: function () {
      let vm = this
      vm.$nextTick(function () {
        vm.scrollMessagesToBottom()
      })
    },
    showBody: function (newValue) {
      let vm = this
      if (newValue === true) {
        vm.$nextTick(function () {
          vm.scrollMessagesToBottom()
        })
      }
    }
},
mounted () {
    this.scrollMessagesToBottom()
  },
 methods: {
    scrollMessagesToBottom () {
      this.$refs.messages.scrollTop =
        this.$refs.messages.scrollHeight + this.$refs.messages.clientHeight
    }
  }
}
</script>
<style lang="scss">
.chat-message-box {
  background-color: #ffffff;
  min-width: 400px;
  max-height: 600px;
  border-top-right-radius: 10px;
  position: relative;
  padding-top: 0px;
  border-top-left-radius: 10px;
  margin-left: 5px;
  align-self: flex-end;
  box-shadow: 0 2px 8px 0 rgba(0, 0, 0, 0.3);
  .chat-message-box-body {
    .messages {
      overflow-y: scroll;
      width: 100%;
      height: 240px;
      display: flex;
      flex-flow: column;
    }
  }
}
</style>