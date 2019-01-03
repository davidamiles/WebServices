using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.WebService.Models
{
    internal sealed class JobFilter
    {
        public JobFilter()
        {
        }

        public bool IsActive { get; set; }
        public string JobType { get; set; }
        public string JobSubType { get; set; }
        public string Salesman { get; set; }
        public string JobStatus { get; set; }
    }
}
