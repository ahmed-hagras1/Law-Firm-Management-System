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

namespace LawFirmManagementSystem.Presentation.Payments
{
    public partial class ctrlPaymentInfo: UserControl
    {
        private int _paymentId;
        public int PaymentId
        {
            get { return _paymentId; }
        }
        private Payment _paymentInfo;
        public Payment PaymentInfo
        {
            get { return _paymentInfo; }    
        }
        public void LoadData(int paymentId)
        {
            _paymentId = paymentId;
            _paymentInfo = Payment.GetPayment(paymentId);

            lblClientName.Text = PaymentInfo.InvoiceInfo.CaseInfo.ClientInfo.PersonInfo.FullName.Trim();
            lblTitle.Text = PaymentInfo.InvoiceInfo.CaseInfo.Title.Trim();
            lblCreatedBy.Text = PaymentInfo.TrackingChangesInfo.CreatedByUserInfo.UserName;
            lblIssueDate.Text = PaymentInfo.TrackingChangesInfo.CreatedDate.ToString("dd-MM-yyyy");
            lblLastUpdatedBy.Text = PaymentInfo.TrackingChangesInfo.LastUpdatedByUserInfo.UserName;
            lblAmount.Text = PaymentInfo.Amount.ToString("f2");
            lblNotes.Text = PaymentInfo.Notes.Trim();

        }
        public ctrlPaymentInfo()
        {
            InitializeComponent();
        }

        private void ctrlPaymentInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
