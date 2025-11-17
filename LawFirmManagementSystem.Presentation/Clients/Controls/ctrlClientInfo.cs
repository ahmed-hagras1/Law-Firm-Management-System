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

namespace LawFirmManagementSystem.Presentation
{
    public partial class ctrlClientInfo: UserControl
    {
        private int _clientId = -1;
        private Client _clientInfo;
        public int ClientId
        {
            get { return  _clientId; }
        }
        public Client ClientInfo
            { get { return _clientInfo; } }

        public ctrlClientInfo()
        {
            InitializeComponent();
        }

        private void ctrlClientInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadClientInfo(int clientId)
        {
            _clientId = clientId;
            _clientInfo = Client.GetClient(clientId);

            ctrlPersonalInfo1.LoadPersonInfo(ClientInfo.PersonId);
            lblJoinDate.Text = ClientInfo.TrackingChangesInfo.CreatedDate.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = ClientInfo.TrackingChangesInfo.CreatedByUserInfo.UserName.Trim();
            lblNotes.Text = ClientInfo.Notes.Trim();
        }
    }
}
