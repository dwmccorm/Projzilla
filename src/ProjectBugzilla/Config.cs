using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace ProjectBugzilla
{
    public static class Config
    {
        private static Dictionary<string, string> _system;
        private static string _userConfigFile = "Config\\UserConfig.xml";
        private static string _systemConfigFile = "Config\\SystemConfig.xml";
        private static Dictionary<string, string> _user;
        private static bool _init = false;

        #region Init
        public static void Init()
        {
            _system = new Dictionary<string, string>();
            _user = new Dictionary<string, string>();
            // DataMapper -> System
            // "SimpleWizardBugzillaXMLFile -> User
            // "SimpleWizardProjectFile -> User
            // "LicenseFile -> SYstem
            // UpdateURL -> System
            LoadFile(_system, _systemConfigFile);
            LoadFile(_user, _userConfigFile);
            _init = true;
        }
        #endregion 

        #region LoadFile
        public static void LoadFile(Dictionary<string, string> dict, string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; // Prevents it from searching for the bugzilla dtd (incase it is not accessible.
            doc.Load(Program.CWD + file);
            foreach (XmlNode node in doc.SelectNodes("/config/pair"))
            {
                dict.Add(node.SelectNodes("key")[0].InnerText, node.SelectNodes("value")[0].InnerText);
            }
        }
        #endregion

        #region Get/Set

        public static string GetSystem(string key)
        {
            if (false == _init)
            {
                Init();
            }

            return _system[key];
        }

        public static string GetUser(string key)
        {
            if (false == _init)
            {
                Init();
            }

            return _user[key];
        }

        public static void SetUser(string key, string val)
        {
            if (false == _init)
            {
                Init();
            }

            _user[key] = val;
        }

        #endregion

        #region WriteConfig
        // We only write user data right now.
        public static void WriteConfig()
        {
            WriteConfig(_user, _userConfigFile);
        }

        public static void WriteConfig(Dictionary<string, string> dict, string file)
        {
            if (System.IO.File.Exists(Program.CWD + file))
            {
                if (System.IO.File.Exists(Program.CWD + file + ".bu"))
                    System.IO.File.Delete(Program.CWD + file + ".bu");
                System.IO.File.Copy(Program.CWD + file, Program.CWD + file + ".bu");
                System.IO.File.Delete(Program.CWD + file);
            }

            XmlTextWriter writer = null;
            writer = new XmlTextWriter(Program.CWD + file, null);
            try
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.Namespaces = false;

                writer.WriteStartDocument();
                writer.WriteComment("File written on: " + System.DateTime.Now.ToString());
                writer.WriteStartElement("", "config", "");
                foreach (KeyValuePair<string, string> kvp in dict)
                {
                    writer.WriteStartElement("", "pair", "");
                    writer.WriteStartElement("", "key", "");
                    writer.WriteString(kvp.Key);
                    writer.WriteEndElement(); // </key>
                    writer.WriteStartElement("", "value", "");
                    writer.WriteString(kvp.Value);
                    writer.WriteEndElement(); // </key>
                    writer.WriteEndElement(); // </pair>
                }

                writer.WriteEndElement(); // </config>
            }
            catch (Exception error)
            {
                Console.WriteLine("Exception: {0}", error.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }      
        }
        #endregion
    }
}
