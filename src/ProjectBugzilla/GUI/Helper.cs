using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjectBugzilla.GUI
{
    class Helper
    {
        #region OpenBugzillaXML
        /// <summary>
        /// Opens an XML file
        /// </summary>
        public static void OpenBugzillaXML(MSProject proj)
        {
            string filePath = "";
            string safeFilePath = "";
            OpenFileDialog ofd;

            ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xml";
            ofd.Filter = "XML files (*.xml)|*.xml|CSV files (*.csv)|*.csv";
            ofd.InitialDirectory = "C:\\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                safeFilePath = ofd.SafeFileName;
                proj.InputPath = filePath;
            }
        }
        #endregion

        #region Generate
        public static void Generate(MSProject proj)
        {
            #region Pre Conditions
            Debug.Assert(null != proj.LoadProjectFilePath);
            Debug.Assert(null != proj.SaveProjectFilePath);
            Debug.Assert(null != proj.InputPath);
            Debug.Assert(InputDataFormat.None != proj.InputType);
            #endregion

            if ((proj.SaveProjectFilePath != null) && (proj.LoadProjectFilePath != null) && (proj.InputPath != null))
            {
                proj.LoadMPP();
                proj.Update();
                proj.SaveMPP();
                proj.Close();
            }
            else
            {
                MessageBox.Show("Unable to load one of {LoadProjectFilePath, SaveProjectFilePath, bugzillaXMLFilePath}", "File not Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ProjectSaveFileName
        public static void ProjectSaveFileName(MSProject proj)
        {
            SaveFileDialog sfd;
            sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.mpp";
            sfd.Filter = "Project files (*.mpp)|*.mpp";
            sfd.InitialDirectory = "C:\\";
            sfd.CheckFileExists = false;
            sfd.OverwritePrompt = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                proj.LoadProjectFilePath = sfd.FileName;
                proj.SaveProjectFilePath = sfd.FileName;
            }
            else
            {
                throw (new ProjzillaException("Can't use the save file name", ProjzillaExceptionSeverity.Warn));
            }
        }
        #endregion
    }
}
