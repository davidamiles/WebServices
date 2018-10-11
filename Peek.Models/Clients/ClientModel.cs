using Peek.Core.Utilities.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Models.Clients
{
    [DataContract()]
    public class ClientModel
    {
        public ClientModel()
        {
        }

        [DataMember()]
        public int Id { get; set; }

        [DataMember()]
        public string FullName { get; set; }

        [DataMember()]
        public string FirstName { get; set; }

        [DataMember()]
        public string LastName { get; set; }

        [DataMember()]
        public string MiddleName { get; set; }

        [DataMember()]
        public string CoClient { get; set; }

        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Phone1Num { get; set; }
        public string Phone1Type { get; set; }
        public string Phone1Notes { get; set; }
        public string Phone2Num { get; set; }
        public string Phone2Type { get; set; }
        public string Phone2Notes { get; set; }
        public string Phone3Num { get; set; }
        public string Phone3Type { get; set; }
        public string Phone3Notes { get; set; }
        public string Phone4Num { get; set; }
        public string Phone4Type { get; set; }
        public string Phone4Notes { get; set; }
        public string Phone5Num { get; set; }
        public string Phone5Type { get; set; }
        public string Phone5Notes { get; set; }
        public string ServiceContract { get; set; }

        [IgnoreDataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "CreatedDate")]
        public string CreatedDateString { get { return DateTimeUtil.GetISODateTimeString(CreatedDate); } set { CreatedDate = DateTime.Parse(value); } }

        [IgnoreDataMember]
        public DateTime ModifiedDate { get; set; }

        [DataMember(Name = "ModifiedDate")]
        public string ModifiedDateString { get { return DateTimeUtil.GetISODateTimeString(ModifiedDate); } set { ModifiedDate = DateTime.Parse(value); } }

        [IgnoreDataMember]
        public DateTime LastActivity { get; set; }

        [DataMember(Name = "LastActivityDate")]
        public string LastActivityDateString { get { return DateTimeUtil.GetISODateTimeString(LastActivity); } set { LastActivity = DateTime.Parse(value); } }

        [IgnoreDataMember]
        public DateTime ClientAcceptedDate { get; set; }

        [DataMember(Name = "ClientAcceptedDate")]
        public string ClientAcceptedDateString { get { return DateTimeUtil.GetISODateTimeString(ClientAcceptedDate); } set { ClientAcceptedDate = DateTime.Parse(value); } }

        [IgnoreDataMember]
        public DateTime ClientDeniedDate { get; set; }

        [DataMember(Name = "ClientDeniedDate")]
        public string ClientDeniedDateString { get { return DateTimeUtil.GetISODateTimeString(ClientDeniedDate); } set { ClientDeniedDate = DateTime.Parse(value); } }


        public string InsuranceCompany { get; set; }
        public string ClaimNumber { get; set; }
        public string AdjusterName { get; set; }
        public string AdjusterPhoneNum { get; set; }

        [IgnoreDataMember]
        public DateTime NextActivityDate { get; set; }

        [DataMember(Name = "NextActivityDate")]
        public string NextActivityDateString { get { return DateTimeUtil.GetISODateTimeString(NextActivityDate); } set { NextActivityDate = DateTime.Parse(value); } }

        [DataMember()]
        public int Priority { get; set; }

        [DataMember()]
        public string Notes { get; set; }

        [DataMember()]
        public string Type { get; set; }

        [DataMember()]
        public string SubType { get; set; }

        [DataMember()]
        public string AssignedTo { get; set; }

        [DataMember()]
        public string Username { get; set; }


    }
}
