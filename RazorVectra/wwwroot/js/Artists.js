if (document.readyState == "loading") {
    document.addEventListener("DOMContentLoaded", ready)
}
else {
    ready()
}


function ready() {

    setTheCart();
}


function setTheCart() {
    var numProducts = localStorage.getItem("totalProducts");
    if (numProducts) {
        document.querySelector('.cart-quantity').textContent = numProducts;
    }
    else {
        document.querySelector('.cart-quantity').textContent = 0;
    }
}



