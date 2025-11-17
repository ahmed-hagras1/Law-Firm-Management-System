using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Data;

namespace LawFirmManagementSystem_Business
{
    public class Session
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        // --- Session Properties ---
        public int SessionId { get; set; }
        public int CaseId { get; set; }
        private Case _caseInfo;
        public Case CaseInfo
        {
            get { return _caseInfo; }
            set { _caseInfo = value; }
        }
        public DateTime Date { get; set; }
        public int RollNumber { get; set; }
        public string Court { get; set; }
        public int LawyerId { get; set; }
        private Lawyer _lawyerInfo;
        public Lawyer LawyerInfo
        {
            get { return _lawyerInfo; }
            set { _lawyerInfo = value; }
        }
        public string Requests { get; set; }
        public string Decision { get; set; }
        public int TrackingChangesId { get; set; }
        private TrackingChanges _trackingChangesInfo;
        public TrackingChanges TrackingChangesInfo
        {
            get { return _trackingChangesInfo; }
            set { _trackingChangesInfo = value; }
        }
        public string Notes { get; set; }

        // Default constructor for AddNewMode
        public Session()
        {
            this.SessionId = 0;
            this.CaseId = 0;
            this.Date = DateTime.Now; // Default to today
            this.RollNumber = 0;
            this.Court = string.Empty;
            this.LawyerId = 0;
            this.Requests = string.Empty;
            this.Decision = string.Empty;
            this.TrackingChangesId = 0;
            this.Notes = string.Empty;
            _caseInfo = new Case();
            _lawyerInfo = new Lawyer();
            _trackingChangesInfo = new TrackingChanges();

            this.mode = enMode.AddNewMode;
        }

        // Private constructor for UpdateMode
        private Session(int sessionId, int caseId, DateTime date, int rollNumber,
                        string court, int lawyerId, string requests, string decision,
                        int trackingChangesId, string notes)
        {
            this.SessionId = sessionId;
            this.CaseId = caseId;
            this.Date = date;
            this.RollNumber = rollNumber;
            this.Court = court;
            this.LawyerId = lawyerId;
            this.Requests = requests;
            this.Decision = decision;
            this.TrackingChangesId = trackingChangesId;
            this.Notes = notes;
            _caseInfo = Case.GetCase(caseId);
            _lawyerInfo = Lawyer.GetLawyer(lawyerId);
            _trackingChangesInfo = TrackingChanges.GetTrackingChanges(trackingChangesId);

            this.mode = enMode.UpdateMode;
        }
        public static Session GetSession(int sessionId)
        {
            // Declare all ref parameters
            int caseId = 0, rollNumber = 0, lawyerId = 0, trackingChangesId = 0;
            DateTime date = DateTime.MinValue;
            string court = "", requests = "", decision = "", notes = "";

            if (SessionsDataAccess.GetSession(sessionId, ref caseId, ref date, ref rollNumber,
                ref court, ref lawyerId, ref requests, ref decision, ref trackingChangesId, ref notes))
            {
                return new Session(sessionId, caseId, date, rollNumber, court, lawyerId,
                                   requests, decision, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new Session();
        }
        public static DataTable GetAllSessions()
        {
            return SessionsDataAccess.GetAllSessions();
        }
        public static bool DeleteSession(int sessionId) => SessionsDataAccess.DeleteSession(sessionId);

        private bool _UpdateSession()
        {
            // This relies on TrackingChangesInfo.LastUpdatedBy being available
            return SessionsDataAccess.UpdateSession(
                this.SessionId, this.CaseId, this.Date, this.RollNumber, this.Court,
                this.LawyerId, this.Requests, this.Decision, this.Notes,
                this.TrackingChangesInfo.LastUpdatedBy // From linked object
            );
        }

        private bool _AddNewSession()
        {
            // This relies on TrackingChangesInfo.CreatedBy being populated *before* calling Save
            this.SessionId = SessionsDataAccess.AddSession(
                this.CaseId, this.Date, this.RollNumber, this.Court,
                this.LawyerId, this.Requests, this.Decision, this.Notes,
                this.TrackingChangesInfo.CreatedBy // From linked object
            );

            return (this.SessionId > 0);
        }
        public bool SaveSession()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateSession();

                case enMode.AddNewMode:
                    if (_AddNewSession())
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