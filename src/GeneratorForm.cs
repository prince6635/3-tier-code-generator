using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ThreeLayersCodeGenerator.Properties;

namespace ThreeLayersCodeGenerator
{
    public partial class GeneratorForm : Form
    {
        public GeneratorForm()
        {
            InitializeComponent();
        }

        private static string _ConnString = string.Empty;

        private void GeneratorForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_ConnStrTxt.Text))
            {
                _ConnStrTxt.Text = CommonArgs.InitialConnString;
            }
        }

        private void _CreateConnBtn_Click(object sender, EventArgs e)
        {
            string strDataSource = _DatasourceTxt.Text.Trim();
            string strDatabase = _DatabaseTxt.Text.Trim();
            if (string.IsNullOrEmpty(strDataSource) || string.IsNullOrEmpty(strDatabase))
            {
                MessageBox.Show("Both of Data Source and Database cannot be empty!");
                return;
            }

            _ConnStrTxt.Text = string.Format(CommonArgs.ConnStringTemplate, strDataSource, strDatabase);
        }

        private void _ConnectBtn_Click(object sender, EventArgs e)
        {
            _ConnString = _ConnStrTxt.Text.Trim();
            _TablesClb.Items.Clear();

            try
            {
                SqlHelper.connstr = _ConnString;
                DataTable dt = SqlHelper.ExecuteDataTable("Select * from INFORMATION_SCHEMA.TABLES");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("There is no table in the database!");
                    return;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    _TablesClb.Items.Add(dr["TABLE_NAME"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _GenerateBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(_OutPutDirTxt.Text.Trim()))
            {
                MessageBox.Show("Please choose the folder you want to save!");
                return;
            }

            if (_TablesClb.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Pleae at least choose one table to generate!");
                return;
            } 

            _LogTxt.Clear();
            GeneratorArgs args = new GeneratorArgs();
            args.ConnectionString = _ConnStrTxt.Text;
            args.OutputDir = _OutPutDirTxt.Text;
            args.RootNamespace = _NameSpaceTxt.Text;
            foreach (string tableName in _TablesClb.CheckedItems)
            {
                GeneratorUtility generator = new GeneratorUtility(tableName);
                if (_GenerateModelCbx.Checked)
                {
                    generator.GenerateModel(args); 
                }
                if (_GenerateDALCbx.Checked)
                {
                    generator.GenerateDAL(args);
                }
                if (_GenerateBLLCbx.Checked)
                {
                    generator.GenerateBLL(args);
                }

                _LogTxt.AppendText(tableName + "Generate successfully!\n");
            }
            _LogTxt.AppendText("All Done......\n");

            MessageBox.Show("Generate Successfully!");
        } 

        private void btnBrowseOutputDir_Click(object sender, EventArgs e)
        {
            if (_OutputDirFolderBrowserDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            _OutPutDirTxt.Text = _OutputDirFolderBrowserDialog.SelectedPath;
        }

        private void GeneratorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
        }

       
    }
}
