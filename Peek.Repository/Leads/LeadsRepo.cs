using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peek.Models.Leads;

namespace Peek.Repository.Leads
{
    public class LeadsRepo : ILeadsRepo
    {
        private Entities.PeekViewEntities baseContext = null;

        public LeadsRepo()
        {
            this.baseContext = new Entities.PeekViewEntities();
        }

        public void Delete(LeadModel item)
        {
            throw new NotImplementedException();
        }

        public bool Exists(LeadModel item)
        {
            throw new NotImplementedException();
        }

        public void Insert(LeadModel item)
        {
            throw new NotImplementedException();
        }

        public LeadModel Select(LeadModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LeadModel> Select()
        {
            IEnumerable<Entities.Lead> entities = this.baseContext.Leads.OrderByDescending(l => l.Id);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public IEnumerable<LeadModel> Select(int skip, int take)
        {
            IEnumerable<Entities.Lead> entities = this.baseContext.Leads.OrderByDescending(l => l.Id).Skip(skip).Take(take);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public void Update(LeadModel item)
        {
            throw new NotImplementedException();
        }



        
        
        
        #region private

        public List<LeadModel> GetModelsFromEntities(IEnumerable<Entities.Lead> entities)
        {
            List<LeadModel> models = new List<LeadModel>();

            foreach(Entities.Lead entity in entities)
            {
                LeadModel model = new LeadModel();

                model.Id = entity.Id;
                model.Active = entity.Active;
                model.AppointmentDate = entity.AppointmentDate;
                model.AssignedTo = entity.AssignedTo;
                model.City = entity.City;
                model.ClientId = entity.ClientID;
                model.CoClient = entity.CoClient;
                model.CreateDate = entity.CreateDate;
                model.CustomerName = entity.CustomerName;
                model.Email = entity.Email;                
                model.JobCreationDate = entity.JobCreationDate;
                model.LastActivity = entity.LastActivity;
                model.LeadCreator = entity.LeadCreator;
                model.LeadSource = entity.LeadSource;
                model.LeadStatus = entity.LeadStatus;
                model.LeadSubSource = entity.LeadSubSource;
                model.LeadSubType = entity.LeadSubType;
                model.LeadType = entity.LeadType;
                model.Notes = entity.Notes;
                model.PhoneNum = entity.PhoneNum;
                model.ShipToAddress = entity.ShipToAddress;
                model.Username = entity.Username;
                model.Zipcode = entity.Zipcode;

                models.Add(model);
            }

            return models;
        }

        public long Count()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
