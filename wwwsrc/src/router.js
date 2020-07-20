import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import KeepDetails from "./views/KeepDetails.vue";
// @ts-ignore
import Vaults from "./views/Vaults.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/keep/:keepId",
      name: "KeepDetails",
      component: KeepDetails,
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard,
    },
    {
      path: "/vaults",
      name: "vaults",
      component: Vaults,
      beforeEnter: authGuard,
    },
  ],
});
