﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
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
            Permissions(userId);
        }
        private void Permissions(int userID) {

            byte isAdmin = dbHelper.isAdmin(userID);
            if (isAdmin == 4 || isAdmin == 2) {
                btnDelItem.Visible = true;
                btnDelItem.Enabled = true;
                btnUpdateItem.Visible = true;
                btnUpdateItem.Enabled = true;
                comboBoxUsers.Enabled = true;
                cbInventories.Enabled = true;
                cbInventories.Visible = true;
                label13.Visible = true;
                isNull.Enabled = true;
 

            } else {
                this.Text = "Demirbaş Bilgileri";
            }
        }
        private string StringIemID(int itemid) {
            return "TTO"+itemid.ToString();
        }
    

        public void LoadInventoryItemsToComboBox(ComboBox comboBox) {
            // Demirbaş verilerini al
            DataTable inventoryTable = dbHelper.GetInventoryItems();

            // ComboBox özelliklerini ayarla
            comboBox.DisplayMember = "itemName"; // Gösterilecek isim
            comboBox.ValueMember = "itemID";    // Tutulacak değer

            // ComboBox'a DataTable bağla
            comboBox.DataSource = inventoryTable;
            comboBox.SelectedValue = StringIemID(selectedItemId);
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
                string selectedItemID = cbInventories.SelectedValue.ToString();


                // Eğer ID 'TTO123' gibi bir formatta ise, 'TTO' harflerinden sonraki kısmı almak için:
                int selectedItemId = Convert.ToInt32(selectedItemID.Substring(3));


                // Detayları getir
                DataRow selectedRow = dbHelper.GetInventoryDetails(selectedItemId);

                // Detayları ilgili alanlara yazdır
                if (selectedRow != null) {
                    txtID.Text = selectedRow["itemID"].ToString();
                    txtItemName.Text = selectedRow["itemName"].ToString();
                    txtItemType.Text = selectedRow["itemType"].ToString();
                    txtSerialNumber.Text = selectedRow["serialNumber"].ToString();
                    txtBrand.Text = selectedRow["brand"].ToString();
                    txtModel.Text = selectedRow["model"].ToString();

                    // DateTimePicker için değer atanması
                    if (DateTime.TryParse(selectedRow["purchaseDate"].ToString(), out DateTime purchaseDate))
                        dateTimePickerPurchase.Value = purchaseDate;

                    if (DateTime.TryParse(selectedRow["warrantyEndDate"].ToString(), out DateTime warrantyEndDate))
                        dateTimePickerWarranty.Value = warrantyEndDate;

                    checkBoxReminder.Checked = Convert.ToBoolean(selectedRow["reminderStatus"]);
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
            try {
                // Seçilen item ID'yi almak
                if (cbInventories.SelectedValue == null || string.IsNullOrWhiteSpace(cbInventories.SelectedValue.ToString())) {
                    MessageBox.Show("Lütfen bir ekipman seçin.");
                    return;
                }

                if (!int.TryParse(cbInventories.SelectedValue.ToString().Substring(3), out int newSelected)) {
                    MessageBox.Show("Geçersiz ekipman ID.");
                    return;
                }

                // Kullanıcı ID dönüşümü (Güvenli şekilde)
                int? userID = comboBoxUsers.SelectedValue != null ? (int?)Convert.ToInt32(comboBoxUsers.SelectedValue) : null;

                // Hatırlatma durumu
                bool reminderStatus = checkBoxReminder.Checked;

                // Güncellenmiş Item nesnesini oluştur
                Item updatedItem = new Item(
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
                    createdAt: null, // Veritabanında zaten mevcut, güncellenmemeli
                    updatedAt: DateTime.Now, // Güncelleme tarihi
                    reminderStatus: reminderStatus // Yeni eklenen alan
                );

                // Veritabanında güncelle
                dbHelper.UpdateInventoryItem(updatedItem, newSelected);
                MessageBox.Show("Ekipman başarıyla güncellendi.");
                dbHelper.AddLog("Güncelleme", fullName + $" Kullanıcısı {txtItemName.Text} adlı demirbaşı güncelledi. ID: {newSelected}");

            } catch (Exception ex) {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                dbHelper.AddLog("Hata", fullName + $" Kullanıcısı {txtItemName.Text} adlı demirbaşı güncellerken hata oluştu. Hata: {ex.Message}");
            }
        }



        private void btnDelPhoto_Click(object sender, EventArgs e) {
            fileBytes = null;
            pictureBox1.Image = null;
        }

        private void btnDelItem_Click(object sender, EventArgs e) {
            // Seçilen item ID'yi almak
            string selectedItemId = cbInventories.SelectedValue.ToString();
            // Eğer geçerli bir item ID yoksa hata mesajı göster
            if (String.IsNullOrEmpty(selectedItemId)) {
                MessageBox.Show("Lütfen bir ekipman seçin.");
                return;
            }

            // Ekipmanı sil
            dbHelper.DeleteInventoryItem(selectedItemId);
            dbHelper.AddLog("Silme", fullName + " Kullanıcısı " + txtItemName.Text + " adlı demirbaşı sildi." + selectedItemId.ToString());
            cbInventories.DataSource = null;
            LoadInventoryItemsToComboBox(cbInventories);

        }
    }
}
