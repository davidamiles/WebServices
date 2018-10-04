using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Peek.Models;

namespace Peek.Core.Logging
{
    public static class Logger
    {
        private static object LOCK_OBJECT = new object();        


        public static void Log(string message, string component, LogSeverity severity)
        {
            lock (LOCK_OBJECT)
            {
                Trace.Write(new SystemLogModel()
                {
                    Component = component,
                    Message = message,
                    Severity = severity,
                    Timestamp = DateTime.Now
                });
            }
        }

        public static void Log(string message, string component, LogSeverity severity, string stacktrace)
        {
            lock (LOCK_OBJECT)
            {
                Trace.Write(new SystemLogModel()
                {
                    Component = component,
                    Message = message,
                    Severity = severity,
                    StackTrace = stacktrace,
                    Timestamp = DateTime.Now
                });
            }
        }
    }
}
