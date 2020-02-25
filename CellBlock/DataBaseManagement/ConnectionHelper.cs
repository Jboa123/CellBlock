using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CellBlockLibrary
{
    public static class ConnectionHelper
    {

        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
