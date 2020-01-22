using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ProjectBugzilla
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static public string Version = ProjectBugzilla.Version.major + "." + ProjectBugzilla.Version.minor + "." + ProjectBugzilla.Version.revison;
        static public string Build = ProjectBugzilla.Version.build;
        static public string LicenseName = "";
        static public string LicenseURL = "http://www.projzilla.com/files/eula.html";
        static public string DocumentationURL = "http://www.projzilla.com/index.php/alldocumentation";
        static public string PurchaseURL = "http://www.projzilla.com/index.php/purchase";
        static public string CWD;

        // ASSUMPTION: Task.Number1 is only ever the BugID, and the user never changes it.
        // BUG: Make this dynamic so that the user can place this at any other place
        // I'm placing this as assertions over the code so that when it is time to fix,
        // it will hopefully be easy to find the danger areas.
        static public bool ASSUMPTION_Task_Number1_to_BugID = true;

        [STAThread]
        static void Main(string[] args)
        {
            Flex flex;
            bool isTrial = false;
            bool isPerm = false;
            bool permFileExists = false;
            bool CLI = false;

#if DEBUG
            CWD = Application.StartupPath + "..\\..\\..\\";
            
#else
            CWD = Application.StartupPath + "\\";
#endif
            CWD = System.IO.Path.GetFullPath(CWD);
            System.IO.Directory.SetCurrentDirectory(CWD);

            #region Running as CLI
            CLI = (args.Length > 0);
            #endregion

            #region Licensing
            flex = new Flex();
            permFileExists = System.IO.File.Exists(Config.GetSystem("LicenseFile"));
            isTrial = flex.IsTrialLicense();
            if (permFileExists)
            {
                flex.Load(Config.GetSystem("LicenseFile"));
                isPerm = flex.IsPermanentLicense();
                LicenseName = flex.Name;
            }
            else
            {
                isPerm = false;
            }

            if (isPerm)
            {
                // Good.
            }
            else if (isTrial && !isPerm)
            {
                // Good.
                if (false == CLI)
                {
                    MessageBox.Show("There are " + flex.TrialDaysLeft() + " day(s) remaining in your trial of Projzilla.", "Projzilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LicenseName = "Evaluation License";
            }
            else
            {
                DialogResult dr = MessageBox.Show("Unable to load a valid license.  Either your trial license has expired or no valid permanent license at \"" + System.IO.Path.GetFullPath(CWD + Config.GetSystem("LicenseFile")) + "\".  If you had a trial license which expired, do you wish to purchase a license now?", "Projzilla Licensing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Program.PurchaseURL);
                }
                return;                
            }
            #endregion

            #region Check Version
            if (false == CLI)
            {
                VersionUpdate vUpdate = new VersionUpdate();

                if (false == vUpdate.IsUpToDate())
                {
                    DialogResult dr = MessageBox.Show("There is a new version (" + vUpdate.LatestVersionString() + ") of Projzilla is availble.  Do you wish to download it?", "Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(vUpdate.url);
                    }
                }
            }
            #endregion

            if (false == CLI)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                Config.WriteConfig();
            }
            else
            {
                MSProject simpleProj = new MSProject();
                simpleProj.CommandLineInterface(args);
                simpleProj = null;
            }
        }
    }
}