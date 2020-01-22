using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectBugzilla.GUI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            labelBuild.Text = Program.Build;
            labelLicenseName.Text = Program.LicenseName;
            labelVersion.Text = Program.Version;
        }

        private void buttonLicense_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Program.LicenseURL);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["MainForm"].BringToFront();
        }
    }
}