<template>
    <div class="user-list">
        <div>
            <h2>Search for users</h2>
        </div>
        <button class="add-item add-user"
                @click="getToCreate">
            Add User
        </button>
        <table>
            <thead>
                <tr>
                    <th />
                    <th>Login/Email</th>
                    <th>Name</th>
                    <th>Access level</th>
                    <th>Orders </th>
                    <th>Created</th>
                    <th>Last login</th>
                    <th />
                </tr>
            </thead>
            <tbody>
                <tr is="user-item"
                    v-for="n in 10"
                    :key="n" />
            </tbody>
        </table>
    </div>
</template>

<script>
import UserItem from "./UserItem";
export default {
  components: {
    "user-item": UserItem
  },
  data() {
    return {};
  },
  methods: {
    getToCreate() {
      this.$router.push("user-create");
    }
  }
};
</script>

<style lang="scss">
    @import "../../assets/sass/_mixins.scss";

    .user-list {
        h2

    {
        margin-bottom: 40px;
        margin-top: 40px;
        font-weight: 300;
    }

    .add-user {
        margin-top: 40px;
        background-color: rgb(255, 255, 255);
        border-radius: 5px;
        padding: 6px 12px;
        border-width: thin;
        margin-bottom: 20px;
        &:hover

    {
        background-color: #eff8fe;
        color: rgb(149, 149, 149);
    }

    }

    table {
        @include tableFormat;
    }
    }
</style>