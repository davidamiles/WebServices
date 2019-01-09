using Peek.Models.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.WebService.Models
{
    public class Result<T>
    {
        public IEnumerable<T> Records { get; set; }
        public long TotalRecordsCount { get; set; }
    }
}
