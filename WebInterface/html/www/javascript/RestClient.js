﻿function RestClient(rootPath)
{
    var _rootPath = new String(rootPath);

    this.SelectClients = function SelectClients(skip, take, callback)
    {
        var url = _rootPath.concat("/desc/id?skip=" + skip + "&take=" + take);
        send(url, "GET", callback);
    }

    this.UpdateClient = function UpdateClient(client, callback)
    {
        var url = _rootPath;
        send(url, "PUT", JSON.stringify(client), callback);
    }

    this.InsertClient = function InsertClient(client, callback)
    {
        var url = _rootPath;
        send(url, "POST", JSON.stringify(client), callback);
    }

    this.DeleteClient = function DeleteClient(clientId, callback)
    {
        var url = _rootPath.concat("/" + clientId);
        send(url, "DELETE", callback);
    }

    this.GetUsername = function GetUsername(callback)
    {
        var url = _rootPath.concat("/username");
        send(url, "GET", callback);
    }

    this.GetHtml = function GetHtml(url, callback)
    {
        send(url, "GET", callback);
    }






    function send(url, method, postData, callback)
    {
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = function ()
        {
            if (xmlHttp.readyState === 4)
            {
                var result = new RestCallbackObj();
                result.Url = url;

                if (xmlHttp.status === 200)
                {
                    result.SetResponseText(xmlHttp.responseText);
                }
                else
                {
                    result.StatusCode = xmlHttp.status;
                    result.StatusText = xmlHttp.statusText;
                }

                callback(result);
            }
        };

        xmlHttp.open(method, url, true);
        xmlHttp.setRequestHeader("Cache-Control", "no-cache");
        xmlHttp.setRequestHeader("Pragma", "no-cache");
        xmlHttp.send(postData);
    }    

    function send(url, method, callback)
    {
        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = function ()
        {
            if (xmlHttp.readyState === 4)
            {
                var result = new RestCallbackObj();
                result.Url = url;

                if (xmlHttp.status === 200)
                {
                    result.SetResponseText(xmlHttp.responseText);
                }
                else
                {
                    result.StatusCode = xmlHttp.status;
                    result.StatusText = xmlHttp.statusText;
                }

                callback(result);
            }
        };

        xmlHttp.open(method, url, true);
        xmlHttp.setRequestHeader("Cache-Control", "no-cache");
        xmlHttp.setRequestHeader("Pragma", "no-cache");
        xmlHttp.send();
    }
    
    function GetErrorMessageString(statusCode, statusText)
    {
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