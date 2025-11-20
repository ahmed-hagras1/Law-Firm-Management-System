namespace LawFirmManagementSystem.Presentation.Sessions
{
    partial class frmShowSessionInfo
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
            this.ctrlSessionInfo1 = new LawFirmManagementSystem.Presentation.Sessions.Controls.ctrlSessionInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlSessionInfo1
            // 
            this.ctrlSessionInfo1.Location = new System.Drawing.Point(0, 46);
            this.ctrlSessionInfo1.Name = "ctrlSessionInfo1";
            this.ctrlSessionInfo1.Size = new System.Drawing.Size(1046, 798);
            this.ctrlSessionInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1008, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "معلومات الجلسه";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmShowSessionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 848);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlSessionInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowSessionInfo";
            this.Text = "معلومات الجلسه";
            this.Load += new System.EventHandler(this.frmShowSessionInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlSessionInfo ctrlSessionInfo1;
        private System.Windows.Forms.Label label1;
    }
}