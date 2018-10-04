function LoginRestService(serverEndPoint) {
    var _rootPath = new String(serverEndPoint);

    this.Login = function Login(username, password, callback) {
        var loginPath = _rootPath.concat("/Login");

        var xmlHttp = new XMLHttpRequest();

        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState === 4) {
                callback(xmlHttp.status);
            }
        };

        xmlHttp.open("GET", loginPath, true, username, password);
        xmlHttp.setRequestHeader("Cache-Control", "no-cache");
        xmlHttp.setRequestHeader("Pragma", "no-cache");
        xmlHttp.send();
    };
}