<template>
  <ul class="main-menu">
    <li class="nav-link">
      <div 
        class="menu" 
        @click="toggleSubMenu()">
        <i :class="nav.icon"/>
        <span>{{ nav.text }}</span>
        <i class="el-icon-arrow-right menu-arrow"/>
      </div>
      <div 
        :style="dispLaySubMenu?'display:flex; flex-direction:column; justify-content: space-between;':'display:none'" 
        class="collapsed">
        <ul>
          <router-link 
            v-for="(subMenu,index) in nav.children" 
            :key="index" 
            :to="subMenu.path" 
            tag="li">
            <span>{{ subMenu.text }}</span>
          </router-link>
        </ul>
      </div>
    </li>
  </ul>
</template>

<script>
    export default {
        create() {},
  props: {
    nav: {
      type: Object,
      default: null
    }
  },
  data () {
    return {
      dispLaySubMenu: false
    }
  },
  methods: {
    toggleSubMenu () {
      this.dispLaySubMenu = !this.dispLaySubMenu
    }
  }
}
</script>

<style lang="scss">
.main-menu {
  list-style: none;
  padding: 0px;
  font-weight: 100;
  li {
    .menu {
      display: flex;
      span {
        flex: 1;
        margin-left: 20px;
      }
    }
  }
  ul {
    list-style: none;
    padding: 0px;
    li {
      margin-left: 36px;
      &:hover {
        color: #68c7ff;
      }
    }
  }
}
</style>