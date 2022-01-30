### Part 1 (1_1)
In the first part javascript import and export operations implemented. 

Created and exported kopek.js
```ruby
const dog = {
    name: "Snow",
    height: "0,7",
    weight: 32,
};

export default dog;

```
--------------------------------------------------------------------------------------------------

Created and exported kopekBakimUtility.js

```ruby
const dogCareTime = 4;

const dogClear = () => {
    // console.log("Kopeginiz yikandi!");
    const washed = "Kopeginiz yikandi!";
    return washed;
};

export { dogCareTime, dogClear };

```

--------------------------------------------------------------------------------------------------

And files above mentioned imported in the index.html and their functions and objects used here.

```ruby

import dog from "./kopek.js";
import { dogCareTime, dogClear } from "./kopekBakimUtility.js";

const obj = dog;
// console.log("Kopek Adi: " + obj.name);
// console.log("Kopek Boyu: " + obj.height);
// console.log(dogClear());
// console.log("Kopek ilgi saati: " + dogCareTime * obj.weight);
console.log("Kopek Adi: " + obj.name + "\nKopek Boyu: " + obj.height + "\n" + dogClear() + "\nKopek ilgi saati: " + dogCareTime * obj.weight);
```

--------------------------------------------------------------------------------------------------

### OUTPUT

![1_1](https://user-images.githubusercontent.com/54467555/151720036-4d446f5b-abef-4f90-b23e-614aedf756b2.png)
