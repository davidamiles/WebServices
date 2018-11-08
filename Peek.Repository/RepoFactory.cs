using Peek.Repository.Clients;
using Peek.Repository.Jobs;
using Peek.Repository.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Repository
{
    public class RepoFactory
    {
        public static IClientRepo GetClientRepo()
        {
            return new ClientRepo();
        }

        public static IJobsRepo GetJobsRepo()
        {
            return new JobsRepo();
        }

        public static ISystemLogRepo GetSystemLogRepo()
        {
            return new SystemLogRepo();
        }

        public static ILeadsRepo GetLeadsRepo()
        {
            return new LeadsRepo();
        }
    }
}
