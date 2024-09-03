namespace MeetingApp
{
    partial class CompanyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.txtFieldsOfActivity = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblFieldsOfActivity = new System.Windows.Forms.Label();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.choosePic = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.isCandidate = new System.Windows.Forms.CheckBox();
            this.canPoints = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ephone = new System.Windows.Forms.MaskedTextBox();
            this.EtxtTitle = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.EbtnSave = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.EtxtPosition = new System.Windows.Forms.TextBox();
            this.EtxtMail = new System.Windows.Forms.TextBox();
            this.EtxtLastName = new System.Windows.Forms.TextBox();
            this.EtxtFirstName = new System.Windows.Forms.TextBox();
            this.listofEmployee = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EbtnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Location = new System.Drawing.Point(20, 33);
            this.txtCompanyName.MaxLength = 50;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(260, 24);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtAddress.Location = new System.Drawing.Point(20, 80);
            this.txtAddress.MaxLength = 300;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(260, 60);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "";
            // 
            // txtFieldsOfActivity
            // 
            this.txtFieldsOfActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtFieldsOfActivity.Location = new System.Drawing.Point(20, 360);
            this.txtFieldsOfActivity.MaxLength = 300;
            this.txtFieldsOfActivity.Name = "txtFieldsOfActivity";
            this.txtFieldsOfActivity.Size = new System.Drawing.Size(260, 60);
            this.txtFieldsOfActivity.TabIndex = 5;
            this.txtFieldsOfActivity.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Şirket Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(16, 9);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(70, 19);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "Şirket Adı";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(20, 60);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(46, 19);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Adres";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(20, 190);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(57, 19);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Telefon";
            // 
            // lblFieldsOfActivity
            // 
            this.lblFieldsOfActivity.AutoSize = true;
            this.lblFieldsOfActivity.Location = new System.Drawing.Point(20, 340);
            this.lblFieldsOfActivity.Name = "lblFieldsOfActivity";
            this.lblFieldsOfActivity.Size = new System.Drawing.Size(113, 19);
            this.lblFieldsOfActivity.TabIndex = 8;
            this.lblFieldsOfActivity.Text = "Aktivite Alanları";
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.logoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoBox.Location = new System.Drawing.Point(20, 237);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(100, 100);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 9;
            this.logoBox.TabStop = false;
            // 
            // choosePic
            // 
            this.choosePic.BackColor = System.Drawing.Color.Orange;
            this.choosePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choosePic.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.choosePic.ForeColor = System.Drawing.Color.White;
            this.choosePic.Location = new System.Drawing.Point(130, 260);
            this.choosePic.Name = "choosePic";
            this.choosePic.Size = new System.Drawing.Size(150, 30);
            this.choosePic.TabIndex = 4;
            this.choosePic.Text = "Logo Seç";
            this.choosePic.UseVisualStyleBackColor = false;
            this.choosePic.Click += new System.EventHandler(this.choosePic_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtPhone.Location = new System.Drawing.Point(20, 210);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(120, 24);
            this.txtPhone.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(20, 160);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 24);
            this.txtEmail.TabIndex = 2;
            // 
            // isCandidate
            // 
            this.isCandidate.AutoSize = true;
            this.isCandidate.Location = new System.Drawing.Point(150, 210);
            this.isCandidate.Name = "isCandidate";
            this.isCandidate.Size = new System.Drawing.Size(104, 23);
            this.isCandidate.TabIndex = 10;
            this.isCandidate.Text = "Aday Şirket";
            this.isCandidate.UseVisualStyleBackColor = true;
            this.isCandidate.CheckedChanged += new System.EventHandler(this.isCandidate_CheckedChanged);
            // 
            // canPoints
            // 
            this.canPoints.Enabled = false;
            this.canPoints.Location = new System.Drawing.Point(240, 230);
            this.canPoints.MaxLength = 3;
            this.canPoints.Name = "canPoints";
            this.canPoints.Size = new System.Drawing.Size(40, 24);
            this.canPoints.TabIndex = 11;
            this.canPoints.TextChanged += new System.EventHandler(this.canPoints_TextChanged);
            this.canPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.canPoints_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Puan:";
            // 
            // Ephone
            // 
            this.Ephone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.Ephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ephone.Location = new System.Drawing.Point(308, 252);
            this.Ephone.Mask = "(999) 000-0000";
            this.Ephone.Name = "Ephone";
            this.Ephone.Size = new System.Drawing.Size(119, 24);
            this.Ephone.TabIndex = 18;
            // 
            // EtxtTitle
            // 
            this.EtxtTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.EtxtTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.EtxtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.EtxtTitle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.EtxtTitle.FormattingEnabled = true;
            this.EtxtTitle.Items.AddRange(new object[] {
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
            this.EtxtTitle.Location = new System.Drawing.Point(308, 312);
            this.EtxtTitle.MaxLength = 50;
            this.EtxtTitle.Name = "EtxtTitle";
            this.EtxtTitle.Size = new System.Drawing.Size(227, 25);
            this.EtxtTitle.TabIndex = 19;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblCompany.Location = new System.Drawing.Point(304, 10);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(44, 19);
            this.lblCompany.TabIndex = 29;
            this.lblCompany.Text = "Şirket";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblPosition.Location = new System.Drawing.Point(305, 351);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(51, 19);
            this.lblPosition.TabIndex = 28;
            this.lblPosition.Text = "Görev";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblTitle.Location = new System.Drawing.Point(304, 290);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(54, 19);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "Ünvan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.Location = new System.Drawing.Point(305, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefon";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblEmail.Location = new System.Drawing.Point(305, 171);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 19);
            this.lblEmail.TabIndex = 25;
            this.lblEmail.Text = "Email";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblLastName.Location = new System.Drawing.Point(305, 122);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(53, 19);
            this.lblLastName.TabIndex = 24;
            this.lblLastName.Text = "Soyad";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblFirstName.Location = new System.Drawing.Point(305, 72);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 19);
            this.lblFirstName.TabIndex = 23;
            this.lblFirstName.Text = "Ad";
            // 
            // EbtnSave
            // 
            this.EbtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.EbtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbtnSave.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.EbtnSave.ForeColor = System.Drawing.Color.White;
            this.EbtnSave.Location = new System.Drawing.Point(303, 430);
            this.EbtnSave.Name = "EbtnSave";
            this.EbtnSave.Size = new System.Drawing.Size(232, 30);
            this.EbtnSave.TabIndex = 22;
            this.EbtnSave.Text = "Personel Kaydet";
            this.EbtnSave.UseVisualStyleBackColor = false;
            this.EbtnSave.Click += new System.EventHandler(this.EbtnSave_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.cmbCompany.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(306, 32);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(227, 25);
            this.cmbCompany.TabIndex = 6;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // EtxtPosition
            // 
            this.EtxtPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.EtxtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EtxtPosition.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.EtxtPosition.Location = new System.Drawing.Point(308, 372);
            this.EtxtPosition.MaxLength = 50;
            this.EtxtPosition.Name = "EtxtPosition";
            this.EtxtPosition.Size = new System.Drawing.Size(227, 24);
            this.EtxtPosition.TabIndex = 20;
            // 
            // EtxtMail
            // 
            this.EtxtMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.EtxtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EtxtMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.EtxtMail.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.EtxtMail.Location = new System.Drawing.Point(306, 192);
            this.EtxtMail.MaxLength = 50;
            this.EtxtMail.Name = "EtxtMail";
            this.EtxtMail.Size = new System.Drawing.Size(227, 24);
            this.EtxtMail.TabIndex = 17;
            // 
            // EtxtLastName
            // 
            this.EtxtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.EtxtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EtxtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EtxtLastName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.EtxtLastName.Location = new System.Drawing.Point(306, 143);
            this.EtxtLastName.MaxLength = 50;
            this.EtxtLastName.Name = "EtxtLastName";
            this.EtxtLastName.Size = new System.Drawing.Size(227, 24);
            this.EtxtLastName.TabIndex = 16;
            // 
            // EtxtFirstName
            // 
            this.EtxtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.EtxtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EtxtFirstName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.EtxtFirstName.Location = new System.Drawing.Point(306, 91);
            this.EtxtFirstName.MaxLength = 50;
            this.EtxtFirstName.Name = "EtxtFirstName";
            this.EtxtFirstName.Size = new System.Drawing.Size(227, 24);
            this.EtxtFirstName.TabIndex = 15;
            this.EtxtFirstName.TextChanged += new System.EventHandler(this.EtxtFirstName_TextChanged);
            // 
            // listofEmployee
            // 
            this.listofEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.listofEmployee.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.listofEmployee.FormattingEnabled = true;
            this.listofEmployee.ItemHeight = 17;
            this.listofEmployee.Location = new System.Drawing.Point(565, 35);
            this.listofEmployee.Name = "listofEmployee";
            this.listofEmployee.Size = new System.Drawing.Size(168, 361);
            this.listofEmployee.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label4.Location = new System.Drawing.Point(561, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Şirket Çalışanları";
            // 
            // EbtnUpdate
            // 
            this.EbtnUpdate.BackColor = System.Drawing.Color.Orange;
            this.EbtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbtnUpdate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.EbtnUpdate.ForeColor = System.Drawing.Color.White;
            this.EbtnUpdate.Location = new System.Drawing.Point(565, 430);
            this.EbtnUpdate.Name = "EbtnUpdate";
            this.EbtnUpdate.Size = new System.Drawing.Size(168, 30);
            this.EbtnUpdate.TabIndex = 22;
            this.EbtnUpdate.Text = "Düzenle";
            this.EbtnUpdate.UseVisualStyleBackColor = false;
            this.EbtnUpdate.Click += new System.EventHandler(this.EbtnUpdate_Click);
            // 
            // CompanyForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(755, 476);
            this.Controls.Add(this.listofEmployee);
            this.Controls.Add(this.Ephone);
            this.Controls.Add(this.EtxtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.canPoints);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.isCandidate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.choosePic);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblFieldsOfActivity);
            this.Controls.Add(this.EbtnUpdate);
            this.Controls.Add(this.EbtnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.EtxtPosition);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.EtxtMail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.EtxtLastName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.EtxtFirstName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFieldsOfActivity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtCompanyName);
            this.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şirket ve Personel Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.RichTextBox txtFieldsOfActivity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblFieldsOfActivity;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Button choosePic;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox isCandidate;
        private System.Windows.Forms.TextBox canPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox Ephone;
        private System.Windows.Forms.ComboBox EtxtTitle;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button EbtnSave;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.TextBox EtxtPosition;
        private System.Windows.Forms.TextBox EtxtMail;
        private System.Windows.Forms.TextBox EtxtLastName;
        private System.Windows.Forms.TextBox EtxtFirstName;
        private System.Windows.Forms.ListBox listofEmployee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EbtnUpdate;
    }
}
