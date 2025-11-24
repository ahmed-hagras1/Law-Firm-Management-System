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

namespace LawFirmManagementSystem.Presentation.Users.Controls
{
    public partial class ctrlUserInfo: UserControl
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
        public void LoadData(int userId)
        {
            _userId = userId;
            _userInfo = User.GetUser(userId);

            lblUserName.Text = UserInfo.UserName.Trim();
            lblUserStatus.Text = UserInfo.IsActive ? "نشط" : "غير نشط";
            lblCreatedBy.Text = UserInfo.TrackingChangesInfo.CreatedByUserInfo.UserName.Trim();
            lblJoinDate.Text = UserInfo.TrackingChangesInfo.CreatedDate.ToString("dd-MM-yyyy");
            lblLastUpdatedBy.Text = UserInfo.TrackingChangesInfo.LastUpdatedByUserInfo.UserName;
            lblNotes.Text = UserInfo.Notes.Trim();
        }
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
