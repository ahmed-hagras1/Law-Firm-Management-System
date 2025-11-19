namespace LawFirmManagementSystem.Presentation.Cases
{
    partial class frmShowCaseInvoicesOrDocuments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCaseInvoicesOrDocuments = new System.Windows.Forms.DataGridView();
            this.cmsInvoices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsDocuments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowInvoiceInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowClientInfoForInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddNewPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowDocumentInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseInvoicesOrDocuments)).BeginInit();
            this.cmsInvoices.SuspendLayout();
            this.cmsDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(776, 50);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "العنوان";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCaseInvoicesOrDocuments
            // 
            this.dgvCaseInvoicesOrDocuments.AllowUserToAddRows = false;
            this.dgvCaseInvoicesOrDocuments.AllowUserToDeleteRows = false;
            this.dgvCaseInvoicesOrDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaseInvoicesOrDocuments.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaseInvoicesOrDocuments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaseInvoicesOrDocuments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCaseInvoicesOrDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseInvoicesOrDocuments.ContextMenuStrip = this.cmsInvoices;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaseInvoicesOrDocuments.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCaseInvoicesOrDocuments.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCaseInvoicesOrDocuments.Location = new System.Drawing.Point(0, 91);
            this.dgvCaseInvoicesOrDocuments.MultiSelect = false;
            this.dgvCaseInvoicesOrDocuments.Name = "dgvCaseInvoicesOrDocuments";
            this.dgvCaseInvoicesOrDocuments.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaseInvoicesOrDocuments.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCaseInvoicesOrDocuments.RowHeadersWidth = 51;
            this.dgvCaseInvoicesOrDocuments.RowTemplate.Height = 24;
            this.dgvCaseInvoicesOrDocuments.Size = new System.Drawing.Size(800, 359);
            this.dgvCaseInvoicesOrDocuments.TabIndex = 28;
            this.dgvCaseInvoicesOrDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaseInvoices_CellContentClick);
            // 
            // cmsInvoices
            // 
            this.cmsInvoices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInvoices.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsInvoices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowInvoiceInfo,
            this.tsmiShowClientInfoForInvoices,
            this.toolStripSeparator7,
            this.tsmiUpdateInvoice,
            this.tsmiDeleteInvoice,
            this.toolStripSeparator8,
            this.tsmiAddNewPayment});
            this.cmsInvoices.Name = "cmsClients";
            this.cmsInvoices.Size = new System.Drawing.Size(292, 196);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(288, 6);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(288, 6);
            // 
            // cmsDocuments
            // 
            this.cmsDocuments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsDocuments.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsDocuments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenDocument,
            this.toolStripSeparator2,
            this.tsmiShowDocumentInfo,
            this.toolStripSeparator1,
            this.tsmiAddDocument,
            this.tsmiEditDocument,
            this.tsmiDeleteDocument});
            this.cmsDocuments.Name = "cmsClients";
            this.cmsDocuments.Size = new System.Drawing.Size(283, 224);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // tsmiShowInvoiceInfo
            // 
            this.tsmiShowInvoiceInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowinvoiceInfo1;
            this.tsmiShowInvoiceInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowInvoiceInfo.Name = "tsmiShowInvoiceInfo";
            this.tsmiShowInvoiceInfo.Size = new System.Drawing.Size(291, 36);
            this.tsmiShowInvoiceInfo.Text = "عرض معلومات الفاتوره";
            // 
            // tsmiShowClientInfoForInvoices
            // 
            this.tsmiShowClientInfoForInvoices.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.PersonDetails_32;
            this.tsmiShowClientInfoForInvoices.Name = "tsmiShowClientInfoForInvoices";
            this.tsmiShowClientInfoForInvoices.Size = new System.Drawing.Size(291, 36);
            this.tsmiShowClientInfoForInvoices.Text = "عرض معلومات العميل";
            // 
            // tsmiUpdateInvoice
            // 
            this.tsmiUpdateInvoice.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiUpdateInvoice.Name = "tsmiUpdateInvoice";
            this.tsmiUpdateInvoice.Size = new System.Drawing.Size(291, 36);
            this.tsmiUpdateInvoice.Text = "تعديل الفاتوره";
            // 
            // tsmiDeleteInvoice
            // 
            this.tsmiDeleteInvoice.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteInvoice.Name = "tsmiDeleteInvoice";
            this.tsmiDeleteInvoice.Size = new System.Drawing.Size(291, 36);
            this.tsmiDeleteInvoice.Text = "ازاله الفاتوره";
            // 
            // tsmiAddNewPayment
            // 
            this.tsmiAddNewPayment.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewPayment;
            this.tsmiAddNewPayment.Name = "tsmiAddNewPayment";
            this.tsmiAddNewPayment.Size = new System.Drawing.Size(291, 36);
            this.tsmiAddNewPayment.Text = "اضافه عمليه دفع";
            // 
            // tsmiOpenDocument
            // 
            this.tsmiOpenDocument.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.OpenDocumentIcon;
            this.tsmiOpenDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiOpenDocument.Name = "tsmiOpenDocument";
            this.tsmiOpenDocument.Size = new System.Drawing.Size(282, 36);
            this.tsmiOpenDocument.Text = "فتح الملف";
            this.tsmiOpenDocument.Click += new System.EventHandler(this.tsmiOpenDocument_Click);
            // 
            // tsmiShowDocumentInfo
            // 
            this.tsmiShowDocumentInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.DocumentsIcon;
            this.tsmiShowDocumentInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowDocumentInfo.Name = "tsmiShowDocumentInfo";
            this.tsmiShowDocumentInfo.Size = new System.Drawing.Size(282, 36);
            this.tsmiShowDocumentInfo.Text = "عرض معلومات الملف";
            // 
            // tsmiAddDocument
            // 
            this.tsmiAddDocument.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddDocument;
            this.tsmiAddDocument.Name = "tsmiAddDocument";
            this.tsmiAddDocument.Size = new System.Drawing.Size(282, 36);
            this.tsmiAddDocument.Text = "اضافه ملف";
            // 
            // tsmiEditDocument
            // 
            this.tsmiEditDocument.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiEditDocument.Name = "tsmiEditDocument";
            this.tsmiEditDocument.Size = new System.Drawing.Size(282, 36);
            this.tsmiEditDocument.Text = "تعديل الملف";
            // 
            // tsmiDeleteDocument
            // 
            this.tsmiDeleteDocument.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteDocument.Name = "tsmiDeleteDocument";
            this.tsmiDeleteDocument.Size = new System.Drawing.Size(282, 36);
            this.tsmiDeleteDocument.Text = "ازاله الملف";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(279, 6);
            // 
            // frmShowCaseInvoicesOrDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCaseInvoicesOrDocuments);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowCaseInvoicesOrDocuments";
            this.Text = "frmShowCaseInvoices";
            this.Load += new System.EventHandler(this.frmShowCaseInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseInvoicesOrDocuments)).EndInit();
            this.cmsInvoices.ResumeLayout(false);
            this.cmsDocuments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCaseInvoicesOrDocuments;
        private System.Windows.Forms.ContextMenuStrip cmsInvoices;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowInvoiceInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowClientInfoForInvoices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPayment;
        private System.Windows.Forms.ContextMenuStrip cmsDocuments;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDocumentInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}