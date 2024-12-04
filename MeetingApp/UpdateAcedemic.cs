using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateAcedemic : Form
    {
        private DatabaseHelper dbHelper;
        private int selectedAcedemicID;
        private int userID; // Sınıf seviyesinde tanımlama
        private string FullName;

        public UpdateAcedemic(DatabaseHelper dbHelper, int userID , string FullName) {
            InitializeComponent();
            this.userID = userID;
            this.dbHelper = dbHelper;
            this.FullName = FullName;
            LoadAcademics();
        }
         
        private void LoadAcademics() {
            DataTable academics = dbHelper.GetAcademics();

            // FullName sütunu ekleyelim
            academics.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");
            listofAcedemics.DataSource = academics;
            listofAcedemics.DisplayMember = "FullName";
            listofAcedemics.ValueMember = "AcademicID";

            if (dbHelper.IsAdmin(userID) == false) {
                btndel.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string title = txtTitle.Text;
            string position = txtPosition.Text;
            string keyWords = txtFieldsOfActivity.Text;
            string tcId = textmaskedtcid.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) 
                || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(keyWords)) {
                MessageBox.Show("Tüm alanlar gereklidir.");
                return;
            }

            if (!IsValidEmail(email)) {
                MessageBox.Show("Email formatı yanlış.");
                return;
            }

            if (selectedAcedemicID == 0) {
                MessageBox.Show("Lütfen güncellemek için bir akademisyen seçin.");
                return;
            }

            if (dbHelper.UpdateAcademic(selectedAcedemicID, firstName, lastName, email, phone, title, position, keyWords , tcId)) {
                MessageBox.Show("Akademisyen Güncellendi.");

                dbHelper.AddLog("Güncelleme", "ID:" + userID.ToString() + " " + FullName + " || Akademisyen : " + firstName + " " + lastName + " Güncelledi. ");
                this.Close();
            } else {
                MessageBox.Show("Akademisyen güncellenirken bir hata oluştu.");
                dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Akademisyen : " + firstName + " " + lastName + " Güncellenirken Hata OLuştu. ");
            }
        }

        private void btndel_Click(object sender, EventArgs e) {
            bool isDeleted = dbHelper.DeleteAcademic(selectedAcedemicID);
            if (isDeleted) {
                MessageBox.Show("Akademisyen başarıyla silindi.");
                dbHelper.AddLog("Silme", "ID:" + userID.ToString() + " " + FullName + " || Akademisyen : " + txtFirstName.Text + " " + txtFirstName.Text + " Silindi. ");
                this.Close();
            } else {
                MessageBox.Show("Akademisyen silinirken bir hata oluştu.");
                dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Akademisyen : " + txtFirstName.Text + " " + txtFirstName.Text + " Silinirken Hata Oluştu. ");
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

        private void listofAcedemics_SelectedIndexChanged(object sender, EventArgs e) {
            if (listofAcedemics.SelectedValue != null && int.TryParse(listofAcedemics.SelectedValue.ToString(), out int selectedID)) {
                selectedAcedemicID = selectedID;

                // Get the academic details based on AcademicID
                DataTable academicDetails = dbHelper.GetDetailsAcademics(selectedAcedemicID);

                if (academicDetails != null && academicDetails.Rows.Count > 0) {
                    DataRow row = academicDetails.Rows[0];

                    // Display the details in the appropriate controls
                    txtFirstName.Text = row["FirstName"].ToString();
                    txtLastName.Text = row["LastName"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtPhone.Text = row["Phone"].ToString();
                    txtTitle.Text = row["Title"].ToString();
                    txtPosition.Text = row["Position"].ToString();
                    txtFieldsOfActivity.Text = row["keyWords"].ToString();
                    textmaskedtcid.Text = row["tcID"].ToString();
                } else {
                    // Handle the case where no details are found
                    MessageBox.Show("Seçilen akademisyenin detayları bulunamadı.");
                }
            } else {
                // Handle the case where selection is invalid or no item is selected
                selectedAcedemicID = 0;
                ClearFields();
            }
        }

        private void ClearFields() {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPosition.Clear();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtFirstName);
        }
    }
}
