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

namespace LawFirmManagementSystem.Presentation.Sessions
{
    public partial class frmAddUpdateSession: Form
    {
        public enum enMode { AddNew = 0, UpdateExisting = 1 };
        private enMode _mode = enMode.AddNew;
        DataTable _allLawyers = Lawyer.GetAllLawyers();

        private int _sessionId;
        public int SessionId
        {
            get
            {
                return _sessionId;
            }
        }
        private Session _sessionInfo = new Session();
        public Session SessionInfo
        {
            get { return _sessionInfo; }
        }
        private int _caseId = -1;
        public int CaseId
        {
            get {
                if (_mode == enMode.UpdateExisting)
                    return SessionInfo.CaseId;
                return _caseId; }
        }
        private Case _caseInfo = new Case();
        public Case CaseInfo
        {
            get
            {
                if (_mode == enMode.UpdateExisting)
                    return SessionInfo.CaseInfo;

                return _caseInfo; 
            }
        }
        public frmAddUpdateSession(int id, enMode mode)
        {
            InitializeComponent();

            if (mode == enMode.AddNew)
            {
                _mode = enMode.AddNew;
                _caseId = id;
                _caseInfo = Case.GetCase(id);
            }
            else if (mode == enMode.UpdateExisting)
            {
                _mode = enMode.UpdateExisting;
                _sessionId = id;
                _sessionInfo = Session.GetSession(id);
            }

        }
        private void _loadLawyers()
        {
            foreach (DataRow lawyer in _allLawyers.Rows)
            {
                cbLawyer.Items.Add(lawyer["FullName"].ToString().Trim());
            }
        }
        private void _loadData()
        {
            txtSessionNumber.Text = SessionInfo.RollNumber.ToString();
            dtpSessionDate.Value = SessionInfo.Date;
            txtCourt.Text = SessionInfo.Court.Trim();
            txtRequests.Text = SessionInfo.Requests.Trim();
            txtDecision.Text = SessionInfo.Decision.Trim();
            txtNotes.Text = SessionInfo.Notes.Trim();
        }
        private void frmAddUpdateSession_Load(object sender, EventArgs e)
        {
            _loadLawyers ();
            
            if (_mode == enMode.UpdateExisting)
            {
                _loadData();
                lblTitle.Text = "تعديل الجلسه";
                this.Text = "تعديل الجلسه";

                for (int i = 0; i < _allLawyers.Rows.Count; i++)
                {
                    if ((int)_allLawyers.Rows[i]["LawyerId"] == SessionInfo.LawyerId)
                    {
                        cbLawyer.SelectedIndex = i;
                        break;
                    }
                }
            }
            else if (_mode == enMode.AddNew)
            {
                lblTitle.Text = "اضافه جلسه جديده";
                this.Text = "اضافه جلسه جديده";
                cbLawyer.SelectedIndex = 0;
            }

        }
        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);
        private bool ValidateCourt(ref string errorMessage, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                errorMessage = "يجب ادخال المحكمه.";

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
        private void txtCourt_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateCourt);
        }
        private void txtSessionNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is NOT a digit (0-9)
            // AND Check if it is NOT a control character (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Block the character by setting e.Handled to true
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (MessageBox.Show(
                        $"هل أنت متأكد أنك تريد حفظ بيانات الجلسه.",
                        "تأكيد الحفظ",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {


                    SessionInfo.Date = dtpSessionDate.Value;
                    int.TryParse(txtSessionNumber.Text.Trim(), out int rollNumber);
                    SessionInfo.RollNumber = rollNumber;
                    SessionInfo.Court = txtCourt.Text.Trim();
                    SessionInfo.Requests = txtRequests.Text.Trim();
                    SessionInfo.Decision = txtDecision.Text.Trim();
                    SessionInfo.Notes = txtNotes.Text.Trim();


                    if (_mode == enMode.AddNew)
                    {
                        SessionInfo.CaseId = CaseId;

                        SessionInfo.LawyerId = (int)_allLawyers.Rows[cbLawyer.SelectedIndex]["LawyerId"];

                        SessionInfo.TrackingChangesInfo.CreatedBy = 1; // Replace with actual logged-in user ID

                        if (SessionInfo.SaveSession())
                        {
                            MessageBox.Show("تم اضافه الجلسه بنجاح.", "اضافه جلسه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ اثناء اضافه الجلسه.", "اضافه جلسه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (_mode == enMode.UpdateExisting)
                    {
                        SessionInfo.TrackingChangesInfo.LastUpdatedBy = 1; // Replace with actual logged-in user ID


                        if (SessionInfo.SaveSession())
                        {
                            MessageBox.Show("تم تعديل الجلسه بنجاح.", "تعديل جلسه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ اثناء تعديل الجلسه.", "تعديل جلسه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
