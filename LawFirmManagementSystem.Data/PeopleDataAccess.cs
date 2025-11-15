using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LawFirmManagementSystem.Data
{
    public static class PeopleDataAccess
    {
        private readonly static string connectionString = DataAccessSettings.connectionString;
        public static bool GetPerson(int personId, ref string fullName, ref string phone, ref string address)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"Select FullName, Phone, Address from People 
                                     Where PersonId = @personId;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@personId", personId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        fullName = (string)reader["FullName"];
                        phone = (string)reader["Phone"];
                        address = (string)reader["Address"];

                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }
            }

            return isFound;
        }
    }
}
