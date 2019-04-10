<template>
    <div class="role-create">
        <b-btn
                :class="'btn btn-primary add-button'"
                @click="centerDialogVisible=true">Add Role</b-btn>
        <el-dialog
                :visible.sync="centerDialogVisible"
                title="Create Role"
                width="30%"
                center>
            <form action="">
                <div class="form-group ">
                    <label for="name">Name</label>
                    <input
                            class="form-control"
                            name="name"
                            type="text">
                </div>
                <div class="form-group row">
                    <label
                            class="col-sm-2"
                            for="enabled">Enabled</label>
                    <div class="col-sm-10">
                        <input
                                name="enabled"
                                type="checkbox">
                    </div>
                </div>
                <div class="form-group">
                    <label for="reviewerName">Permissions</label>
                    <chip-input
                            :select-list="permissions"
                            @click.native.stop/>
                </div>

            </form>
        </el-dialog>

    </div>
</template>

<script>
    import ChipInput from "../../common/ChipList";
    export default {
        components: {
            "chip-input": ChipInput
        },
        data() {
            return {
                centerDialogVisible: false,
                permissions: [
                    {
                        id: "1",
                        text: "Root Access"
                    },
                    {
                        id: "2",
                        text: "Manage catlog"
                    },
                    {
                        id: "3",
                        text: "Manage reviews"
                    },
                    {
                        id: "4",
                        text: "Manage users"
                    },
                    {
                        id: "5",
                        text: "Manage administrators"
                    },
                    {
                        id: "6",
                        text: "Manage orders"
                    },
                    {
                        id: "7",
                        text: "Manage import"
                    },
                    {
                        id: "8",
                        text: "Manage import"
                    },
                    {
                        id: "9",
                        text: "Manage import"
                    }
                ]
            };
        }
    };
</script>

<style lang="scss">
</style>