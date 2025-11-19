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
using System.Xml.Linq;

namespace LawFirmManagementSystem.Presentation.Cases
{
    public partial class frmAddUpdateCase: Form
    {
        public enum enMode { AddNew = 0, UpdateExisting = 1 };
        private enMode _mode = enMode.AddNew;

        private int _caseId = -1;
        public int CaseId
        {
            get { return _caseId; }
        }
        private Case _caseInfo = new Case();
        public Case CaseInfo
        {
            get { return _caseInfo; }
        }
        private int _clientId;
        public int ClientId
        {
            get {
                if (_mode == enMode.UpdateExisting)
                    return _caseInfo.ClientId;
                else
                    return _clientId;
            }
        }
        public frmAddUpdateCase(int id, enMode mode)
        {
            InitializeComponent();

            if (mode == enMode.UpdateExisting)
            {
                _caseId = id;
                _caseInfo = Case.GetCase(id);
                _mode = enMode.UpdateExisting;
            }
            else if (mode == enMode.AddNew)
            {
                _clientId = id;
                _mode = enMode.AddNew;
            }

        }
        private void _loadData()
        {
            txtCaseNumber.Text = CaseInfo.CaseNumber.Trim();
            txtCourt.Text = CaseInfo.Court.Trim();
            txtTitle.Text = CaseInfo.Title.Trim();
            txtClientName.Text = CaseInfo.ClientName.Trim();
            txtOpponentName.Text = CaseInfo.OpponentName.Trim();
            txtClientPhone.Text = CaseInfo.ClientPhone.Trim();
            txtOpponentPhone.Text = CaseInfo.OpponentPhone.Trim();
            txtClientAddress.Text = CaseInfo.ClientAddress.Trim();
            txtOpponentAddress.Text = CaseInfo.OpponentAddress.Trim();
            txtClientStatus.Text = CaseInfo.ClientStatus.Trim();
            txtOpponentStatus.Text = CaseInfo.OpponentStatus.Trim();
            txtNotes.Text = CaseInfo.Notes.Trim();
        }

        private void frmAddUpdateCase_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.AddNew)
            {
                lblTitle.Text = "اضافه قضيه";
            }
            else if (_mode == enMode.UpdateExisting)
            {
                lblTitle.Text = "تعديل القضيه";
                _loadData();

            }
        }

        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);
        private bool ValidateClientName(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                errorMessage = "يجب ادخال اسم العميل.";

            return !(string.IsNullOrEmpty(errorMessage));
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

        private void txtClientName_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateClientName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check all form valid or not.
            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show(
                        $"هل أنت متأكد أنك تريد حفظ بيانات القضية: {txtTitle.Text.Trim()} ؟",
                        "تأكيد الحفظ",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                // 3. Map UI controls to the Business Object
                _caseInfo.CaseNumber = txtCaseNumber.Text.Trim();
                _caseInfo.Court = txtCourt.Text.Trim();
                _caseInfo.Title = txtTitle.Text.Trim();
                _caseInfo.ClientName = txtClientName.Text.Trim();
                _caseInfo.OpponentName = txtOpponentName.Text.Trim();
                _caseInfo.ClientPhone = txtClientPhone.Text.Trim();
                _caseInfo.OpponentPhone = txtOpponentPhone.Text.Trim();
                _caseInfo.ClientAddress = txtClientAddress.Text.Trim();
                _caseInfo.OpponentAddress = txtOpponentAddress.Text.Trim();
                _caseInfo.ClientStatus = txtClientStatus.Text.Trim();
                _caseInfo.OpponentStatus = txtOpponentStatus.Text.Trim();
                _caseInfo.Notes = txtNotes.Text.Trim();

                if (_mode == enMode.AddNew)
                {
                    _caseInfo.ClientId = ClientId;

                    // Set the creator ID (Replace 1 with the actual logged-in user ID)
                    _caseInfo.TrackingChangesInfo.CreatedBy = 1;

                    if (_caseInfo.SaveCase())
                    {
                        MessageBox.Show("تم اضافه القضية بنجاح.", "اضافه قضية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Switch to Update mode
                        _mode = enMode.UpdateExisting;
                        _caseId = _caseInfo.CaseId;
                        lblTitle.Text = "تعديل القضية";
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء اضافه القضية.", "اضافه قضية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // UpdateExisting
                {
                    // Set the updater ID (Replace 1 with the actual logged-in user ID)
                    _caseInfo.TrackingChangesInfo.LastUpdatedBy = 1;

                    if (_caseInfo.SaveCase())
                    {
                        MessageBox.Show("تم تعديل بيانات القضية بنجاح.", "تعديل قضية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء تعديل بيانات القضية.", "تعديل قضية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is NOT a digit (0-9)
            // AND Check if it is NOT a control character (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Block the character by setting e.Handled to true
                e.Handled = true;
            }
        }

        private void txtOpponentPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is NOT a digit (0-9)
            // AND Check if it is NOT a control character (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Block the character by setting e.Handled to true
                e.Handled = true;
            }
        }
    }
}
