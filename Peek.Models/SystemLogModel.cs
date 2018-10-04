using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Peek.Models
{
    public class SystemLogModel
    {
        public SystemLogModel()
        {
        }

        public long Id { get; set; }

        [DataMember(Name = "Timestamp")]
        public long TimestampInMilli { get; set; }

        [IgnoreDataMember]
        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
        public string Component { get; set; }
        public string StackTrace { get; set; }

    }
}
