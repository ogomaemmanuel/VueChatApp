<template>
<div class="login-form-controls">
    <div class="login">
        <b-form-group id="usernamelabel" label="Enter your username" label-for="username">
            <b-form-input id="username" v-model.trim="user.userName" type="text" />
        </b-form-group>

        <b-form-group id="passwordlabel" label="Enter your password" label-for="password">
            <b-form-input id="password" v-model.trim="user.password" type="password" />
        </b-form-group>
        <b-button :block="true" @click="loginUser">
            Login
        </b-button>
        <router-link to="/register">
            Register
        </router-link>
    </div>
</div>
</template>

<script>
export default {
    data () {
        return {
            user: {
                userName: "",
                password: ""
            }
        }
    },
    methods: {
        loginUser () {
            let vm = this
            vm.$store.dispatch("login", vm.user)
        }
    }
}
</script>

<style lang="scss" scoped>
.login-form-controls {
    display: flex;
    justify-content: center;

    .login {
        min-width: 490px;
        min-height: 420px;
        margin-top: 40px;

        button {
            margin-top: 20px;
        }
    }
}
</style>
