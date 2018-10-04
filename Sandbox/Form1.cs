using Peek.WebService.WebServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class Form1 : Form
    {
        private WebServiceHost baseLoginWebServiceHost = null; 
        private WebServiceHost baseContentWebServiceHost = null;
        private WebServiceHost baseDataWebServiceHost = null;
        private WebServiceHost baseAdminWebServiceHost = null;

        private string basePath = null;        

        public Form1()
        {
            InitializeComponent();
            
            this.btnStop.Enabled = false;

            this.basePath = AppDomain.CurrentDomain.BaseDirectory;
            this.basePath = this.basePath.Substring(0, this.basePath.IndexOf("\\Sandbox"));
            this.basePath = Path.Combine(this.basePath, "Peek.WebService");

            MimeTypeHelper.GetInstance().Load(Path.Combine(this.basePath, "Configuration.xml"));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.baseLoginWebServiceHost = new WebServiceHost(typeof(LoginWebSvc));
            this.baseLoginWebServiceHost.Open();

            this.baseContentWebServiceHost = new WebServiceHost(typeof(HtmlContentWebSvc));
            this.baseContentWebServiceHost.Open();
            
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.baseContentWebServiceHost.Close();
            this.baseLoginWebServiceHost.Close();

            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
        }
    }
}
