using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Peek.Repository.Leads;
using Peek.Repository;
using Peek.Models.Leads;

namespace Peek.RepositoryUnitTest
{
    [TestClass]
    public class LeadRepoUnitTest
    {
        public LeadRepoUnitTest()
        {

        }

        [TestMethod]
        public void SelectLeads()
        {
            ILeadsRepo repo = RepoFactory.GetLeadsRepo();
            IEnumerable<LeadModel> models = repo.Select();
        }

        [TestMethod]
        public void SelectLeadsSkipTake()
        {
            ILeadsRepo repo = RepoFactory.GetLeadsRepo();
            IEnumerable<LeadModel> models = repo.Select(0, 1);
        }
    }
}
