
let addBtn = document.querySelector('#add');
let subBtn = document.querySelector('#sub');
let qty = document.querySelector('#qtyBox');

addBtn.addEventListener('click', () => {
    if (qty.value < 12) {
        qty.value = parseInt(qty.value) + 1;
    }
});

subBtn.addEventListener('click', () => {
    if (qty.value <= 0) {
        qty.value = 0;
    }
    else {
        qty.value = parseInt(qty.value) - 1;
    }
});