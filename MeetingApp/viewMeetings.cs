using MeetingApp.Models;
using MeetingApp.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class viewMeetings : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;
        private int meetingID;
        private List<string> originalItems;
        private string email;
        private string subject;
        private string body;
        private ToolTip toolTip = new ToolTip {
            ToolTipTitle = "Bilgi",
            ToolTipIcon = ToolTipIcon.Info,
            AutomaticDelay = 1000
        };
        public viewMeetings(DatabaseHelper databaseHelper, int userID , string FullName) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.userID = userID;
            this.FullName = FullName;
            dbHelper.LoadAllMeetingTitles(listofMeetings);
            PopulateCheckedListBoxWithAllData();
            originalItems = listofMeetings.Items.Cast<string>().ToList();
            toolTip.SetToolTip(ParticipantCompany, "Toplantıyla ilgili mail gönder");

            Filterbegin.Value = DateTime.Now.AddMonths(-1).Date;
            // Bugünün tarihini dptEnd'e ata (günün son anına kadar ayarlanmış şekilde)
            Filterend.Value = DateTime.Now.Date.AddDays(1).AddTicks(-1);
        }

        private void PopulateCheckedListBoxWithAllData() {
            // Tüm verileri veritabanından al
            var allData = dbHelper.GetAllData();
            checkedListBoxParticipants.Items.Clear();
            // CheckedListBox'ı doldur
            foreach (var data in allData) {
                checkedListBoxParticipants.Items.Add(data);
            }
        }
        private void listofMeetings_SelectedIndexChanged(object sender, EventArgs e) {
            if (listofMeetings.SelectedItem != null) {
                // Seçilen öğenin MeetingTitle'ını al
                string selectedTitle = listofMeetings.SelectedItem.ToString();

                // ListBox'taki öğe, MeetingTitle ve MeetingID arasındaki ilişkiyi çözümlemek için
                DataTable allMeetings = dbHelper.GetAllMeetings();
                DataRow[] selectedRows = allMeetings.Select($"MeetingTitle = '{selectedTitle}'");

                if (selectedRows.Length > 0) {
                    int meetingId = (int)selectedRows[0]["MeetingID"];
                    this.meetingID = meetingId;
                    DisplayMeetingDetails(meetingId);
                    dbHelper.LoadParticipants(meetingId, listofParticipants);
                }
            }
        }
        private void cleanViews() {
            listofMeetings.DataSource = null; // DataSource'u null yap
            listofParticipants.DataSource = null;
            listofMeetings.Items.Clear();
            listofParticipants.Items.Clear();
            MeetingDate.Text = string.Empty;
            MeetingLocation.Text = string.Empty;
            MeetingTime.Text = string.Empty;
            MeetingTitle.Text = string.Empty;
            MeetingNotes.Text = string.Empty;
            ParticipantCompany.Image = null;
            ParticipantName.Text = string.Empty;
            ParticipantEmail.Text = string.Empty;
            ParticipantPhone.Text = string.Empty;
            ParticipantPosition.Text = string.Empty;
            ParticipantTitle.Text = string.Empty;
            countofAmeeting.Text = string.Empty;
        }

        private void close_Viewpanel_Click(object sender, EventArgs e) {
            cleanViews();
            this.Close();
        }

        private void DisplayMeetingDetails(int meetingId) {
            // Toplantı detaylarını al
            DataTable meetingDetails = dbHelper.GetMeetingDetails(meetingId);

            // Detayları bir kontrol üzerinde göster
            if (meetingDetails.Rows.Count > 0) {
                DataRow row = meetingDetails.Rows[0];

                // Yardımcı metodları kullanarak tarih ve saat formatlama
                MeetingDate.Text = FormatDate(row["MeetingDate"]);
                MeetingTime.Text = FormatTime(row["MeetingTime"]);

                // Örneğin, TextBox'larda göstermek için
                MeetingTitle.Text = row["MeetingTitle"].ToString();
                subject = row["MeetingTitle"].ToString();
                MeetingNotes.Text = row["MeetingNotes"].ToString();
                MeetingLocation.Text = row["MeetingLocation"].ToString();
            }
        }
        private void ListMeetingforFilter_Click(object sender, EventArgs e) {
            // Tarih aralığı ve katılımcı bilgilerini al
            DateTime startDate = Filterbegin.Value.Date;
            DateTime endDate = Filterend.Value.Date;
            var selectedParticipants = checkedListBoxParticipants.CheckedItems.OfType<Participants>().ToList();

            if (selectedParticipants.Count == 0) {
                MessageBox.Show("Lütfen en az bir katılımcı seçin.", "Katılımcı Seçimi Gerekiyor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Katılımcı ID'lerini ve türlerini al
            List<int> participantIds = selectedParticipants.Select(p => p.ID).ToList();
            List<string> participantTypes = selectedParticipants.Select(p => p.Type).Distinct().ToList();

            // Katılımcılar ve tarih aralığına göre toplantıları getir
            DataTable meetings = dbHelper.GetMeetingsByParticipantsAndDateRange(participantIds, participantTypes, startDate, endDate);

            // Toplantıları ListBox'a ekle
            listofMeetings.Items.Clear();
            foreach (DataRow row in meetings.Rows) {
                listofMeetings.Items.Add(row["MeetingTitle"].ToString());
            }
        }


        private void viewDocument_Click(object sender, EventArgs e) {
            dbHelper.ViewDocuments(meetingID);
        }

        private void listofParticipants_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                // Seçilen katılımcı bilgilerini al
                var (selectedId, participantType) = GetSelectedParticipantInfo(listofParticipants);
                if (selectedId != 0) {
                    // Katılımcı detaylarını al
                    DataTable participantDetails = dbHelper.GetParticipantDetailsById(selectedId, participantType);

                    // Paneldeki label'lara atama yap
                    if (participantDetails.Rows.Count > 0) {
                        DataRow row = participantDetails.Rows[0];
                        UpdateParticipantDetails(row, participantType, selectedId);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void UpdateParticipantDetails(DataRow row, string participantType, int selectedId) {
            switch (participantType) {
                case "Company":
                    UpdateCompanyDetails(row, selectedId);
                    break;
                case "Employee":
                    UpdateEmployeeDetails(row, selectedId);
                    break;
                case "Academic":
                    UpdateAcademicDetails(row, selectedId);
                    break;
                case "User":
                    UpdateUserDetails(row, selectedId);
                    break;
                default:
                    ClearParticipantDetails();
                    break;
            }
        }

        private void UpdateCompanyDetails(DataRow row, int selectedId) {
            ParticipantName.Text = row["Name"].ToString(); // Şirket adı
            ParticipantPosition.Text = row["FieldsOfActivity"].ToString(); // Şirket adresi
            ParticipantTitle.Text = row["Phone"].ToString(); // Şirket telefon numarası
            ParticipantEmail.Text = row["Email"].ToString(); // Şirket e-posta adresi
            email = row["Email"].ToString();
            ParticipantPhone.Text = row["Address"].ToString(); // Şirket faaliyet alanı
            countofAmeeting.Text = dbHelper.CountofMeetings("Company", selectedId).ToString();

            // Şirket logosunu yükle
            if (row["Logo"] != DBNull.Value) {
                byte[] logoBytes = (byte[])row["Logo"];
                using (MemoryStream ms = new MemoryStream(logoBytes)) {
                    ParticipantCompany.Image = Image.FromStream(ms);
                }
            } else {
                ParticipantCompany.Image = null; // Logo yoksa resmi temizle
            }
        }

        private void UpdateEmployeeDetails(DataRow row, int selectedId) {
            ParticipantName.Text = $"{row["FirstName"]} {row["LastName"]}"; // Katılımcının adı
            ParticipantPosition.Text = row["Position"].ToString(); // Unvan
            ParticipantTitle.Text = row["Title"].ToString(); // Başlık
            ParticipantEmail.Text = row["Email"].ToString(); // E-posta adresi
            email = row["Email"].ToString();
            ParticipantPhone.Text = row["Phone"].ToString(); // Telefon numarası
            countofAmeeting.Text = dbHelper.CountofMeetings("Employee", selectedId).ToString();

            // Diğer türler için logo genellikle olmayabilir
            ParticipantCompany.Image = null;
        }

        private void UpdateAcademicDetails(DataRow row, int selectedId) {
            ParticipantName.Text = $"{row["FirstName"]} {row["LastName"]}"; // Katılımcının adı
            ParticipantPosition.Text = row["Position"].ToString(); // Unvan
            ParticipantTitle.Text = row["Title"].ToString(); // Başlık
            ParticipantEmail.Text = row["Email"].ToString(); // E-posta adresi
            email = row["Email"].ToString(); //mail atmak için
            ParticipantPhone.Text = row["Phone"].ToString(); // Telefon numarası
            countofAmeeting.Text = dbHelper.CountofMeetings("Academic", selectedId).ToString();

            // Diğer türler için logo genellikle olmayabilir
            ParticipantCompany.Image = null;
        }

        private void UpdateUserDetails(DataRow row, int selectedId) {
            ParticipantName.Text = $"{row["firstName"]} {row["lastName"]}"; // Katılımcının adı
            ParticipantPosition.Text = row["position"].ToString(); // Unvan
            ParticipantTitle.Text = row["title"].ToString(); // Başlık
            ParticipantEmail.Text = row["email"].ToString(); // E-posta adresi
            email = row["Email"].ToString(); //mail atmak için
            ParticipantPhone.Text = row["phoneNumber"].ToString(); // Telefon numarası
            countofAmeeting.Text = dbHelper.CountofMeetings("User", selectedId).ToString();

            // Diğer türler için logo genellikle olmayabilir
            ParticipantCompany.Image = Resources.teknokentlogo;
        }

        private void ClearParticipantDetails() {
            ParticipantName.Text = "Bilgi bulunamadı.";
            ParticipantPosition.Text = "Bilgi bulunamadı.";
            ParticipantTitle.Text = "Bilgi bulunamadı.";
            ParticipantEmail.Text = "Bilgi bulunamadı.";
            ParticipantPhone.Text = "Bilgi bulunamadı.";
            ParticipantCompany.Image = null;
        }


        private (int id, string type) GetSelectedParticipantInfo(ListBox listBox) {
            try {
                if (listBox.SelectedItem != null) {
                    Participants selectedParticipant = (Participants)listBox.SelectedItem;
                    return (selectedParticipant.ID, selectedParticipant.Type);
                }
                // Katılımcı seçilmemişse varsayılan değer döndür
                return (0, "Unknown");
            } catch (Exception ex) {
                // Hata loglama veya başka bir işlem
                //Log.Error(ex.Message);
                MessageBox.Show($"Hata: {ex.Message}"); // Hata mesajını kullanıcıya göster
                return (0, "Unknown"); // Varsayılan değer döndür
            }
        }

        private string FormatDate(object date) {
            return DateTime.TryParse(date.ToString(), out DateTime parsedDate)
                ? parsedDate.ToString("dd.MM.yyyy")
                : "Geçersiz tarih";
        }

        private string FormatTime(object time) {
            return DateTime.TryParse(time.ToString(), out DateTime parsedTime)
                ? parsedTime.ToString("HH:mm")
                : "Geçersiz saat";
        }


        private void textBoxSearch_TextChanged(object sender, EventArgs e) {
            // Mevcut seçili öğeleri kaydet
            var checkedItems = checkedListBoxParticipants.CheckedItems.Cast<Participants>().ToList();

            // Arama terimini al
            string searchText = textBoxSearch.Text.Trim().ToLower();

            // Arama terimini içeren öğeleri filtrele
            var allItems = dbHelper.GetAllData();
            var filteredItems = allItems.Where(p => p.DisplayName.ToLower().Contains(searchText)).ToList();

            // CheckedListBox'ı güncelle
            // Önce, CheckedListBox'ı temizleyin ve filtrelenmiş öğeleri ekleyin
            checkedListBoxParticipants.Items.Clear();
            checkedListBoxParticipants.Items.AddRange(filteredItems.ToArray());

            // Kaydedilen seçimleri tekrar uygula
            foreach (var item in checkedItems) {
                // Eğer öğe listeye eklenmişse, işaretle
                int index = checkedListBoxParticipants.Items.IndexOf(item);
                if (index >= 0) {
                    checkedListBoxParticipants.SetItemChecked(index, true);
                }
            }
        }
        private void btnClearSelection_Click(object sender, EventArgs e) {
            for (int i = 0; i < checkedListBoxParticipants.Items.Count; i++) {
                checkedListBoxParticipants.SetItemChecked(i, false);
            }
            dbHelper.LoadAllMeetingTitles(listofMeetings);
        }

        [Obsolete]
        private async void generateReport_Click(object sender, EventArgs e) {
            try {
                // meetingID'nin geçerli olup olmadığını kontrol ediyoruz
                if (meetingID <= 0) {
                    MessageBox.Show("Toplantı seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ReportForm nesnesini 'using' bloğu içinde kullanarak kaynakları yönetiyoruz
                using (var viewReport = new ReportForm(dbHelper, userID, FullName)) {
                    // Rapor oluşturma işlemini asenkron olarak yürütüyoruz
                    await Task.Run(() => viewReport.GenerateReport(meetingID));
                }

                // Başarılı bir şekilde rapor oluşturulduğunda kullanıcıya bilgi veriyoruz
                MessageBox.Show("Rapor başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                // Rapor oluşturma sırasında bir hata oluşursa, kullanıcıya hata mesajını gösteriyoruz
                MessageBox.Show($"Rapor oluşturulurken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchTextbox_TextChanged(object sender, EventArgs e) {
            // Arama metnini alıyoruz
            string searchText = searchTextbox.Text.ToLower();

            // ListBox'ı temizliyoruz
            listofMeetings.Items.Clear();

            // Orijinal listeden, arama metniyle eşleşen öğeleri filtreleyip ekliyoruz
            var filteredItems = originalItems.Where(item => item.ToLower().Contains(searchText)).ToList();

            // Filtrelenmiş öğeleri ListBox'a ekliyoruz
            listofMeetings.Items.AddRange(filteredItems.ToArray());
        }

        private void refMeeting_Click(object sender, EventArgs e) {
            for (int i = 0; i < checkedListBoxParticipants.Items.Count; i++) {
                checkedListBoxParticipants.SetItemChecked(i, false);
            }
            dbHelper.LoadAllMeetingTitles(listofMeetings);
            PopulateCheckedListBoxWithAllData();
            originalItems = listofMeetings.Items.Cast<string>().ToList();

        }

        private void ParticipantCompany_Click(object sender, EventArgs e) {
            // Kullanıcı bilgilerini al
            DataTable userDetail = dbHelper.GetDetailUser(userID);
            string mailtoUri;
            string NetMail = string.Empty;

            // Eğer kullanıcı bilgileri başarıyla alındıysa
            if ((userDetail != null && userDetail.Rows.Count > 0) && (!String.IsNullOrEmpty(ParticipantName.Text))) {
                DataRow row = userDetail.Rows[0]; // İlk satırı al

                // Ad ve soyad bilgilerini al
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                string position = row["position"].ToString();
                

                if (IsValidEmail(ParticipantEmail.Text)) {
                    NetMail = ParticipantEmail.Text;
                } else if(IsValidEmail(email)) {
                    NetMail = email;
                } else {
                    MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                    return;
                }

                // Formun başlığını güncelle
                body = $"{MeetingNotes.Text} \n\n\n Sakarya Teknokent - {firstName} {lastName} - {position} \n\nGenerated by Teknokent Meeting.";
                string message = $"Konu: {subject}\n\n{body}";

                // Kullanıcıya önizleme göster
                DialogResult result = MessageBox.Show(message, "E-posta Önizleme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK) {

                } else {
                    // İşlem iptal edildi
                    return;
                }

                mailtoUri = $"mailto:{email}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
                try {
                    Process.Start(mailtoUri);
                } catch (Exception ex) {
                    MessageBox.Show("E-posta istemcisi açılırken bir hata oluştu: " + ex.Message);
                }

            } else {
                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
            }
        }

        private void ParticipantCompany_MouseEnter(object sender, EventArgs e) {
            ParticipantCompany.BackColor = System.Drawing.Color.LightGray;
        }

        private void ParticipantCompany_MouseLeave(object sender, EventArgs e) {
            ParticipantCompany.BackColor = System.Drawing.Color.Transparent;
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

        private void button1_Click(object sender, EventArgs e) {
            ParticipantCompany_Click(null, null);
        }
    }
}

