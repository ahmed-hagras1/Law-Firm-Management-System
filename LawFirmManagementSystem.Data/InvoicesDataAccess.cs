using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class InvoicesDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;

        public static bool GetInvoice(int invoiceId, ref int caseId, ref decimal amount, ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Invoices] WHERE InvoiceId = @invoiceId", connection))
                {
                    command.Parameters.AddWithValue("@invoiceId", invoiceId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            // Non-nullable columns
                            caseId = (int)reader["CaseId"];
                            amount = (decimal)reader["Amount"]; // SQL smallmoney maps to C# decimal
                            trackingChangesId = (int)reader["TrackingChangesId"];

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

        public static DataTable GetAllInvoices()
        {
            DataTable invoices = new DataTable();
            string query = "SELECT * FROM [dbo].[Invoices_View]"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // The .Fill() method opens/closes the connection automatically
                    adapter.Fill(invoices);
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return invoices;
        }
        public static DataTable GetAllInvoicesForSpecificCase(int caseId)
        {
            DataTable invoices = new DataTable();
            string query = "SELECT * FROM [dbo].[Invoices_View] Where CaseId = @caseId"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@caseId", caseId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // The .Fill() method opens/closes the connection automatically
                        adapter.Fill(invoices);
                    }
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return invoices;
        }
        public static int AddInvoice(int caseId, decimal amount, string notes, int createdBy)
        {
            string storedProcedureName = "sp_AddInvoice";
            int newInvoiceId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    // Handle nullable parameter
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();

                    // Use ExecuteScalar() to get the new InvoiceId
                    object result = command.ExecuteScalar();
                    newInvoiceId = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return -1; }
            catch (Exception) { return -1; }

            return newInvoiceId; // Return the new ID
        }
        public static bool UpdateInvoice(int invoiceId, int caseId, decimal amount, string notes, int lastUpdatedBy)
        {
            string storedProcedureName = "sp_UpdateInvoice";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@Amount", amount);
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
        public static bool DeleteInvoice(int invoiceId)
        {
            string storedProcedureName = "sp_DeleteInvoice";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@InvoiceId", invoiceId);
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