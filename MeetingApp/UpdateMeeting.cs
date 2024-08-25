using MeetingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UpdateMeeting : Form
    {
        private DatabaseHelper dbHelper;
        private byte[] documentData;
        private int _selectedMeetingID;
        private int userID;
        public UpdateMeeting(DatabaseHelper databaseHelper , int userID) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.userID = userID;
            LoadCompanies();
            LoadUsers();
            LoadAcademics();
            LoadMeetingsIntoComboBox();
        }
        private void FilterMeetings(string searchText) {

            // Eğer arama metni boşsa veya arama sonucu yoksa verileri yeniden yükle
            if (string.IsNullOrEmpty(searchText) || listofMeetings.Items.Count == 0) {
                LoadMeetingsIntoComboBox(); // Verileri tekrar yükler
                return;
            }

            // Aksi halde, arama filtresi uygulamaya devam edin
            for (int i = listofMeetings.Items.Count - 1; i >= 0; i--) {
                var item = (KeyValuePair<int, string>)listofMeetings.Items[i];
                if (item.Value.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) < 0) {
                    listofMeetings.Items.RemoveAt(i);
                }

            }

            // Eğer öğeler tamamen silindiyse, verileri yeniden yükleyin
            if (listofMeetings.Items.Count == 0) {
                LoadMeetingsIntoComboBox();
            }

        }



        private void FilterCompanies(string searchText) {
            // Arama metnini küçük harfe çevirerek büyük/küçük harf farkını yok sayalım
            string searchLower = searchText.ToLower();

            // CheckedListBox'ı temizle ve filtrelenmiş verilerle yeniden yükle
            clbCompanies.Items.Clear();

            // Tüm şirketleri almak için bir metod çağırıyoruz
            DataTable companies = dbHelper.GetCompanies();

            foreach (DataRow row in companies.Rows) {
                int id = (int)row["CompanyID"];
                string name = row["Name"].ToString();

                // Şirket adı arama metnini içeriyorsa ekleyelim
                if (name.ToLower().Contains(searchLower)) {
                    clbCompanies.Items.Add(new Participant(id, name));
                }
            }
        }

        private void FilterAcademics(string searchText) {
            // Arama metnini küçük harfe çevirerek büyük/küçük harf farkını yok sayalım
            string searchLower = searchText.ToLower();

            // CheckedListBox'ı temizle ve filtrelenmiş verilerle yeniden yükle
            clbAcademics.Items.Clear();

            // Tüm akademik personeli almak için bir metod çağırıyoruz
            DataTable academics = dbHelper.GetAcademics();

            foreach (DataRow row in academics.Rows) {
                int id = (int)row["AcademicID"];
                string name = $"{row["FirstName"]} {row["LastName"]}";

                // Ad ve soyadı arama metnini içeriyorsa ekleyelim
                if (name.ToLower().Contains(searchLower)) {
                    clbAcademics.Items.Add(new Participant(id, name));
                }
            }
        }
        private void LoadMeetingsIntoComboBox() {
            DataTable meetings = dbHelper.GetAllMeetings();
            listofMeetings.Items.Clear(); // Önceki verileri temizle

            foreach (DataRow row in meetings.Rows) {
                int meetingID = (int)row["MeetingID"];
                string meetingTitle = row["MeetingTitle"].ToString();
                listofMeetings.Items.Add(new KeyValuePair<int, string>(meetingID, meetingTitle));
            }

            listofMeetings.DisplayMember = "Value"; // Gösterilecek metin: KeyValuePair'in Value kısmı
            listofMeetings.ValueMember = "Key"; // Seçilecek değer: KeyValuePair'in Key kısmı
        }


        private void LoadCompanies() {
            DataTable companies = dbHelper.GetCompanies();
            clbCompanies.Items.Clear(); // Önceki verileri temizle
            foreach (DataRow row in companies.Rows) {
                int id = (int)row["CompanyID"];
                string name = row["Name"].ToString();
                clbCompanies.Items.Add(new Participant(id, name));
            }
            if (dbHelper.IsAdmin(userID)) {
                btnDelMeeting.Enabled = true;
            }
        }

        private void LoadUsers() {
            DataTable users = dbHelper.GetUsers();
            clbUsers.Items.Clear(); // Önceki verileri temizle
            foreach (DataRow row in users.Rows) {
                int id = (int)row["userID"];
                string fullName = $"{row["firstName"]} {row["lastName"]}";
                clbUsers.Items.Add(new Participant(id, fullName));
            }
        }

        private void LoadAcademics() {
            DataTable academics = dbHelper.GetAcademics();
            clbAcademics.Items.Clear(); // Önceki verileri temizle
            foreach (DataRow row in academics.Rows) {
                int id = (int)row["AcademicID"];
                string name = $"{row["FirstName"]} {row["LastName"]}";
                clbAcademics.Items.Add(new Participant(id, name));
            }
        }


        private void LoadEmployees(int companyId) {
            DataTable employees = dbHelper.GetEmployees(companyId);
            clbEmployees.Items.Clear();

            foreach (DataRow row in employees.Rows) {
                int id = (int)row["EmployeeID"];
                string name = row["FullName"].ToString();
                clbEmployees.Items.Add(new Participant(id, name));
            }
        }
        private void UpdateMeetingParticipants() {
            // Toplantı ID'sini kullanarak katılımcıları güncelle
            dbHelper.UpdateMeetingParticipants(
                _selectedMeetingID,
                lbSelectedCompanies,
                lbSelectedEmployees,
                lbSelectedAcademics,
                lbSelectedUsers
            );
        }




        private void clbCompanies_SelectedIndexChanged(object sender, EventArgs e) {
            if (clbCompanies.SelectedItem != null) {
                // Seçilen öğe Participant türünde mi kontrol et
                if (clbCompanies.SelectedItem is Participant selectedCompany) {
                    int selectedCompanyId = selectedCompany.ID; // ID'yi al
                    LoadEmployees(selectedCompanyId); // Çalışanları yükle
                }
            }
        }


        private void btnAddCompanies_Click(object sender, EventArgs e) {
            foreach (Participant item in clbCompanies.CheckedItems) {
                if (!lbSelectedCompanies.Items.Cast<Participant>().Any(p => p.ID == item.ID)) {
                    lbSelectedCompanies.Items.Add(item);
                }
            }
        }

        private void btnAddUsers_Click(object sender, EventArgs e) {
            foreach (Participant item in clbUsers.CheckedItems) {
                if (!lbSelectedUsers.Items.Cast<Participant>().Any(p => p.ID == item.ID)) {
                    lbSelectedUsers.Items.Add(item);
                }
            }
        }

        private void btnAddAcademics_Click(object sender, EventArgs e) {
            foreach (Participant item in clbAcademics.CheckedItems) {
                if (!lbSelectedAcademics.Items.Cast<Participant>().Any(p => p.ID == item.ID)) {
                    lbSelectedAcademics.Items.Add(item);
                }
            }
        }

        private void btnAddEmployees_Click(object sender, EventArgs e) {
            foreach (var item in clbEmployees.CheckedItems) {
                // Seçilen öğenin DataRowView türünde olup olmadığını kontrol et
                if (item is DataRowView dataRowView) {
                    int employeeId = (int)dataRowView["EmployeeID"];
                    string fullName = dataRowView["FullName"].ToString();
                    var participant = new Participant(employeeId, fullName);

                    // Eğer participant henüz ListBox'ta yoksa ekle
                    if (!lbSelectedEmployees.Items.Cast<Participant>().Any(p => p.ID == participant.ID)) {
                        lbSelectedEmployees.Items.Add(participant);
                    }
                } else if (item is Participant participant) {
                    // Eğer öğe zaten Participant türündeyse doğrudan ekle
                    if (!lbSelectedEmployees.Items.Cast<Participant>().Any(p => p.ID == participant.ID)) {
                        lbSelectedEmployees.Items.Add(participant);
                    }
                }
            }
        }

        private void btnSaveMeeting_Click(object sender, EventArgs e) {
            try {
                // Boş alanlar için kontrolleri yap
                if (string.IsNullOrWhiteSpace(txtTitle.Text)) {
                    MessageBox.Show("Toplantı başlığı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtbNotes.Text)) {
                    MessageBox.Show("Toplantı notları boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLocation.Text)) {
                    MessageBox.Show("Toplantı yeri boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (lbSelectedUsers.Items.Count == 0) {
                    MessageBox.Show("En az bir kullanıcı seçilmelidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Toplantı bilgilerini ayarla
                var meeting = new Meeting {
                    MeetingID = _selectedMeetingID,
                    Date = dtpDate.Value.Date,
                    Time = TimeSpan.Parse(dtpTime.Text),
                    Title = txtTitle.Text,
                    Notes = rtbNotes.Text,
                    Location = txtLocation.Text
                };

                // Toplantıyı güncelle
                dbHelper.UpdateMeeting(meeting);

                // Toplantı Katılımcılarını güncelle
                UpdateMeetingParticipants();

                // Toplantıya dosyayı ekle (eğer varsa)
                if (documentData != null) {
                    dbHelper.AddMeetingDocument(_selectedMeetingID, documentData);
                }

                // Bilgilendirme mesajı
                MessageBox.Show("Toplantı başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Formu temizle
                ClearForm();
            } catch (Exception ex) {
                // Hata durumunda bilgilendirme mesajı
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelMeeting_Click(object sender, EventArgs e) {
            if (_selectedMeetingID == null || _selectedMeetingID <= 0) {
                MessageBox.Show("Lütfen silmek için geçerli bir toplantı seçin.", "Geçersiz Seçim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bu toplantıyı silmek istediğinizden emin misiniz?", "Toplantı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                bool isDeleted = dbHelper.DeleteMeeting(_selectedMeetingID);

                if (isDeleted) {
                    MessageBox.Show("Toplantı başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMeetingsIntoComboBox();
                } else {
                    MessageBox.Show("Toplantı silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearForm() {
            // TextBox'ları temizle
            txtTitle.Text = string.Empty;
            rtbNotes.Text = string.Empty;
            txtLocation.Text = string.Empty;

            // DateTimePicker'ları varsayılan tarihe ayarla
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now; // Zamanı varsayılan olarak şimdiki zaman yap

            // ListBox'ları temizle
            lbSelectedCompanies.Items.Clear();
            lbSelectedUsers.Items.Clear();
            lbSelectedAcademics.Items.Clear();
            lbSelectedEmployees.Items.Clear();
            documentData = null;
            nameDocument.Text = string.Empty;
        }

        private void addDocument_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported Files|*.docx;*.pdf;*.xlsx;*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = openFileDialog.FileName;
                FileInfo fileInfo = new FileInfo(filePath);

                // 10 MB sınırı (10 MB = 10 * 1024 * 1024 bytes)
                long maxFileSize = 10 * 1024 * 1024;
                if (fileInfo.Length > maxFileSize) {
                    MessageBox.Show("Dosya boyutu 10 MB'ı geçemez.");
                    return;
                }

                // Dosya içeriklerini byte dizisi olarak oku
                documentData = File.ReadAllBytes(filePath);
                nameDocument.Text = fileInfo.Name;
            }
        }

        private void clrCom_Click(object sender, EventArgs e) {
            // Şirket listesi için seçili öğeleri temizle
            while (lbSelectedCompanies.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedCompanies.SelectedItems[0];
                lbSelectedCompanies.Items.Remove(selectedParticipant);
            }
        }

        private void clrEmp_Click(object sender, EventArgs e) {
            // Çalışan listesi için seçili öğeleri temizle
            while (lbSelectedEmployees.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedEmployees.SelectedItems[0];
                lbSelectedEmployees.Items.Remove(selectedParticipant);
            }
        }

        private void clrAca_Click(object sender, EventArgs e) {
            // Akademik listesi için seçili öğeleri temizle
            while (lbSelectedAcademics.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedAcademics.SelectedItems[0];
                lbSelectedAcademics.Items.Remove(selectedParticipant);
            }
        }

        private void clrUser_Click(object sender, EventArgs e) {
            // Kullanıcı listesi için seçili öğeleri temizle
            while (lbSelectedUsers.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedUsers.SelectedItems[0];
                lbSelectedUsers.Items.Remove(selectedParticipant);
            }
        }


        private void deleteFile_Click(object sender, EventArgs e) {
            documentData = null;
            nameDocument.Text = string.Empty;
        }

        private void listofMeetings_SelectedIndexChanged(object sender, EventArgs e) {
            if (listofMeetings.SelectedItem != null) {
                var selectedMeeting = (KeyValuePair<int, string>)listofMeetings.SelectedItem;
                _selectedMeetingID = selectedMeeting.Key;  // ID'yi sakla

                // Katılımcıları ve diğer bilgileri yükle
                dbHelper.LoadParticipants(_selectedMeetingID, lbSelectedCompanies, lbSelectedEmployees, lbSelectedAcademics, lbSelectedUsers);
                DataRow meetingData = dbHelper.GetMeetingById(_selectedMeetingID);

                if (meetingData != null) {
                    // Toplantı tarihini ve saatini ayarla
                    listofMeetings.Text = Convert.ToDateTime(meetingData["MeetingDate"]).ToString("dd.MM.yyyy");
                    TimeSpan meetingTime = (TimeSpan)meetingData["MeetingTime"];
                    dtpTime.Text = meetingTime.ToString(@"hh\:mm");

                    // Toplantı başlığını, notlarını ve diğer bilgileri ayarla
                    txtTitle.Text = meetingData["MeetingTitle"].ToString();
                    rtbNotes.Text = meetingData["MeetingNotes"].ToString();
                    txtLocation.Text = meetingData["MeetingLocation"].ToString();
                }
            }
        }

        private void viewDocument_Click(object sender, EventArgs e) {
            dbHelper.ViewDocument(_selectedMeetingID);
        }

        private void searchCompany_TextChanged(object sender, EventArgs e) {
            FilterCompanies(searchCompany.Text);
        }

        private void searchAcedemic_TextChanged(object sender, EventArgs e) {
            FilterAcademics(searchAcedemic.Text);
        }

        private void txtMeetingSearch_TextChanged(object sender, EventArgs e) {
            string searchText = txtMeetingSearch.Text;
            FilterMeetings(searchText);
        }

        private void txtMeetingSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Tab) {
                e.IsInputKey = true; // Varsayılan tab olayını durdur
                if (listofMeetings.Items.Count > 0) {
                    listofMeetings.SelectedIndex = 0; // İlk öğeyi seç
                    var selectedMeeting = (KeyValuePair<int, string>)listofMeetings.SelectedItem;
                    listofMeetings.Text = selectedMeeting.Value; // Seçilen öğenin başlığını ComboBox'ta göster
                    txtMeetingSearch.Text = selectedMeeting.Value;
                    txtMeetingSearch.ForeColor = Color.Gray; // Silik renk
                    txtTitle.Focus();
                }
            }
        }

        private void txtMeetingSearch_Enter(object sender, EventArgs e) {
            if (txtMeetingSearch.ForeColor == Color.Gray) {
                txtMeetingSearch.Clear();
                txtMeetingSearch.ForeColor = Color.Black; // Normal metin rengi
            }
        }

       
    }
}
