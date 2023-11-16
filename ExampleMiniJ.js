let a = "Hello world this many times: ";
const e = 16;
let testArray = [1, 4, 56, 3];

function AddFunc(t) {
    t + e;
    return t;
};

function Calculate(){
    let temp = 0;
    for(let i = 0; i < testArray.length; i++)
    {
        temp += testArray[i];
    }
    return temp;
};

let result = AddFunc(7);
if(result <= 19)
{
    result += Calculate();
} else 
{
    result -= 28;
};

console.log(a + result);
