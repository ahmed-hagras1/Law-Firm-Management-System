using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Presentation.Global_classes;
using LawFirmManagementSystem.Presentation.Properties;
using LawFirmManagementSystem_Business;
using Spire.Xls;
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


namespace LawFirmManagementSystem.Presentation.Documents
{
    public partial class frmAddUpdateDocument : Form
    {
        public enum enMode { AddNewDocument = 0, UpdateDocument = 1 };
        private enMode _mode;
        private enum enDeleteMode { NoDelete = 0, DeleteOnSave = 1 };
        private enDeleteMode _deleteMode;
        private int _documentId;
        public int DocumentId => _documentId;

        private Document _documentInfo;
        public Document DocumentInfo => _documentInfo;

        private int _caseId;
        public int CaseId
        {
            get
            {
                if (_mode == enMode.AddNewDocument)
                    return _caseId;
                else
                    return _documentInfo.CaseId;
            }
        }

        private Case _caseInfo;
        public Case CaseInfo
        {
            get
            {
                if (_mode == enMode.AddNewDocument)
                    return _caseInfo;
                else
                    return _documentInfo.CaseInfo;
            }
        }

        // NEW: store the original selected file path (image or document)
        private string _selectedFilePath = null;
        private List<string> _DeletedFiles = new List<string>();

        public frmAddUpdateDocument(int id, enMode mode)
        {
            InitializeComponent();

            _mode = mode;

            if (mode == enMode.AddNewDocument)
            {
                _caseId = id;
                _caseInfo = Case.GetCase(_caseId);
                _documentInfo = new Document();
            }
            else
            {
                _documentId = id;
                _documentInfo = Document.GetDocument(_documentId);
            }
        }

        private void _loadData()
        {
            // Load data into form controls based on _documentInfo
            if (DocumentInfo == null)
            {
                MessageBox.Show("خطأ في تحميل بيانات المستند.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNotes.Enabled = txtFileName.Enabled = llSetFile.Enabled = llRemoveFile.Enabled = false;
                return;
            }

            txtFileName.Text = _documentInfo.FileName;
            txtNotes.Text = _documentInfo.Notes;

            // If saved file path exists, show preview
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LawFirmManagementSystemFiles", DocumentInfo.FilePath ?? "");
            if (!string.IsNullOrWhiteSpace(DocumentInfo.FilePath) && File.Exists(filePath))
            {
                // set selected file path so _HandleFileImage knows nothing changed
                _selectedFilePath = filePath;

                string ext = Path.GetExtension(DocumentInfo.FilePath).ToLower();
                SafeSetPictureBoxPreview(_selectedFilePath, ext);
            }
            else
            {
                pbFile.ImageLocation = null;
                pbFile.Image = Resources.FileImage; // default icon
            }

            llRemoveFile.Visible = (_selectedFilePath != null);
            llSetFile.Visible = !llRemoveFile.Visible;
        }

        private void frmAddUpdateDocument_Load(object sender, EventArgs e)
        {
            if (_mode == enMode.AddNewDocument)
            {
                lblTitle.Text = "إضافة مستند جديد";
                this.Text = "إضافة مستند جديد";
            }
            else
            {
                lblTitle.Text = "تحديث بيانات المستند";
                this.Text = "تحديث بيانات المستند";
                _loadData();
            }
        }

        private bool IsImage(string ext)
        {
            string[] imageExt = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".svg" };
            return imageExt.Contains(ext);
        }

        // Load image bytes without locking the source file
        private Bitmap LoadImageWithoutLock(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (var img = Image.FromStream(fs))
                {
                    return new Bitmap(img);
                }
            }
        }

        // Safe wrapper to set preview into PictureBox (disposes old image)
        private void SafeSetPictureBoxPreview(string path, string ext)
        {
            // Dispose previous image
            if (pbFile.Image != null)
            {
                try
                {
                    // 1. Remove the reference so the PictureBox stops looking at it
                    var oldImage = pbFile.Image;
                    pbFile.Image = null;

                    // 2. Now it is safe to destroy the image from memory
                    oldImage.Dispose();
                }
                catch { }
            }

            try
            {
                if (IsImage(ext))
                {
                    pbFile.Image = LoadImageWithoutLock(path);
                }
                else if (ext == ".pdf")
                {
                    pbFile.Image = Resources.pdf;
                }
                else if (ext == ".docx")
                {
                    pbFile.Image = Resources.Word;
                }
                else if (ext == ".xlsx")
                {
                    pbFile.Image = Resources.excel;
                }
                else
                {
                    pbFile.Image = Resources.FileImage;
                }
            }
            catch
            {
                // fallback icon on any rendering issue
                pbFile.Image = Resources.FileImage;
            }
        }

