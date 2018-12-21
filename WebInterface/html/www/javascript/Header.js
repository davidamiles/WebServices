function loadHeader(url)
{
    var restClient = new RestClient(url)
    restClient.GetHtml("/parts/Header.html", function (restCallbackObj)
    {
        document.getElementById("headerSection").innerHTML = restCallbackObj.ResponseText;
    });
}