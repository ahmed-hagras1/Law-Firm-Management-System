using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Data;

namespace LawFirmManagementSystem_Business
{
    public class Invoice
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        // --- Invoice Properties ---
        public int InvoiceId { get; set; }
        public int CaseId { get; set; }
        private Case _caseInfo;
        public Case CaseInfo
        {
            get { return _caseInfo; }
            set { _caseInfo = value; }
        }
        public decimal Amount { get; set; }
        public int TrackingChangesId { get; set; }
        private TrackingChanges _trackingChangesInfo;
        public TrackingChanges TrackingChangesInfo
        {
            get { return _trackingChangesInfo; }
            set { _trackingChangesInfo = value; }
        }
        public string Notes { get; set; }

        // Default constructor for AddNewMode
        public Invoice()
        {
            this.InvoiceId = 0;
            this.CaseId = 0;
            this.Amount = 0;
            this.TrackingChangesId = 0;
            this.Notes = string.Empty;
            _caseInfo = new Case();
            _trackingChangesInfo = new TrackingChanges();
            this.mode = enMode.AddNewMode;
        }

        // Private constructor for UpdateMode
        private Invoice(int invoiceId, int caseId, decimal amount, int trackingChangesId, string notes)
        {
            this.InvoiceId = invoiceId;
            this.CaseId = caseId;
            this.Amount = amount;
            this.TrackingChangesId = trackingChangesId;
            this.Notes = notes;
            _caseInfo = Case.GetCase(caseId);
            _trackingChangesInfo = TrackingChanges.GetTrackingChanges(trackingChangesId);

            this.mode = enMode.UpdateMode;
        }
        public static Invoice GetInvoice(int invoiceId)
        {
            // Declare all ref parameters
            int caseId = 0, trackingChangesId = 0;
            decimal amount = 0;
            string notes = "";

            if (InvoicesDataAccess.GetInvoice(invoiceId, ref caseId, ref amount, ref trackingChangesId, ref notes))
            {
                return new Invoice(invoiceId, caseId, amount, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new Invoice();
        }
        public static DataTable GetAllInvoices()
        {
            return InvoicesDataAccess.GetAllInvoices();
        }
        public static bool DeleteInvoice(int invoiceId) => InvoicesDataAccess.DeleteInvoice(invoiceId);

        private bool _UpdateInvoice()
        {
            // This relies on TrackingChangesInfo.LastUpdatedBy being available
            return InvoicesDataAccess.UpdateInvoice(
                this.InvoiceId, this.CaseId, this.Amount, this.Notes,
                this.TrackingChangesInfo.LastUpdatedBy // From linked object
            );
        }

        private bool _AddNewInvoice()
        {
            // This relies on TrackingChangesInfo.CreatedBy being populated *before* calling Save
            this.InvoiceId = InvoicesDataAccess.AddInvoice(
                this.CaseId, this.Amount, this.Notes,
                this.TrackingChangesInfo.CreatedBy // From linked object
            );

            return (this.InvoiceId > 0);
        }
        public bool SaveInvoice()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdateInvoice();

                case enMode.AddNewMode:
                    if (_AddNewInvoice())
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