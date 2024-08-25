using System;
using System.Drawing;
using System.Windows.Forms;
using MeetingApp.Models;

namespace MeetingApp
{
    public partial class LoginForm : Form
    {
        private string connectionString;
        private DatabaseHelper dbHelper;
        public LoginForm() {
            InitializeComponent();
           connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
            if (connectionString != null) {
                dbHelper = new DatabaseHelper(connectionString);
            }
           
            // Placeholder metni başlangıçta ayarlayın
            SetPlaceholderText(txtUsername, "Kullanıcı Adı");
            SetPlaceholderText(txtPassword, "Şifre");

            // Olayları ekleyin
            txtUsername.GotFocus += RemovePlaceholderText;
            txtUsername.LostFocus += SetPlaceholderText;
            txtPassword.GotFocus += RemovePlaceholderText;
            txtPassword.LostFocus += SetPlaceholderText;

            // Veritabanı bağlantısını test et
            if (dbHelper.TestConnection()) {
                lblConnectionStatus.Text = "Connected";
                lblConnectionStatus.ForeColor = System.Drawing.Color.Green;
            } else {
                lblConnectionStatus.Text = "Disconnected";
                lblConnectionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e) {

            // TextBox'ların boş olup olmadığını kontrol edin
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = dbHelper.ValidateUser(txtUsername.Text, txtPassword.Text);
            if (user != null) {
                // User found, login successful
                MessageBox.Show("Giriş Başarılı!");
                    if (user.IsAdmin) {
                        AdminPanel adminPanel = new AdminPanel(dbHelper, user.UserID);
                        adminPanel.FormClosed += (s, args) => this.Visible = true;
                        adminPanel.FormClosed += (s, args) => clearTxtboxes();// AdminPanel kapatıldığında LoginForm'u görünür yap
                        adminPanel.Show();
                        this.Visible = false;
                    }
                   else {
                    UserPanel userPanel = new UserPanel(dbHelper, user.UserID);
                    userPanel.FormClosed += (s, args) => this.Visible = true;
                    userPanel.FormClosed += (s, args) => clearTxtboxes();// AdminPanel kapatıldığında LoginForm'u görünür yap
                    userPanel.Show();
                    this.Visible = false;
                }

            } else {
                // User not found, login failed
                MessageBox.Show("Kullanıcı adı veya parola yanlış.");
            }
        }
        private void clearTxtboxes() { 
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) {
                btnLogin.PerformClick();
            }
        }

        // Placeholder metnini ayarlamak için kullanılan fonksiyon
        private void SetPlaceholderText(TextBox textBox, string placeholder) {
            if (string.IsNullOrWhiteSpace(textBox.Text)) {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
                textBox.Tag = placeholder;
            }
        }

        // Placeholder metnini kaldırmak için kullanılan fonksiyon
        private void RemovePlaceholderText(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if (textBox.ForeColor == Color.Gray) {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        // Placeholder metnini geri ayarlamak için kullanılan fonksiyon
        private void SetPlaceholderText(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text)) {
                textBox.Text = textBox.Tag.ToString();
                textBox.ForeColor = Color.Gray;
            }
        }

        private void lblConnectionStatus_Click(object sender, EventArgs e) {
            using (var configForm = new ConfigurationForm()) {
                if (configForm.ShowDialog() == DialogResult.OK) {
                    MessageBox.Show("Configuration updated successfully!");
                    // Gerekirse bağlantıyı yeniden test edin
                }
            }
        }

        private async void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string username = txtUsername.Text.Trim();

            if (!string.IsNullOrEmpty(username)) {
                try {
                    EmailSender emailSender = new EmailSender(dbHelper,username);
                    string email = dbHelper.GetEmailByUsername(username);

                    if (email != null) {
                        await emailSender.SendEmailAsync(email);
                        MessageBox.Show("Şifre bilgisi gönderildi.");
                    } else {
                        MessageBox.Show("Kullanıcı adı bulunamadı.");
                    }
                } catch (Exception ex) {
                    // Handle any exceptions that occur
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            } else {
                MessageBox.Show("Kullanıcı adı geçersiz.");
            }
        }


        private void linkLabelForgotPassword_MouseHover(object sender, EventArgs e) {
            linkLabelForgotPassword.ForeColor = Color.DarkBlue;
        }
    }
}

