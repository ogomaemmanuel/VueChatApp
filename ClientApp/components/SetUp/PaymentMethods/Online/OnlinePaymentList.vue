<template>
    <div class="online-payment-list">
        <div class="online-payment-list-head">
            <h6 class="title">Online methods</h6>
            <button class="btn btn-add-payment btn-primary-outline">
                Add Payment Method
            </button>
        </div>
        <div class="online-payment-list-body">
            <online-payment-item v-for="paymentMethod in paymentsMethods"
                                 :key="paymentMethod.id"
                                 :payment-method="paymentMethod" />
        </div>
    </div>
</template>
<script>
import OnlinePaymentItem from "./OnlinePaymentItem";
export default {
  components: {
    "online-payment-item": OnlinePaymentItem
  },
  data() {
    return {
      paymentsMethods: [
        {
          id: "1",
          name: "PayPal Express Checkout",
          imageUrl:
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJbbkk9YpJHgkYMVpycbc7fu4dp9XxYJeSMxua-UqOe1VgJ4zO2g",
          description: `Create a seamless checkout experience
       and increase your conversion rate by opening the door to
       over 100 million active PayPal customers
        who look for and use this fast, easy, and secure way to pay.`
        }
      ]
    };
  }
};
</script>

<style lang="scss">
    .online-payment-list {
        max-width: 700px;
        margin-bottom: 50px;
        .online-payment-list-head

    {
        background-color: #eaeaea;
        padding-top: 20px;
        padding-left: 25px;
        padding-right: 25px;
        padding-bottom: 20px;
        display: flex;
        .title

    {
        flex: 1;
    }

    }

    .online-payment-list-body {
        margin-top: 2px;
        background-color: #eaeaea;
        padding-top: 10px;
        padding-bottom: 5px;
    }
    }
</style>