function addGuest(event) {
    event.preventDefault();
    window.get(event.currentTarget.attributes["href"].value, loadGuest)
}

function loadGuest(event) {
    if (event.currentTarget.readyState === XMLHttpRequest.DONE) {
        document.getElementById("participations").insertAdjacentHTML('beforeend', event.currentTarget.responseText);
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    document.getElementById("addguest").addEventListener("click", addGuest);
});