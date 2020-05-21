window.get = function (url, callback) {
    httpRequest = new XMLHttpRequest();
    httpRequest.callback = callback;
    httpRequest.onreadystatechange = function (event) {
        if (httpRequest.readyState === XMLHttpRequest.DONE) {
            var response = event.currentTarget.responseText;
            callback(response);
        } else {
            // Not ready yet.
        }
    }
    httpRequest.open('GET', url, true);
    httpRequest.send();
}

window.onPopupLoaderClick = function (event) {
    event.preventDefault();
    var elem = event.currentTarget;
    var url = elem.attributes["href"].value;
    loadPopup(url);
}

window.loadPopup = function (url) {
    window.get(url, window.applyPopupp);
}

window.onClosePopupClick = function(event) {
 var target = event.currentTarget;
 var popup = target.closest('.popup-container');
 popup.remove();
}

window.applyPopupp = function (content) {
    var popupcontainer = document.createElement("div");
    popupcontainer.className = "popup-container";
    document.body.append(popupcontainer);

    var popup = document.createElement("div");
    popup.className = "popup";
    popupcontainer.append(popup);

    var popupTop = document.createElement("div");
    popupTop.className = "popup-top";
    popup.append(popupTop);

    var closeButton = document.createElement("span");
    closeButton.className = "close-button";
    closeButton.innerText = 'X';
    closeButton.onclick = window.onClosePopupClick;
    popupTop.append(closeButton);

    var popupContent = document.createElement("div");
    popupContent.className = "popup-content"; 
    popupContent.innerHTML = content;
    popup.append(popupContent);    
}

document.addEventListener("DOMContentLoaded", function (event) {
    var popups = document.getElementsByClassName("popup-loader");
    for (var i = 0; i < popups.length; i++) {
        popups[i].onclick = onPopupLoaderClick;
    }
});