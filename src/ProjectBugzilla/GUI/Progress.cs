using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectBugzilla
{
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        #region Range
        /// <summary>
        /// How many ticks the progress bar should have
        /// </summary>
        private int _range;
        public int Range
        {
            get
            {
                return (_range);
            }
            set
            {
                _range = value;
                progressBar.Minimum = 0;
                progressBar.Maximum = _range;
                progressBar.Step = 20;
            }
        }
        #endregion

        #region Update Operation Text
        private string _operationText;
        public string OperationText
        {
            get
            {
                return (_operationText);
            }
            set
            {
                if (value.Length < 54)
                {
                    _operationText = value;
                }
                else
                {
                    _operationText = value.Substring(0, 50);
                    _operationText = _operationText + "...";
                }
                
                labelOperationText.Text = _operationText;
            }
        }
        #endregion

        #region UpdateProgress
        /// <summary>
        /// Updates the progress with no text (text will go blank)
        /// </summary>
        /// <param name="increment"></param>
        public void UpdateProgress(int incr)
        {
            UpdateProgress(incr, "");
        }

        /// <summary>
        /// Updates the progress with the text passed in.
        /// </summary>
        /// <param name="incremenet"></param>
        /// <param name="opText"></param>
        public void UpdateProgress(int incr, string opText)
        {
            OperationText = opText;
            progressBar.Value += incr;
            Refresh();
        }
        #endregion

        #region UpdateProgressDone
        /// <summary>
        /// Sets the bar to 100% complete.
        /// </summary>
        public void UpdateProgressDone()
        {
            progressBar.Value = _range;
            Refresh();
        }
        #endregion
    }
}