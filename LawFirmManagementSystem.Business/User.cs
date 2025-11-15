using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Data;

namespace LawFirmManagementSystem_Business
{
    public class User
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        // --- User Properties ---
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int TrackingChangesId { get; set; }
        public TrackingChanges TrackingChangesInfo
        {
            get { return TrackingChanges.GetTrackingChanges(TrackingChangesId); }
        }
        public string Notes { get; set; }

        // Default constructor for AddNewMode
        public User()
        {
            this.UserId = 0;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.IsActive = false;
            this.TrackingChangesId = 0;
            this.Notes = string.Empty;
            this.mode = enMode.AddNewMode;
        }

        // Private constructor for UpdateMode
        private User(int userId, string userName, string password, bool isActive, int trackingChangesId, string notes)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.TrackingChangesId = trackingChangesId;
            this.Notes = notes;
            this.mode = enMode.UpdateMode;
        }
        public static User GetUser(int userId)
        {
            // Declare all ref parameters
            string userName = "", password = "", notes = "";
            bool isActive = false;
            int trackingChangesId = 0;

            if (UsersDataAccess.GetUser(userId, ref userName, ref password, ref isActive, ref trackingChangesId, ref notes))
            {
                return new User(userId, userName, password, isActive, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new User();
        }
        public static DataTable GetAllUsers()
        {
            return UsersDataAccess.GetAllUsers();
        }
        public static bool DeleteUser(int userId) => UsersDataAccess.DeleteUser(userId);
        private bool _UpdateUser()
        {
            // This relies on TrackingChangesInfo.LastUpdatedBy being available
            return UsersDataAccess.UpdateUser(
                this.UserId,
                this.UserName,
                this.Password,
                this.IsActive,
                this.TrackingChangesInfo.LastUpdatedBy, // From linked object
                this.Notes
            );
        }

        private bool _AddNewUser()
        {
            // This relies on TrackingChangesInfo.CreatedBy being populated *before* calling Save
            this.UserId = UsersDataAccess.AddUser(
                this.UserName,
                this.Password,
                this.TrackingChangesInfo.CreatedBy, // From linked object
                this.Notes
            );

            return (this.UserId > 0);
        }
        public bool SaveUser()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateUser();

                case enMode.AddNewMode:
                    if (_AddNewUser())
                    {
                        // If add new is successful, switch to UpdateMode
                        mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }
    }
}