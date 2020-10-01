<template>
  <div class="keep-details container-fluid">
    <div class="row justify-content-center">
      <h4 v-if="!profile" class="col-9 text-center font-weight-bold">
        {{ keep.name }}
      </h4>
      <h4
        @click="form = !form"
        v-if="!form && profile"
        class="col-9 text-center font-weight-bold"
      >
        {{ keep.name }}
      </h4>
      <p class="col-9 text-center font-weight-light">
        Views: {{ keep.views }} Keeps: {{ keep.keeps }} Shares:
        {{ keep.shares }}
      </p>
      <div class="col-md-3 col-12 col-sm-6 text-center mt-2" v-if="form">
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
          <img
            class="col-md-6 col-lg-4 col-sm-9 col-12 border border-dark rounded shadow p-0"
            :src="keep.img"
            alt
          />
        </div>
        <div class="row justify-content-center">
          <p
            class="mt-2 offset-md-3 col-md-3 col-12 text-center font-italic font-weight-light"
          >
            Posted by: {{ keep.userEmail }}
          </p>
          <p
            class="font-weight-light font-italic col-12 text-center"
            v-if="!profile"
          >
            {{ keep.description }}
          </p>
          <p
            class="font-weight-light col-12 text-center"
            @click="dForm = !dForm"
            v-if="!dForm && profile"
          >
            {{ keep.description }}
          </p>
        </div>
      </div>
      <div class="col-md-9 col-12 text-center">
        <button
          v-if="$auth.isAuthenticated"
          data-toggle="modal"
          data-target="#addToVault"
          class="btn btn-success btn-outline-dark"
        >
          Save
        </button>
        <button
          v-if="$auth.user"
          @click="share"
          data-toggle="modal"
          data-target="#share"
          class="btn ml-2 mr-2 btn-warning btn-outline-dark"
        >
          Share
        </button>
        <button
          v-if="!form && profile"
          @click="deleteKeep"
          class="btn btn-danger btn-outline-dark"
        >
          delete
        </button>
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
    profile() {
      if (this.$auth.user) {
        return this.$auth.user.name == this.keep.userEmail;
      }
      return false;
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