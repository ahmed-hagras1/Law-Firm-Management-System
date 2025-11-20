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
    public partial class frmShowSessionInfo: Form
    {
        private int _sessionId;
        public int SessionId
        {
            get { return _sessionId; }
        }
        public frmShowSessionInfo(int sessionId)
        {
            InitializeComponent();

            _sessionId = sessionId;
        }

        private void frmShowSessionInfo_Load(object sender, EventArgs e)
        {
            ctrlSessionInfo1.LoadData(SessionId);
        }
    }
}
