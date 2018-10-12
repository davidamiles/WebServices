function Constants()
{
    var _this = this;

    this.ClientsWebSvcPath = null;
    this.SystemWebSvcPath = null;
    this.Page = 1;
    this.Take = 10;

    this.Init = function init()
    {
        var scheme = window.location.protocol;
        var host = window.location.host;

        _this.ClientsWebSvcPath = scheme + "//" + host + "/Clients";
        _this.SystemWebSvcPath = scheme + "//" + host + "/System"
    }
}
