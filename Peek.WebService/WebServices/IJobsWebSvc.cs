using Peek.Models.Jobs;
using Peek.WebService.Models;
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
        [WebGet(UriTemplate = "?page={page}&take={take}")]
        Result<JobModel> SelectJobs(string page, string take);
    }
}
