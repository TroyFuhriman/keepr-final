<template>
  <div class="vault-details">
    <div class="row">
      <keeps v-for="keep in myKeeps" :key="keep.id" :keep="keep" />
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
  },
  computed: {
    myKeeps() {
      return this.$store.state.myKeeps;
    }
  },
  methods: {},
  components: {
    Keeps
  }
};
</script>


<style scoped>
</style>