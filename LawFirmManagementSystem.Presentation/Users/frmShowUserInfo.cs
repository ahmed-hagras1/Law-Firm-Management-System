using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Users
{
    public partial class frmShowUserInfo: Form
    {
        int _userId;
        public int UserId
        {
            get { return _userId; }
        }
        public frmShowUserInfo(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadData(_userId);
        }

        private void ctrlUserInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
