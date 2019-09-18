<template>
  <div 
    :style="sideMenuWith" 
    class="side-menu">
    <div class="side-menu-content">
      <user-profile/>
      <div class="nav">
        <menu-item 
          v-for="(menuItem, index) in menus" 
          :nav="menuItem" 
          :key="index"/>
        <div class="side-menu-hide">
          <slot name="side-menu-hider"/>
          <i 
            class="el-icon-arrow-left menu-arrow" 
            @click="hideSideNav()"/>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import UserProfile from "../Users/UserProfile"
import Menu from "./MenuComponent"
import { EventBus } from "../event-bus.js"
export default {
  components: {
    "menu-item": Menu,
    "user-profile": UserProfile
  },
  data () {
    return {
      sideMenuWith: {
        ["margin-left"]: "0px"
      },
      dispLaySubMenu: false,
      menus: [
        {
          text: "Dashboard",
          icon: "fa fa-table",
          children: []
        },
        {
          text: "Orders",
          icon: "fa fa-shopping-bag",
          children: [
            {
              text: "Order List",
              icon: "el-icon-menu menu-icon",
              path: "/order-list"
            },
            {
              text: "Order Status",
              icon: "el-icon-menu menu-icon",
              path: "/order_statuses"
            },
            {
              text: "Statistics",
              icon: "el-icon-menu menu-icon",
              path: "/order_statistics"
            },
            {
              text: "Payment Transaction",
              icon: "el-icon-menu menu-icon",
              path: "/payment-transaction"
            }
          ]
        },
        {
          text: "Catalog",
          icon: "fa fa-building",
          children: [
            {
              text: "Products",
              icon: "el-icon-menu menu-icon",
              path: "/product-list"
            },
            {
              text: "Categories",
              icon: "el-icon-menu menu-icon",
              path: "/category-list"
            },
            {
              text: "Reviews",
              icon: "el-icon-menu menu-icon",
              path: "/review-list"
            },
            {
              text: "Tags",
              icon: "el-icon-menu menu-icon",
              path: "/tag-list"
            },
            {
              text: "Product Tabs",
              icon: "el-icon-menu menu-icon",
              path: "/product-tab-list"
            }
          ]
        },
        {
          text: "Discounts",
          icon: "fa fa-gift",
          children: [
            {
              text: "Volume Discounts",
              icon: "el-icon-menu menu-icon",
              path: "/volume-discount-list"
            },
            {
              text: "Coupons",
              icon: "el-icon-menu menu-icon",
              path: "/coupon-list"
            }
          ]
        },
        {
          text: "Users",
          icon: "fa fa-users",
          children: [
            {
              text: "User List",
              icon: "el-icon-menu menu-icon",
              path: "/user-list"
            },
            {
              text: "Roles",
              path: "/role_list"
            },
            {
              text: "Permission",
              path: "/permission_list"
            }
          ]
        },
        {
          text: "Content",
          icon: "fa fa-book",
          children: [
            {
              text: "News Messages",
              path: "/"
            },
            {
              text: "Menus",
              path: "/"
            },
            {
              text: "Pages",
              path: "/"
            }
          ]
        },
        {
          text: "Store Setup",
          icon: "fa fa-gear",
          children: [
            {
              text: "Contact Information",
              path: "/contact-information"
            },
            {
              text: "Cart and Checkout",
              path: "/"
            },
            {
              text: "Payment Methods",
              path: "/payment-methods-list"
            },
            {
              text: "Countiries, States and Zones",
              path: "/country_list"
            },
            {
              text: "Shipping",
              path: "/"
            },
            {
              text: "Taxes",
              path: "/"
            }
          ]
        }
      ]
    }
  },
  methods: {
    hideSideNav () {
      let vm = this
      vm.sideMenuWith["margin-left"] = "-255px"
      EventBus.$emit("sideNavClosed", this.clickCount)
      EventBus.$on("showSideNav", function () {
        vm.sideMenuWith["margin-left"] = "0px"
      })
    },
    toggleSubMenu () {
      this.dispLaySubMenu = !this.dispLaySubMenu
    }
  }
}
</script>

<style lang="scss">
.side-menu {
  i {
    align-self: center;
  }
  position: fixed;
  width: 255px;
  z-index: 30000;
  height: 100%;
  margin-top: 0px;
  margin-left: 0px;
  padding: 0px;
  // background-color: #161616;
  color: #ffffff;
  transition: all 2s;
  transition-timing-function: ease-in-out;
  .side-menu-content {
    overflow-y: scroll;
    background-color: #161616;
    height: 100%;
    position: relative;
    .nav {
      position: relative;
      overflow: hidden;
      flex-wrap: nowrap;
      flex-direction: column;
      padding-top: 30px;
      padding-bottom: 60px;
      padding-left: 0px;
      .side-menu-hide {
        position: absolute;
        bottom: 2%;
        display: flex;
        width: 100%;
        justify-content: flex-end;
      }
    }
  }
}
</style>