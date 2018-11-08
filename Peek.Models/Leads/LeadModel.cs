using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Models.Leads
{
    public class LeadModel
    {
        public LeadModel()
        {
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNum { get; set; }
        public string ShipToAddress { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }
        public string AssignedTo { get; set; }
        public string LeadType { get; set; }
        public string LeadStatus { get; set; }
        public string LeadSource { get; set; }
        public string LeadSubSource { get; set; }
        public string LeadCreator { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string Notes { get; set; }
        public int? ClientId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastActivity { get; set; }
        public DateTime? JobCreationDate { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; }
        public string CoClient { get; set; }
        public string LeadSubType { get; set; }
    }
}
