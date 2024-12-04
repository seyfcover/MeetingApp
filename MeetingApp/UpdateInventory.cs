using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateInventory : Form
    {
        private DatabaseHelper dbHelper;
        private int userId , selectedItemId;
        private String fullName;
        private byte[] fileBytes = null;
        
        public UpdateInventory(DatabaseHelper databaseHelper, int userId, String fullName, int selectedItemId) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.userId = userId;
            this.fullName = fullName;
            this.selectedItemId = selectedItemId;
            LoadUsers();
            LoadInventoryItemsToComboBox(cbInventories);
        }

        public void LoadInventoryItemsToComboBox(ComboBox comboBox) {
            // Demirbaş verilerini al
            DataTable inventoryTable = dbHelper.GetInventoryItems();

            // ComboBox özelliklerini ayarla
            comboBox.DisplayMember = "itemName"; // Gösterilecek isim
            comboBox.ValueMember = "itemID";    // Tutulacak değer

            // ComboBox'a DataTable bağla
            comboBox.DataSource = inventoryTable;
            comboBox.SelectedValue = selectedItemId;
        }

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

        private void cbInventories_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbInventories.SelectedIndex >= 0) // Geçerli bir seçim kontrolü
            {
                // Seçilen demirbaşın ID'sini al
                int selectedItemID = Convert.ToInt32(cbInventories.SelectedValue);

                // Detayları getir
                DataRow selectedRow = dbHelper.GetInventoryDetails(selectedItemID);

                // Detayları ilgili alanlara yazdır
                if (selectedRow != null) {
                    txtItemName.Text = selectedRow["itemName"].ToString();
                    txtItemType.Text = selectedRow["itemType"].ToString();
                    txtSerialNumber.Text = selectedRow["serialNumber"].ToString();
                    txtBrand.Text = selectedRow["brand"].ToString();
                    txtModel.Text = selectedRow["model"].ToString();

                    // DateTimePicker için değer atanması
                    if (DateTime.TryParse(selectedRow["purchaseDate"].ToString(), out DateTime purchaseDate))
                        dateTimePickerPurchase.Value = purchaseDate;

                    if (DateTime.TryParse(selectedRow["warrantyEndDate"].ToString(), out DateTime warrantyEndDate))
                        dateTimePickerWarrantyEnd.Value = warrantyEndDate;

                    txtCost.Text = selectedRow["cost"].ToString();
                    txtTaxRate.Text = selectedRow["taxRate"].ToString();


                    object photoData = selectedRow["photo"];
                    if (photoData != DBNull.Value && photoData is byte[] photoBytes && photoBytes.Length > 0) {
                    
                        using (var ms = new System.IO.MemoryStream(photoBytes)) {
                            pictureBox1.Image = Image.FromStream(ms);
                            fileBytes = photoBytes;
                        }
                    } else {
                        pictureBox1.Image = null; // Fotoğraf yoksa PictureBox temizlenir.
                        fileBytes = null;
                        photoData = null;
                    }

                    txtLocation.Text = selectedRow["location"].ToString();
                    txtDepartment.Text = selectedRow["department"].ToString();

                    // ComboBox'a kullanıcı atanması
                    if (selectedRow["userID"] != DBNull.Value) {
                        // userID NULL değilse
                        if (int.TryParse(selectedRow["userID"].ToString(), out int userId)) {
                            isNull.Checked = false;
                            comboBoxUsers.SelectedValue = userId;
                        }
                    } else {
                        // userID NULL ise
                        isNull.Checked = true;
                    }


                    txtStatus.Text = selectedRow["status"].ToString();

                    if (DateTime.TryParse(selectedRow["lastMaintenanceDate"].ToString(), out DateTime lastMaintenanceDate))
                        dateTimePickerLastMaintenance.Value = lastMaintenanceDate;

                    txtNotes.Text = selectedRow["notes"].ToString();
                }
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

        private void isNull_CheckedChanged(object sender, EventArgs e) {
            if (isNull.Checked) {
                comboBoxUsers.DataSource = null;
                comboBoxUsers.SelectedItem = null;
                comboBoxUsers.Enabled = false;
            } else { comboBoxUsers.Enabled = true;
                LoadUsers();
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e) {
            // Seçilen item ID'yi almak
            int? selectedItemId = (int?)cbInventories.SelectedValue;

            // Eğer seçilen item ID geçerli değilse hata mesajı göster
            if (!selectedItemId.HasValue) {
                MessageBox.Show("Lütfen bir ekipman seçin.");
                return;
            }

            // Güncellenmiş Item nesnesini oluştur
            Item updatedItem = new Item(
                itemName: txtItemName.Text.Trim(),
                itemType: txtItemType.Text.Trim(),
                serialNumber: string.IsNullOrEmpty(txtSerialNumber.Text) ? null : txtSerialNumber.Text.Trim(),
                brand: string.IsNullOrEmpty(txtBrand.Text) ? null : txtBrand.Text.Trim(),
                model: string.IsNullOrEmpty(txtModel.Text) ? null : txtModel.Text.Trim(),
                purchaseDate: dateTimePickerPurchase.Value,
                warrantyEndDate: dateTimePickerWarrantyEnd.Value,
                cost: decimal.TryParse(txtCost.Text.Trim(), out var cost) ? cost : (decimal?)null,
                taxRate: decimal.TryParse(txtTaxRate.Text.Trim(), out var taxRate) ? taxRate : (decimal?)null,
                photo: fileBytes != null && fileBytes.Length > 0 ? fileBytes : null,
                location: string.IsNullOrEmpty(txtLocation.Text) ? null : txtLocation.Text.Trim(),
                department: string.IsNullOrEmpty(txtDepartment.Text) ? null : txtDepartment.Text.Trim(),
                userID: (int?)comboBoxUsers.SelectedValue,
                status: string.IsNullOrEmpty(txtStatus.Text) ? null : txtStatus.Text.Trim(),
                lastMaintenanceDate: dateTimePickerLastMaintenance.Value,
                notes: string.IsNullOrEmpty(txtNotes.Text) ? null : txtNotes.Text.Trim(),
                createdAt: null, // Veritabanında zaten mevcut, güncellenmemeli
                updatedAt: DateTime.Now // Güncelleme tarihi
            );

            try {
                // Item nesnesini veritabanına güncelle
                dbHelper.UpdateInventoryItem(updatedItem, selectedItemId);
                MessageBox.Show("Ekipman başarıyla güncellendi.");
            } catch (Exception ex) {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }


        private void btnDelPhoto_Click(object sender, EventArgs e) {
            fileBytes = null;
            pictureBox1.Image = null;
        }

        private void btnDelItem_Click(object sender, EventArgs e) {
            // Seçilen item ID'yi almak
            int? selectedItemId = (int?)cbInventories.SelectedValue;

            // Eğer geçerli bir item ID yoksa hata mesajı göster
            if (!selectedItemId.HasValue) {
                MessageBox.Show("Lütfen bir ekipman seçin.");
                return;
            }

            // Ekipmanı sil
            dbHelper.DeleteInventoryItem(selectedItemId.Value);
            cbInventories.DataSource = null;
            LoadInventoryItemsToComboBox(cbInventories);

        }
    }
}
