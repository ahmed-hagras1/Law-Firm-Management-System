namespace LawFirmManagementSystem.Presentation.Invoices
{
    partial class frmShowInvoiceInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowInvoicePayments = new System.Windows.Forms.Button();
            this.ctrlInvoiceInfo1 = new LawFirmManagementSystem.Presentation.Invoices.Controls.ctrlInvoiceInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1057, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "معلومات الفاتوره";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowInvoicePayments
            // 
            this.btnShowInvoicePayments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowInvoicePayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowInvoicePayments.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.paymentIcon1;
            this.btnShowInvoicePayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowInvoicePayments.Location = new System.Drawing.Point(664, 768);
            this.btnShowInvoicePayments.Name = "btnShowInvoicePayments";
            this.btnShowInvoicePayments.Size = new System.Drawing.Size(381, 67);
            this.btnShowInvoicePayments.TabIndex = 79;
            this.btnShowInvoicePayments.Text = "عرض عمليات الدفع الخاصه بالقضيه";
            this.btnShowInvoicePayments.UseVisualStyleBackColor = true;
            this.btnShowInvoicePayments.Click += new System.EventHandler(this.btnShowInvoicePayments_Click);
            // 
            // ctrlInvoiceInfo1
            // 
            this.ctrlInvoiceInfo1.Location = new System.Drawing.Point(12, 51);
            this.ctrlInvoiceInfo1.Name = "ctrlInvoiceInfo1";
            this.ctrlInvoiceInfo1.Size = new System.Drawing.Size(1041, 727);
            this.ctrlInvoiceInfo1.TabIndex = 0;
            // 
            // frmShowInvoiceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 870);
            this.Controls.Add(this.btnShowInvoicePayments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlInvoiceInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowInvoiceInfo";
            this.Text = "عرض معلومات الفاتوره";
            this.Load += new System.EventHandler(this.frmInvoiceInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlInvoiceInfo ctrlInvoiceInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowInvoicePayments;
    }
}