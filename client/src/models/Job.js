// const jobModel = {
//   "company": {
//     "type": "String",
//     "required": true,
//     "maxLength": 100
//   },
//   "jobTitle": {
//     "type": "String",
//     "required": true,
//     "maxLength": 100
//   },
//   "hours": {
//     "type": "Number",
//     "required": true
//   },
//   "rate": {
//     "type": "Number",
//     "required": true
//   },
//   "description": {
//     "type": "String",
//     "maxLength": 5000
//   },
//   "creatorId": {
//     "type": "ObjectId",
//     "ref": "Account"
//   }
// }

// const job = {
//   "_id": "65023abc143fc54c2351917f",
//   "company": "Home Workers",
//   "jobTitle": "Rubber Duck",
//   "hours": 100,
//   "rate": 100,
//   "description": "You must be the rubber duck on my desk indefinitely, or until I write 0 bugs in my code ",
//   "creatorId": "64f21983a9fdc55a60530663",
//   "createdAt": "2023-09-13T22:42:05.000Z",
//   "updatedAt": "2023-09-13T22:42:05.000Z",
//   "__v": 0,
//   "creator": {
//     "_id": "64f21983a9fdc55a60530663",
//     "name": "Everett",
//     "picture": "https://s.gravatar.com/avatar/a35d00c7bf46d0df283833dabcc9210d?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fev.png",
//     "id": "64f21983a9fdc55a60530663"
//   },
//   "id": "65023abc143fc54c2351917f"
// }

export class Job {
  constructor(data) {
    this.id = data.id
    this.company = data.company
    this.jobTitle = data.jobTitle
    this.hours = data.hours
    this.rate = data.rate
    this.description = data.description
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
  }
}