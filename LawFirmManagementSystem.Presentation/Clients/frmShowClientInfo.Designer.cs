namespace LawFirmManagementSystem.Presentation
{
    partial class frmShowClientInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClientCases = new System.Windows.Forms.DataGridView();
            this.cmsCases = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.tsmiShowCaseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEditCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSession = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlClientInfo1 = new LawFirmManagementSystem.Presentation.ctrlClientInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientCases)).BeginInit();
            this.cmsCases.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(843, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "معلومات العميل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvClientCases
            // 
            this.dgvClientCases.AllowUserToAddRows = false;
            this.dgvClientCases.AllowUserToDeleteRows = false;
            this.dgvClientCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientCases.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientCases.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientCases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientCases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientCases.ContextMenuStrip = this.cmsCases;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientCases.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientCases.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClientCases.Location = new System.Drawing.Point(0, 619);
            this.dgvClientCases.MultiSelect = false;
            this.dgvClientCases.Name = "dgvClientCases";
            this.dgvClientCases.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClientCases.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientCases.RowHeadersWidth = 51;
            this.dgvClientCases.RowTemplate.Height = 24;
            this.dgvClientCases.Size = new System.Drawing.Size(843, 242);
            this.dgvClientCases.TabIndex = 27;
            // 
            // cmsCases
            // 
            this.cmsCases.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCases.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsCases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowCaseInfo,
            this.toolStripSeparator4,
            this.tsmiAddCase,
            this.tsmiEditCase,
            this.tsmiDeleteCase,
            this.toolStripSeparator5,
            this.tsmiAddSession,
            this.tsmiAddDocument,
            this.tsmiAddInvoice});
            this.cmsCases.Name = "cmsClients";
            this.cmsCases.Size = new System.Drawing.Size(291, 296);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(287, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(287, 6);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 540);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(819, 51);
            this.label2.TabIndex = 28;
            this.label2.Text = "القضايا الخاصه بالعميل";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsmiShowCaseInfo
            // 
            this.tsmiShowCaseInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowIcon;
            this.tsmiShowCaseInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowCaseInfo.Name = "tsmiShowCaseInfo";
            this.tsmiShowCaseInfo.Size = new System.Drawing.Size(290, 36);
            this.tsmiShowCaseInfo.Text = "عرض معلومات القضيه";
            this.tsmiShowCaseInfo.Click += new System.EventHandler(this.tsmiShowCaseInfo_Click);
            // 
            // tsmiAddCase
            // 
            this.tsmiAddCase.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddCaseIcon;
            this.tsmiAddCase.Name = "tsmiAddCase";
            this.tsmiAddCase.Size = new System.Drawing.Size(290, 36);
            this.tsmiAddCase.Text = "اضافه قضيه";
            this.tsmiAddCase.Click += new System.EventHandler(this.tsmiAddCase_Click);
            // 
            // tsmiEditCase
            // 
            this.tsmiEditCase.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiEditCase.Name = "tsmiEditCase";
            this.tsmiEditCase.Size = new System.Drawing.Size(290, 36);
            this.tsmiEditCase.Text = "تعديل القضيه";
            this.tsmiEditCase.Click += new System.EventHandler(this.tsmiEditCase_Click);
            // 
            // tsmiDeleteCase
            // 
            this.tsmiDeleteCase.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteCase.Name = "tsmiDeleteCase";
            this.tsmiDeleteCase.Size = new System.Drawing.Size(290, 36);
            this.tsmiDeleteCase.Text = "ازاله القضيه";
            this.tsmiDeleteCase.Click += new System.EventHandler(this.tsmiDeleteCase_Click);
            // 
            // tsmiAddSession
            // 
            this.tsmiAddSession.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewIcon2;
            this.tsmiAddSession.Name = "tsmiAddSession";
            this.tsmiAddSession.Size = new System.Drawing.Size(290, 36);
            this.tsmiAddSession.Text = "اضافه جلسه";
            this.tsmiAddSession.Click += new System.EventHandler(this.tsmiAddSession_Click);
            // 
            // tsmiAddDocument
            // 
            this.tsmiAddDocument.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.add_file;
            this.tsmiAddDocument.Name = "tsmiAddDocument";
            this.tsmiAddDocument.Size = new System.Drawing.Size(290, 36);
            this.tsmiAddDocument.Text = "اضافه ملف";
            // 
            // tsmiAddInvoice
            // 
            this.tsmiAddInvoice.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddInvoiceIcon;
            this.tsmiAddInvoice.Name = "tsmiAddInvoice";
            this.tsmiAddInvoice.Size = new System.Drawing.Size(290, 36);
            this.tsmiAddInvoice.Text = "اضافه فاتوره";
            this.tsmiAddInvoice.Click += new System.EventHandler(this.tsmiAddInvoice_Click);
            // 
            // ctrlClientInfo1
            // 
            this.ctrlClientInfo1.Location = new System.Drawing.Point(28, 37);
            this.ctrlClientInfo1.Name = "ctrlClientInfo1";
            this.ctrlClientInfo1.Size = new System.Drawing.Size(787, 500);
            this.ctrlClientInfo1.TabIndex = 29;
            // 
            // frmShowClientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 861);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlClientInfo1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvClientCases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowClientInfo";
            this.Text = "عرض معلومات العميل";
            this.Load += new System.EventHandler(this.frmShowClientInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientCases)).EndInit();
            this.cmsCases.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClientCases;
        private System.Windows.Forms.Label label2;
        private ctrlClientInfo ctrlClientInfo1;
        private System.Windows.Forms.ContextMenuStrip cmsCases;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowCaseInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditCase;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSession;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCase;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddInvoice;
    }
}