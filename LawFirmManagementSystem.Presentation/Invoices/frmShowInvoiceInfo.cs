using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Invoices
{
    public partial class frmShowInvoiceInfo: Form
    {
        private int _invoiceId; 
        public int InvoiceId
        {
            get { return _invoiceId; }
        }
        private decimal _amountPaid;
        private decimal _amountDue;
        public frmShowInvoiceInfo(int invoiceId, decimal amountPaid, decimal amountDue)
        {
            InitializeComponent();
            _invoiceId = invoiceId;
            _amountPaid = amountPaid;
            _amountDue = amountDue;
        }

        private void frmInvoiceInfo_Load(object sender, EventArgs e)
        {
            ctrlInvoiceInfo1.LoadData(InvoiceId, _amountPaid, _amountDue);
            this.Text = "عرض بيانات الفاتوره";
        }

        private void btnShowInvoicePayments_Click(object sender, EventArgs e)
        {
            frmShowInvoicePayments frm = new frmShowInvoicePayments(InvoiceId);
            frm.ShowDialog();
        }
    }
}
