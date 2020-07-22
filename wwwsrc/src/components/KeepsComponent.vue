<template>
  <div class="col-3">
    <div class="keeps card border-dark shadow">
      <img
        @mouseover="hover = true"
        @mouseleave="hover =false"
        @click="editKeep;$router.push({name: 'KeepDetails', params: {keepId: keep.id}})"
        class="card-img-top"
        :src="keep.img"
        alt
      />
      <div name="fade" id="good" v-if="hover" class="text-block card-body text-center">
        <h4 class="card-title">{{keep.name}}</h4>
        <p class="card-text">{{keep.description}}</p>
        <div class="card-text d-flex justify-content-around">
          <p>Views: {{keep.views}}</p>
          <p>Saved:{{keep.keeps}}</p>
          <p>Shares:{{keep.shares}}</p>
        </div>
      </div>
    </div>
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
  methods: {},
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
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
.keeps {
  position: relative;
}
.text-block {
  position: absolute;
  bottom: 20px;
  right: 20px;
  background-color: black;
  color: white;
  padding-left: 20px;
  padding-right: 20px;
}
</style>