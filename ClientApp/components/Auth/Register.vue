<template>
<div class="login-form-controls">
    <div class="login">
        <b-form-group id="usernamelabel" label="Enter your Email" label-for="email">
            <b-form-input id="email" v-model.trim="user.email" type="email" />
        </b-form-group>

        <b-form-group id="first-name-label" label="Enter your Firstname" label-for="first-name">
            <b-form-input id="first-name" v-model.trim="user.firstName" type="email" />
        </b-form-group>

        <b-form-group id="last-name-label" label="Enter your Lastname" label-for="last-name">
            <b-form-input id="last-name" v-model.trim="user.lastName" type="email" />
        </b-form-group>

        <b-form-group id="passwordlabel" label="Enter your password" label-for="password">
            <b-form-input id="password" v-model.trim="user.password" type="password" />
        </b-form-group>

        <b-form-group id="confirm-password-label" label="Confirm Password" label-for="confirm-password">
            <b-form-input id="confirm-password" v-model.trim="user.confirmPassword" type="password" />
        </b-form-group>
        <b-button :block="true" @click="registerUser">
            Register
        </b-button>
    </div>
</div>
</template>

<script>
export default {
    data () {
        return {
            user: {}
        }
    },
    methods: {
        registerUser () {
            let vm = this
            vm.$store.dispatch("register", vm.user)
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
