using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation
{
    public partial class frmShowPaymentInfo: Form
    {
        private int _paymentId;
        public int PaymentId
        {
            get { return _paymentId; }
        }
        public frmShowPaymentInfo(int paymentId)
        {
            InitializeComponent();

            _paymentId = paymentId;
        }

        private void ShowPaymentInfo_Load(object sender, EventArgs e)
        {
            ctrlPaymentInfo1.LoadData(PaymentId);
        }
    }
}
