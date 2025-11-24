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

namespace LawFirmManagementSystem.Presentation.Users
{
    public partial class frmUpdateUser: Form
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
        }
        private User _userInfo;
        public User UserInfo
        {
            get { return _userInfo; }
        }
        public frmUpdateUser(int userId)
        {
            InitializeComponent();

            _userId = userId;
            _userInfo = User.GetUser(userId);
        }

        private void cbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentPassword.Enabled = txtNewPassword.Enabled = txtConfirmPassword.Enabled = cbChangePassword.Checked;
        }

        private void llShowCurrentPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCurrentPassword.PasswordChar == '*')
            {
                txtCurrentPassword.PasswordChar = '\0';
                llShowCurrentPassword.Text = "إخفاء كلمة السر";
            }
            else
            {
                txtCurrentPassword.PasswordChar = '*';
                llShowCurrentPassword.Text = "إظهار كلمة السر";

            }
        }

        private void llShowNewPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtNewPassword.PasswordChar == '*')
            {
                txtNewPassword.PasswordChar = '\0';
                llShowNewPassword.Text = "إخفاء كلمة السر";
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
                llShowNewPassword.Text = "إظهار كلمة السر";
            }

        }

        private void llShowConfirmPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '*')
            {
                txtConfirmPassword.PasswordChar = '\0';
                llShowConfirmPassword.Text = "إخفاء كلمة السر";
            }
            else
            {
                txtConfirmPassword.PasswordChar = '*';
                llShowConfirmPassword.Text = "إظهار كلمة السر";
            }

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

            if (UserInfo.UserName != text.Trim() &&  User.IsUserExist(text.Trim()))
            {
                errorMessage = "اسم المستخدم موجود بالفعل.";
                return true;
            }


            return false; // No errors
        }
        private bool ValidateCurrentPassword(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "من فضلك ادخل كلمة السر الحالية.";
                return true;
            }

            if (text.Trim().Length < 4)
            {
                errorMessage = "يجب ان تحتوي كلمه السر علي الاقل 4 احرف.";
                return true;
            }

            if (_userInfo is null)
            {
                errorMessage = "لا يوجد بيانات للمستخدم.";
                return true;
            }

            if (_userInfo.Password is null)
            {
                errorMessage = "لا يوجد كلمة سر مخزنة.";
                return true;
            }

            if (!PasswordHasher.VerifyPassword(text, _userInfo.Password))
            {
                errorMessage = "كلمه السر الحاليه غير صحيحه.";
                return true;
            }

            return false;
        }
        private bool ValidateNewPassword(ref string errorMessage, string text)
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

            if (text != txtNewPassword.Text.Trim())
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

        private void frmUpdateUser_Load(object sender, EventArgs e)
        {
            txtUsername.Text = UserInfo.UserName;
            cbIsActive.Checked = UserInfo.IsActive;
            txtNotes.Text = UserInfo.Notes;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateUsername);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!cbChangePassword.Checked)
                return;

            Validate(sender, e, ValidateCurrentPassword);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!cbChangePassword.Checked)
                return;

            Validate(sender, e, ValidateNewPassword);   
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!cbChangePassword.Checked)
                return;

            Validate(sender, e, ValidateConfirmPassword);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                return;
            }

            UserInfo.UserName = txtUsername.Text.Trim();

            if (cbChangePassword.Checked)
            {
                UserInfo.Password = PasswordHasher.HashPassword(txtNewPassword.Text.Trim());
            }

            UserInfo.Notes = txtNotes.Text.Trim();
            UserInfo.IsActive = cbIsActive.Checked;

            UserInfo.TrackingChangesInfo.LastUpdatedBy = 1; // Change it.


            // 4) عرض رسالة النتيجة
            if (UserInfo.SaveUser())
            {
                MessageBox.Show("تم تحديث بيانات المستخدم بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء تحديث البيانات.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
