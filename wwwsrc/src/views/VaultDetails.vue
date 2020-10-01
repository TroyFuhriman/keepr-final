<template>
  <div class="vault-details container-fluid">
    <div class="row">
      <div class="col text-center">
        <h3 class>Welcome to your {{ vault.name }} Vault</h3>
        <p>{{ vault.description }}</p>
        <button
          v-if="$auth.user"
          @click="deleteVault"
          class="btn btn-danger btn-outline-dark"
        >
          Delete
        </button>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-12 card-columns">
        <keeps
          v-for="keep in myKeeps"
          :key="keep.id"
          :keep="keep"
          keep.vaultId="vault.id"
        />
      </div>
      <div class="col-12">
        <p class="text-center" v-if="myKeeps.length < 1">
          Oh No! This Vault is empty! it needs some love, go home and add keeps
          to it!
        </p>
      </div>
    </div>
  </div>
</template>


<script>
import Keeps from "../components/KeepsComponent";
export default {
  name: "vault-details",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("GetKeepsByVaultId", this.$route.params.vaultId);
    this.$store.dispatch("getVault", this.$route.params.vaultId);
  },
  computed: {
    myKeeps() {
      return this.$store.state.myKeeps;
    },
    vault() {
      return this.$store.state.activeVault;
    },
  },
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vault.id);
    },
  },
  components: {
    Keeps,
  },
};
</script>


<style scoped>
</style>