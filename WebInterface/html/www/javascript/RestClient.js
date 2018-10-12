function RestClient(rootPath)
{
    var _rootPath = new String(rootPath);

    this.SelectClients = function SelectClients(skip, take, callback)
    {
        var url = _rootPath.concat("/desc/id?skip=" + skip + "&take=" + take);
        sendGetRequest(url, callback);
    }

    this.GetUsername = function GetUsername(callback)
    {
        var url = _rootPath.concat("/username");
        sendGetRequest(url, callback);
    }

    this.GetHtml = function GetHtml(url, callback)
    {
        sendGetRequest(url, callback);
    }


    function sendPost(url, postData, callback) {
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState === 4) {
                var result = new RestCallbackObj();
                result.Url = url;

                if (xmlHttp.status === 200) {
                    result.SetResponseText(xmlHttp.responseText);
                }
                else {
                    result.StatusCode = xmlHttp.status;
                    result.StatusText = xmlHttp.statusText;
                }

                callback(result);
            }
        };

        xmlHttp.open("POST", url, true);
        xmlHttp.setRequestHeader("Cache-Control", "no-cache");
        xmlHttp.setRequestHeader("Pragma", "no-cache");
        xmlHttp.send(postData);
    }

    function sendGetRequest(url, callback) {
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState === 4) {
                var result = new RestCallbackObj();
                result.Url = url;

                if (xmlHttp.status === 200) {
                    result.SetResponseText(xmlHttp.responseText);
                }
                else {
                    result.StatusCode = xmlHttp.status;
                    result.StatusText = xmlHttp.statusText;
                }

                callback(result);
            }
        };

        xmlHttp.open("GET", url, true);
        xmlHttp.setRequestHeader("Cache-Control", "no-cache");
        xmlHttp.setRequestHeader("Pragma", "no-cache");
        xmlHttp.send();
    }

    function GetErrorMessageString(statusCode, statusText) {
        return "Error Code: " + statusCode + "   " + statusText;
    }

}

function RestCallbackObj()
{
    var _this = this;

    this.StatusCode = 200;
    this.StatusText = "OK";
    this.ResponseText = null;
    this.ResponseJSON = null;
    this.Url = null;


    this.SetResponseText = function SetResponseText(responseText)
    {
        _this.ResponseText = responseText;

        try
        {
            _this.ResponseJSON = JSON.parse(responseText);
        }
        catch (Exception)
        {

        }
    }
}