using Peek.Models.Jobs;
using Peek.WebService.Models;
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
    public interface IJobsWebSvc
    {
        [OperationContract]
        [WebGet(UriTemplate = "?page={page}&take={take}")]
        Result<JobModel> SelectJobs(string page, string take);

        [OperationContract]
        [WebGet(UriTemplate = "{client}/{status}/{assignedTo}?page={page}&take={take}")]
        Result<JobModel> SelectJobsWithFilter(string client, string status, string assignedTo, string page, string take);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}")]
        void DeleteJob(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "")]
        void InsertJob(Stream stream);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "")]
        void UpdateJob(Stream stream);
    }
}
