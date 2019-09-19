<template>
    <div class="payment-transaction-list">
        <h2>Payment transactions</h2>
        <table>
            <thead>
            <tr>
                <th>Public Id</th>
                <th>Order</th>
                <th>Customer</th>
                <th>Date</th>
                <th>Method Name</th>
                <th>Type</th>
                <th>Status</th>
                <th>Value</th>
            </tr>
            </thead>
            <tbody>
            <tr
                    is="payment-transaction-item"
                    v-for="n in 10"
                    :key="n"/>
            </tbody>
        </table>
    </div>
</template>

<script>
    import PaymentTransactionItem from "./PaymentTransactionItem";
    export default {
        components: {
            "payment-transaction-item": PaymentTransactionItem
        },
        data() {
            return {};
        }
    };
</script>

<style lang="scss">
    @import "../../../assets/sass/_mixins.scss";
    .payment-transaction-list {
        h2 {
            margin-bottom: 20px;
            font-weight: 300;
        }
        table {
            @include tableFormat;
            tbody {
                tr {
                    td {
                        .order-customer-details {
                            display: flex;
                        }
                    }
                    .fa {
                        align-self: center;
                        font-size: 3rem;
                        margin-right: 10px;
                    }
                }
            }
        }
    }
</style>