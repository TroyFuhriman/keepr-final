<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 text-center">
        <h1>Welcome To Your Dashboard {{$auth.user.nickname}}</h1>
        <button
          v-if="!form"
          @click="form = !form"
          class="btn btn-success btn-outline-dark"
        >Add new Keep</button>
        <span v-if="form">
          <button @click="form=!form" class="btn btn-danger btn-outline-dark rounded mb-3">cancel</button>
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
          <div class="row justify-content-center">
            <button @click="createKeep" class="btn btn-success mt-3 btn-outline-dark">Submit</button>
          </div>
        </span>
      </div>
      <keeps v-for="keep in keeps" :key="keep.id" :keep="keep" />
    </div>
  </div>
</template>

<script>
import keeps from "../components/KeepsComponent";
export default {
  data() {
    return {
      newKeep: {
        userEmail: this.$auth.user.email,
        isPrivate: false
      },
      show: false,
      form: true
    };
  },
  components: {
    keeps
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.publicKeeps.filter(
        k => k.userEmail == this.$auth.user.email
      );
    }
  },
  methods: {
    createKeep() {
      this.$store.dispatch("postKeep", { ...this.newKeep });
      this.newKeep = {
        userEmail: this.$auth.user.email,
        isPrivate: false
      };
    }
  }
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

.slider.round:before {
  border-radius: 50%;
}
</style>
