if (document.readyState == "loading") {
    document.addEventListener("DOMContentLoaded", ready)
}
else {
    ready()
}


function ready() {

    //initializeQuantities();

    var buyButtons = document.getElementsByClassName("btn btn-primary");
    for (var i = 0; i < buyButtons.length; i++) {
        buyButtons[i].addEventListener("click", pressedBuy);
    }

}


function pressedBuy(event) {

    var numProducts = localStorage.getItem("totalProducts");

    var aux = parseInt(numProducts);

    if (numProducts) {
        localStorage.setItem("totalProducts", aux + 1);
        document.querySelector('.cart-quantity').textContent = aux + 1;
    }
    else {
        localStorage.setItem("totalProducts", 1);
        document.querySelector('.cart-quantity').textContent = 1;
    }

    quantity++;
    localStorage.setItem(title, quantity);

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

setTheCart();


