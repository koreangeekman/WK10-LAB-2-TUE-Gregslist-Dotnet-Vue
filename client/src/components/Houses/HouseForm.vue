<template>
  <div class="modal fade" id="houseFormModal" tabindex="-1" aria-labelledby="houseFormLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">

        <div class="modal-header">
          <h1 v-if="!editable.id" class="modal-title fs-5" id="houseFormLabel">Create House Entry</h1>
          <h1 v-else class="modal-title fs-5" id="houseFormLabel">Edit House Entry</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

        <div class="modal-body">
          <form @submit.prevent="triggerSubmit()">
            <div class="mb-3">
              <label for="imgUrl" class="form-label">Image Url</label>
              <input v-model="editable.imgUrl" type="url" class="form-control" id="imgUrl" required maxlength="500">
            </div>
            <div class="mb-3">
              <label for="year" class="form-label">Year</label>
              <input v-model="editable.year" type="number" class="form-control" id="year" required>
            </div>
            <div class="mb-3">
              <label for="price" class="form-label">Price</label>
              <input v-model="editable.price" type="number" class="form-control" id="price" required>
            </div>
            <div class="mb-3">
              <label for="bedrooms" class="form-label">Bedrooms</label>
              <input v-model="editable.bedrooms" type="number" class="form-control" id="bedrooms" required>
            </div>
            <div class="mb-3">
              <label for="bathrooms" class="form-label">Bathrooms</label>
              <input v-model="editable.bathrooms" type="number" class="form-control" id="bathrooms" required>
            </div>
            <div class="mb-3">
              <label for="levels" class="form-label">Levels</label>
              <input v-model="editable.levels" type="number" class="form-control" id="levels" required>
            </div>
            <div class="mb-3">
              <label for="description" class="form-label">Description</label>
              <textarea v-model="editable.description" maxlength="500" class="form-control" id="description"
                rows="3"></textarea>
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
import { Modal } from "bootstrap";
import { housesService } from "../../services/HousesService";
import { logger } from "../../utils/Logger";
import Pop from "../../utils/Pop";
import { ref } from 'vue';

export default {
  setup() {
    const editable = ref({})

    return {
      editable,


      triggerSubmit() {
        if (editable.value.id) {
          this.updateHouse()
        }
        this.createHouse()
      },

      async createHouse() {
        try {
          await housesService.createHouse(editable.value);
          editable.value = {}
          Modal.getOrCreateInstance('#houseFormModal').hide()
        } catch (error) {
          logger.error(error)
          Pop.error(error)
        }
      },
      async updateHouse() {
        try {
          await housesService.updateHouse(editable.value);
        } catch (error) {
          logger.error(error)
          Pop.error(error)
        }
      }


    }
  }
};
</script>


<style lang="scss" scoped></style>