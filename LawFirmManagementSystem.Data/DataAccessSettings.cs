using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirmManagementSystem.Data
{
    internal class DataAccessSettings
    {

        static public string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}
