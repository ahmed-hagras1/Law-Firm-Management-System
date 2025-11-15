using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirmManagementSystem.Data
{
    public static class TrackingChangesDataAccess
    {
        private readonly static string connectionString = DataAccessSettings.connectionString;
        public static bool GetTrackingChanges(int trackingChangesId, ref int createdByUserId, ref DateTime createdDate,
                                              ref int lastUpdatedBy, ref DateTime lastUpdatedDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("Select * From TrackingChanges Where TrackingId = @trackingChangesId", connection))
                {
                    command.Parameters.AddWithValue("@trackingChangesId", trackingChangesId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // --- Corrected Read Logic ---
                            createdByUserId = (int)reader["CreatedByUserId"];
                            createdDate = (DateTime)reader["CreatedDate"];

                            // --- Handle potential NULL values ---
                            if (reader["LastUpdatedBy"] != DBNull.Value)
                            {
                                lastUpdatedBy = (int)reader["LastUpdatedBy"];
                            }
                            else
                            {
                                lastUpdatedBy = 0; // Or -1, as 0 might be a valid UserId
                            }

                            if (reader["LastUpdatedDate"] != DBNull.Value)
                            {
                                lastUpdatedDate = (DateTime)reader["LastUpdatedDate"];
                            }
                            else
                            {
                                lastUpdatedDate = DateTime.MinValue; // Default value for DateTime
                            }

                            isFound = true;
                            // --- End Corrected Logic ---
                        }
                    }
                }
            }
            catch (SqlException)
            {
                // Throw the SQL error for the UI to handle.
                throw;
            }
            catch (Exception)
            {
                // Throw any other C# error.
                throw;
            }

            return isFound;
        }
    }
}
