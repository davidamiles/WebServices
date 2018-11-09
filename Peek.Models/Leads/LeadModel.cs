using Peek.Core.Utilities.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Models.Leads
{
    [DataContract]
    public class LeadModel
    {
        public LeadModel()
        {
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string PhoneNum { get; set; }

        [DataMember]
        public string ShipToAddress { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string Zipcode { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string AssignedTo { get; set; }

        [DataMember]
        public string LeadType { get; set; }

        [DataMember]
        public string LeadStatus { get; set; }

        [DataMember]
        public string LeadSource { get; set; }

        [DataMember]
        public string LeadSubSource { get; set; }

        [DataMember]
        public string LeadCreator { get; set; }

        [IgnoreDataMember]
        public DateTime? AppointmentDate { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public int? ClientId { get; set; }

        [IgnoreDataMember]
        public DateTime? CreateDate { get; set; }

        [IgnoreDataMember]
        public DateTime? LastActivity { get; set; }

        [IgnoreDataMember]
        public DateTime? JobCreationDate { get; set; }

        [DataMember(Name = "JobCreationDate")]
        public string JobCreationDateString
        {
            get => DateTimeUtil.GetISODateTimeString(JobCreationDate);

            set
            {
                CreateDate = DateTime.Parse(value);
            }
        }

        [DataMember]
        public bool? Active { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string CoClient { get; set; }

        [DataMember]
        public string LeadSubType { get; set; }
    }
}
