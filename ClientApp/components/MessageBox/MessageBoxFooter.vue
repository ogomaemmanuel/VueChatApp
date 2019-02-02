<template>
<div class="message-box-footer">
    <input
       v-model="message"
       placeholder="Type a message"
       @keyup.enter="sentMessage"
       type="text"
       />
    <div class="chat-message-icons">
        <div class="chat-message-icons-left">
            <i class="fa fa-file-image-o fa-2x"></i>
            <i class="fa fa-paperclip fa-2x"></i>
            <div class="iconPreview"></div>

            <Camera :online-user="onlineUser" />
            <div tabindex="-1" @blur.self="showEmojiPicker=false" class="emoji-picker">
                <i  @click.self="showEmojiPicker=true" class="fa fa-smile-o fa-2x"></i>
                <Picker emoji="point_up" title="Pick you emoji ..." @select="addEmoji" v-if="showEmojiPicker" />
            </div>
            <div class="gif-povover-wrapper">
                <Gifs />
            </div>
        </div>
        <div class="chat-message-icons-right">
            <i class="fa fa-thumbs-o-up fa-2x"></i>
        </div>
    </div>
</div>
</template>

<script>
import Camera from "./Camera/CameraModal"
import Gifs from "./Gif/Gifs"
import {
    Picker
} from 'emoji-mart-vue'
export default {
    components: {
        Gifs,
        Picker,
        Camera
    },
    props: {
        onlineUser: {
            type: Object,
            default: null
        }
    },
    data () {
        return {
            message: "",
            showGifPovOver: false,
            showEmojiPicker: false
        }
    },
    created () {
        this.$store.dispatch("getGifs")
    },
    computed: {
        auth () {
            return this.$store.getters.auth
        },
        gifs () {
            return this.$store.getters.gifs
        }
    },
    methods: {
        toggleGifPover () {
            this.showGifPovOver = !this.showGifPovOver
        },
        addEmoji (emoji) {
            this.message = this.message + emoji.native
        },
        sentMessage () {
            let vm = this
            let outgoingMessage = {
                to: vm.onlineUser,
                from: vm.auth.userDetails,
                message: vm.message
            }

            vm.$store.dispatch("sendChatMessage", outgoingMessage).then(() => {
                vm.message = ""
            })
        }
    }
}
</script>

<style lang="scss">
.el-popover {
    overflow: hidden;
}

.message-box-footer {
    z-index: 3;

    input {
        width: 100%;
        min-height: 40px;
        border-style: none;
    }

    .chat-message-icons {
        min-height: 20px;
        margin-bottom: 20px;
        margin-top: 10px;
        display: flex;

        .chat-message-icons-left {
            flex: 1;
            display: flex;

            .iconPreview {
                background-image: url('data:image/svg+xml;base64,PHN2ZyBoZWlnaHQ9JzMwMHB4JyB3aWR0aD0nMzAwcHgnICBmaWxsPSIjMDAwMDAwIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2ZXJzaW9uPSIxLjEiIHg9IjBweCIgeT0iMHB4IiB2aWV3Qm94PSIwIDAgMTAwIDEwMCIgZW5hYmxlLWJhY2tncm91bmQ9Im5ldyAwIDAgMTAwIDEwMCIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSI+PHBhdGggZD0iTTQwLjUsNDRjMC02LjY0Nyw1LTYuNjQ5LDUsMEM0NS41LDUwLjY0Nyw0MC41LDUwLjY0OSw0MC41LDQ0eiBNNTkuNSw0NGMwLTYuNjQ3LTUtNi42NDktNSwwICBDNTQuNSw1MC42NDcsNTkuNSw1MC42NDksNTkuNSw0NHogTTU4LjYsNTUuOGMtNS4zLDMuMTAxLTEyLDMuMTAxLTE3LjMsMGMtMS4wODUtMC42NS0yLjI2MSwxLjA0NC0xLDEuOCAgYzYuMzM0LDMuNTksMTMuNDk3LDMuMzQ0LDE5LjIsMEM2MC43OTgsNTYuOTUxLDU5LjkyMSw1NS4yNzEsNTguNiw1NS44eiBNNzIsMjd2MzljMCwwLjMtMC4xLDAuNS0wLjMsMC43bC05LDkgIEM2Mi41LDc1LjksNjIuMyw3Niw2Miw3NkgzMWMtMS43LDAtMy0xLjMtMy0zVjI3YzAtMS43LDEuMy0zLDMtM2gzOEM3MC43LDI0LDcyLDI1LjMsNzIsMjd6IE0zMSw3NGgyOXYtOWMwLTAuNiwwLjQtMSwxLTFoOVYyNyAgYzAtMC42LTAuNC0xLTEtMUgzMWMtMC42LDAtMSwwLjQtMSwxdjQ2QzMwLDczLjYsMzAuNCw3NCwzMSw3NHogTTY5LjYsNjZINjJ2Ny42TDY5LjYsNjZ6Ij48L3BhdGg+PC9zdmc+')
            }

            .emoji-picker {
                position: relative;

                &:focus {
                    outline: none;
                }

                .emoji-mart {
                    position: absolute;
                    bottom: 100%;
                    z-index: 12;

                }
            }

            i {
                margin-left: 5px;
            }

            .gif-povover-wrapper {
                position: relative;

                .gif-icon {
                    background-image: url('/dist/gif-icon.svg');
                    background-repeat: no-repeat;
                    background-size: cover;
                    height: 40px;
                    width: 40px;
                }

                .gif-pover {
                    opacity: 0;
                    display: block;
                    position: absolute;
                    left: -150px;
                    transform: translate(0, 10px);
                    background-color: #BFBFBF;
                    padding: 1.5rem;
                    box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.26);
                    width: auto;
                }

                .gif-pover:before {
                    position: absolute;
                    z-index: -1;
                    content: '';
                    right: calc(50% - 10px);
                    top: -8px;
                    border-style: solid;
                    border-width: 0 10px 10px 10px;
                    border-color: transparent transparent #BFBFBF transparent;
                    transition-duration: 0.3s;
                    transition-property: transform;
                }
            }
        }
    }
}
</style>
