<template>
  <div class="review-list item-listing-page">
    <h2>Product Reviews</h2>
    <!-- <button class="btn btn-primary add-button">Add Review</button> -->
    <review-create />
    <table>
      <thead>
        <tr>
          <th />
          <th>Product</th>
          <th>Reviewer</th>
          <th>Review</th>
          <th>Rating</th>
          <th>Status</th>
          <th>Date</th>
          <th />
        </tr>
      </thead>
      <tbody>
        <tr is="review" />
      </tbody>
    </table>
  </div>
</template>

<script>
import Review from "./Review";
import ReviewCreate from "./ReviewCreate";
export default {
  components: {
    review: Review,
    "review-create": ReviewCreate
  }
};
</script>
<style lang="scss">
@import "../../../assets/sass/_mixins.scss";
.review-list {
  @include addButton;
  @include tableFormat;
}
</style>
