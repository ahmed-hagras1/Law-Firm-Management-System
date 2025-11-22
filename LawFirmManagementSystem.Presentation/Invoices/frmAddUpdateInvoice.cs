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

namespace LawFirmManagementSystem.Presentation.Invoices
{
    public partial class frmAddUpdateInvoice: Form
    {
        public enum enMode { AddNew = 0, UpdateExisting = 1 };
        private enMode _mode = enMode.AddNew;

        private int _invoiceId = -1;
        public int InvoiceId
        {
            get { return _invoiceId; }
        }
        private Invoice _invoiceInfo = new Invoice();
        public Invoice InvoiceInfo
        {
            get { return _invoiceInfo; }
        }
        // initialize amount paid  = 0 
        // use it to validate that total amount is not less than amount paid.
        private decimal _amountPaid = 0;
        private int _caseId = -1;
        public int CaseId
        {
            get
            {
                if (_mode == enMode.UpdateExisting)
                    return InvoiceInfo.CaseId;

                return _caseId;
            }
        }
        private Case _caseInfo = new Case();
        public Case CaseInfo
        {
            get
            {
                if (_mode == enMode.UpdateExisting)
                    return InvoiceInfo.CaseInfo;
                return _caseInfo;
            }
        }
        private void _loadData()
        {
            if (_invoiceInfo != null)
            {
                txtNotes.Text = _invoiceInfo.Notes;
                txtTotalAmount.Text = _invoiceInfo.Amount.ToString("F2");
            }

        }
        public frmAddUpdateInvoice(int invoiceId, decimal amountPaid)
        {
            InitializeComponent();

            _invoiceId = invoiceId;
            _mode = enMode.UpdateExisting;
            _invoiceInfo = Invoice.GetInvoice(invoiceId);
            _amountPaid = amountPaid;
        }
        public frmAddUpdateInvoice(int caseId)
        {
            InitializeComponent();

            _mode = enMode.AddNew;
            _caseId = caseId;
            _caseInfo = Case.GetCase(_caseId);
        }

        private void frmAddUpdateInvoice_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.AddNew)
            {
                lblTitle.Text = "إضافة فاتورة جديدة";
                this.Text = "إضافة فاتورة جديدة";
            }
            else if (_mode == enMode.UpdateExisting)
            {
                _loadData();
                lblTitle.Text = "تعديل الفاتورة";
                this.Text = "تعديل الفاتورة";

            }
        }
        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);
        private bool ValidateAmount(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                errorMessage = "يجب ادخال المبلغ الكلي.";

            
            //if (string.IsNullOrWhiteSpace(text))
            //{
            //    errorMessage = "يجب ادخال المبلغ الكلي.";
            //    return false;
            //}

            // Check if it's a valid number
            if (!decimal.TryParse(text, out decimal result) || result < 0)
            {
                errorMessage = "يجب ادخال قيمة رقمية صحيحة أكبر من 0.";
            }

            // Check if total amount is less than amount paid
            if (result < _amountPaid)
            {
                errorMessage = $"المبلغ الكلي لا يمكن أن يكون أقل من المبلغ المدفوع {_amountPaid:F2}.";
            }


            return !(string.IsNullOrEmpty(errorMessage));

            //return true;
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

        private void txtTotalAmount_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateAmount);
        }

        private void txtTotalAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check all form valid or not.
            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show(
                        $"هل أنت متأكد أنك تريد حفظ بيانات الفاتوره؟",
                        "تأكيد الحفظ",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                // 3. Map UI controls to the Business Object
                decimal.TryParse(txtTotalAmount.Text.Trim(), out decimal totalAmount);
                _invoiceInfo.Amount = totalAmount;
                _invoiceInfo.Notes = txtNotes.Text.Trim();

                if (_mode == enMode.AddNew)
                {
                    _invoiceInfo.CaseId = CaseId;

                    // Set the creator ID (Replace 1 with the actual logged-in user ID)
                    _invoiceInfo.TrackingChangesInfo.CreatedBy = 1;

                    if (_invoiceInfo.SaveInvoice())
                    {
                        MessageBox.Show("تم اضافه الفاتوره بنجاح.", "اضافه الفاتوره", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Switch to Update mode
                        _mode = enMode.UpdateExisting;
                        _invoiceId = _invoiceInfo.InvoiceId;
                        lblTitle.Text = "تعديل الفاتوره";
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء اضافه الفاتوره.", "اضافه فاتوره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // UpdateExisting
                {
                    // Set the updater ID (Replace 1 with the actual logged-in user ID)
                    _invoiceInfo.TrackingChangesInfo.LastUpdatedBy = 1;

                    if (_invoiceInfo.SaveInvoice())
                    {
                        MessageBox.Show("تم تعديل بيانات الفاتوره بنجاح.", "تعديل فاتوره", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء تعديل بيانات الفاتوره.", "تعديل فاتوره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
