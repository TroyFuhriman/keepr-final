<template>
  <div id="app">
    <navbar />
    <router-view class="grow" />
    <modal />
    <footer class="bg-dark p-2 text-light text-center">
      Made with Love by
      <a href="https://github.com/TroyFuhriman">Troy</a>
    </footer>
  </div>
</template>

<script>
import Modal from "./components/ModalComponent";
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
    this.$store.dispatch("getVaults");
  },
  components: {
    Navbar,
    Modal,
  },
};
</script>

<style lang="scss">
@import "bootstrap";
// @import "./assets/_overrides.scss";
@import "./assets/yeti.scss";
#app {
  font-family: "Josefin Sans", sans-serif;
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.grow {
  flex-grow: 1;
}
</style>
