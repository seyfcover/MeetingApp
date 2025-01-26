using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateCompanyForm : Form
    {
        private DatabaseHelper dbHelper;
        private int selectedCompanyId;
        private int userID;
        private string FullName;
        public UpdateCompanyForm(DatabaseHelper dbHelper , int userID, string FullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.FullName = FullName;
            LoadCompanies();
            Permissions(userID);
            isCandidate.CheckedChanged += isCandidate_CheckedChanged;

        }
        private void Permissions(int userID) {
            byte isAdmin = dbHelper.isAdmin(userID);
            if (isAdmin == 4 || isAdmin == 3) {
                delCandidate.Enabled = true;
                delCandidate.Visible = true;
                isCandidate.Visible = true;
                isCandidate.Enabled = true;
            }
        }
        private void LoadCompanies() {
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

            if (selectedCompanyId <= 0) {
                MessageBox.Show("Lütfen şirket seçin");
                return;
            }
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
            string emptyMask = "(   )    -    "; // MaskedTextBox boşken görünen format

            if (phone == emptyMask) {
                // Boş veya eksik bilgi varsa null olarak değerlendir
                phone = null;
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
                        dbHelper.AddLog("Güncelleme", "ID:" + userID.ToString() + " " + FullName + " || Aday Şirket : " +companyName + " Güncellendi. ");
                        ClearForms();
                    } else {
                        MessageBox.Show("Şirket güncellenirken bir hata oluştu.");
                        dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Aday Şirket : " + companyName + " Güncellenirken Hata Oluştu. ");
                    }
                } else {
                    if (dbHelper.UpdateCompany(selectedCompanyId, companyName, address, phone, fieldsOfActivity, logo, email)) {
                        MessageBox.Show("Şirket başarıyla güncellendi.");
                        dbHelper.AddLog("Güncelleme", "ID:" + userID.ToString() + " " + FullName + " || Şirket : " + companyName + " Güncellendi. ");
                        ClearForms();
                    } else {
                        MessageBox.Show("Şirket güncellenirken bir hata oluştu.");
                        dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Şirket : " + companyName + " Güncellenirken Hata Oluştu. ");
                    }
                }
                
            } catch (Exception ex) {
                // Hata mesajını logla veya kullanıcıya göster
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " Hata Oluştu. " + ex.Message);
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
            if (cmbCompany.SelectedItem == null) {
                return;
            }
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
            if (selectedCompanyId > 0) {
                if (!isCandidate.Checked && dbHelper.IsAdmin(userID)) {
                    try {
                        dbHelper.DeleteCompany(selectedCompanyId);
                        MessageBox.Show("Şirket ve onunla ilgili her şey silindi.");
                        dbHelper.AddLog("Silme", "ID:" + userID.ToString() + " " + FullName + " || Şirket : " + txtCompanyName.Text + " Silindi. ");
                        ClearForms();
                    } catch (Exception ex) {
                        MessageBox.Show("Hata oluştu" + ex.ToString());
                        dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Şirket : " + txtCompanyName.Text + " Silinirken Hata Oluştu. "+ ex.ToString());
                        throw ex;
                    }
                } else {
                    try {
                        dbHelper.DeleteCandidateCompany(selectedCompanyId);
                        MessageBox.Show("Aday şirket silindi");
                        dbHelper.AddLog("Silme", "ID:" + userID.ToString() + " " + FullName + " || Aday Şirket : " + txtCompanyName.Text + " Silindi. ");
                        ClearForms();
                    } catch (Exception ex) {
                        MessageBox.Show("Hata oluştu" + ex.ToString());
                        dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Aday Şirket : " + txtCompanyName.Text + " Silinirken Hata Oluştu. " + ex.ToString());
                        throw ex;
                    }
                }
            } else {
                MessageBox.Show("Lütfen şirket seçin.");
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

        private void ClearForms() { 
            txtCompanyName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty; 
            txtFieldsOfActivity.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cmbCompany.SelectedItem = null;
            canPoints.Text = string.Empty;
            logoBox.Image = null;
            LoadCompanies();

        }
        private void txtCompanyName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtCompanyName);
        }
    }
}
