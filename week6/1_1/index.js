import dog from "./kopek.js";
import { dogCareTime, dogClear } from "./kopekBakimUtility.js";

const obj = dog;
// console.log("Kopek Adi: " + obj.name);
// console.log("Kopek Boyu: " + obj.height);
// console.log(dogClear());
// console.log("Kopek ilgi saati: " + dogCareTime * obj.weight);
console.log("Kopek Adi: " + obj.name + "\nKopek Boyu: " + obj.height + "\n" + dogClear() + "\nKopek ilgi saati: " + dogCareTime * obj.weight);
