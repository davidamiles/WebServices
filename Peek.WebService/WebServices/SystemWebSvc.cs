using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Peek.WebService.WebServices
{
    
    internal sealed class SystemWebSvc : BaseWebService, ISystemWebSvc
    {
        public SystemWebSvc() : base("SystemWebSvc", null, false)
        {

        }

        public new string GetUsername() 
        {
            return base.GetUsername();
        }
    }
}
