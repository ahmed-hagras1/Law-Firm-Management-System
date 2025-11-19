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

namespace LawFirmManagementSystem.Presentation.Cases
{
    public partial class frmShowCaseInfo: Form
    {
        private int _caseId;
        public int CaseId
        {
            get { return _caseId; }
        }
        private Case _caseInfo;
        public Case CaseInfo
        {
            get { return _caseInfo; }
        }
        public frmShowCaseInfo(int caseId)
        {
            InitializeComponent();

            _caseId = caseId;

        }

        private void frmShowCaseInfo_Load(object sender, EventArgs e)
        {
            ctrlCaseInfo1.LoadData(CaseId);
        }

        private void btnShowCaseDocuments_Click(object sender, EventArgs e)
        {
            frmShowCaseInvoicesOrDocuments frm = new frmShowCaseInvoicesOrDocuments(CaseId, frmShowCaseInvoicesOrDocuments.enMode.ShowDocuments);
            frm.ShowDialog();
        }

        private void btnShowCaseInvoices_Click(object sender, EventArgs e)
        {
            frmShowCaseInvoicesOrDocuments frm = new frmShowCaseInvoicesOrDocuments(CaseId, frmShowCaseInvoicesOrDocuments.enMode.ShowInvoices);
            frm.ShowDialog();
        }
    }
}
