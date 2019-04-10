<template>
    <div class="create-user">
        <form>
            <div class="form-group row">
                <label for="staticEmail"
                       class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-10">
                    <input id="staticEmail"
                           type="text"
                           class="form-control">
                </div>
            </div>
            <div class="form-group row">
                <label for="inputPassword"
                       class="col-sm-2 col-form-label">Password</label>
                <div class="col-sm-10">
                    <input id="inputPassword"
                           type="password"
                           class="form-control"
                           placeholder="Password">
                </div>
            </div>
            <div class="form-group row">
                <label for="confirm-password"
                       class="col-sm-2 col-form-label">Confirm Password</label>
                <div class="col-sm-10">
                    <input id="confirm-password"
                           type="password"
                           class="form-control"
                           placeholder="Confirm Password">
                </div>
            </div>

            <h6 class="line-header">Access information</h6>
            <div class="form-group row">
                <label for="staticEmail"
                       class="col-sm-2 col-form-label">Access Level</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control">
                </div>
            </div>
            <div class="form-group row">
                <label for="staticEmail"
                       class="col-sm-2 col-form-label">Membership</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control">
                </div>
            </div>
            <div class="form-group row">
                <label for="staticEmail"
                       class="col-sm-4 col-form-label">Require to change password on next log in</label>
                <div class="col-sm-8">
                    <input type="checkbox">
                </div>
            </div>
            <div class="submit-button-holder">
                <button class="btn btn-primary">Create</button>
            </div>
        </form>
    </div>
</template>

<script>
    // const notifier = require("node-notifier");
    export default {
        data() {
            return {
                accessLevels: [
                    {
                        text: "customer",
                        value: "1"
                    },
                    {
                        text: "admin",
                        value: "2"
                    }
                ],
                membershipTypes: [
                    {
                        text: "ignore Membership",
                        value: "1"
                    },
                    {
                        text: "Wholesaler",
                        value: "2"
                    }
                ]
            };
        },
        created() {
            // notifier.notify(
            //   {
            //     title: "My awesome title",
            //     message: "Hello from electron, Mr. User!",
            //     //    icon: path.join('','/home/ayushgp/Desktop/images.png'),  // Absolute path
            //     sound: true, // Only Notification Center or Windows Toasters
            //     wait: true // Wait with callback, until user action is taken
            //   },
            //   function(err, response) {
            //     // Response is response from notification
            //   }
            // );
        }
    };
</script>

<style lang="scss">
    .line-header {
        display: flex;
        align-items: center;
    }

    .line-header::before {
        content: "";
        flex: 1;
        height: 0;
        border-bottom: solid;
        border-bottom-width: thin;
    }

    .line-header::after {
        content: "";
        flex: 1;
        height: 0;
        width: 0;
        border-bottom: solid;
        border-bottom-width: thin;
    }

    .create-user {
        .submit-button-holder {
            display: flex;
            justify-content: center;
        }
    }
</style>