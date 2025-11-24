using LawFirmManagementSystem.Business;
using LawFirmManagementSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Users
{
    public partial class frmAddUser: Form
    {

        public frmAddUser()
        {
            InitializeComponent();
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {

        }
        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);
        private bool ValidateUsername(ref string errorMessage, string text)
        {
            // Empty input
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "يجب ادخال اسم المستخدم.";
                return true; // there is an error
            }

            if (User.IsUserExist(text.Trim()))
            {
                errorMessage = "اسم المستخدم موجود بالفعل.";
                return true;
            }
           

            return false; // No errors
        }
        private bool ValidatePassword(ref string errorMessage, string text)
        {
            // Empty input
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "يجب ادخال كلمه السر.";
                return true; // there is an error
            }

            if (text.Trim().Length < 4)
            {
                errorMessage = "يجب ان تحتوي كلمه السر علي الاقل 4 احرف.";
                return true;
            }


            return false; // No errors
        }
        private bool ValidateConfirmPassword(ref string errorMessage, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                errorMessage = "يجب تاكيد كلمه السر.";
                return true;
            }

            if (text != txtPassword.Text)
            {
                errorMessage = "كلمة السر وتأكيد كلمة السر غير متطابقين.";
                return true;
            }


            return false;
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

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateUsername);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidatePassword);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateConfirmPassword);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            User userInfo = new User();

            userInfo.UserName = txtUsername.Text.Trim();
            userInfo.Password = PasswordHasher.HashPassword(txtPassword.Text.Trim());
            userInfo.Notes = txtNotes.Text.Trim();

            int n = userInfo.Password.Length;

            // Change it.
            userInfo.TrackingChangesInfo.CreatedBy = 1;

            if (userInfo.SaveUser())
            {
                MessageBox.Show("تم حفظ المستخدم بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Enabled = txtPassword.Enabled = txtConfirmPassword.Enabled = txtNotes.Enabled = btnSave.Enabled = false;
                

            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء حفظ البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
