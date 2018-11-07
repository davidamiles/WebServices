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
            IEnumerable<Entities.Lead> entities = this.baseContext.Leads.OrderByDescending(l => l.Id);

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





            return models;
        }

        #endregion
    }
}
