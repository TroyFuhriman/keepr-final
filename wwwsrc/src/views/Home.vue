<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12 text-center">
        <h1 v-if="$auth.user">Welcome {{$auth.user.nickname}}</h1>
        <span v-if="!$auth.user">
          <h1>Welcome to Keepr!</h1>
          <p>sign-up/log-in to save Keeps in your Vault!</p>
        </span>
      </div>
      <keeps v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </div>
  </div>
</template>

<script>
import keeps from "../components/KeepsComponent";
export default {
  name: "home",
  components: {
    keeps
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps.filter(k => k.isPrivate == false);
    },
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>
