<template>
  <div class="keeps col-md-3 col-6">
    <div
      class="size d-flex justify-content-around rounded-top align-items-end mt-3"
      @mouseover="hover = true"
      @mouseleave="hover = false"
      @click=" views(); $router.push({name: 'KeepDetails', params: {keepId: keep.id}})"
      :style="{backgroundImage: 'url(' + keep.img + ')'}"
    >
      <p v-if="hover" class="bg-light p-2 rounded">Views:{{keep.views}}</p>
      <p v-if="hover" class="bg-light p-2 rounded">Shares:{{keep.shares}}</p>
      <p v-if="hover" class="bg-light p-2 rounded">Saved:{{keep.keeps}}</p>
    </div>
    <div class="text-center rounded-bottom">{{keep.name}}</div>
  </div>
</template>


<script>
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
    }
  },
  components: {},
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