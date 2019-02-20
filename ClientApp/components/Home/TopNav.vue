<template>
  <b-navbar 
    :sticky="stickyTopBar" 
    class="app-top-nav" 
    toggleable="md" 
    type="light" 
    variant="light">
    <b-navbar-toggle target="nav_collapse"/>
    <b-navbar-brand href="#">Shopp Cart Admin</b-navbar-brand>
    <b-collapse 
      id="nav_collapse" 
      is-nav>
      <b-navbar-nav>
        <b-nav-item 
          href="#" 
          @click.prevent="showSideNav()"> Toggle Side menu</b-nav-item>
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto">
        <b-nav-form>
          <b-form-input 
            size="sm" 
            class="mr-sm-2" 
            type="text" 
            placeholder="Search" />
          <b-button 
            size="sm" 
            class="my-2 my-sm-0" 
            type="submit">Search</b-button>
        </b-nav-form>
        <b-nav-item-dropdown right>
          <template slot="button-content">
            <img 
              class="profile-image" 
              src="https://media.licdn.com/dms/image/C5603AQEO-nI8cnK_xw/profile-displayphoto-shrink_800_800/0?e=1553731200&v=beta&t=8AnOF1lW9zzdRMfDIpBGkMPT_E1Pd9wTsay9Rd-UcIg"
              alt="John">
          </template>
          <b-dropdown-item href="#">Profile</b-dropdown-item>
          <b-dropdown-item href="#">Signout</b-dropdown-item>
          <b-dropdown-item href="#">Change Password</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>

    </b-collapse>
  </b-navbar>
</template>
<script>
import { EventBus } from "../event-bus.js"
export default {
  data() {
    return {
      stickyTopBar: true
    };
  },
  methods: {
    showSideNav() {
      EventBus.$emit("showSideNav");
    }
  }
};
</script>

<style lang="scss">
.profile-image {
  width: 48px;
  height: 48px;
  border-radius: 50%;
}
</style>