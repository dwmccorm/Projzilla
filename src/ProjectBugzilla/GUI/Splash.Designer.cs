namespace ProjectBugzilla
{
    partial class Splash
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelLicenseName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProjectBugzilla.Properties.Resources.Splash;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 194);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.AccessibleName = "progressBar";
            this.progressBar.ForeColor = System.Drawing.Color.Blue;
            this.progressBar.Location = new System.Drawing.Point(12, 200);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(342, 11);
            this.progressBar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Version:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Build:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(249, 118);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(31, 13);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "0.0.0";
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Location = new System.Drawing.Point(248, 139);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(55, 13);
            this.labelBuild.TabIndex = 5;
            this.labelBuild.Text = Program.Build;
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(187, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 38);
            this.label5.TabIndex = 6;
            this.label5.Text = "Projzilla";
            // 
            // labelLicenseName
            // 
            this.labelLicenseName.AutoSize = true;
            this.labelLicenseName.Location = new System.Drawing.Point(248, 159);
            this.labelLicenseName.Name = "labelLicenseName";
            this.labelLicenseName.Size = new System.Drawing.Size(22, 13);
            this.labelLicenseName.TabIndex = 8;
            this.labelLicenseName.Text = "Me";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Licensed To:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 214);
            this.ControlBox = false;
            this.Controls.Add(this.labelLicenseName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLicenseName;
        private System.Windows.Forms.Label label7;
    }
}