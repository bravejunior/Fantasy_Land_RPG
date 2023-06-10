// const { createApp } = Vue;

// createApp({
//   data() {
//     return {
//       visible: false,

//       pointsLeft: 15,

//       /*array containing attributes + currently chosen amount during character creation*/
//       attributeAmount: [
//         {
//           attribute: "strength",
//           points: 10,
//         },
//         {
//           attribute: "constitution",
//           points: 10,
//         },
//         {
//           attribute: "dexterity",
//           points: 10,
//         },
//         {
//           attribute: "intelligence",
//           points: 10,
//         },
//         {
//           attribute: "wisdom",
//           points: 10,
//         },
//         {
//           attribute: "charisma",
//           points: 10,
//         },
//       ],

//       attributes: [
//         /*Array containing all attributes*/
//         {
//           attribute: "strength",
//           //image: "./productImages/pradamas-gifarry-889Qh5HJj4I-unsplash.jpg",
//           description: "str desc",
//         },
//         {
//           attribute: "constitution",
//           //image: "./productImages/alex-perz-61qBPJeUYcE-unsplash.jpg",
//           description: "con desc",
//         },
//         {
//           attribute: "dexterity",
//           //image: "./productImages/hassan-ouajbir-IYU_YmMRm7s-unsplash.jpg",
//           description: "dex desc",
//         },
//         {
//           attribute: "intelligence",
//           //image: "./productImages/hassan-ouajbir-IYU_YmMRm7s-unsplash.jpg",
//           description: "int desc",
//         },
//         {
//           attribute: "wisdom",
//           //image: "./productImages/hassan-ouajbir-IYU_YmMRm7s-unsplash.jpg",
//           description: "wis desc",
//         },
//         {
//           attribute: "charisma",
//           //image: "./productImages/hassan-ouajbir-IYU_YmMRm7s-unsplash.jpg",
//           description: "cha desc",
//         },
//       ],
//     };
//   },
//   methods: {
//     incrementAttribute(attribute) {
//       let i = 0;
//       let searching = true;

//       while (i < this.attributeAmount.length && searching) {
//         if (this.attributeAmount[i].attribute === attribute) {
//           if (this.attributeAmount[i].points < 18 && this.pointsLeft != 0) {
//             this.attributeAmount[i].points++;
//             this.pointsLeft--;
//           }
//           searching = false;
//         } else {
//           i++;
//         }
//       }
//     },

//     decrementAttribute(attribute) {
//       let i = 0;
//       let searching = true;

//       while (i < this.attributeAmount.length && searching) {
//         if (this.attributeAmount[i].attribute === attribute) {
//           if (this.attributeAmount[i].points > 8) {
//             this.attributeAmount[i].points--;
//             this.pointsLeft++;
//           }
//           searching = false;
//         } else {
//           i++;
//         }
//       }
//     },
//   },

//   computed: {
//     getPointsLeft() {
//       let pointsLeft = 10;

//       for (const i of this.attributeAmount) {
//         this.pointsLeft = this.pointsLeft - i.points;
//       }
//       return pointsLeft;
//     },

//     getStrength() {
//       let result = 0;
//       for (const i of this.attributeAmount) {
//         if (i.attribute === "strength") {
//           result = i.points;
//           break;
//         }
//       }
//       // console.log(this.pointsLeft);
//       console.log(result);
//       return result;
//     },

//     getConstitution() {
//       let result = 0;
//       for (const i of this.attributeAmount) {
//         if (i.attribute === "constitution") {
//           result = i.points;
//           break;
//         }
//       }
//       return result;
//     },

//     getDexterity() {
//       let result = 0;
//       for (const i of this.attributeAmount) {
//         if (i.attribute === "dexterity") {
//           result = i.points;
//           break;
//         }
//       }
//       return result;
//     },

//     getIntelligence() {
//       let result = 0;
//       for (const i of this.attributeAmount) {
//         if (i.attribute === "intelligence") {
//           result = i.points;
//           break;
//         }
//       }
//       return result;
//     },

//     getWisdom() {
//       let result = 0;
//       for (const i of this.attributeAmount) {
//         if (i.attribute === "wisdom") {
//           result = i.points;
//           break;
//         }
//       }
//       return result;
//     },

//     getCharisma() {
//       let result = 0;
//       for (const i of this.attributeAmount) {
//         if (i.attribute === "charisma") {
//           result = i.points;
//           break;
//         }
//       }
//       return result;
//     },
//   },
// }).mount("#create-character-container");
