<template>
  <div class="chat-user-card">
    <div class="user-details">
      <div class="chat-user-avatar">
        <img
          src="https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_960_720.png"
          alt="profile"
          width="32px"
          height="32px"
        />
        {{ user.imageUrl }}
      </div>
      <div class="chat-user-name">{{ user.fullName }}</div>
    </div>
    <span
      :class="{ 'positive-indicator': user.isOnline }"
      class="user-online-status-indicator"
    />
  </div>
</template>
<script>
export default {
  props: {
    user: {
      type: Object,
      default: null
    }
  }
}
</script>
<style lang="scss">
.chat-user-card {
  min-height: 40px;
  padding: 4px 0;
  display: flex;
  &:hover {
    background-color: #e9ebee;
  }

  .user-details {
    flex: 1;
    .chat-user-avatar {
      float: left;
      border-radius: 50%;
      overflow: hidden;
      top: -1px;
    }

    .chat-user-name {
      line-height: 32px;
      overflow: hidden;
      padding-left: 8px;
      text-overflow: ellipsis;
      white-space: nowrap;
    }
  }

  .user-online-status-indicator {
    height: 6px;
    width: 6px;
    margin-left: 4px;
    align-self: center;
    margin-right: 12px;
    border-radius: 50%;
  }

  .positive-indicator {
    background-color: rgb(66, 183, 42);
  }
}
</style>
