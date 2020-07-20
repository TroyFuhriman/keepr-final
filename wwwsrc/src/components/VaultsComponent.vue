<template>
  <div class="vaults col-4 mt-3">
    <div @click="$router.push({name: 'VaultDetails', params: {vaultId: vault.id}})" class="card">
      <img class="card-img-top" src="holder.js/100x180/" alt />
      <div class="card-body">
        <h4 class="card-title">{{vault.name}}</h4>
        <p class="card-text">{{vault.description}}</p>
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
</style>