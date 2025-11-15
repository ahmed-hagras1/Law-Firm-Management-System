using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Data;

namespace LawFirmManagementSystem_Business
{
    public class Case
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        // --- Case Properties ---
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }
        public string Title { get; set; }
        public string Court { get; set; }
        public string ClientName { get; set; }
        public string ClientStatus { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string OpponentName { get; set; }
        public string OpponentStatus { get; set; }
        public string OpponentAddress { get; set; }
        public string OpponentPhone { get; set; }
        public int ClientId { get; set; }
        public Client ClientInfo
        {
            get
            {
                return Client.GetClient(ClientId);
            }
        }
        public int TrackingChangesId { get; set; }
        public TrackingChanges TrackingChangesInfo
        {
            get
            {
                return TrackingChanges.GetTrackingChanges(TrackingChangesId);
            }
        }
        public string Notes { get; set; }

        // Default constructor for AddNewMode
        public Case()
        {
            this.CaseId = 0;
            this.CaseNumber = string.Empty;
            this.Title = string.Empty;
            this.Court = string.Empty;
            this.ClientName = string.Empty;
            this.ClientStatus = string.Empty;
            this.ClientAddress = string.Empty;
            this.ClientPhone = string.Empty;
            this.OpponentName = string.Empty;
            this.OpponentStatus = string.Empty;
            this.OpponentAddress = string.Empty;
            this.OpponentPhone = string.Empty;
            this.ClientId = 0;
            this.TrackingChangesId = 0;
            this.Notes = string.Empty;
            this.mode = enMode.AddNewMode;
        }

        // Private constructor for UpdateMode
        private Case(int caseId, string caseNumber, string title, string court,
                     string clientName, string clientStatus, string clientAddress, string clientPhone,
                     string opponentName, string opponentStatus, string opponentAddress, string opponentPhone,
                     int clientId, int trackingChangesId, string notes)
        {
            this.CaseId = caseId;
            this.CaseNumber = caseNumber;
            this.Title = title;
            this.Court = court;
            this.ClientName = clientName;
            this.ClientStatus = clientStatus;
            this.ClientAddress = clientAddress;
            this.ClientPhone = clientPhone;
            this.OpponentName = opponentName;
            this.OpponentStatus = opponentStatus;
            this.OpponentAddress = opponentAddress;
            this.OpponentPhone = opponentPhone;
            this.ClientId = clientId;
            this.TrackingChangesId = trackingChangesId;
            this.Notes = notes;
            this.mode = enMode.UpdateMode;
        }
        public static Case GetCase(int caseId)
        {
            // Declare all ref parameters
            string caseNumber = "", title = "", court = "", clientName = "", clientStatus = "",
                   clientAddress = "", clientPhone = "", opponentName = "", opponentStatus = "",
                   opponentAddress = "", opponentPhone = "", notes = "";
            int clientId = 0, trackingChangesId = 0;

            if (CasesDataAccess.GetCase(caseId, ref caseNumber, ref title, ref court,
                ref clientName, ref clientStatus, ref clientAddress, ref clientPhone,
                ref opponentName, ref opponentStatus, ref opponentAddress, ref opponentPhone,
                ref clientId, ref trackingChangesId, ref notes))
            {
                return new Case(caseId, caseNumber, title, court, clientName, clientStatus,
                                clientAddress, clientPhone, opponentName, opponentStatus,
                                opponentAddress, opponentPhone, clientId, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new Case();
        }
        public static DataTable GetAllCases()
        {
            return CasesDataAccess.GetAllCases();
        }
        public static bool DeleteCase(int caseId) => CasesDataAccess.DeleteCase(caseId);

        private bool _UpdateCase()
        {
            // This relies on TrackingChangesInfo.LastUpdatedBy being available
            return CasesDataAccess.UpdateCase(
                this.CaseId, this.CaseNumber, this.Title, this.Court,
                this.ClientName, this.ClientStatus, this.ClientAddress, this.ClientPhone,
                this.OpponentName, this.OpponentStatus, this.OpponentAddress, this.OpponentPhone,
                this.ClientId, this.Notes, this.TrackingChangesInfo.LastUpdatedBy);
        }

        private bool _AddNewCase()
        {
            // This relies on TrackingChangesInfo.CreatedBy being populated *before* calling Save
            this.CaseId = CasesDataAccess.AddCase(
                this.CaseNumber, this.Title, this.Court,
                this.ClientName, this.ClientStatus, this.ClientAddress, this.ClientPhone,
                this.OpponentName, this.OpponentStatus, this.OpponentAddress, this.OpponentPhone,
                this.ClientId, this.Notes, this.TrackingChangesInfo.CreatedBy);

            return (this.CaseId > 0);
        }

        public bool SaveCase()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateCase();

                case enMode.AddNewMode:
                    if (_AddNewCase())
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