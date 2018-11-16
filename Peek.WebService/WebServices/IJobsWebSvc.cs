using Peek.Models.Jobs;
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
    public interface IJobsWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "desc/id?skip={skip}&take={take}")]
        IEnumerable<JobModel> SelectJobs(string skip, string take);
    }
}
