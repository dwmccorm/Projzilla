using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjectBugzilla.GUI
{
    public partial class SimpleWizard : Form
    {
        private MSProject proj;

        public SimpleWizard(MSProject aProj)
        {
            proj = aProj;
            InitializeComponent();

            textBoxBugzillaXML.Text = Config.GetUser("SimpleWizardBugzillaXMLFile");
            textBoxProjectExistingFile.Text = Config.GetUser("SimpleWizardProjectFile");
            ShowFieldsCheckBox.Checked = (Config.GetUser("ShowBugzillaFields") == "true");
            panelStep1.Visible = true;
            panelStep2.Visible = false;
            panelStep3.Visible = false;
            panelStep1.BringToFront();
            this.pictureBoxXML.Image = global::ProjectBugzilla.Properties.Resources.XML_Clean;
            this.pictureBoxProject.Image = global::ProjectBugzilla.Properties.Resources.Project_Clean;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            /*
            GUI.Helper.OpenBugzillaXML(proj);
            textBoxBugzillaXML.Text = proj.InputPath;
             */
            Debug.Assert(false, "dead code");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            GUI.Helper.ProjectSaveFileName(proj);
            textBoxProjectExistingFile.Text = proj.SaveProjectFilePath;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["MainForm"].BringToFront();
        }

        private void buttonNextStep1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(proj.InputPath))
            {
                this.pictureBoxXML.Image = global::ProjectBugzilla.Properties.Resources.XML_Done;
            }

            panelStep1.Visible = false;
            panelStep2.Visible = true;
            panelStep3.Visible = false;
            panelStep2.BringToFront();
        }

        private void buttonNextStep2_Click(object sender, EventArgs e)
        {
            // dM
            if (System.IO.File.Exists(proj.SaveProjectFilePath))
            {
                this.pictureBoxProject.Image = global::ProjectBugzilla.Properties.Resources.Project_Done;
            }

            panelStep1.Visible = false;
            panelStep2.Visible = false;
            panelStep3.Visible = true;
            panelStep3.BringToFront();
        }

        private void buttonPrevStep2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(proj.InputPath))
            {
                this.pictureBoxXML.Image = global::ProjectBugzilla.Properties.Resources.XML_Done;
            }
            panelStep1.Visible = true;
            panelStep2.Visible = false;
            panelStep3.Visible = false;
            panelStep1.BringToFront();
        }

        private void buttonPrevStep3_Click(object sender, EventArgs e)
        {
            panelStep1.Visible = false;
            panelStep2.Visible = true;
            panelStep3.Visible = false;
            panelStep2.BringToFront();
        }

        private void buttonPrevStep2_Click_1(object sender, EventArgs e)
        {
            panelStep1.Visible = true;
            panelStep2.Visible = false;
            panelStep3.Visible = false;
            panelStep1.BringToFront();
        }

        private void buttonNextStep2_Click_1(object sender, EventArgs e)
        {
            // dM
            if (System.IO.File.Exists(proj.SaveProjectFilePath))
            {
                this.pictureBoxProject.Image = global::ProjectBugzilla.Properties.Resources.Project_Done;
            }
            panelStep1.Visible = false;
            panelStep2.Visible = false;
            panelStep3.Visible = true;
            panelStep3.BringToFront();
        }

        private void buttonPrevStep3_Click_1(object sender, EventArgs e)
        {
            panelStep1.Visible = false;
            panelStep2.Visible = true;
            panelStep3.Visible = false;
            panelStep2.BringToFront();
        }

        private void panelStep1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxBugzillaXML_TextChanged_1(object sender, EventArgs e)
        {
            proj.InputPath = textBoxBugzillaXML.Text;
            if (System.IO.File.Exists(proj.InputPath))
            {
                this.pictureBoxXML.Image = global::ProjectBugzilla.Properties.Resources.XML_Done;
            }
        }

        /// <summary>
        /// On setting existing file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxProjectFile_TextChanged_1(object sender, EventArgs e)
        {
            if ("" == textBoxProjectExistingFile.Text)
                return;

            // Leave this line near the top of this function.  Moving it lower may reset file names.
            textBoxProjectNewFile.Text = "";

            proj.SaveProjectFilePath = textBoxProjectExistingFile.Text;
            proj.LoadProjectFilePath = textBoxProjectExistingFile.Text;
            if (System.IO.File.Exists(proj.SaveProjectFilePath))
            {
                this.pictureBoxProject.Image = global::ProjectBugzilla.Properties.Resources.Project_Done;
            }
        }

        /// <summary>
        /// On setting "New File"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ("" == textBoxProjectNewFile.Text)
                return;

            // Moving this line to the bottom of this function is bad.  It causes us to lose the file name.
            textBoxProjectExistingFile.Text = "";

            proj.SaveProjectFilePath = textBoxProjectNewFile.Text;

            // We need to start with a blank file to begin with
            string path = Config.GetUser("BlankProjectFile");
            if (false == System.IO.Path.IsPathRooted(path))
                path = Program.CWD + "\\" + path;
            proj.LoadProjectFilePath = path;

            if (!System.IO.File.Exists(proj.SaveProjectFilePath))
            {
                this.pictureBoxProject.Image = global::ProjectBugzilla.Properties.Resources.Project_Done;
                Config.SetUser("SimpleWizardProjectFile", proj.SaveProjectFilePath);
            }
            else
            {
                textBoxProjectNewFile.Text = "";
                MessageBox.Show("Target file \"" + proj.SaveProjectFilePath + "\" already exists.  Change this to be the name of a file which does not exist or use generation to an existing file.", "Projzilla Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = textBoxProjectNewFile.Text;
            saveFileDialog1.Filter = "Project Files (*.MPP)|*.mpp|All Files (*.*)|*.*" ;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true ;
            
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxProjectNewFile.Text = saveFileDialog1.FileName;
                proj.GenerateNewProject = true;
            } 
        }

        private void www_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Existing Project File";
            openFileDialog.InitialDirectory = textBoxProjectExistingFile.Text;
            openFileDialog.Filter = "Project Files (*.MPP)|*.mpp|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxProjectExistingFile.Text = openFileDialog.FileName;
                proj.GenerateNewProject = false;
            }  
        }

        private void buttonGenerate_Click_1(object sender, EventArgs e)
        {
            try
            {
                Config.SetUser("SimpleWizardBugzillaXMLFile", textBoxBugzillaXML.Text);
                if ((null != textBoxProjectExistingFile.Text) && ("" != textBoxProjectExistingFile.Text))
                {
                    Config.SetUser("SimpleWizardProjectFile", textBoxProjectExistingFile.Text);
                }
                else
                {
                    Config.SetUser("SimpleWizardProjectFile", textBoxProjectNewFile.Text);
                }

                GUI.Helper.Generate(proj);
                MessageBox.Show("Generation of Microsoft Project file \"" + proj.SaveProjectFilePath + "\" successfull.", "Generation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                Application.OpenForms["MainForm"].BringToFront();
            }
            catch (ProjzillaException pe)
            {
                MessageBox.Show("Error: " + pe.Message, "Projzilla Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (null != proj.Project)
                {
                    proj.Close();
                }
                if (pe.Severity == ProjzillaExceptionSeverity.Crash)
                {
                    Application.Exit();
                }
            }
        }

        private void buttonLoad_Click_1(object sender, EventArgs e)
        {
            GUI.Helper.OpenBugzillaXML(proj);
            textBoxBugzillaXML.Text = proj.InputPath;
        }

        private void saveLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.projzilla.com/index.php/category-table/76-how-do-i-save-xml-from-bugzilla");
        }

        private void ShowFieldsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            proj.ShowAllBugzillaFieldsInProject = ShowFieldsCheckBox.Checked;
            if (proj.ShowAllBugzillaFieldsInProject)
            {
                Config.SetUser("ShowBugzillaFields", "true");
            }
            else
            {
                Config.SetUser("ShowBugzillaFields", "false");
            }
        }
    }
}