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

        public InventoryStatus(DatabaseHelper databaseHelper, int userID, String FullName) {
            InitializeComponent();
            dbHelper = databaseHelper; 
            this.userID = userID;
            this.FullName = FullName;
            LoadInventoryData();
        }
        private void InventoryStatus_Load(object sender, EventArgs e) {
            // Veritabanından envanter öğelerini al
            DataTable inventoryTable = dbHelper.GetInventoryItems();
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
            dataGridViewInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;  // Başlık arka planı
            dataGridViewInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;  // Başlık yazı rengi
            dataGridViewInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);  // Başlık yazı tipi

            // Kenarlık düzenlemeleri
            dataGridViewInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;  // Hücre kenarlıkları
            dataGridViewInventory.GridColor = Color.Gray;  // Grid çizgisi rengi

            // Satır yüksekliği
            dataGridViewInventory.RowTemplate.Height = 30;  // Satır yüksekliğini artır

            // Kolonlar ve satırlar arasındaki boşluk
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInventory.RowTemplate.Height = 40;

            // Kolonları yeniden boyutlandır
            dataGridViewInventory.AutoResizeColumns();
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
                if (row.Cells["status"].Value != null && row.Cells["status"].Value.ToString() == "In Maintenance") {
                    // Eğer ekipman bakımda ise, satırı kırmızı renkte yap
                    row.DefaultCellStyle.BackColor = Color.Red;
                } else if (row.Cells["status"].Value != null && row.Cells["status"].Value.ToString() == "Available") {
                    // Eğer ekipman kullanılabilir durumdaysa, satırı yeşil yap
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void dataGridViewInventory_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Eğer çift tıklanan satır geçerli bir satırsa
            if (e.RowIndex >= 0) {
                // itemID değerini al
                int selectedItemId = Convert.ToInt32(dataGridViewInventory.Rows[e.RowIndex].Cells["itemID"].Value);

                // Yeni bir form aç ve itemID'yi gönder
                UpdateInventory updateInventoryForm = new UpdateInventory(dbHelper, userID, FullName, selectedItemId);
                updateInventoryForm.ShowDialog(); // Modsal olarak açabiliriz
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e) {
            InventoryManagementForm InventoryManagementForm = new InventoryManagementForm(dbHelper);
            InventoryManagementForm.ShowDialog(); // Modsal olarak açabiliriz
        }
    }
}
