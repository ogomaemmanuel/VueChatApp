<template>
    <div class="order-statuses">
        <h2>Order Statuses</h2>
        <el-tabs
                v-model="activeName"
                @tab-click="handleClick">
            <el-tab-pane
                    label="Payment Statuses"
                    name="first">
                <table>
                    <thead>
                    <tr>
                        <th/>
                        <th>Name</th>
                        <th>Orders</th>
                        <th/>
                    </tr>
                    </thead>
                    <tbody>
                    <tr
                            is="order-status-item"
                            v-for="n in 10"
                            :key="n"/>
                    </tbody>
                </table>
            </el-tab-pane>
            <el-tab-pane
                    label="Fulfilment statuses"
                    name="second">
                <table>
                    <thead>
                    <tr>
                        <th/>
                        <th>Name</th>
                        <th>Orders</th>
                        <th/>
                    </tr>
                    </thead>
                    <tbody>
                    <tr
                            is="order-status-item"
                            v-for="n in 10"
                            :key="n"/>
                    </tbody>
                </table>
            </el-tab-pane>
        </el-tabs>
    </div>
</template>

<script>
    import OrderStatusItem from "./OrderStatusItem";
    export default {
        components: {
            "order-status-item": OrderStatusItem
        },
        data() {
            return {
                activeName: "first"
            };
        },
        methods: {
            handleClick() {}
        }
    };
</script>

<style lang="scss">
    @import "../../../assets/sass/_mixins.scss";
    .order-statuses {
        table {
            @include tableFormat;
            /* Responsive table */
            @media screen and (max-width: 640px) {
                thead {
                    display: none;
                }
                tbody {
                    tr {
                        display: block;
                        margin-bottom: 40px;
                        //    min-width: 100%;
                        td {
                            display: flex;
                            min-width: 100%;
                        }
                        td::before {
                            content: attr(data-label);
                            margin-right: 40px;
                            font-weight: bold;
                        }
                    }
                }
            }
        }
    }
</style>