<template>
    <div class="order-list">
        <table>
            <thead>
            <tr>
                <th/>
                <th>Order #</th>
                <th>Date</th>
                <th>Customer</th>
                <th>Payment status</th>
                <th>Fulfilment status</th>
                <th>Amount</th>
                <th/>
            </tr>
            </thead>
            <tbody>
            <tr
                    is="order-item"
                    v-for="n in 10"
                    :key="n"/>
            </tbody>
        </table>

    </div>
</template>

<script>
    import OrderItem from "./OrderItem";
    export default {
        components: {
            "order-item": OrderItem
        },
        data() {
            return {};
        }
    };
</script>

<style lang="scss">
    @import "../../../assets/sass/_mixins.scss";
    .order-list {
        table {
            @include tableFormat;
            tbody {
                td {
                    select {
                        min-height: 40px;
                        min-width: 100%;
                        border-radius: 5px;
                    }
                }
            }
        }
    }
</style>