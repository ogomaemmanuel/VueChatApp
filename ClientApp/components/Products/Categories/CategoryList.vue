<template>
  <div class="category-list item-listing-page">
    <h2>Manage Product Categories</h2>
    <button class="btn btn-primary add-category add-button">
      Add Category
    </button>
    <table>
      <thead>
        <tr>
          <th />
          <th />
          <th>Category</th>
          <th>Featured</th>
          <th>Subcat</th>
          <th>Products</th>
          <th />
        </tr>
      </thead>
      <tbody>
        <tr is="category-create">
          <td 
            slot="delete-action-slot" 
            class="action-right">
            <span>
              <i class="fa fa-trash" />
            </span>
          </td>
        </tr>
        <tr is="product-category" />
      </tbody>
    </table>
    <paginator />
  </div>
</template>

<script>
import ProductCategory from "./Category";
import Paginator from "../../../Paginator";
import CategoryCreate from "./CategoryCreate";
export default {
  components: {
    "product-category": ProductCategory,
    paginator: Paginator,
    "category-create": CategoryCreate
  },
  data() {
    return {};
  }
};
</script>

<style lang="scss">
@import "../../../assets/sass/_mixins.scss";

.category-list {
  .add-button {
    margin-bottom: 40px;
    margin-top: 40px;
  }

  table {
    @include tableFormat;
  }
}
</style>
