using System;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class InventoryManagementForm : Form
    {
        private DatabaseHelper dbHelper;
        private string FullName;
        private byte[] fileBytes = null;

        public InventoryManagementForm(DatabaseHelper databaseHelper, string FullName) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.FullName = FullName;
        }

        // Form yüklendiğinde gerekli verileri al
        private void InventoryManagementForm_Load(object sender, EventArgs e) {
            LoadUsers();
            ValidateNumberRange(txtTaxRate);
            ValidateNumber(txtCost);
        }

        // Kullanıcıları comboBox'a yükle
        private void LoadUsers() {
            try {
                DataTable usersTable = dbHelper.GetUsers();
                usersTable.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");

                comboBoxUsers.DataSource = usersTable;
                comboBoxUsers.DisplayMember = "FullName";  // FullName sütununu göster
                comboBoxUsers.ValueMember = "userID";     // Kullanıcı ID'sini değer olarak al
            } catch (Exception ex) {
                MessageBox.Show("Kullanıcılar yüklenirken hata oluştu: " + ex.Message);
            }
            comboBoxUsers.SelectedItem = null;
        }


        // Add Item butonuna tıklanınca yeni öğe ekle
        private void btnAddItem_Click(object sender, EventArgs e) {
            try {
                // Gerekli alanları kontrol et
                if (string.IsNullOrEmpty(txtItemName.Text.Trim())) {
                    MessageBox.Show("Öğe adı boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtItemType.Text.Trim())) {
                    MessageBox.Show("Öğe tipi boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtSerialNumber.Text.Trim())) {
                    MessageBox.Show("Seri numarası boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtBrand.Text.Trim())) {
                    MessageBox.Show("Marka boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtModel.Text.Trim())) {
                    MessageBox.Show("Model boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtCost.Text.Trim())) {
                    MessageBox.Show("Maliyet boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTaxRate.Text.Trim())) {
                    MessageBox.Show("%KDV boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtLocation.Text.Trim())) {
                    MessageBox.Show("Konum boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtDepartment.Text.Trim())) {
                    MessageBox.Show("Departman boş olamaz.");
                    return;
                }
                if (string.IsNullOrEmpty(txtStatus.Text.Trim())) {
                    MessageBox.Show("Durum boş olamaz.");
                    return;
                }

                // Kullanıcı ID dönüşümü (Güvenli şekilde)
                int? userID = comboBoxUsers.SelectedValue != null ? (int?)Convert.ToInt32(comboBoxUsers.SelectedValue) : null;

                // ReminderStatus Checkbox kontrolü
                bool reminderStatus = checkBoxReminder.Checked;

                Item newItem = new Item(
                    itemName: txtItemName.Text.Trim(),
                    itemType: txtItemType.Text.Trim(),
                    serialNumber: string.IsNullOrEmpty(txtSerialNumber.Text) ? null : txtSerialNumber.Text.Trim(),
                    brand: string.IsNullOrEmpty(txtBrand.Text) ? null : txtBrand.Text.Trim(),
                    model: string.IsNullOrEmpty(txtModel.Text) ? null : txtModel.Text.Trim(),
                    purchaseDate: dateTimePickerPurchase.Checked ? dateTimePickerPurchase.Value : (DateTime?)null,
                    warrantyEndDate: dateTimePickerWarranty.Checked ? dateTimePickerWarranty.Value : (DateTime?)null,
                    cost: decimal.TryParse(txtCost.Text.Trim(), out var cost) ? cost : (decimal?)null,
                    taxRate: decimal.TryParse(txtTaxRate.Text.Trim(), out var taxRate) ? taxRate : (decimal?)null,
                    photo: fileBytes != null && fileBytes.Length > 0 ? fileBytes : null,
                    location: string.IsNullOrEmpty(txtLocation.Text) ? null : txtLocation.Text.Trim(),
                    department: string.IsNullOrEmpty(txtDepartment.Text) ? null : txtDepartment.Text.Trim(),
                    userID: userID,
                    status: string.IsNullOrEmpty(txtStatus.Text) ? null : txtStatus.Text.Trim(),
                    lastMaintenanceDate: dateTimePickerLastMaintenance.Checked ? dateTimePickerLastMaintenance.Value : (DateTime?)null,
                    notes: string.IsNullOrEmpty(txtNotes.Text) ? null : txtNotes.Text.Trim(),
                    createdAt: null, // Veritabanında otomatik ekleniyor
                    updatedAt: DateTime.Now, // Güncelleme tarihi
                    reminderStatus: reminderStatus// Yeni eklenen alan
                );
                // Belirtilen miktar kadar öğe ekle
                for (int i = 0; i < countItem.Value; i++) {
                    dbHelper.AddInventoryItem(newItem);
                }

                dbHelper.AddLog("Ekleme", FullName + $" {txtItemName.Text} ürününü envantere ekledi.");
                MessageBox.Show("Öğe başarıyla eklendi.");
                ClearForm();
            } catch (Exception ex) {
                MessageBox.Show("Öğe eklenirken hata oluştu: " + ex.Message);
                dbHelper.AddLog("Hata", FullName + $" {txtItemName.Text} ürününü envantere eklerken hata oluştu. " + ex.Message);
            }
        }


        public void ValidateNumberRange(TextBox textBox) {
            // TextBox'ın TextChanged olayını kullanarak her metin değişikliğinde kontrol yapılacak
            textBox.TextChanged -= TextBox_TextChanged; // Olayı önceden varsa temizle
            textBox.TextChanged += TextBox_TextChanged; // Olayı tekrar bağla

            // Bu kontrol yalnızca sayıları ve boşluğu kontrol eder
            void TextBox_TextChanged(object sender, EventArgs e) {
                // TextBox içeriği bir sayıya dönüştürülebiliyorsa
                if (int.TryParse(textBox.Text, out int value)) {
                    // Sayının 1 ile 200 arasında olup olmadığını kontrol et
                    if (value < 1 || value > 200) {
                        MessageBox.Show("Lütfen 1 ile 200 arasında bir sayı giriniz.");
                        textBox.Text = ""; // Girişi temizle
                    }
                } else {
                    // Sayı değilse, boş bırakabiliriz veya hata mesajı verebiliriz
                    textBox.Text = ""; // Girişi temizle
                }
            }
        }
        public void ValidateNumber(TextBox textBox) {
            // TextBox'ın TextChanged olayını kullanarak her metin değişikliğinde kontrol yapılacak
            textBox.TextChanged -= TextBox_TextChanged; // Olayı önceden varsa temizle
            textBox.TextChanged += TextBox_TextChanged; // Olayı tekrar bağla

            // Bu kontrol yalnızca sayıları ve boşluğu kontrol eder
            void TextBox_TextChanged(object sender, EventArgs e) {
                // TextBox içeriği bir sayıya dönüştürülebiliyorsa
                if (int.TryParse(textBox.Text, out int value)) {

                } else {
                    textBox.Text = ""; // Girişi temizle}
                }
            }
        }


        // Formu temizle
        private void ClearForm() {
            txtItemName.Clear();              
            txtItemType.SelectedItem = null;  
            txtSerialNumber.Clear();         
            txtBrand.Clear();                
            txtModel.Clear();          
            dateTimePickerPurchase.Value = DateTime.Now;  
            dateTimePickerWarranty.Value = DateTime.Now; 
            txtCost.Clear();               
            txtTaxRate.Clear();              
            txtLocation.Clear();              
            txtDepartment.Clear();
            txtStatus.SelectedItem = null;              
            dateTimePickerLastMaintenance.Value = DateTime.Now; 
            txtNotes.Clear();                  
            comboBoxUsers.SelectedItem = null; 
            isNull.Checked = false;           
            fileBytes = null;                 
            pictureBox1.Image = null;         
        }


        private void isNull_CheckedChanged(object sender, EventArgs e) {
            if (isNull.Checked) {
                comboBoxUsers.DataSource = null;
                comboBoxUsers.SelectedItem = null;
                comboBoxUsers.Enabled = false;
            } else {
                comboBoxUsers.Enabled = true;
                LoadUsers();
            }
        }

        private void selectFile_Click(object sender, EventArgs e) {
            // OpenFileDialog nesnesini oluştur
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Yalnızca resim dosyalarına izin ver
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Resim Dosyası Seçin";

            // Kullanıcı dosya seçerse
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // Dosya yolunu al
                string filePath = openFileDialog.FileName;

                // Dosyanın boyutunu kontrol et (3MB = 3 * 1024 * 1024 byte)
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > 3 * 1024 * 1024) // 3MB
                {
                    MessageBox.Show("Dosya boyutu 3MB'dan büyük olamaz.");
                    return;
                }

                // Dosyayı byte dizisine oku
                 fileBytes = File.ReadAllBytes(filePath);

                try {
                    // Seçilen resmi PictureBox'ta görüntüle
                    pictureBox1.Image = Image.FromFile(filePath);
                } catch (Exception ex) {
                    MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message);
                }

                // Dosyayı başarıyla okuduktan sonra fileBytes değişkenini kullanabilirsiniz.
                // Örneğin, fileBytes değişkenini veritabanına kaydedebilirsiniz.
                MessageBox.Show("Dosya başarıyla seçildi.");
            }
        }

    }
}
