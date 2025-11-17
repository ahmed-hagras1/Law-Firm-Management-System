using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LawFirmManagementSystem.Business;

namespace LawFirmManagementSystem.Presentation
{
    public partial class ctrlPersonalInfo: UserControl
    {
        private int _personId;
        private Person _personInfo = null;
        public int PersonId
        {
            get { return _personId; }
        }
        public Person PersonInfo
        {
            get { return _personInfo; }
        }
        public ctrlPersonalInfo()
        {
            InitializeComponent();
        }

        private void ctrlPersonalInfo_Load(object sender, EventArgs e)
        {

        }
        public void LoadPersonInfo(int personId)
        {
            _personId = personId;
            _personInfo = Person.GetPerson(personId);


            lblName.Text = _personInfo.FullName;
            lblPhone.Text = _personInfo.Phone;
            lblAddress.Text = _personInfo.Address;
        }
    }
}
