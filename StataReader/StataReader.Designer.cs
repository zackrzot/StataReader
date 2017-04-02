namespace StataReader
{
    partial class StataReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StataReader));
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listBoxSelectedFiles = new System.Windows.Forms.ListBox();
            this.groupBoxSelect = new System.Windows.Forms.GroupBox();
            this.groupBoxParse = new System.Windows.Forms.GroupBox();
            this.treeViewParsedFiles = new System.Windows.Forms.TreeView();
            this.buttonParse = new System.Windows.Forms.Button();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_filters = new System.Windows.Forms.GroupBox();
            this.listBox_filters = new System.Windows.Forms.ListBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_newval = new System.Windows.Forms.TextBox();
            this.button_openfilter = new System.Windows.Forms.Button();
            this.button_savefilter = new System.Windows.Forms.Button();
            this.button_tabsspearman = new System.Windows.Forms.Button();
            this.button_zabs = new System.Windows.Forms.Button();
            this.groupBoxSelect.SuspendLayout();
            this.groupBoxParse.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox_filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(6, 452);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(177, 30);
            this.buttonSelectFiles.TabIndex = 0;
            this.buttonSelectFiles.Text = "Select Files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.buttonSelectFiles_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // listBoxSelectedFiles
            // 
            this.listBoxSelectedFiles.FormattingEnabled = true;
            this.listBoxSelectedFiles.Location = new System.Drawing.Point(6, 19);
            this.listBoxSelectedFiles.Name = "listBoxSelectedFiles";
            this.listBoxSelectedFiles.Size = new System.Drawing.Size(177, 420);
            this.listBoxSelectedFiles.TabIndex = 1;
            // 
            // groupBoxSelect
            // 
            this.groupBoxSelect.Controls.Add(this.listBoxSelectedFiles);
            this.groupBoxSelect.Controls.Add(this.buttonSelectFiles);
            this.groupBoxSelect.Location = new System.Drawing.Point(12, 27);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Size = new System.Drawing.Size(200, 488);
            this.groupBoxSelect.TabIndex = 3;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "1. Select Stata Files";
            // 
            // groupBoxParse
            // 
            this.groupBoxParse.Controls.Add(this.treeViewParsedFiles);
            this.groupBoxParse.Controls.Add(this.buttonParse);
            this.groupBoxParse.Enabled = false;
            this.groupBoxParse.Location = new System.Drawing.Point(218, 229);
            this.groupBoxParse.Name = "groupBoxParse";
            this.groupBoxParse.Size = new System.Drawing.Size(342, 286);
            this.groupBoxParse.TabIndex = 4;
            this.groupBoxParse.TabStop = false;
            this.groupBoxParse.Text = "3. Parse Files";
            // 
            // treeViewParsedFiles
            // 
            this.treeViewParsedFiles.Location = new System.Drawing.Point(6, 19);
            this.treeViewParsedFiles.Name = "treeViewParsedFiles";
            this.treeViewParsedFiles.Size = new System.Drawing.Size(330, 218);
            this.treeViewParsedFiles.TabIndex = 3;
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(103, 250);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(134, 30);
            this.buttonParse.TabIndex = 2;
            this.buttonParse.Text = "Run Filter";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.buttonSave);
            this.groupBoxSave.Enabled = false;
            this.groupBoxSave.Location = new System.Drawing.Point(566, 229);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(142, 286);
            this.groupBoxSave.TabIndex = 5;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "4. Export Data";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 216);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(130, 64);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Open Data in Excel";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(723, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click_1);
            // 
            // groupBox_filters
            // 
            this.groupBox_filters.Controls.Add(this.listBox_filters);
            this.groupBox_filters.Controls.Add(this.button_delete);
            this.groupBox_filters.Controls.Add(this.button_add);
            this.groupBox_filters.Controls.Add(this.textBox_newval);
            this.groupBox_filters.Controls.Add(this.button_openfilter);
            this.groupBox_filters.Controls.Add(this.button_savefilter);
            this.groupBox_filters.Controls.Add(this.button_tabsspearman);
            this.groupBox_filters.Controls.Add(this.button_zabs);
            this.groupBox_filters.Enabled = false;
            this.groupBox_filters.Location = new System.Drawing.Point(218, 36);
            this.groupBox_filters.Name = "groupBox_filters";
            this.groupBox_filters.Size = new System.Drawing.Size(490, 187);
            this.groupBox_filters.TabIndex = 5;
            this.groupBox_filters.TabStop = false;
            this.groupBox_filters.Text = "2. Select Filters";
            // 
            // listBox_filters
            // 
            this.listBox_filters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_filters.FormattingEnabled = true;
            this.listBox_filters.Location = new System.Drawing.Point(9, 19);
            this.listBox_filters.Name = "listBox_filters";
            this.listBox_filters.Size = new System.Drawing.Size(275, 158);
            this.listBox_filters.TabIndex = 10;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(290, 126);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(194, 23);
            this.button_delete.TabIndex = 9;
            this.button_delete.Text = "Delete Selected";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(425, 154);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(59, 23);
            this.button_add.TabIndex = 7;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_newval
            // 
            this.textBox_newval.Location = new System.Drawing.Point(290, 155);
            this.textBox_newval.Name = "textBox_newval";
            this.textBox_newval.Size = new System.Drawing.Size(129, 20);
            this.textBox_newval.TabIndex = 6;
            this.textBox_newval.Text = "Prob > |t|";
            // 
            // button_openfilter
            // 
            this.button_openfilter.Location = new System.Drawing.Point(290, 68);
            this.button_openfilter.Name = "button_openfilter";
            this.button_openfilter.Size = new System.Drawing.Size(194, 23);
            this.button_openfilter.TabIndex = 4;
            this.button_openfilter.Text = "Open Filter";
            this.button_openfilter.UseVisualStyleBackColor = true;
            this.button_openfilter.Click += new System.EventHandler(this.button_openfilter_Click);
            // 
            // button_savefilter
            // 
            this.button_savefilter.Location = new System.Drawing.Point(290, 97);
            this.button_savefilter.Name = "button_savefilter";
            this.button_savefilter.Size = new System.Drawing.Size(194, 23);
            this.button_savefilter.TabIndex = 3;
            this.button_savefilter.Text = "Save Filter";
            this.button_savefilter.UseVisualStyleBackColor = true;
            this.button_savefilter.Click += new System.EventHandler(this.button_savefilter_Click);
            // 
            // button_tabsspearman
            // 
            this.button_tabsspearman.Location = new System.Drawing.Point(290, 39);
            this.button_tabsspearman.Name = "button_tabsspearman";
            this.button_tabsspearman.Size = new System.Drawing.Size(194, 23);
            this.button_tabsspearman.TabIndex = 2;
            this.button_tabsspearman.Text = "Default Spearman\'s and | t |";
            this.button_tabsspearman.UseVisualStyleBackColor = true;
            this.button_tabsspearman.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_zabs
            // 
            this.button_zabs.Location = new System.Drawing.Point(290, 10);
            this.button_zabs.Name = "button_zabs";
            this.button_zabs.Size = new System.Drawing.Size(194, 23);
            this.button_zabs.TabIndex = 1;
            this.button_zabs.Text = "Default | z |";
            this.button_zabs.UseVisualStyleBackColor = true;
            this.button_zabs.Click += new System.EventHandler(this.button_default_z_Click);
            // 
            // StataReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 527);
            this.Controls.Add(this.groupBox_filters);
            this.Controls.Add(this.groupBoxSave);
            this.Controls.Add(this.groupBoxParse);
            this.Controls.Add(this.groupBoxSelect);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(739, 565);
            this.MinimumSize = new System.Drawing.Size(739, 565);
            this.Name = "StataReader";
            this.Text = " StataReader";
            this.groupBoxSelect.ResumeLayout(false);
            this.groupBoxParse.ResumeLayout(false);
            this.groupBoxSave.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox_filters.ResumeLayout(false);
            this.groupBox_filters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listBoxSelectedFiles;
        private System.Windows.Forms.GroupBox groupBoxSelect;
        private System.Windows.Forms.GroupBox groupBoxParse;
        private System.Windows.Forms.TreeView treeViewParsedFiles;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.GroupBox groupBoxSave;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_filters;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_newval;
        private System.Windows.Forms.Button button_openfilter;
        private System.Windows.Forms.Button button_savefilter;
        private System.Windows.Forms.Button button_tabsspearman;
        private System.Windows.Forms.Button button_zabs;
        private System.Windows.Forms.ListBox listBox_filters;
    }
}

