<template>
<div class="media-holder">
    <video v-if="videoRecording"  ref="video" id="video" width="466px" height="350px" autoplay></video>
    <video v-show="!videoRecording" ref="recoredVideoHolder" id="recoredVideoHolder" width="466px" height="350px"></video>
    <div class="custom-modal-footer" slot="custom-modal-footer">
        <button @click="emitShowPhoto" v-if="!videoRecording">Retake</button>
        <button class="stop-video-btn" @click="stopRecordingVideo" v-if="videoRecording">Stop Video</button>
        <button @click="sendVideoToServer" v-if="!videoRecording">Send Video</button>
    </div>
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
    data () {
        return {
            videoRecording: true,
            showRecordedVideo: false,
            recordedStream: null,
            recorder: null,
            recordeMediaType: "",
            recordedVideoChunks: [],
            videoBlob: null
        }
    },
    mounted () {
        this.openCamera()
    },
    computed: {
        auth () {
            return this.$store.getters.auth
        },
    },
    methods: {
        openCamera () {
            let vm = this
            let video = this.$refs.video
            if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {

                navigator.mediaDevices.getUserMedia({
                    video: true,
                    audio: true
                }).then(function (stream) {
                    video.srcObject = stream,
                        vm.recordedStream = stream,
                        video.play()
                    //muted removes the echo effect
                    video.muted = true
                    return
                }).then(() => {
                    vm.startRecordingVideo()
                })
            }
        },
        startRecordingVideo () {
            this.recorder = new MediaRecorder(this.recordedStream)
            let vm = this
            this.recorder.ondataavailable = e => {
                vm.recordedVideoChunks.push(e.data)
            }
            this.recorder.onstop = function () {
                vm.videoBlob = new Blob(vm.recordedVideoChunks, {
                    type: "video/mp4"
                })
                vm.recordedVideoChunks = []
                vm.videoRecording = false
                vm.$nextTick(function () {
                    let video = vm.$refs.recoredVideoHolder
                    video.src = URL.createObjectURL(vm.videoBlob)
                    video.play()
                    video.controls = true
                })
            }
            vm.recorder.start()
        },

        stopRecordingVideo () {
            this.recorder.stop()
        },
        emitShowPhoto () {
            this.$emit("takePhoto")
        },
        sendVideoToServer () {
            let vm = this
            let outgoingMessage = {
                to: vm.onlineUser,
                from: vm.auth.userDetails,
                type: "video",
               
            }
          let formData=  vm.createFormData(outgoingMessage,new FormData(),null)
          formData.append('video',vm.videoBlob,"recordedVid.mp4")
          vm.$store.dispatch("sendChatVideoMessage", formData).then(() => {

            })
        },
        createFormData (object, formData, namespace) {
            let vm = this
            formData = formData || new FormData()
            for (let property in object) {
                if (!object.hasOwnProperty(property) || !object[property]) {
                    continue
                }
                const formKey = namespace ? `${namespace}[${property}]` : property
                if (object[property] instanceof Date) {
                    formData.append(formKey, object[property].toISOString())
                } else if (typeof object[property] === 'object' && !(object[property] instanceof File)) {
                    vm.createFormData(object[property], formData, formKey)
                } else {
                    formData.append(formKey, object[property])
                }
            }
            return formData
        }
    },
}
</script>

<style lang="scss">
.media-holder {
    .custom-modal-footer {
        margin-top: 15px;
        display: flex;
        justify-content: space-between;
        padding-top: 18px;
        border-top: 1px solid #e9ecef;

        .stop-video-btn {
            margin: auto
        }
    }
}
</style>
