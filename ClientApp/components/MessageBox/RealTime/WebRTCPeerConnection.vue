<template>
    <div>
        <figure>
            <video ref="localVideo"></video>
            <figcaption>
                <p>Local Video</p>
            </figcaption>
        </figure>
        <figure>
            <video ref="remoteVideo"></video>
            <figcaption>
                <p>Remote Video</p>
            </figcaption>
        </figure>
    </div>
</template>

<script>
    export default {
        props: {
            onlineUser: {}
        },
        data() {
            return {
                localVideo: null,
                remoteVideo: null,
                localStream: null,
                localPeerConnection: null,
                remotePeerConnection: null,
                servers: null
            }
        },
        created() {
        },
        mounted() {
            let vm = this
            this.localVideo = this.$refs.localVideo;
            this.remoteVideo = this.$refs.remoteVideo;
            navigator.getUserMedia({
                    audio: true,
                    video: true
                },
                stream => {
                    vm.localVideo.srcObject = stream;
                    vm.localStream = stream;
                    vm.localVideo.play();
                    vm.localVideo.muted = true
                    vm.localPeerConnection = new RTCPeerConnection(
                        {
                            iceServers: [     // Information about ICE servers - Use your own!
                                {
                                    urls: "stun:stun4.l.google.com:19302"
                                }
                            ]
                        }
                    );
                    vm.localPeerConnection.onicecandidate = vm.handleICECandidateEvent;
                    vm.localPeerConnection.addStream(vm.localStream)
                    //vm.localPeerConnection.createOffer(vm.gotLocalDescription, (error) => {
                    //   console.log(error)
                    //})
                    //vm.remotePeerConnection = new RTCPeerConnection(vm.servers)
                    // vm.remotePeerConnection.onicecandidate = vm.gotRemoteIceCandidate
                    // vm.remotePeerConnection.onaddstream = vm.gotRemoteStream
                    //vm.remotePeerConnection.createAnswer(vm.gotRemoteDescription, (error) => {
                    //    console.log(error)
                    // })
                },
                error => {
                    console.log(error)
                }
            )
        },
        methods: {
            gotLocalDescription(description) {
                let vm = this
                this.localPeerConnection.setLocalDescription(description)
                this.remotePeerConnection.setRemoteDescription(description)
                this.remotePeerConnection.createAnswer(vm.gotRemoteDescription, error => {
                    console.log(error)
                })
            },
            gotRemoteDescription(description) {
                let vm = this
                vm.remotePeerConnection.setLocalDescription(description)
                vm.localPeerConnection.setRemoteDescription(description)
            },
            handleICECandidateEvent(event) {
                let vm = this;
                if (event.candidate) {
                    sendToServer({
                        type: "candidate",
                        to: vm.onlineUser.id,
                        candidate: event.candidate
                    });
                }


                //console.log("gotLocalIceCandidate",event)
                if (event.candidate) {
                    // Add candidate to the remote PeerConnection
                    vm.remotePeerConnection.addIceCandidate(
                        new RTCIceCandidate(event.candidate)
                    )
                    /// console.log(event.candidate.candidate)
                }
            },
            gotRemoteIceCandidate(event) {
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
            gotRemoteStream(event) {
                console.log("gotRemote Stream", event);
                let vm = this;
                vm.remoteVideo.srcObject = event.stream;
                vm.remoteVideo.play();
            },
            hangup() {
                let vm = this
                vm.localPeerConnection.close();
                vm.remotePeerConnection.close();
                vm.localPeerConnection = null;
                vm.remotePeerConnection = null;
            },
            call() {
                let vm = this;
                this.localPeerConnection.createOffer().then(function (offer) {
                    return localPeerConnection.setLocalDescription(offer);
                })
                    .then(function () {
                        sendToServer({
                            to: vm.onlineUser.id,
                            from: targetUsername,
                            type: "offer",
                            sdp: vm.localPeerConnection
                        });
                    })
            },
            answer(msg) {
                let vm = this;
                let targetUsername = msg.name;
                let desc = new RTCSessionDescription(msg.sdp);
                this.localPeerConnection.setRemoteDescription(desc).then(function () {
                    return navigator.mediaDevices.getUserMedia({
                        audio: true,
                        video: true
                    });
                })
                    .then(function (stream) {
                        let localStream = stream;
                        vm.localVideo.srcObject = localStream;

                        localStream.getTracks().forEach(track => vm.localPeerConnection.addTrack(track, localStream));
                    })
                    .then(function () {
                        return vm.localPeerConnection.createAnswer();
                    })
                    .then(function (answer) {
                        return vm.localPeerConnection.setLocalDescription(answer);
                    })
                    .then(function () {
                        let msg = {
                            from: me,
                            to: targetUsername,
                            type: "answer",
                            sdp: vm.localPeerConnection.localDescription
                        };

                        sendToServer(msg);
                    });

            }
        }
    }
</script>

<style lang="scss">
    figure {
        display: inline-block
    }
</style>
