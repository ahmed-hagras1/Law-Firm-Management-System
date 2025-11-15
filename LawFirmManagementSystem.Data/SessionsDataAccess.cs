using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class SessionsDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;
        public static bool GetSession(int sessionId, ref int caseId, ref DateTime date, ref int rollNumber,
                                      ref string court, ref int lawyerId, ref string requests, ref string decision,
                                      ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Sessions] WHERE SessionId = @sessionId", connection))
                {
                    command.Parameters.AddWithValue("@sessionId", sessionId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            // Non-nullable columns
                            caseId = (int)reader["CaseId"];
                            date = (DateTime)reader["Date"];
                            court = (string)reader["Court"];
                            lawyerId = (int)reader["LawyerId"];
                            trackingChangesId = (int)reader["TrackingChangesId"];

                            // Nullable columns
                            rollNumber = (reader["RollNumber"] != DBNull.Value) ? (int)reader["RollNumber"] : 0; // Default to 0
                            requests = (reader["Requests"] != DBNull.Value) ? (string)reader["Requests"] : string.Empty;
                            decision = (reader["Decision"] != DBNull.Value) ? (string)reader["Decision"] : string.Empty;
                            notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : string.Empty;
                        }
                    }
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return isFound;
        }
        public static DataTable GetAllSessions()
        {
            DataTable sessions = new DataTable();
            string query = "SELECT * FROM [dbo].[Sessions_View]"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // The .Fill() method opens/closes the connection automatically
                    adapter.Fill(sessions);
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return sessions;
        }
        public static int AddSession(int caseId, DateTime date, int rollNumber, string court,
                                   int lawyerId, string requests, string decision,
                                   string notes, int createdBy)
        {
            string storedProcedureName = "sp_AddSession";
            int newSessionId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Court", court);
                    command.Parameters.AddWithValue("@LawyerId", lawyerId);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@RollNumber", (rollNumber == 0) ? (object)DBNull.Value : rollNumber); // Assuming 0 means null
                    command.Parameters.AddWithValue("@Requests", string.IsNullOrEmpty(requests) ? (object)DBNull.Value : requests);
                    command.Parameters.AddWithValue("@Decision", string.IsNullOrEmpty(decision) ? (object)DBNull.Value : decision);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();

                    // Use ExecuteScalar() to get the new SessionId
                    object result = command.ExecuteScalar();
                    newSessionId = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return -1; }
            catch (Exception) { return -1; }

            return newSessionId; // Return the new ID
        }
        public static bool UpdateSession(int sessionId, int caseId, DateTime date, int rollNumber, string court,
                                       int lawyerId, string requests, string decision,
                                       string notes, int lastUpdatedBy)
        {
            string storedProcedureName = "sp_UpdateSession";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@SessionId", sessionId);
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Court", court);
                    command.Parameters.AddWithValue("@LawyerId", lawyerId);
                    command.Parameters.AddWithValue("@LastUpdatedBy", lastUpdatedBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@RollNumber", (rollNumber == 0) ? (object)DBNull.Value : rollNumber);
                    command.Parameters.AddWithValue("@Requests", string.IsNullOrEmpty(requests) ? (object)DBNull.Value : requests);
                    command.Parameters.AddWithValue("@Decision", string.IsNullOrEmpty(decision) ? (object)DBNull.Value : decision);
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
        public static bool DeleteSession(int sessionId)
        {
            string storedProcedureName = "sp_DeleteSession";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SessionId", sessionId);
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
    }
}