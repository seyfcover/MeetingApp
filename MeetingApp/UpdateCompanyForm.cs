using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateCompanyForm : Form
    {
        private DatabaseHelper dbHelper;
        private int selectedCompanyId;
        private int userID;
        public UpdateCompanyForm(DatabaseHelper dbHelper , int userID) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            LoadCompanies();
            isCandidate.CheckedChanged += isCandidate_CheckedChanged;

        }
        private void LoadCompanies() {
            if (!dbHelper.IsAdmin(userID)) {
                isCandidate.Enabled = false;
            } 
            DataTable companies;
            if (isCandidate.Checked == true) {
                 companies = dbHelper.GetCandidateCompanies();
                 canPoints.Enabled = true;
                delCandidate.Enabled = true;
            } else {
                companies = dbHelper.GetCompanies();
                canPoints.Enabled = false;
                if (dbHelper.IsAdmin(userID)) {
                    delCandidate.Enabled = true;
                } else {
                    delCandidate.Enabled = false;
                }
            }
            cmbCompany.DataSource = companies;
            cmbCompany.DisplayMember = "name";
            cmbCompany.ValueMember = "companyID";
            if (companies.Rows.Count > 0) {
                cmbCompany.SelectedIndex = 0; // İlk öğeyi seç
            }
        }

        private void LoadCompanyDetails(int companyId) {
            // Şirket bilgilerini al
            DataRow company = dbHelper.GetCompanyById(companyId);

            if (company != null) {
                txtCompanyName.Text = company["Name"].ToString();
                txtAddress.Text = company["Address"].ToString();
                txtPhone.Text = company["Phone"].ToString();
                txtEmail.Text = company["Email"].ToString();
                txtFieldsOfActivity.Text = company["FieldsOfActivity"].ToString();

                // Logo bilgisi varsa, resim kutusuna yükle
                if (company["Logo"] != DBNull.Value) {
                    byte[] logo = (byte[])company["Logo"];
                    using (MemoryStream ms = new MemoryStream(logo)) {
                        logoBox.Image = Image.FromStream(ms);
                    }
                } else {
                    logoBox.Image = null;
                }
            }
        }

        private void LoadCandidateCompanyDetails(int companyId) {
            // Şirket bilgilerini al
            DataRow company = dbHelper.GetCandidateCompanyById(companyId);

            if (company != null) {
                txtCompanyName.Text = company["Name"].ToString();
                txtAddress.Text = company["Address"].ToString();
                txtPhone.Text = company["Phone"].ToString();
                txtEmail.Text = company["Email"].ToString();
                txtFieldsOfActivity.Text = company["FieldsOfActivity"].ToString();
                canPoints.Text = company["Points"].ToString();
                canPoints.Enabled = true;


                // Logo bilgisi varsa, resim kutusuna yükle
                if (company["Logo"] != DBNull.Value) {
                    byte[] logo = (byte[])company["Logo"];
                    using (MemoryStream ms = new MemoryStream(logo)) {
                        logoBox.Image = Image.FromStream(ms);
                    }
                } else {
                    logoBox.Image = null;
                }
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
            if (!string.IsNullOrWhiteSpace(email)) {
                if (!IsValidEmail(email)) {
                    MessageBox.Show("Yanlış e-mail formatı");
                    return;
                }
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

            if (string.IsNullOrWhiteSpace(fieldsOfActivity)) {
                MessageBox.Show("Faaliyet alanları boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (isCandidate.Checked == true) {
                    int point = Convert.ToInt32(canPoints.Text);
                    if (dbHelper.UpdateCandidateCompany(selectedCompanyId, companyName, address, phone, fieldsOfActivity, logo, email,point)) {
                        MessageBox.Show("Şirket başarıyla güncellendi.");
                        this.Close();
                    } else {
                        MessageBox.Show("Şirket güncellenirken bir hata oluştu.");
                    }
                } else {
                    if (dbHelper.UpdateCompany(selectedCompanyId, companyName, address, phone, fieldsOfActivity, logo, email)) {
                        MessageBox.Show("Şirket başarıyla güncellendi.");
                        this.Close();
                    } else {
                        MessageBox.Show("Şirket güncellenirken bir hata oluştu.");
                    }
                }
                
            } catch (Exception ex) {
                // Hata mesajını logla veya kullanıcıya göster
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void choosePic_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    // Dosya boyutunu kontrol et
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    long fileSizeInBytes = fileInfo.Length;

                    // 1 MB = 1,048,576 bytes
                    if (fileSizeInBytes > 1048576) {
                        MessageBox.Show("Dosya boyutu 1 MB'ı geçmemelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        logoBox.Image = Image.FromFile(openFileDialog.FileName);
                    }
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

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbCompany.SelectedItem is DataRowView selectedRowView) {
                selectedCompanyId = Convert.ToInt32(selectedRowView["CompanyID"]);
                if (isCandidate.Checked == true) {
                    LoadCandidateCompanyDetails(selectedCompanyId);
                } else {
                    LoadCompanyDetails(selectedCompanyId);
                }
                
            } else {
                MessageBox.Show("Geçersiz şirket seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void isCandidate_CheckedChanged(object sender, EventArgs e) {
            LoadCompanies();
        }

        private void delCandidate_Click(object sender, EventArgs e) {
            if (!isCandidate.Checked && dbHelper.IsAdmin(userID)) {
                try {
                    dbHelper.DeleteCompany(selectedCompanyId);
                    MessageBox.Show("Aday şirket silindi");
                    this.Close();
                } catch (Exception ex) {
                    MessageBox.Show("Hata oluştu" + ex.ToString());
                    throw ex;
                }
            } else {
                try {
                    dbHelper.DeleteCandidateCompany(selectedCompanyId);
                    MessageBox.Show("Şirket ve onunla ilgili her şey silindi.");
                    this.Close();
                } catch (Exception ex) {
                    MessageBox.Show("Hata oluştu" + ex.ToString());
                    throw ex;
                }
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

        private void txtCompanyName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtCompanyName);
        }
    }
}
