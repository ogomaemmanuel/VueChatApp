<template>
    <div class="product-list">
        <span><h2>Products</h2></span>
        <div class="search-conditions-box">
            <div class="search-conditions">
                <input
                        class="search-input form-item"
                        name="search"
                        type="text" >
                <input
                        class="form-item"
                        type="text" >
                <input
                        class="form-item"
                        type="text" >
                <button class="btn form-item btn-primary">search</button>
            </div>
        </div>
        <div>
            <button class="btn btn-primary add-product add-button">
                Add Product
            </button>
        </div>
        <table>
            <thead>
            <tr>
                <th><input type="checkbox" ></th>
                <th>Sku</th>
                <th>Name</th>
                <th>Model</th>
                <th>Category</th>
                <th>Price</th>
                <th>In Stock</th>
                <th></th>
            </tr>
            </thead>
            <tbody>
            <tr
                    is="product"
                    v-for="n in 2"
                    :key="n"></tr>
            </tbody>
        </table>
        <paginator />
    </div>
</template>
<script>
    import Product from "./Product";
    import Paginator from "../common/Paginator";
    export default {
        components: {
            product: Product,
            paginator: Paginator
        },
        data() {
            return {};
        }
    };
</script>

<style lang="scss">
    @import "../../assets/sass/_mixins.scss";
    .product-list {
        .add-product {
            margin-bottom: 40px;
        }
        .search-conditions-box {
            border: 1px solid #d4dee4;
            background: #ebf7fe;
            position: relative;
            margin-bottom: 40px;
            padding: 18px 18px 18px 18px;
            .search-conditions {
                display: flex;
                width: 100%;
                flex-wrap: wrap;
                align-items: center;
                justify-content: space-around;
                .form-item {
                    margin: 0px 5px;
                }
                .search-input {
                    flex: 1;
                }

                @media screen and (max-width: 980px) {
                    flex-direction: column;
                    width: 100%;

                    .form-item {
                        width: 100%;
                        margin-top: 5px;
                    }
                }
            }
        }
        table {
            @include tableFormat;
        }

        @media screen and(max-width: 980px) {
            .add-product {
                margin-bottom: 40px;
            }
        }
    }
</style>