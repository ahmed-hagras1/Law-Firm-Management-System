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

namespace LawFirmManagementSystem.Presentation.Lawyers
{
    public partial class frmAddUpdateLawyer: Form
    {
        private enum enMode { UpdateMode, AddNewMode};
        private enMode _mode = enMode.AddNewMode;
        private  int _lawyerId; 
        public int LawyerId
        {
            get { return _lawyerId; }
        }
        private Lawyer _lawyerInfo = new Lawyer();
        public Lawyer LawyerInfo
        {
            get { return _lawyerInfo; }
        }
        public frmAddUpdateLawyer()
        {
            InitializeComponent();

            _mode = enMode.AddNewMode;
        }
        public frmAddUpdateLawyer(int lawyerId)
        {
            InitializeComponent();

            _lawyerId = lawyerId;
            _lawyerInfo = Lawyer.GetLawyer(lawyerId);
            _mode = enMode.UpdateMode;

        }
        private void LoadData()
        {
            txtName.Text = LawyerInfo.PersonInfo.FullName;
            txtPhone.Text = LawyerInfo.PersonInfo.Phone;
            txtAddress.Text = LawyerInfo.PersonInfo.Address;
            txtNotes.Text = LawyerInfo.Notes;
        }

        private void frmAddUpdateLawyer_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.UpdateMode)
            {
                LoadData();
                lblTitle.Text = "تعديل المحامي";
            }
            else if (_mode == enMode.AddNewMode)
            {
                lblTitle.Text = "اضافه محامي";
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
                        $"هل أنت متأكد أنك تريد حفظ بيانات المحامي: {txtName.Text.Trim()} ؟",
                        "تأكيد الحفظ", 
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                LawyerInfo.PersonInfo.FullName = txtName.Text.Trim();
                LawyerInfo.PersonInfo.Phone = txtPhone.Text.Trim();
                LawyerInfo.PersonInfo.Address = txtAddress.Text.Trim();
                LawyerInfo.Notes = txtNotes.Text.Trim();

                if (_mode == enMode.AddNewMode)
                {
                    LawyerInfo.TrackingChangesInfo.CreatedBy = 1;
                    if (LawyerInfo.SaveLawyer())
                    {
                        MessageBox.Show("تم اضافه المحامي بنجاح.", "اضافه محامي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mode = enMode.UpdateMode;
                        _lawyerId = LawyerInfo.LawyerId;
                        lblTitle.Text = "تعديل المحامي";
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء اضافه المحامي.", "اضافه محامي", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (_mode == enMode.UpdateMode)
                {
                    LawyerInfo.TrackingChangesInfo.LastUpdatedBy = 1;

                    if (LawyerInfo.SaveLawyer())
                    {
                        MessageBox.Show("تم تعديل بيانات المحامي بنجاح.", "تعديل محامي", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ اثناء تعديل بيانات المحامي.", "تعديل محامي", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
