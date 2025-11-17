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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiClients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLawyers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCases = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSessions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.dgvFormData = new System.Windows.Forms.DataGridView();
            this.cmsClients = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowClientDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddNewClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteClient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLawyers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowLawyerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddLawyer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateLawyer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteLawyer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCases = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowCaseInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowClientInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddSession = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSessions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowSessionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowCaseInfoForSession = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditSession = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteSession = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInvoices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowInvoiceInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowCaseInfoForInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowClientInfoForInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUpdateInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddNewPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormData)).BeginInit();
            this.cmsClients.SuspendLayout();
            this.cmsLawyers.SuspendLayout();
            this.cmsCases.SuspendLayout();
            this.cmsSessions.SuspendLayout();
            this.cmsInvoices.SuspendLayout();
            this.cmsUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClients,
            this.tsmiLawyers,
            this.tsmiCases,
            this.tsmiSessions,
            this.tsmiInvoices,
            this.tsmiUsers,
            this.tsmiSignOut});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(978, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(327, 775);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiClients
            // 
            this.tsmiClients.AutoSize = false;
            this.tsmiClients.BackColor = System.Drawing.Color.Black;
            this.tsmiClients.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiClients.ForeColor = System.Drawing.Color.White;
            this.tsmiClients.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.People_64;
            this.tsmiClients.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiClients.Name = "tsmiClients";
            this.tsmiClients.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiClients.Size = new System.Drawing.Size(320, 90);
            this.tsmiClients.Text = "         العملاء";
            this.tsmiClients.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiClients.Click += new System.EventHandler(this.tsmiClients_Click);
            // 
            // tsmiLawyers
            // 
            this.tsmiLawyers.AutoSize = false;
            this.tsmiLawyers.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.tsmiLawyers.ForeColor = System.Drawing.Color.White;
            this.tsmiLawyers.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.LawyersIcon;
            this.tsmiLawyers.Name = "tsmiLawyers";
            this.tsmiLawyers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiLawyers.Size = new System.Drawing.Size(320, 90);
            this.tsmiLawyers.Text = "       المحامين";
            this.tsmiLawyers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiLawyers.Click += new System.EventHandler(this.tsmiLawyers_Click);
            // 
            // tsmiCases
            // 
            this.tsmiCases.AutoSize = false;
            this.tsmiCases.BackColor = System.Drawing.Color.Black;
            this.tsmiCases.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiCases.ForeColor = System.Drawing.Color.White;
            this.tsmiCases.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCases.Image")));
            this.tsmiCases.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiCases.Name = "tsmiCases";
            this.tsmiCases.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiCases.Size = new System.Drawing.Size(320, 90);
            this.tsmiCases.Text = "        القضايا";
            this.tsmiCases.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiCases.Click += new System.EventHandler(this.tsmiCases_Click);
            // 
            // tsmiSessions
            // 
            this.tsmiSessions.AutoSize = false;
            this.tsmiSessions.BackColor = System.Drawing.Color.Black;
            this.tsmiSessions.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiSessions.ForeColor = System.Drawing.Color.White;
            this.tsmiSessions.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.session_icon;
            this.tsmiSessions.ImageTransparentColor = System.Drawing.Color.White;
            this.tsmiSessions.Name = "tsmiSessions";
            this.tsmiSessions.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiSessions.Size = new System.Drawing.Size(320, 90);
            this.tsmiSessions.Text = "       الجلسات";
            this.tsmiSessions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiSessions.Click += new System.EventHandler(this.tsmiSessions_Click);
            // 
            // tsmiInvoices
            // 
            this.tsmiInvoices.AutoSize = false;
            this.tsmiInvoices.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.tsmiInvoices.ForeColor = System.Drawing.Color.White;
            this.tsmiInvoices.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Invoice;
            this.tsmiInvoices.Name = "tsmiInvoices";
            this.tsmiInvoices.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiInvoices.Size = new System.Drawing.Size(320, 90);
            this.tsmiInvoices.Text = "          الفواتير";
            this.tsmiInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiInvoices.Click += new System.EventHandler(this.tsmiInvoices_Click);
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.AutoSize = false;
            this.tsmiUsers.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.tsmiUsers.ForeColor = System.Drawing.Color.White;
            this.tsmiUsers.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Users_2_64;
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiUsers.Size = new System.Drawing.Size(320, 90);
            this.tsmiUsers.Text = "  المستخدمين";
            this.tsmiUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiSignOut
            // 
            this.tsmiSignOut.AutoSize = false;
            this.tsmiSignOut.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.tsmiSignOut.ForeColor = System.Drawing.Color.White;
            this.tsmiSignOut.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.sign_out_32__2;
            this.tsmiSignOut.Name = "tsmiSignOut";
            this.tsmiSignOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiSignOut.Size = new System.Drawing.Size(320, 90);
            this.tsmiSignOut.Text = "تسجيل الخروج";
            this.tsmiSignOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmiSignOut.Click += new System.EventHandler(this.tsmiSignOut_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(851, 83);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 38);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "العملاء";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(440, 88);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbFilterBy.Size = new System.Drawing.Size(320, 33);
            this.cbFilterBy.TabIndex = 21;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(110, 20);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(320, 33);
            this.cbFilter.TabIndex = 23;
            this.cbFilter.Visible = false;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(96, 24);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(320, 30);
            this.txtFilter.TabIndex = 22;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dtpFilter);
            this.panel1.Controls.Add(this.lblDataCount);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.cbFilter);
            this.panel1.Location = new System.Drawing.Point(2, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 71);
            this.panel1.TabIndex = 25;
            // 
            // dtpFilter
            // 
            this.dtpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFilter.CustomFormat = "dd/MM/yyyy";
            this.dtpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilter.Location = new System.Drawing.Point(86, 21);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.ShowUpDown = true;
            this.dtpFilter.Size = new System.Drawing.Size(320, 30);
            this.dtpFilter.TabIndex = 27;
            this.dtpFilter.Visible = false;
            this.dtpFilter.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // lblDataCount
            // 
            this.lblDataCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCount.Location = new System.Drawing.Point(723, 17);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(130, 33);
            this.lblDataCount.TabIndex = 24;
            this.lblDataCount.Text = "1000000:";
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvFormData
            // 
            this.dgvFormData.AllowUserToAddRows = false;
            this.dgvFormData.AllowUserToDeleteRows = false;
            this.dgvFormData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFormData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFormData.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFormData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormData.ContextMenuStrip = this.cmsClients;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFormData.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFormData.Location = new System.Drawing.Point(2, 154);
            this.dgvFormData.MultiSelect = false;
            this.dgvFormData.Name = "dgvFormData";
            this.dgvFormData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFormData.RowHeadersWidth = 51;
            this.dgvFormData.RowTemplate.Height = 24;
            this.dgvFormData.Size = new System.Drawing.Size(973, 621);
            this.dgvFormData.TabIndex = 26;
            // 
            // cmsClients
            // 
            this.cmsClients.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsClients.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsClients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowClientDetails,
            this.toolStripSeparator1,
            this.tsmiAddNewClient,
            this.tsmiUpdateClient,
            this.tsmiDeleteClient,
            this.toolStripSeparator2,
            this.tsmiAddCase,
            this.tsmiAddInvoice});
            this.cmsClients.Name = "cmsClients";
            this.cmsClients.Size = new System.Drawing.Size(288, 232);
            // 
            // tsmiShowClientDetails
            // 
            this.tsmiShowClientDetails.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.PersonDetails_32;
            this.tsmiShowClientDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowClientDetails.Name = "tsmiShowClientDetails";
            this.tsmiShowClientDetails.Size = new System.Drawing.Size(287, 36);
            this.tsmiShowClientDetails.Text = "عرض معلومات العميل";
            this.tsmiShowClientDetails.Click += new System.EventHandler(this.tsmiShowClientDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(284, 6);
            // 
            // tsmiAddNewClient
            // 
            this.tsmiAddNewClient.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewIcon;
            this.tsmiAddNewClient.Name = "tsmiAddNewClient";
            this.tsmiAddNewClient.Size = new System.Drawing.Size(287, 36);
            this.tsmiAddNewClient.Text = "اضافه عميل";
            this.tsmiAddNewClient.Click += new System.EventHandler(this.tsmiAddNewClient_Click);
            // 
            // tsmiUpdateClient
            // 
            this.tsmiUpdateClient.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiUpdateClient.Name = "tsmiUpdateClient";
            this.tsmiUpdateClient.Size = new System.Drawing.Size(287, 36);
            this.tsmiUpdateClient.Text = "تعديل العميل";
            this.tsmiUpdateClient.Click += new System.EventHandler(this.tsmiUpdateClient_Click);
            // 
            // tsmiDeleteClient
            // 
            this.tsmiDeleteClient.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteClient.Name = "tsmiDeleteClient";
            this.tsmiDeleteClient.Size = new System.Drawing.Size(287, 36);
            this.tsmiDeleteClient.Text = "ازاله العميل";
            this.tsmiDeleteClient.Click += new System.EventHandler(this.tsmiDeleteClient_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(284, 6);
            // 
            // tsmiAddCase
            // 
            this.tsmiAddCase.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddCaseIcon;
            this.tsmiAddCase.Name = "tsmiAddCase";
            this.tsmiAddCase.Size = new System.Drawing.Size(287, 36);
            this.tsmiAddCase.Text = "اضافه قضيه";
            // 
            // tsmiAddInvoice
            // 
            this.tsmiAddInvoice.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddInvoiceIcon;
            this.tsmiAddInvoice.Name = "tsmiAddInvoice";
            this.tsmiAddInvoice.Size = new System.Drawing.Size(287, 36);
            this.tsmiAddInvoice.Text = "اضافه فاتوره";
            // 
            // cmsLawyers
            // 
            this.cmsLawyers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsLawyers.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsLawyers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowLawyerInfo,
            this.toolStripSeparator3,
            this.tsmiAddLawyer,
            this.tsmiUpdateLawyer,
            this.tsmiDeleteLawyer});
            this.cmsLawyers.Name = "cmsClients";
            this.cmsLawyers.Size = new System.Drawing.Size(302, 182);
            // 
            // tsmiShowLawyerInfo
            // 
            this.tsmiShowLawyerInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.PersonDetails_32;
            this.tsmiShowLawyerInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowLawyerInfo.Name = "tsmiShowLawyerInfo";
            this.tsmiShowLawyerInfo.Size = new System.Drawing.Size(301, 36);
            this.tsmiShowLawyerInfo.Text = "عرض معلومات المحامي";
            this.tsmiShowLawyerInfo.Click += new System.EventHandler(this.tsmiShowLawyerInfo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(298, 6);
            // 
            // tsmiAddLawyer
            // 
            this.tsmiAddLawyer.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewIcon;
            this.tsmiAddLawyer.Name = "tsmiAddLawyer";
            this.tsmiAddLawyer.Size = new System.Drawing.Size(301, 36);
            this.tsmiAddLawyer.Text = "اضافه محامي";
            this.tsmiAddLawyer.Click += new System.EventHandler(this.tsmiAddLawyer_Click);
            // 
            // tsmiUpdateLawyer
            // 
            this.tsmiUpdateLawyer.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiUpdateLawyer.Name = "tsmiUpdateLawyer";
            this.tsmiUpdateLawyer.Size = new System.Drawing.Size(301, 36);
            this.tsmiUpdateLawyer.Text = "تعديل المحامي";
            this.tsmiUpdateLawyer.Click += new System.EventHandler(this.tsmiUpdateLawyer_Click);
            // 
            // tsmiDeleteLawyer
            // 
            this.tsmiDeleteLawyer.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteLawyer.Name = "tsmiDeleteLawyer";
            this.tsmiDeleteLawyer.Size = new System.Drawing.Size(301, 36);
            this.tsmiDeleteLawyer.Text = "ازاله المحامي";
            this.tsmiDeleteLawyer.Click += new System.EventHandler(this.tsmiDeleteLawyer_Click);
            // 
            // cmsCases
            // 
            this.cmsCases.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsCases.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsCases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowCaseInfo,
            this.tsmiShowClientInfo,
            this.toolStripSeparator4,
            this.tsmiEditCase,
            this.tsmiDeleteCase,
            this.toolStripSeparator5,
            this.tsmiAddSession,
            this.tsmiAddDocument});
            this.cmsCases.Name = "cmsClients";
            this.cmsCases.Size = new System.Drawing.Size(291, 232);
            // 
            // tsmiShowCaseInfo
            // 
            this.tsmiShowCaseInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowIcon;
            this.tsmiShowCaseInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowCaseInfo.Name = "tsmiShowCaseInfo";
            this.tsmiShowCaseInfo.Size = new System.Drawing.Size(290, 36);
            this.tsmiShowCaseInfo.Text = "عرض معلومات القضيه";
            // 
            // tsmiShowClientInfo
            // 
            this.tsmiShowClientInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.PersonDetails_32;
            this.tsmiShowClientInfo.Name = "tsmiShowClientInfo";
            this.tsmiShowClientInfo.Size = new System.Drawing.Size(290, 36);
            this.tsmiShowClientInfo.Text = "عرض معلومات العميل";
            this.tsmiShowClientInfo.Click += new System.EventHandler(this.tsmiShowClientInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(287, 6);
            // 
            // tsmiEditCase
            // 
            this.tsmiEditCase.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiEditCase.Name = "tsmiEditCase";
            this.tsmiEditCase.Size = new System.Drawing.Size(290, 36);
            this.tsmiEditCase.Text = "تعديل القضيه";
            // 
            // tsmiDeleteCase
            // 
            this.tsmiDeleteCase.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteCase.Name = "tsmiDeleteCase";
            this.tsmiDeleteCase.Size = new System.Drawing.Size(290, 36);
            this.tsmiDeleteCase.Text = "ازاله القضيه";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(287, 6);
            // 
            // tsmiAddSession
            // 
            this.tsmiAddSession.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewIcon2;
            this.tsmiAddSession.Name = "tsmiAddSession";
            this.tsmiAddSession.Size = new System.Drawing.Size(290, 36);
            this.tsmiAddSession.Text = "اضافه جلسه";
            // 
            // tsmiAddDocument
            // 
            this.tsmiAddDocument.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.add_file;
            this.tsmiAddDocument.Name = "tsmiAddDocument";
            this.tsmiAddDocument.Size = new System.Drawing.Size(290, 36);
            this.tsmiAddDocument.Text = "اضافه ملف";
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
            // cmsInvoices
            // 
            this.cmsInvoices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsInvoices.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsInvoices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowInvoiceInfo,
            this.tsmiShowCaseInfoForInvoices,
            this.tsmiShowClientInfoForInvoices,
            this.toolStripSeparator7,
            this.tsmiUpdateInvoice,
            this.tsmiDeleteInvoice,
            this.toolStripSeparator8,
            this.tsmiAddNewPayment});
            this.cmsInvoices.Name = "cmsClients";
            this.cmsInvoices.Size = new System.Drawing.Size(292, 232);
            // 
            // tsmiShowInvoiceInfo
            // 
            this.tsmiShowInvoiceInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowinvoiceInfo1;
            this.tsmiShowInvoiceInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowInvoiceInfo.Name = "tsmiShowInvoiceInfo";
            this.tsmiShowInvoiceInfo.Size = new System.Drawing.Size(291, 36);
            this.tsmiShowInvoiceInfo.Text = "عرض معلومات الفاتوره";
            // 
            // tsmiShowCaseInfoForInvoices
            // 
            this.tsmiShowCaseInfoForInvoices.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.ShowIcon;
            this.tsmiShowCaseInfoForInvoices.Name = "tsmiShowCaseInfoForInvoices";
            this.tsmiShowCaseInfoForInvoices.Size = new System.Drawing.Size(291, 36);
            this.tsmiShowCaseInfoForInvoices.Text = "عرض معلومات القضيه";
            // 
            // tsmiShowClientInfoForInvoices
            // 
            this.tsmiShowClientInfoForInvoices.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.PersonDetails_32;
            this.tsmiShowClientInfoForInvoices.Name = "tsmiShowClientInfoForInvoices";
            this.tsmiShowClientInfoForInvoices.Size = new System.Drawing.Size(291, 36);
            this.tsmiShowClientInfoForInvoices.Text = "عرض معلومات العميل";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(288, 6);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(288, 6);
            // 
            // tsmiAddNewPayment
            // 
            this.tsmiAddNewPayment.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewPayment;
            this.tsmiAddNewPayment.Name = "tsmiAddNewPayment";
            this.tsmiAddNewPayment.Size = new System.Drawing.Size(291, 36);
            this.tsmiAddNewPayment.Text = "اضافه عمليه دفع";
            // 
            // cmsUsers
            // 
            this.cmsUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsUsers.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowUserInfo,
            this.toolStripSeparator9,
            this.tsmiAddUser,
            this.tsmiUpdateUser,
            this.tsmiDeleteUser});
            this.cmsUsers.Name = "cmsClients";
            this.cmsUsers.Size = new System.Drawing.Size(314, 154);
            // 
            // tsmiShowUserInfo
            // 
            this.tsmiShowUserInfo.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.User_32__2;
            this.tsmiShowUserInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmiShowUserInfo.Name = "tsmiShowUserInfo";
            this.tsmiShowUserInfo.Size = new System.Drawing.Size(313, 36);
            this.tsmiShowUserInfo.Text = "عرض معلومات المستخدم";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(310, 6);
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Add_New_User_32;
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(313, 36);
            this.tsmiAddUser.Text = "اضافه مستخدم";
            // 
            // tsmiUpdateUser
            // 
            this.tsmiUpdateUser.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.edit_32;
            this.tsmiUpdateUser.Name = "tsmiUpdateUser";
            this.tsmiUpdateUser.Size = new System.Drawing.Size(313, 36);
            this.tsmiUpdateUser.Text = "تعديل المستخدم";
            // 
            // tsmiDeleteUser
            // 
            this.tsmiDeleteUser.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.Delete_32_2;
            this.tsmiDeleteUser.Name = "tsmiDeleteUser";
            this.tsmiDeleteUser.Size = new System.Drawing.Size(313, 36);
            this.tsmiDeleteUser.Text = "ازاله المستخدم";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::LawFirmManagementSystem.Presentation.Properties.Resources.AddNewIcon2;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 83);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(183, 39);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "اضافه";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1305, 775);
            this.Controls.Add(this.dgvFormData);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMainScreen";
            this.Text = "frmMainScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormData)).EndInit();
            this.cmsClients.ResumeLayout(false);
            this.cmsLawyers.ResumeLayout(false);
            this.cmsCases.ResumeLayout(false);
            this.cmsSessions.ResumeLayout(false);
            this.cmsInvoices.ResumeLayout(false);
            this.cmsUsers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCases;
        private System.Windows.Forms.ToolStripMenuItem tsmiClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiSessions;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiSignOut;
        private System.Windows.Forms.ToolStripMenuItem tsmiInvoices;
        private System.Windows.Forms.ToolStripMenuItem tsmiLawyers;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFormData;
        private System.Windows.Forms.ContextMenuStrip cmsClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowClientDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewClient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateClient;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteClient;
        private System.Windows.Forms.Label lblDataCount;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsLawyers;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLawyerInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddLawyer;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateLawyer;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteLawyer;
        private System.Windows.Forms.ContextMenuStrip cmsCases;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowCaseInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowClientInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditCase;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSession;
        private System.Windows.Forms.ContextMenuStrip cmsSessions;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowSessionInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowCaseInfoForSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditSession;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteSession;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDocument;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddInvoice;
        private System.Windows.Forms.ContextMenuStrip cmsInvoices;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowInvoiceInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowCaseInfoForInvoices;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowClientInfoForInvoices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddNewPayment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ContextMenuStrip cmsUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowUserInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
    }
}