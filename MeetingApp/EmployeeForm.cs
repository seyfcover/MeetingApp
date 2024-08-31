using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class EmployeeForm : Form
    {
        private DatabaseHelper dbHelper;

        public EmployeeForm(DatabaseHelper dbHelper) {
            InitializeComponent();
            this.dbHelper = dbHelper;
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
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string title = txtTitle.Text;
            string position = txtPosition.Text;
            int companyID = Convert.ToInt32(cmbCompany.SelectedValue);

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(position)) {
                MessageBox.Show("Ad, soyad , görev ve ünvan boş olamaz.");
                return;
            }
            if (txtEmail.Text != null) {
                if (!IsValidEmail(email)) {
                    MessageBox.Show("Yanlış e-mail formatı");
                    return;
                }
            }
            
            if (dbHelper.AddEmployee(firstName, lastName, companyID, email, phone, title, position)) {
                MessageBox.Show("Personel başarıyla eklendi");
                clearForm();
            } else {
                MessageBox.Show("Personel eklenirken bir hata oluştu.");
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

        private void clearForm() { 
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;    
            txtPhone.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtTitle.Text = string.Empty;
        }
    }
}
