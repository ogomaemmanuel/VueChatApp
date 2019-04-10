<template>
    <tr>
        <td>
            <input type="checkbox">
            <i class="fa fa-power-off"/>
        </td>
        <td>{{ country.name }}</td>
        <td>{{ country.code }}</td>
        <td>
            <a href=""
               @click.prevent="goToStateList()">
                {{ country.stateCount>0?"Edit States ("+country.stateCount+")":"Add States" }}
            </a>
        </td>
    </tr>
</template>

<script>
    export default {
        props: {
            country: {
                type: Object,
                default: null
            }
        },
        data() {
            return {};
        },
        methods: {
            goToStateList() {
                this.$router.push("state-list");
            }
        }
    };
</script>