using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Data;

namespace LawFirmManagementSystem_Business
{
    public class Document
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        // --- Document Properties ---
        public int DocumentId { get; set; }
        public int CaseId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TrackingChangesId { get; set; }
        public string Notes { get; set; }

        // --- Private Backing Fields for Linked Objects ---
        private Case _caseInfo;
        private TrackingChanges _trackingChangesInfo;

        // --- Public Properties for Linked Objects ---

        // Assumes you have a 'Case' business object
        public Case CaseInfo
        {
            get { return _caseInfo; }
            set { _caseInfo = value; }
        }

        // Assumes you have a 'TrackingChanges' business object
        public TrackingChanges TrackingChangesInfo
        {
            get { return _trackingChangesInfo; }
            set { _trackingChangesInfo = value; }
        }

        // Default constructor for AddNewMode
        public Document()
        {
            this.DocumentId = 0;
            this.CaseId = 0;
            this.FileName = string.Empty;
            this.FilePath = string.Empty;
            this.TrackingChangesId = 0;
            this.Notes = string.Empty;
            // Initialize linked objects for AddNewMode
            _caseInfo = new Case();
            _trackingChangesInfo = new TrackingChanges();
            this.mode = enMode.AddNewMode;
        }

        // Private constructor for UpdateMode (Eager Loading)
        private Document(int documentId, int caseId, string fileName, string filePath, int trackingChangesId, string notes)
        {
            this.DocumentId = documentId;
            this.CaseId = caseId;
            this.FileName = fileName;
            this.FilePath = filePath;
            this.TrackingChangesId = trackingChangesId;
            this.Notes = notes;
            // Eagerly load linked objects in UpdateMode
            _caseInfo = Case.GetCase(caseId);
            _trackingChangesInfo = TrackingChanges.GetTrackingChanges(trackingChangesId);
            this.mode = enMode.UpdateMode;
        }
        public static Document GetDocument(int documentId)
        {
            // Declare all ref parameters
            int caseId = 0, trackingChangesId = 0;
            string fileName = "", filePath = "", notes = "";

            if (DocumentsDataAccess.GetDocument(documentId, ref caseId, ref fileName, ref filePath, ref trackingChangesId, ref notes))
            {
                return new Document(documentId, caseId, fileName, filePath, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new Document();
        }
        public static DataTable GetAllDocuments()
        {
            return DocumentsDataAccess.GetAllDocuments();
        }

        public static DataTable GetAllDocumentsForSpecificCase(int caseId)
        {
            return DocumentsDataAccess.GetAllDocumentsForSpecificCase(caseId);
        }
        public static bool DeleteDocument(int documentId) => DocumentsDataAccess.DeleteDocument(documentId);

        private bool _UpdateDocument()
        {
            // This relies on TrackingChangesInfo.LastUpdatedBy being available
            return DocumentsDataAccess.UpdateDocument(
                this.DocumentId, this.CaseId, this.FileName, this.FilePath, this.Notes,
                this.TrackingChangesInfo.LastUpdatedBy // From linked object
            );
        }

        private bool _AddNewDocument()
        {
            // This relies on TrackingChangesInfo.CreatedBy being populated *before* calling Save
            this.DocumentId = DocumentsDataAccess.AddDocument(
                this.CaseId, this.FileName, this.FilePath, this.Notes,
                this.TrackingChangesInfo.CreatedBy // From linked object
            );

            return (this.DocumentId > 0);
        }

        public bool SaveDocument()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateDocument();

                case enMode.AddNewMode:
                    if (_AddNewDocument())
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