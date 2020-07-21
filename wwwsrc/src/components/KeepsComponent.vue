<template>
  <div class="keeps col-md-3 col-6">
    <div
      class="size d-flex justify-content-around rounded align-items-end mt-3 shadow border border-dark"
      @mouseover="hover = true"
      @mouseleave="hover = false"
      @click=" views(); $router.push({name: 'KeepDetails', params: {keepId: keep.id}})"
      :style="{backgroundImage: 'url(' + keep.img + ')'}"
    >
      <p v-if="hover" class="bg-light p-2 rounded">Views:{{keep.views}}</p>
      <p
        type="button"
        v-if="hover"
        @click.stop="addToVault"
        class="bg-light p-2 rounded dropdown"
      >Saved:{{keep.keeps}}</p>
      <p v-if="hover" class="bg-light p-2 rounded">Shares:{{keep.shares}}</p>
    </div>
    <div class="text-center rounded-bottom">{{keep.name}}</div>
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
  computed: {},
  methods: {
    views() {
      this.keep.views++;
      console.log(this.keep.views);
      this.$store.dispatch("editKeep", this.keep);
    },
    addToVault() {
      $("#addToVault").modal("toggle");
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