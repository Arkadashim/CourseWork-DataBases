
namespace CourseWork
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SetterResultButton = new System.Windows.Forms.Button();
            this.ThemeLabel = new System.Windows.Forms.Label();
            this.MarksBox = new System.Windows.Forms.ComboBox();
            this.MarkSortLabel = new System.Windows.Forms.Label();
            this.CancelSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchNameTextBox = new System.Windows.Forms.TextBox();
            this.ReviewerLabel = new System.Windows.Forms.Label();
            this.ShowGroupBox = new System.Windows.Forms.GroupBox();
            this.SRB = new System.Windows.Forms.RadioButton();
            this.NSRB = new System.Windows.Forms.RadioButton();
            this.AllRB = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.ComboBox();
            this.ResultsGridView = new System.Windows.Forms.DataGridView();
            this.AGridLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SetThemeButton = new System.Windows.Forms.Button();
            this.RemoveStudButton = new System.Windows.Forms.Button();
            this.AddStudButton = new System.Windows.Forms.Button();
            this.SetPIButton = new System.Windows.Forms.Button();
            this.EditingGroupBox = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.StudentsGrid = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.EditRevGroupBox = new System.Windows.Forms.GroupBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.RevGridView = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ShowGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.EditingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.EditRevGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RevGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 381);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.TabStop = false;
            this.tabControl.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.SetterResultButton);
            this.tabPage1.Controls.Add(this.ThemeLabel);
            this.tabPage1.Controls.Add(this.MarksBox);
            this.tabPage1.Controls.Add(this.MarkSortLabel);
            this.tabPage1.Controls.Add(this.CancelSearchButton);
            this.tabPage1.Controls.Add(this.SearchButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.SearchNameTextBox);
            this.tabPage1.Controls.Add(this.ReviewerLabel);
            this.tabPage1.Controls.Add(this.ShowGroupBox);
            this.tabPage1.Controls.Add(this.groupBox);
            this.tabPage1.Controls.Add(this.ResultsGridView);
            this.tabPage1.Controls.Add(this.AGridLabel);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Menu";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // SetterResultButton
            // 
            this.SetterResultButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SetterResultButton.Enabled = false;
            this.SetterResultButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SetterResultButton.Location = new System.Drawing.Point(46, 288);
            this.SetterResultButton.Name = "SetterResultButton";
            this.SetterResultButton.Size = new System.Drawing.Size(151, 41);
            this.SetterResultButton.TabIndex = 13;
            this.SetterResultButton.Text = "Set Result";
            this.SetterResultButton.UseVisualStyleBackColor = true;
            this.SetterResultButton.Click += new System.EventHandler(this.SetterResultButton_Click);
            // 
            // ThemeLabel
            // 
            this.ThemeLabel.AutoSize = true;
            this.ThemeLabel.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ThemeLabel.Location = new System.Drawing.Point(499, 267);
            this.ThemeLabel.MaximumSize = new System.Drawing.Size(470, 0);
            this.ThemeLabel.Name = "ThemeLabel";
            this.ThemeLabel.Size = new System.Drawing.Size(237, 28);
            this.ThemeLabel.TabIndex = 12;
            this.ThemeLabel.Text = "Student\'s theme of work:";
            // 
            // MarksBox
            // 
            this.MarksBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarksBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MarksBox.FormattingEnabled = true;
            this.MarksBox.Location = new System.Drawing.Point(561, 224);
            this.MarksBox.Name = "MarksBox";
            this.MarksBox.Size = new System.Drawing.Size(165, 31);
            this.MarksBox.TabIndex = 11;
            this.MarksBox.TabStop = false;
            this.MarksBox.SelectedIndexChanged += new System.EventHandler(this.MarksBox_SelectedIndexChanged);
            // 
            // MarkSortLabel
            // 
            this.MarkSortLabel.AutoSize = true;
            this.MarkSortLabel.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MarkSortLabel.Location = new System.Drawing.Point(561, 193);
            this.MarkSortLabel.MaximumSize = new System.Drawing.Size(470, 0);
            this.MarkSortLabel.Name = "MarkSortLabel";
            this.MarkSortLabel.Size = new System.Drawing.Size(165, 28);
            this.MarkSortLabel.TabIndex = 10;
            this.MarkSortLabel.Text = "Show with Mark:";
            // 
            // CancelSearchButton
            // 
            this.CancelSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelSearchButton.Enabled = false;
            this.CancelSearchButton.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.CancelSearchButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelSearchButton.Image")));
            this.CancelSearchButton.Location = new System.Drawing.Point(431, 298);
            this.CancelSearchButton.Name = "CancelSearchButton";
            this.CancelSearchButton.Size = new System.Drawing.Size(36, 31);
            this.CancelSearchButton.TabIndex = 9;
            this.CancelSearchButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CancelSearchButton.UseVisualStyleBackColor = true;
            this.CancelSearchButton.Click += new System.EventHandler(this.CancelSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchButton.Enabled = false;
            this.SearchButton.Location = new System.Drawing.Point(389, 298);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(36, 31);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "🔎";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(236, 267);
            this.label1.MaximumSize = new System.Drawing.Size(470, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search by student name:";
            // 
            // SearchNameTextBox
            // 
            this.SearchNameTextBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchNameTextBox.Location = new System.Drawing.Point(236, 298);
            this.SearchNameTextBox.Name = "SearchNameTextBox";
            this.SearchNameTextBox.Size = new System.Drawing.Size(147, 31);
            this.SearchNameTextBox.TabIndex = 6;
            this.SearchNameTextBox.TextChanged += new System.EventHandler(this.SearchNameTextBox_TextChanged);
            // 
            // ReviewerLabel
            // 
            this.ReviewerLabel.AutoSize = true;
            this.ReviewerLabel.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ReviewerLabel.Location = new System.Drawing.Point(341, 14);
            this.ReviewerLabel.MaximumSize = new System.Drawing.Size(470, 0);
            this.ReviewerLabel.Name = "ReviewerLabel";
            this.ReviewerLabel.Size = new System.Drawing.Size(108, 28);
            this.ReviewerLabel.TabIndex = 5;
            this.ReviewerLabel.Text = "Reviewer: ";
            // 
            // ShowGroupBox
            // 
            this.ShowGroupBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ShowGroupBox.Controls.Add(this.SRB);
            this.ShowGroupBox.Controls.Add(this.NSRB);
            this.ShowGroupBox.Controls.Add(this.AllRB);
            this.ShowGroupBox.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShowGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ShowGroupBox.Location = new System.Drawing.Point(552, 45);
            this.ShowGroupBox.Name = "ShowGroupBox";
            this.ShowGroupBox.Size = new System.Drawing.Size(184, 134);
            this.ShowGroupBox.TabIndex = 4;
            this.ShowGroupBox.TabStop = false;
            this.ShowGroupBox.Text = "Show:";
            // 
            // SRB
            // 
            this.SRB.AutoSize = true;
            this.SRB.Location = new System.Drawing.Point(6, 93);
            this.SRB.Name = "SRB";
            this.SRB.Size = new System.Drawing.Size(130, 32);
            this.SRB.TabIndex = 2;
            this.SRB.TabStop = true;
            this.SRB.Text = "Setted only";
            this.SRB.UseVisualStyleBackColor = true;
            this.SRB.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // NSRB
            // 
            this.NSRB.AutoSize = true;
            this.NSRB.Location = new System.Drawing.Point(6, 60);
            this.NSRB.Name = "NSRB";
            this.NSRB.Size = new System.Drawing.Size(168, 32);
            this.NSRB.TabIndex = 1;
            this.NSRB.TabStop = true;
            this.NSRB.Text = "Not Setted only";
            this.NSRB.UseVisualStyleBackColor = true;
            this.NSRB.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // AllRB
            // 
            this.AllRB.AutoSize = true;
            this.AllRB.Location = new System.Drawing.Point(6, 27);
            this.AllRB.Name = "AllRB";
            this.AllRB.Size = new System.Drawing.Size(54, 32);
            this.AllRB.TabIndex = 0;
            this.AllRB.TabStop = true;
            this.AllRB.Text = "All";
            this.AllRB.UseVisualStyleBackColor = true;
            this.AllRB.CheckedChanged += new System.EventHandler(this.RadioButtonChanged);
            // 
            // groupBox
            // 
            this.groupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.FormattingEnabled = true;
            this.groupBox.Location = new System.Drawing.Point(136, 11);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(199, 31);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            this.groupBox.SelectedIndexChanged += new System.EventHandler(this.groupBox_SelectedIndexChanged);
            // 
            // ResultsGridView
            // 
            this.ResultsGridView.AllowUserToAddRows = false;
            this.ResultsGridView.AllowUserToDeleteRows = false;
            this.ResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsGridView.Location = new System.Drawing.Point(46, 45);
            this.ResultsGridView.Name = "ResultsGridView";
            this.ResultsGridView.ReadOnly = true;
            this.ResultsGridView.RowHeadersWidth = 25;
            this.ResultsGridView.RowTemplate.Height = 25;
            this.ResultsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultsGridView.Size = new System.Drawing.Size(500, 210);
            this.ResultsGridView.TabIndex = 1;
            this.ResultsGridView.TabStop = false;
            this.ResultsGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.ResultsGridView_ColumnWidthChanged);
            this.ResultsGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultsGridView_RowEnter);
            this.ResultsGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.ResultsGridView_RowsRemoved);
            // 
            // AGridLabel
            // 
            this.AGridLabel.AutoSize = true;
            this.AGridLabel.Font = new System.Drawing.Font("Sitka Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AGridLabel.Location = new System.Drawing.Point(46, 14);
            this.AGridLabel.Name = "AGridLabel";
            this.AGridLabel.Size = new System.Drawing.Size(84, 28);
            this.AGridLabel.TabIndex = 2;
            this.AGridLabel.Text = "Results:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage2.Controls.Add(this.SetThemeButton);
            this.tabPage2.Controls.Add(this.RemoveStudButton);
            this.tabPage2.Controls.Add(this.AddStudButton);
            this.tabPage2.Controls.Add(this.SetPIButton);
            this.tabPage2.Controls.Add(this.EditingGroupBox);
            this.tabPage2.Controls.Add(this.StudentsGrid);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(776, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Students";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // SetThemeButton
            // 
            this.SetThemeButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SetThemeButton.Location = new System.Drawing.Point(283, 227);
            this.SetThemeButton.Name = "SetThemeButton";
            this.SetThemeButton.Size = new System.Drawing.Size(198, 33);
            this.SetThemeButton.TabIndex = 5;
            this.SetThemeButton.Text = "Set new Theme";
            this.SetThemeButton.UseVisualStyleBackColor = true;
            this.SetThemeButton.Click += new System.EventHandler(this.SetThemeButton_Click);
            // 
            // RemoveStudButton
            // 
            this.RemoveStudButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoveStudButton.Location = new System.Drawing.Point(283, 266);
            this.RemoveStudButton.Name = "RemoveStudButton";
            this.RemoveStudButton.Size = new System.Drawing.Size(198, 33);
            this.RemoveStudButton.TabIndex = 4;
            this.RemoveStudButton.Text = "Remove Student";
            this.RemoveStudButton.UseVisualStyleBackColor = true;
            this.RemoveStudButton.Click += new System.EventHandler(this.RemoveStudButton_Click);
            // 
            // AddStudButton
            // 
            this.AddStudButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddStudButton.Location = new System.Drawing.Point(24, 266);
            this.AddStudButton.Name = "AddStudButton";
            this.AddStudButton.Size = new System.Drawing.Size(253, 33);
            this.AddStudButton.TabIndex = 3;
            this.AddStudButton.Text = "Add new Student";
            this.AddStudButton.UseVisualStyleBackColor = true;
            this.AddStudButton.Click += new System.EventHandler(this.AddStudButton_Click);
            // 
            // SetPIButton
            // 
            this.SetPIButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SetPIButton.Location = new System.Drawing.Point(24, 227);
            this.SetPIButton.Name = "SetPIButton";
            this.SetPIButton.Size = new System.Drawing.Size(253, 33);
            this.SetPIButton.TabIndex = 2;
            this.SetPIButton.Text = "Edit Personal Information";
            this.SetPIButton.UseVisualStyleBackColor = true;
            this.SetPIButton.Click += new System.EventHandler(this.SetPIButton_Click);
            // 
            // EditingGroupBox
            // 
            this.EditingGroupBox.Controls.Add(this.buttonCancel);
            this.EditingGroupBox.Controls.Add(this.buttonOK);
            this.EditingGroupBox.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditingGroupBox.Location = new System.Drawing.Point(502, 17);
            this.EditingGroupBox.Name = "EditingGroupBox";
            this.EditingGroupBox.Size = new System.Drawing.Size(251, 317);
            this.EditingGroupBox.TabIndex = 1;
            this.EditingGroupBox.TabStop = false;
            this.EditingGroupBox.Text = "Editing Box";
            this.EditingGroupBox.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCancel.Location = new System.Drawing.Point(212, 288);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(33, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "✗";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonOK.Location = new System.Drawing.Point(173, 288);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(33, 29);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "✓";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // StudentsGrid
            // 
            this.StudentsGrid.AllowUserToAddRows = false;
            this.StudentsGrid.AllowUserToDeleteRows = false;
            this.StudentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsGrid.Location = new System.Drawing.Point(24, 17);
            this.StudentsGrid.Name = "StudentsGrid";
            this.StudentsGrid.RowHeadersWidth = 25;
            this.StudentsGrid.RowTemplate.Height = 25;
            this.StudentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentsGrid.Size = new System.Drawing.Size(457, 204);
            this.StudentsGrid.TabIndex = 0;
            this.StudentsGrid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.StudentsGrid_ColumnWidthChanged);
            this.StudentsGrid.SelectionChanged += new System.EventHandler(this.StudentsGrid_SelectionChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage3.Controls.Add(this.RemoveButton);
            this.tabPage3.Controls.Add(this.AddButton);
            this.tabPage3.Controls.Add(this.EditButton);
            this.tabPage3.Controls.Add(this.EditRevGroupBox);
            this.tabPage3.Controls.Add(this.RevGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(776, 349);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Professors";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RemoveButton.Location = new System.Drawing.Point(383, 280);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(321, 33);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddButton.Location = new System.Drawing.Point(383, 241);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(321, 33);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Add new Professor";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditButton.Location = new System.Drawing.Point(383, 202);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(321, 33);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "Edit Personal Information";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // EditRevGroupBox
            // 
            this.EditRevGroupBox.Controls.Add(this.CancelButton);
            this.EditRevGroupBox.Controls.Add(this.OKButton);
            this.EditRevGroupBox.Location = new System.Drawing.Point(29, 26);
            this.EditRevGroupBox.Name = "EditRevGroupBox";
            this.EditRevGroupBox.Size = new System.Drawing.Size(294, 283);
            this.EditRevGroupBox.TabIndex = 2;
            this.EditRevGroupBox.TabStop = false;
            this.EditRevGroupBox.Text = "EditRevGroupBox";
            this.EditRevGroupBox.Visible = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CancelButton.Location = new System.Drawing.Point(242, 254);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(33, 29);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "✗";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.OKButton.Location = new System.Drawing.Point(203, 254);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(33, 29);
            this.OKButton.TabIndex = 14;
            this.OKButton.Text = "✓";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // RevGridView
            // 
            this.RevGridView.AllowUserToAddRows = false;
            this.RevGridView.AllowUserToDeleteRows = false;
            this.RevGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RevGridView.Location = new System.Drawing.Point(383, 26);
            this.RevGridView.Name = "RevGridView";
            this.RevGridView.RowHeadersWidth = 25;
            this.RevGridView.RowTemplate.Height = 25;
            this.RevGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RevGridView.Size = new System.Drawing.Size(321, 170);
            this.RevGridView.TabIndex = 1;
            this.RevGridView.SelectionChanged += new System.EventHandler(this.RevGridView_SelectionChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(776, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Groups";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage5.Location = new System.Drawing.Point(4, 28);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(776, 349);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Workthemes";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 381);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Sitka Text", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoURSEWORK ";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ShowGroupBox.ResumeLayout(false);
            this.ShowGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.EditingGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StudentsGrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.EditRevGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RevGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView ResultsGridView;
        private System.Windows.Forms.Label AGridLabel;
        private System.Windows.Forms.ComboBox groupBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox ShowGroupBox;
        private System.Windows.Forms.RadioButton SRB;
        private System.Windows.Forms.RadioButton NSRB;
        private System.Windows.Forms.RadioButton AllRB;
        private System.Windows.Forms.Label ReviewerLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchNameTextBox;
        private System.Windows.Forms.Button CancelSearchButton;
        private System.Windows.Forms.ComboBox MarksBox;
        private System.Windows.Forms.Label MarkSortLabel;
        private System.Windows.Forms.Label ThemeLabel;
        private System.Windows.Forms.Button SetterResultButton;
        private System.Windows.Forms.DataGridView StudentsGrid;
        private System.Windows.Forms.Button RemoveStudButton;
        private System.Windows.Forms.Button AddStudButton;
        private System.Windows.Forms.Button SetPIButton;
        private System.Windows.Forms.GroupBox EditingGroupBox;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button SetThemeButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView RevGridView;
        private System.Windows.Forms.GroupBox EditRevGroupBox;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}

