using Peek.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.WebService.Models
{
    public class InfragisticJobsResult
    {
        public List<JobModel> Results { get; set; }
        public int TotalRecordsCount { get; set; }
    }
}
