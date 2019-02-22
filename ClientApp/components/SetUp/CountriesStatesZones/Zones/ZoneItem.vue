<template>
    <tr>
        <td>
            {{ zone.name }}
        </td>
        <td>
            <a href=""
               @click.prevent>
                <i class="fa fa-trash" />
            </a>
        </td>
    </tr>
</template>
<script>
export default {
  props: {
    zone: {
      type: Object,
      default: null
    }
  },
  data () {
    return {}
  }
}
</script>