using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Entity.Validation;
using Peek.Models.Clients;
using Peek.Repository.Clients;

namespace Peek.WebService.WebServices
{    
    internal sealed class ClientsWebSvc : BaseWebService, IClientsWebSvc
    {
        public ClientsWebSvc() : base("ClientsWebSvc", null, false)
        {
        }

        public void Delete(string clientId)
        {
            try
            {
                IClientRepo repo = Repository.RepoFactory.GetClientRepo();
            }
            catch(DbEntityValidationException ex)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                response.StatusDescription = "Bad Request";
                
               
                base.LogMessage(ex.Message, Peek.Models.LogSeverity.Error, ex.StackTrace);
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
        }

        public void Insert(Stream stream)
        {
            try
            {
                byte[] data = BaseWebService.GetBufferFromStream(stream);
                IClientRepo repo = Repository.RepoFactory.GetClientRepo();
            }
            catch(DbEntityValidationException ex)
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
        }

        public IEnumerable<ClientModel> SelectClients()
        {
            IEnumerable<ClientModel> models = null;

            try
            {
                IClientRepo repo = Repository.RepoFactory.GetClientRepo();
                models = repo.Select().OrderBy(c => c.CoClient);
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
        

        public void Update(Stream stream)
        {
            try
            {
                byte[] data = BaseWebService.GetBufferFromStream(stream);

                IClientRepo repo = Repository.RepoFactory.GetClientRepo();

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
        }



      
    }
}
