using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlTypes;

namespace ThreeLayersCodeGenerator
{
    partial class GeneratorUtility
    {
        private DataTable dtCols;
        private string tableName;
        private DataTable dtPrimaryKeys;
        private DataTable dtIdentityCols;
        private Dictionary<string, string> dictDefaultValueCols;

        public GeneratorUtility(string tableName)
        {
            this.tableName = tableName;
            
            // All columns in table
            dtCols = SqlHelper.ExecuteDataTable("select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @tablename",
                new SqlParameter("@tablename", this.tableName));
            
            // All primary keys in the table
            dtPrimaryKeys = SqlHelper.ExecuteDataTable("SELECT ColName=column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                "WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = @tablename",
                new SqlParameter("@tablename", this.tableName));
            
            // All identity columns in the table
            dtIdentityCols = SqlHelper.ExecuteDataTable("SELECT ColName=i.name FROM sys.identity_columns i " +
                "Inner join INFORMATION_SCHEMA.COLUMNS c on i.name = c.COLUMN_NAME where c.TABLE_NAME = @tablename",
                new SqlParameter("@tablename", this.tableName));

            // All columns which have default values
            DataTable dtTemp = SqlHelper.ExecuteDataTable("select COLUMN_NAME, DATA_TYPE, COLUMN_DEFAULT from INFORMATION_SCHEMA.COLUMNS " +
                "where TABLE_NAME=@tablename and COLUMN_DEFAULT is not null",
                new SqlParameter("@tablename", this.tableName));
            dictDefaultValueCols = ConvertDbDefautValuesToDict(dtTemp);
        }


        /// <summary>
        /// Generate Model Layer
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="args"></param>
        public void GenerateModel(GeneratorArgs args)
        {             
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("namespace " + args.RootNamespace + ".Model");
            sb.AppendLine("{");
            sb.AppendLine("public partial class " + tableName);
            sb.AppendLine("{");
            foreach (DataRow row in dtCols.Rows)
            {
                string colName = Convert.ToString(row["Column_Name"]);
                string dataType = Convert.ToString(row["Data_Type"]);
                Type netType = GetDotNetTypeByDBType(dataType);
                string netTypeName;
                
                // Set value type to be nullable
                if (netType.IsValueType)
                {
                    netTypeName = netType.ToString() + "?";
                }
                else
                {
                    netTypeName = netType.ToString();
                }
                sb.AppendLine("public " + netTypeName + " " + colName + " { get; set; }");
            }
            sb.AppendLine("}");
            sb.AppendLine("}");
            string modelDir = Path.Combine(args.OutputDir, "Model"); // Add folder seperator automatically
            string modelFile = Path.Combine(modelDir, tableName + ".cs");
            Directory.CreateDirectory(modelDir);
            File.WriteAllText(modelFile, sb.ToString());
        }

        #region Assistant methods
        /// <summary>
        /// Get column names in a DataTable
        /// </summary>
        /// <param name="dtCols"></param>
        /// <returns></returns>
        private string[] GetCols(DataTable dtCols)
        {
            List<string> list = new List<string>();
            foreach (DataRow row in dtCols.Rows)
            {
                string colName = Convert.ToString(row["Column_Name"]);
                list.Add(colName);
            }
            return list.ToArray();
        }       

        /// <summary>
        /// Convert DB type to C# type
        /// </summary>
        /// <param name="dbtype"></param>
        /// <returns></returns>
        private Type GetDotNetTypeByDBType(string dbtype)
        {
            switch (dbtype.ToLower())
            {
                case "tinyint":
                    return typeof(Byte);
                case "smallint":
                    return typeof(Int16);
                case "int":
                    return typeof(Int32);
                case "bigint":
                    return typeof(Int64);
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    return typeof(Decimal);
                case "float":
                    return typeof(Double);
                    
                case "binary":
                case "varbinary":
                    return typeof(Byte[]);
                                        
                case "bit":
                    return typeof(Boolean);
                    
                case "char":
                case "varchar":
                case "nchar": 
                case "nvarchar":
                    return typeof(String);
                    
                case "date":
                case "datetime":
                case "datetime2":
                case "smalldatetime":
                    return typeof(DateTime);
                case "datetimeoffset":
                    return typeof(DateTimeOffset);
                case "time":
                    return typeof(TimeSpan);

                case "real":
                    return typeof(Single);
                                    
                case "uniqueidentifier":
                    return typeof(Guid);

                case "xml":
                    return typeof(SqlXml);

                default:
                    return typeof(object);
            }
        }

        private Dictionary<string, string> ConvertDbDefautValuesToDict(DataTable dtTemp)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (DataRow dr in dtTemp.Rows)
            {
                string value = string.Empty;
                string dataType = dr["DATA_TYPE"].ToString();
                string defaultValue = dr["COLUMN_DEFAULT"].ToString();
                
                if (dataType.Contains("char"))
                {
                    value = string.Format("\"{0}\"", defaultValue.Substring(2, defaultValue.Length - 4));
                }
                else if (dataType.Contains("int"))
                {
                    value = defaultValue.Substring(2, defaultValue.Length - 4);
                }
                else if (dataType.Contains("bit"))
                {
                    value = defaultValue.Substring(2, defaultValue.Length - 4) == "0" ? "false" : "true";
                }
                else if (dataType.Contains("date") || dataType.Contains("time"))
                {
                    if (defaultValue.Contains("getdate"))
                    {
                        value = "DateTime.Now";
                    }
                    else
                    {
                        value = string.Format("Convert.ToDateTime(\"{0}\")", defaultValue.Substring(2, defaultValue.Length - 4));
                    }
                }
                else
                {
                    value = defaultValue.Substring(1, defaultValue.Length - 2);
                }

                dict.Add(dr["COLUMN_NAME"].ToString(), value);
            }

            return dict;
        }
        #endregion 
    }
}
