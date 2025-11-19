using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LawFirmManagementSystem_Business;

namespace LawFirmManagementSystem.Presentation.Cases.Controls
{
    public partial class ctrlCaseInfo: UserControl
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
        public ctrlCaseInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int caseId)
        {
            _caseId = caseId;
            _caseInfo = Case.GetCase(caseId);

            lblCaseNumber.Text = CaseInfo.CaseNumber.Trim();
            lblCourt.Text = CaseInfo.Court.Trim();
            lblTitle.Text = CaseInfo.Title.Trim();
            lblClientName.Text = CaseInfo.ClientName.Trim();
            lblClientStatus.Text = CaseInfo.ClientStatus.Trim();
            lblClientAddress.Text = CaseInfo.ClientAddress.Trim();
            lblClientPhone.Text = CaseInfo.ClientPhone.Trim();
            lblOppoinentName.Text = CaseInfo.OpponentName.Trim();
            lblOppoinentStatus.Text = CaseInfo.OpponentStatus.Trim();
            lblOppoinentAddress.Text = CaseInfo.OpponentAddress.Trim();
            lblOppoinentPhone.Text = CaseInfo.OpponentPhone.Trim();
            lblCreatedBy.Text = CaseInfo.TrackingChangesInfo.CreatedByUserInfo.UserName.Trim();
            lblNotes.Text = CaseInfo.Notes.Trim();


        }

        private void ctrlCaseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
