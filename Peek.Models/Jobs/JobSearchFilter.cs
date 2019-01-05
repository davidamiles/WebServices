using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Models.Jobs
{
    public class JobSearchFilter
    {
        public JobSearchFilter()
        {
        }

        public JobSearchFilter(string client, string status, string assignedTo)
        {
            Client = client;
            AssignedTo = assignedTo;
            Status = status;
        }


        public string Client { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }

        public string GenerateSQL()
        {
            return string.Format(" Select * from Jobs" +
                    " where AssignedTo like '{0}'" +
                    " and Status like '{1}'" +
                    " and (CoClient like '{2}' or CustomerName like '{2}')", AssignedTo, Status, Client);
        }
        

    }
}
