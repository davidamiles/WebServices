using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peek.Models.Jobs;

namespace Peek.Repository.Jobs
{
    public class JobsRepo : IJobsRepo
    {
        private Entities.PeekViewEntities baseContext = null;

        public JobsRepo()
        {
            this.baseContext = new Entities.PeekViewEntities();
        }

        public long Count()
        {
            return this.baseContext.Jobs.Count();
        }

        public void Delete(JobModel item)
        {
            Entities.Job entity = this.baseContext.Jobs.Where(job => job.Id == item.Id).FirstOrDefault();

            if (entity != null)
            {
                this.baseContext.Jobs.Remove(entity);
                this.baseContext.SaveChanges();
            }
        }

        public bool Exists(JobModel item)
        {
            throw new NotImplementedException();
        }

        public void Insert(JobModel item)
        {
            Entities.Job entity = new Entities.Job()
            {
                CreateDate = DateTime.Now,
                LeadID = item.LeadId,
                ClientID = item.ClientId,
                GrossProfit = item.GrossProfit,
                Active = item.IsActive,
                AssignedTo = item.Assignedto,          
                Zipcode = item.Zipcode,
                PhoneNum = item.PhoneNum,
                PONumber = item.PONumber,
                ShipToAddress = item.ShipToAddress,
                City = item.City,
                Email = item.Email,
                Status = item.Status,                
                CoClient = item.CoClient,
                Commission = item.Commission,
                CommissionBalance = item.CommissionBalance,
                CommissionPercentage = item.CommissionPercentage,
                ContractAmount = item.ContractAmount,
                CustomerName = item.CustomerName,
                InsEmail = item.InsuranceEmail,
                InsAdjusterDesk = item.InsuranceAdjusterDesk,
                InsAdjusterField = item.InsuranceAdjusterField,
                InsClaimNum = item.InsuranceClaimNumber,
                InsExtension = item.InsuranceExtension,
                InsFax = item.InsuranceFax,
                InsInsuranceCarrier = item.InsuranceCarrier,
                InsPhone = item.InsurancePhone,
                InsSupplement = item.HasInsuranceSupplement,
                JobCosts = item.JobCosts,
                JobSubType = item.JobSubType,
                JobType = item.JobType,
                LastActivity = item.LastActivity,
                Notes = item.Notes,
                PaymentNotes = item.PaymentNotes,
                OverheadCosts = item.OverheadCosts,         
                LastTrueUpDate = item.LastTruedUpDate,
                LastTrueUpPerson = item.LastTruedUpPerson,
                PaymentType = item.PaymentType,
                PermitNo = item.PermitNumber,
                TruedUp = item.IsTruedUp
            };

            this.baseContext.Jobs.Add(entity);
            this.baseContext.SaveChanges();
        }

        public JobModel Select(JobModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobModel> Select()
        {
            IEnumerable<Entities.Job> entities = this.baseContext.Jobs.OrderByDescending(j => j.Id);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public IEnumerable<JobModel> Select(int skip, int take)
        {
            IEnumerable<Entities.Job> entities = this.baseContext.Jobs.OrderByDescending(j => j.Id).Skip(skip).Take(take);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public void Update(JobModel item)
        {
            Entities.Job entity = this.baseContext.Jobs.Where(job => job.Id == item.Id).FirstOrDefault();

            if (entity != null)
            {
                entity.LeadID = item.LeadId;
                entity.ClientID = item.ClientId;
                entity.GrossProfit = item.GrossProfit;
                entity.Active = item.IsActive;
                entity.AssignedTo = item.Assignedto;
                entity.Zipcode = item.Zipcode;
                entity.PhoneNum = item.PhoneNum;
                entity.PONumber = item.PONumber;
                entity.ShipToAddress = item.ShipToAddress;
                entity.City = item.City;
                entity.Email = item.Email;
                entity.Status = item.Status;            
                entity.CoClient = item.CoClient;
                entity.Commission = item.Commission;
                entity.CommissionBalance = item.CommissionBalance;
                entity.CommissionPercentage = item.CommissionPercentage;
                entity.ContractAmount = item.ContractAmount;
                entity.CustomerName = item.CustomerName;
                entity.InsEmail = item.InsuranceEmail;
                entity.InsAdjusterDesk = item.InsuranceAdjusterDesk;
                entity.InsAdjusterField = item.InsuranceAdjusterField;
                entity.InsClaimNum = item.InsuranceClaimNumber;
                entity.InsExtension = item.InsuranceExtension;
                entity.InsFax = item.InsuranceFax;
                entity.InsInsuranceCarrier = item.InsuranceCarrier;
                entity.InsPhone = item.InsurancePhone;
                entity.InsSupplement = item.HasInsuranceSupplement;
                entity.JobCosts = item.JobCosts;
                entity.JobSubType = item.JobSubType;
                entity.JobType = item.JobType;
                entity.LastActivity = item.LastActivity;
                entity.Notes = item.Notes;
                entity.PaymentNotes = item.PaymentNotes;
                entity.OverheadCosts = item.OverheadCosts;             
                entity.LastTrueUpDate = item.LastTruedUpDate;
                entity.LastTrueUpPerson = item.LastTruedUpPerson;
                entity.PaymentType = item.PaymentType;
                entity.PermitNo = item.PermitNumber;
                entity.TruedUp = item.IsTruedUp;
            }

            this.baseContext.SaveChanges();

        }



        #region private

        private List<JobModel> GetModelsFromEntities(IEnumerable<Entities.Job> entities)
        {
            List<JobModel> models = new List<JobModel>();

            foreach(Entities.Job entity in entities)
            {
                JobModel model = new JobModel();
                model.Id = entity.Id;
                model.ClientId = (int)entity.ClientID;
                model.LeadId = (int)entity.LeadID;
                model.Assignedto = entity.AssignedTo;
                model.City = entity.City;
                model.CoClient = entity.CoClient;
                model.Commission = (float)entity.Commission;
                model.CommissionBalance = (float)entity.CommissionBalance;
                model.CommissionPercentage = (float)((entity.CommissionPercentage != null) ? entity.CommissionPercentage : 0);
                model.ContractAmount = (double)entity.ContractAmount;
                model.CreateDate = (DateTime)entity.CreateDate;
                model.CustomerName = entity.CustomerName;
                model.Email = entity.Email;
                model.GrossProfit = (double)entity.GrossProfit;
                model.HasInsuranceSupplement = (bool)entity.InsSupplement;
                model.InsuranceAdjusterDesk = entity.InsAdjusterDesk;
                model.InsuranceAdjusterField = entity.InsAdjusterField;
                model.InsuranceCarrier = entity.InsInsuranceCarrier;
                model.InsuranceClaimNumber = entity.InsClaimNum;
                model.InsuranceEmail = entity.InsEmail;
                model.InsuranceExtension = entity.InsExtension;
                model.InsuranceFax = entity.InsFax;
                model.InsurancePhone = entity.InsPhone;
                model.IsActive = (bool)entity.Active;
                model.IsTruedUp = (bool)entity.TruedUp;

                models.Add(model);
            }

            return models;
        }

        #endregion
    }
}
