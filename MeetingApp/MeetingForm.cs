using MeetingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class MeetingForm : Form
    {
        private DatabaseHelper dbHelper;
        // Dosya isimlerini ve türlerini tutacak listeler
        private List<byte[]> documentDataList = new List<byte[]>(); // Dosya içerikleri
        private List<string> documentNamesList = new List<string>(); // Dosya adları
        private List<string> documentTypesList = new List<string>(); // Dosya türleri
        private int userID;
        public MeetingForm(DatabaseHelper dbHelper, int userID) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            LoadCompanies();
            LoadUsers();
            LoadAcademics();
            this.userID = userID;   
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


        private void LoadCompanies() {
            DataTable companies = dbHelper.GetCompanies();
            clbCompanies.Items.Clear(); // Önceki verileri temizle
            foreach (DataRow row in companies.Rows) {
                int id = (int)row["CompanyID"];
                string name = row["Name"].ToString();
                clbCompanies.Items.Add(new Participant(id, name));
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
                if (MeetingType.SelectedItem == null) {
                    MessageBox.Show("Faaliyet türü boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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

                // Toplantı bilgilerini oluştur
                var meeting = new Meeting {
                    Date = dtpDate.Value,
                    Time = dtpTime.Value.TimeOfDay,
                    Title = txtTitle.Text,
                    Notes = rtbNotes.Text,
                    Location = txtLocation.Text,
                    MeetingType = MeetingType.Text,
                    isImportant = isImportant.Checked
                };

                // Toplantıyı veritabanına ekle ve ID'sini al
                int meetingId = dbHelper.AddMeeting(meeting);

                // Toplantı katılımcılarını ekle
                AddParticipantsToMeeting(meetingId, lbSelectedCompanies.Items, "Company");
                AddParticipantsToMeeting(meetingId, lbSelectedUsers.Items, "User");
                AddParticipantsToMeeting(meetingId, lbSelectedAcademics.Items, "Academic");
                AddParticipantsToMeeting(meetingId, lbSelectedEmployees.Items, "Employee");

                //Toplantıya dosyayaı ekle
                dbHelper.AddMeetingDocuments(meetingId, documentDataList, documentNamesList, documentTypesList);
                // Bilgilendirme mesajı
                MessageBox.Show("Toplantı başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            } catch (Exception ex) {
                // Hata durumunda bilgilendirme mesajı
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddParticipantsToMeeting(int meetingId, ListBox.ObjectCollection participants, string participantType) {
            foreach (Participant participant in participants) {
                dbHelper.AddMeetingParticipant(meetingId, participantType, participant.ID);
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
            documentDataList?.Clear();
            documentNamesList?.Clear();
            documentTypesList?.Clear();
            nameDocument.Text = string.Empty;
        }

        private void addDocument_Click(object sender, EventArgs e) {
            // Listeleri temizle
            documentDataList?.Clear();
            documentNamesList?.Clear();
            documentTypesList?.Clear();
            nameDocument.Text = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Birden fazla dosya seçilmesine izin verir
            openFileDialog.Filter = "Supported Files|*.docx;*.pdf;*.xlsx;*.jpg;*.png"; // Desteklenen dosya türleri

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // Seçilen dosya sayısını kontrol et
                if (openFileDialog.FileNames.Length > 3) {
                    MessageBox.Show("En fazla 3 dosya seçebilirsiniz.");
                    return; // Fazla dosya seçildiyse işlemi iptal et
                }

                List<string> selectedFileNames = new List<string>(); // Seçilen dosya isimlerini tutacak liste

                foreach (string filePath in openFileDialog.FileNames) {
                    FileInfo fileInfo = new FileInfo(filePath);

                    // 3 MB sınırı (3 MB = 3 * 1024 * 1024 bytes)
                    long maxFileSize = 3 * 1024 * 1024;
                    if (fileInfo.Length > maxFileSize) {
                        MessageBox.Show($"Dosya '{fileInfo.Name}' boyutu 3 MB'ı geçemez.");
                        continue; // Dosya boyutu sınırı aşıldıysa döngüye devam et
                    }

                    // Dosya içeriklerini byte dizisi olarak oku ve listeye ekle
                    byte[] documentData = File.ReadAllBytes(filePath);
                    documentDataList.Add(documentData); // Byte dizisini listeye ekle

                    // Dosya adını ekle
                    documentNamesList.Add(fileInfo.Name);

                    // Dosya türünü al ve ekle
                    string documentType = GetDocumentType(fileInfo.Extension);
                    documentTypesList.Add(documentType);

                    // Dosya adını ve türünü listelere ekle
                    selectedFileNames.Add($"{fileInfo.Name} ({documentType})");
                }

                // Seçilen dosya isimlerini `nameDocument.Text` içinde göster
                nameDocument.Text = string.Join(", ", selectedFileNames);
            }
        }



        private string GetDocumentType(string extension) {
            switch (extension.ToLower()) {
                case ".docx":
                    return "Word Document";
                case ".pdf":
                    return "PDF Document";
                case ".xlsx":
                    return "Excel Spreadsheet";
                case ".jpg":
                case ".jpeg":
                    return "JPEG Image";
                case ".png":
                    return "PNG Image";
                default:
                    return "Unknown";
            }
        }



        private void clrCom_Click(object sender, EventArgs e) {
            lbSelectedCompanies.Items.Clear();
        }

        private void clrEmp_Click(object sender, EventArgs e) {
            lbSelectedEmployees.Items.Clear();
        }

        private void clrAca_Click(object sender, EventArgs e) {
            lbSelectedAcademics.Items.Clear();
        }

        private void clrUser_Click(object sender, EventArgs e) {
            lbSelectedUsers.Items.Clear();
        }

        private void deleteFile_Click(object sender, EventArgs e) {
            documentDataList?.Clear();
            documentNamesList?.Clear();
            documentTypesList?.Clear();
            nameDocument.Text = string.Empty;
        }

        private void searchCompany_TextChanged(object sender, EventArgs e) {
            // Arama terimini al
            FilterCompanies(searchCompany.Text);
        }

        private void searchAcedemic_TextChanged(object sender, EventArgs e) {
            FilterAcademics(searchAcedemic.Text);
        }

        private void txtLocation_TextChanged(object sender, EventArgs e) {
            dbHelper.CastingName(txtLocation);
        }
    }
}