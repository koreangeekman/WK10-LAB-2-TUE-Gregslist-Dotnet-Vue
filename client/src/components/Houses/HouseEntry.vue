<template>
  <router-link :to="{ name: 'HouseDetails', params: { houseId: house.id } }">
    <div class="card">
      <img :src="house.imgUrl">
      <p class="price fs-4 mb-0 px-2 py-1">${{ house.price }}</p>
      <i class="deleteBtn text-danger fs-2 px-2 mdi mdi-trash-can" type="button" v-if="house.creatorId == account.id"></i>
      <p class="description p-2">{{ house.description }}</p>
      <span class="d-flex justify-content-around">
        <div>
          <span class="d-flex justify-content-between">
            <p>Year:&nbsp;</p>
            <p>{{ house.year }}</p>
          </span>
          <span class="d-flex justify-content-between">
            <p>Levels:&nbsp;</p>
            <p>{{ house.levels }}</p>
          </span>
        </div>
        <div>
          <span class="d-flex justify-content-between">
            <p>Bedrooms:&nbsp;</p>
            <p>{{ house.bedrooms }}</p>
          </span>
          <span class="d-flex justify-content-between">
            <p>Bathrooms:&nbsp;</p>
            <p>{{ house.bathrooms }}</p>
          </span>
        </div>
      </span>
    </div>
  </router-link>
</template>


<script>
import { computed } from "vue";
import { House } from "../../models/House";
import { AppState } from "../../AppState";

export default {
  props: {
    house: { type: House },
  },
  setup() {
    return {
      account: computed(() => AppState.account),
    }
  }
};
</script>


<style lang="scss" scoped>
img {
  height: 32dvh;
  object-fit: cover;
}

.card {
  position: relative;
}

.price {
  position: absolute;
  top: 3px;
  left: 3px;
  border-radius: 0.5rem;
  background-color: rgba(0, 128, 0, 0.86);
  color: white;
}

.deleteBtn {
  position: absolute;
  top: 3px;
  right: 3px;
  border-radius: 0.5rem;
  background-color: #ffffffb9;
}
</style>