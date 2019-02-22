<template>
    <tr>
        <td>
            <input type="checkbox">
        </td>
        <td>
            {{ state.name }}
        </td>
        <td>
            {{ state.code }}
        </td>
        <td>
            <a href="">
                <i class="fa fa-trash" />
            </a>
        </td>
    </tr>
</template>
<script>
export default {
  props: {
    state: {
      type: Object,
      default: null
    }
  },
  data () {
    return {}
  }
}
</script>