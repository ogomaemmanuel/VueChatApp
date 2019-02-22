<template>
    <div class="zone-list">
        <button class="btn btn-primary">Add Zone </button>
        <!-- TODO handle create and Edit zone, zone creation will either be inline or form ontop of the table -->
        <table>
            <thead>
                <tr>
                    <th>zone</th>
                    <th />
                </tr>
            </thead>
            <tbody>
                <tr is="zone-item"
                    v-for="zone in zones"
                    :zone="zone"
                    :key="zone.id" />
            </tbody>
        </table>
    </div>
</template>
<script>
import ZoneItem from "./ZoneItem"
export default {
  components: {
    "zone-item": ZoneItem
  },
  data () {
    return {
      zones: [
        {
          id: "1",
          name: "All Addresses (default zone)"
        },
        {
          id: "2",
          name: "Europe"
        },
        {
          id: "3",
          name: "North of United States & Canada"
        },
        {
          id: "4",
          name: "United States"
        }
      ]
    }
  }
}
</script>