using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBugzilla
{
    class Version
    {
        public static int major = 1;
        public static int minor = 1;
        public static int revison = 0;

        public static string build = "200901101";

        public string PrintAsString()
        {
            return (major.ToString() + "." + minor.ToString() + "." + revison.ToString());
        }
    }
}