using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ThreeLayersCodeGenerator
{
    partial class GeneratorUtility
    {
        /// <summary>
        /// Generate DAL layer
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="args"></param>
        public void GenerateDAL(GeneratorArgs args)
        { 
            // Exclude columns with Identity property
            DataTable dtNoIdentityCols = SqlHelper.ExecuteDataTable("SELECT * FROM INFORMATION_SCHEMA.COLUMNS " +
                "WHERE COLUMNPROPERTY(OBJECT_ID(TABLE_NAME),COLUMN_NAME,'IsIdentity') = 0 AND TABLE_NAME = @tablename",
                new SqlParameter("tablename", tableName));
            //"select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME=@tablename", new SqlParameter("tablename", tableName));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using " + args.RootNamespace + ".Model;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine("using System.Data;");

            sb.AppendLine("namespace " + args.RootNamespace + ".DAL");
            sb.AppendLine("{");
            sb.AppendLine("public partial class " + tableName + "DAL");
            sb.AppendLine("{");
            sb.AppendLine("private static readonly string _ClassMsg = \"Class: " + tableName + "DAL\";"); // class message for exception
            sb.AppendLine();
            {
                sb.AppendLine("public int AddNew(" + tableName + " model, string dbConnString){");
                sb.AppendLine("string functionMsg = \"Function: AddNew(" + tableName + " model, string dbConnString)\";"); // function message for exception
                sb.AppendLine("try");
                sb.AppendLine("{");
                string[] cols = GetCols(dtNoIdentityCols);
                string[] colParams = (from col in cols select "@" + col).ToArray();
                sb.AppendLine("string sql = \"insert into " + tableName + "(" + string.Join(",", cols) + ") values(" +
                    string.Join(",", colParams) + "); select @@ROWCOUNT AS 'AffectedCount'\";"); // Show the new inserted id
                sb.AppendLine("int affectedCount = (int)SqlHelper.ExecuteScalar(sql, dbConnString");
                foreach (string col in cols)
                {
                    if (dictDefaultValueCols.ContainsKey(col))
                    {
                        sb.AppendLine(",new SqlParameter(\"" + col + "\", model." + col + " == null ? "+ dictDefaultValueCols[col] +" : model." + col + ")");
                    }
                    else
                    {
                        //, new SqlParameter("TelPhone", model.TelPhone == null ? (object)DBNull.Value : model.TelPhone)
                        sb.AppendLine(",new SqlParameter(\"" + col + "\", model." + col + " == null ? (object)DBNull.Value : model." + col + ")");
                        // sb.AppendLine(",new SqlParameter(\"" + col + "\", model." + col + ")");
                    }
                }
                sb.AppendLine(");");
                sb.AppendLine("return affectedCount;");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
                sb.AppendLine("}");
                sb.AppendLine("}");
            }
            sb.AppendLine();

            {
                sb.AppendLine("/* Used for reference");
                sb.AppendLine("public bool Update(" + tableName + " model, string dbConnString){");
                sb.AppendLine("string functionMsg = \"Function: Update(" + tableName + " model, string dbConnString)\";"); // function message for exception
                sb.AppendLine("try");
                sb.AppendLine("{");
                string[] cols = GetCols(dtNoIdentityCols);
                string[] colParams = (from col in cols select col + "=@" + col).ToArray();
                
                string whereSql = " where";
                foreach (DataRow dr in dtPrimaryKeys.Rows)
                {
                    whereSql += string.Format(" {0}=@{0} and", dr["ColName"].ToString());
                }
                whereSql = whereSql.TrimEnd('a', 'n', 'd');

                sb.AppendLine("string sql = \"update " + tableName + " set " + string.Join(",", colParams) + whereSql + "\"; ");
                sb.AppendLine("int rows = SqlHelper.ExecuteNonQuery(sql, dbConnString");
                foreach (string col in GetCols(dtCols))
                {
                    if (dictDefaultValueCols.ContainsKey(col))
                    {
                        sb.AppendLine(",new SqlParameter(\"" + col + "\", model." + col + " == null ? " + dictDefaultValueCols[col] + " : model." + col + ")");
                    }
                    else
                    {
                        sb.AppendLine(",new SqlParameter(\"" + col + "\", model." + col + " == null ? (object)DBNull.Value : model." + col + ")");
                        //sb.AppendLine(",new SqlParameter(\"" + col + "\", model." + col + ")");
                    } 
                }
                sb.AppendLine(");");
                sb.AppendLine("return rows > 0;");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
                sb.AppendLine("}");
                sb.AppendLine("}");
                sb.AppendLine("*/");
            }
            sb.AppendLine();

            {
                sb.AppendLine("private bool Delete(string whereSql, string dbConnString, SqlParameter[] parameters){");
                sb.AppendLine("string functionMsg = \"Function: Delete(string whereSql, string dbConnString, SqlParameter[] parameters)\";"); // function message for exception
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("int rows = SqlHelper.ExecuteNonQuery(\"delete from " + tableName + " where \"+ whereSql +\"\", dbConnString, parameters);"); 
                sb.AppendLine("return rows > 0;");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
                sb.AppendLine("}");
                sb.AppendLine("}");
            }
            sb.AppendLine();

            {
                sb.AppendLine("private static " + tableName + " ToModel(DataRow row){");
                sb.AppendLine("string functionMsg = \"Function: ToModel(DataRow row)\";"); // function message for exception
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine(tableName + " model = new " + tableName + "();");
                foreach (DataRow row in dtCols.Rows)
                {
                    string colName = Convert.ToString(row["Column_Name"]);
                    string dataType = Convert.ToString(row["Data_Type"]);
                    Type netType = GetDotNetTypeByDBType(dataType);
                    string netTypeName;

                    // Convert nullable value type
                    if (netType.IsValueType)
                    {
                        netTypeName = netType.ToString() + "?";
                    }
                    else
                    {
                        netTypeName = netType.ToString();
                    }
                    // model.Number = row.IsNull("Number") ? null : (System.Int32?)ConvertUtility.ToInt(row["Number"]);
                    // model.Number = row.IsNull("Number") ? (System.Int32?)null : ConvertUtility.ToInt(row["Number"]);
                    // The second one is more efficient than the fisrt one, cuz null is rare.
                    // If get a DataTable from a .csv file, the value maybe "123", to cannot convert to int, should use: ConvertUtility.ToInt()
                    sb.AppendLine("model." + colName + " = row.IsNull(\"" + colName + "\")?null:(" + netTypeName + ")row[\"" + colName + "\"];");
                }
                sb.AppendLine("return model;");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
                sb.AppendLine("}");
                sb.AppendLine("}");
            }
            sb.AppendLine();

            {
                sb.AppendLine("private " + tableName + " Get(string whereSql, string dbConnString, SqlParameter[] parameters){");
                sb.AppendLine("string functionMsg = \"Function: Get(string whereSql, string dbConnString,  SqlParameter[] parameters)\";"); // function message for exception
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("DataTable dt = SqlHelper.ExecuteDataTable(\"select * from " + tableName + " (nolock) where \"+ whereSql +\"\", dbConnString, parameters);"); 
                sb.AppendLine("if (dt.Rows.Count > 1)");
                sb.AppendLine("{throw new Exception(\"more than 1 row was found\");}");
                sb.AppendLine("if (dt.Rows.Count <= 0){return null;}");
                sb.AppendLine("DataRow row = dt.Rows[0];");
                sb.AppendLine(tableName + " model = ToModel(row);");

                sb.AppendLine("return model;");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
                sb.AppendLine("}");
                sb.AppendLine("}");
            }
            sb.AppendLine();

            {
                sb.AppendLine("public List<" + tableName + "> ListAll(string dbConnString){");
                sb.AppendLine("string functionMsg = \"Function: ListAll(string dbConnString)\";"); // function message for exception
                sb.AppendLine("try");
                sb.AppendLine("{");
                sb.AppendLine("List<" + tableName + "> list = new List<" + tableName + ">();");
                sb.AppendLine("DataTable dt = SqlHelper.ExecuteDataTable(\"select * from " + tableName + " (nolock) \", dbConnString);");
                sb.AppendLine("foreach (DataRow row in dt.Rows){");
                sb.AppendLine("list.Add(ToModel(row));}");
                sb.AppendLine("return list;");
                sb.AppendLine("}");
                sb.AppendLine("catch (Exception ex)");
                sb.AppendLine("{");
                sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
                sb.AppendLine("}");
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            sb.AppendLine("}");
            string dalDir = Path.Combine(args.OutputDir, "DAL");
            string dalFile = Path.Combine(dalDir, tableName + "DAL.cs");
            Directory.CreateDirectory(dalDir);
            File.WriteAllText(dalFile, sb.ToString());

            string dalSqlHelperFile = Path.Combine(dalDir, "SqlHelper.cs");
            File.WriteAllText(dalSqlHelperFile, GenerateSqlHelperForDAL(args.RootNamespace + ".DAL"));
        }
    }
}
