<template>
  <div id="app">
    <navbar />
    <router-view />
  </div>
</template>

<script>
import { setBearer } from ".//store/AxiosService";
import { resetBearer } from ".//store/AxiosService";
import Navbar from "@/components/navbar";
import { onAuth } from "@bcwdev/auth0-vue";
export default {
  name: "App",
  async beforeCreate() {
    await onAuth();
    // this.$store.dispatch("setBearer", this.$auth.bearer);
    setBearer(this.$auth.bearer);
  },
  components: {
    Navbar
  }
};
</script>

<style lang="scss">
@import "bootstrap";
// @import "./assets/_overrides.scss";
@import "./assets/yeti.scss";
</style>
