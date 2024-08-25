namespace MeetingApp
{
    partial class UpdateEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.listofEmployee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(17, 84);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(297, 23);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtLastName
            // 
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(17, 130);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(297, 23);
            this.txtLastName.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(17, 177);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(297, 23);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(17, 316);
            this.txtPosition.MaxLength = 50;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(297, 23);
            this.txtPosition.TabIndex = 5;
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(17, 366);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(297, 24);
            this.cmbCompany.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(17, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(165, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Güncelle";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 65);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(26, 16);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "Ad";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(17, 111);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(48, 16);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Soyad";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(17, 156);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(17, 203);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 16);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "Telefon";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(17, 248);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(47, 16);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Ünvan";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(17, 297);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(46, 16);
            this.lblPosition.TabIndex = 13;
            this.lblPosition.Text = "Görev";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(17, 347);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(43, 16);
            this.lblCompany.TabIndex = 14;
            this.lblCompany.Text = "Şirket";
            // 
            // txtTitle
            // 
            this.txtTitle.FormattingEnabled = true;
            this.txtTitle.Items.AddRange(new object[] {
            "Rektör",
            "Rektör Yardımcısı",
            "Fakülte Dekanı",
            "Dekan Yardımcısı",
            "Bölüm Başkanı",
            "Bölüm Başkan Yardımcısı",
            "Anabilim Dalı Başkanı",
            "Anabilim Dalı Başkan Yardımcısı",
            "Prof. Dr.",
            "Doç. Dr.",
            "Yardımcı Doç. Dr.",
            "Dr. Öğr. Üyesi",
            "Öğr. Gör.",
            "Araştırma Görevlisi",
            "Araştırma Görevlisi (Öğretim Görevlisi)",
            "Öğrenci Asistanı",
            "Laborant",
            "İdari Personel",
            "Sekreter",
            "Bilgi İşlem Sorumlusu",
            "Kütüphane Görevlisi",
            "İç Denetçi",
            "Finans Sorumlusu",
            "İnsan Kaynakları Sorumlusu",
            "Hukuk Müşaviri"});
            this.txtTitle.Location = new System.Drawing.Point(17, 267);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(297, 24);
            this.txtTitle.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(17, 222);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(111, 23);
            this.txtPhone.TabIndex = 3;
            // 
            // listofEmployee
            // 
            this.listofEmployee.FormattingEnabled = true;
            this.listofEmployee.Location = new System.Drawing.Point(17, 38);
            this.listofEmployee.Name = "listofEmployee";
            this.listofEmployee.Size = new System.Drawing.Size(297, 24);
            this.listofEmployee.TabIndex = 15;
            this.listofEmployee.SelectedIndexChanged += new System.EventHandler(this.listofEmployee_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Çalışanı Seçin";
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.DarkOrange;
            this.btnDel.Enabled = false;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(207, 406);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(107, 28);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "Sil";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // UpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(345, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listofEmployee);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpdateEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Çalışan Güncelle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox txtTitle;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.ComboBox listofEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDel;
    }
}
