using System.Windows.Forms;

namespace MeetingApp
{
    partial class MeetingForm
    {
        private System.Windows.Forms.ListBox lbSelectedCompanies;
        private System.Windows.Forms.ListBox lbSelectedUsers;
        private System.Windows.Forms.ListBox lbSelectedAcademics;
        private System.Windows.Forms.ListBox lbSelectedEmployees;
        private System.Windows.Forms.CheckedListBox clbCompanies;
        private System.Windows.Forms.CheckedListBox clbUsers;
        private System.Windows.Forms.CheckedListBox clbAcademics;
        private System.Windows.Forms.CheckedListBox clbEmployees;
        private System.Windows.Forms.Button btnAddCompanies;
        private System.Windows.Forms.Button btnAddUsers;
        private System.Windows.Forms.Button btnAddAcademics;
        private System.Windows.Forms.Button btnAddEmployees;
        private System.Windows.Forms.Button btnSaveMeeting;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblAcademics;
        private System.Windows.Forms.Label lblEmployees;
        private void InitializeComponent() {
            this.lbSelectedCompanies = new System.Windows.Forms.ListBox();
            this.lbSelectedUsers = new System.Windows.Forms.ListBox();
            this.lbSelectedAcademics = new System.Windows.Forms.ListBox();
            this.lbSelectedEmployees = new System.Windows.Forms.ListBox();
            this.clbCompanies = new System.Windows.Forms.CheckedListBox();
            this.clbUsers = new System.Windows.Forms.CheckedListBox();
            this.clbAcademics = new System.Windows.Forms.CheckedListBox();
            this.clbEmployees = new System.Windows.Forms.CheckedListBox();
            this.btnAddCompanies = new System.Windows.Forms.Button();
            this.btnAddUsers = new System.Windows.Forms.Button();
            this.btnAddAcademics = new System.Windows.Forms.Button();
            this.btnAddEmployees = new System.Windows.Forms.Button();
            this.btnSaveMeeting = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblAcademics = new System.Windows.Forms.Label();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clrCom = new System.Windows.Forms.Button();
            this.clrEmp = new System.Windows.Forms.Button();
            this.clrAca = new System.Windows.Forms.Button();
            this.clrUser = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.nameDocument = new System.Windows.Forms.Label();
            this.addDocument = new System.Windows.Forms.Button();
            this.deleteFile = new System.Windows.Forms.Button();
            this.searchCompany = new System.Windows.Forms.TextBox();
            this.searchAcedemic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSelectedCompanies
            // 
            this.lbSelectedCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedCompanies.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedCompanies.FormattingEnabled = true;
            this.lbSelectedCompanies.ItemHeight = 16;
            this.lbSelectedCompanies.Location = new System.Drawing.Point(989, 119);
            this.lbSelectedCompanies.Name = "lbSelectedCompanies";
            this.lbSelectedCompanies.Size = new System.Drawing.Size(156, 148);
            this.lbSelectedCompanies.TabIndex = 0;
            // 
            // lbSelectedUsers
            // 
            this.lbSelectedUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedUsers.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedUsers.FormattingEnabled = true;
            this.lbSelectedUsers.ItemHeight = 16;
            this.lbSelectedUsers.Location = new System.Drawing.Point(989, 641);
            this.lbSelectedUsers.Margin = new System.Windows.Forms.Padding(0);
            this.lbSelectedUsers.Name = "lbSelectedUsers";
            this.lbSelectedUsers.Size = new System.Drawing.Size(156, 132);
            this.lbSelectedUsers.TabIndex = 1;
            // 
            // lbSelectedAcademics
            // 
            this.lbSelectedAcademics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedAcademics.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedAcademics.FormattingEnabled = true;
            this.lbSelectedAcademics.ItemHeight = 16;
            this.lbSelectedAcademics.Location = new System.Drawing.Point(989, 469);
            this.lbSelectedAcademics.Margin = new System.Windows.Forms.Padding(0);
            this.lbSelectedAcademics.Name = "lbSelectedAcademics";
            this.lbSelectedAcademics.Size = new System.Drawing.Size(156, 148);
            this.lbSelectedAcademics.TabIndex = 2;
            // 
            // lbSelectedEmployees
            // 
            this.lbSelectedEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedEmployees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedEmployees.FormattingEnabled = true;
            this.lbSelectedEmployees.ItemHeight = 16;
            this.lbSelectedEmployees.Location = new System.Drawing.Point(989, 290);
            this.lbSelectedEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.lbSelectedEmployees.Name = "lbSelectedEmployees";
            this.lbSelectedEmployees.Size = new System.Drawing.Size(156, 148);
            this.lbSelectedEmployees.TabIndex = 3;
            // 
            // clbCompanies
            // 
            this.clbCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbCompanies.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbCompanies.FormattingEnabled = true;
            this.clbCompanies.Location = new System.Drawing.Point(12, 115);
            this.clbCompanies.Margin = new System.Windows.Forms.Padding(0);
            this.clbCompanies.Name = "clbCompanies";
            this.clbCompanies.Size = new System.Drawing.Size(156, 140);
            this.clbCompanies.TabIndex = 4;
            this.clbCompanies.SelectedIndexChanged += new System.EventHandler(this.clbCompanies_SelectedIndexChanged);
            // 
            // clbUsers
            // 
            this.clbUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbUsers.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbUsers.FormattingEnabled = true;
            this.clbUsers.Location = new System.Drawing.Point(12, 642);
            this.clbUsers.Margin = new System.Windows.Forms.Padding(0);
            this.clbUsers.Name = "clbUsers";
            this.clbUsers.Size = new System.Drawing.Size(156, 123);
            this.clbUsers.TabIndex = 5;
            // 
            // clbAcademics
            // 
            this.clbAcademics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbAcademics.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbAcademics.FormattingEnabled = true;
            this.clbAcademics.Location = new System.Drawing.Point(12, 477);
            this.clbAcademics.Margin = new System.Windows.Forms.Padding(0);
            this.clbAcademics.Name = "clbAcademics";
            this.clbAcademics.Size = new System.Drawing.Size(156, 140);
            this.clbAcademics.TabIndex = 6;
            // 
            // clbEmployees
            // 
            this.clbEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbEmployees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbEmployees.FormattingEnabled = true;
            this.clbEmployees.Location = new System.Drawing.Point(12, 281);
            this.clbEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.clbEmployees.Name = "clbEmployees";
            this.clbEmployees.Size = new System.Drawing.Size(156, 140);
            this.clbEmployees.TabIndex = 7;
            // 
            // btnAddCompanies
            // 
            this.btnAddCompanies.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddCompanies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCompanies.ForeColor = System.Drawing.Color.White;
            this.btnAddCompanies.Location = new System.Drawing.Point(174, 115);
            this.btnAddCompanies.Name = "btnAddCompanies";
            this.btnAddCompanies.Size = new System.Drawing.Size(23, 140);
            this.btnAddCompanies.TabIndex = 8;
            this.btnAddCompanies.Text = "EKLE";
            this.btnAddCompanies.UseVisualStyleBackColor = false;
            this.btnAddCompanies.Click += new System.EventHandler(this.btnAddCompanies_Click);
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUsers.ForeColor = System.Drawing.Color.White;
            this.btnAddUsers.Location = new System.Drawing.Point(174, 642);
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.Size = new System.Drawing.Size(23, 123);
            this.btnAddUsers.TabIndex = 9;
            this.btnAddUsers.Text = "EKLE";
            this.btnAddUsers.UseVisualStyleBackColor = false;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // btnAddAcademics
            // 
            this.btnAddAcademics.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddAcademics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAcademics.ForeColor = System.Drawing.Color.White;
            this.btnAddAcademics.Location = new System.Drawing.Point(174, 477);
            this.btnAddAcademics.Name = "btnAddAcademics";
            this.btnAddAcademics.Size = new System.Drawing.Size(23, 140);
            this.btnAddAcademics.TabIndex = 10;
            this.btnAddAcademics.Text = "EKLE";
            this.btnAddAcademics.UseVisualStyleBackColor = false;
            this.btnAddAcademics.Click += new System.EventHandler(this.btnAddAcademics_Click);
            // 
            // btnAddEmployees
            // 
            this.btnAddEmployees.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmployees.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployees.Location = new System.Drawing.Point(174, 281);
            this.btnAddEmployees.Name = "btnAddEmployees";
            this.btnAddEmployees.Size = new System.Drawing.Size(23, 140);
            this.btnAddEmployees.TabIndex = 11;
            this.btnAddEmployees.Text = "EKLE";
            this.btnAddEmployees.UseVisualStyleBackColor = false;
            this.btnAddEmployees.Click += new System.EventHandler(this.btnAddEmployees_Click);
            // 
            // btnSaveMeeting
            // 
            this.btnSaveMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveMeeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMeeting.ForeColor = System.Drawing.Color.White;
            this.btnSaveMeeting.Location = new System.Drawing.Point(790, 619);
            this.btnSaveMeeting.Name = "btnSaveMeeting";
            this.btnSaveMeeting.Size = new System.Drawing.Size(142, 43);
            this.btnSaveMeeting.TabIndex = 18;
            this.btnSaveMeeting.Text = "Toplantı Kaydet";
            this.btnSaveMeeting.UseVisualStyleBackColor = false;
            this.btnSaveMeeting.Click += new System.EventHandler(this.btnSaveMeeting_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.dtpDate.Location = new System.Drawing.Point(267, 43);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 23);
            this.dtpDate.TabIndex = 13;
            // 
            // dtpTime
            // 
            this.dtpTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(525, 43);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(200, 23);
            this.dtpTime.TabIndex = 14;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtTitle.Location = new System.Drawing.Point(222, 99);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(557, 23);
            this.txtTitle.TabIndex = 15;
            // 
            // rtbNotes
            // 
            this.rtbNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.rtbNotes.Location = new System.Drawing.Point(222, 205);
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(710, 403);
            this.rtbNotes.TabIndex = 17;
            this.rtbNotes.Text = "";
            // 
            // lblUsers
            // 
            this.lblUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblUsers.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUsers.ForeColor = System.Drawing.Color.White;
            this.lblUsers.Location = new System.Drawing.Point(12, 620);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(156, 22);
            this.lblUsers.TabIndex = 18;
            this.lblUsers.Text = "TEKNOKENT";
            this.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAcademics
            // 
            this.lblAcademics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAcademics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblAcademics.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAcademics.ForeColor = System.Drawing.Color.White;
            this.lblAcademics.Location = new System.Drawing.Point(12, 450);
            this.lblAcademics.Name = "lblAcademics";
            this.lblAcademics.Size = new System.Drawing.Size(156, 27);
            this.lblAcademics.TabIndex = 19;
            this.lblAcademics.Text = "Akademisyenler";
            this.lblAcademics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmployees
            // 
            this.lblEmployees.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEmployees.ForeColor = System.Drawing.Color.White;
            this.lblEmployees.Location = new System.Drawing.Point(12, 255);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(156, 26);
            this.lblEmployees.TabIndex = 20;
            this.lblEmployees.Text = "Şirket Çalışanları";
            this.lblEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Toplantı Konusu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Alınan Notlar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tarih";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Saat";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10);
            this.label5.Size = new System.Drawing.Size(156, 41);
            this.label5.TabIndex = 26;
            this.label5.Text = "KATILIMCI SEÇ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Teal;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(989, 20);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10);
            this.label6.Size = new System.Drawing.Size(156, 41);
            this.label6.TabIndex = 26;
            this.label6.Text = "ÖNİZLEME";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clrCom
            // 
            this.clrCom.BackColor = System.Drawing.Color.OrangeRed;
            this.clrCom.FlatAppearance.BorderSize = 0;
            this.clrCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrCom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrCom.ForeColor = System.Drawing.Color.White;
            this.clrCom.Location = new System.Drawing.Point(960, 119);
            this.clrCom.Name = "clrCom";
            this.clrCom.Size = new System.Drawing.Size(23, 148);
            this.clrCom.TabIndex = 27;
            this.clrCom.Text = "SİL";
            this.clrCom.UseVisualStyleBackColor = false;
            this.clrCom.Click += new System.EventHandler(this.clrCom_Click);
            // 
            // clrEmp
            // 
            this.clrEmp.BackColor = System.Drawing.Color.OrangeRed;
            this.clrEmp.FlatAppearance.BorderSize = 0;
            this.clrEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrEmp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrEmp.ForeColor = System.Drawing.Color.White;
            this.clrEmp.Location = new System.Drawing.Point(960, 290);
            this.clrEmp.Name = "clrEmp";
            this.clrEmp.Size = new System.Drawing.Size(23, 148);
            this.clrEmp.TabIndex = 27;
            this.clrEmp.Text = "SİL";
            this.clrEmp.UseVisualStyleBackColor = false;
            this.clrEmp.Click += new System.EventHandler(this.clrEmp_Click);
            // 
            // clrAca
            // 
            this.clrAca.BackColor = System.Drawing.Color.OrangeRed;
            this.clrAca.FlatAppearance.BorderSize = 0;
            this.clrAca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrAca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrAca.ForeColor = System.Drawing.Color.White;
            this.clrAca.Location = new System.Drawing.Point(960, 469);
            this.clrAca.Name = "clrAca";
            this.clrAca.Size = new System.Drawing.Size(23, 148);
            this.clrAca.TabIndex = 27;
            this.clrAca.Text = "SİL";
            this.clrAca.UseVisualStyleBackColor = false;
            this.clrAca.Click += new System.EventHandler(this.clrAca_Click);
            // 
            // clrUser
            // 
            this.clrUser.BackColor = System.Drawing.Color.OrangeRed;
            this.clrUser.FlatAppearance.BorderSize = 0;
            this.clrUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrUser.ForeColor = System.Drawing.Color.White;
            this.clrUser.Location = new System.Drawing.Point(960, 642);
            this.clrUser.Name = "clrUser";
            this.clrUser.Size = new System.Drawing.Size(23, 131);
            this.clrUser.TabIndex = 27;
            this.clrUser.Text = "SİL";
            this.clrUser.UseVisualStyleBackColor = false;
            this.clrUser.Click += new System.EventHandler(this.clrUser_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(222, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Toplantı Yeri";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtLocation.Location = new System.Drawing.Point(222, 152);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(625, 23);
            this.txtLocation.TabIndex = 16;
            // 
            // nameDocument
            // 
            this.nameDocument.AutoSize = true;
            this.nameDocument.Location = new System.Drawing.Point(379, 626);
            this.nameDocument.Name = "nameDocument";
            this.nameDocument.Size = new System.Drawing.Size(0, 16);
            this.nameDocument.TabIndex = 30;
            // 
            // addDocument
            // 
            this.addDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.addDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDocument.ForeColor = System.Drawing.Color.White;
            this.addDocument.Location = new System.Drawing.Point(222, 619);
            this.addDocument.Name = "addDocument";
            this.addDocument.Size = new System.Drawing.Size(142, 43);
            this.addDocument.TabIndex = 31;
            this.addDocument.Text = "Belge Ekle";
            this.addDocument.UseVisualStyleBackColor = false;
            this.addDocument.Click += new System.EventHandler(this.addDocument_Click);
            // 
            // deleteFile
            // 
            this.deleteFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.deleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteFile.ForeColor = System.Drawing.Color.White;
            this.deleteFile.Location = new System.Drawing.Point(222, 668);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(142, 27);
            this.deleteFile.TabIndex = 32;
            this.deleteFile.Text = "Sil";
            this.deleteFile.UseVisualStyleBackColor = false;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // searchCompany
            // 
            this.searchCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.searchCompany.Location = new System.Drawing.Point(12, 68);
            this.searchCompany.Name = "searchCompany";
            this.searchCompany.Size = new System.Drawing.Size(156, 23);
            this.searchCompany.TabIndex = 33;
            this.searchCompany.TextChanged += new System.EventHandler(this.searchCompany_TextChanged);
            // 
            // searchAcedemic
            // 
            this.searchAcedemic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.searchAcedemic.Location = new System.Drawing.Point(12, 424);
            this.searchAcedemic.Name = "searchAcedemic";
            this.searchAcedemic.Size = new System.Drawing.Size(156, 23);
            this.searchAcedemic.TabIndex = 34;
            this.searchAcedemic.TextChanged += new System.EventHandler(this.searchAcedemic_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(989, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Şirketler";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 21);
            this.label13.TabIndex = 17;
            this.label13.Text = "Şirketler";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(989, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 23);
            this.label10.TabIndex = 20;
            this.label10.Text = "Şirket Çalışanları";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(989, 442);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 27);
            this.label9.TabIndex = 19;
            this.label9.Text = "Akademisyenler";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(989, 619);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 22);
            this.label8.TabIndex = 18;
            this.label8.Text = "TEKNOKENT";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MeetingForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1160, 787);
            this.Controls.Add(this.searchAcedemic);
            this.Controls.Add(this.searchCompany);
            this.Controls.Add(this.deleteFile);
            this.Controls.Add(this.addDocument);
            this.Controls.Add(this.nameDocument);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.clrUser);
            this.Controls.Add(this.clrAca);
            this.Controls.Add(this.clrEmp);
            this.Controls.Add(this.clrCom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSelectedEmployees);
            this.Controls.Add(this.btnAddEmployees);
            this.Controls.Add(this.clbEmployees);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblEmployees);
            this.Controls.Add(this.lbSelectedAcademics);
            this.Controls.Add(this.btnAddAcademics);
            this.Controls.Add(this.clbAcademics);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAcademics);
            this.Controls.Add(this.lbSelectedUsers);
            this.Controls.Add(this.btnAddUsers);
            this.Controls.Add(this.clbUsers);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lbSelectedCompanies);
            this.Controls.Add(this.btnAddCompanies);
            this.Controls.Add(this.clbCompanies);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.btnSaveMeeting);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MeetingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüşme Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button clrCom;
        private Button clrEmp;
        private Button clrAca;
        private Button clrUser;
        private Label label11;
        private TextBox txtLocation;
        private Label nameDocument;
        private Button addDocument;
        private Button deleteFile;
        private TextBox searchCompany;
        private TextBox searchAcedemic;
        private Label label7;
        private Label label13;
        private Label label10;
        private Label label9;
        private Label label8;
        public DateTimePicker dtpDate;
        public DateTimePicker dtpTime;
        private TextBox txtTitle;
    }
}
