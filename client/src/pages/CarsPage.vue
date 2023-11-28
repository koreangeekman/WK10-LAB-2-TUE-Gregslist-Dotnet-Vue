<template>
  <div class="container-fluid">
    <section class="row">
      <div v-for="car in cars" :key="car.id" class="col-12 col-md-6 p-4">
        <CarEntry :carProp="car" />
      </div>
    </section>
  </div>

  <CarForm />
</template>


<script>
import { computed, onMounted, onUnmounted } from 'vue';
import { logger } from "../utils/Logger";
import Pop from '../utils/Pop.js';
import { AppState } from '../AppState.js'
import { carsService } from '../services/CarsService.js'
import CarForm from '../components/Cars/CarForm.vue';
import CarEntry from '../components/Cars/CarEntry.vue';

export default {
  // NOTE no props on pages
  setup() {
    async function getCars() {
      try {
        await carsService.getCars();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }

    onMounted(() => {
      carsService.clearData();
      getCars();
    });

    onUnmounted(() => {
      carsService.clearAllData();
    });

    return {
      cars: computed(() => AppState.cars),
      // account: computed(() => AppState.account)
    };
  },
  components: { CarForm, CarEntry }
};
</script>


<style lang="scss" scoped></style>