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
    myKeeps: [],
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
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps;
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
        await api.post("keeps", newKeep);
        dispatch("getKeeps");
      } catch (error) {
        console.error(error);
      }
    },
    async editKeep({ commit, dispatch }, editKeep) {
      try {
        await api.put("keeps/" + editKeep.id, editKeep);
        dispatch("getKeep", editKeep.id);
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      try {
        await api.delete("keeps/" + keepId);
        router.push({ name: "home" });
      } catch (error) {
        console.error(error);
      }
    },
    //#endregion Keeps
    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        commit("setVaults", res.data);
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
    async postVault({ commit, dispatch }, newVault) {
      try {
        await api.post("vaults", newVault);
        dispatch("getVaults");
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
        router.push({ name: "dashboard" });
      } catch (error) {
        console.error(error);
      }
    },
    async GetKeepsByVaultId({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get("vaults/" + vaultId + "/keeps");
        commit("setMyKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
});
