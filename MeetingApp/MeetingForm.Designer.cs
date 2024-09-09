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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeetingForm));
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
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.MeetingType = new System.Windows.Forms.ComboBox();
            this.isImportant = new System.Windows.Forms.CheckBox();
            this.selecetAllAcedemic = new System.Windows.Forms.Button();
            this.selecetAllUsers = new System.Windows.Forms.Button();
            this.clrAcedemicSolo = new System.Windows.Forms.Button();
            this.clrUserSolo = new System.Windows.Forms.Button();
            this.clrEmployeeSolo = new System.Windows.Forms.Button();
            this.clrAcademicSolo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSelectedCompanies
            // 
            this.lbSelectedCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedCompanies.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedCompanies.FormattingEnabled = true;
            this.lbSelectedCompanies.ItemHeight = 16;
            this.lbSelectedCompanies.Location = new System.Drawing.Point(1317, 115);
            this.lbSelectedCompanies.Name = "lbSelectedCompanies";
            this.lbSelectedCompanies.Size = new System.Drawing.Size(199, 116);
            this.lbSelectedCompanies.TabIndex = 0;
            // 
            // lbSelectedUsers
            // 
            this.lbSelectedUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedUsers.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedUsers.FormattingEnabled = true;
            this.lbSelectedUsers.ItemHeight = 16;
            this.lbSelectedUsers.Location = new System.Drawing.Point(1314, 673);
            this.lbSelectedUsers.Margin = new System.Windows.Forms.Padding(0);
            this.lbSelectedUsers.Name = "lbSelectedUsers";
            this.lbSelectedUsers.Size = new System.Drawing.Size(199, 116);
            this.lbSelectedUsers.TabIndex = 1;
            // 
            // lbSelectedAcademics
            // 
            this.lbSelectedAcademics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedAcademics.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedAcademics.FormattingEnabled = true;
            this.lbSelectedAcademics.ItemHeight = 16;
            this.lbSelectedAcademics.Location = new System.Drawing.Point(1316, 463);
            this.lbSelectedAcademics.Margin = new System.Windows.Forms.Padding(0);
            this.lbSelectedAcademics.Name = "lbSelectedAcademics";
            this.lbSelectedAcademics.Size = new System.Drawing.Size(199, 148);
            this.lbSelectedAcademics.TabIndex = 2;
            // 
            // lbSelectedEmployees
            // 
            this.lbSelectedEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.lbSelectedEmployees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSelectedEmployees.FormattingEnabled = true;
            this.lbSelectedEmployees.ItemHeight = 16;
            this.lbSelectedEmployees.Location = new System.Drawing.Point(1315, 289);
            this.lbSelectedEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.lbSelectedEmployees.Name = "lbSelectedEmployees";
            this.lbSelectedEmployees.Size = new System.Drawing.Size(199, 116);
            this.lbSelectedEmployees.TabIndex = 3;
            // 
            // clbCompanies
            // 
            this.clbCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbCompanies.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbCompanies.FormattingEnabled = true;
            this.clbCompanies.Location = new System.Drawing.Point(21, 115);
            this.clbCompanies.Margin = new System.Windows.Forms.Padding(0);
            this.clbCompanies.Name = "clbCompanies";
            this.clbCompanies.Size = new System.Drawing.Size(199, 123);
            this.clbCompanies.TabIndex = 4;
            this.clbCompanies.SelectedIndexChanged += new System.EventHandler(this.clbCompanies_SelectedIndexChanged);
            // 
            // clbUsers
            // 
            this.clbUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbUsers.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbUsers.FormattingEnabled = true;
            this.clbUsers.Location = new System.Drawing.Point(18, 673);
            this.clbUsers.Margin = new System.Windows.Forms.Padding(0);
            this.clbUsers.Name = "clbUsers";
            this.clbUsers.Size = new System.Drawing.Size(199, 123);
            this.clbUsers.TabIndex = 5;
            // 
            // clbAcademics
            // 
            this.clbAcademics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbAcademics.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbAcademics.FormattingEnabled = true;
            this.clbAcademics.Location = new System.Drawing.Point(20, 496);
            this.clbAcademics.Margin = new System.Windows.Forms.Padding(0);
            this.clbAcademics.Name = "clbAcademics";
            this.clbAcademics.Size = new System.Drawing.Size(199, 123);
            this.clbAcademics.TabIndex = 6;
            // 
            // clbEmployees
            // 
            this.clbEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.clbEmployees.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clbEmployees.FormattingEnabled = true;
            this.clbEmployees.Location = new System.Drawing.Point(20, 289);
            this.clbEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.clbEmployees.Name = "clbEmployees";
            this.clbEmployees.Size = new System.Drawing.Size(199, 123);
            this.clbEmployees.TabIndex = 7;
            // 
            // btnAddCompanies
            // 
            this.btnAddCompanies.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddCompanies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCompanies.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnAddCompanies.ForeColor = System.Drawing.Color.White;
            this.btnAddCompanies.Location = new System.Drawing.Point(20, 238);
            this.btnAddCompanies.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCompanies.Name = "btnAddCompanies";
            this.btnAddCompanies.Size = new System.Drawing.Size(199, 25);
            this.btnAddCompanies.TabIndex = 8;
            this.btnAddCompanies.Text = "EKLE";
            this.btnAddCompanies.UseVisualStyleBackColor = false;
            this.btnAddCompanies.Click += new System.EventHandler(this.btnAddCompanies_Click);
            // 
            // btnAddUsers
            // 
            this.btnAddUsers.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUsers.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnAddUsers.ForeColor = System.Drawing.Color.White;
            this.btnAddUsers.Location = new System.Drawing.Point(18, 796);
            this.btnAddUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddUsers.Name = "btnAddUsers";
            this.btnAddUsers.Size = new System.Drawing.Size(153, 25);
            this.btnAddUsers.TabIndex = 9;
            this.btnAddUsers.Text = "EKLE";
            this.btnAddUsers.UseVisualStyleBackColor = false;
            this.btnAddUsers.Click += new System.EventHandler(this.btnAddUsers_Click);
            // 
            // btnAddAcademics
            // 
            this.btnAddAcademics.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddAcademics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAcademics.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnAddAcademics.ForeColor = System.Drawing.Color.White;
            this.btnAddAcademics.Location = new System.Drawing.Point(18, 619);
            this.btnAddAcademics.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddAcademics.Name = "btnAddAcademics";
            this.btnAddAcademics.Size = new System.Drawing.Size(154, 25);
            this.btnAddAcademics.TabIndex = 10;
            this.btnAddAcademics.Text = "EKLE";
            this.btnAddAcademics.UseVisualStyleBackColor = false;
            this.btnAddAcademics.Click += new System.EventHandler(this.btnAddAcademics_Click);
            // 
            // btnAddEmployees
            // 
            this.btnAddEmployees.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAddEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmployees.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnAddEmployees.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployees.Location = new System.Drawing.Point(20, 412);
            this.btnAddEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddEmployees.Name = "btnAddEmployees";
            this.btnAddEmployees.Size = new System.Drawing.Size(200, 25);
            this.btnAddEmployees.TabIndex = 11;
            this.btnAddEmployees.Text = "EKLE";
            this.btnAddEmployees.UseVisualStyleBackColor = false;
            this.btnAddEmployees.Click += new System.EventHandler(this.btnAddEmployees_Click);
            // 
            // btnSaveMeeting
            // 
            this.btnSaveMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveMeeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMeeting.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSaveMeeting.ForeColor = System.Drawing.Color.White;
            this.btnSaveMeeting.Location = new System.Drawing.Point(993, 759);
            this.btnSaveMeeting.Name = "btnSaveMeeting";
            this.btnSaveMeeting.Size = new System.Drawing.Size(175, 37);
            this.btnSaveMeeting.TabIndex = 18;
            this.btnSaveMeeting.Text = "Faaliyet Kaydet";
            this.btnSaveMeeting.UseVisualStyleBackColor = false;
            this.btnSaveMeeting.Click += new System.EventHandler(this.btnSaveMeeting_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.dtpDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpDate.Location = new System.Drawing.Point(375, 64);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(267, 27);
            this.dtpDate.TabIndex = 13;
            // 
            // dtpTime
            // 
            this.dtpTime.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.dtpTime.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(796, 66);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(196, 27);
            this.dtpTime.TabIndex = 14;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTitle.Location = new System.Drawing.Point(375, 106);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(620, 27);
            this.txtTitle.TabIndex = 15;
            // 
            // rtbNotes
            // 
            this.rtbNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.rtbNotes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.rtbNotes.Location = new System.Drawing.Point(375, 212);
            this.rtbNotes.MaxLength = 3000;
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(793, 399);
            this.rtbNotes.TabIndex = 17;
            this.rtbNotes.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(248, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Faaliyet Konusu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(248, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Alınan Notlar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(248, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tarih";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(739, 70);
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
            this.label5.Location = new System.Drawing.Point(21, 20);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10);
            this.label5.Size = new System.Drawing.Size(199, 41);
            this.label5.TabIndex = 26;
            this.label5.Text = "KATILIMCI SEÇ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Teal;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1314, 20);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10);
            this.label6.Size = new System.Drawing.Size(199, 41);
            this.label6.TabIndex = 26;
            this.label6.Text = "ÖNİZLEME";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clrCom
            // 
            this.clrCom.BackColor = System.Drawing.Color.OrangeRed;
            this.clrCom.FlatAppearance.BorderSize = 0;
            this.clrCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrCom.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.clrCom.ForeColor = System.Drawing.Color.White;
            this.clrCom.Location = new System.Drawing.Point(1359, 234);
            this.clrCom.Margin = new System.Windows.Forms.Padding(0);
            this.clrCom.Name = "clrCom";
            this.clrCom.Size = new System.Drawing.Size(156, 24);
            this.clrCom.TabIndex = 27;
            this.clrCom.Text = "Tümünü Sil";
            this.clrCom.UseVisualStyleBackColor = false;
            this.clrCom.Click += new System.EventHandler(this.clrCom_Click);
            // 
            // clrEmp
            // 
            this.clrEmp.BackColor = System.Drawing.Color.OrangeRed;
            this.clrEmp.FlatAppearance.BorderSize = 0;
            this.clrEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrEmp.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.clrEmp.ForeColor = System.Drawing.Color.White;
            this.clrEmp.Location = new System.Drawing.Point(1359, 405);
            this.clrEmp.Margin = new System.Windows.Forms.Padding(0);
            this.clrEmp.Name = "clrEmp";
            this.clrEmp.Size = new System.Drawing.Size(155, 24);
            this.clrEmp.TabIndex = 27;
            this.clrEmp.Text = "Tümünü Sil";
            this.clrEmp.UseVisualStyleBackColor = false;
            this.clrEmp.Click += new System.EventHandler(this.clrEmp_Click);
            // 
            // clrAca
            // 
            this.clrAca.BackColor = System.Drawing.Color.OrangeRed;
            this.clrAca.FlatAppearance.BorderSize = 0;
            this.clrAca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrAca.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.clrAca.ForeColor = System.Drawing.Color.White;
            this.clrAca.Location = new System.Drawing.Point(1360, 611);
            this.clrAca.Margin = new System.Windows.Forms.Padding(0);
            this.clrAca.Name = "clrAca";
            this.clrAca.Size = new System.Drawing.Size(156, 24);
            this.clrAca.TabIndex = 27;
            this.clrAca.Text = "Tümünü Sil";
            this.clrAca.UseVisualStyleBackColor = false;
            this.clrAca.Click += new System.EventHandler(this.clrAca_Click);
            // 
            // clrUser
            // 
            this.clrUser.BackColor = System.Drawing.Color.OrangeRed;
            this.clrUser.FlatAppearance.BorderSize = 0;
            this.clrUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrUser.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.clrUser.ForeColor = System.Drawing.Color.White;
            this.clrUser.Location = new System.Drawing.Point(1359, 789);
            this.clrUser.Margin = new System.Windows.Forms.Padding(0);
            this.clrUser.Name = "clrUser";
            this.clrUser.Size = new System.Drawing.Size(154, 24);
            this.clrUser.TabIndex = 27;
            this.clrUser.Text = "Tümünü Sil";
            this.clrUser.UseVisualStyleBackColor = false;
            this.clrUser.Click += new System.EventHandler(this.clrUser_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(248, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 28;
            this.label11.Text = "Faaliyet Yeri";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtLocation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLocation.Location = new System.Drawing.Point(375, 152);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(686, 27);
            this.txtLocation.TabIndex = 16;
            this.txtLocation.TextChanged += new System.EventHandler(this.txtLocation_TextChanged);
            // 
            // nameDocument
            // 
            this.nameDocument.AutoEllipsis = true;
            this.nameDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.nameDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameDocument.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.nameDocument.Location = new System.Drawing.Point(375, 622);
            this.nameDocument.Name = "nameDocument";
            this.nameDocument.Size = new System.Drawing.Size(793, 50);
            this.nameDocument.TabIndex = 30;
            // 
            // addDocument
            // 
            this.addDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.addDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDocument.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addDocument.ForeColor = System.Drawing.Color.White;
            this.addDocument.Location = new System.Drawing.Point(375, 713);
            this.addDocument.Name = "addDocument";
            this.addDocument.Size = new System.Drawing.Size(132, 37);
            this.addDocument.TabIndex = 31;
            this.addDocument.Text = "Belge Ekle";
            this.addDocument.UseVisualStyleBackColor = false;
            this.addDocument.Click += new System.EventHandler(this.addDocument_Click);
            // 
            // deleteFile
            // 
            this.deleteFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.deleteFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteFile.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteFile.ForeColor = System.Drawing.Color.White;
            this.deleteFile.Location = new System.Drawing.Point(375, 759);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(132, 37);
            this.deleteFile.TabIndex = 32;
            this.deleteFile.Text = "Sil";
            this.deleteFile.UseVisualStyleBackColor = false;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // searchCompany
            // 
            this.searchCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.searchCompany.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.searchCompany.Location = new System.Drawing.Point(21, 64);
            this.searchCompany.Name = "searchCompany";
            this.searchCompany.Size = new System.Drawing.Size(199, 27);
            this.searchCompany.TabIndex = 33;
            this.searchCompany.TextChanged += new System.EventHandler(this.searchCompany_TextChanged);
            // 
            // searchAcedemic
            // 
            this.searchAcedemic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.searchAcedemic.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.searchAcedemic.Location = new System.Drawing.Point(20, 466);
            this.searchAcedemic.Name = "searchAcedemic";
            this.searchAcedemic.Size = new System.Drawing.Size(199, 27);
            this.searchAcedemic.TabIndex = 34;
            this.searchAcedemic.TextChanged += new System.EventHandler(this.searchAcedemic_TextChanged);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(249, 628);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 44);
            this.label19.TabIndex = 35;
            this.label19.Text = "Eklenen Dosyalar";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 91);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.Size = new System.Drawing.Size(199, 24);
            this.label7.TabIndex = 36;
            this.label7.Text = "Şirketler";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 265);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.Size = new System.Drawing.Size(199, 24);
            this.label8.TabIndex = 36;
            this.label8.Text = "Şirket Çalışanları";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 439);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.Size = new System.Drawing.Size(199, 24);
            this.label9.TabIndex = 36;
            this.label9.Text = "Akademisyenler";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 648);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.Size = new System.Drawing.Size(199, 24);
            this.label10.TabIndex = 36;
            this.label10.Text = "TEKNOKENT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1317, 91);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3);
            this.label12.Size = new System.Drawing.Size(199, 24);
            this.label12.TabIndex = 36;
            this.label12.Text = "Şirketler";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(1315, 265);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(3);
            this.label13.Size = new System.Drawing.Size(199, 24);
            this.label13.TabIndex = 36;
            this.label13.Text = "Şirket Çalışanları";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(1316, 439);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3);
            this.label14.Size = new System.Drawing.Size(199, 24);
            this.label14.TabIndex = 36;
            this.label14.Text = "Akademisyenler";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(1314, 648);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(3);
            this.label15.Size = new System.Drawing.Size(199, 24);
            this.label15.TabIndex = 36;
            this.label15.Text = "TEKNOKENT";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(248, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 18);
            this.label16.TabIndex = 25;
            this.label16.Text = "Faaliyet Türü";
            // 
            // MeetingType
            // 
            this.MeetingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeetingType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingType.FormattingEnabled = true;
            this.MeetingType.Items.AddRange(new object[] {
            "ÜSİ",
            "Girişimcilik",
            "FSMH",
            "Süreç Yönetimi",
            "Etkinlik",
            "Uluslararasılaşma",
            "Genel/TTO"});
            this.MeetingType.Location = new System.Drawing.Point(375, 30);
            this.MeetingType.Name = "MeetingType";
            this.MeetingType.Size = new System.Drawing.Size(104, 27);
            this.MeetingType.TabIndex = 37;
            // 
            // isImportant
            // 
            this.isImportant.AutoSize = true;
            this.isImportant.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isImportant.Location = new System.Drawing.Point(539, 31);
            this.isImportant.Name = "isImportant";
            this.isImportant.Size = new System.Drawing.Size(143, 22);
            this.isImportant.TabIndex = 38;
            this.isImportant.Text = "Önemli Faaliyet";
            this.isImportant.UseVisualStyleBackColor = true;
            // 
            // selecetAllAcedemic
            // 
            this.selecetAllAcedemic.BackColor = System.Drawing.Color.CadetBlue;
            this.selecetAllAcedemic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selecetAllAcedemic.ForeColor = System.Drawing.Color.White;
            this.selecetAllAcedemic.Location = new System.Drawing.Point(172, 619);
            this.selecetAllAcedemic.Margin = new System.Windows.Forms.Padding(0);
            this.selecetAllAcedemic.Name = "selecetAllAcedemic";
            this.selecetAllAcedemic.Size = new System.Drawing.Size(48, 25);
            this.selecetAllAcedemic.TabIndex = 10;
            this.selecetAllAcedemic.Text = "Tüm";
            this.selecetAllAcedemic.UseVisualStyleBackColor = false;
            this.selecetAllAcedemic.Click += new System.EventHandler(this.selectAllAcademics_Click);
            // 
            // selecetAllUsers
            // 
            this.selecetAllUsers.BackColor = System.Drawing.Color.CadetBlue;
            this.selecetAllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selecetAllUsers.ForeColor = System.Drawing.Color.White;
            this.selecetAllUsers.Location = new System.Drawing.Point(171, 796);
            this.selecetAllUsers.Margin = new System.Windows.Forms.Padding(0);
            this.selecetAllUsers.Name = "selecetAllUsers";
            this.selecetAllUsers.Size = new System.Drawing.Size(48, 25);
            this.selecetAllUsers.TabIndex = 10;
            this.selecetAllUsers.Text = "Tüm";
            this.selecetAllUsers.UseVisualStyleBackColor = false;
            this.selecetAllUsers.Click += new System.EventHandler(this.selectAllUsers_Click);
            // 
            // clrAcedemicSolo
            // 
            this.clrAcedemicSolo.BackColor = System.Drawing.Color.Coral;
            this.clrAcedemicSolo.FlatAppearance.BorderSize = 0;
            this.clrAcedemicSolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrAcedemicSolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrAcedemicSolo.ForeColor = System.Drawing.Color.White;
            this.clrAcedemicSolo.Location = new System.Drawing.Point(1316, 611);
            this.clrAcedemicSolo.Margin = new System.Windows.Forms.Padding(0);
            this.clrAcedemicSolo.Name = "clrAcedemicSolo";
            this.clrAcedemicSolo.Size = new System.Drawing.Size(44, 24);
            this.clrAcedemicSolo.TabIndex = 27;
            this.clrAcedemicSolo.Text = "Sil";
            this.clrAcedemicSolo.UseVisualStyleBackColor = false;
            this.clrAcedemicSolo.Click += new System.EventHandler(this.clrAcedemicSolo_Click);
            // 
            // clrUserSolo
            // 
            this.clrUserSolo.BackColor = System.Drawing.Color.Coral;
            this.clrUserSolo.FlatAppearance.BorderSize = 0;
            this.clrUserSolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrUserSolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrUserSolo.ForeColor = System.Drawing.Color.White;
            this.clrUserSolo.Location = new System.Drawing.Point(1315, 789);
            this.clrUserSolo.Margin = new System.Windows.Forms.Padding(0);
            this.clrUserSolo.Name = "clrUserSolo";
            this.clrUserSolo.Size = new System.Drawing.Size(44, 24);
            this.clrUserSolo.TabIndex = 27;
            this.clrUserSolo.Text = "Sil";
            this.clrUserSolo.UseVisualStyleBackColor = false;
            this.clrUserSolo.Click += new System.EventHandler(this.clrUserSolo_Click);
            // 
            // clrEmployeeSolo
            // 
            this.clrEmployeeSolo.BackColor = System.Drawing.Color.Coral;
            this.clrEmployeeSolo.FlatAppearance.BorderSize = 0;
            this.clrEmployeeSolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrEmployeeSolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrEmployeeSolo.ForeColor = System.Drawing.Color.White;
            this.clrEmployeeSolo.Location = new System.Drawing.Point(1315, 405);
            this.clrEmployeeSolo.Margin = new System.Windows.Forms.Padding(0);
            this.clrEmployeeSolo.Name = "clrEmployeeSolo";
            this.clrEmployeeSolo.Size = new System.Drawing.Size(44, 24);
            this.clrEmployeeSolo.TabIndex = 27;
            this.clrEmployeeSolo.Text = "Sil";
            this.clrEmployeeSolo.UseVisualStyleBackColor = false;
            this.clrEmployeeSolo.Click += new System.EventHandler(this.clrEmployeeSolo_Click);
            // 
            // clrAcademicSolo
            // 
            this.clrAcademicSolo.BackColor = System.Drawing.Color.Coral;
            this.clrAcademicSolo.FlatAppearance.BorderSize = 0;
            this.clrAcademicSolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrAcademicSolo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clrAcademicSolo.ForeColor = System.Drawing.Color.White;
            this.clrAcademicSolo.Location = new System.Drawing.Point(1317, 234);
            this.clrAcademicSolo.Margin = new System.Windows.Forms.Padding(0);
            this.clrAcademicSolo.Name = "clrAcademicSolo";
            this.clrAcademicSolo.Size = new System.Drawing.Size(44, 24);
            this.clrAcademicSolo.TabIndex = 27;
            this.clrAcademicSolo.Text = "Sil";
            this.clrAcademicSolo.UseVisualStyleBackColor = false;
            this.clrAcademicSolo.Click += new System.EventHandler(this.clrCompanySolo_Click);
            // 
            // MeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1532, 829);
            this.Controls.Add(this.isImportant);
            this.Controls.Add(this.MeetingType);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.searchAcedemic);
            this.Controls.Add(this.searchCompany);
            this.Controls.Add(this.deleteFile);
            this.Controls.Add(this.addDocument);
            this.Controls.Add(this.nameDocument);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.clrUser);
            this.Controls.Add(this.clrUserSolo);
            this.Controls.Add(this.clrAcademicSolo);
            this.Controls.Add(this.clrEmployeeSolo);
            this.Controls.Add(this.clrAcedemicSolo);
            this.Controls.Add(this.clrAca);
            this.Controls.Add(this.clrEmp);
            this.Controls.Add(this.clrCom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSelectedEmployees);
            this.Controls.Add(this.btnAddEmployees);
            this.Controls.Add(this.clbEmployees);
            this.Controls.Add(this.lbSelectedAcademics);
            this.Controls.Add(this.selecetAllUsers);
            this.Controls.Add(this.selecetAllAcedemic);
            this.Controls.Add(this.btnAddAcademics);
            this.Controls.Add(this.clbAcademics);
            this.Controls.Add(this.lbSelectedUsers);
            this.Controls.Add(this.btnAddUsers);
            this.Controls.Add(this.clbUsers);
            this.Controls.Add(this.lbSelectedCompanies);
            this.Controls.Add(this.btnAddCompanies);
            this.Controls.Add(this.clbCompanies);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.btnSaveMeeting);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MeetingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faaliyet Ekle";
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
        public DateTimePicker dtpDate;
        public DateTimePicker dtpTime;
        private TextBox txtTitle;
        private Label label19;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private ComboBox MeetingType;
        private CheckBox isImportant;
        private Button selecetAllAcedemic;
        private Button selecetAllUsers;
        private Button clrAcedemicSolo;
        private Button clrUserSolo;
        private Button clrEmployeeSolo;
        private Button clrAcademicSolo;
    }
}
