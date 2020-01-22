using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBugzilla
{
    public enum ProjzillaExceptionSeverity { Warn, Crash }

    class ProjzillaException : Exception
    {    
        public string s;
        public ProjzillaExceptionSeverity Severity;
        public ProjzillaException():base()
        {
        s=null;
        Severity = ProjzillaExceptionSeverity.Crash;
        }
        public ProjzillaException(string message):base()
        {
        s=message.ToString();
        }
        public ProjzillaException(string message, ProjzillaExceptionSeverity sev)
            : base()
        {
            Severity = sev;
            s = message.ToString();
        }
        public ProjzillaException(string message, Exception myNew)
            : base(message, myNew)
        {
        s=message.ToString();// Stores new exception message into class member s
        }
        public ProjzillaException(string message, Exception myNew, ProjzillaExceptionSeverity sev)
            : base(message, myNew)
        {
            Severity = sev;
            s = message.ToString();// Stores new exception message into class member s
        }
    }
}
