using Microsoft.VisualStudio.TestTools.UnitTesting;
using Peek.Models.Jobs;
using Peek.Repository;
using Peek.Repository.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.RepositoryUnitTest
{
    [TestClass]
    public class JobRepoUnitTest
    {
        [TestMethod]
        public void SelectJobsWithSkipTake()
        {
            IJobsRepo repo = RepoFactory.GetJobsRepo();
            List<JobModel> models = repo.Select(0, 10) as List<JobModel>;
        }

        [TestMethod]
        public void SelectJobs()
        {
            IJobsRepo repo = RepoFactory.GetJobsRepo();
            List<JobModel> models = repo.Select() as List<JobModel>;
        }
    }
}
