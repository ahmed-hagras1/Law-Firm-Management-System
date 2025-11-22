using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LawFirmManagementSystem_Business;

namespace LawFirmManagementSystem.Presentation.Invoices.Controls
{
    public partial class ctrlInvoiceInfo: UserControl
    {
        private int _invoiceId;
        public int InvoiceId
        {
            get { return _invoiceId; }
        }
        private Invoice _invoiceInfo;
        public Invoice InvoiceInfo
        {
            get { return _invoiceInfo; }
        }
        public void LoadData(int invoiceId, decimal amountPaid, decimal amountDue)
        {
            _invoiceId = invoiceId;
            _invoiceInfo = Invoice.GetInvoice(invoiceId);
            ctrlCaseInfo1.LoadData(InvoiceInfo.CaseId);

            lblTotalAmount.Text = InvoiceInfo.Amount.ToString("C2");
            lblAmountPaid.Text = amountPaid.ToString("C2");
            lblAmountDue.Text = amountDue.ToString("C2");
            lblNotes.Text = InvoiceInfo.Notes.Trim();
        }
        public ctrlInvoiceInfo()
        {
            InitializeComponent();
        }

        private void ctrlInvoiceInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
