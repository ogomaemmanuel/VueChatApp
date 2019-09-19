<template>
    <div class="order-statistics-list">
        <div>
            <h2>Statistics</h2>
        </div>
        <el-tabs
                v-model="activeName"
                @tab-click="handleClick">
            <el-tab-pane
                    label="Order Statistics"
                    name="first">
                <table>
                    <thead>
                    <tr>
                        <th/>
                        <th>Today</th>
                        <th>This Weeek</th>
                        <th>This Month</th>
                        <th>This Year</th>
                        <th>All Time</th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr is="statistic-item"/>
                    </tbody>
                </table>
            </el-tab-pane>
            <el-tab-pane
                    label="Best Sellers"
                    name="second">
                <p>This section lists 10 best selling products for today, last week, last month, last year and all time.</p>
                <h2>
                    Top 10 Products
                </h2>
                <best-seller-item-list/>
            </el-tab-pane>
        </el-tabs>
    </div>
</template>

<script>
    import StatisticItem from "./StatisticItem";
    import BestSellerItemList from "./BestSellerItemList";
    export default {
        components: {
            "statistic-item": StatisticItem,
            "best-seller-item-list": BestSellerItemList
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
    .order-statistics-list {
        table {
            @include tableFormat;
        }
    }
</style>