namespace ProjectBugzilla.GUI
{
    partial class SimpleWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleWizard));
            this.panelStep1 = new System.Windows.Forms.Panel();
            this.groupBoxStep1 = new System.Windows.Forms.GroupBox();
            this.saveLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxBugzillaXML = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonNextStep1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelStep2 = new System.Windows.Forms.Panel();
            this.groupBoxStep2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProjectNewFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectExistingFile = new System.Windows.Forms.TextBox();
            this.www = new System.Windows.Forms.Button();
            this.buttonNextStep2 = new System.Windows.Forms.Button();
            this.buttonPrevStep2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panelStep3 = new System.Windows.Forms.Panel();
            this.groupBoxStep3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonPrevStep3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxGenerate = new System.Windows.Forms.PictureBox();
            this.pictureBoxProject = new System.Windows.Forms.PictureBox();
            this.pictureBoxXML = new System.Windows.Forms.PictureBox();
            this.ShowFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.panelStep1.SuspendLayout();
            this.groupBoxStep1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelStep2.SuspendLayout();
            this.groupBoxStep2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelStep3.SuspendLayout();
            this.groupBoxStep3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXML)).BeginInit();
            this.SuspendLayout();
            // 
            // panelStep1
            // 
            this.panelStep1.Controls.Add(this.groupBoxStep1);
            this.panelStep1.Location = new System.Drawing.Point(1, 64);
            this.panelStep1.Name = "panelStep1";
            this.panelStep1.Size = new System.Drawing.Size(491, 306);
            this.panelStep1.TabIndex = 8;
            this.panelStep1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelStep1_Paint);
            // 
            // groupBoxStep1
            // 
            this.groupBoxStep1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxStep1.Controls.Add(this.saveLabel1);
            this.groupBoxStep1.Controls.Add(this.groupBox4);
            this.groupBoxStep1.Controls.Add(this.buttonNextStep1);
            this.groupBoxStep1.Controls.Add(this.textBox1);
            this.groupBoxStep1.Location = new System.Drawing.Point(14, 3);
            this.groupBoxStep1.Name = "groupBoxStep1";
            this.groupBoxStep1.Size = new System.Drawing.Size(470, 298);
            this.groupBoxStep1.TabIndex = 5;
            this.groupBoxStep1.TabStop = false;
            this.groupBoxStep1.Text = "Step 1 - Load Bugzilla Information";
            // 
            // saveLabel1
            // 
            this.saveLabel1.AutoSize = true;
            this.saveLabel1.Location = new System.Drawing.Point(9, 112);
            this.saveLabel1.Name = "saveLabel1";
            this.saveLabel1.Size = new System.Drawing.Size(268, 13);
            this.saveLabel1.TabIndex = 1002;
            this.saveLabel1.TabStop = true;
            this.saveLabel1.Text = "Click here to see how to save your results from Bugzilla.";
            this.saveLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.saveLabel1_LinkClicked);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxBugzillaXML);
            this.groupBox4.Controls.Add(this.buttonLoad);
            this.groupBox4.Location = new System.Drawing.Point(6, 198);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(452, 62);
            this.groupBox4.TabIndex = 1001;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bugzilla Search Results";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 203;
            this.label3.Text = "File:";
            // 
            // textBoxBugzillaXML
            // 
            this.textBoxBugzillaXML.Location = new System.Drawing.Point(39, 23);
            this.textBoxBugzillaXML.Name = "textBoxBugzillaXML";
            this.textBoxBugzillaXML.Size = new System.Drawing.Size(326, 20);
            this.textBoxBugzillaXML.TabIndex = 202;
            this.textBoxBugzillaXML.TabStop = false;
            this.textBoxBugzillaXML.TextChanged += new System.EventHandler(this.textBoxBugzillaXML_TextChanged_1);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(371, 22);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 201;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click_1);
            // 
            // buttonNextStep1
            // 
            this.buttonNextStep1.Location = new System.Drawing.Point(390, 270);
            this.buttonNextStep1.Name = "buttonNextStep1";
            this.buttonNextStep1.Size = new System.Drawing.Size(75, 23);
            this.buttonNextStep1.TabIndex = 6;
            this.buttonNextStep1.Text = "Next";
            this.buttonNextStep1.UseVisualStyleBackColor = true;
            this.buttonNextStep1.Click += new System.EventHandler(this.buttonNextStep1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(9, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(450, 172);
            this.textBox1.TabIndex = 1000;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // panelStep2
            // 
            this.panelStep2.Controls.Add(this.groupBoxStep2);
            this.panelStep2.Location = new System.Drawing.Point(13, 64);
            this.panelStep2.Name = "panelStep2";
            this.panelStep2.Size = new System.Drawing.Size(492, 306);
            this.panelStep2.TabIndex = 9;
            // 
            // groupBoxStep2
            // 
            this.groupBoxStep2.Controls.Add(this.ShowFieldsCheckBox);
            this.groupBoxStep2.Controls.Add(this.groupBox3);
            this.groupBoxStep2.Controls.Add(this.groupBox2);
            this.groupBoxStep2.Controls.Add(this.buttonNextStep2);
            this.groupBoxStep2.Controls.Add(this.buttonPrevStep2);
            this.groupBoxStep2.Controls.Add(this.textBox4);
            this.groupBoxStep2.Location = new System.Drawing.Point(2, 3);
            this.groupBoxStep2.Name = "groupBoxStep2";
            this.groupBoxStep2.Size = new System.Drawing.Size(470, 298);
            this.groupBoxStep2.TabIndex = 8;
            this.groupBoxStep2.TabStop = false;
            this.groupBoxStep2.Text = "Step 2 - Target Microsoft Project File";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxProjectNewFile);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(10, 141);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 57);
            this.groupBox3.TabIndex = 1003;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 203;
            this.label2.Text = "File:";
            // 
            // textBoxProjectNewFile
            // 
            this.textBoxProjectNewFile.Location = new System.Drawing.Point(38, 23);
            this.textBoxProjectNewFile.Name = "textBoxProjectNewFile";
            this.textBoxProjectNewFile.Size = new System.Drawing.Size(334, 20);
            this.textBoxProjectNewFile.TabIndex = 202;
            this.textBoxProjectNewFile.TabStop = false;
            this.textBoxProjectNewFile.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(376, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 201;
            this.button1.Text = "Save As";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxProjectExistingFile);
            this.groupBox2.Controls.Add(this.www);
            this.groupBox2.Location = new System.Drawing.Point(11, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 57);
            this.groupBox2.TabIndex = 1002;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Existing File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 203;
            this.label1.Text = "File:";
            // 
            // textBoxProjectExistingFile
            // 
            this.textBoxProjectExistingFile.Location = new System.Drawing.Point(38, 23);
            this.textBoxProjectExistingFile.Name = "textBoxProjectExistingFile";
            this.textBoxProjectExistingFile.Size = new System.Drawing.Size(334, 20);
            this.textBoxProjectExistingFile.TabIndex = 202;
            this.textBoxProjectExistingFile.TabStop = false;
            this.textBoxProjectExistingFile.TextChanged += new System.EventHandler(this.textBoxProjectFile_TextChanged_1);
            // 
            // www
            // 
            this.www.Location = new System.Drawing.Point(376, 21);
            this.www.Name = "www";
            this.www.Size = new System.Drawing.Size(75, 23);
            this.www.TabIndex = 201;
            this.www.Text = "Open";
            this.www.UseVisualStyleBackColor = true;
            this.www.Click += new System.EventHandler(this.www_Click);
            // 
            // buttonNextStep2
            // 
            this.buttonNextStep2.Location = new System.Drawing.Point(390, 270);
            this.buttonNextStep2.Name = "buttonNextStep2";
            this.buttonNextStep2.Size = new System.Drawing.Size(75, 23);
            this.buttonNextStep2.TabIndex = 12;
            this.buttonNextStep2.Text = "Next";
            this.buttonNextStep2.UseVisualStyleBackColor = true;
            this.buttonNextStep2.Click += new System.EventHandler(this.buttonNextStep2_Click_1);
            // 
            // buttonPrevStep2
            // 
            this.buttonPrevStep2.Location = new System.Drawing.Point(310, 270);
            this.buttonPrevStep2.Name = "buttonPrevStep2";
            this.buttonPrevStep2.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevStep2.TabIndex = 11;
            this.buttonPrevStep2.Text = "Prev";
            this.buttonPrevStep2.UseVisualStyleBackColor = true;
            this.buttonPrevStep2.Click += new System.EventHandler(this.buttonPrevStep2_Click_1);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(9, 21);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(458, 114);
            this.textBox4.TabIndex = 1001;
            this.textBox4.TabStop = false;
            this.textBox4.Text = resources.GetString("textBox4.Text");
            // 
            // panelStep3
            // 
            this.panelStep3.Controls.Add(this.groupBoxStep3);
            this.panelStep3.Location = new System.Drawing.Point(12, 64);
            this.panelStep3.Name = "panelStep3";
            this.panelStep3.Size = new System.Drawing.Size(482, 312);
            this.panelStep3.TabIndex = 11;
            // 
            // groupBoxStep3
            // 
            this.groupBoxStep3.Controls.Add(this.textBox2);
            this.groupBoxStep3.Controls.Add(this.buttonGenerate);
            this.groupBoxStep3.Controls.Add(this.buttonPrevStep3);
            this.groupBoxStep3.Location = new System.Drawing.Point(3, 3);
            this.groupBoxStep3.Name = "groupBoxStep3";
            this.groupBoxStep3.Size = new System.Drawing.Size(470, 298);
            this.groupBoxStep3.TabIndex = 11;
            this.groupBoxStep3.TabStop = false;
            this.groupBoxStep3.Text = "Step 3 - Generate";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(7, 20);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(460, 108);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerate.Location = new System.Drawing.Point(390, 270);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 10;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click_1);
            // 
            // buttonPrevStep3
            // 
            this.buttonPrevStep3.Location = new System.Drawing.Point(310, 270);
            this.buttonPrevStep3.Name = "buttonPrevStep3";
            this.buttonPrevStep3.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevStep3.TabIndex = 9;
            this.buttonPrevStep3.Text = "Prev";
            this.buttonPrevStep3.UseVisualStyleBackColor = true;
            this.buttonPrevStep3.Click += new System.EventHandler(this.buttonPrevStep3_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxGenerate);
            this.panel1.Controls.Add(this.pictureBoxProject);
            this.panel1.Controls.Add(this.pictureBoxXML);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 46);
            this.panel1.TabIndex = 13;
            // 
            // pictureBoxGenerate
            // 
            this.pictureBoxGenerate.Image = global::ProjectBugzilla.Properties.Resources.Generate_Clean;
            this.pictureBoxGenerate.Location = new System.Drawing.Point(122, 6);
            this.pictureBoxGenerate.Name = "pictureBoxGenerate";
            this.pictureBoxGenerate.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxGenerate.TabIndex = 15;
            this.pictureBoxGenerate.TabStop = false;
            // 
            // pictureBoxProject
            // 
            this.pictureBoxProject.Image = global::ProjectBugzilla.Properties.Resources.Project_Clean;
            this.pictureBoxProject.Location = new System.Drawing.Point(62, 6);
            this.pictureBoxProject.Name = "pictureBoxProject";
            this.pictureBoxProject.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxProject.TabIndex = 14;
            this.pictureBoxProject.TabStop = false;
            // 
            // pictureBoxXML
            // 
            this.pictureBoxXML.Image = global::ProjectBugzilla.Properties.Resources.XML_Clean;
            this.pictureBoxXML.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxXML.Name = "pictureBoxXML";
            this.pictureBoxXML.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxXML.TabIndex = 12;
            this.pictureBoxXML.TabStop = false;
            // 
            // ShowFieldsCheckBox
            // 
            this.ShowFieldsCheckBox.AutoSize = true;
            this.ShowFieldsCheckBox.Checked = true;
            this.ShowFieldsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowFieldsCheckBox.Location = new System.Drawing.Point(11, 117);
            this.ShowFieldsCheckBox.Name = "ShowFieldsCheckBox";
            this.ShowFieldsCheckBox.Size = new System.Drawing.Size(221, 17);
            this.ShowFieldsCheckBox.TabIndex = 1004;
            this.ShowFieldsCheckBox.Text = "Show the Bugzilla fields in the Project file.";
            this.ShowFieldsCheckBox.UseVisualStyleBackColor = true;
            this.ShowFieldsCheckBox.CheckedChanged += new System.EventHandler(this.ShowFieldsCheckBox_CheckedChanged);
            // 
            // SimpleWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 388);
            this.Controls.Add(this.panelStep2);
            this.Controls.Add(this.panelStep1);
            this.Controls.Add(this.panelStep3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleWizard";
            this.ShowIcon = false;
            this.Text = "Simple Generator Wizard";
            this.panelStep1.ResumeLayout(false);
            this.groupBoxStep1.ResumeLayout(false);
            this.groupBoxStep1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panelStep2.ResumeLayout(false);
            this.groupBoxStep2.ResumeLayout(false);
            this.groupBoxStep2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelStep3.ResumeLayout(false);
            this.groupBoxStep3.ResumeLayout(false);
            this.groupBoxStep3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxXML)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStep1;
        private System.Windows.Forms.GroupBox groupBoxStep1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelStep2;
        private System.Windows.Forms.Panel panelStep3;
        private System.Windows.Forms.Button buttonNextStep1;
        private System.Windows.Forms.GroupBox groupBoxStep3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonPrevStep3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxBugzillaXML;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.GroupBox groupBoxStep2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProjectNewFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjectExistingFile;
        private System.Windows.Forms.Button www;
        private System.Windows.Forms.Button buttonNextStep2;
        private System.Windows.Forms.Button buttonPrevStep2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxProject;
        private System.Windows.Forms.PictureBox pictureBoxXML;
        private System.Windows.Forms.PictureBox pictureBoxGenerate;
        private System.Windows.Forms.LinkLabel saveLabel1;
        private System.Windows.Forms.CheckBox ShowFieldsCheckBox;

    }
}