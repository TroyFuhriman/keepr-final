<template>
  <div class="vaults col-2 mt-3">
    <div
      @click="$router.push({name: 'VaultDetails', params: {vaultId: vault.id}})"
      class="action card border-dark bg-info shadow"
    >
      <img class="card-img-top" src="holder.js/100x180/" alt />
      <div class="card-body">
        <h4 class="card-title text-center">{{vault.name}}</h4>
        <p class="card-text text-center">{{vault.description}}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vaults",
  data() {
    return {};
  },
  computed: {},
  methods: {},
  props: ["vault"],
  components: {}
};
</script>


<style scoped>
.vaults {
  opacity: 0.75;
}
.action {
  cursor: pointer;
}
.card:hover {
  background-color: #6dd2e2 !important;
}
</style>