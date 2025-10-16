namespace LawFirmManagementSystem.Presentation
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.tsmiMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSessions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMain,
            this.tsmiClients,
            this.tsmiSessions,
            this.tsmiUsers,
            this.tsmiInvoices,
            this.tsmiSignOut});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(978, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(327, 775);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::LawFirmManagementSystem.Presentation.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Location = new System.Drawing.Point(12, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 35);
            this.btnClose.TabIndex = 18;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tsmiMain
            // 
            this.tsmiMain.AutoSize = false;
            this.tsmiMain.BackColor = System.Drawing.Color.Black;
            this.tsmiMain.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiMain.ForeColor = System.Drawing.Color.White;
            this.tsmiMain.Image = ((System.Drawing.Image)(resources.GetObject("tsmiMain.Image")));
            this.tsmiMain.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiMain.Name = "tsmiMain";
            this.tsmiMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiMain.Size = new System.Drawing.Size(320, 60);
            this.tsmiMain.Text = "       الرئيسيه";
            this.tsmiMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsmiClients
            // 
            this.tsmiClients.AutoSize = false;
            this.tsmiClients.BackColor = System.Drawing.Color.Black;
            this.tsmiClients.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiClients.ForeColor = System.Drawing.Color.White;
            this.tsmiClients.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.People_64;
            this.tsmiClients.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiClients.Name = "tsmiClients";
            this.tsmiClients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiClients.Size = new System.Drawing.Size(320, 60);
            this.tsmiClients.Text = "         العملاء";
            this.tsmiClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiClients.Click += new System.EventHandler(this.tsmiClients_Click);
            // 
            // tsmiSessions
            // 
            this.tsmiSessions.AutoSize = false;
            this.tsmiSessions.BackColor = System.Drawing.Color.Black;
            this.tsmiSessions.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiSessions.ForeColor = System.Drawing.Color.White;
            this.tsmiSessions.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.session_icon;
            this.tsmiSessions.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiSessions.Name = "tsmiSessions";
            this.tsmiSessions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiSessions.Size = new System.Drawing.Size(320, 60);
            this.tsmiSessions.Text = "       الجلسات";
            this.tsmiSessions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.AutoSize = false;
            this.tsmiUsers.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.tsmiUsers.ForeColor = System.Drawing.Color.White;
            this.tsmiUsers.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Users_2_64;
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiUsers.Size = new System.Drawing.Size(320, 60);
            this.tsmiUsers.Text = "  المستخدمين";
            this.tsmiUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsmiSignOut
            // 
            this.tsmiSignOut.AutoSize = false;
            this.tsmiSignOut.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.tsmiSignOut.ForeColor = System.Drawing.Color.White;
            this.tsmiSignOut.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.sign_out_32__2;
            this.tsmiSignOut.Name = "tsmiSignOut";
            this.tsmiSignOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiSignOut.Size = new System.Drawing.Size(320, 60);
            this.tsmiSignOut.Text = "تسجيل الخروج";
            this.tsmiSignOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsmiInvoices
            // 
            this.tsmiInvoices.AutoSize = false;
            this.tsmiInvoices.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.tsmiInvoices.ForeColor = System.Drawing.Color.White;
            this.tsmiInvoices.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Invoice;
            this.tsmiInvoices.Name = "tsmiInvoices";
            this.tsmiInvoices.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiInvoices.Size = new System.Drawing.Size(320, 60);
            this.tsmiInvoices.Text = "          الفواتير";
            this.tsmiInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1305, 775);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainScreen";
            this.Text = "frmMainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiSessions;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiSignOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvoices;
    }
}