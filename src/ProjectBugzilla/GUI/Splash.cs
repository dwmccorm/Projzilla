using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectBugzilla
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        public string LicenseName
        {
            set
            {
                labelLicenseName.Text = value;
            }
        }
        public string Build
        {
            set
            {
                labelBuild.Text = value;
            }
        }
        public string Version
        {
            set
            {
                labelVersion.Text = value;
            }
        }

        public void DoProgress()
        {
            progressBar.Maximum = 50;
            progressBar.Minimum=0;
            progressBar.Step=20;
            for (int i = 0; i < 50; i++)
            {
                System.Threading.Thread.Sleep(40);
                progressBar.Value += 1;
                Refresh();
            }
        }
    }
}