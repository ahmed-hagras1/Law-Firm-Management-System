using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LawFirmManagementSystem.Data
{
    public static class ClientsDataAccess
    {
        private readonly static string connectionString = DataAccessSettings.connectionString;
        public static bool GetClient(int clientId, ref int personId, ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Clients] WHERE ClientId = @clientId", connection))
                {
                    command.Parameters.AddWithValue("@clientId", clientId);
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
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            return isFound;
        }
        public static DataTable GetAllClients()
        {

            DataTable clients = new DataTable();

            string query = "SELECT * FROM [dbo].[Clients_View]";

            try
            {
                // Use 'using' blocks to ensure connections are closed
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        //  Use a SqlDataAdapter to automatically fill the DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // No need to manually open/close the connection.
                            // The .Fill() method does it for you.
                            adapter.Fill(clients);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }

            // Return the filled DataTable
            return clients;
        }
        public static int AddClient(string fullName, string phone, string address, int createdBy, string notes)
        {
            string storedProcedureName = "sp_AddClient";
            int newClientId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
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

                        // Use ExecuteScalar() because the stored procedure 
                        // returns a single value (the new ClientId).
                        object result = command.ExecuteScalar();

                        // Convert the result (which is a decimal or long) to int
                        newClientId = Convert.ToInt32(result);
                    }
                }
            }
            catch (SqlException)
            {
                // On SQL error, return -1 as requested.
                return -1;
            }
            catch (Exception)
            {
                // On any other C# error, return -1 as requested.
                return -1;
            }

            return newClientId; // Return the new ID (or -1 if it failed)
        }
        public static bool UpdateClient(int clientId, string fullName, string phone, string address, int lastUpdatedBy, string notes)
        {
            string storedProcedureName = "sp_UpdateClient";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@ClientId", clientId);
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

                    // Use ExecuteScalar() because the stored procedure 
                    // returns a single value (1 for success, 0 for failure).
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException)
            {
                // Don't throw, just return false.
                // The stored procedure is designed to handle errors and return 0.
                return false;
            }
            catch (Exception)
            {
                // Don't throw, just return false.
                return false;
            }

            // Return true if success == 1, false otherwise
            return (success == 1);
        }
        public static bool DeleteClient(int clientId)
        {
            string storedProcedureName = "sp_DeleteClient";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@ClientId", clientId);

                    connection.Open();

                    // Use ExecuteScalar() because the stored procedure 
                    // returns a single value (1 for success, 0 for failure).
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException)
            {
                // Don't throw, just return false.
                // The stored procedure is designed to handle errors and return 0.
                return false;
            }
            catch (Exception)
            {
                // Don't throw, just return false.
                return false;
            }

            // Return true if success == 1, false otherwise
            return (success == 1);
        }

    }
}
