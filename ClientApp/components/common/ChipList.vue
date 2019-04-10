<template>
    <div
            class="chip-container"
            tabindex="0"
            @blur="hideSelector">
        <div
                class="chip-input"
                @click="showSector=true">
            <chip
                    v-for="selectedChip in selectedChips"
                    :chip="selectedChip"
                    :key="selectedChip.id"
                    @chipRemoved="removeChip"/>
        </div>
        <div
                v-if="showSector"
                class="chip-selector">
            <ul>
                <li
                        v-for="chipDt in selectList"
                        :key="chipDt.id"
                        class="chip-option"
                        @click="setSelectedChip(chipDt)">
                    <div>{{ chipDt.text }}</div>
                </li>
            </ul>
        </div>
    </div>
</template>
<script>
    import Chip from "./Chip";
    export default {
        components: {
            chip: Chip
        },
        props: {
            selectList: {
                type: Array,
                default: null
            }
        },
        data() {
            return {
                selectedChips: [],
                showSector: false
            };
        },
        methods: {
            setSelectedChip(chip) {
                if (
                    !this.selectedChips.find(selectedChip => selectedChip.id == chip.id)
                ) {
                    this.selectedChips.push(chip);
                }
            },
            setFocus() {},
            removeChip(chip) {
                this.selectedChips = this.selectedChips.filter(
                    selectedChip => selectedChip.id !== chip.id
                );
            },
            hideSelector() {
                this.showSector = false;
            }
        }
    };
</script>

<style lang="scss">
    .chip-container {
        position: relative;
        .chip-input {
            min-height: 40px;
            min-width: 100%;
            border-radius: 5px;
            border-width: thin;
            border-style: solid;
            border-color: #d4d9de;
            background-color: white;
            display: flex;
            flex-wrap: wrap;
            align-content: space-between;
            padding: 5px;
        }
        &:hover {
            .chip-selector {
                display: block;
            }
        }
        .chip-selector {
            border-radius: 5px;
            max-height: 254px;
            overflow-y: scroll;
            z-index: 1;
            // border-top: thin;
            // border-top-style: solid;
            position: absolute;
            background-color: white;
            color: black;
            width: 100%;
            box-shadow: 0px 8px 8px 0px rgba(0, 0, 0, 0.2);
            ul {
                list-style-type: none;
                padding: 0%;
                display: block;
                li {
                    display: block;
                    padding: 5px;
                    &:hover {
                        background-color: blue;
                        color: white;
                    }
                }
            }
        }
    }
</style>