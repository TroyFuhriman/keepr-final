<template>
  <div class="keep-details container-fluid">
    <div class="row justify-content-center">
      <h4 v-if="$auth.user != keep.userEmail" class="col-9 text-center">
        {{ keep.name }}
      </h4>
      <h4
        @click="form = !form"
        v-if="!form && $auth.user == keep.userEmail"
        class="col-9 text-center"
      >
        {{ keep.name }}
      </h4>
      <div class="col-3 text-center mt-2" v-if="form">
        <input
          v-model="keep.name"
          class="form-control text-center"
          type="text"
        />
        <button
          @click="editKeepName"
          class="btn btn-warning my-2 btn-outline-dark"
        >
          edit
        </button>
      </div>
      <div class="col-12">
        <div class="row justify-content-center">
          <img class="col-3 img-fluid" :src="keep.img" alt />
        </div>
      </div>
      <div class="col-9 text-center">
        <button
          v-if="$auth.isAuthenticated"
          data-toggle="modal"
          data-target="#addToVault"
          class="btn btn-success btn-outline-dark mt-2 mb-2"
        >
          Save
        </button>
        <button
          @click="share"
          data-toggle="modal"
          data-target="#share"
          class="btn ml-2 btn-warning btn-outline-dark mt-2 mb-2"
        >
          Share
        </button>
        <div class="col-12">
          <div class="row justify-content-center">
            <button
              v-if="!form && $auth.user"
              @click="deleteKeep"
              class="btn btn-danger btn-outline-dark mb-2"
            >
              delete
            </button>
          </div>
        </div>
        <p v-if="$auth.user != keep.userEmail">
          {{ keep.description }}
        </p>
        <p
          @click="dForm = !dForm"
          v-if="!dForm && $auth.user == keep.userEmail"
        >
          {{ keep.description }}
        </p>
        <div class="row justify-content-center">
          <span class="col-4 text-center mt-2" v-if="dForm">
            <input
              v-model="keep.description"
              class="form-control text-center"
              type="text"
            />
            <button
              @click="editKeepDescription"
              class="btn btn-warning my-2 btn-outline-dark"
            >
              edit
            </button>
          </span>
        </div>
        <p>Posted by: {{ keep.userEmail }}</p>
        <p>
          Views: {{ keep.views }} Keeps: {{ keep.keeps }} Shares:
          {{ keep.shares }}
        </p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep-details",
  data() {
    return {
      form: false,
      dForm: false,
    };
  },
  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
    this.keep.views = this.keep.views + 1;
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
  },
  methods: {
    share() {
      this.keep.shares = this.keep.shares + 1;
      this.$store.dispatch("editKeep", this.keep);
    },
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    },
    editKeepName() {
      this.form = false;
      this.$store.dispatch("editKeep", this.keep);
    },
    editKeepDescription() {
      this.dForm = false;
      this.$store.dispatch("editKeep", this.keep);
    },
  },
  components: {},
};
</script>


<style scoped>
</style>