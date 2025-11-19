using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class DocumentsDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;

        public static bool GetDocument(int documentId, ref int caseId, ref string fileName,
                                       ref string filePath, ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Documents] WHERE DocumentId = @documentId", connection))
                {
                    command.Parameters.AddWithValue("@documentId", documentId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            // Non-nullable columns
                            caseId = (int)reader["CaseId"];
                            fileName = (string)reader["FileName"];
                            trackingChangesId = (int)reader["TrackingChangesId"];

                            // Nullable columns
                            filePath = (reader["FilePath"] != DBNull.Value) ? (string)reader["FilePath"] : string.Empty;
                            notes = (reader["Notes"] != DBNull.Value) ? (string)reader["Notes"] : string.Empty;
                        }
                    }
                }
            }
            catch (SqlException) { return false; }
            catch (Exception) { return false; }

            return isFound;
        }

        /// <summary>
        /// Gets a DataTable of all documents from the 'Documents_View'.
        /// </summary>
        public static DataTable GetAllDocuments()
        {
            DataTable documents = new DataTable();
            string query = "SELECT * FROM [dbo].[Documents_View]"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // The .Fill() method opens/closes the connection automatically
                    adapter.Fill(documents);
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return documents;
        }
        public static DataTable GetAllDocumentsForSpecificCase(int caseId)
        {
            DataTable documents = new DataTable();
            string query = "SELECT * FROM [dbo].[Documents_View] Where caseId = @caseId"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@caseId", caseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // The .Fill() method opens/closes the connection automatically
                        adapter.Fill(documents);
                    }
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return documents;
        }
        public static int AddDocument(int caseId, string fileName, string filePath, string notes, int createdBy)
        {
            string storedProcedureName = "sp_AddDocument";
            int newDocumentId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@FilePath", string.IsNullOrEmpty(filePath) ? (object)DBNull.Value : filePath);
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();

                    // Use ExecuteScalar() to get the new DocumentId
                    object result = command.ExecuteScalar();
                    newDocumentId = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return -1; }
            catch (Exception) { return -1; }

            return newDocumentId; // Return the new ID
        }
        public static bool UpdateDocument(int documentId, int caseId, string fileName, string filePath, string notes, int lastUpdatedBy)
        {
            string storedProcedureName = "sp_UpdateDocument";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@DocumentId", documentId);
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@LastUpdatedBy", lastUpdatedBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@FilePath", string.IsNullOrEmpty(filePath) ? (object)DBNull.Value : filePath);
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
        public static bool DeleteDocument(int documentId)
        {
            string storedProcedureName = "sp_DeleteDocument";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DocumentId", documentId);
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