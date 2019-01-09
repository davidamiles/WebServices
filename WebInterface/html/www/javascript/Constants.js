function Constants()
{
    var _this = this;

    this.HtmlWebSvcPath = null;
    this.ClientsWebSvcPath = null;      
    this.JobsWebSvcPath = null;
    this.LeadsWebSvcPath = null;
    this.SystemWebSvcPath = null;
    this.Clients = [];
    
    this.Page = 1;
    this.Take = 10;

    this.Init = function init()
    {
        var scheme = window.location.protocol;
        var host = window.location.host;
        _this.HtmlWebSvcPath = scheme + "//" + host + "/html";
        _this.ClientsWebSvcPath = scheme + "//" + host + "/Clients";
        _this.JobsWebSvcPath = scheme + "//" + host + "/Jobs";
        _this.LeadsWebSvcPath = scheme + "//" + host + "/Leads";
        _this.SystemWebSvcPath = scheme + "//" + host + "/System";
    }
}
