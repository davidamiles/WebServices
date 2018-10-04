using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Peek.WebService.WebServices
{    
    [ServiceContract]
    public interface ILoginWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "{*path}")]
        Stream GetResource(string path);
    }
}
