<template>
<el-popover show="getGifs" placement="top-start" width="300" trigger="click">
    <div class="gif-wrapper">
        <input class="gif-search" @input="updateSearchString" placeholder="Search GIFs across all apps.." type="text">
        <div class="gif-container">
            <img v-for="(gif,index) in gifs" :key="index" :src="gif.url" alt="">
  </div>
        </div>
        <div slot="reference" class="gif-icon fa fa-2x" alt="/dist/gif-icon.svg">
        </div>
</el-popover>
</template>

<script>
import _ from "lodash"
export default {
    data () {
        return {
            searchString: ""
        }
    },
    watch: {
        searchString () {
            this.search()
        }
    },
    created () {
        // this.$store.dispatch("getGifs")
    },
    computed: {
        gifs () {
            return this.$store.getters.gifs
        }
    },
    methods: {
        updateSearchString (newVlaue) {
            this.searchString = newVlaue.target.value
        },
        getGifs () {
            this.$store.dispatch("getGifs")
        },
        search: _.debounce(function () {
            let query = {}

            if (this.searchString.trim()) {
                query.q = this.searchString
                this.$store.dispatch("searchGifs", query)
            } else {
                delete query.q
                this.$store.dispatch("getGifs")
            }
        }, 500)
    }
}
</script>

<style lang="scss">
.gif-wrapper {
    min-width: 100%;
    height: 380px;

    .gif-search {
        width: 100%;
        min-height: 25px;
        border-radius: 5px;
        font-size: 12px;
        font-weight: normal;
        background: transparent;
        border: thin;
        margin: 0;
        outline: 0;
        padding: 0;
        width: 100%;
    }

    .gif-container {
        min-width: 100%;
        height: 100%;
        margin-bottom: 5px;
        overflow-y: scroll;
        z-index: -3;
        overflow-x: hidden;

        img {
            width: 100%;
            height: 150px;
            margin: 2px
        }
    }
}
</style>
