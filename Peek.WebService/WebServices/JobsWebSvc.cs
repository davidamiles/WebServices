using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Peek.Core.Utilities.Json;
using Peek.Models.Jobs;
using Peek.Repository;
using Peek.Repository.Jobs;
using Peek.WebService.Models;

namespace Peek.WebService.WebServices
{
    internal sealed class JobsWebSvc : BaseWebService, IJobsWebSvc
    {
       public JobsWebSvc() : base("JobsWebSvc", null, false)
       {
       }

        public void DeleteJob(string id)
        {
            try
            {
                int recordId = int.Parse(id);

                IJobsRepo repo = RepoFactory.GetJobsRepo();
                repo.Delete(new JobModel() { Id = recordId });
            }
            catch(FormatException ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Bad Request";

                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
            catch(Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = "Internal Server Error";

                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
        }

        public void InsertJob(Stream stream)
        {
            try
            {
                byte[] buffer = BaseWebService.GetBufferFromStream(stream);
                string jsonString = ASCIIEncoding.ASCII.GetString(buffer);

                JobModel model = JsonSerializer.Deserialize<JobModel>(buffer);
                model.CreateDate = DateTime.UtcNow;
                model.LastTruedUpDate = DateTime.UtcNow;
                model.LastActivity = DateTime.UtcNow;                

                IJobsRepo repo = RepoFactory.GetJobsRepo();
                repo.Insert(model);
            }
            catch (DbEntityValidationException ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Bad Request";

                string errorMessage = base.GetErrorMessageFromEntityValidationException(ex);

                base.LogMessage(errorMessage, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
            catch (Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = "Internal Server Error";

                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
        }

        public Result<JobModel> SelectJobs(string page, string take)
        {
            Result<JobModel> result = null;

            try
            {
                int t = int.Parse(take);
                int s = int.Parse(page) * t;                

                IJobsRepo repo = RepoFactory.GetJobsRepo();
                IEnumerable<JobModel> models = repo.Select(s, t);
                long total = repo.Count();
                result =  new Result<JobModel>() { Records = models.ToList(), TotalRecordsCount = total };
            }           
            catch (DbEntityValidationException ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Bad Request";

                string errorMessage = base.GetErrorMessageFromEntityValidationException(ex);

                base.LogMessage(errorMessage, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
            catch (FormatException ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Bad Request";

                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
            catch (Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = "Internal Server Error";

                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }

            return result;
        }

        public void UpdateJob(Stream stream)
        {
            try
            {
                byte[] buffer = BaseWebService.GetBufferFromStream(stream);
                string jsonString = ASCIIEncoding.ASCII.GetString(buffer);

                JobModel model = JsonSerializer.Deserialize<JobModel>(buffer);
                IJobsRepo repo = RepoFactory.GetJobsRepo();
                repo.Update(model);
            }
            catch (DbEntityValidationException ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Bad Request";

                string errorMessage = base.GetErrorMessageFromEntityValidationException(ex);

                base.LogMessage(errorMessage, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
            catch (Exception ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.StatusDescription = "Internal Server Error";

                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
            }
        }
    }
}
