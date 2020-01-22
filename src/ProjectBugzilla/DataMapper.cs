using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace ProjectBugzilla
{
    /// <summary>
    /// Translates the XML file of where things are to go, to where they go
    /// </summary>
    public class DataMapper
    {
        private Dictionary<string, string> _map;
        private string _xmlMap = "";
        private string _tag = "";

        #region DataMapper
        public DataMapper(string xmlMap, string tag)
        {
            _map = new Dictionary<string,string>();
            _xmlMap = xmlMap;
            _tag = tag;
        }
        #endregion

        #region Reload
        // Loads the data map
        public void Reload()
        {
            #region Pre Condition
            Debug.Assert(_xmlMap != null);
            #endregion

            XmlDocument doc = new XmlDocument();
            doc.XmlResolver = null; // Prevents it from searching for the bugzilla dtd (incase it is not accessible.
            doc.Load(_xmlMap);
            foreach (XmlNode node in doc.SelectNodes("/ProjectMapping/" + _tag))
            {
                _map.Add(node.SelectNodes("bugzilla")[0].InnerText, node.SelectNodes("msproject")[0].InnerText);
            }
        }
        #endregion

        #region Contains
        public bool ContainsKey(string key)
        {
            return(_map.ContainsKey(key));
        }
        #endregion

        #region GetEnumerator
        public Dictionary<string, string> GetEnumerator()
        {
            return (_map);
        }
        #endregion

        #region accessor
        public string this[string src]
        {
            get
            {

                return _map[src];
            }
        }
        #endregion
    }
}
