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

namespace LawFirmManagementSystem.Presentation.Sessions.Controls
{
    public partial class ctrlSessionInfo: UserControl
    {
        private int _sessionId;
        public int SessionId
        {
            get { return _sessionId; }
        }
        private Session _sessionInfo;
        public Session SessionInfo
        {
            get { return _sessionInfo; }
        }
        public ctrlSessionInfo()
        {
            InitializeComponent();
        }

        private void ctrlSessionInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadData(int sessionId)
        {
            _sessionId = sessionId;
            _sessionInfo = Session.GetSession(sessionId);

            // Check if session is found.
            if (_sessionInfo == null || _sessionInfo.SessionId == 0)
            {
                MessageBox.Show("لم يتم العثور على بيانات الجلسة المطلوبة.", "خطأ تحميل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlCaseInfo1.LoadData(_sessionInfo.CaseId);

            // Session Status.
            string statusText = (_sessionInfo.Date >= DateTime.Today) ? "قادمة / فعالة" : "انتهت";

            lblSessionNumber.Text = (_sessionInfo.RollNumber == 0) ? string.Empty : _sessionInfo.RollNumber.ToString();

            // تصحيح: استخدام .ToString() للتنسيق بدلاً من ToShortDateString()
            lblSessionDate.Text = _sessionInfo.Date.ToString("dd/MM/yyyy");

            // الحصول على اسم المحامي (باستخدام التعبير الشرطي الآمن)
            // نستخدم ?? "غير محدد" في حال لم يتم تحميل بيانات المحامي لأي سبب
            lblLawyerName.Text = _sessionInfo.LawyerInfo?.PersonInfo?.FullName ?? "غير محدد";

            lblStatus.Text = statusText;
            lblSessionRequests.Text = _sessionInfo.Requests;
            lblSessionDecision.Text = _sessionInfo.Decision;
            lblCourt.Text = _sessionInfo.Court;
        }
    }
}
