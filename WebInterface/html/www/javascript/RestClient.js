function RestClient(rootPath)
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





    this.SelectJobs = function SelectJobs(skip, take, callback)
    {
        var url = _rootPath.concat("/desc/id?skip=" + skip + "&take=" + take);
        send(url, "GET", callback);
    }

    this.UpdateJob = function UpdateJob(job, callback)
    {
        var url = _rootPath;
        sendData(url, "PUT", JSON.stringify(job), callback);
    }

    this.InsertJob = function InsertJob(job, callback)
    {
        var url = _rootPath;
        sendData(url, "POST", JSON.stringify(job), callback);
    }

    this.DeleteJob = function DeleteJob(jobId, callback)
    {
        var url = _rootPath.concat("/" + jobId);
        send(url, "DELETE", callback);
    }




    this.SelectLeads = function SelectLeads(skip, take, callback)
    {
        var url = _rootPath.concat("/desc/id?skip=" + skip + "&take=" + take);
        send(url, "GET", callback);
    }

    this.UpdateLead = function UpdateLead(client, callback)
    {
        var url = _rootPath;
        send(url, "PUT", JSON.stringify(client), callback);
    }

    this.InsertLead = function InsertLead(client, callback)
    {
        var url = _rootPath;
        send(url, "POST", JSON.stringify(client), callback);
    }

    this.DeleteLead = function DeleteLead(clientId, callback)
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
        url = _rootPath.concat(url);
        send(url, "GET", callback);
    }






    function sendData(url, method, postData, callback)
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