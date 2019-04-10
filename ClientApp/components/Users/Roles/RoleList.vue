<template>
    <div class="role-list">
        <h2>Roles</h2>
        <role-create/>

        <table>
            <thead>
            <tr>
                <th/>
                <th>Name</th>
                <th/>
            </tr>
            </thead>
            <tbody>
            <tr
                    is="role_item"
                    v-for="role in roles"
                    :role="role"
                    :key="role.id"/>
            </tbody>
        </table>
    </div>
</template>
<script>
    import RoleCreate from "./RoleCreate";
    import RoleItem from "./RoleItem";

    export default {
        components: {
            role_item: RoleItem,
            "role-create": RoleCreate
        },
        data() {
            return {
                roles: [
                    {
                        active: true,
                        id: "1",
                        name: "Coupons management",
                        slug: "coupons_management"
                    },
                    {
                        active: true,
                        id: "2",
                        name: "Coupons management",
                        slug: "coupons_management"
                    },
                    {
                        active: false,
                        id: "3",
                        name: "Content management",
                        slug: "content_management"
                    },
                    {
                        active: true,
                        id: "4",
                        name: "Volume discounts management ",
                        slug: "volume_discounts_management "
                    }
                ]
            };
        }
    };
</script>
<style lang="scss">
    @import "../../../assets/sass/_mixins.scss";

    .role-list {
        .role-create {
            margin-top: 30px;
            margin-bottom: 30px;
        }

        table {
            @include tableFormat;
        }
    }
</style>