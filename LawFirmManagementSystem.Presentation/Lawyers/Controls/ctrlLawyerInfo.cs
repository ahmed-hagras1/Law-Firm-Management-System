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

namespace LawFirmManagementSystem.Presentation.Lawyers
{
    public partial class ctrlLawyerInfo: UserControl
    {
        private int _lawyerId;
        private Lawyer _lawyerInfo;
        public int LawyerId
        {
            get { return _lawyerId; }
        }
        public Lawyer LawyerInfo
        {
            get { return _lawyerInfo; }
        }
        public ctrlLawyerInfo()
        {
            InitializeComponent();
        }

        private void ctrlLawyerInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadLawyerInfo(int lawyerId)
        {
            _lawyerId = lawyerId;
            _lawyerInfo = Lawyer.GetLawyer(lawyerId);
            ctrlPersonalInfo1.LoadPersonInfo(LawyerInfo.PersonId);

            lblJoinDate.Text = LawyerInfo.TrackingChangesInfo.CreatedDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = LawyerInfo.TrackingChangesInfo.CreatedByUserInfo.UserName.Trim();
            lblNotes.Text = LawyerInfo.Notes.Trim();
        }
    }
}
