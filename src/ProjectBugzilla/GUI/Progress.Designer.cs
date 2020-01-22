namespace ProjectBugzilla
{
    partial class Progress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelOperationText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(274, 17);
            this.progressBar.TabIndex = 0;
            // 
            // labelOperationText
            // 
            this.labelOperationText.AutoSize = true;
            this.labelOperationText.Location = new System.Drawing.Point(12, 33);
            this.labelOperationText.Name = "labelOperationText";
            this.labelOperationText.Size = new System.Drawing.Size(46, 13);
            this.labelOperationText.TabIndex = 1;
            this.labelOperationText.Text = "Status...";
            this.labelOperationText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 55);
            this.ControlBox = false;
            this.Controls.Add(this.labelOperationText);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Progress";
            this.ShowInTaskbar = false;
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelOperationText;
    }
}