
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateUsers : Form
    {
        private DatabaseHelper dbHelper;
        private ErrorProvider errorProvider;
        private int selecteduserID;
        private int userID;
        private string FullName;
        public UpdateUsers(DatabaseHelper dbHelper, int userID, string FullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.FullName = FullName;
            this.errorProvider = new ErrorProvider();
            PopulateUserTypes();
            LoadUsers();

            // E-mail numarası için validasyon olaylarını ekleyin
            txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            
        }
        // ComboBox'a key-value atama fonksiyonu
        private void PopulateUserTypes() {
            userTypes.DataSource = null;
            var userTypesList = new Dictionary<byte, string>()
            {
                { 3, "TTO Admin" },
                { 2, "İdari Admin" },
                { 0, "User" }
            };

            // ComboBox'a veri bağlama
            userTypes.DataSource = new BindingSource(userTypesList, null);
            userTypes.DisplayMember = "Value";  // Kullanıcıya gösterilecek değer
            userTypes.ValueMember = "Key";      // Arka planda tutulacak değer

            // Varsayılan seçim yapmak istersen
            userTypes.SelectedIndex = -1;  // Hiçbiri seçili olmasın
        }


        private void LoadUsers() {
            DataTable users = dbHelper.GetUsers();

            // FullName sütunu ekleyelim
            users.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");
            listofUsers.DataSource = users;
            listofUsers.DisplayMember = "FullName";
            listofUsers.ValueMember = "userID";
        }

        private void btnRegister_Click(object sender, EventArgs e) {
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
                selecteduserID,
                txtUsername.Text,
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtCompany.Text,
                txtTitle.Text,
                txtPhone.Text,
                txtPassword.Text,
                (byte)userTypes.SelectedValue,
                txtPosition.Text
            );

            MessageBox.Show("Kullanıcı Güncellendi.!");
            dbHelper.AddLog("Güncelleme", FullName + ",  " + txtFirstName.Text + " " + txtLastName.Text + " Kullanıcısını Güncelledi.");
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e) {
            // Seçili kullanıcı ID'sini kontrol et
            if (selecteduserID <= 0) {
                MessageBox.Show("Lütfen silmek için geçerli bir kullanıcı seçin.", "Geçersiz Seçim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıdan silme onayı al
            DialogResult result = MessageBox.Show("Bu kullanıcıyı silmek istediğinizden emin misiniz?", "Kullanıcı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                // Kullanıcıyı sil
                bool isDeleted = dbHelper.DeleteUser(selecteduserID);

                if (isDeleted) {
                    MessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbHelper.AddLog("Silme", FullName + ",  " + txtFirstName.Text + " " + txtLastName.Text + " Kullanıcısını Sildi.");
                    LoadUsers(); 
                } else {
                    MessageBox.Show("Kullanıcı silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dbHelper.AddLog("Hata", FullName + ",  " + txtFirstName.Text + " " + txtLastName.Text + " Kullanıcısını Silerken Hata Oluştu.");
                }
            }
        }

        private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            if (!IsValidEmail(txtEmail.Text)) {
                errorProvider.SetError(txtEmail, "Lütfen geçerli bir adres girin");
            } else {
                errorProvider.SetError(txtEmail, "");
            }
        }

        private bool IsValidEmail(string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }

        private void listofUsers_SelectedIndexChanged(object sender, EventArgs e) {
            if (listofUsers.SelectedValue != null && int.TryParse(listofUsers.SelectedValue.ToString(), out int selectedID)) {
                selecteduserID = selectedID;

                // Get the academic details based on AcademicID
                DataTable userDetails = dbHelper.GetDetailUser(selecteduserID);

                if (userDetails != null && userDetails.Rows.Count > 0) {
                    DataRow row = userDetails.Rows[0];

                    // Display the details in the appropriate controls
                    userTypes.SelectedValue = Convert.ToByte(row["isAdmin"]);
                    txtUsername.Text = row["username"].ToString();
                    txtPassword.Text = row["userPassword"].ToString();
                    txtFirstName.Text = row["FirstName"].ToString();
                    txtLastName.Text = row["LastName"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtPhone.Text = row["phoneNumber"].ToString();
                    txtTitle.Text = row["Title"].ToString();
                    txtPosition.Text = row["Position"].ToString();
                } else {
                    // Handle the case where no details are found
                    MessageBox.Show("Seçilen kullanıcının detayları bulunamadı.");
                }
            } else {
                // Handle the case where selection is invalid or no item is selected
                
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtFirstName);
        }
    }
}
