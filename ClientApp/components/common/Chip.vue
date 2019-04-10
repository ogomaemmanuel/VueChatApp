<template>
    <div class="chip">
        {{ chip.text }} <i
            class="fa fa-times"
            @click.prevent="removeChip"/>
    </div>
</template>
<script>
    export default {
        props: {
            chip: {
                default: null,
                type: Object
            }
        },
        data() {
            return {};
        },
        methods: {
            removeChip() {
                this.$emit("chipRemoved", this.chip);
            }
        }
    };
</script>
<style lang="scss">
    .chip {
        display: flex;
        border-radius: 5px;
        background: #e0e0e0;
        margin: 4px;
        min-width: 80px;
        min-height: 1rem;
        border: 1px solid #ccc;
        margin-bottom: 2px;
        align-content: space-around;
        align-items: center;
        padding: 0px 4px;

        i {
            cursor: pointer;
            opacity: 0.56;
            margin-left: 8px;
        }
    }
</style>