<template>

    <div class="modal is-active">
        <div class="modal-background"></div>
        <div class="modal-card">
            <header class="modal-card-head">
                <p class="modal-card-title">Modal title</p>
            </header>
            <section class="modal-card-body">
                <div>
                    <div class="video-wrapper">
                        <figure>
                            <video ref="localVideo" autoplay muted></video>
                            <figcaption>
                                <p>Local Video</p>
                            </figcaption>
                        </figure>
                        <figure>
                            <video ref="remoteVideo" autoplay></video>
                            <figcaption>
                                <p>Remote Video</p>
                            </figcaption>
                        </figure>
                    </div>
                    <div class="call-controls">
                        <button :disabled="disableHangUpButton" @click="createAnswer" class="btn btn-success" ref="hangUpButton">Accept</button>
                        <button :disabled="disableHangUpButton" @click="hangUpCall" class="btn btn-danger" ref="hangUpButton">Reject/Hang Up</button>
                    </div>
                </div>
            </section>
        </div>
    </div>


</template>

<script>
    //https://www.html5rocks.com/en/tutorials/webrtc/infrastructure/
    // Alice creates an RTCPeerConnection object.
    //     Alice creates an offer (an SDP session description) with the RTCPeerConnection createOffer() method.
    //     Alice calls setLocalDescription() with his offer.
    //     Alice stringifies the offer and uses a signaling mechanism to send it to Eve.
    //
    //     Eve calls setRemoteDescription() with Alice's offer, so that her RTCPeerConnection knows about Alice's setup.
    //     Eve calls createAnswer(), and the success callback for this is passed a local session description: Eve's answer.
    // Eve sets her answer as the local description by calling setLocalDescription().
    //     Eve then uses the signaling mechanism to send her stringified answer back to Alice.
    //     Alice sets Eve's answer as the remote session description using setRemoteDescription().
    
    import {EventBus} from "../../event-bus";

    export default {
        props: {
            onlineUser: {},
            webRtcMessage:{}
        },
        computed: {
            auth() {
                return this.$store.getters.auth
            },
        },

        data() {
            return {
                localVideo: null,
                remoteVideo: null,
                hangUpButton: null,
                localStream: null,
                myPeerConnection: null,
                disableHangUpButton:false,
                // remotePeerConnection: null,
                servers: null
            }
        },
        created() {
        },
        mounted() {
            let vm = this;
            this.localVideo = this.$refs.localVideo;
            this.remoteVideo = this.$refs.remoteVideo;
            this.hangUpButton = this.$refs.hangUpButton;

            vm.myPeerConnection = new RTCPeerConnection(
                {
                    iceServers: [
                        {
                            urls: "stun:stun4.l.google.com:19302"
                        }
                    ]
                }
            );
            vm.myPeerConnection.ontrack=vm.handleTrackEvent;
            //  vm.myPeerConnection.on
            vm.myPeerConnection.onicecandidate =vm.gotIceCandidate;
            EventBus.$on("webRtcSignalReceived",(msg)=>{
                if(msg.type=="candidate"){
                    vm.handleIceCandidate(msg);
                }
            });
            
            
            
            //https://developer.mozilla.org/en-US/docs/Web/API/WebRTC_API/Signaling_and_video_calling
            //https://github.com/mdn/samples-server/blob/master/s/webrtc-from-chat/chatclient.js
        },
        methods: {
            createAnswer() {
                let vm = this;
                let mediaConstraints = {
                    audio: true, // We want an audio track
                    video: true ,// ...and we want a video track
                };
               
               // vm.myPeerConnection.onicegatheringstatechange =(event)=>{
                //    console.log("gathering ice candidate");
                //};

               
                console.log("vm.webRtcMessage.sdp",vm.webRtcMessage.sdp);
                vm.myPeerConnection.setRemoteDescription(new RTCSessionDescription(vm.webRtcMessage.sdp)).then(()=>{
                    return navigator.mediaDevices.getUserMedia(mediaConstraints)}).then((stream)=>{
                    vm.$refs.localVideo.srcObject = stream;

                    stream.getTracks().forEach(function(track) {
                        vm.myPeerConnection.addTrack(track, stream);
                    });
                    //return vm.myPeerConnection.addStream(stream);
                }).then(()=>{

                  return  vm.myPeerConnection.createAnswer({
                        offerToReceiveAudio: true,
                        offerToReceiveVideo: true
                    }).then((answer) => {
                        vm.myPeerConnection.setLocalDescription(answer).then(() => {
                            vm.sendToServer({
                                to: vm.webRtcMessage.from,
                                from: vm.webRtcMessage.to, //vm.auth.userDetails.id,
                                sdp: answer,
                                type: "answer"
                            })
                        });
                    });
                })
                

            },
            handleTrackEvent(event) {
                console.log("answer component:got video stream remotely");
                this.$refs.remoteVideo.srcObject = event.streams[0];
               //this.$refs.remoteVideo.play(); //= event.streams[0];
               // this.disableHangUpButton = false;
            },
            hangUpCall(){},
            gotIceCandidate(event) {
                console.log("got ice candidate");
                let vm = this;
                if(event.candidate != null) {
                    vm.sendToServer({
                        'type': "candidate",
                         to: vm.webRtcMessage.from,
                         from: vm.webRtcMessage.to, //vm.auth.userDetails.id,
                         candidate:event.candidate
                    });
                }
            },
            handleIceCandidate(msg){
                console.log("adding ice candidate", msg);
                this.myPeerConnection.addIceCandidate(new RTCIceCandidate(msg.candidate))
            },
            sendToServer(msg) {
                axios.post("/api/chats/web-rtc-signal", msg).then(resp => {
                    console.log("signaling done");
                })
            }
        }
    }
</script>

<style lang="scss" scoped>
    .video-wrapper {
        width: 100%;
        display: flex;
        //justify-content: space-between;
        figure {
            flex-basis: 50%;
            display: flex;
            flex-direction: column;

            video {
                flex: 1;
            }

            figcaption {
                align-self: center;
            }
        }

    }

    .call-controls {
        display: flex;
        justify-content: center;
    }
</style>