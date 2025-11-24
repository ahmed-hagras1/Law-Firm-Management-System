using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class UsersDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;

        public static bool GetUser(int userId, ref string userName, ref string password,
                                   ref bool isActive, ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Users] WHERE UserId = @userId", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            // Non-nullable columns
                            userName = (string)reader["UserName"];
                            password = (string)reader["Password"]; // Note: Reading password is poor practice
                            isActive = (bool)reader["IsActive"];
                            trackingChangesId = (reader["TrackingChangesId"] != DBNull.Value) ? (int)reader["TrackingChangesId"] : 0;

                            // Nullable columns
                            notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : string.Empty;
                        }
                    }
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return isFound;
        }
        public static DataTable GetAllUsers()
        {
            DataTable users = new DataTable();
            string query = "SELECT * FROM [dbo].[Users_View]"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // The .Fill() method opens/closes the connection automatically
                    adapter.Fill(users);
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return users;
        }
        public static int AddUser(string userName, string password, int createdBy, string notes)
        {
            string storedProcedureName = "sp_AddNewUser";
            int newUserId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    connection.Open();

                    // Use ExecuteScalar() to get the new UserId
                    object result = command.ExecuteScalar();
                    newUserId = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return -1; }
            catch (Exception) { return -1; }

            return newUserId; // Return the new ID
        }
        public static bool UpdateUser(int userId, string userName, string password, bool isActive, int lastUpdatedBy, string notes)
        {
            string storedProcedureName = "sp_UpdateUser";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@IsActive", isActive);
                    command.Parameters.AddWithValue("@LastUpdatedBy", lastUpdatedBy);

                    // Handle nullable parameter
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();

                    // Use ExecuteScalar() to get the return value (1 for success, 0 for failure)
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return (success == 1);
        }
        public static bool DeleteUser(int userId)
        {
            string storedProcedureName = "sp_DeleteUser";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();

                    // Use ExecuteScalar() to get the return value (1 for success, 0 for failure)
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return (success == 1);
        }
        static public bool IsUserExist(string username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Select Found =1 from Users where username = @username;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}