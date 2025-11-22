using LawFirmManagementSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Payments
{
    public partial class frmAddUpdatePayment: Form
    {
        public enum enMode { AddNew = 0, UpdateExisting = 1 };
        private enMode _mode = enMode.AddNew;

        private int _paymentId = -1;
        public int PaymentId
        {
            get { return _paymentId; }
        }
        private Payment _paymentInfo = new Payment();
        public Payment PaymentInfo
        {
            get 
            {
                return _paymentInfo;
            }
        }
        private decimal _amountDue = 0;

        private int _invoiceId = -1;
        public int InvoiceId
        {
            get
            {
                if (_mode == enMode.UpdateExisting)
                    return PaymentInfo.InvoiceId;

                return _invoiceId;
            }
        }
        private Invoice _invoiceInfo = new Invoice();
        public Invoice InvoiceInfo
        {
            get
            {
                if (_mode == enMode.UpdateExisting)
                    return PaymentInfo.InvoiceInfo;
                return _invoiceInfo;
            }
        }
        private void _loadData()
        {
            if (_invoiceInfo != null)
            {
                txtNotes.Text = PaymentInfo.Notes;
                txtAmount.Text = PaymentInfo.Amount.ToString("F2");
            }

        }
        public frmAddUpdatePayment(int id, decimal amountDue, enMode mode)
        {
            InitializeComponent();

            _amountDue = amountDue;

            if (mode == enMode.AddNew)
            {
                _invoiceId = id;
                _mode = enMode.AddNew;
            }
            else
            {
                _paymentId = id;
                _paymentInfo = Payment.GetPayment(PaymentId);
                _mode = enMode.UpdateExisting;
            }

        }

        private void frmAddUpdatePayment_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.AddNew)
            {
                this.Text = "اضافه عمليه دفع";
                lblTitle.Text = "اضافه عمليه دفع";
            }
            else
            {
                this.Text = "تعديل عمليه الدفع";
                lblTitle.Text = "تعديل عمليه الدفع";
                _loadData();
            }
        }
        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);
        private bool ValidateAmount(ref string errorMessage, string text)
        {
            // Empty input
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "يجب ادخال المبلغ.";
                return true; // there is an error
            }

            // Invalid number
            if (!decimal.TryParse(text, out decimal result) || result < 0)
            {
                errorMessage = "يجب ادخال قيمة رقمية صحيحة أكبر من 0.";
                return true;
            }

            // Exceeds amount due when adding new
            if (_mode == enMode.AddNew && result > _amountDue)
            {
                errorMessage = $"المبلغ لا يمكن أن يكون اكبر من المبلغ المتبقي {_amountDue:F2}.";
                return true;
            }

            // Exceeds amount due when updating
            if (_mode == enMode.UpdateExisting && result > _amountDue + PaymentInfo.Amount)
            {
                errorMessage = $"المبلغ لا يمكن أن يكون اكبر من المبلغ المتبقي {_amountDue + PaymentInfo.Amount:F2}.";
                return true;
            }

            return false; // No errors
        }
        private void Validate(object sender, CancelEventArgs e, ValidateDataDelegate validateData)
        {
            TextBox textBox = (TextBox)sender;
            string errorMessage = default;

            if (validateData(ref errorMessage, textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, errorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateAmount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (MessageBox.Show(
                    "هل أنت متأكد أنك تريد حفظ بيانات عمليه الدفع؟",
                    "تأكيد الحفظ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                return;


            // Map UI -> Business
            decimal.TryParse(txtAmount.Text.Trim(), out decimal totalAmount);
            _paymentInfo.Amount = totalAmount;
            _paymentInfo.Notes = txtNotes.Text.Trim();


            if (_mode == enMode.AddNew)
            {
                _paymentInfo.InvoiceId = InvoiceId;
                _paymentInfo.TrackingChangesInfo.CreatedBy = 1;  // TODO: replace actual user ID

                if (_paymentInfo.SavePayment())
                {
                    MessageBox.Show("تم اضافه عمليه الدفع بنجاح.",
                                    "اضافه عمليه الدفع",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Switch mode
                    _mode = enMode.UpdateExisting;
                    _paymentId = _paymentInfo.PaymentId;
                    lblTitle.Text = "تعديل عمليه الدفع";
                }
                else
                {
                    MessageBox.Show("حدث خطأ اثناء اضافه عمليه الدفع.",
                                    "خطأ",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // UpdateExisting
            {
                _paymentInfo.TrackingChangesInfo.LastUpdatedBy = 1;  // TODO: replace actual user ID

                if (_paymentInfo.SavePayment())  
                {
                    MessageBox.Show("تم تعديل بيانات عمليه الدفع بنجاح.",
                                    "تعديل عمليه الدفع",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("حدث خطأ اثناء تعديل بيانات عمليه الدفع.",   
                                    "خطأ",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (like Backspace)
            if (char.IsControl(e.KeyChar))
                return;

            // Allow digits
            if (char.IsDigit(e.KeyChar))
                return;

            // Allow only ONE decimal point
            if (e.KeyChar == '.' && !((TextBox)sender).Text.Contains("."))
                return;

            // Block everything else
            e.Handled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
