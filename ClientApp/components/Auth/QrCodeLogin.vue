<template>
    <div class="qr-code">
        <div class="qr-code-wrapper">
        <img style="height: 400px;width: 400px" :src="qrCode" alt="">
        </div>
    </div>
</template>
<script>
    import axios from "axios"
    import * as SignalR from "@aspnet/signalr"
    export default {
        data() {
            return {
                qrCode: "",
                loaded: false,
                loading: false,
                connection: null
            };
        },


        created() {
            let vm = this;
            vm.connection = new SignalR.HubConnectionBuilder()
                .withUrl(`/login-hub/`)
                .configureLogging(SignalR.LogLevel.Information)
                .build();
            vm.connection.start().then(() => {
                vm.connection.invoke("GetCode")
            });
            vm.connection.on("LoginCode", function (code) {
                vm.qrCode = code;
            });
        }


    }


</script>

<style>
    .qr-code{
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>