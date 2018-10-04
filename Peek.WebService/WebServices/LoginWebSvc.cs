using Peek.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Peek.WebService.WebServices
{    
    internal class LoginWebSvc : BaseWebService, ILoginWebSvc
    {
        public LoginWebSvc() : base("LoginWebSvc", "html\\login", true)
        {
        }

        public System.IO.Stream GetResource(string path)
        {
            Stream resourceStream = null;

            if (string.IsNullOrEmpty(path))
            {
                path = "default.html";
            }

            try
            {
                string mimetype = base.GetMimeType(Path.GetExtension(path));

                if (mimetype == null)
                {
                    base.LogMessage("Missing mimetype for resource; " + path + " check mimetypes in WebSvcConfig.xml", LogSeverity.Error, null);
                }
                else
                {
                    WebOperationContext.Current.OutgoingResponse.ContentType = mimetype;

                    resourceStream = new MemoryStream(File.ReadAllBytes(Path.Combine(base.basePath, path)));
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                resourceStream = base.GetErrorResponseStream(404, "Not Found");

                if (!path.ToLower().Contains("files"))
                {
                    this.LogMessage("Path Not Found: " + path, LogSeverity.Error, null);
                }

            }
            catch (System.IO.DirectoryNotFoundException)
            {
                resourceStream = base.GetErrorResponseStream(404, "Not Found");

                if (!path.ToLower().Contains("files"))
                {
                    this.LogMessage("Path Not Found: " + path, LogSeverity.Error, null);
                }

                this.LogMessage("Path Not Found: " + path, LogSeverity.Error, null);
            }
            catch (Exception ex)
            {
                base.LogMessage("Exception loading resource \"" + path + "\"   " + ex.Message, LogSeverity.Error, ex.StackTrace);
            }

            return resourceStream;
        }
    }
}
