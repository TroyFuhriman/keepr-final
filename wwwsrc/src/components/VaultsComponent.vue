<template>
  <div class="vaults col-md-5 col-lg-4 col-sm-6 col-12 mt-3 col-xl-3">
    <div
      @click="
        $router.push({ name: 'VaultDetails', params: { vaultId: vault.id } })
      "
      class="action card border-dark bg-green shadow"
    >
      <div class="card-body">
        <h4 class="card-title text-center text-truncate">{{ vault.name }}</h4>
        <p class="card-text text-center text-truncate">
          {{ vault.description }}
        </p>
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
  components: {},
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
  background-color: #eee !important;
}
.bg-green {
  background-color: #99c5aa;
}
</style>
