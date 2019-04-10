<template>
    <div class="home-page-wrapper">
        <slot name="sidemenu">
            <i slot="side-menu-hider"
               class="el-icon-arrow-left menu-arrow" />
        </slot>
        <div :style="homeWidth"
             class="delivery-app-body">
            <slot name="top-nav-bar" />
            <div class="delivery-app-body-content">
                <transition name="fade">
                    <router-view />
                </transition>
            </div>
        </div>
        <div class="chat-area">
            <div class="chats">
                <MessageBox v-for="(user, index) in usersToChatWith"
                            :key="index"
                            :online-user="user" />
            </div>
            <ChatFlyOut />
        </div>
    </div>
</template>

<script>
import { EventBus } from "../event-bus.js";
import ChatFlyOut from "../ChatListFlyOut/ChatFlyOut.vue"
import MessageBox from "../MessageBox/MessageBox.vue"
export default {
  components: {
    ChatFlyOut,
    MessageBox
  },
  data () {
    return {
      homeWidth: {
        "margin-left": "255px"
      },
      user: {}
    }
  },
  computed: {
    usersToChatWith () {
      return this.$store.getters.usersToChatWith
    }
  },
  created () {
     let vm = this;
    EventBus.$on("sideNavClosed", function() {
      vm.homeWidth["margin-left"] = "0px";
    });
    EventBus.$on("showSideNav", function() {
      vm.homeWidth["margin-left"] = "255px";
    });
  }
}
</script>

<style lang="scss">
.home-page-wrapper {
  .delivery-app-body {
    margin-left: 255px;
    transition: all 2s;
    background-color: #ffffff;
    min-height: 100%;
    transition-timing-function: ease-in-out;
    .delivery-app-body-content {
      min-height: 100vh;
      margin-top: 36px;
      margin-left: 28px;
      margin-right: 90px;
    }
  }

  .chat-area {
    display: flex;
    position: fixed;
    bottom: -3px;
    right: 15px;
    align-items: flex-end;
    padding: 0%;
    .chats {
      min-height: 0px;
      align-items: baseline;
      margin-right: 10px;
      display: flex;
    }
  }
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease-in-out;
}

.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>
