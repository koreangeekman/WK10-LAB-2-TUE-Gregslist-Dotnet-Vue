export class House {
  constructor(data) {
    this.id = data.id
    this.year = data.year
    this.price = data.price
    this.imgUrl = data.imgUrl
    this.levels = data.levels
    this.bedrooms = data.bedrooms
    this.bathrooms = data.bathrooms
    this.description = data.description
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}