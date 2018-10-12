using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Peek.WebService.WebServices
{    
    [ServiceContract]
    public interface ISystemWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "username")]
        string GetUsername();
    }
}
