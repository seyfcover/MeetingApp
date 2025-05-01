using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class InventoryStatus : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private String FullName;
        private DataTable OriginalTable;

        public InventoryStatus(DatabaseHelper databaseHelper, int userID, String FullName) {
            InitializeComponent();
            dbHelper = databaseHelper; 
            this.userID = userID;
            this.FullName = FullName;
            LoadInventoryData();
            CountInventories.Text = dbHelper.CountAllInventories().ToString();
        }
        private void InventoryStatus_Load(object sender, EventArgs e) {
            // Veritabanından envanter öğelerini al
            dataGridViewInventory.DataSource = null;
            DataTable inventoryTable = dbHelper.GetInventoryItems();
            OriginalTable = inventoryTable;
            dataGridViewInventory.DataSource = inventoryTable;

            // Kolon başlıklarını Türkçe yap
            dataGridViewInventory.Columns["itemID"].Visible = false;  // itemID kolonunu gizle
            dataGridViewInventory.Columns["userID"].Visible = false;  // userID kolonunu gizle
            dataGridViewInventory.Columns["itemName"].HeaderText = "Ekipman Adı";
            dataGridViewInventory.Columns["itemType"].HeaderText = "Ekipman Türü";
            dataGridViewInventory.Columns["FullName"].HeaderText = "Kullanıcı Adı";
            dataGridViewInventory.Columns["status"].HeaderText = "Durum";
            dataGridViewInventory.Columns["brand"].HeaderText = "Marka";
            dataGridViewInventory.Columns["model"].HeaderText = "Model";
            dataGridViewInventory.Columns["location"].HeaderText = "Konum";
            dataGridViewInventory.Columns["department"].HeaderText = "Departman";

            // Tasarım
            dataGridViewInventory.AllowUserToAddRows = false;  // Satır eklemeye izin verme
            dataGridViewInventory.AllowUserToDeleteRows = false;  // Satır silmeye izin verme
            dataGridViewInventory.ReadOnly = true;  // Veriler yalnızca okunabilir
            dataGridViewInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // Kolon genişliklerini otomatik ayarla
            dataGridViewInventory.BackgroundColor = Color.White;  // Arka plan rengini beyaz yap

            // Satır rengi düzenlemeleri
            dataGridViewInventory.DefaultCellStyle.BackColor = Color.LightGray;  // Satır arka planı
            dataGridViewInventory.DefaultCellStyle.ForeColor = Color.Black;  // Yazı rengi
            dataGridViewInventory.DefaultCellStyle.Font = new Font("Arial", 10);  // Yazı tipi

            // Alternatif satır renkleri
            dataGridViewInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  // Alternatif satır rengi

            // Başlıkların renkleri ve düzenlemeleri
            dataGridViewInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);  // Başlık yazı tipi

            // Kenarlık düzenlemeleri
            dataGridViewInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;  // Hücre kenarlıkları
            dataGridViewInventory.GridColor = Color.Gray;  // Grid çizgisi rengi

            // Satır yüksekliği
            dataGridViewInventory.RowTemplate.Height = 20;  // Satır yüksekliğini artır

            // Kolonlar ve satırlar arasındaki boşluk
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInventory.RowTemplate.Height = 40;

            // Kolonları yeniden boyutlandır
            dataGridViewInventory.AutoResizeColumns();
            LoadInventoryData();
        }
        private void LoadInventoryData() {
            try {
                // Veritabanından envanter verilerini al
                DataTable inventoryTable = dbHelper.GetInventoryItems(); // Veritabanı sorgusunu kullanarak veri alır

                // DataGridView'e veri bağla
                dataGridViewInventory.DataSource = inventoryTable;

                // Renkli satırlar için DataGridView'i formatla
                FormatInventoryGrid();
            } catch (Exception ex) {
                MessageBox.Show("Envanter verileri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void FormatInventoryGrid() {
            foreach (DataGridViewRow row in dataGridViewInventory.Rows) {
                if (row.Cells["status"].Value != null) {
                    string status = row.Cells["status"].Value.ToString();

                    switch (status) {
                        case "Bakımda":
                            row.DefaultCellStyle.BackColor = Color.Moccasin;
                            break;
                        case "Mevcut":
                            row.DefaultCellStyle.BackColor = Color.Honeydew;
                            break;
                        case "Kayıp":
                            row.DefaultCellStyle.BackColor = Color.MistyRose;
                            break;
                        case "Kullanımda":
                            row.DefaultCellStyle.BackColor = Color.AliceBlue;
                            break;
                        case "Arızalı":
                            row.DefaultCellStyle.BackColor = Color.Gainsboro;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White; // Varsayılan renk
                            break;
                    }
                }
            }
        }

        private void dataGridViewInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Eğer çift tıklanan satır geçerli bir satırsa
            if (e.RowIndex >= 0) {
                // itemID değerini al
                string selectedItemIdStr = dataGridViewInventory.Rows[e.RowIndex].Cells["itemID"].Value.ToString();

                // Eğer ID 'TTO123' gibi bir formatta ise, 'TTO' harflerinden sonraki kısmı almak için:
                int selectedItemId = Convert.ToInt32(selectedItemIdStr.Substring(3));



                // Yeni bir form aç ve itemID'yi gönder
                UpdateInventory updateInventoryForm = new UpdateInventory(dbHelper, userID, FullName, selectedItemId);
                updateInventoryForm.ShowDialog(); // Modsal olarak açabiliriz
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e) {
            InventoryManagementForm InventoryManagementForm = new InventoryManagementForm(dbHelper,FullName);
            InventoryManagementForm.ShowDialog(); // Modsal olarak açabiliriz
        }

        private void btn_refItems_Click(object sender, EventArgs e) {
            dataGridViewInventory.DataSource = null;
            InventoryStatus_Load(null, null);
            LoadInventoryData();
            originalTable();
            CountInventories.Text = dbHelper.CountAllInventories().ToString();
        }
        private void originalTable() {
            OriginalTable = dbHelper.GetInventoryItems();
        }

        private void txtbox_searchItems_TextChanged(object sender, EventArgs e) {
            // Arama metnini al
            string searchText = txtbox_searchItems.Text.ToLower();

            // Orijinal tabloyu filtrele
            if (string.IsNullOrWhiteSpace(searchText)) {
                // Arama kutusu boşsa orijinal tabloyu göster
                dataGridViewInventory.DataSource = OriginalTable;
                return;
            }

            // Yeni bir DataTable oluştur
            DataTable filteredTable = OriginalTable.Clone(); // Yapıyı klonla (kolonları oluştur)

            foreach (DataRow row in OriginalTable.Rows) {
                // Görünen kolonlarda arama yap
                foreach (DataColumn column in OriginalTable.Columns) {
                   // if (!dataGridViewInventory.Columns[column.ColumnName].Visible)
                      //  continue; // Sadece görünen kolonları kontrol et

                    string cellValue = row[column.ColumnName].ToString().ToLower();
                    if (cellValue.Contains(searchText)) {
                        filteredTable.Rows.Add(row.ItemArray); // Eşleşen satırı ekle
                        break;
                    }
                }
            }

            // Filtrelenmiş tabloyu DataGridView'e ata
            dataGridViewInventory.DataSource = filteredTable;
            FormatInventoryGrid();
        }
    }
}
