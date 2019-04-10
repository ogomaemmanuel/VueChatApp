/* eslint-disable prettier/prettier */
<template>
    <tr>
        <td :class="role.active?'text-primary':''">
            <i class="fa fa-power-off"/>
        </td>

        <td>{{ role.name }}</td>
        <td>
            <a href=""><i class="fa fa-eye"/></a>
            <a href=""><i class="fa fa-edit"/></a>
            <a href=""><i class="fa fa-trash"/></a>
        </td>
    </tr>
</template>

<script>
    export default {
        props: {
            role: {
                default: null,
                type: Object
            }
        },
        data() {
            return {};
        }
    };
</script>

<style lang="scss">
</style>