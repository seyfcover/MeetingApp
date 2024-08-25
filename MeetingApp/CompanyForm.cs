using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class CompanyForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        public CompanyForm(DatabaseHelper dbHelper, int userID) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            logoBox.Image = null;
            this.userID = userID;
            if (!dbHelper.IsAdmin(userID)) {
                isCandidate.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string companyName = txtCompanyName.Text;
                string address = txtAddress.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string fieldsOfActivity = txtFieldsOfActivity.Text;
                byte[] logo = null; // Başlangıçta logo null olarak ayarlanır

                // E-posta doğrulaması
                if (!IsValidEmail(email)) {
                    MessageBox.Show("Doğru bir e-mail adresi girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Alanların boş olup olmadığını kontrol et
                if (string.IsNullOrWhiteSpace(companyName)) {
                    MessageBox.Show("Şirket adı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(address)) {
                    MessageBox.Show("Adres boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(phone)) {
                    MessageBox.Show("Telefon numarası boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(fieldsOfActivity)) {
                    MessageBox.Show("Faaliyet alanları boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            if (isCandidate.Checked == false) {
                
                try {
                    // Logo varsa, byte dizisine dönüştür
                    if (logoBox.Image != null) {
                        using (MemoryStream ms = new MemoryStream()) {
                            logoBox.Image.Save(ms, ImageFormat.Png);
                            logo = ms.ToArray();
                        }
                    }

                    // Şirketi eklemeye çalış
                    if (dbHelper.AddCompany(companyName, address, phone, fieldsOfActivity, logo, email)) {
                        MessageBox.Show("Şirket başarıyla eklendi.");
                        this.Close();
                    } else {
                        MessageBox.Show("Şirket eklenirken bir hata oluştu.");
                    }
                } catch (Exception ex) {
                    // Hata mesajını logla veya kullanıcıya göster
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else {

                int point = Convert.ToInt32(canPoints.Text);
              
                // Alanların boş olup olmadığını kontrol et
                if (string.IsNullOrWhiteSpace(point.ToString())) {
                    MessageBox.Show("Puanlama boş olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try {
                    // Logo varsa, byte dizisine dönüştür
                    if (logoBox.Image != null) {
                        using (MemoryStream ms = new MemoryStream()) {
                            logoBox.Image.Save(ms, ImageFormat.Png);
                            logo = ms.ToArray();
                        }
                    }

                    // Şirketi eklemeye çalış
                    if (dbHelper.AddCandidateCompany(companyName, address, phone, fieldsOfActivity, logo, email , point)) {
                        MessageBox.Show("Şirket başarıyla eklendi.");
                        this.Close();
                    } else {
                        MessageBox.Show("Şirket eklenirken bir hata oluştu.");
                    }
                } catch (Exception ex) {
                    // Hata mesajını logla veya kullanıcıya göster
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            
        }

        private void choosePic_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    logoBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private bool IsValidEmail(string email) {
            try {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(email);
            } catch (Exception) {
                return false;
            }
        }

        private void isCandidate_CheckedChanged(object sender, EventArgs e) {
            if (isCandidate.Checked) {
                canPoints.Enabled = true;
            } else {
                canPoints.Enabled = false;
            }
        }

        private void canPoints_KeyPress(object sender, KeyPressEventArgs e) {
            // Yalnızca sayı ve silme tuşuna izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void canPoints_TextChanged(object sender, EventArgs e) {
            if (int.TryParse(canPoints.Text, out int value)) {
                // Değer 0-100 aralığında değilse, textbox'ı temizle
                if (value < 0 || value > 100) {
                    MessageBox.Show("Lütfen 0 ile 100 arasında bir değer girin.");
                    canPoints.Text = string.Empty;
                }
            } else {
                // Eğer geçersiz bir giriş yapılırsa (örneğin boş bırakılırsa), textbox'ı temizle
                canPoints.Text = string.Empty;
            }
        }
    }
}
