<template>
    <div class="best-sellers">
        <div class="best-seller-filter-section">
            <p>Products</p>
            <a href="">All</a>
            <a href="">Only Available</a>
            <p>For The Period:</p>
            <a href="">All Time</a>
            <a href="">Today</a>
            <a href="">This Week</a>
            <a href="">This Month</a>
            <a href="">This Year</a>
        </div>
        <table>
            <thead>
            <tr>
                <th>Position</th>
                <th>Product</th>
            </tr>
            </thead>
            <tbody>
            <tr is="best-seller-item"/>
            </tbody>
        </table>
    </div>
</template>

<script>
    import BestSellerItem from "./BestSellerItem";
    export default {
        components: {
            "best-seller-item": BestSellerItem
        },
        data() {
            return {};
        }
    };
</script>

<style lang="scss">
    @import "../../../assets/sass/_mixins.scss";
    .best-sellers {
        .best-seller-filter-section {
            display: flex;
        }
        table {
            @include tableFormat;
        }
    }
</style>