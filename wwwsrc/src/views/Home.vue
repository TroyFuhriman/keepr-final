<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1 v-if="$auth.user">Welcome {{ $auth.user.nickname }}</h1>
        <span v-if="!$auth.user">
          <h1>Welcome to Keepr!</h1>
          <p>sign-up/log-in to save Keeps in your Vault!</p>
        </span>
      </div>

      <div class="col-md-4 col-12 col-sm-9">
        <input
          v-model="search"
          placeholder="Search..."
          class="form-control mb-2"
          type="text"
        />
      </div>
    </div>
    <div class="row">
      <div class="col-12 card-columns">
        <keeps class v-for="keep in filteredList" :key="keep.id" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keeps from "../components/KeepsComponent";
export default {
  name: "home",
  data() {
    return {
      search: "",
    };
  },
  components: {
    keeps,
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps.filter((k) => k.isPrivate == false);
    },
    user() {
      return this.$store.state.user;
    },
    filteredList() {
      return this.keeps.filter((keep) => {
        return (
          keep.name.toLowerCase().includes(this.search.toLowerCase()) ||
          keep.description.toLowerCase().includes(this.search.toLowerCase()) ||
          keep.userEmail.toLowerCase().includes(this.search.toLowerCase())
        );
      });
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
};
</script>
<style  scoped>
@media (min-width: 576px) {
  .card-columns {
    column-count: 2;
  }
}
@media (max-width: 575px) {
  .card-columns {
    column-count: 1;
  }
}

@media (min-width: 768px) {
  .card-columns {
    column-count: 3;
  }
}

@media (min-width: 992px) {
  .card-columns {
    column-count: 4;
  }
}

@media (min-width: 1200px) {
  .card-columns {
    column-count: 5;
  }
}
</style>