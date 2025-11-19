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
    public partial class frmShowCaseInvoicesOrDocuments: Form
    {
        public enum enMode { ShowInvoices = 0, ShowDocuments = 1 };
        private enMode _mode;
        public  enMode Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        private int _caseId;
        public int CaseId
        {
            get { return _caseId; }
        }
        private static DataTable _dtAllInvoicesForSpecificCase;
        private DataTable _dtInvoices;
        private void RefreshInvoicesList()
        {
            _dtAllInvoicesForSpecificCase = Invoice.GetAllInvoicesForSpecificCase(CaseId);
            _dtInvoices = _dtAllInvoicesForSpecificCase.DefaultView.ToTable(false, "ClientName", "CaseNumber", "CreatedBy",
                "IssueDate", "TotalAmount", "AmountPaid", "AmountDue");

        }
        private void InvoicesColumnsFormatting()
        {
            dgvCaseInvoicesOrDocuments.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvCaseInvoicesOrDocuments.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvCaseInvoicesOrDocuments.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvCaseInvoicesOrDocuments.Columns["IssueDate"].HeaderText = "تاريخ الاصدار";
            dgvCaseInvoicesOrDocuments.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCaseInvoicesOrDocuments.Columns["TotalAmount"].HeaderText = "المبلغ الكلي";
            dgvCaseInvoicesOrDocuments.Columns["AmountPaid"].HeaderText = "المبلغ المدفوع";
            dgvCaseInvoicesOrDocuments.Columns["AmountDue"].HeaderText = "المبلغ المتبقي";

        }

        private static DataTable _dtAllDocumentsForSpecificCase;
        private DataTable _dtDocuments;
        private void RefreshDocumentsList()
        {
            _dtAllDocumentsForSpecificCase = Document.GetAllDocumentsForSpecificCase(CaseId);
            _dtDocuments = _dtAllDocumentsForSpecificCase.DefaultView.ToTable(false, "CaseNumber", "CreatedBy",
                "FileName", "Notes");

        }
        private void DocumentsColumnsFormatting()
        {
            dgvCaseInvoicesOrDocuments.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvCaseInvoicesOrDocuments.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvCaseInvoicesOrDocuments.Columns["FileName"].HeaderText = "اسم الملف";
            dgvCaseInvoicesOrDocuments.Columns["Notes"].HeaderText = "ملاحظات";

        }
        public frmShowCaseInvoicesOrDocuments(int caseId, enMode mode)
        {
            InitializeComponent();
            if (mode == enMode.ShowInvoices)
            {
                _caseId = caseId;
                _mode = enMode.ShowInvoices;
                lblTitle.Text = "الفواتير الخاصة بالقضية";
                dgvCaseInvoicesOrDocuments.ContextMenuStrip = cmsInvoices;
            }
            else if (mode == enMode.ShowDocuments)
            {
                _caseId = caseId;
                _mode = enMode.ShowDocuments;
                lblTitle.Text = "المستندات الخاصة بالقضية";
                dgvCaseInvoicesOrDocuments.ContextMenuStrip = cmsDocuments;

            }

        }

        private void frmShowCaseInvoices_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.ShowInvoices)
            {
                RefreshInvoicesList();

                if (_dtInvoices.Rows.Count > 0)
                {
                    dgvCaseInvoicesOrDocuments.DataSource = _dtInvoices;
                    InvoicesColumnsFormatting();

                }
            }
            else if (Mode == enMode.ShowDocuments)
            {
                RefreshDocumentsList();

                if (_dtDocuments.Rows.Count > 0)
                {
                    dgvCaseInvoicesOrDocuments.DataSource = _dtDocuments;
                    DocumentsColumnsFormatting();
                }

            }
            
        }

        private void dgvCaseInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsmiOpenDocument_Click(object sender, EventArgs e)
        {
            string number = (string)dgvCaseInvoicesOrDocuments.CurrentRow.Cells[0].Value;
        }

    }
}
