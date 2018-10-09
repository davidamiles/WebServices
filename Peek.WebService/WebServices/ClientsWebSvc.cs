using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Peek.Models.Clients;
using Peek.Repository.Clients;

namespace Peek.WebService.WebServices
{    
    internal sealed class ClientsWebSvc : BaseWebService, IClientsWebSvc
    {
        public ClientsWebSvc() : base("ClientsWebSvc", null, false)
        {
        }

        public IEnumerable<ClientModel> SelectClients(string skip, string take)
        {
            IEnumerable<ClientModel> models = null;

            try
            {
                IClientRepo repo = Repository.RepoFactory.GetClientRepo();
                models = repo.Select(0, 10);
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
