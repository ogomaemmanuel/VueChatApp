<template>
<div>
    <figure>
        <video ref="localVideo"></video>
        <figcaption>
            <p>Local Video</p>
        </figcaption>
    </figure>
    <figure>
        <video  ref="remoteVideo"></video>
        <figcaption>
            <p>Remote Video</p>
        </figcaption>
    </figure>
</div>
</template>

<script>
export default {
    data () {
        return {
            localVideo: null,
            remoteVideo: null,
            localStream: null,
            localPeerConnection: null,
            remotePeerConnection: null,
            servers: null
        }
    },
    created () {},
    mounted () {
        let vm = this
        this.localVideo = this.$refs.localVideo
        this.remoteVideo = this.$refs.remoteVideo
        navigator.getUserMedia({
                audio: true,
                video: true
            },
            stream => {
                vm.localVideo.srcObject = stream
                vm.localStream = stream
                vm.localVideo.play()
                vm.localVideo.muted = true
                vm.localPeerConnection = new RTCPeerConnection(vm.servers)
                vm.localPeerConnection.onicecandidate = vm.gotLocalIceCandidate
                vm.localPeerConnection.addStream(vm.localStream)
                vm.localPeerConnection.createOffer(vm.gotLocalDescription, (error) => {
                    console.log(error)
                })
                vm.remotePeerConnection = new RTCPeerConnection(vm.servers)
                vm.remotePeerConnection.onicecandidate = vm.gotRemoteIceCandidate
                vm.remotePeerConnection.onaddstream = vm.gotRemoteStream
                vm.remotePeerConnection.createAnswer(vm.gotRemoteDescription, (error) => {
                    console.log(error)
                })
            },
            error => {
                console.log(error)
            }
        )
    },
    methods: {
        gotLocalDescription (description) {
            let vm = this
            this.localPeerConnection.setLocalDescription(description)
            this.remotePeerConnection.setRemoteDescription(description)
            this.remotePeerConnection.createAnswer(vm.gotRemoteDescription, error => {
                console.log(error)
            })
        },
        gotRemoteDescription (description) {
            let vm = this
            vm.remotePeerConnection.setLocalDescription(description)
            vm.localPeerConnection.setRemoteDescription(description)
        },
        gotLocalIceCandidate (event) {
            let vm = this
            //console.log("gotLocalIceCandidate",event)
            if (event.candidate) {
                // Add candidate to the remote PeerConnection
                vm.remotePeerConnection.addIceCandidate(
                    new RTCIceCandidate(event.candidate)
                )
                /// console.log(event.candidate.candidate)
            }
        },
        gotRemoteIceCandidate (event) {
            let vm = this
            // console.log("gotRemoteIceCandidate",event)
            if (event.candidate) {
                // Add candidate to the local PeerConnection
                vm.localPeerConnection.addIceCandidate(
                    new RTCIceCandidate(event.candidate)
                )
                // console.log(event.candidate.candidate)
            }
        },
        gotRemoteStream (event) {
            console.log("gotRemote Stream", event)
            let vm = this
            vm.remoteVideo.srcObject = event.stream
            vm.remoteVideo.play()
        },
        hangup () {
            let vm = this
            vm.localPeerConnection.close()
            vm.remotePeerConnection.close()
            vm.localPeerConnection = null
            vm.remotePeerConnection = null
        }
    }
}
</script>

<style lang="scss">
figure {
    display: inline-block
}
</style>
