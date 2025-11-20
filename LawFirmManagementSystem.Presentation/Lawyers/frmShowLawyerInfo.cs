using LawFirmManagementSystem.Presentation.Cases;
using LawFirmManagementSystem.Presentation.Sessions;
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
    public partial class frmShowLawyerInfo: Form
    {
        private static DataTable _dtAllActiveSessionsForSpecificLawyer;
        private DataTable _dtSessions;

        private int _lawyerId;
        public int LawyerId
        {
            get { return _lawyerId; }
        }
        private void RefreshSessionsList()
        {
            _dtAllActiveSessionsForSpecificLawyer = Session.GetAllActiveSessionsForSpecificLawyer(_lawyerId);
            _dtSessions = _dtAllActiveSessionsForSpecificLawyer.DefaultView.ToTable(false, "CaseNumber", "Title", "RollNumber", "Date",
            "Court", "ClientName", "Requests", "Decision", "Notes");

        }
        private void SessionsColumnsFormatting()
        {
            dgvActiveLawyerSessions.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvActiveLawyerSessions.Columns["Title"].HeaderText = "وصف الجلسه";
            dgvActiveLawyerSessions.Columns["RollNumber"].HeaderText = "رقم الجلسه";
            dgvActiveLawyerSessions.Columns["Date"].HeaderText = "تاريخ الجلسه";
            dgvActiveLawyerSessions.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvActiveLawyerSessions.Columns["Court"].HeaderText = "اسم المحكمه";
            dgvActiveLawyerSessions.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvActiveLawyerSessions.Columns["Requests"].HeaderText = "الطلبات";
            dgvActiveLawyerSessions.Columns["Decision"].HeaderText = "القرار";
            dgvActiveLawyerSessions.Columns["Notes"].HeaderText = "ملاحظات";

        }
        public frmShowLawyerInfo(int lawyerId)
        {
            InitializeComponent();

            _lawyerId = lawyerId;


        }

        private void frmShowLawyerInfo_Load(object sender, EventArgs e)
        {
            dgvActiveLawyerSessions.DataSource = null;
            RefreshSessionsList();

            if (_dtSessions.Rows.Count > 0 )
            {
                dgvActiveLawyerSessions.DataSource = _dtSessions;
                SessionsColumnsFormatting();
            }

            ctrlLawyerInfo1.LoadLawyerInfo(_lawyerId);
        }

        private void tsmiShowSessionInfo_Click(object sender, EventArgs e)
        {
            if (dgvActiveLawyerSessions.Rows.Count > 0)
            {
                // Get sessionId.
                int sessionId = _dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["SessionId"] != DBNull.Value ?
                    (int)_dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["SessionId"] : 0;

                frmShowSessionInfo frm = new frmShowSessionInfo(sessionId);
                frm.ShowDialog();
            }
        }

        private void tsmiShowCaseInfoForSession_Click(object sender, EventArgs e)
        {
            if (dgvActiveLawyerSessions.Rows.Count > 0)
            {
                // Get caseId.
                int caseId = _dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["CaseId"] : 0;

                frmShowCaseInfo frm = new frmShowCaseInfo(caseId);
                frm.ShowDialog();
            }
        }

        private void tsmiEditSession_Click(object sender, EventArgs e)
        {
            if (dgvActiveLawyerSessions.Rows.Count > 0)
            {
                // Get sessionId.
                int sessionId = _dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["SessionId"] != DBNull.Value ?
                    (int)_dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["SessionId"] : 0;

                frmAddUpdateSession frm = new frmAddUpdateSession(sessionId, frmAddUpdateSession.enMode.UpdateExisting);
                frm.ShowDialog();

                // 4. Refresh the data grid
                frmShowLawyerInfo_Load(null, null);
            }
        }

        private void tsmiDeleteSession_Click(object sender, EventArgs e)
        {
            if (dgvActiveLawyerSessions.Rows.Count > 0)
            {
                // Get sessionId.
                int sessionId = _dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["SessionId"] != DBNull.Value ?
                    (int)_dtAllActiveSessionsForSpecificLawyer.Rows[dgvActiveLawyerSessions.CurrentRow.Index]["SessionId"] : 0;


                // 2. Show Confirmation Message
                if (MessageBox.Show(
                            $"هل أنت متأكد أنك تريد حذف الجلسه؟",
                            "تأكيد الحذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // 3. Call the Business Layer to delete
                    if (Session.DeleteSession(sessionId))
                    {
                        MessageBox.Show("تم حذف الجلسه بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Refresh the data grid
                        frmShowLawyerInfo_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف الجلسه.",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
    }
}
