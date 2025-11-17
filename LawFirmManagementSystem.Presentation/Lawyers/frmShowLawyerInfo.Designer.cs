namespace LawFirmManagementSystem.Presentation.Lawyers
{
    partial class frmShowLawyerInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvActiveLawyerSessions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsSessions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowSessionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowCaseInfoForSession = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditSession = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteSession = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlLawyerInfo1 = new LawFirmManagementSystem.Presentation.Lawyers.ctrlLawyerInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLawyerSessions)).BeginInit();
            this.cmsSessions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 579);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(778, 51);
            this.label2.TabIndex = 31;
            this.label2.Text = "الجلسات الفعاله الخاصه بالمحامي";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvActiveLawyerSessions
            // 
            this.dgvActiveLawyerSessions.AllowUserToAddRows = false;
            this.dgvActiveLawyerSessions.AllowUserToDeleteRows = false;
            this.dgvActiveLawyerSessions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActiveLawyerSessions.BackgroundColor = System.Drawing.Color.White;
            this.dgvActiveLawyerSessions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActiveLawyerSessions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActiveLawyerSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveLawyerSessions.ContextMenuStrip = this.cmsSessions;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActiveLawyerSessions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActiveLawyerSessions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvActiveLawyerSessions.Location = new System.Drawing.Point(0, 690);
            this.dgvActiveLawyerSessions.MultiSelect = false;
            this.dgvActiveLawyerSessions.Name = "dgvActiveLawyerSessions";
            this.dgvActiveLawyerSessions.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActiveLawyerSessions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvActiveLawyerSessions.RowHeadersWidth = 51;
            this.dgvActiveLawyerSessions.RowTemplate.Height = 24;
            this.dgvActiveLawyerSessions.Size = new System.Drawing.Size(800, 198);
            this.dgvActiveLawyerSessions.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 50);
            this.label1.TabIndex = 29;
            this.label1.Text = "معلومات المحامي";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsSessions
            // 
            this.cmsSessions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsSessions.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsSessions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowSessionInfo,
            this.tsmiShowCaseInfoForSession,
            this.toolStripSeparator6,
            this.tsmiEditSession,
            this.tsmiDeleteSession});
            this.cmsSessions.Name = "cmsClients";
            this.cmsSessions.Size = new System.Drawing.Size(291, 154);
            // 
            // tsmiShowSessionInfo
            // 
            this.tsmiShowSessionInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowSessionInfo;
            this.tsmiShowSessionInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowSessionInfo.Name = "tsmiShowSessionInfo";
            this.tsmiShowSessionInfo.Size = new System.Drawing.Size(290, 36);
            this.tsmiShowSessionInfo.Text = "عرض معلومات الجلسه";
            // 
            // tsmiShowCaseInfoForSession
            // 
            this.tsmiShowCaseInfoForSession.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowIcon;
            this.tsmiShowCaseInfoForSession.Name = "tsmiShowCaseInfoForSession";
            this.tsmiShowCaseInfoForSession.Size = new System.Drawing.Size(290, 36);
            this.tsmiShowCaseInfoForSession.Text = "عرض معلومات القضيه";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(287, 6);
            // 
            // tsmiEditSession
            // 
            this.tsmiEditSession.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiEditSession.Name = "tsmiEditSession";
            this.tsmiEditSession.Size = new System.Drawing.Size(290, 36);
            this.tsmiEditSession.Text = "تعديل الجلسه";
            // 
            // tsmiDeleteSession
            // 
            this.tsmiDeleteSession.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteSession.Name = "tsmiDeleteSession";
            this.tsmiDeleteSession.Size = new System.Drawing.Size(290, 36);
            this.tsmiDeleteSession.Text = "ازاله الجلسه";
            // 
            // ctrlLawyerInfo1
            // 
            this.ctrlLawyerInfo1.Location = new System.Drawing.Point(0, 62);
            this.ctrlLawyerInfo1.Name = "ctrlLawyerInfo1";
            this.ctrlLawyerInfo1.Size = new System.Drawing.Size(790, 514);
            this.ctrlLawyerInfo1.TabIndex = 0;
            // 
            // frmShowLawyerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 888);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvActiveLawyerSessions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlLawyerInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLawyerInfo";
            this.Text = "frmShowLawyerInfo";
            this.Load += new System.EventHandler(this.frmShowLawyerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveLawyerSessions)).EndInit();
            this.cmsSessions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLawyerInfo ctrlLawyerInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvActiveLawyerSessions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsSessions;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowSessionInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowCaseInfoForSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditSession;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteSession;
    }
}