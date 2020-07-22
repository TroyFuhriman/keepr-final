<template>
  <div class="keeps col-md-3 col-6 text-center">
    <div
      class="size d-flex justify-content-around rounded align-items-end mt-3 shadow border border-dark"
      @mouseover="hover = true"
      @mouseleave="hover = false"
      @click="editKeep;$router.push({name: 'KeepDetails', params: {keepId: keep.id}})"
      :style="{backgroundImage: 'url(' + keep.img + ')'}"
    >
      <p v-if="hover" class="bg-light p-2 rounded">Views:{{keep.views}}</p>
      <p v-if="hover" class="bg-light p-2 rounded">Saved:{{keep.keeps}}</p>
      <p v-if="hover" class="bg-light p-2 rounded">Shares:{{keep.shares}}</p>
    </div>
    <div class="text-center rounded-bottom">{{keep.name}}</div>
    <button @click="removeFromKeep" class="btn mt-2 btn-danger btn-outline-dark">Remove</button>
  </div>
</template>
<script>
import Modal from "../components/ModalComponent";
export default {
  name: "keeps",
  data() {
    return {
      hover: false
    };
  },
  mounted() {},
  computed: {
    editKeep() {
      this.keep.views = this.keep.views + 1;
      this.$store.dispatch("editKeepViews", this.keep);
    }
  },
  methods: {
    removeFromKeep() {
      this.keep.vaultId = this.$route.params.vaultId;
      this.$store.dispatch("removeFromKeep", this.keep);
    }
  },
  components: {
    Modal
  },
  props: ["keep"]
};
</script>


<style scoped>
.size {
  min-width: 100%;
  min-height: 20em;
  background-size: cover;
  background-position: center;
}
.bad {
  display: flex;
  align-items: flex-end;
}
</style>