<template>
  <div class="pe-3">
    <button v-if="account.id && cars != null" class="btn fs-2 ms-3 text-white" type="button" title="Open Add Car Form"
      data-bs-toggle="modal" data-bs-target="#carFormModal">
      +<i class="mdi mdi-car"></i>
    </button>
    <button v-if="account.id && houses != null" class="btn fs-2 ms-3 text-white" type="button" title="Open Add House Form"
      data-bs-toggle="modal" data-bs-target="#houseFormModal">
      <i class="mdi mdi-home-plus"></i>
    </button>
    <button v-if="account.id && jobs != null" class="btn fs-2 ms-3 text-white" type="button" title="Open Add Job Form"
      data-bs-toggle="modal" data-bs-target="#jobFormModal">
      <i class="mdi mdi-shape-rectangle-plus"></i>
    </button>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState";

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      cars: computed(() => AppState.cars),
      houses: computed(() => AppState.houses),
      jobs: computed(() => AppState.jobs),
    }
  },
}
</script>


<style lang="scss" scoped></style>