// const carModel = {
//   "make": {
//     "type": "String",
//     "required": true,
//     "maxLength": 500
//   },
//   "model": {
//     "type": "String",
//     "required": true,
//     "maxLength": 500
//   },
//   "imgUrl": {
//     "type": "String",
//     "required": true,
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
//     "maxLength": 500
//   },
//   "color": {
//     "type": "String",
//     "validate": [
//       null,
//       "you must pass a valid color hexcode"
//     ]
//   },
//   "engineType": {
//     "type": "String",
//     "enum": [
//       "unknown",
//       "2 stroke",
//       "4 cylinder",
//       "v6",
//       "v8",
//       "v10",
//       "v12",
//       "small",
//       "medium",
//       "large",
//       "chuncko"
//     ],
//     "default": "unknown"
//   },
//   "creatorId": {
//     "type": "ObjectId",
//     "required": true,
//     "ref": "Account"
//   }
// }

// const car = {
//   "_id": "6463f57cafbe13b729b64cbd",
//   "make": "Indian",
//   "model": "Scout",
//   "imgUrl": "https://cdn-fastly.motorcycle.com/media/2023/02/26/8998036/2022-indian-scout-rogue-confirmed-by-nhtsa.jpg?size=1200x628",
//   "year": 2022,
//   "price": 12000,
//   "description": "It's so pretty 🤤",
//   "engineType": "unknown",
//   "creatorId": "6463f55d54c66ad9f7f1efcf",
//   "createdAt": "2023-05-16T21:28:28.384Z",
//   "updatedAt": "2023-05-16T21:28:28.384Z",
//   "__v": 0,
//   "creator": {
//     "_id": "6463f55d54c66ad9f7f1efcf",
//     "name": "bullwulfe",
//     "picture": "https://s.gravatar.com/avatar/e8a20af81297e006d4171be71683424d?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fbu.png",
//     "id": "6463f55d54c66ad9f7f1efcf"
//   },
//   "id": "6463f57cafbe13b729b64cbd"
// }

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