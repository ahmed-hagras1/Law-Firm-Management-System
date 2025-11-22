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

namespace LawFirmManagementSystem.Presentation
{
    public partial class frmShowClientInfo: Form
    {
        // Cases of specific client.
        private static DataTable _dtAllCasesForSpecificClient;
        private DataTable _dtCases;
        private void CasesColumnsFormatting()
        {
            dgvClientCases.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvClientCases.Columns["Title"].HeaderText = "وصف القضيه";
            dgvClientCases.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvClientCases.Columns["ClientStatus"].HeaderText = "حاله العميل";
            dgvClientCases.Columns["OpponentName"].HeaderText = "اسم الخصم";
            dgvClientCases.Columns["OpponentStatus"].HeaderText = "حاله الخصم";
        }

        private static int _clientId;
        public int ClientId
        {
            get { return _clientId; }
        }
        public frmShowClientInfo(int clientId)
        {
            _clientId = clientId;
            InitializeComponent();
        }

        private void frmShowClientInfo_Load(object sender, EventArgs e)
        {
            _dtAllCasesForSpecificClient = Case.GetAllCasesForSpecificClient(_clientId);
            _dtCases = _dtAllCasesForSpecificClient.DefaultView.ToTable(false, "CaseNumber", "Title", "ClientName",
            "ClientStatus", "OpponentName", "OpponentStatus");

            if (_dtCases.Rows.Count > 0)
            {

                dgvClientCases.DataSource = _dtCases;
                CasesColumnsFormatting();
            }
            else
            {
                dgvClientCases.DataSource = null;
            }

                ctrlClientInfo1.LoadClientInfo(ClientId);
            
            
        }

        private void tsmiShowCaseInfo_Click(object sender, EventArgs e)
        {
            if (dgvClientCases.Rows.Count > 0)
            {
                // Get caseId.
                int caseId = _dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] : 0;

                frmShowCaseInfo frm = new frmShowCaseInfo(caseId);
                frm.ShowDialog();

            }
        }

        private void tsmiEditCase_Click(object sender, EventArgs e)
        {
            if (dgvClientCases.Rows.Count > 0)
            {
                // Get caseId.
                int caseId = _dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] : 0;

                frmAddUpdateCase frm = new frmAddUpdateCase(caseId, frmAddUpdateCase.enMode.UpdateExisting);
                frm.ShowDialog();

                frmShowClientInfo_Load(null, null);


            }
        }

        private void tsmiAddCase_Click(object sender, EventArgs e)
        {
            frmAddUpdateCase frm = new frmAddUpdateCase(ClientId, frmAddUpdateCase.enMode.AddNew);
            frm.ShowDialog();

            frmShowClientInfo_Load(null, null);

        }

        private void tsmiDeleteCase_Click(object sender, EventArgs e)
        {
            if (dgvClientCases.Rows.Count > 0)
            {
                // 1. Get the Case ID and Title for the confirmation message
                // Assuming 'CaseId' is hidden in the grid and 'Title' is visible in column 1 (or adjust index as needed)
                // Using column names is safer than indexes.
                // Get caseId.
                int caseId = _dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] : 0;
                string caseTitle = dgvClientCases.CurrentRow.Cells[1].Value.ToString();

                // 2. Show Confirmation Message
                if (MessageBox.Show(
                            $"هل أنت متأكد أنك تريد حذف القضية بعنوان: {caseTitle} ؟",
                            "تأكيد الحذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // 3. Call the Business Layer to delete
                    if (Case.DeleteCase(caseId))
                    {
                        MessageBox.Show("تم حذف القضية بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Refresh the data grid
                        frmShowClientInfo_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف القضية. ربما حدث خطأ أو أن القضية مرتبطة ببيانات أخرى (مثل الجلسات أو المستندات).",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void tsmiAddSession_Click(object sender, EventArgs e)
        {
            if (dgvClientCases.Rows.Count > 0)
            {
                // Get caseId.
                int caseId = _dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCasesForSpecificClient.Rows[dgvClientCases.CurrentRow.Index]["CaseId"] : 0;

                frmAddUpdateSession frm = new frmAddUpdateSession(caseId, frmAddUpdateSession.enMode.AddNew);
                frm.ShowDialog();

            }
        }

        private void tsmiAddInvoice_Click(object sender, EventArgs e)
        {

        }
    }
}
