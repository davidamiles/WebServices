function Constants()
{
    var _this = this;

    this.ClientsWebSvcPath = null;
    this.SystemWebSvcPath = null;
    this.BaseWebSvcPath = null;
    this.Page = 1;
    this.Take = 10;

    this.Init = function init()
    {
        var scheme = window.location.protocol;
        var host = window.location.host;
        _this.BaseWebSvcPath = scheme + "//" + host + "/html";
        _this.ClientsWebSvcPath = scheme + "//" + host + "/Clients";
        _this.JobsWebSvcPath = scheme + "//" + host + "/Jobs";
        _this.LeadsWebSvcPath = scheme + "//" + host + "/Leads";
        _this.SystemWebSvcPath = scheme + "//" + host + "/System";
    }
}
