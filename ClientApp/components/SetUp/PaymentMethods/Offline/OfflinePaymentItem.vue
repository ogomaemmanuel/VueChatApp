<template>
    <div class="offline-payment-item">
        <div class="offline-payment-item-header">
            <span class="payment-name">{{ paymentMethod.name }}</span>
            <el-switch v-model="paymentMethod.isActive"
                       active-text="Active"
                       inactive-text="Inactive" />
        </div>
        <div class="offline-payment-item-footer">
            <div class="offline-payment-contols">
                <a href=""
                   @click.prevent><i class="fa fa-trash" /></a>
                <button class="btn btn-configure btn-light">Configure</button>
            </div>
        </div>
    </div>
</template>
<script>
export default {
  props: {
    paymentMethod: {
      type: Object,
      default: null
    }
  }
};
</script>
<style lang="scss">
    .offline-payment-item {
        min-height: 125px;
        padding-left: 20px;
        padding-right: 20px;
        background-color: #ffffff;
        margin: 0px 10px 10px 10px;
        .offline-payment-item-header

    {
        min-height: 65px;
        width: 100%;
        display: flex;
        padding-top: 10px;
        padding-bottom: 20px;
        .payment-name

    {
        flex: 1;
    }

    }

    .offline-payment-item-footer {
        padding-top: 20px;
        padding-bottom: 20px;
        min-height: 65px;
        width: 100%;
        border-top: thin;
        border-top-style: solid;
        border-top-color: #f4f4f7;
        .offline-payment-contols

    {
        display: flex;
        justify-content: flex-end;
        align-items: center;
        .btn-configure

    {
        margin-left: 20px;
    }

    }
    }
    }
</style>