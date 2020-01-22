namespace ProjectBugzilla.GUI
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.labelLicenseName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonLicense = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLicenseName
            // 
            this.labelLicenseName.AutoSize = true;
            this.labelLicenseName.Location = new System.Drawing.Point(261, 171);
            this.labelLicenseName.Name = "labelLicenseName";
            this.labelLicenseName.Size = new System.Drawing.Size(22, 13);
            this.labelLicenseName.TabIndex = 17;
            this.labelLicenseName.Text = "Me";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(188, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Licensed To:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(200, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 38);
            this.label5.TabIndex = 15;
            this.label5.Text = "Projzilla";
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Location = new System.Drawing.Point(261, 151);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(55, 13);
            this.labelBuild.TabIndex = 14;
            this.labelBuild.Text = Program.Build;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(262, 130);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(31, 13);
            this.labelVersion.TabIndex = 13;
            this.labelVersion.Text = "0.0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Build:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Version:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjectBugzilla.Properties.Resources.Splash;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 194);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.Control;
            this.buttonClose.Location = new System.Drawing.Point(302, 206);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(89, 23);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonLicense
            // 
            this.buttonLicense.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLicense.Location = new System.Drawing.Point(207, 206);
            this.buttonLicense.Name = "buttonLicense";
            this.buttonLicense.Size = new System.Drawing.Size(89, 23);
            this.buttonLicense.TabIndex = 19;
            this.buttonLicense.Text = "View License";
            this.buttonLicense.UseVisualStyleBackColor = false;
            this.buttonLicense.Click += new System.EventHandler(this.buttonLicense_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 236);
            this.ControlBox = false;
            this.Controls.Add(this.buttonLicense);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelLicenseName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.Text = "About Prozilla";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLicenseName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonLicense;
    }
}