namespace MeetingApp
{
    partial class AcademicForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.ComboBox txtTitle;

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcademicForm));
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtTitle = new System.Windows.Forms.ComboBox();
            this.lblFieldsOfActivity = new System.Windows.Forms.Label();
            this.txtFieldsOfActivity = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmaskedtcid = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(120, 30);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 24);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // txtLastName
            // 
            this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLastName.Location = new System.Drawing.Point(120, 70);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 24);
            this.txtLastName.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(120, 110);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 24);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(120, 270);
            this.txtPosition.MaxLength = 50;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(200, 24);
            this.txtPosition.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 414);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 33);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(32, 19);
            this.lblFirstName.TabIndex = 7;
            this.lblFirstName.Text = "Ad:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 73);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(57, 19);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Soyad:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 113);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 19);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 193);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(61, 19);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Telefon:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 233);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(58, 19);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Ünvan:";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(12, 273);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(55, 19);
            this.lblPosition.TabIndex = 12;
            this.lblPosition.Text = "Görev:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(120, 190);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(101, 24);
            this.txtPhone.TabIndex = 4;
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
            this.txtTitle.Location = new System.Drawing.Point(120, 230);
            this.txtTitle.MaxLength = 100;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 25);
            this.txtTitle.TabIndex = 5;
            // 
            // lblFieldsOfActivity
            // 
            this.lblFieldsOfActivity.AutoSize = true;
            this.lblFieldsOfActivity.Location = new System.Drawing.Point(12, 308);
            this.lblFieldsOfActivity.Name = "lblFieldsOfActivity";
            this.lblFieldsOfActivity.Size = new System.Drawing.Size(130, 19);
            this.lblFieldsOfActivity.TabIndex = 14;
            this.lblFieldsOfActivity.Text = "Anahtar Kelimeler";
            // 
            // txtFieldsOfActivity
            // 
            this.txtFieldsOfActivity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.txtFieldsOfActivity.Location = new System.Drawing.Point(16, 330);
            this.txtFieldsOfActivity.MaxLength = 300;
            this.txtFieldsOfActivity.Name = "txtFieldsOfActivity";
            this.txtFieldsOfActivity.Size = new System.Drawing.Size(304, 78);
            this.txtFieldsOfActivity.TabIndex = 7;
            this.txtFieldsOfActivity.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "TC No:";
            // 
            // txtmaskedtcid
            // 
            this.txtmaskedtcid.Location = new System.Drawing.Point(120, 149);
            this.txtmaskedtcid.Mask = "00000000000";
            this.txtmaskedtcid.Name = "txtmaskedtcid";
            this.txtmaskedtcid.Size = new System.Drawing.Size(118, 24);
            this.txtmaskedtcid.TabIndex = 3;
            // 
            // AcademicForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(340, 456);
            this.Controls.Add(this.lblFieldsOfActivity);
            this.Controls.Add(this.txtFieldsOfActivity);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtmaskedtcid);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AcademicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Akademisyen Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblFieldsOfActivity;
        private System.Windows.Forms.RichTextBox txtFieldsOfActivity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtmaskedtcid;
    }
}
