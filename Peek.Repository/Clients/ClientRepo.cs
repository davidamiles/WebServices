﻿using Peek.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Repository.Clients
{
    public class ClientRepo : IClientRepo
    {
        private Entities.PeekViewEntities baseContext = null;

        public ClientRepo()
        {
            this.baseContext = new Entities.PeekViewEntities();
        }

        public void Insert(ClientModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientModel item)
        {
            throw new NotImplementedException();
        }

        public ClientModel Select(ClientModel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientModel> Select()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientModel> Select(int skip, int take)
        {
            IEnumerable<Entities.Client> entities = this.baseContext.Clients.OrderByDescending(client => client.Id).Skip(skip).Take(take);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public IEnumerable<ClientModel> SelectAscending(int skip, int take)
        {
            IEnumerable<Entities.Client> entities = this.baseContext.Clients.OrderBy(client => client.FullName).Skip(skip).Take(take);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public IEnumerable<ClientModel> SelectDescending(int skip, int take)
        {
            IEnumerable<Entities.Client> entities = this.baseContext.Clients.OrderByDescending(client => client.FullName).Skip(skip).Take(take);

            return (entities.Count() > 0) ? this.GetModelsFromEntities(entities) : null;
        }

        public void Delete(ClientModel item)
        {
            throw new NotImplementedException();
        }

        public bool Exists(ClientModel item)
        {
            throw new NotImplementedException();
        }




        private List<ClientModel> GetModelsFromEntities(IEnumerable<Entities.Client> entities)
        {
            List<ClientModel> clients = new List<ClientModel>();

            foreach (Entities.Client entity in entities)
            {
                clients.Add(new ClientModel()
                {
                    Id = entity.Id,
                    FullName = entity.FullName,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    CreatedDate = (DateTime)entity.CreatedDate,
                    AddressLine1 = entity.AddressLine1,
                    AddressLine2 = entity.AddressLine2,
                    AdjusterName = entity.AdjusterName
                });
            }

            return clients;
        }

        public long Count()
        {
            return this.baseContext.Clients.Count();
        }
    }
}
