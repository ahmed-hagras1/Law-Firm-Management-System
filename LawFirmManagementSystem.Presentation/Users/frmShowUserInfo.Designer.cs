namespace LawFirmManagementSystem.Presentation.Users
{
    partial class frmShowUserInfo
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
            this.ctrlUserInfo1 = new LawFirmManagementSystem.Presentation.Users.Controls.ctrlUserInfo();
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
            this.label1.Size = new System.Drawing.Size(866, 50);
            this.label1.TabIndex = 31;
            this.label1.Text = "معلومات المستخدم";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlUserInfo1
            // 
            this.ctrlUserInfo1.Location = new System.Drawing.Point(-12, 52);
            this.ctrlUserInfo1.Name = "ctrlUserInfo1";
            this.ctrlUserInfo1.Size = new System.Drawing.Size(889, 476);
            this.ctrlUserInfo1.TabIndex = 0;
            this.ctrlUserInfo1.Load += new System.EventHandler(this.ctrlUserInfo1_Load);
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 536);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlUserInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowUserInfo";
            this.Text = "عرض معلومات المستخدم";
            this.Load += new System.EventHandler(this.frmShowUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlUserInfo ctrlUserInfo1;
        private System.Windows.Forms.Label label1;
    }
}