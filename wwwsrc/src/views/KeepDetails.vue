<template>
  <div class="keep-details container-fluid">
    <div class="row justify-content-center">
      <h4 class="col-9 text-center">{{keep.name}}</h4>
      <div class="col-12">
        <div class="row justify-content-center">
          <button @click="deleteKeep" class="btn btn-danger mb-2">delete</button>
        </div>
      </div>
      <img class="col-5" :src="keep.img" alt />
      <div class="col-9 text-center">
        <p>{{keep.description}}</p>
        <p>Posted by: {{keep.userEmail}}</p>
        <p>Views: {{keep.views}} Keeps: {{keep.keeps}} Shares: {{keep.shares}}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep-details",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    }
  },
  components: {}
};
</script>


<style scoped>
</style>