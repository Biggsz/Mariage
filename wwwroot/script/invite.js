function hasPlusOneChange(elem) {
    let plusone = document.getElementById("plusone");
    if (plusone != null) {
        if (elem.checked) {
            plusone.classList.remove("hidden");
        }
        else {
            plusone.classList.add("hidden");
        }
    }
}