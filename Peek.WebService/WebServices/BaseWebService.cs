using Peek.Core.Logging;
using Peek;
using Peek.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Peek.WebService.WebServices
{
    internal class BaseWebService
    {
        private string baseServiceName = null;
        //private SessionManager baseSessionManager = null;
        private MimeTypeHelper baseMimeTypeHelper = null;
        private string baseUsername = null;
        protected string basePath = null;

        public BaseWebService(string name, string contentPath, bool hasContent)
        {
            if (hasContent)
            {
                this.basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, contentPath);

#if (DEBUG)
                this.basePath = this.basePath.Substring(0, this.basePath.IndexOf("\\Sandbox"));
                this.basePath = Path.Combine(this.basePath, "WebInterface", contentPath);
#endif
            }


            if (!Directory.Exists(basePath))
            {
                throw new DirectoryNotFoundException(this.basePath);
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.baseMimeTypeHelper = MimeTypeHelper.GetInstance();            

            this.baseServiceName = name;
            //this.baseSessionManager = SessionManager.GetInstance();
        }

        protected string GetMimeType(string extension)
        {
            return this.baseMimeTypeHelper.GetMimeType(extension);
        }

        protected string GetRequestingIpAddress()
        {
            RemoteEndpointMessageProperty endPointProperty = (RemoteEndpointMessageProperty)OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name];
            return endPointProperty.Address;
        }

        protected static byte[] GetBufferFromStream(Stream data)
        {
            byte[] buffer = new byte[1400];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;

                while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        protected void LogMessage(string message, LogSeverity severity)
        {
            Logger.Log(this.baseServiceName + ": " + message, LogComponent.WebService.ToString(), severity);
        }

        protected void LogMessage(string message, LogSeverity severity, string stacktrace)
        {
            Logger.Log(this.baseServiceName + ": " + message, LogComponent.WebService.ToString(), severity, stacktrace);
        }

        protected string GetUsername()
        {
            if (this.baseUsername == null)
            {
                if (ServiceSecurityContext.Current == null)
                {
                    return null;
                }

                WindowsIdentity callerWindowsIdentity = ServiceSecurityContext.Current.WindowsIdentity;

                this.baseUsername = callerWindowsIdentity.Name;

                this.baseUsername = this.baseUsername.Substring(this.baseUsername.IndexOf("\\") + 1);
            }

            return baseUsername;
        }

        //protected SessionModel CheckSessionId(string sessionId)
        //{
        //    if (sessionId == null)
        //    {
        //        OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
        //        response.StatusCode = System.Net.HttpStatusCode.NotFound;
        //        response.StatusDescription = Properties.Resources.ResourceNotFoundError;

        //        this.LogMessage(string.Format(Properties.Resources.InputParameterNullError, "sessionId"), LogSeverity.Error, null);

        //        return null;
        //    }

        //    SessionModel session = this.baseSessionManager.GetSession(sessionId);

        //    if (session == null)
        //    {
        //        OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
        //        response.StatusCode = System.Net.HttpStatusCode.NotFound;
        //        response.StatusDescription = Properties.Resources.ResourceNotFoundError;

        //        this.LogMessage(string.Format(Properties.Resources.InvalidSessionIdError, sessionId), LogSeverity.Error, null);

        //        return null;
        //    }

        //    session.ActivityTimestamp = DateTime.UtcNow;

        //    return session;
        //}

        protected static Guid GetGuid(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("userId");
            }

            Guid id;

            if (!Guid.TryParse(userId, out id))
            {
                throw new ArgumentException("userId");
            }

            return id;
        }

        protected Stream GetErrorResponseStream(int errorCode, string message)
        {
            string pageFormat = "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title>Error</title></head><body>" +
                "<font style=\"font-size: 35px;\">{0} {1}</font></body></html>";

            return new MemoryStream(ASCIIEncoding.ASCII.GetBytes(string.Format(pageFormat, errorCode, message)));
        }
    }
}
