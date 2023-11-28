import { AppState } from "../AppState";
import { House } from "../models/House";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class HousesService {

  async getHouses() {
    const res = await api.get('api/houses');
    const houses = res.data.map(house => new House(house))
    AppState.houses = houses
    // logger.log('[HOUSES SERVICE] getHouses(): ', houses)
    // return houses
  }

  async getHouseById(houseId) {
    const res = await api.get(`api/houses/${houseId}`);
    AppState.activeHouse = new House(res.data)
    logger.log('[HOUSES SERVICE] getHouseById(): ', AppState.activeHouse)
    return new House(res.data)
  }

  clearData() {
    AppState.activeHouse = null
  }
  clearAllData() {
    this.clearData()
    AppState.houses = null
  }

  // 🔽 AUTHENTICATION REQUIRED 🔽

  async createHouse(body) {
    const res = await api.post('api/houses', body);
    const newHouse = new House(res.data);
    AppState.houses.unshift(newHouse);
    return newHouse
  }
  async removeHouse(houseId) {
    const res = await api.delete(`api/houses/${houseId}`);
    this.clearData()
    logger.log('House removed.', res.data)
  }

  // async removeHouse(houseId, userId) {
  //   const toBeDeletedIndex = AppState.houses.findIndex(h => h.id = houseId)
  //   if (toBeDeletedIndex == -1) { throw new logger.error('Unable to locate house with ID: ', houseId); }
  //   const toBeDeleted = await api.get(`api/houses/${houseId}`)
  //   if (toBeDeleted.data.creatorId != userId) { throw new logger.error('Not your entry to remove'); }

  //   const res = await api.delete(`api/houses/${houseId}`);

  //   AppState.houses.splice(toBeDeletedIndex, 1);
  //   return res.data
  // }

  async updateHouse(houseId, newBody, userId) {
    const toBeUpdatedIndex = AppState.houses.findIndex(h => h.id = houseId)
    if (toBeUpdatedIndex == -1) { throw new logger.error('Unable to locate house with ID: ', houseId); }
    const toBeUpdated = await api.get(`api/houses/${houseId}`)
    if (toBeUpdated.data.creatorId != userId) { throw new logger.error('Not your entry to remove'); }

    toBeUpdated.year = newBody.year || toBeUpdated.year
    toBeUpdated.price = newBody.price || toBeUpdated.price
    toBeUpdated.imgUrl = newBody.imgUrl || toBeUpdated.imgUrl
    toBeUpdated.levels = newBody.levels || toBeUpdated.levels
    toBeUpdated.bedrooms = newBody.bedrooms || toBeUpdated.bedrooms
    toBeUpdated.bathrooms = newBody.bathrooms || toBeUpdated.bathrooms
    toBeUpdated.description = newBody.description || toBeUpdated.description

    const res = await api.put(`api/houses/${houseId}`, toBeUpdated);

    AppState.houses.splice(toBeUpdatedIndex, 1, new House(res.data));
    return res.data
  }

}

export const housesService = new HousesService();