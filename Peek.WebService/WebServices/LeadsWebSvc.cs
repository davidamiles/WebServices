using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Peek.Models.Leads;
using Peek.Repository;
using Peek.Repository.Leads;

namespace Peek.WebService.WebServices
{
    internal sealed class LeadsWebSvc : BaseWebService, ILeadsWebSvc
    {
        public LeadsWebSvc() : base("LeadsWebSvc", null, false)
        {

        }


        public IEnumerable<LeadModel> SelectLeads(string skip, string take)
        {
            IEnumerable<LeadModel> models = null;

            try
            {
                int s = int.Parse(skip);
                int t = int.Parse(take);

                ILeadsRepo repo = RepoFactory.GetLeadsRepo();
                models = repo.Select(s, t);
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

            return models;
        }
    }
}
