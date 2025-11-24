namespace LawFirmManagementSystem.Presentation.Users
{
    partial class frmUpdateUser
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
            this.label9 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbChangePassword = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llShowCurrentPassword = new System.Windows.Forms.LinkLabel();
            this.llShowNewPassword = new System.Windows.Forms.LinkLabel();
            this.llShowConfirmPassword = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(704, 191);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 142;
            this.label9.Text = "حاله المستخدم:";
            // 
            // cbIsActive
            // 
            this.cbIsActive.BackColor = System.Drawing.Color.White;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cbIsActive.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.cbIsActive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.Location = new System.Drawing.Point(69, 182);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsActive.Size = new System.Drawing.Size(550, 38);
            this.cbIsActive.TabIndex = 129;
            this.cbIsActive.UseVisualStyleBackColor = false;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Enabled = false;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(42, 171);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtConfirmPassword.Size = new System.Drawing.Size(550, 27);
            this.txtConfirmPassword.TabIndex = 127;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(715, 435);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 140;
            this.label7.Text = "تاكيد كلمه السر:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPassword.Enabled = false;
            this.txtCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassword.Location = new System.Drawing.Point(42, 38);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCurrentPassword.Size = new System.Drawing.Size(550, 27);
            this.txtCurrentPassword.TabIndex = 128;
            this.txtCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPassword_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(715, 302);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 138;
            this.label4.Text = "كلمه السر الحاليه:";
            // 
            // txtNotes
            // 
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(80, 522);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNotes.Size = new System.Drawing.Size(550, 147);
            this.txtNotes.TabIndex = 130;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(69, 135);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsername.Size = new System.Drawing.Size(550, 27);
            this.txtUsername.TabIndex = 126;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(715, 580);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 136;
            this.label6.Text = "ملاحظات:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(704, 135);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 134;
            this.label2.Text = "اسم المستخدم:";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(886, 50);
            this.lblTitle.TabIndex = 133;
            this.lblTitle.Text = "تعديل مستخدم";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.StatusIcon;
            this.label8.Location = new System.Drawing.Point(659, 184);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(35, 33);
            this.label8.TabIndex = 143;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Password_32;
            this.label5.Location = new System.Drawing.Point(670, 428);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(35, 33);
            this.label5.TabIndex = 141;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Password_32;
            this.label3.Location = new System.Drawing.Point(670, 295);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(35, 33);
            this.label3.TabIndex = 139;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(275, 706);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(157, 39);
            this.btnClose.TabIndex = 132;
            this.btnClose.Text = "الغاء";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(473, 706);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 39);
            this.btnSave.TabIndex = 131;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Notes_32;
            this.label1.Location = new System.Drawing.Point(670, 574);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(35, 33);
            this.label1.TabIndex = 137;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Person_32;
            this.label16.Location = new System.Drawing.Point(659, 128);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(35, 33);
            this.label16.TabIndex = 135;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Enabled = false;
            this.txtNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.Location = new System.Drawing.Point(42, 107);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNewPassword.Size = new System.Drawing.Size(550, 27);
            this.txtNewPassword.TabIndex = 144;
            this.txtNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPassword_Validating);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Password_32;
            this.label10.Location = new System.Drawing.Point(670, 364);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(35, 33);
            this.label10.TabIndex = 146;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(715, 371);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 145;
            this.label11.Text = "كلمه السر الجديده:";
            // 
            // cbChangePassword
            // 
            this.cbChangePassword.AutoSize = true;
            this.cbChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChangePassword.Location = new System.Drawing.Point(503, 253);
            this.cbChangePassword.Name = "cbChangePassword";
            this.cbChangePassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbChangePassword.Size = new System.Drawing.Size(127, 24);
            this.cbChangePassword.TabIndex = 147;
            this.cbChangePassword.Text = "تغير كلمه السر";
            this.cbChangePassword.UseVisualStyleBackColor = true;
            this.cbChangePassword.CheckedChanged += new System.EventHandler(this.cbChangePassword_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.llShowConfirmPassword);
            this.panel1.Controls.Add(this.llShowNewPassword);
            this.panel1.Controls.Add(this.llShowCurrentPassword);
            this.panel1.Controls.Add(this.txtNewPassword);
            this.panel1.Controls.Add(this.txtConfirmPassword);
            this.panel1.Controls.Add(this.txtCurrentPassword);
            this.panel1.Location = new System.Drawing.Point(31, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 237);
            this.panel1.TabIndex = 148;
            // 
            // llShowCurrentPassword
            // 
            this.llShowCurrentPassword.AutoSize = true;
            this.llShowCurrentPassword.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.llShowCurrentPassword.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.llShowCurrentPassword.Location = new System.Drawing.Point(492, 68);
            this.llShowCurrentPassword.Name = "llShowCurrentPassword";
            this.llShowCurrentPassword.Size = new System.Drawing.Size(84, 16);
            this.llShowCurrentPassword.TabIndex = 145;
            this.llShowCurrentPassword.TabStop = true;
            this.llShowCurrentPassword.Text = "إظهار كلمه السر";
            this.llShowCurrentPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowCurrentPassword_LinkClicked);
            // 
            // llShowNewPassword
            // 
            this.llShowNewPassword.AutoSize = true;
            this.llShowNewPassword.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.llShowNewPassword.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.llShowNewPassword.Location = new System.Drawing.Point(492, 137);
            this.llShowNewPassword.Name = "llShowNewPassword";
            this.llShowNewPassword.Size = new System.Drawing.Size(84, 16);
            this.llShowNewPassword.TabIndex = 146;
            this.llShowNewPassword.TabStop = true;
            this.llShowNewPassword.Text = "إظهار كلمه السر";
            this.llShowNewPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewPassword_LinkClicked);
            // 
            // llShowConfirmPassword
            // 
            this.llShowConfirmPassword.AutoSize = true;
            this.llShowConfirmPassword.DisabledLinkColor = System.Drawing.Color.DarkGray;
            this.llShowConfirmPassword.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.llShowConfirmPassword.Location = new System.Drawing.Point(492, 201);
            this.llShowConfirmPassword.Name = "llShowConfirmPassword";
            this.llShowConfirmPassword.Size = new System.Drawing.Size(84, 16);
            this.llShowConfirmPassword.TabIndex = 147;
            this.llShowConfirmPassword.TabStop = true;
            this.llShowConfirmPassword.Text = "إظهار كلمه السر";
            this.llShowConfirmPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowConfirmPassword_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // frmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 753);
            this.Controls.Add(this.cbChangePassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUpdateUser";
            this.Text = "تعديل مستخدم";
            this.Load += new System.EventHandler(this.frmUpdateUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbChangePassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel llShowCurrentPassword;
        private System.Windows.Forms.LinkLabel llShowConfirmPassword;
        private System.Windows.Forms.LinkLabel llShowNewPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}