using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Data;
using System;
using System.Data;

namespace LawFirmManagementSystem_Business
{
    public class Payment
    {
        public enum enMode { UpdateMode = 0, AddNewMode = 1 };
        public enMode mode = enMode.AddNewMode;

        // --- Payment Properties ---
        public int PaymentId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public int TrackingChangesId { get; set; }
        public string Notes { get; set; }

        // --- Private Backing Fields for Linked Objects ---
        private Invoice _invoiceInfo;
        private TrackingChanges _trackingChangesInfo;

        // --- Public Properties for Linked Objects ---

        // Assumes you have an 'Invoice' business object
        public Invoice InvoiceInfo
        {
            get { return _invoiceInfo; }
            set { _invoiceInfo = value; }
        }

        // Assumes you have a 'TrackingChanges' business object
        public TrackingChanges TrackingChangesInfo
        {
            get { return _trackingChangesInfo; }
            set { _trackingChangesInfo = value; }
        }

        // Default constructor for AddNewMode
        public Payment()
        {
            this.PaymentId = 0;
            this.InvoiceId = 0;
            this.Amount = 0;
            this.TrackingChangesId = 0;
            this.Notes = string.Empty;
            // Initialize linked objects for AddNewMode
            _invoiceInfo = new Invoice();
            _trackingChangesInfo = new TrackingChanges();
            this.mode = enMode.AddNewMode;
        }

        // Private constructor for UpdateMode (Eager Loading)
        private Payment(int paymentId, int invoiceId, decimal amount, int trackingChangesId, string notes)
        {
            this.PaymentId = paymentId;
            this.InvoiceId = invoiceId;
            this.Amount = amount;
            this.TrackingChangesId = trackingChangesId;
            this.Notes = notes;
            // Eagerly load linked objects in UpdateMode
            _invoiceInfo = Invoice.GetInvoice(invoiceId);
            _trackingChangesInfo = TrackingChanges.GetTrackingChanges(trackingChangesId);
            this.mode = enMode.UpdateMode;
        }

        /// <summary>
        /// Finds a Payment by ID and returns a Payment object.
        /// </summary>
        public static Payment GetPayment(int paymentId)
        {
            // Declare all ref parameters
            int invoiceId = 0, trackingChangesId = 0;
            decimal amount = 0;
            string notes = "";

            if (PaymentsDataAccess.GetPayment(paymentId, ref invoiceId, ref amount, ref trackingChangesId, ref notes))
            {
                return new Payment(paymentId, invoiceId, amount, trackingChangesId, notes);
            }

            // If not found, return a new object in AddNewMode
            return new Payment();
        }

        /// <summary>
        /// Gets a DataTable of all payments from the view.
        /// </summary>
        public static DataTable GetAllPayments()
        {
            return PaymentsDataAccess.GetAllPayments();
        }

        /// <summary>
        /// Gets a DataTable of all payments for a specific invoice.
        /// </summary>
        public static DataTable GetAllPaymentsForSpecificInvoice(int invoiceId)
        {
            return PaymentsDataAccess.GetAllPaymentsForSpecificInvoice(invoiceId);
        }

        /// <summary>
        /// Deletes a payment by ID.
        /// </summary>
        public static bool DeletePayment(int paymentId) => PaymentsDataAccess.DeletePayment(paymentId);

        private bool _UpdatePayment()
        {
            // This relies on TrackingChangesInfo.LastUpdatedBy being available
            return PaymentsDataAccess.UpdatePayment(
                this.PaymentId, this.InvoiceId, this.Amount, this.Notes,
                this.TrackingChangesInfo.LastUpdatedBy // From linked object
            );
        }

        private bool _AddNewPayment()
        {
            // This relies on TrackingChangesInfo.CreatedBy being populated *before* calling Save
            this.PaymentId = PaymentsDataAccess.AddPayment(
                this.InvoiceId, this.Amount, this.Notes,
                this.TrackingChangesInfo.CreatedBy // From linked object
            );

            return (this.PaymentId > 0);
        }

        /// <summary>
        /// Saves the Payment object (either Adds New or Updates)
        /// </summary>
        public bool SavePayment()
        {
            switch (mode)
            {
                case enMode.UpdateMode:
                    return _UpdatePayment();

                case enMode.AddNewMode:
                    if (_AddNewPayment())
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