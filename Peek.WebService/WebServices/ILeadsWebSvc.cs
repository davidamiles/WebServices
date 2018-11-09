using Peek.Models.Leads;
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
    public interface ILeadsWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "desc/id?skip={skip}&take={take}")]
        IEnumerable<LeadModel> SelectLeads(string skip, string take);
    }
}
