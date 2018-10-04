using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Models.Clients
{
    public class ClientModel
    {
        public ClientModel()
        {
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime ClientAcceptedDate { get; set; }
        public DateTime ClientDeniedDate { get; set; }
        public string InsuranceCompany { get; set; }
        public string ClaimNumber { get; set; }
        public string AdjusterName { get; set; }
        public string AdjusterPhoneNum { get; set; }
        public DateTime NextActivityDate { get; set; }
        public int Priority { get; set; }
        public string Notes { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string AssignedTo { get; set; }
        public string Username { get; set; }


    }
}
