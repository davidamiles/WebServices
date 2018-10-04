using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Peek.Repository;
using Peek.Repository.Clients;
using Peek.Models.Clients;
using System.Collections.Generic;

namespace Peek.RepositoryUnitTest
{
    [TestClass]
    public class ClientRepoUnitTest
    {
        [TestMethod]
        public void SelectClientsWithSkipTake()
        {
            IClientRepo repo = RepoFactory.GetClientRepo();
            List<ClientModel> models = repo.Select(0, 10) as List<ClientModel>;            
        }
    }
}
