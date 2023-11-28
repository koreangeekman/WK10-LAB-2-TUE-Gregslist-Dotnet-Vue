<template>
  <!-- NOTE the CarDetails route in our router.js has a required parameter, so we have to specify its value here in our :to object -->
  <router-link :to="{ name: 'CarDetails', params: { carId: carProp.id } }">
    <section class="row rounded bg-light shadow">
      <div class="col-md-4 p-0">
        <img class="img-fluid rounded-start" :src="carProp.imgUrl" :alt="carProp.make + ' ' + carProp.model">
      </div>
      <div class="col-md-8 p-5">
        <h2>{{ carProp.make }} {{ carProp.model }}</h2>
        <h3>${{ carProp.price }}</h3>
      </div>
    </section>
  </router-link>
</template>


<script>
import { Car } from '../../models/Car.js';


export default {
  props: {
    carProp: { type: Car },
  },
  setup() {
    return {
      // NOTE not going to work well, we'll use our id from our route instead
      // setActiveCar(car) {
      //   AppState.activeCar = car
      // }
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 30vh;
  width: 100%;
  object-fit: cover;
}
</style>