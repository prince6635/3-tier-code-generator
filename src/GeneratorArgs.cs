using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeLayersCodeGenerator
{
    class GeneratorArgs
    {
        public string RootNamespace { get; set; }
        public string OutputDir { get; set; }
        public string ConnectionString { get; set; }
    }

    class CommonArgs
    {
        public const string InitialConnString = "Data Source=TestServer;Initial Catalog=TestDB;Integrated security=SSPI; Connect Timeout=1000";
        public const string ConnStringTemplate = "Data Source={0};Initial Catalog={1};Integrated security=SSPI; Connect Timeout=1000";
    }
}
