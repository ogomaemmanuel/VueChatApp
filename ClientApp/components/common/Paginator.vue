<template>
  <div class="pagination-section">
    <div class="pagination-nav pagination-item">
      <button class="btn btn-clear">Previous</button>
      <button class="btn btn-clear">Next</button>
    </div>
    <span 
      class="pagination-item pagination-view-count"
    >Viewing 20 of 1000</span
    >
    <div class="per-page-section pagination-item">
      <select 
        id="" 
        name="per-page">
        <option value="10">10</option>
        <option value="25">25</option>
        <option value="25">50</option>
        <option value="25">100</option>
      </select>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {};
  }
};
</script>
<style lang="scss">
.pagination-section {
  display: flex;
  margin-top: 40px;
  flex-wrap: wrap;
  flex-grow: 1;
  .pagination-item {
    margin: 0 5px;
  }
  .pagination-view-count {
    align-self: center;
  }
  .per-page-section {
    select {
      min-height: 38px;
      padding: 0.375rem 0.75rem;
      text-align: center;
      border-radius: 0.25rem;
    }
  }
}
</style>
