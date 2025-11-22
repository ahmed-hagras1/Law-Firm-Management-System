using LawFirmManagementSystem.Presentation.Payments;
using LawFirmManagementSystem_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Invoices
{
    public partial class frmShowInvoicePayments : Form
    {
        private readonly int _invoiceId;
        public int InvoiceId => _invoiceId;

        private readonly Invoice _invoiceInfo;
        public Invoice InvoiceInfo => _invoiceInfo;

        private decimal _amountDue;
        private static DataTable _dtAllPaymentsForSpecificInvoice;
        private DataTable _dtPayments;

        public frmShowInvoicePayments(int invoiceId)
        {
            InitializeComponent();
            _invoiceId = invoiceId;

            // Load invoice data only once
            _invoiceInfo = Invoice.GetInvoice(invoiceId);
        }

        private void RefreshInvoicesList()
        {
            _dtAllPaymentsForSpecificInvoice =
                Payment.GetAllPaymentsForSpecificInvoice(InvoiceId);

            _dtPayments = _dtAllPaymentsForSpecificInvoice.DefaultView
                .ToTable(false,
                    "ClientName",
                    "Title",
                    "Amount",
                    "CreatedBy",
                    "IssueDate",
                    "LastUpdatedBy",
                    "Notes");
        }

        private void PaymentsColumnsFormatting()
        {
            dgvCaseInvoicesOrDocuments.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvCaseInvoicesOrDocuments.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvCaseInvoicesOrDocuments.Columns["IssueDate"].HeaderText = "تاريخ الاصدار";
            dgvCaseInvoicesOrDocuments.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCaseInvoicesOrDocuments.Columns["Amount"].HeaderText = "المبلغ";
            dgvCaseInvoicesOrDocuments.Columns["Title"].HeaderText = "وصف القضيه";
            dgvCaseInvoicesOrDocuments.Columns["LastUpdatedBy"].HeaderText = "اخر تحديث بواسطه";
            dgvCaseInvoicesOrDocuments.Columns["Notes"].HeaderText = "ملاحظات";
        }

        private void frmShowInvoicePayments_Load(object sender, EventArgs e)
        {
            RefreshInvoicesList();

            if (_dtPayments.Rows.Count > 0)
            {
                dgvCaseInvoicesOrDocuments.DataSource = _dtPayments;
                PaymentsColumnsFormatting();

                // Calculate total paid
                decimal amountPaid = 0;
                foreach (DataRow row in _dtPayments.Rows)
                {
                    amountPaid += (decimal)row["Amount"];
                }

                // Correct remaining amount
                _amountDue = InvoiceInfo.Amount - amountPaid;
            }
            else
            {
                dgvCaseInvoicesOrDocuments.DataSource = null;
                _amountDue = InvoiceInfo.Amount; // no payments yet
            }
        }

        private void UpdatePayment_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.CurrentRow == null)
                return;

            int rowIndex = dgvCaseInvoicesOrDocuments.CurrentRow.Index;

            int paymentId =
                _dtAllPaymentsForSpecificInvoice.Rows[rowIndex]["PaymentId"] != DBNull.Value ?
                (int)_dtAllPaymentsForSpecificInvoice.Rows[rowIndex]["PaymentId"] :
                0;

            frmAddUpdatePayment frm =
                new frmAddUpdatePayment(paymentId, _amountDue, frmAddUpdatePayment.enMode.UpdateExisting);

            frm.ShowDialog();

            frmShowInvoicePayments_Load(null, null);
        }

        private void tsmiShowPaymentInfo_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.CurrentRow == null)
                return;

            int rowIndex = dgvCaseInvoicesOrDocuments.CurrentRow.Index;

            int paymentId =
                _dtAllPaymentsForSpecificInvoice.Rows[rowIndex]["PaymentId"] != DBNull.Value ?
                (int)_dtAllPaymentsForSpecificInvoice.Rows[rowIndex]["PaymentId"] :
                0;

            frmShowPaymentInfo frm = new frmShowPaymentInfo(paymentId);
            frm.ShowDialog();

            frmShowInvoicePayments_Load(null, null);
        }

        private void AddPayment_Click(object sender, EventArgs e)
        {
            // You already have InvoiceId — no need to read from the grid
            frmAddUpdatePayment frm =
                new frmAddUpdatePayment(InvoiceId, _amountDue, frmAddUpdatePayment.enMode.AddNew);

            frm.ShowDialog();

            frmShowInvoicePayments_Load(null, null);
        }

        private void tsmiDeletePayment_Click(object sender, EventArgs e)
        {
            // 1. Check if a row is selected
            if (dgvCaseInvoicesOrDocuments.CurrentRow != null)
            {
                int rowIndex = dgvCaseInvoicesOrDocuments.CurrentRow.Index;

                int paymentId =
                    _dtAllPaymentsForSpecificInvoice.Rows[rowIndex]["PaymentId"] != DBNull.Value ?
                    (int)_dtAllPaymentsForSpecificInvoice.Rows[rowIndex]["PaymentId"] :
                    0;

                // 3. Show Confirmation Message
                if (MessageBox.Show(
                            $"هل أنت متأكد أنك تريد حذف عمليه الدفع؟",
                            "تأكيد الحذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // 4. Call the Business Layer to delete
                    if (LawFirmManagementSystem_Business.Payment.DeletePayment(paymentId))
                    {
                        MessageBox.Show("تم حذف عمليه الدفع بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        frmShowInvoicePayments_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف الدفع. ربما حدث خطأ.",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
    }
}
