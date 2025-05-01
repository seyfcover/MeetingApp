using System.Windows.Forms;

namespace MeetingApp
{
    partial class InventoryManagementForm
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryManagementForm));
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.dateTimePickerPurchase = new System.Windows.Forms.DateTimePicker();
            this.lblUser = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.isNull = new System.Windows.Forms.CheckBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerWarranty = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerLastMaintenance = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectFile = new System.Windows.Forms.Button();
            this.txtItemType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.countItem = new System.Windows.Forms.NumericUpDown();
            this.checkBoxReminder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(26, 24);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(130, 23);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Demirbaş İsmi :";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtItemName.Location = new System.Drawing.Point(183, 18);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(250, 29);
            this.txtItemName.TabIndex = 1;
            // 
            // lblItemType
            // 
            this.lblItemType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblItemType.ForeColor = System.Drawing.Color.Black;
            this.lblItemType.Location = new System.Drawing.Point(26, 55);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(100, 23);
            this.lblItemType.TabIndex = 2;
            this.lblItemType.Text = "Türü : ";
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPurchaseDate.ForeColor = System.Drawing.Color.Black;
            this.lblPurchaseDate.Location = new System.Drawing.Point(26, 179);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(151, 25);
            this.lblPurchaseDate.TabIndex = 4;
            this.lblPurchaseDate.Text = "Satın Alınma Tarihi :";
            // 
            // dateTimePickerPurchase
            // 
            this.dateTimePickerPurchase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerPurchase.Location = new System.Drawing.Point(183, 173);
            this.dateTimePickerPurchase.MinDate = new System.DateTime(2000, 1, 24, 0, 0, 0, 0);
            this.dateTimePickerPurchase.Name = "dateTimePickerPurchase";
            this.dateTimePickerPurchase.Size = new System.Drawing.Size(250, 29);
            this.dateTimePickerPurchase.TabIndex = 6;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(26, 399);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(130, 23);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Zimmetli Kişi :";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUsers.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxUsers.Location = new System.Drawing.Point(183, 393);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(180, 29);
            this.comboBoxUsers.TabIndex = 13;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.Green;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(30, 759);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(404, 35);
            this.btnAddItem.TabIndex = 20;
            this.btnAddItem.Text = "Demirbaş Ekle";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // isNull
            // 
            this.isNull.AutoSize = true;
            this.isNull.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isNull.Location = new System.Drawing.Point(378, 395);
            this.isNull.Name = "isNull";
            this.isNull.Size = new System.Drawing.Size(55, 25);
            this.isNull.TabIndex = 13;
            this.isNull.Text = "Boş";
            this.isNull.UseVisualStyleBackColor = true;
            this.isNull.CheckedChanged += new System.EventHandler(this.isNull_CheckedChanged);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerialNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSerialNumber.Location = new System.Drawing.Point(183, 80);
            this.txtSerialNumber.MaxLength = 50;
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(250, 29);
            this.txtSerialNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seri Numarası :";
            // 
            // txtBrand
            // 
            this.txtBrand.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtBrand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBrand.Location = new System.Drawing.Point(183, 111);
            this.txtBrand.MaxLength = 50;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(250, 29);
            this.txtBrand.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Marka :";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtModel.Location = new System.Drawing.Point(183, 142);
            this.txtModel.MaxLength = 50;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(250, 29);
            this.txtModel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(26, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Model :";
            // 
            // dateTimePickerWarranty
            // 
            this.dateTimePickerWarranty.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerWarranty.Location = new System.Drawing.Point(183, 208);
            this.dateTimePickerWarranty.MinDate = new System.DateTime(2000, 1, 24, 0, 0, 0, 0);
            this.dateTimePickerWarranty.Name = "dateTimePickerWarranty";
            this.dateTimePickerWarranty.Size = new System.Drawing.Size(250, 29);
            this.dateTimePickerWarranty.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(26, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Son Garanti Süresi : ";
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCost.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost.Location = new System.Drawing.Point(183, 269);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(250, 29);
            this.txtCost.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(26, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Maliyet :";
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTaxRate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTaxRate.Location = new System.Drawing.Point(183, 300);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(250, 29);
            this.txtTaxRate.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(26, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "%KDV  :";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLocation.Location = new System.Drawing.Point(183, 331);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(250, 29);
            this.txtLocation.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(26, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Konum : ";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDepartment.Location = new System.Drawing.Point(183, 362);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(250, 29);
            this.txtDepartment.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(26, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "İlgili Departman :";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(26, 432);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 6;
            this.label10.Text = "Durum : ";
            // 
            // dateTimePickerLastMaintenance
            // 
            this.dateTimePickerLastMaintenance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerLastMaintenance.Location = new System.Drawing.Point(183, 456);
            this.dateTimePickerLastMaintenance.MinDate = new System.DateTime(2000, 1, 24, 0, 0, 0, 0);
            this.dateTimePickerLastMaintenance.Name = "dateTimePickerLastMaintenance";
            this.dateTimePickerLastMaintenance.Size = new System.Drawing.Size(250, 29);
            this.dateTimePickerLastMaintenance.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(26, 461);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "Son Bakım Tarihi :";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(26, 635);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 24);
            this.label12.TabIndex = 2;
            this.label12.Text = "Açıklama :";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNotes.Location = new System.Drawing.Point(183, 630);
            this.txtNotes.MaxLength = 300;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 114);
            this.txtNotes.TabIndex = 17;
            this.txtNotes.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtStatus.FormattingEnabled = true;
            this.txtStatus.Items.AddRange(new object[] {
            "Mevcut",
            "Kullanımda",
            "Bakımda",
            "Arızalı",
            "Kayıp"});
            this.txtStatus.Location = new System.Drawing.Point(183, 424);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(180, 29);
            this.txtStatus.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fotoğraf :";
            // 
            // selectFile
            // 
            this.selectFile.BackColor = System.Drawing.SystemColors.HotTrack;
            this.selectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFile.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.selectFile.ForeColor = System.Drawing.Color.White;
            this.selectFile.Location = new System.Drawing.Point(402, 494);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(31, 130);
            this.selectFile.TabIndex = 16;
            this.selectFile.Text = "Ekle";
            this.selectFile.UseVisualStyleBackColor = false;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // txtItemType
            // 
            this.txtItemType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtItemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtItemType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtItemType.FormattingEnabled = true;
            this.txtItemType.Items.AddRange(new object[] {
            "Masa",
            "Sandalye",
            "Dolap",
            "Raflar",
            "Koltuklar",
            "Sehpa",
            "Konferans masası",
            "Bilgisayarlar",
            "Monitörler",
            "Klavye",
            "Fare",
            "Yazıcılar",
            "Fotokopi makineleri",
            "Tarayıcılar",
            "Projektörler",
            "Sunucu ve ağ cihazları",
            "Telefonlar",
            "Faks makineleri",
            "IP telefonlar",
            "Kamera sistemleri",
            "Lambalar",
            "Elektrik kabloları ve prizler",
            "Uzatma kabloları",
            "UPS (Kesintisiz Güç Kaynağı)",
            "Klima ve havalandırma sistemleri",
            "Isıtıcılar",
            "Routers",
            "Switch",
            "Modemler",
            "Ağ kabloları",
            "IP kameralar",
            "Ağ depolama cihazları(NAS)",
            "Yazılım lisansları",
            "Veri yedekleme cihazları",
            "Elektronik veritabanları",
            "Dosya kutuları",
            "Dosya raftları",
            "Arşiv odası dolapları",
            "Çekmeceli dosya sistemleri",
            "Defterler",
            "Kalemler",
            "Post-it’ler",
            "Dosya klasörleri",
            "Zımba makineleri",
            "Evrak çantaları",
            "Makaslar",
            "Delgeçler",
            "Mikrodalga fırın",
            "Buzdolabı",
            "Kahve makinesi",
            "Su sebili",
            "Çaydanlık",
            "Kettle (su ısıtıcı)",
            "Fırın",
            "Süpürgeler",
            "Moplar",
            "Çöp kutuları",
            "Temizlik bezleri",
            "Temizlik ürünleri",
            "Yangın söndürücüler",
            "İlk yardım çantaları",
            "Güvenlik kameraları",
            "Alarm sistemleri",
            "Metal dedektörler",
            "Çalışan kimlik kartları ve aksesuarları",
            "Bahçe mobilyaları",
            "Depolama kutuları",
            "Paletler",
            "Raflar ve raf sistemleri"});
            this.txtItemType.Location = new System.Drawing.Point(183, 49);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(250, 29);
            this.txtItemType.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Location = new System.Drawing.Point(183, 494);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(318, 427);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 23);
            this.label13.TabIndex = 6;
            this.label13.Text = "Adet : ";
            this.label13.Visible = false;
            // 
            // countItem
            // 
            this.countItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.countItem.Location = new System.Drawing.Point(380, 424);
            this.countItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countItem.Name = "countItem";
            this.countItem.Size = new System.Drawing.Size(53, 29);
            this.countItem.TabIndex = 13;
            this.countItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countItem.Visible = false;
            // 
            // checkBoxReminder
            // 
            this.checkBoxReminder.AutoSize = true;
            this.checkBoxReminder.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.checkBoxReminder.Location = new System.Drawing.Point(183, 246);
            this.checkBoxReminder.Name = "checkBoxReminder";
            this.checkBoxReminder.Size = new System.Drawing.Size(110, 25);
            this.checkBoxReminder.TabIndex = 8;
            this.checkBoxReminder.Text = "Hatırlatma";
            this.checkBoxReminder.UseVisualStyleBackColor = true;
            // 
            // InventoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(455, 804);
            this.Controls.Add(this.checkBoxReminder);
            this.Controls.Add(this.countItem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtItemType);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.isNull);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtTaxRate);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerLastMaintenance);
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.dateTimePickerWarranty);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePickerPurchase);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.btnAddItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demirbaş Ekle";
            this.Load += new System.EventHandler(this.InventoryManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Declare controls
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchase;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.Label lblUser;
        private CheckBox isNull;
        private TextBox txtSerialNumber;
        private Label label2;
        private TextBox txtBrand;
        private Label label3;
        private TextBox txtModel;
        private Label label4;
        private DateTimePicker dateTimePickerWarranty;
        private Label label5;
        private TextBox txtCost;
        private Label label6;
        private TextBox txtTaxRate;
        private Label label7;
        private TextBox txtLocation;
        private Label label8;
        private TextBox txtDepartment;
        private Label label9;
        private Label label10;
        private DateTimePicker dateTimePickerLastMaintenance;
        private Label label11;
        private Label label12;
        private RichTextBox txtNotes;
        private ComboBox txtStatus;
        private Label label1;
        private Button selectFile;
        private PictureBox pictureBox1;
        private ComboBox txtItemType;
        private Label label13;
        private NumericUpDown countItem;
        private CheckBox checkBoxReminder;
    }
}
