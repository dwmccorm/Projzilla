using System;
using System.Xml;
using System.IO; 
using System.Collections.Generic;
using System.Text;

namespace ProjectBugzilla
{
    class VersionUpdate
    {
        public VersionUpdate()
        {
            Populate();
        }

        public int major = 0;
        public int minor = 0;
        public int revison = 0;
        public string url = "";

        public string LatestVersionString()
        {
            return (major.ToString() + "." + minor.ToString() + "." + revison.ToString());
        }

        public void Populate()
        {
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; // Prevents it from searching for the bugzilla dtd (incase it is not accessible.
            doc.Load(Config.GetSystem("UpdateURL"));
            XmlNode node = doc.SelectSingleNode("/projzilla-version/latest");
            major = Convert.ToInt32(node.SelectNodes("major")[0].InnerText);
            minor = Convert.ToInt32(node.SelectNodes("minor")[0].InnerText);
            revison = Convert.ToInt32(node.SelectNodes("revison")[0].InnerText);
            url = node.SelectNodes("url")[0].InnerText;
        }

        public bool IsUpToDate()
        {
            return ((Version.major == major) && (Version.minor == minor) && (Version.revison == revison));
        }
    }
}
