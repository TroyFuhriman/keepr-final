<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <router-link
      class="navbar-brand"
      data-toggle="collapse"
      data-target=".navbar-collapse.show"
      :to="{ name: 'home' }"
    >
      <b>Keepr</b>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText active">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item active">
          <router-link
            :to="{ name: 'home' }"
            class="nav-link"
            data-toggle="collapse"
            data-target=".navbar-collapse.show"
          >
            <b>Home</b>
          </router-link>
        </li>
        <li class="nav-item active" v-if="$auth.isAuthenticated">
          <router-link
            :to="{ name: 'dashboard' }"
            data-toggle="collapse"
            data-target=".navbar-collapse.show"
            class="nav-link"
          >
            <b>My-Dashboard</b>
          </router-link>
        </li>
        <li class="nav-item active" v-if="$auth.isAuthenticated">
          <router-link
            :to="{ name: 'vaults' }"
            data-toggle="collapse"
            data-target=".navbar-collapse.show"
            class="nav-link"
          >
            <b>Vaults</b>
          </router-link>
        </li>
      </ul>
      <span class="navbar-text nav-item">
        <button class="btn btn-success" @click="login" v-if="!$auth.isAuthenticated">Login</button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";
import { resetBearer, setBearer } from "../store/AxiosService";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      // this.$store.dispatch("setBearer", this.$auth.bearer);
      setBearer(this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      // this.$store.dispatch("resetBearer");
      resetBearer();
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style></style>
