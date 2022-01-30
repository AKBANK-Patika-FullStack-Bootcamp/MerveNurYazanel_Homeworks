## Part 1 (1_1)
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

--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------

## Part 2 (1_2)

In the second part of the homework javascript high order functions implemented and tested.

 The girlsPowerSum makes a special sum for given number.

```ruby
const girlsPowerSum = (number) => {
    number = number / 2 + 3;
    return number;
};

```

--------------------------------------------------------------------------------------------------

 The girlsPowerFunc is a high order function that takes an array and implementing each element to girlsPowerSum function and returning again, as an array.
 
 ```ruby
const numberArray = [2, 3, 4];
const girlsPowerFunc = numberArray.map((x) => girlsPowerSum(x));
// girlsPowerFunc is a high order function that takes an array and implementing each element to girlsPowerSum
//function and returning again, as an array.

console.log(girlsPowerFunc);
```

--------------------------------------------------------------------------------------------------

### OUTPUT
![1_2](https://user-images.githubusercontent.com/54467555/151720327-1bb7a171-992c-4305-b845-61034e94091a.png)


--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------


## Part 3 (1_3)

In the third part 4 javascript string reverse way tested.



```ruby
const word = "asli";
console.log("Word: " + word);
```



#### 1 Reverse by using for Loop

```ruby
function reverseWord_1(str) {
    let reversed_1 = "";
    for (let i = str.length - 1; i >= 0; i--) {
        reversed_1 += str[i];
    }
    return reversed_1;
}

console.log("for loop: " + reverseWord_1(word));
```

--------------------------------------------------------------------------------------------------

#### 2 Reverse by using built-in functions


```ruby
function reverseWord_2(str) {
    let reversed_2 = str.split("").reverse().join("");

    return reversed_2;
}

console.log("built-in fuctions: " + reverseWord_2(word));

```

--------------------------------------------------------------------------------------------------

#### 3 Reverse by using Array.prototype.reduce()


```ruby

function reverseWord_3(str) {
    let reversed_3 = str.split("").reduce((rev, char) => char + rev, "");
    return reversed_3;
}
console.log("Array.prototype.reduce(): " + reverseWord_3(word));

```

--------------------------------------------------------------------------------------------------

#### 4 Reverse by using recursion

```ruby
function reverseWord_4(str) {
    if (str === "") return "";
    else return reverseWord_4(str.substr(1)) + str.charAt(0);
}
console.log("recursive function: " + reverseWord_4(word));

```

### OUTPUT
![1_3](https://user-images.githubusercontent.com/54467555/151720480-a4edbe5d-430a-4ef6-8bc2-d275baa8820d.png)





