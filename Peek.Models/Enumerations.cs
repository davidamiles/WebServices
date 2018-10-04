using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Models
{
    public enum LogSeverity
    {
        Info = 1,
        Warning,
        Error,
        Debug
    }

    public enum LogComponent
    {
        WebService = 1
    }
}
