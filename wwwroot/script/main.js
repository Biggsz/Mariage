window.get = function(url,callback)
{
    httpRequest = new XMLHttpRequest();
    httpRequest.callback = callback;
    httpRequest.onreadystatechange = callback;
    httpRequest.open('GET', url, true);
    httpRequest.send();
}

onRequestStatusChange = function(event)
{
    if (httpRequest.readyState === XMLHttpRequest.DONE) {
        // Everything is good, the response was received.
    } else {
        // Not ready yet.
    }
}