using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateEmployee : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;
        public UpdateEmployee(DatabaseHelper dbHelper, int userID, string FullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.FullName = FullName;
            LoadCompanies();
            LoadEmployees();
            Permissions(userID);
        }

        private void Permissions(int userID) {
            byte isAdmin = dbHelper.isAdmin(userID);
            if (isAdmin == 4 || isAdmin == 3) {
                btnDel.Enabled = true;
                btnDel.Visible = true;
            }
        }
        private void LoadCompanies() {
            DataTable companies = dbHelper.GetCompanies();
            cmbCompany.DataSource = companies;
            cmbCompany.DisplayMember = "name";
            cmbCompany.ValueMember = "companyID";
        }

        private void LoadEmployees() {
            DataTable emplooyes = dbHelper.GetListEmployees();
            listofEmployee.DataSource = emplooyes;
            listofEmployee.DisplayMember = "Fullname";
            listofEmployee.ValueMember = "EmployeeID";
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string tcID = EmployeeTcID.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string title = txtTitle.Text;
            string position = txtPosition.Text;

            if (cmbCompany.SelectedValue == null) {
                MessageBox.Show("Lütfen bir şirket seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int companyID = Convert.ToInt32(cmbCompany.SelectedValue);

            string emptyMask = "(   )    -"; // MaskedTextBox boşken görünen format

            if (phone == emptyMask) {
                // Boş veya eksik bilgi varsa null olarak değerlendir
                phone = string.Empty;
            }


            // Boş alanları kontrol et
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(tcID)) {
                MessageBox.Show("Ad, soyad, ünvan , görev ve TC eksik olamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text)) {
                if (!IsValidEmail(email)) {
                    MessageBox.Show("Yanlış e-mail formatı");
                    return;
                }
            }

            if (listofEmployee.SelectedValue == null) {
                MessageBox.Show("Lütfen bir çalışan seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedEmployeeID = Convert.ToInt32(listofEmployee.SelectedValue);

            // Çalışanı güncelle
            if (dbHelper.UpdateEmployee(selectedEmployeeID, firstName, tcID, lastName, companyID, email, phone, title, position)) {
                MessageBox.Show("Çalışan başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbHelper.AddLog("Güncelleme", "ID:" + userID.ToString() + " " + FullName + " || Şirket Personeli : " + firstName + " " + lastName + " Güncellendi. ");
                this.Close();
            } else {
                MessageBox.Show("Çalışan güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Şirket Personeli : " + firstName + " " + lastName + " Güncellenirken Hata Oluştu. ");
            }
        }


        private bool IsValidEmail(string email) {
            try {
                // Define a regular expression for validating email addresses
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(email);
            } catch (Exception) {
                return false;
            }
        }

        public void listofEmployee_SelectedIndexChanged(object sender, EventArgs e) {
            // Ensure that SelectedValue is not null and can be cast to int
            if (listofEmployee.SelectedValue != null && int.TryParse(listofEmployee.SelectedValue.ToString(), out int selectedEmployeeID)) {

                // Get the employee details based on EmployeeID
                DataTable employeeDetails = dbHelper.GetDetailsEmployee(selectedEmployeeID);

                if (employeeDetails.Rows.Count > 0) {
                    DataRow row = employeeDetails.Rows[0];

                    // Display the details in the appropriate controls
                    txtFirstName.Text = row["FirstName"].ToString();
                    txtLastName.Text = row["LastName"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtPhone.Text = row["Phone"].ToString();
                    txtTitle.Text = row["Title"].ToString();
                    txtPosition.Text = row["Position"].ToString();
                    EmployeeTcID.Text = row["EmployeeTcID"].ToString();

                    // Set the selected company in the ComboBox
                    cmbCompany.SelectedValue = row["CompanyID"];
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e) {
            if (listofEmployee.SelectedValue == null) {
                MessageBox.Show("Lütfen silmek için bir çalışan seçin.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedEmployeeID = Convert.ToInt32(listofEmployee.SelectedValue);

            // Kullanıcıdan silme işlemi için onay al
            DialogResult result = MessageBox.Show("Bu çalışanı silmek istediğinizden emin misiniz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                // Çalışanı sil
                if (dbHelper.DeleteEmployee(selectedEmployeeID)) {
                    MessageBox.Show("Çalışan başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbHelper.AddLog("Silme", FullName + " " + txtFirstName.Text + " " + txtLastName.Text + " Çalışanını sildi");
                    // Güncellenmiş listeyi yeniden yükleyin veya arayüzü güncelleyin
                    LoadEmployees();
                } else {
                    MessageBox.Show("Çalışan silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dbHelper.AddLog("Hata", FullName + " " + txtFirstName.Text + " " + txtLastName.Text + " Çalışanını silerken hata oluştu");
                }
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtFirstName);
        }

        private void EmployeeTcID_TextChanged(object sender, EventArgs e) {
            // TextBox kontrolünü al
            if (EmployeeTcID != null) {
                // Sadece rakamları içeren bir değer oluştur
                string newText = string.Concat(EmployeeTcID.Text.Where(char.IsDigit));

                // TextBox içeriği değiştiyse güncelle
                if (EmployeeTcID.Text != newText) {
                    int selectionStart = EmployeeTcID.SelectionStart - (EmployeeTcID.Text.Length - newText.Length);
                    EmployeeTcID.Text = newText;
                    EmployeeTcID.SelectionStart = Math.Max(selectionStart, 0); // İmleç pozisyonunu koru
                }
            }
        }
    }
}
