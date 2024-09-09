using System;
using System.Windows.Forms;

namespace MeetingApp
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.renewMeetings = new System.Windows.Forms.Button();
            this.dgvMeetings = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.isImportant = new System.Windows.Forms.CheckBox();
            this.customDateRange = new System.Windows.Forms.CheckBox();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.MeetingType = new System.Windows.Forms.ComboBox();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.reportConditions = new System.Windows.Forms.Button();
            this.chkAcd = new System.Windows.Forms.CheckBox();
            this.lisrConditions = new System.Windows.Forms.Button();
            this.chkUser = new System.Windows.Forms.CheckBox();
            this.chkCom = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPArticipants = new System.Windows.Forms.Label();
            this.listAcedemics = new System.Windows.Forms.ComboBox();
            this.listUsers = new System.Windows.Forms.ComboBox();
            this.listCompany = new System.Windows.Forms.ComboBox();
            this.searchEvent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.listEmployee = new System.Windows.Forms.ComboBox();
            this.chkEmployee = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(875, 765);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(257, 69);
            this.btnGenerateReport.TabIndex = 6;
            this.btnGenerateReport.Text = "Rapor Oluştur";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // renewMeetings
            // 
            this.renewMeetings.BackColor = System.Drawing.Color.Orange;
            this.renewMeetings.FlatAppearance.BorderSize = 0;
            this.renewMeetings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renewMeetings.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.renewMeetings.ForeColor = System.Drawing.Color.White;
            this.renewMeetings.Location = new System.Drawing.Point(11, 765);
            this.renewMeetings.Margin = new System.Windows.Forms.Padding(4);
            this.renewMeetings.Name = "renewMeetings";
            this.renewMeetings.Size = new System.Drawing.Size(257, 69);
            this.renewMeetings.TabIndex = 5;
            this.renewMeetings.Text = "Yenile";
            this.renewMeetings.UseVisualStyleBackColor = false;
            this.renewMeetings.Click += new System.EventHandler(this.renewMeetings_Click);
            // 
            // dgvMeetings
            // 
            this.dgvMeetings.AllowUserToAddRows = false;
            this.dgvMeetings.AllowUserToDeleteRows = false;
            this.dgvMeetings.AllowUserToResizeColumns = false;
            this.dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMeetings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMeetings.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeetings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeetings.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvMeetings.Location = new System.Drawing.Point(11, 100);
            this.dgvMeetings.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMeetings.MultiSelect = false;
            this.dgvMeetings.Name = "dgvMeetings";
            this.dgvMeetings.ReadOnly = true;
            this.dgvMeetings.RowHeadersVisible = false;
            this.dgvMeetings.RowHeadersWidth = 51;
            this.dgvMeetings.RowTemplate.Height = 24;
            this.dgvMeetings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetings.Size = new System.Drawing.Size(1121, 657);
            this.dgvMeetings.TabIndex = 4;
            this.dgvMeetings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeetings_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.isImportant);
            this.panel1.Controls.Add(this.customDateRange);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.MeetingType);
            this.panel1.Controls.Add(this.dateTimeStart);
            this.panel1.Controls.Add(this.reportConditions);
            this.panel1.Controls.Add(this.chkAcd);
            this.panel1.Controls.Add(this.lisrConditions);
            this.panel1.Controls.Add(this.chkEmployee);
            this.panel1.Controls.Add(this.chkUser);
            this.panel1.Controls.Add(this.chkCom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelEmployee);
            this.panel1.Controls.Add(this.labelPArticipants);
            this.panel1.Controls.Add(this.listAcedemics);
            this.panel1.Controls.Add(this.listUsers);
            this.panel1.Controls.Add(this.listCompany);
            this.panel1.Controls.Add(this.listEmployee);
            this.panel1.Location = new System.Drawing.Point(1152, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 840);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 8);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(287, 52);
            this.label1.TabIndex = 28;
            this.label1.Text = "Raporlama";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(92, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 54;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // isImportant
            // 
            this.isImportant.AutoSize = true;
            this.isImportant.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isImportant.Location = new System.Drawing.Point(92, 109);
            this.isImportant.Name = "isImportant";
            this.isImportant.Size = new System.Drawing.Size(202, 29);
            this.isImportant.TabIndex = 53;
            this.isImportant.Text = "  Önemli Faaliyet";
            this.isImportant.UseVisualStyleBackColor = true;
            // 
            // customDateRange
            // 
            this.customDateRange.AutoSize = true;
            this.customDateRange.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.customDateRange.Location = new System.Drawing.Point(55, 534);
            this.customDateRange.Name = "customDateRange";
            this.customDateRange.Size = new System.Drawing.Size(149, 29);
            this.customDateRange.TabIndex = 44;
            this.customDateRange.Text = "Tarihe Göre";
            this.customDateRange.UseVisualStyleBackColor = true;
            this.customDateRange.CheckedChanged += new System.EventHandler(this.customDateRange_CheckedChanged);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Enabled = false;
            this.dateTimeEnd.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimeEnd.Location = new System.Drawing.Point(55, 619);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(285, 33);
            this.dateTimeEnd.TabIndex = 43;
            // 
            // MeetingType
            // 
            this.MeetingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeetingType.Enabled = false;
            this.MeetingType.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MeetingType.FormattingEnabled = true;
            this.MeetingType.Items.AddRange(new object[] {
            "ÜSİ",
            "Girişimcilik",
            "FSMH",
            "Süreç Yönetimi",
            "Etkinlik",
            "Uluslararasılaşma",
            "Genel/TTO"});
            this.MeetingType.Location = new System.Drawing.Point(127, 71);
            this.MeetingType.Name = "MeetingType";
            this.MeetingType.Size = new System.Drawing.Size(155, 32);
            this.MeetingType.TabIndex = 52;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Enabled = false;
            this.dateTimeStart.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimeStart.Location = new System.Drawing.Point(55, 571);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(285, 33);
            this.dateTimeStart.TabIndex = 42;
            // 
            // reportConditions
            // 
            this.reportConditions.BackColor = System.Drawing.Color.SteelBlue;
            this.reportConditions.FlatAppearance.BorderSize = 0;
            this.reportConditions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportConditions.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.reportConditions.ForeColor = System.Drawing.Color.White;
            this.reportConditions.Location = new System.Drawing.Point(55, 759);
            this.reportConditions.Margin = new System.Windows.Forms.Padding(4);
            this.reportConditions.Name = "reportConditions";
            this.reportConditions.Size = new System.Drawing.Size(285, 69);
            this.reportConditions.TabIndex = 6;
            this.reportConditions.Text = "Tümünü Raporla";
            this.reportConditions.UseVisualStyleBackColor = false;
            this.reportConditions.Click += new System.EventHandler(this.reportConditions_Click);
            // 
            // chkAcd
            // 
            this.chkAcd.AutoSize = true;
            this.chkAcd.Location = new System.Drawing.Point(92, 481);
            this.chkAcd.Name = "chkAcd";
            this.chkAcd.Size = new System.Drawing.Size(86, 24);
            this.chkAcd.TabIndex = 41;
            this.chkAcd.Text = "chkAcd";
            this.chkAcd.UseVisualStyleBackColor = true;
            this.chkAcd.Visible = false;
            this.chkAcd.CheckedChanged += new System.EventHandler(this.chkEmp_CheckedChanged);
            // 
            // lisrConditions
            // 
            this.lisrConditions.BackColor = System.Drawing.Color.Orange;
            this.lisrConditions.FlatAppearance.BorderSize = 0;
            this.lisrConditions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lisrConditions.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lisrConditions.ForeColor = System.Drawing.Color.White;
            this.lisrConditions.Location = new System.Drawing.Point(55, 691);
            this.lisrConditions.Margin = new System.Windows.Forms.Padding(4);
            this.lisrConditions.Name = "lisrConditions";
            this.lisrConditions.Size = new System.Drawing.Size(285, 60);
            this.lisrConditions.TabIndex = 5;
            this.lisrConditions.Text = "Listele";
            this.lisrConditions.UseVisualStyleBackColor = false;
            this.lisrConditions.Click += new System.EventHandler(this.lisrConditions_Click);
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.Location = new System.Drawing.Point(91, 385);
            this.chkUser.Name = "chkUser";
            this.chkUser.Size = new System.Drawing.Size(87, 24);
            this.chkUser.TabIndex = 41;
            this.chkUser.Text = "chkUser";
            this.chkUser.UseVisualStyleBackColor = true;
            this.chkUser.Visible = false;
            this.chkUser.CheckedChanged += new System.EventHandler(this.chkUser_CheckedChanged);
            // 
            // chkCom
            // 
            this.chkCom.AutoSize = true;
            this.chkCom.Location = new System.Drawing.Point(88, 197);
            this.chkCom.Name = "chkCom";
            this.chkCom.Size = new System.Drawing.Size(90, 24);
            this.chkCom.TabIndex = 41;
            this.chkCom.Text = "chkCom";
            this.chkCom.UseVisualStyleBackColor = true;
            this.chkCom.Visible = false;
            this.chkCom.CheckedChanged += new System.EventHandler(this.chkCom_CheckedChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 423);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10);
            this.label3.Size = new System.Drawing.Size(282, 47);
            this.label3.TabIndex = 40;
            this.label3.Text = "Akademisyenler";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(55, 329);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10);
            this.label2.Size = new System.Drawing.Size(282, 47);
            this.label2.TabIndex = 40;
            this.label2.Text = "TEKNOKENT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelPArticipants
            // 
            this.labelPArticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelPArticipants.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPArticipants.ForeColor = System.Drawing.Color.White;
            this.labelPArticipants.Location = new System.Drawing.Point(55, 141);
            this.labelPArticipants.Name = "labelPArticipants";
            this.labelPArticipants.Padding = new System.Windows.Forms.Padding(10);
            this.labelPArticipants.Size = new System.Drawing.Size(282, 47);
            this.labelPArticipants.TabIndex = 40;
            this.labelPArticipants.Text = "Şirketler";
            this.labelPArticipants.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPArticipants.Click += new System.EventHandler(this.labelPArticipants_Click);
            // 
            // listAcedemics
            // 
            this.listAcedemics.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listAcedemics.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listAcedemics.Enabled = false;
            this.listAcedemics.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listAcedemics.FormattingEnabled = true;
            this.listAcedemics.Location = new System.Drawing.Point(55, 473);
            this.listAcedemics.Name = "listAcedemics";
            this.listAcedemics.Size = new System.Drawing.Size(282, 32);
            this.listAcedemics.TabIndex = 0;
            // 
            // listUsers
            // 
            this.listUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listUsers.Enabled = false;
            this.listUsers.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(55, 379);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(282, 32);
            this.listUsers.TabIndex = 0;
            // 
            // listCompany
            // 
            this.listCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listCompany.Enabled = false;
            this.listCompany.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listCompany.FormattingEnabled = true;
            this.listCompany.Location = new System.Drawing.Point(55, 191);
            this.listCompany.Name = "listCompany";
            this.listCompany.Size = new System.Drawing.Size(282, 32);
            this.listCompany.TabIndex = 0;
            // 
            // searchEvent
            // 
            this.searchEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.searchEvent.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.searchEvent.Location = new System.Drawing.Point(305, 40);
            this.searchEvent.Name = "searchEvent";
            this.searchEvent.Size = new System.Drawing.Size(827, 37);
            this.searchEvent.TabIndex = 9;
            this.searchEvent.TextChanged += new System.EventHandler(this.searchEvent_TextChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10);
            this.label5.Size = new System.Drawing.Size(287, 52);
            this.label5.TabIndex = 27;
            this.label5.Text = "Faaliyetler     |     Arama";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEmployee
            // 
            this.labelEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelEmployee.Font = new System.Drawing.Font("Century Gothic", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEmployee.ForeColor = System.Drawing.Color.White;
            this.labelEmployee.Location = new System.Drawing.Point(55, 235);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Padding = new System.Windows.Forms.Padding(10);
            this.labelEmployee.Size = new System.Drawing.Size(282, 47);
            this.labelEmployee.TabIndex = 40;
            this.labelEmployee.Text = "Personeller";
            this.labelEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEmployee.Click += new System.EventHandler(this.labelEmployee_Click);
            // 
            // listEmployee
            // 
            this.listEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listEmployee.Enabled = false;
            this.listEmployee.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listEmployee.FormattingEnabled = true;
            this.listEmployee.Location = new System.Drawing.Point(58, 287);
            this.listEmployee.Name = "listEmployee";
            this.listEmployee.Size = new System.Drawing.Size(282, 32);
            this.listEmployee.TabIndex = 55;
            // 
            // chkEmployee
            // 
            this.chkEmployee.AutoSize = true;
            this.chkEmployee.Location = new System.Drawing.Point(88, 293);
            this.chkEmployee.Name = "chkEmployee";
            this.chkEmployee.Size = new System.Drawing.Size(127, 24);
            this.chkEmployee.TabIndex = 41;
            this.chkEmployee.Text = "chkEmployee";
            this.chkEmployee.UseVisualStyleBackColor = true;
            this.chkEmployee.Visible = false;
            this.chkEmployee.CheckedChanged += new System.EventHandler(this.chkEmp1_CheckedChanged);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 843);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.searchEvent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.renewMeetings);
            this.Controls.Add(this.dgvMeetings);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faaliyet Raporları";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button renewMeetings;
        private System.Windows.Forms.DataGridView dgvMeetings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox listAcedemics;
        private System.Windows.Forms.ComboBox listUsers;
        private System.Windows.Forms.ComboBox listCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPArticipants;
        private System.Windows.Forms.CheckBox chkAcd;
        private System.Windows.Forms.CheckBox chkUser;
        private System.Windows.Forms.CheckBox chkCom;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.Button lisrConditions;
        private System.Windows.Forms.CheckBox customDateRange;
        private System.Windows.Forms.Button reportConditions;
        private System.Windows.Forms.CheckBox isImportant;
        private System.Windows.Forms.ComboBox MeetingType;
        private System.Windows.Forms.TextBox searchEvent;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private ComboBox listEmployee;
        private Label labelEmployee;
        private CheckBox chkEmployee;
    }
}
