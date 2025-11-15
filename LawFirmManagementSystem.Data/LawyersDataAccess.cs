using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class LawyersDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;

        public static bool GetLawyer(int lawyerId, ref int personId, ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("SELECT PersonId, TrackingChangesId, Notes FROM [dbo].[Lawyers] WHERE LawyerId = @lawyerId", connection))
                    {
                        command.Parameters.AddWithValue("@lawyerId", lawyerId);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personId = (int)reader["PersonId"];
                                trackingChangesId = (int)reader["TrackingChangesId"];

                                // Handle potential NULL for Notes
                                if (reader["Notes"] != DBNull.Value)
                                {
                                    notes = (string)reader["Notes"];
                                }
                                else
                                {
                                    notes = string.Empty; // or null, based on your preference
                                }
                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (SqlException)
            {
                // On error, return false.
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            return isFound;
        }
        public static DataTable GetAllLawyers()
        {
            DataTable lawyers = new DataTable();
            string query = "SELECT * FROM [dbo].[Lawyers_View]";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // The .Fill() method opens/closes the connection automatically
                    adapter.Fill(lawyers);
                }
            }
            catch (SqlException)
            {
                return new DataTable(); // Return empty table on error
            }
            catch (Exception)
            {
                return new DataTable(); // Return empty table on error
            }

            return lawyers;
        }
        public static int AddLawyer(string fullName, string phone, string address, int createdBy, string notes)
        {
            string storedProcedureName = "sp_AddLawyer";
            int newLawyerId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    // Handle nullable parameter
                    if (string.IsNullOrEmpty(notes))
                    {
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Notes", notes);
                    }

                    connection.Open();

                    // Use ExecuteScalar() to get the new LawyerId
                    object result = command.ExecuteScalar();
                    newLawyerId = Convert.ToInt32(result);
                }
            }
            catch (SqlException)
            {
                return -1; // On SQL error, return -1
            }
            catch (Exception)
            {
                return -1; // On any other C# error, return -1
            }

            return newLawyerId; // Return the new ID
        }

        public static bool UpdateLawyer(int lawyerId, string fullName, string phone, string address, int lastUpdatedBy, string notes)
        {
            string storedProcedureName = "sp_UpdateLawyer";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@LawyerId", lawyerId);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@LastUpdatedBy", lastUpdatedBy);

                    // Handle nullable parameter
                    if (string.IsNullOrEmpty(notes))
                    {
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Notes", notes);
                    }

                    connection.Open();

                    // Use ExecuteScalar() to get the return value (1 for success, 0 for failure)
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

            return (success == 1);
        }
        public static bool DeleteLawyer(int lawyerId)
        {
            string storedProcedureName = "sp_DeleteLawyer";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LawyerId", lawyerId);
                    connection.Open();

                    // Use ExecuteScalar() to get the return value (1 for success, 0 for failure)
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

            return (success == 1);
        }
    }
}
