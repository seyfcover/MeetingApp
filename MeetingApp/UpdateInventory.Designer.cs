namespace MeetingApp
{
    partial class UpdateInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateInventory));
            this.txtItemType = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.isNull = new System.Windows.Forms.CheckBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblItemType = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtTaxRate = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerLastMaintenance = new System.Windows.Forms.DateTimePicker();
            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.dateTimePickerWarrantyEnd = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerPurchase = new System.Windows.Forms.DateTimePicker();
            this.lblUser = new System.Windows.Forms.Label();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.selectFile = new System.Windows.Forms.Button();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDelItem = new System.Windows.Forms.Button();
            this.cbInventories = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDelPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.txtItemType.Location = new System.Drawing.Point(181, 88);
            this.txtItemType.Name = "txtItemType";
            this.txtItemType.Size = new System.Drawing.Size(250, 29);
            this.txtItemType.TabIndex = 22;
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
            this.txtStatus.Location = new System.Drawing.Point(181, 429);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(180, 29);
            this.txtStatus.TabIndex = 48;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNotes.Location = new System.Drawing.Point(181, 631);
            this.txtNotes.MaxLength = 300;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 114);
            this.txtNotes.TabIndex = 51;
            this.txtNotes.Text = "";
            // 
            // isNull
            // 
            this.isNull.AutoSize = true;
            this.isNull.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isNull.Location = new System.Drawing.Point(376, 400);
            this.isNull.Name = "isNull";
            this.isNull.Size = new System.Drawing.Size(55, 25);
            this.isNull.TabIndex = 47;
            this.isNull.Text = "Boş";
            this.isNull.UseVisualStyleBackColor = true;
            this.isNull.CheckedChanged += new System.EventHandler(this.isNull_CheckedChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(24, 63);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(130, 23);
            this.lblItemName.TabIndex = 19;
            this.lblItemName.Text = "Demirbaş İsmi :";
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtItemName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtItemName.Location = new System.Drawing.Point(181, 57);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(250, 29);
            this.txtItemName.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(24, 636);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 24);
            this.label12.TabIndex = 23;
            this.label12.Text = "Açıklama :";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(24, 373);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 23);
            this.label9.TabIndex = 24;
            this.label9.Text = "İlgili Departman :";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(24, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Konum : ";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "%KDV  :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 27;
            this.label6.Text = "Maliyet :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(24, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Model :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(24, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Marka :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Seri Numarası :";
            // 
            // lblItemType
            // 
            this.lblItemType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblItemType.ForeColor = System.Drawing.Color.Black;
            this.lblItemType.Location = new System.Drawing.Point(24, 94);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(100, 23);
            this.lblItemType.TabIndex = 30;
            this.lblItemType.Text = "Türü : ";
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDepartment.Location = new System.Drawing.Point(181, 367);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(250, 29);
            this.txtDepartment.TabIndex = 45;
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLocation.Location = new System.Drawing.Point(181, 336);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(250, 29);
            this.txtLocation.TabIndex = 44;
            // 
            // txtTaxRate
            // 
            this.txtTaxRate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTaxRate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTaxRate.Location = new System.Drawing.Point(181, 305);
            this.txtTaxRate.Name = "txtTaxRate";
            this.txtTaxRate.Size = new System.Drawing.Size(250, 29);
            this.txtTaxRate.TabIndex = 43;
            // 
            // txtCost
            // 
            this.txtCost.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtCost.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost.Location = new System.Drawing.Point(181, 274);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(250, 29);
            this.txtCost.TabIndex = 42;
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtModel.Location = new System.Drawing.Point(181, 181);
            this.txtModel.MaxLength = 50;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(250, 29);
            this.txtModel.TabIndex = 37;
            // 
            // txtBrand
            // 
            this.txtBrand.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtBrand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBrand.Location = new System.Drawing.Point(181, 150);
            this.txtBrand.MaxLength = 50;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(250, 29);
            this.txtBrand.TabIndex = 33;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtSerialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerialNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSerialNumber.Location = new System.Drawing.Point(181, 119);
            this.txtSerialNumber.MaxLength = 50;
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(250, 29);
            this.txtSerialNumber.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 24);
            this.label1.TabIndex = 32;
            this.label1.Text = "Fotoğraf :";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(24, 466);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 24);
            this.label11.TabIndex = 36;
            this.label11.Text = "Son Bakım Tarihi :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(24, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 23);
            this.label5.TabIndex = 35;
            this.label5.Text = "Son Garanti Süresi : ";
            // 
            // dateTimePickerLastMaintenance
            // 
            this.dateTimePickerLastMaintenance.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerLastMaintenance.Location = new System.Drawing.Point(181, 460);
            this.dateTimePickerLastMaintenance.MinDate = new System.DateTime(2000, 1, 24, 0, 0, 0, 0);
            this.dateTimePickerLastMaintenance.Name = "dateTimePickerLastMaintenance";
            this.dateTimePickerLastMaintenance.Size = new System.Drawing.Size(250, 29);
            this.dateTimePickerLastMaintenance.TabIndex = 49;
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPurchaseDate.ForeColor = System.Drawing.Color.Black;
            this.lblPurchaseDate.Location = new System.Drawing.Point(24, 218);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(151, 25);
            this.lblPurchaseDate.TabIndex = 34;
            this.lblPurchaseDate.Text = "Satın Alınma Tarihi :";
            // 
            // dateTimePickerWarrantyEnd
            // 
            this.dateTimePickerWarrantyEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerWarrantyEnd.Location = new System.Drawing.Point(181, 243);
            this.dateTimePickerWarrantyEnd.MinDate = new System.DateTime(2000, 1, 24, 0, 0, 0, 0);
            this.dateTimePickerWarrantyEnd.Name = "dateTimePickerWarrantyEnd";
            this.dateTimePickerWarrantyEnd.Size = new System.Drawing.Size(250, 29);
            this.dateTimePickerWarrantyEnd.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(24, 437);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 38;
            this.label10.Text = "Durum : ";
            // 
            // dateTimePickerPurchase
            // 
            this.dateTimePickerPurchase.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerPurchase.Location = new System.Drawing.Point(181, 212);
            this.dateTimePickerPurchase.MinDate = new System.DateTime(2000, 1, 24, 0, 0, 0, 0);
            this.dateTimePickerPurchase.Name = "dateTimePickerPurchase";
            this.dateTimePickerPurchase.Size = new System.Drawing.Size(250, 29);
            this.dateTimePickerPurchase.TabIndex = 39;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(24, 404);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(130, 23);
            this.lblUser.TabIndex = 40;
            this.lblUser.Text = "Zimmetli Kişi :";
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUsers.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBoxUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxUsers.Location = new System.Drawing.Point(181, 398);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(180, 29);
            this.comboBoxUsers.TabIndex = 46;
            // 
            // selectFile
            // 
            this.selectFile.BackColor = System.Drawing.SystemColors.HotTrack;
            this.selectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.selectFile.ForeColor = System.Drawing.Color.White;
            this.selectFile.Location = new System.Drawing.Point(400, 495);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(31, 64);
            this.selectFile.TabIndex = 50;
            this.selectFile.Text = "Ekle";
            this.selectFile.UseVisualStyleBackColor = false;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdateItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdateItem.ForeColor = System.Drawing.Color.White;
            this.btnUpdateItem.Location = new System.Drawing.Point(28, 760);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(194, 35);
            this.btnUpdateItem.TabIndex = 52;
            this.btnUpdateItem.Text = "Demirbaş Güncelle";
            this.btnUpdateItem.UseVisualStyleBackColor = false;
            this.btnUpdateItem.Click += new System.EventHandler(this.btnUpdateItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Location = new System.Drawing.Point(181, 495);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // btnDelItem
            // 
            this.btnDelItem.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDelItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelItem.ForeColor = System.Drawing.Color.White;
            this.btnDelItem.Location = new System.Drawing.Point(237, 760);
            this.btnDelItem.Name = "btnDelItem";
            this.btnDelItem.Size = new System.Drawing.Size(194, 35);
            this.btnDelItem.TabIndex = 52;
            this.btnDelItem.Text = "Demirbaş Sil";
            this.btnDelItem.UseVisualStyleBackColor = false;
            this.btnDelItem.Click += new System.EventHandler(this.btnDelItem_Click);
            // 
            // cbInventories
            // 
            this.cbInventories.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbInventories.FormattingEnabled = true;
            this.cbInventories.Location = new System.Drawing.Point(181, 25);
            this.cbInventories.Name = "cbInventories";
            this.cbInventories.Size = new System.Drawing.Size(250, 29);
            this.cbInventories.TabIndex = 54;
            this.cbInventories.SelectedIndexChanged += new System.EventHandler(this.cbInventories_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(24, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 23);
            this.label13.TabIndex = 19;
            this.label13.Text = "Demirbaş  :";
            // 
            // btnDelPhoto
            // 
            this.btnDelPhoto.BackColor = System.Drawing.Color.OrangeRed;
            this.btnDelPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelPhoto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelPhoto.ForeColor = System.Drawing.Color.White;
            this.btnDelPhoto.Location = new System.Drawing.Point(400, 561);
            this.btnDelPhoto.Name = "btnDelPhoto";
            this.btnDelPhoto.Size = new System.Drawing.Size(31, 64);
            this.btnDelPhoto.TabIndex = 50;
            this.btnDelPhoto.Text = "Sil";
            this.btnDelPhoto.UseVisualStyleBackColor = false;
            this.btnDelPhoto.Click += new System.EventHandler(this.btnDelPhoto_Click);
            // 
            // UpdateInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(450, 815);
            this.Controls.Add(this.cbInventories);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtItemType);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.isNull);
            this.Controls.Add(this.label13);
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
            this.Controls.Add(this.dateTimePickerWarrantyEnd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePickerPurchase);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Controls.Add(this.btnDelPhoto);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.btnDelItem);
            this.Controls.Add(this.btnUpdateItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Düzenle / Sil";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox txtItemType;
        private System.Windows.Forms.ComboBox txtStatus;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.CheckBox isNull;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtTaxRate;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastMaintenance;
        private System.Windows.Forms.Label lblPurchaseDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerWarrantyEnd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerPurchase;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Button btnDelItem;
        private System.Windows.Forms.ComboBox cbInventories;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDelPhoto;
    }
}