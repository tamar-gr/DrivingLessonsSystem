using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS
{
    public class XmlDs
    {
        private static string solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;

        private static string filePath = Path.Combine(solutionDirectory, "DS", "DataXML");
        /// <summary>
        /// Holding XElements for testers,trainees,tests and configuration
        /// </summary>
        private static XElement configurationRoot = null;
       
        private static string configurationPath = Path.Combine(filePath, "configXml.xml");
      
        internal XmlDs()
        {
            // if the directory we want to store in it the XML files doesn't exist - create it
            bool exists = Directory.Exists(filePath);
            if (!exists)
            {
                Directory.CreateDirectory(filePath);
            }

            if (!File.Exists(configurationPath))
            {
                CreateFile("Configuration", configurationPath);
            }
            configurationRoot = LoadData(configurationPath);
        }
      
        private void CreateFile(string typename, string path)
        {
            XElement root = new XElement(typename);
            root.Save(path);
        }

      

        public void SaveConfig()
        {
            configurationRoot.Save(configurationPath);
        }
        public XElement Configuration
        {
            get
            {
                configurationRoot = LoadData(configurationPath);
                return configurationRoot;
            }
        }
      
        private XElement LoadData(string path)
        {
            XElement root;
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
            return root;
        }
    }
}
