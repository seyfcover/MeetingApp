using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace MeetingApp
{
    public partial class AcademicForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;

        public AcademicForm(DatabaseHelper dbHelper, int userID) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string title = txtTitle.Text;
            string position = txtPosition.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(position)) {
                MessageBox.Show("Tüm alanlar gereklidir.");
                return;
            }

            if (!IsValidEmail(email)) {
                MessageBox.Show("Email formatı yanlış.");
                return;
            }

            if (dbHelper.AddAcademic(firstName, lastName, email, phone, title, position)) {
                MessageBox.Show("Akademisyen Eklendi.");
                this.Close();
            } else {
                MessageBox.Show("Akademisyen eklenirken hata oluştu.");
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

        private void txtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtFirstName);
        }
    }
}
