namespace LawFirmManagementSystem.Presentation.Cases
{
    partial class frmShowCaseInfo
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
            this.btnShowCaseDocuments = new System.Windows.Forms.Button();
            this.btnShowCaseInvoices = new System.Windows.Forms.Button();
            this.ctrlCaseInfo1 = new LawFirmManagementSystem.Presentation.Cases.Controls.ctrlCaseInfo();
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
            this.label1.Size = new System.Drawing.Size(1047, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "معلومات القضيه";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowCaseDocuments
            // 
            this.btnShowCaseDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowCaseDocuments.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.DocumentsIcon;
            this.btnShowCaseDocuments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCaseDocuments.Location = new System.Drawing.Point(18, 596);
            this.btnShowCaseDocuments.Name = "btnShowCaseDocuments";
            this.btnShowCaseDocuments.Size = new System.Drawing.Size(381, 67);
            this.btnShowCaseDocuments.TabIndex = 79;
            this.btnShowCaseDocuments.Text = "عرض الملفات الخاصه بالقضيه";
            this.btnShowCaseDocuments.UseVisualStyleBackColor = true;
            this.btnShowCaseDocuments.Click += new System.EventHandler(this.btnShowCaseDocuments_Click);
            // 
            // btnShowCaseInvoices
            // 
            this.btnShowCaseInvoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowCaseInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowCaseInvoices.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.InvoicesIcon3;
            this.btnShowCaseInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCaseInvoices.Location = new System.Drawing.Point(654, 596);
            this.btnShowCaseInvoices.Name = "btnShowCaseInvoices";
            this.btnShowCaseInvoices.Size = new System.Drawing.Size(381, 67);
            this.btnShowCaseInvoices.TabIndex = 78;
            this.btnShowCaseInvoices.Text = "عرض الفواتير الخاصه بالقضيه";
            this.btnShowCaseInvoices.UseVisualStyleBackColor = true;
            this.btnShowCaseInvoices.Click += new System.EventHandler(this.btnShowCaseInvoices_Click);
            // 
            // ctrlCaseInfo1
            // 
            this.ctrlCaseInfo1.Location = new System.Drawing.Point(12, 72);
            this.ctrlCaseInfo1.Name = "ctrlCaseInfo1";
            this.ctrlCaseInfo1.Size = new System.Drawing.Size(1031, 518);
            this.ctrlCaseInfo1.TabIndex = 80;
            // 
            // frmShowCaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 681);
            this.Controls.Add(this.ctrlCaseInfo1);
            this.Controls.Add(this.btnShowCaseDocuments);
            this.Controls.Add(this.btnShowCaseInvoices);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowCaseInfo";
            this.Text = "عرض معلومات القضيه";
            this.Load += new System.EventHandler(this.frmShowCaseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnShowCaseDocuments;
        private System.Windows.Forms.Button btnShowCaseInvoices;
        private System.Windows.Forms.Label label1;
        private Controls.ctrlCaseInfo ctrlCaseInfo1;
    }
}