using LawFirmManagementSystem.Presentation.Documents;
using LawFirmManagementSystem.Presentation.Global_classes;
using LawFirmManagementSystem.Presentation.Invoices;
using LawFirmManagementSystem.Presentation.Payments;
using LawFirmManagementSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation.Cases
{
    public partial class frmShowCaseInvoicesOrDocuments: Form
    {
        public enum enMode { ShowInvoices = 0, ShowDocuments = 1};
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
            _dtDocuments = _dtAllDocumentsForSpecificCase.DefaultView.ToTable(false, "Title", "FileName",  "CreatedBy", "LastUpdatedBy"
                , "Notes");

        }
        private void DocumentsColumnsFormatting()
        {
            dgvCaseInvoicesOrDocuments.Columns["Title"].HeaderText = "وصف القضيه";
            dgvCaseInvoicesOrDocuments.Columns["FileName"].HeaderText = "اسم الملف";
            dgvCaseInvoicesOrDocuments.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvCaseInvoicesOrDocuments.Columns["LastUpdatedBy"].HeaderText = "اخر تحديث بواسطه";
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
                this.Text = "الفواتير الخاصة بالقضية";
                dgvCaseInvoicesOrDocuments.ContextMenuStrip = cmsInvoices;
            }
            else if (mode == enMode.ShowDocuments)
            {
                _caseId = caseId;
                _mode = enMode.ShowDocuments;
                lblTitle.Text = "المستندات الخاصة بالقضية";
                this.Text = "المستندات الخاصة بالقضية";
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
                else
                {
                    dgvCaseInvoicesOrDocuments.DataSource = null;
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
                else
                {
                    dgvCaseInvoicesOrDocuments.DataSource = null;
                }

            }
            
        }

        private void dgvCaseInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void tsmiShowInvoiceInfo_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {
                // Get invoiceId.
                int invoiceId = _dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] != DBNull.Value ?
                    (int)_dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] : 0;

                frmShowInvoiceInfo frm = new frmShowInvoiceInfo(invoiceId, (decimal)dgvCaseInvoicesOrDocuments.CurrentRow.Cells[5].Value, (decimal)dgvCaseInvoicesOrDocuments.CurrentRow.Cells[6].Value);
                frm.ShowDialog();

                // Refresh the data grid
                frmShowCaseInvoices_Load(null, null);

            }
        }

        private void tsmiUpdateInvoice_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {
                // Get invoiceId.
                int invoiceId = _dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] != DBNull.Value ?
                    (int)_dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] : 0;

                frmAddUpdateInvoice frm = new frmAddUpdateInvoice(invoiceId, (decimal)dgvCaseInvoicesOrDocuments.CurrentRow.Cells[5].Value);
                frm.ShowDialog();

                frmShowCaseInvoices_Load(null, null);

            }
        }

        private void tsmiDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {
                // Get invoiceId.
                int invoiceId = _dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] != DBNull.Value ?
                    (int)_dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] : 0;


                // 2. Show Confirmation Message
                if (MessageBox.Show(
                            $"هل أنت متأكد أنك تريد حذف الفاتوره؟",
                            "تأكيد الحذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // 3. Call the Business Layer to delete
                    if (Invoice.DeleteInvoice(invoiceId))
                    {
                        MessageBox.Show("تم حذف الفاتوره بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Refresh the data grid
                        frmShowCaseInvoices_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف الفاتوره.",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void tsmiAddNewPayment_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {
                // Get invoiceId.
                int invoiceId = _dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] != DBNull.Value ?
                    (int)_dtAllInvoicesForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["InvoiceId"] : 0;

                frmAddUpdatePayment frm = new frmAddUpdatePayment(invoiceId, (decimal)dgvCaseInvoicesOrDocuments.CurrentRow.Cells[6].Value, frmAddUpdatePayment.enMode.AddNew);
                frm.ShowDialog();

                frmShowCaseInvoices_Load(null, null);

            }
        }

        private void tsmiAddDocument_Click(object sender, EventArgs e)
        {

            frmAddUpdateDocument frm = new frmAddUpdateDocument(CaseId, frmAddUpdateDocument.enMode.AddNewDocument);
            frm.ShowDialog();
        }

        private void tsmiEditDocument_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {
                // Get DocumentId.
                int documentId = _dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["DocumentId"] != DBNull.Value ?
                    (int)_dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["DocumentId"] : 0;

                frmAddUpdateDocument frm = new frmAddUpdateDocument(documentId, frmAddUpdateDocument.enMode.UpdateDocument);
                frm.ShowDialog();

                frmShowCaseInvoices_Load(null, null);

            }
        }

        private void tsmiDeleteDocument_Click(object sender, EventArgs e)
        {
            // Check if there are rows to delete
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {
                // 1. Get DocumentId
                int documentId = _dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["DocumentId"] != DBNull.Value ?
                    (int)_dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["DocumentId"] : 0;

                string fileName = _dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["FilePath"] != DBNull.Value ?
                    (string)_dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["FilePath"] : string.Empty;
                // Delete old file if exists and stored in DocumentInfo.FilePath
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LawFirmManagementSystemFiles", fileName ?? "");
                if (!string.IsNullOrWhiteSpace(fileName) &&
                    File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception)
                    {
                        // ignore delete errors, or you can notify user
                    }
                }

                // 2. Ask for user confirmation (Arabic)
                if (MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا المستند؟", "تأكيد الحذف",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // 3. Call your Business Layer to delete
                    if (Document.DeleteDocument(documentId))
                    {
                        MessageBox.Show("تم حذف المستند بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Refresh the grid
                        frmShowCaseInvoices_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("فشل في حذف المستند.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void tsmiOpenDocument_Click(object sender, EventArgs e)
        {
            if (dgvCaseInvoicesOrDocuments.Rows.Count > 0)
            {

                try
                {
                    // 1. Get DocumentId
                    int documentId = _dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["DocumentId"] != DBNull.Value ?
                        (int)_dtAllDocumentsForSpecificCase.Rows[dgvCaseInvoicesOrDocuments.CurrentRow.Index]["DocumentId"] : 0;

                    Document documentInfo = Document.GetDocument(documentId);

                    // Get stored file path
                    string filePath = System.IO.Directory.GetCurrentDirectory() + @"\LawFirmManagementSystemFiles\" + documentInfo?.FilePath;

                    if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                    {
                        MessageBox.Show("الملف غير موجود أو تم نقله.",
                            "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Open file with the default app
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء فتح الملف:\n" + ex.Message,
                        "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
