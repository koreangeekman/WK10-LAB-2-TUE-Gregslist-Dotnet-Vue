<template>
  <div class="modal fade" id="carFormModal" tabindex="-1" aria-labelledby="carFormLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 v-if="!editable.id" class="modal-title fs-5" id="carFormLabel">Create Car Entry</h1>
          <h1 v-else class="modal-title fs-5" id="carFormLabel">Edit Car Entry</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="handleSubmit()">
            <div class="mb-3">
              <label for="make" class="form-label">Car Make</label>
              <input v-model="editable.make" type="text" class="form-control" id="make" required maxlength="500">
            </div>
            <div class="mb-3">
              <label for="model" class="form-label">Car Model</label>
              <input v-model="editable.model" type="text" class="form-control" id="model" required maxlength="500">
            </div>
            <div class="mb-3">
              <label for="imgUrl" class="form-label">Car ImgUrl</label>
              <input v-model="editable.imgUrl" type="url" class="form-control" id="imgUrl" required maxlength="500">
            </div>
            <div class="mb-3">
              <label for="year" class="form-label">Car Year</label>
              <input v-model="editable.year" type="number" class="form-control" id="year" required>
            </div>
            <div class="mb-3">
              <label for="price" class="form-label">Car Price</label>
              <input v-model="editable.price" type="number" class="form-control" id="price" required>
            </div>
            <div class="mb-3">
              <label for="description" class="form-label">Car Description</label>
              <textarea v-model="editable.description" maxlength="500" class="form-control" id="description"
                rows="3"></textarea>
            </div>
            <div class="mb-3">
              <label for="color" class="form-label">Car Color</label>
              <input v-model="editable.color" type="color" class="form-control form-control-color" id="color"
                title="Choose your color">

            </div>
            <div class="mb-3">
              <select v-model="editable.engineType" class="form-select" aria-label="Default select example">
                <option v-for="engineType in engineTypes" :key="engineType" :value="engineType">{{ engineType }}</option>
              </select>
            </div>
            <div class="text-end">
              <button class="btn btn-success" type="submit">Submit</button>
            </div>
          </form>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
import { ref, watchEffect } from 'vue';
import { Modal } from 'bootstrap';
import Pop from '../../utils/Pop.js';
import { logger } from '../../utils/Logger.js';
import { carsService } from '../../services/CarsService.js';
import { AppState } from '../../AppState.js';

export default {
  setup() {
    const editable = ref({})

    watchEffect(() => {
      if (AppState.activeCar) {
        editable.value = { ...AppState.activeCar }
        logger.log('WATCH')
      }
      else {
        editable.value = {}

      }
    })
    return {
      editable,
      engineTypes: [
        "unknown",
        "2 stroke",
        "4 cylinder",
        "v6",
        "v8",
        "v10",
        "v12",
        "small",
        "medium",
        "large",
        "chuncko"
      ],
      handleSubmit() {
        if (!editable.value.id) {
          this.createCar()
        }
        else {
          this.updateCar()
        }
      },
      async createCar() {
        try {
          const carData = editable.value
          await carsService.createCar(carData)
          // NOTE clears form
          editable.value = {}
          // NOTE closes modal
          Modal.getOrCreateInstance('#carFormModal').hide()
        } catch (error) {
          Pop.error(error)
        }
      },
      async updateCar() {
        try {
          const carData = editable.value
          await carsService.updateCar(carData)
          Modal.getOrCreateInstance('#carFormModal').hide()
        } catch (error) {
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>