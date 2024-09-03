using MeetingApp.Models;
using System;
using System.Data;
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
            LoadCompanies();
        }

        private void LoadCompanies() {
            DataTable companies = dbHelper.GetCompanies();
            cmbCompany.DataSource = companies;
            cmbCompany.DisplayMember = "name";
            cmbCompany.ValueMember = "companyID";
            // Son eklenen şirketin seçili olmasını sağla
            if (companies.Rows.Count > 0) {
                int lastCompanyID = (int)companies.Compute("MAX(companyID)", string.Empty);
                cmbCompany.SelectedValue = lastCompanyID;
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
            if (!string.IsNullOrWhiteSpace(txtEmail.Text)) {
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
                        clearForm();
                        LoadCompanies();
                        EtxtFirstName.Focus();
                    } else {
                        MessageBox.Show("Şirket eklenirken bir hata oluştu.");
                    }
                } catch (Exception ex) {
                    // Hata mesajını logla veya kullanıcıya göster
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {

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
                    if (dbHelper.AddCandidateCompany(companyName, address, phone, fieldsOfActivity, logo, email, point)) {
                        MessageBox.Show("Şirket başarıyla eklendi.");
                        clearForm();
                    } else {
                        MessageBox.Show("Şirket eklenirken bir hata oluştu.");
                    }
                } catch (Exception ex) {
                    // Hata mesajını logla veya kullanıcıya göster
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void clearForm() {
            txtCompanyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFieldsOfActivity.Text = string.Empty;
            logoBox.Image = null;
        }

        private void EclearForm() {
            EtxtFirstName.Text = string.Empty;
            EtxtLastName.Text = string.Empty;
            EtxtMail.Text = string.Empty;
            Ephone.Text = string.Empty;
            EtxtTitle.Text = string.Empty;
            EtxtPosition.Text = string.Empty;
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

        private void EbtnSave_Click(object sender, EventArgs e) {
            string firstName = EtxtFirstName.Text;
            string lastName = EtxtLastName.Text;
            string email = EtxtMail.Text;
            string phone = Ephone.Text;
            string title = EtxtTitle.Text;
            string position = EtxtPosition.Text;
            int companyID = Convert.ToInt32(cmbCompany.SelectedValue);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(position)) {
                MessageBox.Show("Ad, soyad , görev ve ünvan boş olamaz.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text)) {
                if (!IsValidEmail(email)) {
                    MessageBox.Show("Yanlış e-mail formatı");
                    return;
                }
            }

            if (dbHelper.AddEmployee(firstName, lastName, companyID, email, phone, title, position)) {
                MessageBox.Show("Personel başarıyla eklendi");
                EclearForm();
                cmbCompany.SelectedValue = companyID;
                LoadEmployees(companyID);
            } else {
                MessageBox.Show("Personel eklenirken bir hata oluştu.");
            }
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbCompany.SelectedItem is DataRowView rowView) {
                int selectedCompanyId = Convert.ToInt32(rowView["companyID"]);
                LoadEmployees(selectedCompanyId); // Bu ID'ye göre çalışanları yükle
            }
        }

        private void LoadEmployees(int companyId) {
            DataTable employees = dbHelper.GetEmployees(companyId);
            listofEmployee.Items.Clear();

            foreach (DataRow row in employees.Rows) {
                int id = (int)row["EmployeeID"];
                string name = row["FullName"].ToString();
                listofEmployee.Items.Add(new Participant(id, name));
            }
        }

        private void EbtnUpdate_Click(object sender, EventArgs e) {
            // Seçili olan çalışanı al
            if (listofEmployee.SelectedItem is Participant selectedEmployee) {
                int selectedEmployeeID = selectedEmployee.ID;

                // UpdateEmployee formunu aç ve seçili olan EmployeeID'yi gönder
                UpdateEmployee updateEmployeeForm = new UpdateEmployee(dbHelper, userID);
                updateEmployeeForm.listofEmployee.SelectedValue = selectedEmployeeID;
                updateEmployeeForm.ShowDialog();
            } else {
                MessageBox.Show("Lütfen güncellemek istediğiniz çalışanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtCompanyName);
        }

        private void EtxtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(EtxtFirstName);
        }
    }
}
