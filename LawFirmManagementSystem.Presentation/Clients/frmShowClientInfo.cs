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

        private void RefreshCasesList()
        {
            _dtAllCasesForSpecificClient = Case.GetAllCasesForSpecificClient(_clientId);
            _dtCases = _dtAllCasesForSpecificClient.DefaultView.ToTable(false, "CaseId", "CaseNumber", "Title", "ClientName",
            "ClientStatus", "OpponentName", "OpponentStatus");
        }
        private void CasesColumnsFormatting()
        {
            dgvClientCases.Columns["CaseId"].HeaderText = "ترتيب القضيه";
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
            RefreshCasesList();

            if (_dtCases.Rows.Count > 0)
            {

                dgvClientCases.DataSource = _dtCases;
                CasesColumnsFormatting();
            }

            ctrlClientInfo1.LoadClientInfo(ClientId);
            
            
        }
    }
}
