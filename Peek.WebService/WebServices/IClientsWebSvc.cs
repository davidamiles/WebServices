﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Peek.Models.Clients;

namespace Peek.WebService.WebServices
{
    
    [ServiceContract]
    public interface IClientsWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "")]
        IEnumerable<ClientModel> SelectClients();        
        
    }
}
