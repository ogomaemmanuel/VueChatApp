<template>
    <div class="contact-information">

        <h2>Contact information</h2>
        <form class="contact-information-form">

            <div class="company-identity">

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Company name</label>

                    </div>

                    <div class="contact-information-form-control-input has-icon">

                        <input class="form-control"
                               type="text">

                        <i class="fa fa-info-circle" />
                    </div>

                </div>
                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">
                        <label>Company website</label>

                    </div>
                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="url">

                    </div>
                </div>
                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">
                        <label>Year in which the store opened</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

            </div>

            <div class="company-address">

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Street address</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="text">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Country</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="url">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>State</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Fax</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>City</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Zip/postal code</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Phone</label>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

            </div>

            <div class="company-contacts">

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Site administrator e-mails</label>
                        <span class="text-danger">*</span>
                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="text">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Customer relations e-mails</label>
                        <span class="text-danger">*</span>
                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="url">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>Sales department e-mails</label>
                        <span class="text-danger">*</span>
                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-label">

                        <label>HelpDesk/Support service e-mails</label>
                        <span class="text-danger">*</span>

                    </div>

                    <div class="contact-information-form-control-input">

                        <input class="form-control"
                               type="number">

                    </div>

                </div>

                <div class="contact-information-form-control">

                    <div class="contact-information-form-control-links">

                        <a href=""
                           @click.prevent>Test your emails</a>

                        <a href=""
                           @click.prevent>Contact Us page settings</a>

                    </div>

                </div>

            </div>
            <!--TODO create Three Tabs named Identity,Company address and Contacts -->
            <!-- TODO Add Edit vue component for this compoment -->
        </form>

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
    .contact-information {
        .company-identity

    {
        .contact-information-form-control

    {
        display: flex;
        align-items: center;
        margin-bottom: 5px;

        @media screen and (max-width: 878px) {
            flex-flow: column;
            align-items: flex-start;
        }
    }

    .contact-information-form-control-label {
        flex-basis: 25%;
        display: flex;
        align-items: center;
        label

    {
        flex: 1;
    }

    span {
        margin-right: 16px;
        margin-left: 16px;
    }

    @media screen and (max-width: 878px) {
        flex: 1;
    }

    }

    .contact-information-form-control-input {
        flex-basis: 380px;
        display: flex;
        align-items: center;
        align-content: space-between;
        position: relative;
        input

    {
        min-width: 300px;
    }

    i {
        color: #63b3d8;
        position: absolute;
        right: -20px;
    }

    @media screen and (max-width: 878px) {
        flex-basis: 100%;
    }

    }

    .contact-information-form-control-links {
        display: flex;
        flex-flow: column;
    }

    }

    .company-address {
        @extend .company-identity;
        margin-top: 20px;
    }

    .company-contacts {
        @extend .company-address;
    }
    }
</style>