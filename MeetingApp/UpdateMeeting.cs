using MeetingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace MeetingApp
{
    public partial class UpdateMeeting : Form
    {
        private DatabaseHelper dbHelper;
        private List<byte[]> documentDataList = new List<byte[]>(); // Dosya içerikleri
        private List<string> documentNamesList = new List<string>(); // Dosya adları
        private List<string> documentTypesList = new List<string>();
        public int _selectedMeetingID ;
        private int userID;
        private string FullName;
        public UpdateMeeting(DatabaseHelper databaseHelper, int userID,string FullName ) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.userID = userID;
            this.FullName = FullName;
            LoadCompanies();
            LoadUsers();
            LoadAcademics();
            LoadMeetingsIntoComboBox();
            Permissions(userID);
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
                DateTime meetingDate = (DateTime)row["MeetingDate"];

                // Tarih olmadan sadece başlık ekleniyor, ancak tarihler arka planda tutuluyor
                listofMeetings.Items.Add(new KeyValuePair<int, string>(meetingID, meetingTitle));
            }

            listofMeetings.DisplayMember = "Value"; // Yalnızca toplantı başlığını göster
            listofMeetings.ValueMember = "Key"; // Seçilecek değer: meetingID
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
        private void Permissions(int userID) {
            byte isAdmin = dbHelper.isAdmin(userID);
            if (isAdmin == 4 || isAdmin == 3) {
                btnDelMeeting.Enabled=true;
                btnDelMeeting.Visible=true;
                deleteFile.Enabled=true;
                deleteFile.Visible=true;
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
                if (_selectedMeetingID <= 0) {
                    MessageBox.Show($"Faaliyet seçmediniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MeetingType.SelectedItem == null) {
                    MessageBox.Show("Faaliyet türü boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Boş alanlar için kontrolleri yap
                if (string.IsNullOrWhiteSpace(txtTitle.Text)) {
                    MessageBox.Show("Faaliyet başlığı boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtbNotes.Text)) {
                    MessageBox.Show("Faaliyet notları boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLocation.Text)) {
                    MessageBox.Show("Faaliyet yeri boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Location = txtLocation.Text,
                    MeetingType = MeetingType.Text,
                    isImportant = isImportant.Checked
                };

                // Toplantıyı güncelle
                dbHelper.UpdateMeeting(meeting);

                // Toplantı Katılımcılarını güncelle
                UpdateMeetingParticipants();

                // Toplantıya dosyayı ekle (eğer varsa)
                if (documentDataList != null) {
                    dbHelper.UpdateMeetingDocuments(_selectedMeetingID, documentDataList, documentNamesList, documentTypesList);
                }

                // Bilgilendirme mesajı
                MessageBox.Show("Faaliyet başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbHelper.AddLog("Güncelleme", "ID:" + userID.ToString() + " " + FullName + " || Faaliyet : " + txtTitle.Text + " Başlıklı Faaliyet Güncellendi. ");
                // Formu temizle
                ClearForm();
                LoadMeetingsIntoComboBox();

            } catch (Exception ex) {
                // Hata durumunda bilgilendirme mesajı
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Faaliyet : " + txtTitle.Text + " Başlıklı Faaliyet Güncellenirken Hata Oluştu. "+ ex.Message);
            }
        }

        private void btnDelMeeting_Click(object sender, EventArgs e) {
            if (_selectedMeetingID > 0) {
                DialogResult result = MessageBox.Show("Bu faaliyeti silmek istediğinizden emin misiniz?", "Faaliyet Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes) {
                    bool isDeleted = dbHelper.DeleteMeeting(_selectedMeetingID);

                    if (isDeleted) {
                        MessageBox.Show("Faaliyet başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbHelper.AddLog("Silme", "ID:" + userID.ToString() + " " + FullName + " || Faaliyet : " + txtTitle.Text + " Başlıklı Faaliyet Silindi. ");
                        ClearForm();
                        LoadMeetingsIntoComboBox();

                    } else {
                        MessageBox.Show("Faaliyet silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.AddLog("Hata", "ID:" + userID.ToString() + " " + FullName + " || Faaliyet : " + txtTitle.Text + " Başlıklı Faaliyet Silinirken Hata Oluştu. ");
                    }
                }
            } else {
                MessageBox.Show("Lütfen silmek için geçerli bir toplantı seçin.", "Geçersiz Seçim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            listofMeetings.SelectedItem = null;
            _selectedMeetingID = 0;
        }

        private void addDocument_Click(object sender, EventArgs e) {
            documentDataList?.Clear();
            documentNamesList?.Clear();
            documentTypesList?.Clear();
            nameDocument.Text = string.Empty;

            int currentDocumentCount = 0;

            // Veritabanında mevcut olan dosya sayısını al
            currentDocumentCount = dbHelper.GetDocumentCountForMeeting(_selectedMeetingID);

            if (currentDocumentCount >= 3) {
                MessageBox.Show("Maksimum 3 dosya yüklenebilir. Zaten 3 dosya mevcut.");
                return; // Mevcut dosya sayısı 3 veya daha fazla ise işlem iptal edilir.
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Birden fazla dosya seçilmesine izin verir
            openFileDialog.Filter = "Supported Files|*.docx;*.pdf;*.xlsx;*.jpg;*.png;*.jpeg"; ; // Desteklenen dosya türleri

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                List<string> selectedFileNames = new List<string>(); // Seçilen dosya isimlerini tutacak liste

                // Kullanıcının seçtiği dosya sayısı + veritabanındaki mevcut dosya sayısı toplamı 3'ü geçmemeli
                if (openFileDialog.FileNames.Length + currentDocumentCount > 3) {
                    MessageBox.Show($"Maksimum 3 dosya yükleyebilirsiniz. Zaten {currentDocumentCount} dosya mevcut.");
                    return;
                }

                foreach (string filePath in openFileDialog.FileNames) // Seçilen her dosya için döngü
                {
                    FileInfo fileInfo = new FileInfo(filePath);

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


        private string GetDocumentType(string fileExtension) {
            switch (fileExtension.ToLower()) {
                case ".docx":
                    return "Word Document";
                case ".pdf":
                    return "PDF Document";
                case ".xlsx":
                    return "Excel Document";
                case ".jpg":
                    return "JPG Image";
                case ".jpeg":
                    return "JPEG Image";
                case ".png":
                    return "PNG Image";
                default:
                    return "Unknown";
            }
        }

        private void clrCompanySolo_Click(object sender, EventArgs e) {
            while (lbSelectedCompanies.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedCompanies.SelectedItems[0];
                lbSelectedCompanies.Items.Remove(selectedParticipant);
            }
        }

        private void clrEmployeeSolo_Click(object sender, EventArgs e) {
            while (lbSelectedEmployees.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedEmployees.SelectedItems[0];
                lbSelectedEmployees.Items.Remove(selectedParticipant);
            }
        }

        private void clrAcedemicSolo_Click(object sender, EventArgs e) {
            while (lbSelectedAcademics.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedAcademics.SelectedItems[0];
                lbSelectedAcademics.Items.Remove(selectedParticipant);
            }
        }

        private void clrUserSolo_Click(object sender, EventArgs e) {
            while (lbSelectedUsers.SelectedItems.Count > 0) {
                Participant selectedParticipant = (Participant)lbSelectedUsers.SelectedItems[0];
                lbSelectedUsers.Items.Remove(selectedParticipant);
            }
        }



        private void SclrCom_Click(object sender, EventArgs e) {
            lbSelectedCompanies.Items.Clear();
        }

        private void SclrEmp_Click(object sender, EventArgs e) {
            lbSelectedEmployees.Items.Clear();
        }

        private void SclrAca_Click(object sender, EventArgs e) {
            lbSelectedAcademics.Items.Clear();
        }

        private void SclrUser_Click(object sender, EventArgs e) {
            lbSelectedUsers.Items.Clear();
        }

        private void deleteFile_Click(object sender, EventArgs e) {
            // Document listelerini temizle
            documentDataList?.Clear();
            documentNamesList?.Clear();
            documentTypesList?.Clear();

            // UI elementlerini temizle
            nameDocument.Text = string.Empty;
            DialogResult result = MessageBox.Show("Bu faaliyet belgelerini silmek istediğinizden emin misiniz?", "Faaliyet Belgeleri Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) {
                // Toplantı ID'si kontrolü
                if (_selectedMeetingID > 0) {
                    try {
                        // Veritabanından ilgili dosyaları sil
                        dbHelper.DeleteMeetingDocuments(_selectedMeetingID);
                        MessageBox.Show("İlgili dosyalar başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dbHelper.AddLog("Silme", "ID: " + userID.ToString() + " " + FullName + " " + txtTitle.Text + " Başlıklı Faaliyetin dosyalarını sildi.");
                    } catch (Exception ex) {
                        MessageBox.Show($"Dosyalar silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dbHelper.AddLog("Hata", "ID: " + userID.ToString() + " " + FullName + " " + txtTitle.Text + " Başlıklı Faaliyetin dosyalarını silerken hata oluştu.");
                    }
                } else {
                    MessageBox.Show("Silinecek dökuman bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        public void listofMeetings_SelectedIndexChanged(object sender, EventArgs e) {
            if ((sender == null) &&( e == null)) {
                forceloadcalendar(_selectedMeetingID);
            }
            if (listofMeetings.SelectedItem != null) {
                var selectedMeeting = (KeyValuePair<int, string>)listofMeetings.SelectedItem;
                _selectedMeetingID = selectedMeeting.Key;  // ID'yi sakla
                forceloadcalendar(_selectedMeetingID);
            }
        }

        public void forceloadcalendar(int selectedmeetingID) {
            // Katılımcıları ve diğer bilgileri yükle
            dbHelper.LoadParticipants(_selectedMeetingID, lbSelectedCompanies, lbSelectedEmployees, lbSelectedAcademics, lbSelectedUsers);
            DataRow meetingData = dbHelper.GetMeetingById(_selectedMeetingID);

            if (meetingData != null) {
                // Toplantı tarihini ve saatini ayarla
                listofMeetings.Text = meetingData["MeetingTitle"].ToString();
                dtpDate.Text = Convert.ToDateTime(meetingData["MeetingDate"]).ToString("dd.MM.yyyy");
                TimeSpan meetingTime = (TimeSpan)meetingData["MeetingTime"];
                dtpTime.Text = meetingTime.ToString(@"hh\:mm");
                isImportant.Checked = meetingData["isImportant"] != DBNull.Value && Convert.ToBoolean(meetingData["isImportant"]);
                MeetingType.Text = meetingData["MeetingType"] != DBNull.Value ? meetingData["MeetingType"].ToString() : string.Empty;
                // Toplantı başlığını, notlarını ve diğer bilgileri ayarla
                txtTitle.Text = meetingData["MeetingTitle"].ToString();
                rtbNotes.Text = meetingData["MeetingNotes"].ToString();
                txtLocation.Text = meetingData["MeetingLocation"].ToString();
            }
        }

        private void viewDocument_Click(object sender, EventArgs e) {
            dbHelper.ViewDocuments(_selectedMeetingID);
        }

        private void searchCompany_TextChanged(object sender, EventArgs e) {
            FilterCompanies(searchCompany.Text);
        }

        private void searchAcedemic_TextChanged(object sender, EventArgs e) {
            FilterAcademics(searchAcedemic.Text);
        }
        private bool isAllSelected = false;
        private void selectAllAcademics_Click(object sender, EventArgs e) {
            if (!isAllSelected) {
                // Eğer öğeler seçili değilse, hepsini seç
                for (int i = 0; i < clbAcademics.Items.Count; i++) {
                    clbAcademics.SetItemChecked(i, true);
                }
                isAllSelected = true;
            } else {
                // Eğer öğeler zaten seçiliyse, seçimleri kaldır
                for (int i = 0; i < clbAcademics.Items.Count; i++) {
                    clbAcademics.SetItemChecked(i, false);
                }
                isAllSelected = false;
            }
        }

        // Seçim durumu için bir bayrak tanımlayın
        private bool isAllUsersSelected = false;

        private void selectAllUsers_Click(object sender, EventArgs e) {
            if (!isAllUsersSelected) {
                // Eğer öğeler seçili değilse, hepsini seç
                for (int i = 0; i < clbUsers.Items.Count; i++) {
                    clbUsers.SetItemChecked(i, true);
                }
                isAllUsersSelected = true;
            } else {
                // Eğer öğeler zaten seçiliyse, seçimleri kaldır
                for (int i = 0; i < clbUsers.Items.Count; i++) {
                    clbUsers.SetItemChecked(i, false);
                }
                isAllUsersSelected = false;
            }
        }

        private void sendAllMail_Click(object sender, EventArgs e) {
            // E-posta konusu ve içeriği
            DataTable userDetail = dbHelper.GetDetailUser(userID);
            DataRow row = userDetail.Rows[0]; // İlk satırı al

            // Ad ve soyad bilgilerini al
            string firstName = row["FirstName"].ToString();
            string lastName = row["LastName"].ToString();
            string position = row["position"].ToString();
            if (_selectedMeetingID < 0) {
                MessageBox.Show("Herhangi bir faaliyet seçmediniz.");
                return;
            }
            string bodyNotes = rtbNotes.Text;
            string subject = txtTitle.Text;
            string body = $"{bodyNotes} \n\n\n Sakarya Teknokent - {firstName} {lastName} - {position} \n\nGenerated by Teknokent Meeting.";
            // E-posta içeriğini oluştur ve göster
            string message = $"Konu: {subject}\n\n{body}";

            // Kullanıcıya önizleme göster
            DialogResult result = MessageBox.Show(message, "E-posta Önizleme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK) {
               
            } else {
                // İşlem iptal edildi
                return;
            }

            // RichTextBox içeriğini kontrol edin
            if (string.IsNullOrEmpty(rtbNotes.Text)) {
                MessageBox.Show("Toplantı notları boş.");
                return;
            }

            // E-posta adreslerini toplamak için bir liste
            List<string> emailAddresses = new List<string>();

            // Şirketlerden e-posta adreslerini toplama
            foreach (Participant participant in lbSelectedCompanies.Items) {
                string email = dbHelper.GetEmailFromId(participant.ID, "Companies");
                if (!string.IsNullOrEmpty(email)) {
                    emailAddresses.Add(email);
                }
            }

            // Çalışanlardan e-posta adreslerini toplama
            foreach (Participant participant in lbSelectedEmployees.Items) {
                string email = dbHelper.GetEmailFromId(participant.ID, "Employees");
                if (!string.IsNullOrEmpty(email)) {
                    emailAddresses.Add(email);
                }
            }

            // Akademisyenlerden e-posta adreslerini toplama
            foreach (Participant participant in lbSelectedAcademics.Items) {
                string email = dbHelper.GetEmailFromId(participant.ID, "Academics");
                if (!string.IsNullOrEmpty(email)) {
                    emailAddresses.Add(email);
                }
            }

            // Kullanıcılardan e-posta adreslerini toplama
            foreach (Participant participant in lbSelectedUsers.Items) {
                if (participant.ID == userID) {
                    continue;
                }
                string email = dbHelper.GetEmailFromId(participant.ID, "Users");
                if (!string.IsNullOrEmpty(email)) {
                    emailAddresses.Add(email);
                }
            }

            // E-posta adreslerini birleştir
            string emailList = string.Join(",", emailAddresses.Distinct()); // Tekrarlanan e-posta adreslerini kaldırın

            // Mailto URI oluştur
            string encodedSubject = Uri.EscapeDataString(subject);
            string encodedBody = Uri.EscapeDataString(body);

            // Debug için URI'yi kontrol edin
            string mailtoUri = $"mailto:{emailList}?subject={encodedSubject}&body={encodedBody}";


            try {
                Process.Start(mailtoUri);
            } catch (Exception ex) {
                MessageBox.Show("E-posta istemcisi açılırken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
