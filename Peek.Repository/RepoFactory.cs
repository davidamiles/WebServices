using Peek.Repository.Clients;
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

        public static ISystemLogRepo GetSystemLogRepo()
        {
            return new SystemLogRepo();
        }
    }
}
