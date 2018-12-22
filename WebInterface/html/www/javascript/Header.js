function loadHeader(url, callback)
{
    var restClient = new RestClient(url)
    restClient.GetHtml("/parts/Header.html", function (restCallbackObj)
    {
        document.getElementById("headerSection").innerHTML = restCallbackObj.ResponseText;

        callback();
    });
}

function getUsername(url)
{
    var restClient = new RestClient(url)
    restClient.GetUsername(function (restCallbackObj)
    {
        document.getElementById("usernameDiv").innerHTML = restCallbackObj.ResponseText;        
    });
}

function logout()
{
    var xmlHttp = new XMLHttpRequest();

    xmlHttp.onreadystatechange = function ()
    {
        if (xmlHttp.readyState === 4)
        {
            var scheme = window.location.protocol;

            var host = window.location.host;

            var url = scheme + "//" + host + "/login/logout.html";

            window.location.assign(url);
        }
    };

    xmlHttp.open("GET", this.RootPath + "/Ping", true, "invalidusername", "invalidpassword");
    xmlHttp.setRequestHeader("Cache-Control", "no-cache");
    xmlHttp.setRequestHeader("Pragma", "no-cache");

    xmlHttp.send();
}