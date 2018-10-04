using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Peek.Models;
using Peek.Repository;

namespace Peek.Core.Logging
{
    public class DbTraceListener : TraceListener
    {
        private string baseSeverityString = null;

        public DbTraceListener()
            : base()
        {
        }

        public DbTraceListener(string initData)
            : base(initData)
        {
            this.baseSeverityString = initData;
        }



        public override void Write(object o)
        {
            SystemLogModel log = o as SystemLogModel;

            if (this.baseSeverityString != null && this.baseSeverityString.Contains(log.Severity.ToString()))
            {
                new SystemLogRepo().Insert(log);
            }
            else
            {
                new SystemLogRepo().Insert(log);
            }
        }

        public override void Write(string message)
        {
            //throw new NotImplementedException();
        }

        public override void WriteLine(string message)
        {
            //throw new NotImplementedException();
        }
    }
}
