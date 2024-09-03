namespace MeetingApp
{
    partial class UpdateCompanyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCompanyForm));
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
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.canPoints = new System.Windows.Forms.TextBox();
            this.isCandidate = new System.Windows.Forms.CheckBox();
            this.delCandidate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(12, 62);
            this.txtCompanyName.MaxLength = 50;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(260, 23);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 107);
            this.txtAddress.MaxLength = 300;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(260, 60);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "";
            // 
            // txtFieldsOfActivity
            // 
            this.txtFieldsOfActivity.Location = new System.Drawing.Point(10, 400);
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
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(12, 482);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Güncelle";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(12, 39);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(69, 16);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.Text = "Şirket Adı";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 88);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 16);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Adres";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(12, 232);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 16);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Telefon";
            // 
            // lblFieldsOfActivity
            // 
            this.lblFieldsOfActivity.AutoSize = true;
            this.lblFieldsOfActivity.Location = new System.Drawing.Point(9, 381);
            this.lblFieldsOfActivity.Name = "lblFieldsOfActivity";
            this.lblFieldsOfActivity.Size = new System.Drawing.Size(112, 16);
            this.lblFieldsOfActivity.TabIndex = 8;
            this.lblFieldsOfActivity.Text = "Aktivite Alanları";
            // 
            // logoBox
            // 
            this.logoBox.Location = new System.Drawing.Point(12, 283);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(95, 95);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoBox.TabIndex = 9;
            this.logoBox.TabStop = false;
            // 
            // choosePic
            // 
            this.choosePic.BackColor = System.Drawing.Color.SteelBlue;
            this.choosePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choosePic.ForeColor = System.Drawing.Color.White;
            this.choosePic.Location = new System.Drawing.Point(146, 311);
            this.choosePic.Name = "choosePic";
            this.choosePic.Size = new System.Drawing.Size(88, 30);
            this.choosePic.TabIndex = 4;
            this.choosePic.Text = "Logo Seç";
            this.choosePic.UseVisualStyleBackColor = false;
            this.choosePic.Click += new System.EventHandler(this.choosePic_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(12, 251);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(131, 23);
            this.txtPhone.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 204);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 23);
            this.txtEmail.TabIndex = 2;
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(12, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(260, 24);
            this.cmbCompany.TabIndex = 10;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Puan:";
            // 
            // canPoints
            // 
            this.canPoints.Enabled = false;
            this.canPoints.Location = new System.Drawing.Point(231, 277);
            this.canPoints.Name = "canPoints";
            this.canPoints.Size = new System.Drawing.Size(39, 23);
            this.canPoints.TabIndex = 14;
            this.canPoints.TextChanged += new System.EventHandler(this.canPoints_TextChanged);
            this.canPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.canPoints_KeyPress);
            // 
            // isCandidate
            // 
            this.isCandidate.AutoSize = true;
            this.isCandidate.Location = new System.Drawing.Point(168, 42);
            this.isCandidate.Name = "isCandidate";
            this.isCandidate.Size = new System.Drawing.Size(102, 20);
            this.isCandidate.TabIndex = 13;
            this.isCandidate.Text = "Aday Şirket";
            this.isCandidate.UseVisualStyleBackColor = true;
            this.isCandidate.CheckedChanged += new System.EventHandler(this.isCandidate_CheckedChanged);
            // 
            // delCandidate
            // 
            this.delCandidate.BackColor = System.Drawing.Color.DarkOrange;
            this.delCandidate.Enabled = false;
            this.delCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delCandidate.ForeColor = System.Drawing.Color.White;
            this.delCandidate.Location = new System.Drawing.Point(169, 482);
            this.delCandidate.Name = "delCandidate";
            this.delCandidate.Size = new System.Drawing.Size(101, 30);
            this.delCandidate.TabIndex = 16;
            this.delCandidate.Text = "Sil";
            this.delCandidate.UseVisualStyleBackColor = false;
            this.delCandidate.Click += new System.EventHandler(this.delCandidate_Click);
            // 
            // UpdateCompanyForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(285, 522);
            this.Controls.Add(this.delCandidate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canPoints);
            this.Controls.Add(this.isCandidate);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.choosePic);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.lblFieldsOfActivity);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFieldsOfActivity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtCompanyName);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateCompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şirket Güncelle";
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
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox canPoints;
        private System.Windows.Forms.CheckBox isCandidate;
        private System.Windows.Forms.Button delCandidate;
    }
}
