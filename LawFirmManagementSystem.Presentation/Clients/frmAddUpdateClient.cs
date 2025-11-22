using LawFirmManagementSystem.Business;
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

namespace LawFirmManagementSystem.Presentation
{
    public partial class frmAddUpdateClient: Form
    {
        enum enMode { UpdateMode = 0, AddNewMode = 1 };
        private enMode _mode = enMode.AddNewMode;


        private int _clientId = -1;
        public int ClientId
        {
            get { return _clientId; }
        }
        private Client _clientInfo = new Client();
        public Client ClientInfo
        {
            get { return _clientInfo; }
        }

        public frmAddUpdateClient(int clientId)
        {
            InitializeComponent();

            _mode = enMode.UpdateMode;
            _clientId = clientId;
            _clientInfo = Client.GetClient(clientId);
        }
        public frmAddUpdateClient()
        {
            InitializeComponent();

            _mode = enMode.AddNewMode;

        }
        private void _LoadData()
        {
            txtName.Text = _clientInfo.PersonInfo.FullName;
            txtPhone.Text = _clientInfo.PersonInfo.Phone;
            txtAddress.Text = _clientInfo.PersonInfo.Address;
            txtNotes.Text = _clientInfo.Notes;
        }
        private void frmAddUpdateClient_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.UpdateMode)
            {
                _LoadData();
                lblTitle.Text = "تعديل عميل";
                this.Text = "تعديل عميل";
            }
            else if (_mode == enMode.AddNewMode)
            {
                lblTitle.Text = "اضافه عميل";
                this.Text = "اضافه عميل";
            }
        }
        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);
        private bool ValidateName(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                errorMessage = "يجب ادخال الاسم.";

            return !(string.IsNullOrEmpty(errorMessage));
        }
        private bool ValidatePhone(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                errorMessage = "يجب ادخال رقم الهاتف.";

            return !(string.IsNullOrEmpty(errorMessage));
        }
        private bool ValidateAddress(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                errorMessage = "يجب ادخال العنوان.";

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

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateName);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidatePhone);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateAddress);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check all form valid or not.
            if (!this.ValidateChildren())
            {
                return;
            }
            if (MessageBox.Show(
                        $"هل أنت متأكد أنك تريد حفظ بيانات العميل: {txtName.Text.Trim()} ؟",
                        "تأكيد الحفظ",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ClientInfo.PersonInfo.FullName = txtName.Text.Trim();
                ClientInfo.PersonInfo.Phone = txtPhone.Text.Trim();
                ClientInfo.PersonInfo.Address = txtAddress.Text.Trim();
                ClientInfo.Notes = txtNotes.Text.Trim();

                if (_mode == enMode.AddNewMode)
                {
                    ClientInfo.TrackingChangesInfo.CreatedBy = 1;
                    if (ClientInfo.Save())
                    {
                        MessageBox.Show("تم اضافه العميل بنجاح.", "اضافه عميل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mode = enMode.UpdateMode;
                        _clientId = ClientInfo.ClientId;
                        lblTitle.Text = "تعديل عميل";
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء اضافه العميل.", "اضافه عميل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (_mode == enMode.UpdateMode)
                {
                    ClientInfo.TrackingChangesInfo.LastUpdatedBy = 1;

                    if (ClientInfo.Save())
                    {
                        MessageBox.Show("تم تعديل بيانات العميل بنجاح.", "تعديل عميل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء تعديل بيانات العميل.", "تعديل عميل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
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
