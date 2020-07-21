<template>
  <div class="vault-modal">
    <div class="modal fade" id="addToVault" tabindex="-1" role="dialog">
      <div class="modal-dialog-centered modal-dialog modal-sm" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add to Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <select class="form-control form-control-sm">
              <option v-for="vault in vaults" :key="vault.id">{{ vault.name }}</option>
            </select>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" data-dismiss="modal" class="btn btn-primary">Add</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault-modal",
  data() {
    return {};
  },
  mounted() {
    return this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>