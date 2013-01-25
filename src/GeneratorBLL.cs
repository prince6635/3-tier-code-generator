using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace ThreeLayersCodeGenerator
{
    partial class GeneratorUtility
    {
        /// <summary>
        /// Generate BLL layer
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="args"></param>
        public void GenerateBLL(GeneratorArgs args)
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using " + args.RootNamespace + ".Model;");
            sb.AppendLine("using " + args.RootNamespace + ".DAL;");

            sb.AppendLine("namespace " + args.RootNamespace + ".BLL");
            sb.AppendLine("{");
            sb.AppendLine("public partial class " + tableName + "BLL");

            sb.AppendLine("{");
            sb.AppendLine("private static readonly string _ClassMsg = \"Class: " + tableName + "BLL\";"); // class message for exception
            sb.AppendLine();

            sb.AppendLine("public int AddNew(" + tableName + " model, string dbConnString){");
            sb.AppendLine("string functionMsg = \"Function: AddNew(" + tableName + " model, string dbConnString)\";"); // function message for exception
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("return new " + tableName + "DAL().AddNew(model, dbConnString);}"); 
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine();

            /*sb.AppendLine("public bool Delete(string whereSql, string dbConnString){");
            sb.AppendLine("string functionMsg = \"Function: Delete(string whereSql, string dbConnString)\";"); // function message for exception
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("return new " + tableName + "DAL().Delete(whereSql, dbConnString);}");
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine();*/

            /*sb.AppendLine("public bool Update(" + tableName + " model, string dbConnString){");
            sb.AppendLine("string functionMsg = \"Function: Update(" + tableName + " model, string dbConnString)\";"); // function message for exception
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("return new " + tableName + "DAL().Update(model, dbConnString);}");
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine();*/

            /*sb.AppendLine("public " + tableName + " Get(string whereSql, string dbConnString){");
            sb.AppendLine("string functionMsg = \"Function: Get(string whereSql, string dbConnString)\";"); // function message for exception
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("return new " + tableName + "DAL().Get(whereSql, dbConnString);}");
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
            sb.AppendLine("}");
            sb.AppendLine("}");
            sb.AppendLine();*/

            sb.AppendLine("public List<" + tableName + "> ListAll(string dbConnString){");
            sb.AppendLine("string functionMsg = \"Function: ListAll(string dbConnString)\";"); // function message for exception
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("return new " + tableName + "DAL().ListAll(dbConnString);}"); 
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("throw new Exception(string.Format(\"Exception: {0}{1}{2}{3}{4}{5}\", ex.Message, Environment.NewLine, _ClassMsg, Environment.NewLine, functionMsg, Environment.NewLine));");
            sb.AppendLine("}");
            sb.AppendLine("}");

            sb.AppendLine("}");
            sb.AppendLine("}");

            string bllDir = Path.Combine(args.OutputDir, "BLL");
            string bllFile = Path.Combine(bllDir, tableName + "BLL.cs");
            Directory.CreateDirectory(bllDir);
            File.WriteAllText(bllFile, sb.ToString());
        }
    }
}
