<template>
  <div class="user-profile">
    <div class="card">
      <img 
        class="profile-image" 
        src="https://media.licdn.com/dms/image/C5603AQEO-nI8cnK_xw/profile-displayphoto-shrink_800_800/0?e=1553731200&v=beta&t=8AnOF1lW9zzdRMfDIpBGkMPT_E1Pd9wTsay9Rd-UcIg"
 
        alt="John">
      <p class="name">{{ auth.userDetails.fullName }}</p>
      <p class="title">CEO & Founder, Example</p>
      <div class="notification-panel">
        <span><i class="el-icon-setting"/></span>
        <span class="count-wrapper">
          <i class="el-icon-bell"/>
          <span class="count top-right bg-warning">
            4
          </span>
        </span>
        <span><i class="el-icon-message"/></span>
      </div>
    </div>
  </div>
</template>
<script>
// import { mapGetters } from "vuex"
export default {
  data () {
    return {}
  },
  computed: {
   auth () {
      return this.$store.getters.auth
    }
  }
}
</script>
<style lang="scss" scoped>
.user-profile {
  margin-top: 70px;
  .card {
    width: 100%;
    margin: auto;
    text-align: center;
    background-color: #161616;
    .notification-panel {
      display: flex;
      align-items: center;
      justify-content: center;
      position: relative;
      span {
        height: 31px;
        width: 31px;
        background: #232323;
        display: flex;
        align-items: center;
        -webkit-justify-content: center;
        justify-content: center;
        border-radius: 50px;
        margin-right: 1.1875rem;
      }
      .count-wrapper {
        position: relative;
        .top-right {
          top: -5px;
          right: -25px;
          height: 15px;
        }
        .count {
          position: absolute;
          width: auto;
          min-width: 8px;
          min-height: 8px;
          padding: 2px 4px;
          font-size: 75%;
          line-height: 1;
          vertical-align: middle;
          border-radius: 100%;
          color: #ffffff;
          font-weight: 500;
        }
      }
      i {
        text-align: center;
        color: #8ba2b5;
        margin: auto;
      }
      margin-top: 1.5rem;
      //   position: relative;
    }
    .profile-image {
      width: 88px;
      height: 88px;
      margin: auto;
      border-radius: 50%;
    }
  }
  .title {
    color: #8d9498;
    font-size: 0.75rem;
  }
  .name {
    margin-bottom: 0;
    line-height: 1.5;
  }
  button {
    border: none;
    outline: 0;
    display: inline-block;
    padding: 8px;
    color: white;
    background-color: #000;
    text-align: center;
    cursor: pointer;
    width: 100%;
    font-size: 18px;
  }
  a {
    text-decoration: none;
    font-size: 22px;
    color: black;
  }
}
</style>