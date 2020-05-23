window.get = function (url, callback, token) {
    httpRequest = new XMLHttpRequest();
    if (token !== undefined) {
        token.cancel = function () {
            httpRequest.abort();
        }
    }

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

window.onClosePopupClick = function (event) {
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
    window.initPopup(popup);
    window.initSearchable(popup);
}

window.onSearch = function (event) {
    if (window.seachToken !== undefined && window.seachToken.cancel !== undefined) {
        window.seachToken.cancel();
    }
    var input = event.currentTarget;
    window.seachToken = {};
    searchable = input.closest(".searchable");
    var url = searchable.attributes['data-url'].value + "?search=" + input.value;
    window.get(url, function (result) {
        searchable.querySelector('.searchable-results').innerHTML = result;
        var results = searchable.getElementsByClassName("searchable-result");
        for (var i = 0; i < results.length; i++) {
            results[i].onclick = onResultClick;
        }
    }, window.seachToken)
}

window.onResultClick = function (event) {
    var result = event.currentTarget;
    var searchable = result.closest(".searchable");
    var serachableValue = searchable.querySelector(".searchable-value");
    serachableValue.value = result.attributes["data-value"].value;

    var searchableName = searchable.querySelector(".searchable-name");
    searchableName.value = result.innerText;

    var searchableResults = result.closest(".searchable-results");
    searchableResults.innerHTML = "";
}

window.initSearchable = function (elem) {
    var searchables = elem.getElementsByClassName("searchable");
    for (var i = 0; i < searchables.length; i++) {
        var input = searchables[i].querySelector(".searchable-name");
        input.onkeyup = onSearch;
    }
}

window.initPopup = function (elem) {
    var popups = elem.getElementsByClassName("popup-loader");
    for (var i = 0; i < popups.length; i++) {
        popups[i].onclick = onPopupLoaderClick;
    }
}

document.addEventListener("DOMContentLoaded", function (event) {

    window.initPopup(document);
    window.initSearchable(document);
});