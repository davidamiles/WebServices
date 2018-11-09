using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Peek.Models.Leads;

namespace Peek.WebService.WebServices
{
    internal sealed class LeadsWebSvc : BaseWebService, ILeadsWebSvc
    {
        public LeadsWebSvc() : base("LeadsWebSvc", null, false)
        {

        }


        public IEnumerable<LeadModel> SelectLeads(string skip, string take)
        {
            throw new NotImplementedException();
        }
    }
}
