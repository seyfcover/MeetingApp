using System.Text.RegularExpressions;
using System.Windows.Forms;
using System;

namespace MeetingApp
{
    public partial class AcademicForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;
        public AcademicForm(DatabaseHelper dbHelper, int userID, string FullName) {
            InitializeComponent();
            this.FullName = FullName;
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
            string keyWords = txtFieldsOfActivity.Text;
            string tcId = txtmaskedtcid.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) {
                MessageBox.Show("Ad ve soyad zorunlu.");
                return;
            }

            string emptyMask = "(   )    -"; // MaskedTextBox boşken görünen format

            if (phone == emptyMask) {
                // Boş veya eksik bilgi varsa null olarak değerlendir
                phone = string.Empty;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text)) {
                if (!IsValidEmail(email)) {
                    MessageBox.Show("Yanlış e-mail formatı");
                    return;
                }
            }

            if (dbHelper.AddAcademic(firstName, lastName, email, phone, title, position , keyWords , tcId)) {
                MessageBox.Show("Akademisyen Eklendi.");
                dbHelper.AddLog("Ekleme", "ID:" + userID.ToString() + " " + FullName + " || Akademisyen : " + firstName + " " + lastName + " ekledi ");
                ClearForm();
            } else {
                MessageBox.Show("Akademisyen eklenirken hata oluştu.");
                dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Akademisyen : " + firstName + " " + lastName + " Eklerken Hata oluştu.");
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

        private void ClearForm() { 
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtTitle.Text = string.Empty;   
        }

    }
}
