<template>
    <div class="state-list">
        <button class="btn primary">Add State</button>
        <table>
            <thead>
                <tr>
                    <th />
                    <th>State</th>
                    <th>Code</th>
                    <th />
                </tr>
            </thead>
            <tbody>
                <tr is="state-item"
                    v-for="state in states"
                    :state="state"
                    :key="state.id" />
            </tbody>
        </table>

    </div>
</template>

<script>
import StateItem from "./StateItem"
export default {
  components: {
    "state-item": StateItem
  },
  data () {
    return {
      states: [
        {
          id: "1",
          name: "Alabama",
          code: "AL"
        },
        {
          id: "2",
          name: "Alaska",
          code: "AK"
        },
        {
          id: "3",
          name: "Alabama",
          code: "AL"
        },
        {
          id: "4",
          name: "Arizona",
          code: "AZ"
        },
        {
          id: "5",
          name: "Arkansas",
          code: "AR"
        }
      ]
    }
  }
}
</script>

<style lang="scss">
    @import "../../../../assets/sass/_mixins.scss";

    .state-list {
        table

    {
        @include tableFormat;
    }
    }
</style>