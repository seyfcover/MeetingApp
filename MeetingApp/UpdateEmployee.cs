using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateEmployee : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        public UpdateEmployee(DatabaseHelper dbHelper, int userID) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            LoadCompanies();
            LoadEmployees();
           
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
            if (dbHelper.IsAdmin(userID)) {
                btnDel.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
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
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(position)) {
                MessageBox.Show("Ad, soyad, ünvan ve görev eksik olamaz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dbHelper.UpdateEmployee(selectedEmployeeID, firstName, lastName, companyID, email, phone, title, position)) {
                MessageBox.Show("Çalışan başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {
                MessageBox.Show("Çalışan güncellenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Güncellenmiş listeyi yeniden yükleyin veya arayüzü güncelleyin
                    LoadEmployees();
                } else {
                    MessageBox.Show("Çalışan silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtFirstName);
        }
    }
}
