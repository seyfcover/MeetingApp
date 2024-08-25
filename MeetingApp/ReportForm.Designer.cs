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
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.renewMeetings = new System.Windows.Forms.Button();
            this.dgvMeetings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customDateRange = new System.Windows.Forms.CheckBox();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.fastReport3Month = new System.Windows.Forms.Button();
            this.fastReportMonth = new System.Windows.Forms.Button();
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
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(558, 560);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(204, 58);
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
            this.renewMeetings.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.renewMeetings.ForeColor = System.Drawing.Color.White;
            this.renewMeetings.Location = new System.Drawing.Point(28, 559);
            this.renewMeetings.Margin = new System.Windows.Forms.Padding(4);
            this.renewMeetings.Name = "renewMeetings";
            this.renewMeetings.Size = new System.Drawing.Size(196, 58);
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
            this.dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMeetings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMeetings.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeetings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeetings.Location = new System.Drawing.Point(11, 35);
            this.dgvMeetings.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMeetings.MultiSelect = false;
            this.dgvMeetings.Name = "dgvMeetings";
            this.dgvMeetings.RowHeadersVisible = false;
            this.dgvMeetings.RowHeadersWidth = 51;
            this.dgvMeetings.RowTemplate.Height = 24;
            this.dgvMeetings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMeetings.Size = new System.Drawing.Size(751, 516);
            this.dgvMeetings.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Toplantılar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.customDateRange);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.fastReport3Month);
            this.panel1.Controls.Add(this.fastReportMonth);
            this.panel1.Controls.Add(this.dateTimeStart);
            this.panel1.Controls.Add(this.reportConditions);
            this.panel1.Controls.Add(this.chkAcd);
            this.panel1.Controls.Add(this.lisrConditions);
            this.panel1.Controls.Add(this.chkUser);
            this.panel1.Controls.Add(this.chkCom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelPArticipants);
            this.panel1.Controls.Add(this.listAcedemics);
            this.panel1.Controls.Add(this.listUsers);
            this.panel1.Controls.Add(this.listCompany);
            this.panel1.Location = new System.Drawing.Point(774, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 587);
            this.panel1.TabIndex = 8;
            // 
            // customDateRange
            // 
            this.customDateRange.AutoSize = true;
            this.customDateRange.Location = new System.Drawing.Point(16, 271);
            this.customDateRange.Name = "customDateRange";
            this.customDateRange.Size = new System.Drawing.Size(112, 24);
            this.customDateRange.TabIndex = 44;
            this.customDateRange.Text = "Tarihe Göre";
            this.customDateRange.UseVisualStyleBackColor = true;
            this.customDateRange.CheckedChanged += new System.EventHandler(this.customDateRange_CheckedChanged);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Enabled = false;
            this.dateTimeEnd.Location = new System.Drawing.Point(16, 333);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 26);
            this.dateTimeEnd.TabIndex = 43;
            // 
            // fastReport3Month
            // 
            this.fastReport3Month.BackColor = System.Drawing.Color.Teal;
            this.fastReport3Month.FlatAppearance.BorderSize = 0;
            this.fastReport3Month.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastReport3Month.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastReport3Month.ForeColor = System.Drawing.Color.White;
            this.fastReport3Month.Location = new System.Drawing.Point(0, 422);
            this.fastReport3Month.Margin = new System.Windows.Forms.Padding(4);
            this.fastReport3Month.Name = "fastReport3Month";
            this.fastReport3Month.Size = new System.Drawing.Size(229, 37);
            this.fastReport3Month.TabIndex = 6;
            this.fastReport3Month.Text = "Hızlı Rapor (3 Aylık)";
            this.fastReport3Month.UseVisualStyleBackColor = false;
            // 
            // fastReportMonth
            // 
            this.fastReportMonth.BackColor = System.Drawing.Color.Teal;
            this.fastReportMonth.FlatAppearance.BorderSize = 0;
            this.fastReportMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastReportMonth.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastReportMonth.ForeColor = System.Drawing.Color.White;
            this.fastReportMonth.Location = new System.Drawing.Point(0, 377);
            this.fastReportMonth.Margin = new System.Windows.Forms.Padding(4);
            this.fastReportMonth.Name = "fastReportMonth";
            this.fastReportMonth.Size = new System.Drawing.Size(229, 37);
            this.fastReportMonth.TabIndex = 6;
            this.fastReportMonth.Text = "Hızlı Rapor (Aylık)";
            this.fastReportMonth.UseVisualStyleBackColor = false;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Enabled = false;
            this.dateTimeStart.Location = new System.Drawing.Point(16, 301);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 26);
            this.dateTimeStart.TabIndex = 42;
            // 
            // reportConditions
            // 
            this.reportConditions.BackColor = System.Drawing.Color.SteelBlue;
            this.reportConditions.FlatAppearance.BorderSize = 0;
            this.reportConditions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportConditions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.reportConditions.ForeColor = System.Drawing.Color.White;
            this.reportConditions.Location = new System.Drawing.Point(0, 533);
            this.reportConditions.Margin = new System.Windows.Forms.Padding(4);
            this.reportConditions.Name = "reportConditions";
            this.reportConditions.Size = new System.Drawing.Size(229, 41);
            this.reportConditions.TabIndex = 6;
            this.reportConditions.Text = "Raporla";
            this.reportConditions.UseVisualStyleBackColor = false;
            // 
            // chkAcd
            // 
            this.chkAcd.AutoSize = true;
            this.chkAcd.Location = new System.Drawing.Point(58, 223);
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
            this.lisrConditions.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lisrConditions.ForeColor = System.Drawing.Color.White;
            this.lisrConditions.Location = new System.Drawing.Point(0, 488);
            this.lisrConditions.Margin = new System.Windows.Forms.Padding(4);
            this.lisrConditions.Name = "lisrConditions";
            this.lisrConditions.Size = new System.Drawing.Size(229, 37);
            this.lisrConditions.TabIndex = 5;
            this.lisrConditions.Text = "Listele";
            this.lisrConditions.UseVisualStyleBackColor = false;
            this.lisrConditions.Click += new System.EventHandler(this.lisrConditions_Click);
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.Location = new System.Drawing.Point(55, 129);
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
            this.chkCom.Location = new System.Drawing.Point(55, 44);
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
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 181);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10);
            this.label3.Size = new System.Drawing.Size(165, 39);
            this.label3.TabIndex = 40;
            this.label3.Text = "Akademisyenler";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 87);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10);
            this.label2.Size = new System.Drawing.Size(165, 39);
            this.label2.TabIndex = 40;
            this.label2.Text = "TEKNOKENT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelPArticipants
            // 
            this.labelPArticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.labelPArticipants.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPArticipants.ForeColor = System.Drawing.Color.White;
            this.labelPArticipants.Location = new System.Drawing.Point(32, 0);
            this.labelPArticipants.Name = "labelPArticipants";
            this.labelPArticipants.Padding = new System.Windows.Forms.Padding(10);
            this.labelPArticipants.Size = new System.Drawing.Size(165, 39);
            this.labelPArticipants.TabIndex = 40;
            this.labelPArticipants.Text = "Şirketler";
            this.labelPArticipants.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPArticipants.Click += new System.EventHandler(this.labelPArticipants_Click);
            // 
            // listAcedemics
            // 
            this.listAcedemics.Enabled = false;
            this.listAcedemics.FormattingEnabled = true;
            this.listAcedemics.Location = new System.Drawing.Point(32, 223);
            this.listAcedemics.Name = "listAcedemics";
            this.listAcedemics.Size = new System.Drawing.Size(165, 28);
            this.listAcedemics.TabIndex = 0;
            // 
            // listUsers
            // 
            this.listUsers.Enabled = false;
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(32, 129);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(165, 28);
            this.listUsers.TabIndex = 0;
            // 
            // listCompany
            // 
            this.listCompany.Enabled = false;
            this.listCompany.FormattingEnabled = true;
            this.listCompany.Location = new System.Drawing.Point(32, 42);
            this.listCompany.Name = "listCompany";
            this.listCompany.Size = new System.Drawing.Size(165, 28);
            this.listCompany.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(832, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Raporlama";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 631);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.renewMeetings);
            this.Controls.Add(this.dgvMeetings);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toplantı Raporları";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeetings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button renewMeetings;
        private System.Windows.Forms.DataGridView dgvMeetings;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button fastReport3Month;
        private System.Windows.Forms.Button fastReportMonth;
        private System.Windows.Forms.Label label4;
    }
}
