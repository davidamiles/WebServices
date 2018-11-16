using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Peek.Core.Utilities.Time;

namespace Peek.Models.Jobs
{

    [DataContract()]
    public class JobModel
    {
        public JobModel()
        {
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int LeadId { get; set; }

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
        public string Assignedto { get; set; }

        [DataMember]
        public string JobType { get; set; }

        [DataMember]
        public string JobSubType { get; set; }
        [DataMember]
        public string Notes { get; set; }

        [IgnoreDataMember]
        public DateTime CreateDate { get; set; }

        [DataMember(Name = "CreateDate")]
        public string CreateDateString
        {
            get
            {
                return DateTimeUtil.GetISODateTimeString(CreateDate);
            }

            set
            {
                CreateDate = DateTime.Parse(value);
            }
        }

        [IgnoreDataMember]
        public DateTime LastActivity { get; set; }

        [DataMember(Name = "LastActivity")]
        public string LastActivityString
        {
            get
            {
                return DateTimeUtil.GetISODateTimeString(LastActivity);
            }

            set
            {
                CreateDate = DateTime.Parse(value).ToUniversalTime();
            }
        }

        [DataMember]
        public string PONumber { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public float JobCosts { get; set; }

        [DataMember]
        public string InsuranceClaimNumber { get; set; }

        [DataMember]
        public bool HasInsuranceSupplement { get; set; }

        [DataMember]
        public string InsuranceCarrier { get; set; }

        [DataMember]
        public string InsurancePhone { get; set; }

        [DataMember]
        public string InsuranceExtension { get; set; }

        [DataMember]
        public string InsuranceAdjusterField { get; set; }

        [DataMember]
        public string InsuranceAdjusterDesk { get; set; }

        [DataMember]
        public string InsuranceEmail { get; set; }

        [DataMember]
        public string InsuranceFax { get; set; }

        [DataMember]
        public string PaymentType { get; set; }

        [DataMember]
        public double GrossProfit { get; set; }

        [DataMember]
        public float OverheadCosts { get; set; }

        [DataMember]
        public float Commission { get; set; }

        [DataMember]
        public bool IsTruedUp { get; set; }

        [IgnoreDataMember]
        public DateTime LastTruedUpDate { get; set; }

        [DataMember(Name = "LastTruedUpDate")]
        public string LastTruedUpDateString
        {
            get
            {
                return DateTimeUtil.GetISODateTimeString(LastTruedUpDate);
            }
            set
            {
                this.LastTruedUpDate = DateTime.Parse(value).ToUniversalTime();
            }
        }

        [DataMember]
        public string LastTruedUpPerson { get; set; }

        [DataMember]
        public float CommissionBalance { get; set; }

        [DataMember]
        public double ContractAmount { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string PaymentNotes { get; set; }

        [DataMember]
        public float CommissionPercentage { get; set; }

        [DataMember]
        public string CoClient { get; set; }

        [DataMember]
        public string PermitNumber { get; set; }





    }
}
