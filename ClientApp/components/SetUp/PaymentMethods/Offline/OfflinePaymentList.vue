<template>
    <div class="offline-payment-list">
        <div class="offline-payment-list-head">
            <h2>Offline methods</h2>
            <button class="btn btn-add-payment btn-primary-outline">
                Add Payment Method
            </button>
        </div>
        <div class="offline-payment-list-body">
            <offline-payment-item v-for="paymentMethod in paymentsMethods"
                                  :key="paymentMethod.id"
                                  :payment-method="paymentMethod" />
        </div>
    </div>
</template>
<script>
import OfflinePaymentItem from "./OfflinePaymentItem";
export default {
  components: {
    "offline-payment-item": OfflinePaymentItem
  },
  data() {
    return {
      paymentsMethods: [
        {
          id: "1",
          name: "Cash on Delivery (FedEx)",
          isActive: false
        },
        {
          id: "2",
          name: "Cash on Delivery (UPS)",
          isActive: false
        },
        {
          id: "3",
          name: "Cash on Delivery (USPS)",
          isActive: false
        },
        {
          id: "4",
          name: "Check",
          isActive: false
        },
        {
          id: "5",
          name: "Phone Ordering",
          isActive: false
        },
        {
          id: "6",
          name: "Purchase Order",
          isActive: false
        },
        {
          id: "7",
          name: "COD",
          isActive: false
        },
        {
          id: "8",
          name: "Fax Ordering",
          isActive: true
        },
        {
          id: "9",
          name: "Money Order",
          isActive: true
        }
      ]
    };
  }
};
</script>
<style lang="scss">
    .offline-payment-list {
        max-width: 700px;
        margin-bottom: 50px;
        .offline-payment-list-head

    {
        background-color: #eaeaea;
        padding-top: 20px;
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 20px;
        display: flex;
        h2

    {
        flex: 1;
    }

    }

    .offline-payment-list-body {
        margin-top: 2px;
        background-color: #eaeaea;
        padding-top: 10px;
        padding-bottom: 5px;
    }
    }
</style>