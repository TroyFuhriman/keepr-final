<template>
  <div class="dashboard container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1 class="font-weight-bold text-capitalize">
          Welcome To Your Dashboard <br />
          {{ $auth.user.nickname }}
        </h1>
        <button
          v-if="!form && !vaultForm"
          @click="form = !form"
          class="btn btn-secondary btn-outline-light border-dark mr-2 mb-2"
        >
          Add new Keep
        </button>
        <button
          v-if="!vaultForm && !form"
          @click="vaultForm = !vaultForm"
          class="btn btn-secondary btn-outline-light border-dark mb-2"
        >
          Add new Vault
        </button>
        <span v-if="form">
          <button
            @click="form = !form"
            class="btn btn-danger btn-outline-light border-dark rounded mb-3"
          >
            Cancel
          </button>
          <div class="row justify-content-center">
            <input
              v-model="newKeep.name"
              class="form-control rounded col-7"
              placeholder="Name"
              type="text"
            />
            <input
              v-model="newKeep.description"
              class="form-control col-7 mt-2"
              placeholder="description"
              type="text"
            />
            <input
              v-model="newKeep.img"
              class="form-control mt-2 col-7"
              placeholder="imageURL"
              type="url"
              name
              id
            />
          </div>
          <label class="switch mt-2">
            <input
              class
              v-model="newKeep.isPrivate"
              type="checkbox"
              aria-label="Check to keep private"
            />
            <span class="slider round"></span>
          </label>
          <p class>Private</p>
          <div class="row justify-content-center mb-3">
            <button
              @click="createKeep"
              class="btn btn-success mt-3 btn-outline-light border-dark"
            >
              Submit
            </button>
          </div>
        </span>
      </div>
      <div v-if="vaultForm" class="col-12 text-center">
        <div class="row justify-content-center">
          <div class="col-12">
            <button
              @click="vaultForm = !vaultForm"
              class="btn btn-danger btn-outline-light border-dark rounded mb-2"
            >
              cancel
            </button>
          </div>
          <input
            class="form-control col-7"
            v-model="newVault.name"
            placeholder="Name"
            type="text"
          />
          <input
            class="form-control mt-1 col-7"
            v-model="newVault.description"
            placeholder="Description"
            type="text"
          />
        </div>
        <div class="row justify-content-center mb-3">
          <button
            @click="createVault"
            class="btn btn-success btn-outline-light border-dark text-center mt-2"
          >
            Create
          </button>
        </div>
      </div>
      <div class="col-6">
        <h3 class="text-center border-bottom border-dark">My Vaults</h3>
      </div>
      <div class="col-12">
        <div class="row">
          <Vaults v-for="vault in vaults" :key="vault.id" :vault="vault" />
        </div>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-6 border-bottom border-dark text-center">
        <h3>My Keeps</h3>
      </div>
    </div>
    <div class="row mt-2">
      <div class="col-12 card-columns">
        <keeps v-for="keep in keeps" :key="keep.id" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import Vaults from "../components/VaultsComponent";
import keeps from "../components/KeepsComponent";
export default {
  data() {
    return {
      newKeep: {
        userEmail: this.$auth.user.email,
        isPrivate: false,
      },
      newVault: {},
      form: false,
      vaultForm: false,
    };
  },
  components: {
    keeps,
    Vaults,
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps.filter(
        (k) => k.userEmail == this.$auth.user.email
      );
    },
    vaults() {
      return this.$store.state.vaults;
    },
  },
  methods: {
    createKeep() {
      this.$store.dispatch("postKeep", { ...this.newKeep });
      this.newKeep = {
        userEmail: this.$auth.user.email,
        isPrivate: false,
      };
    },
    createVault() {
      this.$store.dispatch("postVault", { ...this.newVault });
      this.newVault = {};
    },
  },
};
</script>

<style>
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}
/* Hide default HTML checkbox */
.switch input {
  opacity: 0;
  width: 0;
  height: 0;
}

/* The slider */
.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: 0.4s;
  transition: 0.4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: 0.4s;
  transition: 0.4s;
}

input:checked + .slider {
  background-color: #2196f3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196f3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}
.card-columns {
  column-count: 6;
}
.slider.round:before {
  border-radius: 50%;
}
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
