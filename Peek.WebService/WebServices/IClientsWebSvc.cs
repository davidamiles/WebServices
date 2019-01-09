using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

using Peek.Models.Clients;

namespace Peek.WebService.WebServices
{
    
    [ServiceContract]
    public interface IClientsWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "")]
        IEnumerable<ClientModel> SelectClients();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "")]
        void Insert(Stream stream);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "")]
        void Update(Stream stream);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{clientId}")]
        void Delete(string clientId);
        
    }
}
