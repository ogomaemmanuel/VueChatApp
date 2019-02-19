<template>
    <div class="payment-methods">
        <online-payment-list />
        <offline-payment-list />
    </div>
</template>
<script>
import OfflinePaymentList from "./Offline/OfflinePaymentList";
import OnlinePaymentList from "./Online/OnlinePaymentList";
export default {
  components: {
    "offline-payment-list": OfflinePaymentList,
    "online-payment-list": OnlinePaymentList
  }
};
</script>
<style lang="scss">
</style>