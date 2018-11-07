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

        public void Delete(JobModel item)
        {
            throw new NotImplementedException();
        }

        public bool Exists(JobModel item)
        {
            throw new NotImplementedException();
        }

        public void Insert(JobModel item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }



        #region private

        private List<JobModel> GetModelsFromEntities(IEnumerable<Entities.Job> entities)
        {
            List<JobModel> models = new List<JobModel>();

            foreach(Entities.Job entity in entities)
            {
                JobModel model = new JobModel();

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
