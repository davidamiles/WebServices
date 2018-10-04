using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Peek.WebService.WebServices
{
    internal class MimeTypeHelper
    {
        private Dictionary<string, string> baseMimeTypes = null;
        private static MimeTypeHelper INSTANCE = null;

        private MimeTypeHelper()
        {
            this.baseMimeTypes = new Dictionary<string, string>();
        }

        public static MimeTypeHelper GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new MimeTypeHelper();
            }

            return INSTANCE;
        }

        public void Load(string filePath)
        {
            XElement xml = XElement.Load(filePath);

            IEnumerable<XElement> elements = xml.Element("MimeTypes").Elements();
            foreach (XElement element in elements)
            {
                string extension = element.Attribute("fileExtension").Value;
                string value = element.Attribute("type").Value;

                this.baseMimeTypes.Add(extension, value);
            }
        }

        public string GetMimeType(string fileExtension)
        {
            string value = null;

            if (baseMimeTypes.ContainsKey(fileExtension))
            {
                value = this.baseMimeTypes[fileExtension];
            }

            return value;
        }
    }
}
