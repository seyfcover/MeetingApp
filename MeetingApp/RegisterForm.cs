using System;
using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class RegisterForm : Form
    {
        private DatabaseHelper dbHelper;
        private ErrorProvider errorProvider;
        private string username;
        private int userID;
        private string FullName;
        public RegisterForm(DatabaseHelper dbHelper , int userID , string FullName) {
            InitializeComponent();
            this.userID = userID;
            this.FullName = FullName;
            this.dbHelper = dbHelper;
            this.errorProvider = new ErrorProvider();

            // E-mail numarası için validasyon olaylarını ekleyin
            txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
     
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
            if (dbHelper.isIdentyusername(username)){
                MessageBox.Show("Bu kullanıcı adı kullanılıyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(txtEmail.Text)) {
                MessageBox.Show("Doğru bir e-posta adresi girin", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbHelper.RegisterUser(
                username,
                txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtCompany.Text,
                txtTitle.Text,
                txtPhone.Text,
                txtPassword.Text,
                (byte)0,
                txtPosition.Text
            );

            MessageBox.Show("Kayıt başarılı!");
            dbHelper.AddLog("Ekleme", FullName + " || " + txtFirstName.Text + " " + txtLastName.Text + " Kullanıcısını Eklledi");
            this.Close();
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

        private void txtUsername_TextChanged(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.StartsWith("@@")) {
                // Geçerli kullanıcı adı
                chkIsAdmin.Checked = true;
                panel1.BackColor = Color.LightGreen;
                // @@ karakterlerini çıkar
                username = textBox.Text.Substring(2);
                // cleanUsername'ı kullanmak isterseniz burada kullanabilirsiniz
            } else {
                // Geçersiz kullanıcı adı
                username = textBox.Text;
                panel1.BackColor = Color.Azure;
                chkIsAdmin.Checked = false;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtFirstName);
        }
    }

}

