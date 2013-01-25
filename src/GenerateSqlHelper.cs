using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeLayersCodeGenerator
{
    partial class GeneratorUtility
    {
        /// <summary>
        /// Generate SqlHelper.cs For DAL
        /// </summary>
        /// <returns></returns>
        private static string GenerateSqlHelperForDAL(string nameSpace)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Configuration;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendLine("using System.Data;");

            sb.AppendLine("namespace " + nameSpace);
            sb.AppendLine("{");
            sb.AppendLine("    class SqlHelper");
            sb.AppendLine("    {");
            //sb.AppendLine("        public static readonly string connstr = ConfigurationManager.ConnectionStrings[\"DbConnection\"].ConnectionString;");

            //sb.AppendLine();
            sb.AppendLine("        public static int ExecuteNonQuery(string cmdText, string dbConnString, params SqlParameter[] parameters)");
            sb.AppendLine("        {");
            sb.AppendLine("            using (SqlConnection conn = new SqlConnection(dbConnString))");
            sb.AppendLine("            {");
            sb.AppendLine("                conn.Open();");
            sb.AppendLine("                using (SqlCommand cmd = conn.CreateCommand())");
            sb.AppendLine("                {");
            sb.AppendLine("                    cmd.CommandText = cmdText;");
            sb.AppendLine("                    cmd.Parameters.AddRange(parameters);");
            sb.AppendLine("                    return cmd.ExecuteNonQuery();");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        public static object ExecuteScalar(string cmdText, string dbConnString, params SqlParameter[] parameters)");
            sb.AppendLine("        {");
            sb.AppendLine("            using (SqlConnection conn = new SqlConnection(dbConnString))");
            sb.AppendLine("            {");
            sb.AppendLine("                conn.Open();");
            sb.AppendLine("                using (SqlCommand cmd = conn.CreateCommand())");
            sb.AppendLine("                {");
            sb.AppendLine("                    cmd.CommandText = cmdText;");
            sb.AppendLine("                    cmd.Parameters.AddRange(parameters);");
            sb.AppendLine("                    return cmd.ExecuteScalar();");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        public static DataTable ExecuteDataTable(string cmdText, string dbConnString, params SqlParameter[] parameters)");
            sb.AppendLine("        {");
            sb.AppendLine("            using (SqlConnection conn = new SqlConnection(dbConnString))");
            sb.AppendLine("            {");
            sb.AppendLine("                conn.Open();");
            sb.AppendLine("                using (SqlCommand cmd = conn.CreateCommand())");
            sb.AppendLine("                {");
            sb.AppendLine("                    cmd.CommandText = cmdText;");
            sb.AppendLine("                    cmd.Parameters.AddRange(parameters);");
            sb.AppendLine("                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))");
            sb.AppendLine("                    {");
            sb.AppendLine("                        DataTable dt = new DataTable();");
            sb.AppendLine("                        adapter.Fill(dt);");
            sb.AppendLine("                        return dt;");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        public static SqlDataReader ExecuteDataReader(string cmdText, string dbConnString, params SqlParameter[] parameters)");
            sb.AppendLine("        {");
            sb.AppendLine("            SqlConnection conn = new SqlConnection(dbConnString);");
            sb.AppendLine("            conn.Open();");
            sb.AppendLine("            using (SqlCommand cmd = conn.CreateCommand())");
            sb.AppendLine("            {");
            sb.AppendLine("                cmd.CommandText = cmdText;");
            sb.AppendLine("                cmd.Parameters.AddRange(parameters);");
            sb.AppendLine("                return cmd.ExecuteReader(CommandBehavior.CloseConnection);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        public int ExecuteStoredProcedureNonQuery(string spName, string dbConnString, params SqlParameter[] parameters)");
            sb.AppendLine("        {");
            sb.AppendLine("            SqlConnection conn = new SqlConnection(dbConnString);");
            sb.AppendLine("            conn.Open();");
            sb.AppendLine("            using (SqlCommand cmd = conn.CreateCommand())");
            sb.AppendLine("            {");
            sb.AppendLine("                cmd.CommandText = spName;");
            sb.AppendLine("                cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("                cmd.Parameters.AddRange(parameters);");
            sb.AppendLine("                int result = cmd.ExecuteNonQuery();"); 
            sb.AppendLine("                return result;");
            sb.AppendLine("            }"); 
            sb.AppendLine("        }");

            sb.AppendLine();
            sb.AppendLine("        public DataTable ExecuteStoredProcedureDataTable(string spName, string dbConnString, params SqlParameter[] parameters)");
            sb.AppendLine("        {");
            sb.AppendLine("            DataTable dt = new DataTable();");
            sb.AppendLine("            SqlConnection conn = new SqlConnection(dbConnString);");
            sb.AppendLine("            conn.Open();");
            sb.AppendLine("            using (SqlCommand cmd = conn.CreateCommand())");
            sb.AppendLine("            {");
            sb.AppendLine("                cmd.CommandText = spName;");
            sb.AppendLine("                cmd.CommandType = CommandType.StoredProcedure;");
            sb.AppendLine("                cmd.Parameters.AddRange(parameters);");
            sb.AppendLine("                SqlDataAdapter da = new SqlDataAdapter(cmd);"); 
            sb.AppendLine("                da.Fill(dt);");
            sb.AppendLine("                return dt;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");

            sb.AppendLine("    }");
            sb.AppendLine("}");
             
            return sb.ToString();
        }
    }
}
