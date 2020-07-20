<template>
  <div class="vaults container-fluid">
    <div class="row">
      <div class="col">
        <input class="form-control" type="text" />
        <input class="form-control" type="text" />
      </div>
    </div>
    <Vaults v-for="vault in vaults" :key="vault.id" :vault="vault" />
  </div>
</template>


<script>
import Vaults from "../components/VaultsComponent";
export default {
  name: "vaults",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {},
  components: {
    Vaults
  }
};
</script>


<style scoped>
</style>