        private bool _HandleFileImage()
        {
            // If nothing selected -> no changes
            if (string.IsNullOrWhiteSpace(_selectedFilePath))
            {
                // If previously there was a file and user removed it, DocumentInfo.FilePath might need to be cleared elsewhere
                return true;
            }

            // If the selected file path is same as current stored path, nothing to do
            if (!string.IsNullOrWhiteSpace(DocumentInfo.FilePath) &&
                Path.GetFullPath(DocumentInfo.FilePath).Equals(Path.GetFullPath(_selectedFilePath), StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

           

            // Copy selected file into project files folder and update DocumentInfo.FilePath
            string sourceFile = _selectedFilePath;
            string destFile = sourceFile; // will be replaced by utility

            if (Utility.CopyFileToProjectFilesFolder(ref destFile))
            {
                // destFile now contains something like:
                // C:\ProjectFiles\123e4567-e89b-12d3-a456-426614174000.pdf

                // Extract only "GUID.ext"
                string fileNameOnly = Path.GetFileName(destFile);

                // Save it to DB
                DocumentInfo.FilePath = fileNameOnly;

                return true;
            }
            else
            {
                MessageBox.Show("Error copying file to project folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void llSetFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog.Filter =
                "Supported Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp;*.svg;*.pdf;*.docx;*.xlsx|" +
                "Images|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp;*.svg|" +
                "PDF Files|*.pdf|" +
                "Word Documents|*.docx|" +
                "Excel Files|*.xlsx|" +
                "All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                string ext = Path.GetExtension(path).ToLower();

                // store selected file path (used during save/copy)
                _selectedFilePath = path;

                // Show preview safely
                SafeSetPictureBoxPreview(path, ext);

                llRemoveFile.Visible = true;
                llSetFile.Visible = false;
            }
        }

        private void llRemoveFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Clear selection (but do NOT delete from project files until user saves)
            _selectedFilePath = null;

            // Dispose previous image
            if (pbFile.Image != null)
            {
                try
                {
                    pbFile.Image.Dispose();
                }
                catch { }
                pbFile.Image = null;
            }


            pbFile.Image = Resources.FileImage;
            pbFile.ImageLocation = null;
            llRemoveFile.Visible = false;
            llSetFile.Visible = true;

            // Delete old file if exists and stored in DocumentInfo.FilePath
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "LawFirmManagementSystemFiles", DocumentInfo.FilePath ?? "");
            _DeletedFiles.Add(filePath);

            //if (!string.IsNullOrWhiteSpace(DocumentInfo.FilePath) &&
            //    File.Exists(filePath))
            //{
            //    try
            //    {
            //        File.Delete(filePath);
            //    }
            //    catch (Exception)
            //    {
            //        // ignore delete errors, or you can notify user
            //    }
            //}


            DocumentInfo.FilePath = null;
        }

        private delegate bool ValidateDataDelegate(ref string errorMessage, string text);

        private bool ValidateFileName(ref string errorMessage, string text)
        {
            // Empty input
            if (string.IsNullOrWhiteSpace(text))
            {
                errorMessage = "يجب ادخال اسم الملف.";
                return true; // there is an error
            }

            return false; // No errors
        }

        private void Validate(object sender, CancelEventArgs e, ValidateDataDelegate validateData)
        {
            TextBox textBox = (TextBox)sender;
            string errorMessage = default;

            if (validateData(ref errorMessage, textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, errorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtFileName_Validating(object sender, CancelEventArgs e)
        {
            Validate(sender, e, ValidateFileName);
        }
        // Delete all files that were marked for deletion
        // deleteMode: NoDelete = only on form close; DeleteOnSave = on save
        // If NoDelete, skip first file (to allow rollback on form close)
        private void _DeleteAllFilesAlreadyDeleted(enDeleteMode deleteMode)
        {
            if (_DeletedFiles.Count > 0)
            {
                for (int i = 0; i < _DeletedFiles.Count; i++)
                {
                    string filePath = _DeletedFiles[i];

                    if (deleteMode == enDeleteMode.NoDelete && i == 0)
                        continue;

                    if (File.Exists(filePath))
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

                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            // Ensure user selected a file (either previously saved or newly selected)
            if (string.IsNullOrWhiteSpace(_selectedFilePath) && string.IsNullOrWhiteSpace(DocumentInfo?.FilePath))
            {
                MessageBox.Show("يجب اختيار ملف للمستند.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DeleteAllFilesAlreadyDeleted(enDeleteMode.DeleteOnSave);
            _DeletedFiles.Clear();

            // copy selected file into project folder and update DocumentInfo.FilePath
            if (!string.IsNullOrWhiteSpace(_selectedFilePath))
            {
                if (!_HandleFileImage())
                    return;
            }

            // Map UI -> Business
            _documentInfo.FileName = txtFileName.Text.Trim();
            _documentInfo.Notes = txtNotes.Text.Trim();
            // DocumentInfo.FilePath already updated by _HandleFileImage if needed; otherwise keep existing value

            if (_mode == enMode.AddNewDocument)
            {
                _documentInfo.CaseId = _caseId;
                _documentInfo.TrackingChangesInfo.CreatedBy = 1;  // TODO: replace actual user ID
                if (_document_info_save())
                {
                    // success handled inside helper
                }
            }
            else
            {
                _documentInfo.TrackingChangesInfo.LastUpdatedBy = 1;  // TODO: replace actual user ID
                if (_document_info_save())
                {
                    // success handled inside helper
                }
            }
        }

        // Small helper to avoid duplicate code for saving and showing messages
        private bool _document_info_save()
        {
            if (_documentInfo.SaveDocument())
            {
                if (_mode == enMode.AddNewDocument)
                {
                    MessageBox.Show("تم اضافه المستند بنجاح.", "اضافه مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Switch mode
                    _mode = enMode.UpdateDocument;
                    _documentId = _documentInfo.DocumentId;
                    lblTitle.Text = "تحديث بيانات المستند";
                    this.Text = "تحديث بيانات المستند";
                }
                else
                {
                    MessageBox.Show("تم تحديث بيانات المستند بنجاح.", "تحديث مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            else
            {
                MessageBox.Show("حدث خطأ اثناء حفظ بيانات المستند.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void frmAddUpdateDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            _DeleteAllFilesAlreadyDeleted(enDeleteMode.NoDelete);

            // If there are any deleted files left, it means user removed a file but did not save
            if (_DeletedFiles.Count > 0)
            {
                DocumentInfo.FilePath = Path.GetFileName(_DeletedFiles[0]);
            }
            
            _DeletedFiles.Clear();

        }
    }
}