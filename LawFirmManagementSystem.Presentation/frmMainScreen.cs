using LawFirmManagementSystem.Business;
using LawFirmManagementSystem.Presentation.Cases;
using LawFirmManagementSystem.Presentation.Lawyers;
using LawFirmManagementSystem_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawFirmManagementSystem.Presentation
{
    public partial class frmMainScreen: Form
    {
        private enum enPages { ClientsPage, LawyersPage, CasesPage, SessionsPage, InvoicesPage, UsersPage }
        enPages page = enPages.ClientsPage; // Default page.
        private string FilterColumn = string.Empty;

        // Clients list.
        private static DataTable _dtAllClients;
        private DataTable _dtClients;

        // Lawyer List.
        private static DataTable _dtAllLawyers;
        private DataTable _dtLawyers;

        // Cases List.
        private static DataTable _dtAllCases;
        private DataTable _dtCases;

        // Sessions List.
        private static DataTable _dtAllSessions;
        private DataTable _dtSessions;

        // Invoices List.
        private static DataTable _dtAllInvoices;
        private DataTable _dtInvoices;

        // Users List.
        private static DataTable _dtAllUsers;
        private DataTable _dtUsers;
        private string GetFilterColumn()
        {
            txtFilter.Text = string.Empty;
            txtFilter.Visible = true;
            cbFilter.Visible = false;
            dtpFilter.Visible = false;

            if (page == enPages.ClientsPage || page == enPages.LawyersPage)
            {
                switch (cbFilterBy.Text)
                {
                    case "بدون":
                        txtFilter.Visible = false;
                        return "None";
                    case "الاسم الكامل":
                        return "FullName";
                    case "رقم الهاتف":
                        return "Phone";
                    case "العنوان":
                        return "Address";
                    case "تاريخ الانضمام":
                        dtpFilter.Visible = true;
                        txtFilter.Visible = false;
                        return "JoinDate";
                    case "تم الانشاء بواسطة":
                        return "CreatedBy";
                    case "تم التحديث بواسطة":
                        return "UpdatedBy";

                }
            }
            else if (page == enPages.CasesPage)
            {
                switch (cbFilterBy.Text)
                {
                    case "بدون":
                        txtFilter.Visible = false;
                        return "None";
                    case "رقم القضيه":
                        return "CaseNumber";
                    case "وصف القضيه":
                        return "Title";
                    case "المحكمه":
                        return "Court";
                    case "اسم العميل":
                        return "ClientName";
                    case "حاله العميل":
                        return "ClientStatus";
                    case "عنوان العميل":
                        return "ClientAddress";
                    case "رقم العميل":
                        return "ClientPhone";
                    case "اسم الخصم":
                        return "OpponentName";
                    case "حاله الخصم":
                        return "OpponentStatus";
                    case "عنوان الخصم":
                        return "OpponentAddress";
                    case "رقم الخصم":
                        return "OpponentPhone";
                    case "تم الانشاء بواسطة":
                        return "CreatedBy";
                    case "تم التحديث بواسطة":
                        return "LastUpdatedBy";
                    case "ملاحظات":
                        return "Notes";
                    default:
                        return "None";
                }

            }
            else if (page == enPages.SessionsPage)
            {
                switch (cbFilterBy.Text)
                {
                    case "بدون":
                        txtFilter.Visible = false;
                        return "None";
                    case "رقم القضيه":
                        return "CaseNumber";
                    case "وصف الجلسه":
                        return "Title";
                    case "اسم المحكمه":
                        return "Court";
                    case "رقم الجلسه":
                        return "RollNumber";
                    case "تاريخ الجلسه":
                        dtpFilter.Visible = true;
                        txtFilter.Visible = false;
                        return "Date";
                    case "اسم العميل":
                        return "ClientName";
                    case "اسم المحامي":
                        return "LawyerName";
                    case "الطلبات":
                        return "Requests";
                    case "القرار":
                        return "Decision";
                    case "تم الانشاء بواسطة":
                        return "CreatedBy";
                    case "تم التحديث بواسطة":
                        return "LastUpdatedBy";
                    case "حاله الجلسه":
                        cbFilter.Visible = true;
                        txtFilter.Visible = dtpFilter.Visible = false;
                        cbFilter.Items.Clear();
                        cbFilter.Items.Add("الكل");
                        cbFilter.Items.Add("فعاله");
                        cbFilter.Items.Add("انتهت");
                        cbFilter.SelectedIndex = 0;
                        return "SessionStatus";
                    case "ملاحظات":
                        return "Notes";
                    default:
                        return "None";
                }

            }
            else if (page == enPages.InvoicesPage)
            {
                switch (cbFilterBy.Text)
                {
                    case "بدون":
                        txtFilter.Visible = false;
                        return "None";
                    case "رقم القضيه":
                        return "CaseNumber";
                    case "وصف القضيه":
                        return "Title";
                    case "اسم العميل":
                        return "ClientName";
                    case "تم الانشاء بواسطة":
                        return "CreatedBy";
                    case "تاريخ الاصدار":
                        dtpFilter.Visible = true;
                        txtFilter.Visible = false;
                        return "IssueDate";
                    case "تم التحديث بواسطة":
                        return "LastUpdatedBy";
                    case "ملاحظات":
                        return "Notes";
                    default:
                        return "None";

                }

            }
            else if (page == enPages.UsersPage)
            {
                switch (cbFilterBy.Text)
                {
                    case "بدون":
                        txtFilter.Visible = false;
                        return "None";
                    case "اسم المستخدم":
                        return "Username";
                    case "حاله المستخدم":
                        cbFilter.Visible = true;
                        txtFilter.Visible = dtpFilter.Visible = false;
                        cbFilter.Items.Clear();
                        cbFilter.Items.Add("الكل");
                        cbFilter.Items.Add("نشط");
                        cbFilter.Items.Add("غير نشط");
                        cbFilter.SelectedIndex = 0;
                        return "UserStatus";
                    case "تاريخ الانضمام":
                        dtpFilter.Visible = true;
                        txtFilter.Visible = false;
                        return "JoinDate";
                    case "تم الانشاء بواسطة":
                        return "CreatedBy";
                    case "تم التحديث بواسطة":
                        return "LastUpdatedBy";
                    case "ملاحظات":
                        return "Notes";
                    default:
                        return "None";
                }

            }
                return string.Empty;
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterColumn = GetFilterColumn();

            // To reset the data if changed from one filter to another.
            // Especially To reset data if changed from JoinDate to another filter.
            if (page == enPages.ClientsPage)
            {
                (_dtClients.DefaultView).RowFilter = string.Empty;
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.LawyersPage)
            {
                (_dtLawyers.DefaultView).RowFilter = string.Empty;
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.SessionsPage)
            {
                (_dtSessions.DefaultView).RowFilter = string.Empty;
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.InvoicesPage)
            {
                (_dtInvoices.DefaultView).RowFilter = string.Empty;
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.UsersPage)
            {
                (_dtUsers.DefaultView).RowFilter = string.Empty;
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }

            
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (page == enPages.ClientsPage)
            {
                if (txtFilter.Text.Trim() == string.Empty)
                {
                    (_dtClients.DefaultView).RowFilter = string.Empty;
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }

                (_dtClients.DefaultView).RowFilter = $"{FilterColumn} LIKE '%{txtFilter.Text.Trim()}%'";
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.LawyersPage)
            {
                if (txtFilter.Text.Trim() == string.Empty)
                {
                    (_dtLawyers.DefaultView).RowFilter = string.Empty;
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }
                (_dtLawyers.DefaultView).RowFilter = $"{FilterColumn} LIKE '%{txtFilter.Text.Trim()}%'";
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.CasesPage)
            {
                if (txtFilter.Text.Trim() == string.Empty)
                {
                    (_dtCases.DefaultView).RowFilter = string.Empty;
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }
                
                (_dtCases.DefaultView).RowFilter = $"{FilterColumn} LIKE '%{txtFilter.Text.Trim()}%'";
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.SessionsPage)
            {
                if (txtFilter.Text.Trim() == string.Empty)
                {
                    (_dtSessions.DefaultView).RowFilter = string.Empty;
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }

                if (FilterColumn == "RollNumber")
                {

                    (_dtSessions.DefaultView).RowFilter = $"{FilterColumn} = {int.Parse(txtFilter.Text.Trim())}";
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }

                (_dtSessions.DefaultView).RowFilter = $"{FilterColumn} LIKE '%{txtFilter.Text.Trim()}%'";
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }
            else if (page == enPages.InvoicesPage)
            {
                if (txtFilter.Text.Trim() == string.Empty)
                {
                    (_dtInvoices.DefaultView).RowFilter = string.Empty;
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }

                (_dtInvoices.DefaultView).RowFilter = $"{FilterColumn} LIKE '%{txtFilter.Text.Trim()}%'";
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";

            }
            else if (page == enPages.UsersPage)
            {
                if (txtFilter.Text.Trim() == string.Empty)
                {
                    (_dtUsers.DefaultView).RowFilter = string.Empty;
                    lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
                    return;
                }
                (_dtUsers.DefaultView).RowFilter = $"{FilterColumn} LIKE '%{txtFilter.Text.Trim()}%'";
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            }


        }
        private void dtpFilter_ValueChanged(object sender, EventArgs e)
        {
            if (page == enPages.ClientsPage)
            {
                (_dtClients.DefaultView).RowFilter = string.Format(GetFilterColumn() + " = '{0}'", dtpFilter.Value.Date.ToString("MM/dd/yyyy"));
            }
            else if (page == enPages.LawyersPage)
            {
                (_dtLawyers.DefaultView).RowFilter = string.Format(GetFilterColumn() + " = '{0}'", dtpFilter.Value.Date.ToString("MM/dd/yyyy"));
            }
            else if (page == enPages.SessionsPage)
            {
                (_dtSessions.DefaultView).RowFilter = string.Format(GetFilterColumn() + " = '{0}'", dtpFilter.Value.Date.ToString("MM/dd/yyyy"));

            }
            else if (page == enPages.InvoicesPage)
            {
                (_dtInvoices.DefaultView).RowFilter = string.Format(GetFilterColumn() + " = '{0}'", dtpFilter.Value.Date.ToString("MM/dd/yyyy"));
            }
            else if (page == enPages.UsersPage)
            {
                (_dtUsers.DefaultView).RowFilter = string.Format(GetFilterColumn() + " = '{0}'", dtpFilter.Value.Date.ToString("MM/dd/yyyy"));
            }

                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
        }
        private void RefreshClientsList()
        {
            _dtAllClients = Client.GetAllClients();
            _dtClients = _dtAllClients.DefaultView.ToTable(false, "FullName", "Phone", "Address", "JoinDate",
             "CreatedBy", "UpdatedBy", "Notes");

            HandelClientsPage();
        }
        private void RefreshLawyersList()
        {
            _dtAllLawyers = Lawyer.GetAllLawyers();
            _dtLawyers = _dtAllLawyers.DefaultView.ToTable(false, "FullName", "Phone", "Address", "JoinDate",
             "CreatedBy", "UpdatedBy", "Notes");

            HandelLawyersPage();
        }
        private void RefreshCasesList()
        {
            _dtAllCases = Case.GetAllCases();
            _dtCases = _dtAllCases.DefaultView.ToTable(false, "CaseNumber", "Title", "Court", "ClientName",
            "ClientStatus", "ClientAddress", "ClientPhone", "OpponentName", "OpponentStatus", "OpponentAddress", "OpponentPhone",
            "CreatedBy", "LastUpdatedBy", "Notes");

            HandelCasesPage();
        }
        private void RefreshSessionsList()
        {
            _dtAllSessions = Session.GetAllSessions();
            _dtSessions = _dtAllSessions.DefaultView.ToTable(false, "CaseNumber", "Title", "RollNumber", "Date",
            "Court", "ClientName", "LawyerName", "Requests", "Decision", "CreatedBy", "LastUpdatedBy", "SessionStatus", "Notes");

            HandelSessionsPage();
        }
        private void RefreshInvoicesList()
        {
            _dtAllInvoices = Invoice.GetAllInvoices();
            _dtInvoices = _dtAllInvoices.DefaultView.ToTable(false, "ClientName", "CaseNumber",
            "Title", "CreatedBy", "IssueDate", "LastUpdatedBy", "TotalAmount", "AmountPaid", "AmountDue", "Notes");

            HandelInvoicesPage();
        }
        private void RefreshUsersList()
        {
            _dtAllUsers = User.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "Username", "UserStatus",
            "JoinDate", "CreatedBy", "LastUpdatedBy", "Notes");

            HandelUsersPage();
        }
        private void ClientsLawyersColumnsFormatting()
        {
            dgvFormData.Columns["FullName"].HeaderText = "الاسم الكامل";
            dgvFormData.Columns["Phone"].HeaderText = "رقم الهاتف";
            dgvFormData.Columns["Address"].HeaderText = "العنوان";
            dgvFormData.Columns["JoinDate"].HeaderText = "تاريخ الانضمام";
            dgvFormData.Columns["JoinDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvFormData.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvFormData.Columns["UpdatedBy"].HeaderText = "تم التحديث بواسطة";
            dgvFormData.Columns["Notes"].HeaderText = "ملاحظات";
        }
        private void ClientsLawyersFilters()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("بدون");
            cbFilterBy.Items.Add("الاسم الكامل");
            cbFilterBy.Items.Add("رقم الهاتف");
            cbFilterBy.Items.Add("العنوان");
            cbFilterBy.Items.Add("تاريخ الانضمام");
            cbFilterBy.Items.Add("تم الانشاء بواسطة");
            cbFilterBy.Items.Add("تم التحديث بواسطة");
            cbFilterBy.SelectedIndex = 0;

        }
        private void HandelClientsPage()
        {
            page = enPages.ClientsPage;

            _dtAllClients = Client.GetAllClients();
            _dtClients = _dtAllClients.DefaultView.ToTable(false, "FullName", "Phone", "Address", "JoinDate",
             "CreatedBy", "UpdatedBy", "Notes");

            if (_dtClients.Rows.Count > 0)
            {
                dgvFormData.DataSource = _dtClients;
                ClientsLawyersColumnsFormatting();
                ClientsLawyersFilters();
            }
            else
            {
                // Reset if no data,
                dgvFormData.DataSource = null;
                cbFilterBy.Items.Clear();
            }
                dgvFormData.ContextMenuStrip = cmsClients;
            lblTitle.Text = "العملاء";
            btnAdd.Visible = true;
            btnAdd.Text = "اضافه عميل";
            cbFilter.Visible = false;
            lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            tsmiClients.BackColor = Color.GreenYellow;
            tsmiLawyers.BackColor = tsmiCases.BackColor = tsmiSessions.BackColor = tsmiInvoices.BackColor = tsmiUsers.BackColor = Color.Black;


        }
        private void HandelLawyersPage()
        {
            page = enPages.LawyersPage;
            _dtAllLawyers = Lawyer.GetAllLawyers();
            _dtLawyers = _dtAllLawyers.DefaultView.ToTable(false, "FullName", "Phone", "Address", "JoinDate",
             "CreatedBy", "UpdatedBy", "Notes");

            if (_dtLawyers.Rows.Count > 0 )
            {
                dgvFormData.DataSource = _dtLawyers;
                ClientsLawyersColumnsFormatting();
                ClientsLawyersFilters();
            }
            else
            {
                // Reset if no data.
                dgvFormData.DataSource = null;
                cbFilterBy.Items.Clear();
            }
                dgvFormData.ContextMenuStrip = cmsLawyers;
            lblTitle.Text = "المحامين";
            btnAdd.Visible = true;
            btnAdd.Text = "اضافه محامي";
            cbFilter.Visible = false;
            lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            tsmiLawyers.BackColor = Color.GreenYellow;
            tsmiClients.BackColor = tsmiCases.BackColor = tsmiSessions.BackColor = tsmiInvoices.BackColor = tsmiUsers.BackColor = Color.Black;


        }
        private void CasesColumnsFormatting()
        {
            dgvFormData.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvFormData.Columns["Title"].HeaderText = "وصف القضيه";
            dgvFormData.Columns["Court"].HeaderText = "المحكمه";
            dgvFormData.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvFormData.Columns["ClientStatus"].HeaderText = "حاله العميل";
            dgvFormData.Columns["ClientAddress"].HeaderText = "عنوان العميل";
            dgvFormData.Columns["ClientPhone"].HeaderText = "رقم العميل";
            dgvFormData.Columns["OpponentName"].HeaderText = "اسم الخصم";
            dgvFormData.Columns["OpponentStatus"].HeaderText = "حاله الخصم";
            dgvFormData.Columns["OpponentAddress"].HeaderText = "عنوان الخصم";
            dgvFormData.Columns["OpponentPhone"].HeaderText = "رقم الخصم";
            dgvFormData.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvFormData.Columns["LastUpdatedBy"].HeaderText = "تم التحديث بواسطة";
            dgvFormData.Columns["Notes"].HeaderText = "ملاحظات";
        }
        private void CasesFilters()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("بدون");
            cbFilterBy.Items.Add("رقم القضيه");
            cbFilterBy.Items.Add("وصف القضيه");
            cbFilterBy.Items.Add("المحكمه");
            cbFilterBy.Items.Add("اسم العميل");
            cbFilterBy.Items.Add("حاله العميل");
            cbFilterBy.Items.Add("عنوان العميل");
            cbFilterBy.Items.Add("رقم العميل");
            cbFilterBy.Items.Add("اسم الخصم");
            cbFilterBy.Items.Add("حاله الخصم");
            cbFilterBy.Items.Add("عنوان الخصم");
            cbFilterBy.Items.Add("رقم الخصم");
            cbFilterBy.Items.Add("تم الانشاء بواسطة");
            cbFilterBy.Items.Add("تم التحديث بواسطة");
            cbFilterBy.Items.Add("ملاحظات");

            cbFilterBy.SelectedIndex = 0;

        }
        private void HandelCasesPage()
        {
            page = enPages.CasesPage;
            _dtAllCases = Case.GetAllCases();
            _dtCases = _dtAllCases.DefaultView.ToTable(false, "CaseNumber", "Title", "Court", "ClientName",
            "ClientStatus", "ClientAddress", "ClientPhone", "OpponentName", "OpponentStatus", "OpponentAddress", "OpponentPhone",
            "CreatedBy", "LastUpdatedBy", "Notes");

            if (_dtCases.Rows.Count > 0 )
            {
                dgvFormData.DataSource = _dtCases;
                CasesColumnsFormatting();
                CasesFilters();
            }
            else
            {
                // Reset if no data.
                dgvFormData.DataSource = null;
                cbFilterBy.Items.Clear();
            }

                dgvFormData.ContextMenuStrip = cmsCases;
            lblTitle.Text = "القضايا";
            btnAdd.Visible = false;
            cbFilter.Visible = false;
            lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            tsmiCases.BackColor = Color.GreenYellow;
            tsmiLawyers.BackColor = tsmiClients.BackColor = tsmiSessions.BackColor = tsmiInvoices.BackColor = tsmiUsers.BackColor = Color.Black;


        }
        private void SessionsColumnsFormatting()
        {
            dgvFormData.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvFormData.Columns["Title"].HeaderText = "وصف الجلسه";
            dgvFormData.Columns["RollNumber"].HeaderText = "رقم الجلسه";
            dgvFormData.Columns["Date"].HeaderText = "تاريخ الجلسه";
            dgvFormData.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvFormData.Columns["Court"].HeaderText = "اسم المحكمه";
            dgvFormData.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvFormData.Columns["LawyerName"].HeaderText = "اسم المحامي";
            dgvFormData.Columns["Requests"].HeaderText = "الطلبات";
            dgvFormData.Columns["Decision"].HeaderText = "القرار";
            dgvFormData.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvFormData.Columns["LastUpdatedBy"].HeaderText = "تم التحديث بواسطة";
            dgvFormData.Columns["SessionStatus"].HeaderText = "حاله الجلسه";
            dgvFormData.Columns["Notes"].HeaderText = "ملاحظات";

        }
        private void SessionsFilters()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("بدون");
            cbFilterBy.Items.Add("رقم القضيه");
            cbFilterBy.Items.Add("وصف الجلسه");
            cbFilterBy.Items.Add("اسم المحكمه");
            cbFilterBy.Items.Add("رقم الجلسه");
            cbFilterBy.Items.Add("تاريخ الجلسه");
            cbFilterBy.Items.Add("اسم العميل");
            cbFilterBy.Items.Add("اسم المحامي");
            cbFilterBy.Items.Add("الطلبات");
            cbFilterBy.Items.Add("القرار");
            cbFilterBy.Items.Add("تم الانشاء بواسطة");
            cbFilterBy.Items.Add("تم التحديث بواسطة");
            cbFilterBy.Items.Add("حاله الجلسه");
            cbFilterBy.Items.Add("ملاحظات");

            cbFilterBy.SelectedIndex = 0;

        }
        private void HandelSessionsPage()
        {
            page = enPages.SessionsPage;
            _dtAllSessions = Session.GetAllSessions();
            _dtSessions = _dtAllSessions.DefaultView.ToTable(false, "CaseNumber", "Title", "RollNumber", "Date",
            "Court", "ClientName", "LawyerName", "Requests", "Decision", "CreatedBy", "LastUpdatedBy", "SessionStatus", "Notes");

            if (_dtSessions.Rows.Count > 0 )
            {
                dgvFormData.DataSource = _dtSessions;
                SessionsColumnsFormatting();
                SessionsFilters();
            }
            else
            {
                // Reset if no data.
                dgvFormData.DataSource = null;
                cbFilterBy.Items.Clear();
            }

                dgvFormData.ContextMenuStrip = cmsSessions;
            lblTitle.Text = "الجلسات";
            btnAdd.Visible = false;
            cbFilter.Visible = false;
            lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            tsmiSessions.BackColor = Color.GreenYellow;
            tsmiLawyers.BackColor = tsmiClients.BackColor = tsmiCases.BackColor = tsmiInvoices.BackColor = tsmiUsers.BackColor = Color.Black;
        }
        private void InvoicesColumnsFormatting()
        {
            dgvFormData.Columns["ClientName"].HeaderText = "اسم العميل";
            dgvFormData.Columns["CaseNumber"].HeaderText = "رقم القضيه";
            dgvFormData.Columns["Title"].HeaderText = "وصف القضيه";
            dgvFormData.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvFormData.Columns["IssueDate"].HeaderText = "تاريخ الاصدار";
            dgvFormData.Columns["IssueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvFormData.Columns["LastUpdatedBy"].HeaderText = "تم التحديث بواسطة";
            dgvFormData.Columns["TotalAmount"].HeaderText = "المبلغ الكلي";
            dgvFormData.Columns["AmountPaid"].HeaderText = "المبلغ المدفوع";
            dgvFormData.Columns["AmountDue"].HeaderText = "المبلغ المتبقي";
            dgvFormData.Columns["Notes"].HeaderText = "ملاحظات";

        }
        private void InvoicesFilters()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("بدون");
            cbFilterBy.Items.Add("اسم العميل");
            cbFilterBy.Items.Add("رقم القضيه");
            cbFilterBy.Items.Add("وصف القضيه");
            cbFilterBy.Items.Add("تم الانشاء بواسطة");
            cbFilterBy.Items.Add("تاريخ الاصدار");
            cbFilterBy.Items.Add("تم التحديث بواسطة");
            cbFilterBy.Items.Add("ملاحظات");
            cbFilterBy.SelectedIndex = 0;

        }
        private void HandelInvoicesPage()
        {
            page = enPages.InvoicesPage;
            _dtAllInvoices = Invoice.GetAllInvoices();
            _dtInvoices = _dtAllInvoices.DefaultView.ToTable(false, "ClientName", "CaseNumber",
            "Title", "CreatedBy", "IssueDate", "LastUpdatedBy", "TotalAmount", "AmountPaid", "AmountDue", "Notes");

            if (_dtInvoices.Rows.Count > 0 )
            {
                dgvFormData.DataSource = _dtInvoices;
                InvoicesColumnsFormatting();
                InvoicesFilters();
            }
            else
            {
                // Reset if no data.
                dgvFormData.DataSource = null;
                cbFilterBy.Items.Clear();
            }

            dgvFormData.ContextMenuStrip = cmsInvoices;
            lblTitle.Text = "الفواتير";
            btnAdd.Visible = false;
            cbFilter.Visible = false;
            lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            tsmiInvoices.BackColor = Color.GreenYellow;
            tsmiLawyers.BackColor = tsmiClients.BackColor = tsmiCases.BackColor = tsmiSessions.BackColor = tsmiUsers.BackColor = Color.Black;

        }
        private void UsersColumnsFormatting()
        {
            dgvFormData.Columns["Username"].HeaderText = "اسم المستخدم";
            dgvFormData.Columns["UserStatus"].HeaderText = "حاله المستخدم";
            dgvFormData.Columns["JoinDate"].HeaderText = "تاريخ الانضمام";
            dgvFormData.Columns["JoinDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvFormData.Columns["CreatedBy"].HeaderText = "تم الانشاء بواسطة";
            dgvFormData.Columns["LastUpdatedBy"].HeaderText = "تم التحديث بواسطة";
            dgvFormData.Columns["Notes"].HeaderText = "ملاحظات";
        }
        public void UsersFilters()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("بدون");
            cbFilterBy.Items.Add("اسم المستخدم");
            cbFilterBy.Items.Add("حاله المستخدم");
            cbFilterBy.Items.Add("تاريخ الانضمام");
            cbFilterBy.Items.Add("تم الانشاء بواسطة");
            cbFilterBy.Items.Add("تم التحديث بواسطة");
            cbFilterBy.SelectedIndex = 0;
        }
        private void HandelUsersPage()
        {
            page = enPages.UsersPage;
            _dtAllUsers = User.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "Username", "UserStatus",
            "JoinDate", "CreatedBy", "LastUpdatedBy", "Notes");

            if (_dtUsers.Rows.Count > 0 )
            {
                dgvFormData.DataSource = _dtUsers;
                UsersColumnsFormatting();
                UsersFilters();
            }
            else
            {
                // Reset if no data.
                dgvFormData.DataSource = null;
                cbFilterBy.Items.Clear();
            }

                dgvFormData.ContextMenuStrip = cmsUsers;
            lblTitle.Text = "المستخدمين";
            btnAdd.Visible = true;
            btnAdd.Text = "اضافه مستخدم";
            cbFilter.Visible = false;
            lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";
            tsmiUsers.BackColor = Color.GreenYellow;
            tsmiLawyers.BackColor = tsmiClients.BackColor = tsmiCases.BackColor = tsmiSessions.BackColor = tsmiInvoices.BackColor = Color.Black;
        }
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            HandelClientsPage();
        }
        private void tsmiClients_Click(object sender, EventArgs e)
        {
            HandelClientsPage();
        }
        private void tsmiLawyers_Click(object sender, EventArgs e)
        {
            HandelLawyersPage();
        }

        private void tsmiCases_Click(object sender, EventArgs e)
        {
            HandelCasesPage();
        }

        private void tsmiSessions_Click(object sender, EventArgs e)
        {
            HandelSessionsPage();
        }
        private void tsmiInvoices_Click(object sender, EventArgs e)
        {
            HandelInvoicesPage();
        }
        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            HandelUsersPage();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (page == enPages.SessionsPage && FilterColumn == "RollNumber")
            {
                // Check if the key pressed is NOT a digit (0-9)
                // AND Check if it is NOT a control character (like Backspace)
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    // Block the character by setting e.Handled to true
                    e.Handled = true;
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (page == enPages.UsersPage)
            {
                if (cbFilter.SelectedItem.ToString() == "الكل")
                {
                    (_dtUsers.DefaultView).RowFilter = string.Empty;
                }
                else
                {
                    (_dtUsers.DefaultView).RowFilter = $"{FilterColumn} = '{cbFilter.SelectedItem.ToString()}'";
                }
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";

            }
            else if (page == enPages.SessionsPage)
            {
                if (cbFilter.SelectedItem.ToString() == "الكل")
                {
                    (_dtSessions.DefaultView).RowFilter = string.Empty;
                }
                else
                {
                    (_dtSessions.DefaultView).RowFilter = $"{FilterColumn} = '{cbFilter.SelectedItem.ToString()}'";
                }
                lblDataCount.Text = $"{dgvFormData.Rows.Count.ToString()}:";

            }
        }

        private void tsmiSignOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiShowClientDetails_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0 )
            {
                // Get clientId.
                int clientId = _dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] != DBNull.Value ?
                    (int)_dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] : 0;

                frmShowClientInfo frm = new frmShowClientInfo(clientId);
                frm.ShowDialog();
            }

        }

        private void tsmiAddNewClient_Click(object sender, EventArgs e)
        {
            frmAddUpdateClient frm = new frmAddUpdateClient();
            frm.ShowDialog();

            HandelClientsPage();
        }

        private void tsmiUpdateClient_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0 )
            {
                // Get clientId.
                int clientId = _dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] != DBNull.Value ?
                    (int)_dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] : 0;

                frmAddUpdateClient frm = new frmAddUpdateClient(clientId);
                frm.ShowDialog();

                HandelClientsPage();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (page == enPages.ClientsPage)
            {
                frmAddUpdateClient frm = new frmAddUpdateClient();
                frm.ShowDialog();

                HandelClientsPage();
            }
            else if (page == enPages.LawyersPage)
            {
                frmAddUpdateLawyer frm = new frmAddUpdateLawyer();
                frm.ShowDialog();

                HandelLawyersPage();
            }

        }

        private void tsmiDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                if (MessageBox.Show(
                       $"هل أنت متأكد أنك تريد حذف العميل الذي اسمه: {dgvFormData.CurrentRow.Cells[0].Value} ؟",
                       "تأكيد الحذف",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // Get clientId.
                    int clientId = _dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] != DBNull.Value ?
                        (int)_dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] : 0;

                    if (Client.DeleteClient(clientId))
                    {
                        MessageBox.Show("تم حذف العميل بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the data.
                        HandelClientsPage();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف العميل. ربما حدث خطأ.",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
           
        }
        // Show client info from cases page.
        private void tsmiShowClientInfo_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {

                // Get caseId.
                int caseId = _dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] : 0;
                
                Case caseInfo = Case.GetCase(caseId);

                if (caseInfo != null)
                {
                    frmShowClientInfo frm = new frmShowClientInfo(caseInfo.ClientId);
                    frm.ShowDialog();
                }
            }
        }

        private void tsmiShowLawyerInfo_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                // Get lawyerId.
                int lawyerId = _dtAllLawyers.Rows[dgvFormData.CurrentRow.Index]["LawyerId"] != DBNull.Value ?
                    (int)_dtAllLawyers.Rows[dgvFormData.CurrentRow.Index]["LawyerId"] : 0;

                frmShowLawyerInfo frm = new frmShowLawyerInfo(lawyerId);
                frm.ShowDialog();
            }
        }

        private void tsmiAddLawyer_Click(object sender, EventArgs e)
        {
            frmAddUpdateLawyer frm = new frmAddUpdateLawyer();
            frm.ShowDialog();

            HandelLawyersPage();
        }

        private void tsmiUpdateLawyer_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                // Get lawyerId.
                int lawyerId = _dtAllLawyers.Rows[dgvFormData.CurrentRow.Index]["LawyerId"] != DBNull.Value ?
                    (int)_dtAllLawyers.Rows[dgvFormData.CurrentRow.Index]["LawyerId"] : 0;

                frmAddUpdateLawyer frm = new frmAddUpdateLawyer(lawyerId);
                frm.ShowDialog();

                HandelLawyersPage();
            }
        }

        private void tsmiDeleteLawyer_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                if (MessageBox.Show(
                           $"هل أنت متأكد أنك تريد حذف المحامي الذي اسمه: {dgvFormData.CurrentRow.Cells[0].Value} ؟",
                           "تأكيد الحذف",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {

                    // Get lawyerId.
                    int lawyerId = _dtAllLawyers.Rows[dgvFormData.CurrentRow.Index]["LawyerId"] != DBNull.Value ?
                        (int)_dtAllLawyers.Rows[dgvFormData.CurrentRow.Index]["LawyerId"] : 0;

                    if (Lawyer.DeleteLawyer(lawyerId))
                    {
                        MessageBox.Show("تم حذف المحامي بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the data.
                        HandelLawyersPage();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف المحامي. ربما حدث خطأ.",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void tsmiShowCaseInfo_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                // Get caseId.
                int caseId = _dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] : 0;

                frmShowCaseInfo frm = new frmShowCaseInfo(caseId);
                frm.ShowDialog();
            }
        }

        private void tsmiEditCase_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                // Get caseId.
                int caseId = _dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] : 0;

                frmAddUpdateCase frm = new frmAddUpdateCase(caseId, frmAddUpdateCase.enMode.UpdateExisting);
                frm.ShowDialog();
            }
        }

        private void tsmiAddCase_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                // Get clientId.
                int clientId = _dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] != DBNull.Value ?
                    (int)_dtAllClients.Rows[dgvFormData.CurrentRow.Index]["ClientId"] : 0;

                frmAddUpdateCase frm = new frmAddUpdateCase(clientId, frmAddUpdateCase.enMode.AddNew);
                frm.ShowDialog();
            }
        }

        private void tsmiDeleteCase_Click(object sender, EventArgs e)
        {
            if (dgvFormData.Rows.Count > 0)
            {
                // 1. Get the Case ID and Title for the confirmation message
                // Assuming 'CaseId' is hidden in the grid and 'Title' is visible in column 1 (or adjust index as needed)
                // Using column names is safer than indexes.
                // Get caseId.
                int caseId = _dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] != DBNull.Value ?
                    (int)_dtAllCases.Rows[dgvFormData.CurrentRow.Index]["CaseId"] : 0;
                string caseTitle = dgvFormData.CurrentRow.Cells[1].Value.ToString();

                // 2. Show Confirmation Message
                if (MessageBox.Show(
                            $"هل أنت متأكد أنك تريد حذف القضية بعنوان: {caseTitle} ؟",
                            "تأكيد الحذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    // 3. Call the Business Layer to delete
                    if (Case.DeleteCase(caseId))
                    {
                        MessageBox.Show("تم حذف القضية بنجاح.", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Refresh the data grid
                        HandelCasesPage();
                    }
                    else
                    {
                        MessageBox.Show(
                            "لم يتم حذف القضية. ربما حدث خطأ أو أن القضية مرتبطة ببيانات أخرى (مثل الجلسات أو المستندات).",
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }

        }
    }
}
