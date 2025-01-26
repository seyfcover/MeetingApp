using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MeetingApp.Models;

namespace MeetingApp
{
    public partial class UserInformationEditForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;
        private byte  UserType;
        public UserInformationEditForm(DatabaseHelper databaseHelper, int userID, string fullName) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.userID = userID;
            FullName = fullName;
            LoadUsersDetails();
            LoadInventoryByUserId(userID);
            Permissions(userID);
            GetCountInvetories(userID);
        }
        private void GetCountInvetories(int userID) {
             countInventory.Text = dbHelper.CountInventory(userID).ToString();
        }

        private void Permissions(int userID) {

            byte isAdmin = dbHelper.isAdmin(userID);
            if (isAdmin == 4 || isAdmin == 3 || isAdmin == 2) {
                btnRquestMng.Enabled = true;
                btnRquestMng.Visible = true;
            } 
        }
        private void LoadInventoryByUserId(int userId) {
            // DataTable'ı doldurmak için metodu çağırıyoruz
            DataTable inventoryData = dbHelper.GetInventoryItemsByUserId(userId);

            // DataGridView'e verileri atıyoruz
            MyInventoryies.DataSource = inventoryData;

            CustomizeDataGridView();
        }

        private void LoadUsersDetails() {

            // Get the academic details based on AcademicID
            DataTable userDetails = dbHelper.GetDetailUser(userID);

            if (userDetails != null && userDetails.Rows.Count > 0) {
                DataRow row = userDetails.Rows[0];

                // Display the details in the appropriate controls
                txtUsername.Text = row["username"].ToString();
                txtPassword.Text = row["userPassword"].ToString();
                txtFirstName.Text = row["FirstName"].ToString();
                txtLastName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["phoneNumber"].ToString();
                txtTitle.Text = row["Title"].ToString();
                txtPosition.Text = row["Position"].ToString();
                UserType = Convert.ToByte(row["isAdmin"]);
            } else {
                // Handle the case where no details are found
                MessageBox.Show("Seçilen kullanıcının detayları bulunamadı.");
            }

        }

        private void button1_Click(object sender, EventArgs e) {

            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("Lütfen tüm alanları doldurum", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

            if (!IsValidEmail(txtEmail.Text)) {
                MessageBox.Show("Doğru bir e-posta adresi girin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbHelper.UpdateUser(
                userID,
                txtUsername.Text,
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtCompany.Text,
                txtTitle.Text,
                txtPhone.Text,
                txtPassword.Text,
                UserType,
                txtPosition.Text
            );

            MessageBox.Show("Kullanıcı Güncellendi.!");
            dbHelper.AddLog("Güncelleme", FullName + ",  " + txtFirstName.Text + " " + txtLastName.Text + " Kullanıcısını Güncelledi.");
            this.Close();
        }

        private void CustomizeDataGridView() {
            // Sütunların başlıklarını Türkçeleştirme ve istenmeyen sütunları gizleme
            if (MyInventoryies.Columns.Contains("itemID"))
                MyInventoryies.Columns["itemID"].Visible = false; // itemID'yi gizle
            if (MyInventoryies.Columns.Contains("userID"))
                MyInventoryies.Columns["userID"].Visible = false; // userID'yi gizle

            // Sütun başlıklarını Türkçeleştir
            if (MyInventoryies.Columns.Contains("itemName"))
                MyInventoryies.Columns["itemName"].HeaderText = "Ürün Adı";
            if (MyInventoryies.Columns.Contains("itemType"))
                MyInventoryies.Columns["itemType"].HeaderText = "Ürün Türü";
            if (MyInventoryies.Columns.Contains("FullName"))
                MyInventoryies.Columns["FullName"].HeaderText = "Kullanıcı Adı";
            if (MyInventoryies.Columns.Contains("status"))
                MyInventoryies.Columns["status"].HeaderText = "Durum";
            if (MyInventoryies.Columns.Contains("brand"))
                MyInventoryies.Columns["brand"].HeaderText = "Marka";
            if (MyInventoryies.Columns.Contains("model"))
                MyInventoryies.Columns["model"].HeaderText = "Model";
            if (MyInventoryies.Columns.Contains("location"))
                MyInventoryies.Columns["location"].HeaderText = "Konum";
            if (MyInventoryies.Columns.Contains("department"))
                MyInventoryies.Columns["department"].HeaderText = "Departman";

            // DataGridView için genel estetik ayarları
            MyInventoryies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları otomatik genişlet
            MyInventoryies.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy; // Başlık arka plan rengi
            MyInventoryies.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White; // Başlık metin rengi
            MyInventoryies.ColumnHeadersDefaultCellStyle.Font = new Font(MyInventoryies.Font, FontStyle.Bold); // Kalın yazı
            MyInventoryies.EnableHeadersVisualStyles = false; // Varsayılan stilleri devre dışı bırak
            MyInventoryies.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue; // Seçili hücre arka planı
            MyInventoryies.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black; // Seçili hücre metin rengi
            MyInventoryies.DefaultCellStyle.Font = new Font("Segoe UI", 10); // Hücre yazı tipi
            MyInventoryies.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Uzun metinler için sarma
            MyInventoryies.RowHeadersVisible = false; // Satır başlıklarını gizle
        }


        private bool IsValidEmail(string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }

        private void MyInventoryies_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                // itemID değerini al      
                string selectedItemIdStr = MyInventoryies.Rows[e.RowIndex].Cells["itemID"].Value.ToString();
                if (selectedItemIdStr.Length > 3) {
                    int selectedItemId = Convert.ToInt32(selectedItemIdStr.Substring(3));

                    // Yeni bir form aç ve itemID'yi gönder
                    UpdateInventory updateInventoryForm = new UpdateInventory(dbHelper, userID, FullName, selectedItemId);
                    updateInventoryForm.ShowDialog(); // Modsal olarak açabiliriz
                }
                // Eğer ID 'TTO123' gibi bir formatta ise, 'TTO' harflerinden sonraki kısmı almak için:
            }
        }

        private void btnNewRquest_Click(object sender, EventArgs e) {
            NewRequestForm newRequestForm = new NewRequestForm(dbHelper,userID,FullName);
            newRequestForm.ShowDialog();
        }

        private void RequestMng_Click(object sender, EventArgs e) {
            RequestManagement requestManagement = new RequestManagement(dbHelper, userID, FullName);
            requestManagement.ShowDialog();
        }
    }
}
