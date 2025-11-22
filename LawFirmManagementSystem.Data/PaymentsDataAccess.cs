using System;
using System.Data;
using System.Data.SqlClient;

namespace LawFirmManagementSystem.Data
{
    public static class PaymentsDataAccess
    {
        // Get the connection string from the central settings class
        private readonly static string connectionString = DataAccessSettings.connectionString;

        public static bool GetPayment(int paymentId, ref int invoiceId, ref decimal amount,
                                      ref int trackingChangesId, ref string notes)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Payments] WHERE PaymentId = @paymentId", connection))
                {
                    command.Parameters.AddWithValue("@paymentId", paymentId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            // Non-nullable columns
                            invoiceId = (int)reader["InvoiceId"];
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
        public static DataTable GetAllPayments()
        {
            DataTable payments = new DataTable();
            string query = "SELECT * FROM [dbo].[Payments_View]"; // Assumes this view exists

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // The .Fill() method opens/closes the connection automatically
                    adapter.Fill(payments);
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return payments;
        }
        public static DataTable GetAllPaymentsForSpecificInvoice(int invoiceId)
        {
            DataTable payments = new DataTable();
            string query = "SELECT * FROM [dbo].[Payments_View] WHERE InvoiceId = @invoiceId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@invoiceId", invoiceId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(payments);
                    }
                }
            }
            catch (SqlException) { return new DataTable(); }
            catch (Exception) { return new DataTable(); }

            return payments;
        }
        public static int AddPayment(int invoiceId, decimal amount, string notes, int createdBy)
        {
            string storedProcedureName = "sp_AddPayment";
            int newPaymentId = -1; // Default to -1 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);

                    // Add nullable parameters
                    command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(notes) ? (object)DBNull.Value : notes);

                    connection.Open();

                    // Use ExecuteScalar() to get the new PaymentId
                    object result = command.ExecuteScalar();
                    newPaymentId = Convert.ToInt32(result);
                }
            }
            catch (SqlException) { return -1; }
            catch (Exception) { return -1; }

            return newPaymentId; // Return the new ID
        }
        public static bool UpdatePayment(int paymentId, int invoiceId, decimal amount, string notes, int lastUpdatedBy)
        {
            string storedProcedureName = "sp_UpdatePayment";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add all parameters
                    command.Parameters.AddWithValue("@PaymentId", paymentId);
                    command.Parameters.AddWithValue("@InvoiceId", invoiceId);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@LastUpdatedBy", lastUpdatedBy);

                    // Add nullable parameters
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
        public static bool DeletePayment(int paymentId)
        {
            string storedProcedureName = "sp_DeletePayment";
            int success = 0; // Default to 0 (failure)

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PaymentId", paymentId);
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