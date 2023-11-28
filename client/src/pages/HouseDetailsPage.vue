<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1>House Details</h1>
      </div>
    </section>
    <section v-if="activeHouse" class="row">
      <div class="col-12 col-md-6">
        <img class="rounded shadow" :src="activeHouse.imgUrl">
      </div>
      <div class="col-12 col-md-6">
        <p class="price shadow fs-4 mb-0 px-2 py-1">${{ activeHouse.price }}</p>
        <span class="d-flex justify-content-around rounded border border-success my-3 py-3">
          <div>
            <span class="d-flex justify-content-between">
              <p>Year:&nbsp;</p>
              <p>{{ activeHouse.year }}</p>
            </span>
            <span class="d-flex justify-content-between">
              <p>Levels:&nbsp;</p>
              <p>{{ activeHouse.levels }}</p>
            </span>
          </div>
          <div>
            <span class="d-flex justify-content-between">
              <p>Bedrooms:&nbsp;</p>
              <p>{{ activeHouse.bedrooms }}</p>
            </span>
            <span class="d-flex justify-content-between">
              <p>Bathrooms:&nbsp;</p>
              <p>{{ activeHouse.bathrooms }}</p>
            </span>
          </div>
        </span>
        <p class="description rounded border border-success p-3">{{ activeHouse.description }}</p>
        <span class="d-flex justify-content-between align-items-center" v-if="activeHouse.creatorId == account.id">
          <i class="deleteBtn text-danger fs-2 px-2 mdi mdi-trash-can" type="button" @click="removeHouse()"></i>
          <button data-bs-toggle="modal" data-bs-target="#houseFormModal" class="btn btn-info ms-3">Edit House</button>
        </span>
      </div>
    </section>
    <section v-else class="row justify-contents-center">
      <div class="col-12 col-md-6 p-5">
        <h1>Loading... <i class="mdi mdi-swap-vertical-circle-outline mdi-spin"></i> </h1>
      </div>
    </section>
  </div>
  <HouseForm />
</template>


<script>
import { useRoute, useRouter } from "vue-router";
import { AppState } from '../AppState';
import { computed, onMounted, onUnmounted } from 'vue';
import { housesService } from "../services/HousesService";
import Pop from "../utils/Pop";
import { logger } from "../utils/Logger";
import HouseForm from "../components/Houses/HouseForm.vue";

export default {
  setup() {
    const route = useRoute();
    const router = useRouter();
    async function _getHouseById() {
      try {
        const houseId = route.params.houseId;
        await housesService.getHouseById(houseId);
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    onMounted(() => {
      housesService.clearData();
      _getHouseById();
    });
    onUnmounted(() => housesService.clearData());
    return {
      account: computed(() => AppState.account),
      activeHouse: computed(() => AppState.activeHouse),

      async removeHouse() {
        try {
          const toBeDeletes = await Pop.confirm('Delete this entry?');
          if (!toBeDeletes) { return; }

          const houseId = route.params.houseId;
          await housesService.removeHouse(houseId);
          router.push({ name: 'Houses' });
        }
        catch (error) {
          logger.error(error);
          Pop.error(error);
        }
      }
    };
  },
  components: { HouseForm }
};
</script>


<style lang="scss" scoped>
img {
  width: 100%;
  object-fit: cover;
}

p {
  margin: .5rem .25rem;
}

.price {
  border-radius: 0.5rem;
  background-color: rgba(0, 128, 0, 0.86);
  color: white;
  width: fit-content;
}

.deleteBtn {
  border-radius: 0.5rem;
  background-color: #ffffffb9;
}
</style>