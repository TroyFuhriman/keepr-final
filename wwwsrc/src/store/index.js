import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { api } from "./AxiosService";

Vue.use(Vuex);
export default new Vuex.Store({
  state: {
    publicKeeps: [],
    privateKeeps: [],
    activeKeep: {},
    vaults: [],
    activeVault: {},
  },
  mutations: {
    setKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setKeep(state, keep) {
      state.activeKeep = keep;
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setVault(state, vault) {
      state.activeVault = vault;
    },
  },
  actions: {
    //#region Keeps
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeep({ commit, dispatch }, keepId) {
      try {
        let res = await api.get("keeps/" + keepId);
        commit("setKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async postKeep({ commit, dispatch }, newKeep) {
      try {
        console.log(newKeep);
        let res = await api.post("keeps", newKeep);
      } catch (error) {
        console.error(error);
      }
    },
    async editKeep({ commit, dispatch }, editKeep) {
      try {
        let res = await api.put("keeps/" + editKeep.id, editKeep);
        dispatch("getKeep", editKeep.id);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      try {
        let res = await api.delete("keeps/" + keepId);
        router.push({ name: "home" });
      } catch (error) {
        console.error(error);
      }
    },
    //#endregion Keeps
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        commit("setVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getVault({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId);
        commit("setVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async postVaults({ commit, dispatch }, newVault) {
      try {
        let res = await api.post("vaults", newVault);
      } catch (error) {
        console.error(error);
      }
    },
    async editVault({ commit, dispatch }, editVault) {
      try {
        let res = await api.put("vaults/" + editVault.id, editVault);
        dispatch("getVault", editVault.id);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      try {
        let res = await api.delete("vaults/" + vaultId);
        dispatch("getVaults");
      } catch (error) {
        console.error(error);
      }
    },
  },
});
