namespace ProjectBugzilla
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenBugzillaXML = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewProjectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.wizardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutProjzillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBoxQuickGen = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBoxWizard = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuickGen)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWizard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.wizardsToolStripMenuItem,
            this.heToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(265, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenBugzillaXML,
            this.generateNewProjectFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "&File";
            // 
            // menuOpenBugzillaXML
            // 
            this.menuOpenBugzillaXML.Name = "menuOpenBugzillaXML";
            this.menuOpenBugzillaXML.Size = new System.Drawing.Size(219, 22);
            this.menuOpenBugzillaXML.Text = "Quick Generate Bugzilla XML";
            this.menuOpenBugzillaXML.Click += new System.EventHandler(this.menuOpenBugzillaXML_Click);
            // 
            // generateNewProjectFileToolStripMenuItem
            // 
            this.generateNewProjectFileToolStripMenuItem.Name = "generateNewProjectFileToolStripMenuItem";
            this.generateNewProjectFileToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.generateNewProjectFileToolStripMenuItem.Text = "Quick Generate Project File";
            this.generateNewProjectFileToolStripMenuItem.Click += new System.EventHandler(this.menuGenerateNewProjectFile_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(216, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(219, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // wizardsToolStripMenuItem
            // 
            this.wizardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleToolStripMenuItem});
            this.wizardsToolStripMenuItem.Name = "wizardsToolStripMenuItem";
            this.wizardsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.wizardsToolStripMenuItem.Text = "Wizard";
            // 
            // simpleToolStripMenuItem
            // 
            this.simpleToolStripMenuItem.Name = "simpleToolStripMenuItem";
            this.simpleToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.simpleToolStripMenuItem.Text = "Simple  Generator Wizard";
            this.simpleToolStripMenuItem.Click += new System.EventHandler(this.simpleToolStripMenuItem_Click);
            // 
            // heToolStripMenuItem
            // 
            this.heToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.toolStripMenuItem3,
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutProjzillaToolStripMenuItem});
            this.heToolStripMenuItem.Name = "heToolStripMenuItem";
            this.heToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.heToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.documentationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 6);
            // 
            // aboutProjzillaToolStripMenuItem
            // 
            this.aboutProjzillaToolStripMenuItem.Name = "aboutProjzillaToolStripMenuItem";
            this.aboutProjzillaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.aboutProjzillaToolStripMenuItem.Text = "About Projzilla";
            this.aboutProjzillaToolStripMenuItem.Click += new System.EventHandler(this.aboutProjzillaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quick Generate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wizard";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.pictureBoxQuickGen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 106);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick Generate";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Location = new System.Drawing.Point(98, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(138, 75);
            this.textBox1.TabIndex = 1000;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Quick Generate will in one click generate your project file to the same settings " +
                "which were done on the last generation.";
            // 
            // pictureBoxQuickGen
            // 
            this.pictureBoxQuickGen.Image = global::ProjectBugzilla.Properties.Resources.Quick;
            this.pictureBoxQuickGen.Location = new System.Drawing.Point(30, 19);
            this.pictureBoxQuickGen.Name = "pictureBoxQuickGen";
            this.pictureBoxQuickGen.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxQuickGen.TabIndex = 1;
            this.pictureBoxQuickGen.TabStop = false;
            this.pictureBoxQuickGen.Click += new System.EventHandler(this.pictureBoxQuickGen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.pictureBoxWizard);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 106);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simple Wizard";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Location = new System.Drawing.Point(98, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(138, 75);
            this.textBox2.TabIndex = 1001;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "This will take you through a simple three step wizard to create the project file " +
                "from your bugzilla search.";
            // 
            // pictureBoxWizard
            // 
            this.pictureBoxWizard.Image = global::ProjectBugzilla.Properties.Resources.Wizard;
            this.pictureBoxWizard.Location = new System.Drawing.Point(30, 19);
            this.pictureBoxWizard.Name = "pictureBoxWizard";
            this.pictureBoxWizard.Size = new System.Drawing.Size(38, 38);
            this.pictureBoxWizard.TabIndex = 2;
            this.pictureBoxWizard.TabStop = false;
            this.pictureBoxWizard.Click += new System.EventHandler(this.pictureBoxWizard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(265, 269);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Projzilla";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuickGen)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWizard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem wizardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutProjzillaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.PictureBox pictureBoxQuickGen;
        private System.Windows.Forms.PictureBox pictureBoxWizard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem menuOpenBugzillaXML;
        private System.Windows.Forms.ToolStripMenuItem generateNewProjectFileToolStripMenuItem;

    }
}

