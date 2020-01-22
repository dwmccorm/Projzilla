using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectBugzilla.GUI;

namespace ProjectBugzilla
{
    public partial class MainForm : Form
    {
        private MSProject proj;

        protected void Init()
        {
            proj = new MSProject();
        }

        protected void DeInit()
        {
            proj = null;
        }
        public void SplashScreen()
        {
            Splash s = new Splash();
            s.Version = Program.Version;
            s.Build = Program.Build;
            s.LicenseName = Program.LicenseName;
            s.Show();
            s.DoProgress();
            s.Refresh();
            s.Close();
        }

        public MainForm()
        {
            SplashScreen();
            InitializeComponent();
            Init();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            DeInit();
            this.Close();
        }

        private void menuOpenBugzillaXML_Click(object sender, EventArgs e)
        {
            GUI.Helper.OpenBugzillaXML(proj);
        }

        private void menuGenerateNewProjectFile_Click(object sender, EventArgs e)
        {
            GUI.Helper.ProjectSaveFileName(proj);
        }


        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleWizard simpleWizard = new SimpleWizard(proj);
            simpleWizard.Show();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionUpdate vUpdate = new VersionUpdate();

            if (vUpdate.IsUpToDate())
            {
                MessageBox.Show("Projzilla is up-to-date.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dr = MessageBox.Show("There is a new version (" + vUpdate.LatestVersionString() + ") of Projzilla is availble.  Do you wish to download it?", "Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(vUpdate.url);
                }
            }
        }

        private void pictureBoxWizard_Click(object sender, EventArgs e)
        {
            SimpleWizard simpleWizard = new SimpleWizard(proj);
            simpleWizard.Show();
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.DocumentationURL);
        }

        private void aboutProjzillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void pictureBoxQuickGen_Click(object sender, EventArgs e)
        {
            proj.InputPath = Config.GetUser("SimpleWizardBugzillaXMLFile");
            proj.LoadProjectFilePath = Config.GetUser("SimpleWizardProjectFile");
            proj.SaveProjectFilePath = Config.GetUser("SimpleWizardProjectFile");
            try
            {
                GUI.Helper.Generate(proj);
                MessageBox.Show("Generation of Microsoft Project file \"" + proj.SaveProjectFilePath + "\" successfull.", "Generation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ProjzillaException pe)
            {
                MessageBox.Show("Error: " + pe.Message, "Projzilla Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proj.Close();
                if (pe.Severity == ProjzillaExceptionSeverity.Crash)
                {
                    Application.Exit();
                }
            }
        }
    }
}