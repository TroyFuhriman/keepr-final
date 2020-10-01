<template>
  <div class="keeps card border-dark shadow mt-1">
    <img
      @mouseover="hover = true"
      @mouseleave="hover = false"
      @click="
        $router.push({ name: 'KeepDetails', params: { keepId: keep.id } })
      "
      class="card-img-top blur action"
      :src="keep.img"
      alt
    />
    <div
      name="fade"
      id="good"
      v-if="hover"
      class="text-block rounded text-center text-truncate"
    >
      <h4 class="font-weight-bold">{{ keep.name }}</h4>
      <p class="font-weight-light">{{ keep.description }}</p>
      <div class="d-flex justify-content-around font-italic">
        <p>-Views: {{ keep.views }} -</p>
        <p>Saved: {{ keep.keeps }} -</p>
        <p>Shares: {{ keep.shares }}</p>
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
      hover: false,
    };
  },
  mounted() {},
  computed: {
    editKeep() {
      this.$store.dispatch("getKeep", this.keep.id);
    },
  },
  methods: {},
  components: {
    Modal,
  },
  props: ["keep"],
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
.blur:hover {
  filter: contrast(75%);
}

.text-block {
  position: absolute;
  bottom: 5px;
  right: 5px;
  background-color: white;
  color: black;
  opacity: 0.75;
  padding-left: 5px;
  padding-right: 5px;
}
.action {
  cursor: pointer;
}
</style>