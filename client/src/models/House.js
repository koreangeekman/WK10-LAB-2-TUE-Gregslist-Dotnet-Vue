// const houseModel = {
//   "bedrooms": {
//     "type": "Number",
//     "required": true
//   },
//   "bathrooms": {
//     "type": "Number",
//     "required": true
//   },
//   "levels": {
//     "type": "Number",
//     "required": true
//   },
//   "imgUrl": {
//     "type": "String",
//     "maxLength": 500
//   },
//   "year": {
//     "type": "Number",
//     "required": true
//   },
//   "price": {
//     "type": "Number",
//     "required": true
//   },
//   "description": {
//     "type": "String",
//     "maxLength": 5000
//   },
//   "creatorId": {
//     "type": "ObjectId",
//     "required": true,
//     "ref": "Account"
//   }
// }

// const house = {
//   "_id": "645d60f381faf24223ae886b",
//   "bedrooms": 3,
//   "bathrooms": 2,
//   "levels": 2,
//   "imgUrl": "https://floorcentral.com/wp-content/uploads/2014/07/sick-house-syndrome.jpg",
//   "year": 2003,
//   "price": 230000,
//   "description": "Super sick house",
//   "creatorId": "63f7d6202d1cf882287f12e2",
//   "createdAt": "2023-05-11T21:41:07.979Z",
//   "updatedAt": "2023-05-11T21:41:07.979Z",
//   "__v": 0,
//   "creator": {
//     "_id": "63f7d6202d1cf882287f12e2",
//     "name": "Charles Francis Xavier",
//     "picture": "https://www.looper.com/img/gallery/professor-xs-entire-backstory-explained/intro-1587748942.jpg",
//     "id": "63f7d6202d1cf882287f12e2"
//   },
//   "id": "645d60f381faf24223ae886b"
// }

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