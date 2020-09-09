 if (document.readyState == "loading") {
document.addEventListener("DOMContentLoaded", ready)
}
else {
    ready()
}

var totalItems = 0;

function ready() {

    var aux = localStorage.getItem("totalProducts")
    localStorage.setItem("totalProducts", totalItems);

}


