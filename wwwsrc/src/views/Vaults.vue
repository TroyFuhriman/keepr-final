<template>
  <div class="vaults container-fluid">
    <div class="row justify-content-center">
      <div class="col-6">
        <h3 class="text-center mt-2">Welcome To Your Vaults!</h3>
        <p class="text-center">Create New Vault</p>
        <input class="form-control" v-model="newVault.name" placeholder="Name" type="text" />
        <input
          class="form-control"
          v-model="newVault.description"
          placeholder="Description"
          type="text"
        />
        <div class="row justify-content-center">
          <button
            @click="createVault"
            class="btn btn-success btn-outline-dark text-center col-1 mt-2"
          >Create</button>
        </div>
      </div>
    </div>
    <div class="row">
      <Vaults v-for="vault in vaults" :key="vault.id" :vault="vault" />
    </div>
  </div>
</template>


<script>
import Vaults from "../components/VaultsComponent";
export default {
  name: "vaults",
  data() {
    return {
      newVault: {}
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    createVault() {
      this.$store.dispatch("postVault", { ...this.newVault });
      this.newVault = {};
    }
  },
  components: {
    Vaults
  }
};
</script>


<style scoped>
</style>