using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LawFirmManagementSystem.Data
{
    internal class DataAccessSettings
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}
