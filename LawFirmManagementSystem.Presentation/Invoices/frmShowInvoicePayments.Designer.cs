namespace LawFirmManagementSystem.Presentation.Invoices
{
    partial class frmShowInvoicePayments
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
            this.dgvCaseInvoicesOrDocuments = new System.Windows.Forms.DataGridView();
            this.cmsPayments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPaymentInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdatePayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeletePayment = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseInvoicesOrDocuments)).BeginInit();
            this.cmsPayments.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCaseInvoicesOrDocuments
            // 
            this.dgvCaseInvoicesOrDocuments.AllowUserToAddRows = false;
            this.dgvCaseInvoicesOrDocuments.AllowUserToDeleteRows = false;
            this.dgvCaseInvoicesOrDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCaseInvoicesOrDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaseInvoicesOrDocuments.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaseInvoicesOrDocuments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaseInvoicesOrDocuments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaseInvoicesOrDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseInvoicesOrDocuments.ContextMenuStrip = this.cmsPayments;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaseInvoicesOrDocuments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCaseInvoicesOrDocuments.Location = new System.Drawing.Point(0, 196);
            this.dgvCaseInvoicesOrDocuments.MultiSelect = false;
            this.dgvCaseInvoicesOrDocuments.Name = "dgvCaseInvoicesOrDocuments";
            this.dgvCaseInvoicesOrDocuments.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaseInvoicesOrDocuments.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCaseInvoicesOrDocuments.RowHeadersWidth = 51;
            this.dgvCaseInvoicesOrDocuments.RowTemplate.Height = 24;
            this.dgvCaseInvoicesOrDocuments.Size = new System.Drawing.Size(1066, 254);
            this.dgvCaseInvoicesOrDocuments.TabIndex = 30;
            // 
            // cmsPayments
            // 
            this.cmsPayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsPayments.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsPayments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPaymentInfo,
            this.toolStripSeparator4,
            this.AddPayment,
            this.UpdatePayment,
            this.tsmiDeletePayment});
            this.cmsPayments.Name = "cmsClients";
            this.cmsPayments.Size = new System.Drawing.Size(330, 154);
            // 
            // tsmiShowPaymentInfo
            // 
            this.tsmiShowPaymentInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.PaymentsInfo;
            this.tsmiShowPaymentInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowPaymentInfo.Name = "tsmiShowPaymentInfo";
            this.tsmiShowPaymentInfo.Size = new System.Drawing.Size(329, 36);
            this.tsmiShowPaymentInfo.Text = "عرض معلومات عمليه الدفع";
            this.tsmiShowPaymentInfo.Click += new System.EventHandler(this.tsmiShowPaymentInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(326, 6);
            // 
            // AddPayment
            // 
            this.AddPayment.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewPayment;
            this.AddPayment.Name = "AddPayment";
            this.AddPayment.Size = new System.Drawing.Size(329, 36);
            this.AddPayment.Text = "اضافه عمليه دفع";
            this.AddPayment.Click += new System.EventHandler(this.AddPayment_Click);
            // 
            // UpdatePayment
            // 
            this.UpdatePayment.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.UpdatePayment.Name = "UpdatePayment";
            this.UpdatePayment.Size = new System.Drawing.Size(329, 36);
            this.UpdatePayment.Text = "تعديل عمليه الدفع";
            this.UpdatePayment.Click += new System.EventHandler(this.UpdatePayment_Click);
            // 
            // tsmiDeletePayment
            // 
            this.tsmiDeletePayment.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeletePayment.Name = "tsmiDeletePayment";
            this.tsmiDeletePayment.Size = new System.Drawing.Size(329, 36);
            this.tsmiDeletePayment.Text = "ازاله عمليه الدفع";
            this.tsmiDeletePayment.Click += new System.EventHandler(this.tsmiDeletePayment_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1066, 50);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "عرض المدفوعات الخاصة بالفاتورة";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmShowInvoicePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 450);
            this.Controls.Add(this.dgvCaseInvoicesOrDocuments);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowInvoicePayments";
            this.RightToLeftLayout = true;
            this.Text = "عرض المدفوعات الخاصة بالفاتورة";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowInvoicePayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseInvoicesOrDocuments)).EndInit();
            this.cmsPayments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCaseInvoicesOrDocuments;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip cmsPayments;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPaymentInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem AddPayment;
        private System.Windows.Forms.ToolStripMenuItem UpdatePayment;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePayment;
    }
}