using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Peek.Models.Clients;

namespace Peek.WebService.WebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Clients" in both code and config file together.
    public class ClientsWebSvc : IClientsWebSvc
    {
        public IEnumerable<ClientModel> SelectClients()
        {
            IEnumerable<ClientModel> models = null;

            try
            {

            }
            catch(Exception ex)
            {

            }

            return models;
        }
    }
}
