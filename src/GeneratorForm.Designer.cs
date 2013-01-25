namespace ThreeLayersCodeGenerator
{
    partial class GeneratorForm
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
            ThreeLayersCodeGenerator.Properties.Settings settings1 = new ThreeLayersCodeGenerator.Properties.Settings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorForm));
            this.label1 = new System.Windows.Forms.Label();
            this._ConnectBtn = new System.Windows.Forms.Button();
            this._TablesClb = new System.Windows.Forms.CheckedListBox();
            this._GenerateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._LogTxt = new System.Windows.Forms.TextBox();
            this.btnBrowseOutputDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._OutputDirFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._CreateConnBtn = new System.Windows.Forms.Button();
            this._DatasourceTxt = new System.Windows.Forms.TextBox();
            this._DatabaseTxt = new System.Windows.Forms.TextBox();
            this._NameSpaceTxt = new System.Windows.Forms.TextBox();
            this._OutPutDirTxt = new System.Windows.Forms.TextBox();
            this._GenerateModelCbx = new System.Windows.Forms.CheckBox();
            this._GenerateBLLCbx = new System.Windows.Forms.CheckBox();
            this._GenerateDALCbx = new System.Windows.Forms.CheckBox();
            this._ConnStrTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String:";
            // 
            // _ConnectBtn
            // 
            this._ConnectBtn.Location = new System.Drawing.Point(517, 59);
            this._ConnectBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._ConnectBtn.Name = "_ConnectBtn";
            this._ConnectBtn.Size = new System.Drawing.Size(148, 26);
            this._ConnectBtn.TabIndex = 2;
            this._ConnectBtn.Text = "Connect";
            this._ConnectBtn.UseVisualStyleBackColor = true;
            this._ConnectBtn.Click += new System.EventHandler(this._ConnectBtn_Click);
            // 
            // _TablesClb
            // 
            this._TablesClb.FormattingEnabled = true;
            this._TablesClb.HorizontalScrollbar = true;
            this._TablesClb.Location = new System.Drawing.Point(15, 108);
            this._TablesClb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._TablesClb.Name = "_TablesClb";
            this._TablesClb.ScrollAlwaysVisible = true;
            this._TablesClb.Size = new System.Drawing.Size(189, 327);
            this._TablesClb.TabIndex = 3;
            // 
            // _GenerateBtn
            // 
            this._GenerateBtn.Location = new System.Drawing.Point(573, 235);
            this._GenerateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._GenerateBtn.Name = "_GenerateBtn";
            this._GenerateBtn.Size = new System.Drawing.Size(89, 30);
            this._GenerateBtn.TabIndex = 4;
            this._GenerateBtn.Text = "Generate";
            this._GenerateBtn.UseVisualStyleBackColor = true;
            this._GenerateBtn.Click += new System.EventHandler(this._GenerateBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 158);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Namespace:";
            // 
            // _LogTxt
            // 
            this._LogTxt.Location = new System.Drawing.Point(225, 271);
            this._LogTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._LogTxt.Multiline = true;
            this._LogTxt.Name = "_LogTxt";
            this._LogTxt.Size = new System.Drawing.Size(439, 174);
            this._LogTxt.TabIndex = 21;
            // 
            // btnBrowseOutputDir
            // 
            this.btnBrowseOutputDir.Location = new System.Drawing.Point(631, 206);
            this.btnBrowseOutputDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowseOutputDir.Name = "btnBrowseOutputDir";
            this.btnBrowseOutputDir.Size = new System.Drawing.Size(32, 22);
            this.btnBrowseOutputDir.TabIndex = 19;
            this.btnBrowseOutputDir.Text = "...";
            this.btnBrowseOutputDir.UseVisualStyleBackColor = true;
            this.btnBrowseOutputDir.Click += new System.EventHandler(this.btnBrowseOutputDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Output Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Data Source:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Database:";
            // 
            // _CreateConnBtn
            // 
            this._CreateConnBtn.Location = new System.Drawing.Point(517, 9);
            this._CreateConnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._CreateConnBtn.Name = "_CreateConnBtn";
            this._CreateConnBtn.Size = new System.Drawing.Size(148, 26);
            this._CreateConnBtn.TabIndex = 28;
            this._CreateConnBtn.Text = "Create Connection";
            this._CreateConnBtn.UseVisualStyleBackColor = true;
            this._CreateConnBtn.Click += new System.EventHandler(this._CreateConnBtn_Click);
            // 
            // _DatasourceTxt
            // 
            this._DatasourceTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ThreeLayersCodeGenerator.Properties.Settings.Default, "DataSource", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._DatasourceTxt.Location = new System.Drawing.Point(127, 9);
            this._DatasourceTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._DatasourceTxt.Name = "_DatasourceTxt";
            this._DatasourceTxt.Size = new System.Drawing.Size(132, 22);
            this._DatasourceTxt.TabIndex = 29;
            this._DatasourceTxt.Text = global::ThreeLayersCodeGenerator.Properties.Settings.Default.DataSource;
            // 
            // _DatabaseTxt
            // 
            this._DatabaseTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ThreeLayersCodeGenerator.Properties.Settings.Default, "Database", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._DatabaseTxt.Location = new System.Drawing.Point(367, 10);
            this._DatabaseTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._DatabaseTxt.Name = "_DatabaseTxt";
            this._DatabaseTxt.Size = new System.Drawing.Size(132, 22);
            this._DatabaseTxt.TabIndex = 30;
            this._DatabaseTxt.Text = global::ThreeLayersCodeGenerator.Properties.Settings.Default.Database;
            // 
            // _NameSpaceTxt
            // 
            settings1.ConnString = "";
            settings1.Database = "";
            settings1.DataSource = "";
            settings1.GenerateBLL = true;
            settings1.GenerateDAL = true;
            settings1.GenerateModel = true;
            settings1.NameSpace = "";
            settings1.OutputPath = "";
            settings1.SettingsKey = "";
            this._NameSpaceTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "NameSpace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._NameSpaceTxt.Location = new System.Drawing.Point(321, 158);
            this._NameSpaceTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._NameSpaceTxt.Name = "_NameSpaceTxt";
            this._NameSpaceTxt.Size = new System.Drawing.Size(343, 22);
            this._NameSpaceTxt.TabIndex = 23;
            this._NameSpaceTxt.Text = settings1.NameSpace;
            // 
            // _OutPutDirTxt
            // 
            this._OutPutDirTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "OutputPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._OutPutDirTxt.Location = new System.Drawing.Point(321, 206);
            this._OutPutDirTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._OutPutDirTxt.Name = "_OutPutDirTxt";
            this._OutPutDirTxt.Size = new System.Drawing.Size(303, 22);
            this._OutPutDirTxt.TabIndex = 18;
            this._OutPutDirTxt.Text = settings1.OutputPath;
            // 
            // _GenerateModelCbx
            // 
            this._GenerateModelCbx.AutoSize = true;
            this._GenerateModelCbx.Checked = settings1.GenerateModel;
            this._GenerateModelCbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this._GenerateModelCbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "GenerateModel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._GenerateModelCbx.Location = new System.Drawing.Point(531, 118);
            this._GenerateModelCbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._GenerateModelCbx.Name = "_GenerateModelCbx";
            this._GenerateModelCbx.Size = new System.Drawing.Size(132, 21);
            this._GenerateModelCbx.TabIndex = 16;
            this._GenerateModelCbx.Text = "Generate Model";
            this._GenerateModelCbx.UseVisualStyleBackColor = true;
            // 
            // _GenerateBLLCbx
            // 
            this._GenerateBLLCbx.AutoSize = true;
            this._GenerateBLLCbx.Checked = settings1.GenerateBLL;
            this._GenerateBLLCbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this._GenerateBLLCbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "GenerateBLL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._GenerateBLLCbx.Location = new System.Drawing.Point(372, 118);
            this._GenerateBLLCbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._GenerateBLLCbx.Name = "_GenerateBLLCbx";
            this._GenerateBLLCbx.Size = new System.Drawing.Size(119, 21);
            this._GenerateBLLCbx.TabIndex = 15;
            this._GenerateBLLCbx.Text = "Generate BLL";
            this._GenerateBLLCbx.UseVisualStyleBackColor = true;
            // 
            // _GenerateDALCbx
            // 
            this._GenerateDALCbx.AutoSize = true;
            this._GenerateDALCbx.Checked = settings1.GenerateDAL;
            this._GenerateDALCbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this._GenerateDALCbx.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings1, "GenerateDAL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._GenerateDALCbx.Location = new System.Drawing.Point(229, 118);
            this._GenerateDALCbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._GenerateDALCbx.Name = "_GenerateDALCbx";
            this._GenerateDALCbx.Size = new System.Drawing.Size(121, 21);
            this._GenerateDALCbx.TabIndex = 14;
            this._GenerateDALCbx.Text = "Generate DAL";
            this._GenerateDALCbx.UseVisualStyleBackColor = true;
            // 
            // _ConnStrTxt
            // 
            this._ConnStrTxt.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "ConnString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._ConnStrTxt.Location = new System.Drawing.Point(145, 59);
            this._ConnStrTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._ConnStrTxt.Name = "_ConnStrTxt";
            this._ConnStrTxt.Size = new System.Drawing.Size(353, 22);
            this._ConnStrTxt.TabIndex = 1;
            this._ConnStrTxt.Text = settings1.ConnString;
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 459);
            this.Controls.Add(this._DatabaseTxt);
            this.Controls.Add(this._DatasourceTxt);
            this.Controls.Add(this._CreateConnBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._NameSpaceTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._LogTxt);
            this.Controls.Add(this.btnBrowseOutputDir);
            this.Controls.Add(this._OutPutDirTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._GenerateModelCbx);
            this.Controls.Add(this._GenerateBLLCbx);
            this.Controls.Add(this._GenerateDALCbx);
            this.Controls.Add(this._GenerateBtn);
            this.Controls.Add(this._TablesClb);
            this.Controls.Add(this._ConnectBtn);
            this.Controls.Add(this._ConnStrTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratorForm";
            this.Text = "Code Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneratorForm_FormClosed);
            this.Load += new System.EventHandler(this.GeneratorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _ConnStrTxt;
        private System.Windows.Forms.Button _ConnectBtn;
        private System.Windows.Forms.CheckedListBox _TablesClb;
        private System.Windows.Forms.Button _GenerateBtn;
        private System.Windows.Forms.TextBox _NameSpaceTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _LogTxt;
        private System.Windows.Forms.Button btnBrowseOutputDir;
        private System.Windows.Forms.TextBox _OutPutDirTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox _GenerateModelCbx;
        private System.Windows.Forms.CheckBox _GenerateBLLCbx;
        private System.Windows.Forms.CheckBox _GenerateDALCbx;
        private System.Windows.Forms.FolderBrowserDialog _OutputDirFolderBrowserDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _CreateConnBtn;
        private System.Windows.Forms.TextBox _DatasourceTxt;
        private System.Windows.Forms.TextBox _DatabaseTxt;
    }
}

