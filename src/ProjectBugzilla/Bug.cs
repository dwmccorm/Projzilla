using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ProjectBugzilla
{
    public class Bug
    {
        #region Bug
        public Bug()
        {
            _blocks = new ArrayList();
            _dependsOn = new ArrayList();
            _projectTaskId = 0;
        }
        #endregion

        #region Id
        private int _id;
        /// <summary>
        /// Bug ID
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        #endregion

        #region ProjectTaskId
        private int _projectTaskId;
        public int ProjectTaskId
        {
            get
            {
                return _projectTaskId;
            }
            set
            {
                _projectTaskId = value;
            }
        }
        #endregion

        #region Summary
        private string _summary;
        /// <summary>
        /// Summary (Short description) of the bug
        /// </summary>
        public string Summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
            }
        }
        #endregion

        #region Status
        private string _status;

        /// <summary>
        /// NEW, ASSIGNED, ...
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        #endregion

        #region Resolution
        private string _resolution;
        /// <summary>
        /// FIXED, WONTFIX, ...
        /// </summary>
        public string Resolution
        {
            get
            {
                return _resolution;
            }
            set
            {
                _resolution = value;
            }
        }
        #endregion

        #region CustomFields
        private Dictionary<string, string> _customFields;
        public Dictionary<string, string> CustomFields
        {
            get
            {
                return _customFields;
            }
            set
            {
                _customFields = value;
            }
        }
        #endregion

        #region Owner
        private string _owner;
        /// <summary>
        /// Who the bug is currently assigned to
        /// </summary>
        public string Owner
        {
            get
            {
                return _owner;
            }
            set
            {
                _owner = value;
            }
        }
        #endregion

        #region Milestone
        private string _milestone;
        /// <summary>
        /// Target milestone for bug to be fixed
        /// </summary>
        public string Milestone
        {
            get
            {
                return _milestone;
            }
            set
            {
                _milestone = value;
            }
        }
        #endregion

        #region Priority
        private string _priority;
        /// <summary>
        /// P1, P2, ...
        /// </summary>
        public string Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }
        #endregion

        #region Product
        private string _product;
        /// <summary>
        /// Product
        /// </summary>
        public string Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }
        #endregion

        #region Component
        private string _component;
        /// <summary>
        /// Component
        /// </summary>
        public string Component
        {
            get
            {
                return _component;
            }
            set
            {
                _component = value;
            }
        }
        #endregion

        #region Version
        private string _version;
        /// <summary>
        /// Version
        /// </summary>
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        #endregion

        #region Platform
        private string _platform;
        /// <summary>
        /// Platform
        /// </summary>
        public string Platform
        {
            get
            {
                return _platform;
            }
            set
            {
                _platform = value;
            }
        }
        #endregion

        #region Keywords
        private string _keywords;
        /// <summary>
        /// Keywords
        /// </summary>
        public string Keywords
        {
            get
            {
                return _keywords;
            }
            set
            {
                _keywords = value;
            }
        }
        #endregion

        #region OS
        private string _os;
        /// <summary>
        /// OS
        /// </summary>
        public string OS
        {
            get
            {
                return _os;
            }
            set
            {
                _os = value;
            }
        }
        #endregion

        #region Reporter
        private string _reporter;
        /// <summary>
        /// Reporter
        /// </summary>
        public string Reporter
        {
            get
            {
                return _reporter;
            }
            set
            {
                _reporter = value;
            }
        }
        #endregion

        #region QAContact
        private string _qacontact;
        /// <summary>
        /// QAContact
        /// </summary>
        public string QAContact
        {
            get
            {
                return _qacontact;
            }
            set
            {
                _qacontact = value;
            }
        }
        #endregion

        #region CreationDate
        private string _creation;
        /// <summary>
        /// Date/Time issue was logged
        /// </summary>
        public string CreationDate
        {
            get
            {
                return _creation;
            }
            set
            {
                _creation = value;
            }
        }
        #endregion

        #region Severity
        private string _severity;
        /// <summary>
        /// Minor, Major, Trival, ...
        /// </summary>
        public string Severity
        {
            get
            {
                return _severity;
            }
            set
            {
                _severity = value;
            }
        }
        #endregion

        #region DependsOn
        private ArrayList _dependsOn;
        public ArrayList DependsOn
        {
            get
            {
                return _dependsOn;
            }
            set
            {
                _dependsOn = value;
            }
        }
        public string DependsOnAsString()
        {
            string str = "";
            _dependsOn.Sort();
            foreach (int i in _dependsOn)
            {
                if ("" != str)
                {
                    str += ", ";
                }
                str += i.ToString();
            }
            return (str);
        }
        #endregion

        #region Blocks
        private ArrayList _blocks;
        public ArrayList Blocks
        {
            get
            {
                return _blocks;
            }
            set
            {
                _blocks = value;
            }
        }

        public string BlocksAsString()
        {
            string str = "";
            _blocks.Sort();
            foreach (int i in _blocks)
            {
                if ("" != str)
                {
                    str += ", ";
                }
                str += i.ToString();
            }
            return (str);
        }
        #endregion

        #region OriginalTimeEstimate
        private double _estimatedTime;
        /// <summary>
        /// Original Time Estimate (XML = estimated_time)
        /// </summary>
        public double OriginalTimeEstimate
        {
            get
            {
                return _estimatedTime;
            }
            set
            {
                _estimatedTime = value;
            }
        }
        #endregion

        #region RemainingTime
        private double  _remainingTime;
        /// <summary>
        /// Remaining time left to fix the bug (XML = remaining_time)
        /// </summary>
        public double RemainingTime
        {
            get
            {
                return _remainingTime;
            }
            set
            {
                _remainingTime = value;
            }
        }
        #endregion

        #region ActualTime
        private double _actualTime;
        /// <summary>
        /// Actual time worked on the bug so far (XML = actual_time)
        /// </summary>
        public double ActualTime
        {
            get
            {
                return _actualTime;
            }
            set
            {
                _actualTime = value;
            }
        }
        #endregion

    }
}