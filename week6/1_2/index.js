const girlsPowerSum = (number) => {
    number = number / 2 + 3;
    return number;
};

// console.log(girlsPowerSum(2));

const numberArray = [2, 3, 4];
const girlsPowerFunc = numberArray.map((x) => girlsPowerSum(x));
// girlsPowerFunc is a high order function that takes an array and implementing each element to girlsPowerSum
//function and returning again, as an array.

console.log(girlsPowerFunc);
