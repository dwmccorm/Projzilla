using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjectBugzilla
{
    public abstract class BugFactory
    {
        public BugDictionary CreateBugs(string xmlfile)
        {
            return (CreateBugs(xmlfile, null));
        }

        public abstract BugDictionary CreateBugs(string xmlfile, Progress progress);
        public abstract int Length();

        #region InputPath
        private string _inputPath;
        public string InputPath
        {
            get
            {
                return (_inputPath);
            }
            set
            {
                _inputPath = value;
            }
        }
        #endregion

    }

    public enum InputDataFormat
    {
        None = 0,
        BugzillaXML = 1, 
        BugzillaCSV =2
    }
}
