<template>
  <div class="vault-modal">
    <div class="modal fade" id="addToVault" tabindex="-1" role="dialog">
      <div class="modal-dialog-centered modal-dialog modal-sm" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add to Vault</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <select
              v-model="fun.vaultName"
              class="form-control form-control-sm"
            >
              <option v-for="vault in vaults" :key="vault.id">
                {{ vault.name }}
              </option>
            </select>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
            >
              Close
            </button>
            <button
              type="button"
              @click="addToVault"
              data-dismiss="modal"
              class="btn btn-primary"
            >
              Add
            </button>
          </div>
        </div>
      </div>
    </div>
    <div class="modal fade" id="share" tabindex="-1" role="dialog">
      <div class="modal-dialog-centered modal-dialog modal" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Add to Vault</h5>
            <button
              type="button"
              class="close"
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <input
              class="form-control"
              id="keepImg"
              readonly
              :value="keep.img"
              type="text"
            />
          </div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-secondary"
              data-dismiss="modal"
            >
              Close
            </button>
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
    return {
      fun: {},
    };
  },
  mounted() {},
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {
    addToVault() {
      this.fun.keepId = this.keep.id;
      for (let i = 0; i < this.vaults.length; i++) {
        const vault = this.vaults[i];
        if (vault.name == this.fun.vaultName) {
          this.fun.vaultId = vault.id;
        }
      }
      this.keep.keeps++;
      this.$store.dispatch("editKeep", { ...this.keep });
      this.$store.dispatch("postKeeptoVault", { ...this.fun });
      this.fun = {};
    },
  },
  components: {},
};
</script>


<style scoped>
</style>