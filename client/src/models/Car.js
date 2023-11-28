export class Car {
  constructor(data) {
    this.id = data.id || data._id
    this.make = data.make
    this.model = data.model
    this.imgUrl = data.imgUrl
    this.year = data.year
    this.price = data.price
    this.color = data.color || '#000000'
    this.description = data.description
    this.engineType = data.engineType
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}