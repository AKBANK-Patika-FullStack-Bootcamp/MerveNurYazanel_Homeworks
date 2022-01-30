const word = "asli";
console.log("Word: " + word);

//-----------1---------

function reverseWord_1(str) {
    let reversed_1 = "";
    for (let i = str.length - 1; i >= 0; i--) {
        reversed_1 += str[i];
    }
    return reversed_1;
}

console.log("for loop: " + reverseWord_1(word));

//-----------2---------

function reverseWord_2(str) {
    let reversed_2 = str.split("").reverse().join("");

    return reversed_2;
}

console.log("built-in fuctions: " + reverseWord_2(word));

//-----------3---------

function reverseWord_3(str) {
    let reversed_3 = str.split("").reduce((rev, char) => char + rev, "");
    return reversed_3;
}
console.log("Array.prototype.reduce(): " + reverseWord_3(word));

//-----------3---------

function reverseWord_4(str) {
    if (str === "") return "";
    else return reverseWord_4(str.substr(1)) + str.charAt(0);
}
console.log("recursive function: " + reverseWord_4(word));
