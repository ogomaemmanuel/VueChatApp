<template>
    <tr>
        <td>1</td>
        <td>{{ permission.slug }}</td>
        <td>{{ permission.name }}</td>
        <td>{{ permission.description }}</td>
    </tr>
</template>

<script>
export default {
  props: {
    permission: {
      default: null,
      type: Object
    }
  },
  data() {
    return {};
  }
};
</script>