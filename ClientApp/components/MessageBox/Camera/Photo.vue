<template>
    <div class="media-holder">
        <canvas v-show="photoTaken" ref="photoHolder" width="466px" height="350px"></canvas>
        <video v-if="!photoTaken" ref="video" id="video" width="466px" height="350px" autoplay></video>
        <div v-if="showCountDownCount" class="counter">
            {{countDown}}
        </div>
        <div class="custom-modal-footer" slot="custom-modal-footer">
            <button v-if="photoTaken" @click="resetCamera">Retake</button>
            <button v-if="!photoTaken" @click="showCountDown">Take Photo</button>
            <button v-if="!photoTaken" @click="emitTakeVideo">Take Video</button>
            <button class="send-photo-btn" v-if="photoTaken" @click="sendPhoto">Send Photo</button>
        </div>
        <audio ref="shutter" src="/assets/audio/beep.mp3"></audio>
    </div>
</template>

<script>
    export default {
        props: {
            onlineUser: {
                type: Object,
                required: true
            }
        },
        computed: {
            auth() {
                return this.$store.getters.auth
            },
        },
        data() {
            return {
                showCountDownCount: false,
                countDown: 3,
                photoTaken: false,
            }
        },
        mounted() {
            this.showPhoto()
        },
        methods: {
            showPhoto() {
                let vm = this
                let video = this.$refs.video
                if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {

                    navigator.mediaDevices.getUserMedia({
                        video: true
                    }).then(function (stream) {

                        video.srcObject = stream,
                            vm.recordedStrem = stream,
                            video.play()
                    })
                }
            },
            emitTakeVideo() {
                this.$emit("takeVideo")
            },
            sendPhoto() {
                let vm = this
                let canvas = this.$refs.photoHolder
                var image = canvas.toDataURL("image/png")
                let outgoingMessage = {
                    to: vm.onlineUser,
                    from: vm.auth.userDetails,
                    message: image,
                    type: "img"
                }
                vm.$store.dispatch("sendChatMessage", outgoingMessage).then(() => {

                })
            },
            resetCamera() {
                this.photoTaken = false,
                    this.$nextTick(function () {
                        this.showPhoto()
                    })
            },
            takePhoto() {
                let canvas = this.$refs.photoHolder
                let video = this.$refs.video
                let context = canvas.getContext('2d')
                context.drawImage(video, 0, 0, 466, 350)
                this.photoTaken = true
            },
            showCountDown() {
                let vm = this
                vm.showCountDownCount = true
                let myVar = setInterval(() => {
                    vm.countDown--
                    if (vm.countDown < 0) {
                        clearInterval(myVar)
                        vm.countDown = 3
                        vm.showCountDownCount = false,
                            vm.takePhoto()
                        vm.mediaRecorded = true
                        vm.playShutterSound()
                    }
                }, 2000)

            },
            playShutterSound() {
                let audio = this.$refs.shutter
                audio.play()
            }
        },

    }
</script>
<style lang="scss">
    .media-holder {
        width: 100%;
        display: flex;
        padding: 1.5rem;
        flex-direction: column;
        video {
            align-self: center;
        }

        .custom-modal-footer {
            margin-top: 15px;
            display: flex;
            justify-content: space-between;
            padding-top: 18px;
            border-top: 1px solid #e9ecef;

            .send-photo-btn {
                background-color: #3578E5;
                border-radius: 5px;
                border-width: thin;
                color: #ffffff
            }
        }
    }
</style>
