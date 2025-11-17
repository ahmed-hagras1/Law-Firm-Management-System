using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class CasesDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;

        public static bool GetCase(int caseId, ref string caseNumber, ref string title, ref string court,
            ref string clientName, ref string clientStatus, ref string clientAddress, ref string clientPhone,
            ref string opponentName, ref string opponentStatus, ref string opponentAddress, ref string opponentPhone,
            ref int clientId, ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Cases] WHERE CaseId = @caseId", connection))
                {
                    command.Parameters.AddWithValue("@caseId", caseId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // --- Handle Non-Nullable Columns ---
                            clientName = (string)reader["ClientName"];
                            clientId = (int)reader["ClientId"];
                            trackingChangesId = (int)reader["TrackingChangesId"];

                            // --- Handle Nullable Columns ---
                            caseNumber = (reader["CaseNumber"] != DBNull.Value) ? (string)reader["CaseNumber"] : string.Empty;
                            title = (reader["Title"] != DBNull.Value) ? (string)reader["Title"] : string.Empty;
                            court = (reader["Court"] != DBNull.Value) ? (string)reader["Court"] : string.Empty;
                            clientStatus = (reader["ClientStatus"] != DBNull.Value) ? (string)reader["ClientStatus"] : string.Empty;
                            clientAddress = (reader["ClientAddress"] != DBNull.Value) ? (string)reader["ClientAddress"] : string.Empty;
                            clientPhone = (reader["ClientPhone"] != DBNull.Value) ? (string)reader["ClientPhone"] : string.Empty;
                            opponentName = (reader["OpponentName"] != DBNull.Value) ? (string)reader["OpponentName"] : string.Empty;
                            opponentStatus = (reader["OpponentStatus"] != DBNull.Value) ? (string)reader["OpponentStatus"] : string.Empty;
                            opponentAddress = (reader["OpponentAddress"] != DBNull.Value) ? (string)reader["OpponentAddress"] : string.Empty;
                            opponentPhone = (reader["OpponentPhone"] != DBNull.Value) ? (string)reader["OpponentPhone"] : string.Empty;
                            notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : string.Empty;

                            isFound = true;
                        }
                    }
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return isFound;
        }

        public static DataTable GetAllCases()
        {
            DataTable cases = new DataTable();
            string query = "SELECT * FROM [dbo].[Cases_View]"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(cases);
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return cases;
        }
        public static DataTable GetAllCasesForSpecificClient(int clientId)
        {
            DataTable cases = new DataTable();
            string query = "SELECT * FROM [dbo].[Cases_View] Where ClientId = @clientId"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@clientId", clientId);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(cases);
                    }
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return cases;
        }
        public static int AddCase(string caseNumber, string title, string court,
            string clientName, string clientStatus, string clientAddress, string clientPhone,
            string opponentName, string opponentStatus, string opponentAddress, string opponentPhone,
            int clientId, string notes, int createdBy)
        {
            string storedProcedureName = "sp_AddCase";
            int newCaseId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@ClientName", clientName);
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@CaseNumber", string.IsNullOrEmpty(caseNumber) ? (object)DBNull.Value : caseNumber);
                    command.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(title) ? (object)DBNull.Value : title);
                    command.Parameters.AddWithValue("@Court", string.IsNullOrEmpty(court) ? (object)DBNull.Value : court);
                    command.Parameters.AddWithValue("@ClientStatus", string.IsNullOrEmpty(clientStatus) ? (object)DBNull.Value : clientStatus);
                    command.Parameters.AddWithValue("@ClientAddress", string.IsNullOrEmpty(clientAddress) ? (object)DBNull.Value : clientAddress);
                    command.Parameters.AddWithValue("@ClientPhone", string.IsNullOrEmpty(clientPhone) ? (object)DBNull.Value : clientPhone);
                    command.Parameters.AddWithValue("@OpponentName", string.IsNullOrEmpty(opponentName) ? (object)DBNull.Value : opponentName);
                    command.Parameters.AddWithValue("@OpponentStatus", string.IsNullOrEmpty(opponentStatus) ? (object)DBNull.Value : opponentStatus);
                    command.Parameters.AddWithValue("@OpponentAddress", string.IsNullOrEmpty(opponentAddress) ? (object)DBNull.Value : opponentAddress);
                    command.Parameters.AddWithValue("@OpponentPhone", string.IsNullOrEmpty(opponentPhone) ? (object)DBNull.Value : opponentPhone);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    newCaseId = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return -1; }
            catch (Exception) { return -1; }

            return newCaseId; // Return the new ID
        }
        public static bool UpdateCase(int caseId, string caseNumber, string title, string court,
            string clientName, string clientStatus, string clientAddress, string clientPhone,
            string opponentName, string opponentStatus, string opponentAddress, string opponentPhone,
            int clientId, string notes, int lastUpdatedBy)
        {
            string storedProcedureName = "sp_UpdateCase";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@ClientName", clientName);
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@LastUpdatedBy", lastUpdatedBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@CaseNumber", string.IsNullOrEmpty(caseNumber) ? (object)DBNull.Value : caseNumber);
                    command.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(title) ? (object)DBNull.Value : title);
                    command.Parameters.AddWithValue("@Court", string.IsNullOrEmpty(court) ? (object)DBNull.Value : court);
                    command.Parameters.AddWithValue("@ClientStatus", string.IsNullOrEmpty(clientStatus) ? (object)DBNull.Value : clientStatus);
                    command.Parameters.AddWithValue("@ClientAddress", string.IsNullOrEmpty(clientAddress) ? (object)DBNull.Value : clientAddress);
                    command.Parameters.AddWithValue("@ClientPhone", string.IsNullOrEmpty(clientPhone) ? (object)DBNull.Value : clientPhone);
                    command.Parameters.AddWithValue("@OpponentName", string.IsNullOrEmpty(opponentName) ? (object)DBNull.Value : opponentName);
                    command.Parameters.AddWithValue("@OpponentStatus", string.IsNullOrEmpty(opponentStatus) ? (object)DBNull.Value : opponentStatus);
                    command.Parameters.AddWithValue("@OpponentAddress", string.IsNullOrEmpty(opponentAddress) ? (object)DBNull.Value : opponentAddress);
                    command.Parameters.AddWithValue("@OpponentPhone", string.IsNullOrEmpty(opponentPhone) ? (object)DBNull.Value : opponentPhone);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    success = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return (success == 1);
        }
        public static bool DeleteCase(int caseId)
        {
            string storedProcedureName = "sp_DeleteCase";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    connection.Open();

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