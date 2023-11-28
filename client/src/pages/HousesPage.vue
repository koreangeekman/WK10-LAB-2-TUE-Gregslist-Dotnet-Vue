<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12 col-md-4 p-4" v-for="house in houses" :key="house.id">
        <HouseEntry :house="house" />
      </div>
    </section>
  </div>

  <HouseForm />
</template>


<script>
import { computed, onMounted, onUnmounted } from 'vue';
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop";
import { AppState } from '../AppState';
import { housesService } from "../services/HousesService";
import HouseEntry from "../components/Houses/HouseEntry.vue";
import HouseForm from "../components/Houses/HouseForm.vue";

export default {
  setup() {
    async function _getHouses() {
      try {
        await housesService.getHouses()
      } catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }

    onMounted(() => {
      housesService.clearData();
      _getHouses();
    });

    onUnmounted(() => {
      housesService.clearAllData();
    });

    return {
      houses: computed(() => AppState.houses),
      // account: computed(() => AppState.account)
    };

  },
  components: { HouseEntry, HouseForm }
};
</script>


<style lang="scss" scoped></style>