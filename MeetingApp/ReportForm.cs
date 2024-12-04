using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using MeetingApp.Models;
using System.Data.SqlClient;
using System.Text;
using Mailjet.Client.Resources;
using System.Runtime.CompilerServices;
using OxyPlot;
using System.Reflection;

namespace MeetingApp
{
    public partial class ReportForm : Form
    {
        private DatabaseHelper dbHelper;
        private MeetingReportGenerator reportGenerator;
        private int userID;
        private string FullName;

        public ReportForm(DatabaseHelper dbHelper , int userID , string FullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.FullName = FullName;
            reportGenerator = new MeetingReportGenerator(dbHelper);
            LoadMeetings(null,null);
            LoadCompanies();
            LoadUsers();
            LoadAcademics();
            LoadEmployees();

            defDateRange();
            listAcedemics.SelectedItem = null;
            listCompany.SelectedItem = null;
            listUsers.SelectedItem = null;
            listEmployee.SelectedItem = null;  
            dgvMeetings.CellFormatting += dgvMeetings_CellFormatting;
        }
        private void dgvMeetings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            // Sadece "MeetingType" sütununu işlemek için kontrol edin
            if (dgvMeetings.Columns[e.ColumnIndex].Name == "MeetingType") {
                // Hücredeki değeri al
                var cellValue = dgvMeetings.Rows[e.RowIndex].Cells["MeetingType"].Value;

                // Hücre değeri null değilse ve boş değilse işleme devam edin
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString())) {
                    string logType = cellValue.ToString();

                    // LogType'a göre renklendirme yap
                    if (logType == "ÜSİ") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkBlue;  // Koyu Mavi
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Girişimcilik") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.OrangeRed;  // Parlak Turuncu
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Etkinlik") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Purple;  // Koyu Mor
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Süreç Yönetimi") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.ForestGreen;  // Zümrüt Yeşili
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Uluslararasılaşma") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSlateGray;  // Koyu Gri
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "FSMH") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Maroon;  // Bordo
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Genel/TTO") {
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Teal;  // Petrol Yeşili
                        dgvMeetings.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }




        private void LoadCompanies() {
            System.Data.DataTable companies = dbHelper.GetCompanies();
            listCompany.DataSource = companies;
            listCompany.DisplayMember = "name";
            listCompany.ValueMember = "companyID";

        }

        private void LoadUsers() {
            System.Data.DataTable users = dbHelper.GetUsers();

            // FullName sütunu ekleyelim
            users.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");
            listUsers.DataSource = users;
            listUsers.DisplayMember = "FullName";
            listUsers.ValueMember = "userID";
        }

        private void LoadAcademics() {
            System.Data.DataTable academics = dbHelper.GetAcademics();

            // FullName sütunu ekleyelim
            academics.Columns.Add("FullName", typeof(string), "FirstName + ' ' + LastName");
            listAcedemics.DataSource = academics;
            listAcedemics.DisplayMember = "FullName";
            listAcedemics.ValueMember = "AcademicID";
        }

        private void LoadEmployees() {
            System.Data.DataTable emplooyes = dbHelper.GetListEmployees();
            listEmployee.DataSource = emplooyes;
            listEmployee.DisplayMember = "Fullname";
            listEmployee.ValueMember = "EmployeeID";
        }
        private void LoadMeetings(DateTime? startDate, DateTime? endDate) {
            // Sorgu için dinamik bir StringBuilder oluşturuyoruz
            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("SELECT MeetingID, MeetingDate, MeetingTitle, MeetingType, isImportant FROM Meetings");

            // Eğer tarih aralığı verilmişse WHERE koşulu ekliyoruz
            if (startDate.HasValue && endDate.HasValue) {
                queryBuilder.AppendLine($"WHERE MeetingDate BETWEEN '{startDate.Value:yyyy-MM-dd}' AND '{endDate.Value:yyyy-MM-dd}'");
            }

            // Sıralama koşulunu ekliyoruz
            queryBuilder.AppendLine("ORDER BY MeetingDate DESC");

            // Sorguyu alıyoruz
            string query = queryBuilder.ToString();

            // Sorguyu çalıştırıyoruz ve DataTable'a sonuçları yüklüyoruz
            System.Data.DataTable dt = dbHelper.ExecuteQuery(query); // dbHelper string sorgu alır

            // DataGridView'e verileri bağlıyoruz
            dgvMeetings.DataSource = dt;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt; // dt DataTable'dir
            dgvMeetings.DataSource = bindingSource;

            // Kolon başlıklarını düzenleme
            if (dgvMeetings.Columns["MeetingID"] != null) {
                dgvMeetings.Columns["MeetingID"].Visible = false;
            }

            if (dgvMeetings.Columns["MeetingDate"] != null) {
                dgvMeetings.Columns["MeetingDate"].HeaderText = "Faaliyet Tarihi";
            }

            if (dgvMeetings.Columns["MeetingTitle"] != null) {
                dgvMeetings.Columns["MeetingTitle"].HeaderText = "Faaliyet Başlığı";
            }

            if (dgvMeetings.Columns["MeetingType"] != null) {
                dgvMeetings.Columns["MeetingType"].HeaderText = "Faaliyet Türü";
            }

            if (dgvMeetings.Columns["IsImportant"] != null) {
                dgvMeetings.Columns["IsImportant"].HeaderText = "Önemli";
            }

            // Otomatik boyutlandırma
            dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMeetings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            

        }




        private void LoadFilteredMeetingsToDataGridView(int? companyId, int? userId, int? academicId, int?employeeId, DateTime? dateTimeStart, DateTime? dateTimeEnd, string meetingType, bool isImportant) {
         
            // Toplantıları sorgulamak için GetMeetingsWithSelectedParticipantsAndDateRange fonksiyonunu çağırıyoruz
            List<Meeting> meetings = dbHelper.GetMeetingsWithSelectedParticipantsAndDateRange(companyId, userId, academicId, employeeId, dateTimeStart, dateTimeEnd, meetingType, isImportant);

            // DataTable oluşturma ve kolonları ekleme
            var dt = new System.Data.DataTable();
            dt.Columns.Add("MeetingID", typeof(int));
            dt.Columns.Add("MeetingDate", typeof(DateTime));
            dt.Columns.Add("MeetingTitle", typeof(string));
            dt.Columns.Add("MeetingType", typeof(string));
            dt.Columns.Add("IsImportant", typeof(bool));

            // Listeden DataTable'e veri ekleme
            foreach (var meeting in meetings) {
                dt.Rows.Add(meeting.MeetingID, meeting.Date, meeting.Title, meeting.MeetingType, meeting.isImportant);
            }

            // DataGridView'e verileri yükleme
            dgvMeetings.DataSource = dt;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt; // dt DataTable'dir
            dgvMeetings.DataSource = bindingSource;

            // DataGridView sütun ayarları
            if (dgvMeetings.Columns["MeetingID"] != null) {
                dgvMeetings.Columns["MeetingID"].Visible = false;
            }

            if (dgvMeetings.Columns["MeetingDate"] != null) {
                dgvMeetings.Columns["MeetingDate"].HeaderText = "Faaliyet Tarihi";
            }

            if (dgvMeetings.Columns["MeetingTitle"] != null) {
                dgvMeetings.Columns["MeetingTitle"].HeaderText = "Faaliyet Başlığı";
            }

            if (dgvMeetings.Columns["MeetingType"] != null) {
                dgvMeetings.Columns["MeetingType"].HeaderText = "Faaliyet Türü";
            }

            if (dgvMeetings.Columns["IsImportant"] != null) {
                dgvMeetings.Columns["IsImportant"].HeaderText = "Önemli";
            }
            dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMeetings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            
        }



        [Obsolete]
        private void btnGenerateReport_Click(object sender, EventArgs e) {
            if (dgvMeetings.SelectedRows.Count > 0) {
                DataGridViewRow selectedRow = dgvMeetings.SelectedRows[0];
                int meetingID = Convert.ToInt32(selectedRow.Cells["MeetingID"].Value);

                try {
                    GenerateReport(meetingID);

                    MessageBox.Show("Rapor başarıyla oluşturuldu ve görüntüleniyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Rapor oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Lütfen bir Faaliyet seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        [Obsolete]
        public void GenerateReport(int meetingID) {
            string query = $"SELECT MeetingDate, MeetingTitle FROM Meetings WHERE MeetingID = {meetingID}";
            System.Data.DataTable dt = dbHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0) {
                DateTime meetingDate = Convert.ToDateTime(dt.Rows[0]["MeetingDate"]);
                string meetingTitle = dt.Rows[0]["MeetingTitle"].ToString();

                string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "form1.docx");
                string exportDirectory = @"C:\Export";
                string meetingDateFormatted = meetingDate.ToString("yyyy-MM-dd");
                string outputDocxPath = Path.Combine(exportDirectory, $"{meetingID}-{meetingDateFormatted}-{meetingTitle}_report.docx");
                string outputPdfPath = Path.Combine(exportDirectory, $"{meetingID}-{meetingDateFormatted}-{meetingTitle}_report.pdf");

                if (!Directory.Exists(exportDirectory)) {
                    Directory.CreateDirectory(exportDirectory);
                }

                try {
                    reportGenerator.GenerateMeetingReport(meetingID, templatePath, outputDocxPath, outputPdfPath);

                    // DOCX dosyasını PDF'e çevir
                    ConvertDocxToPdf(outputDocxPath, outputPdfPath);

                    // PDF dosyasını varsayılan PDF görüntüleyicide aç
                    Process.Start(outputPdfPath);
                } catch (Exception ex) {
                    MessageBox.Show($"Rapor oluşturulurken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Faaliyet bilgileri alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertDocxToPdf(string inputDocxPath, string outputPdfPath) {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document wordDoc = null;

            try {
                wordDoc = wordApp.Documents.Open(inputDocxPath);
                wordDoc.ExportAsFixedFormat(outputPdfPath, WdExportFormat.wdExportFormatPDF);
            } catch (Exception ex) {
                MessageBox.Show($"PDF'e dönüştürme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                if (wordDoc != null) {
                    wordDoc.Close();
                    wordDoc = null;
                }

                if (wordApp != null) {
                    wordApp.Quit();
                    wordApp = null;
                }
            }
        }

        private void renewMeetings_Click(object sender, EventArgs e) {

            // Tarih aralığını tanımla
            DateTime? startDate = null;
            DateTime? endDate = null;

            // Tarih aralığı için CheckBox kontrolü
            if (customDateRange.Checked) {
                startDate = dateTimeStart.Value;
                endDate = dateTimeEnd.Value;

                // Başlangıç tarihinin bitiş tarihinden sonra olup olmadığını kontrol et
                if (startDate > endDate) {
                    MessageBox.Show("Başlangıç tarihi, bitiş tarihinden daha ileri bir tarih olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // İşlemi durdur
                }
            }
            LoadMeetings(startDate,endDate);
        }

        private void labelPArticipants_Click(object sender, EventArgs e) {
            if (chkCom.Checked == false) {
                chkCom.Checked = true;
            } else {
                chkCom.Checked = false;
            }
        }

        private void label2_Click(object sender, EventArgs e) {
            if (chkUser.Checked == false) {
                chkUser.Checked = true;
            } else {
                chkUser.Checked = false;
            }
        }

        private void label3_Click(object sender, EventArgs e) {
            if (chkAcd.Checked == false) {
                chkAcd.Checked = true;
            } else {
                chkAcd.Checked = false;
            }
        }
        private void labelEmployee_Click(object sender, EventArgs e) {
            if (chkEmployee.Checked == false) {
                chkEmployee.Checked = true;
            } else {
                chkEmployee.Checked = false;
            }
        }

        private void chkCom_CheckedChanged(object sender, EventArgs e) {
            if (chkCom.Checked == false) {
                listCompany.Enabled = false;
                listCompany.SelectedItem = null;
                labelPArticipants.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listCompany.Enabled = true;
                labelPArticipants.BackColor = Color.MediumSeaGreen;
            }
        }

        private void chkUser_CheckedChanged(object sender, EventArgs e) {
            if (chkUser.Checked == false) {
                listUsers.Enabled = false;
                listUsers.SelectedItem = null;
                label2.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listUsers.Enabled = true;
                label2.BackColor = Color.MediumSeaGreen;
            }
        }

        private void chkEmp_CheckedChanged(object sender, EventArgs e) {
            if (chkAcd.Checked == false) {
                listAcedemics.Enabled = false;
                listAcedemics.SelectedItem = null;
                label3.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listAcedemics.Enabled = true;
                label3.BackColor = Color.MediumSeaGreen;
            }
        }

        private void chkEmp1_CheckedChanged(object sender, EventArgs e) {
            if (chkEmployee.Checked == false) {
                listEmployee.Enabled = false;
                listEmployee.SelectedItem = null;
                labelEmployee.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listEmployee.Enabled = true;
                labelEmployee.BackColor = Color.MediumSeaGreen;
            }
        }

        private void customDateRange_CheckedChanged(object sender, EventArgs e) {
            if (customDateRange.Checked) {
                dateTimeStart.Enabled = true;
                dateTimeEnd.Enabled = true;
            } else {
                dateTimeStart.Enabled = false;
                dateTimeEnd.Enabled = false;
            }
        }

        private void lisrConditions_Click(object sender, EventArgs e) {
            // Tarih aralığını tanımla
            DateTime? startDate = null;
            DateTime? endDate = null;

            // Tarih aralığı için CheckBox kontrolü
            if (customDateRange.Checked) {
                startDate = dateTimeStart.Value;
                endDate = dateTimeEnd.Value;

                // Başlangıç tarihinin bitiş tarihinden sonra olup olmadığını kontrol et
                if (startDate > endDate) {
                    MessageBox.Show("Başlangıç tarihi, bitiş tarihinden daha ileri bir tarih olamaz.", "Tarih Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // İşlemi durdur
                }
            }

            // ComboBox'lardaki seçili değerleri kontrol et
            int? selectedCompanyId = null;
            int? selectedUserId = null;
            int? selectedAcademicId = null;
            int? selectedEmployeeId = null;

            if (chkCom.Checked) {
                selectedCompanyId = listCompany.SelectedValue as int?;
                if (selectedCompanyId == 0) selectedCompanyId = null;
            }

            if (chkUser.Checked) {
                selectedUserId = listUsers.SelectedValue as int?;
                if (selectedUserId == 0) selectedUserId = null;
            }

            if (chkAcd.Checked) {
                selectedAcademicId = listAcedemics.SelectedValue as int?;
                if (selectedAcademicId == 0) selectedAcademicId = null;
            }

            if (chkEmployee.Checked) {
                selectedEmployeeId = listEmployee.SelectedValue as int?;
                if (selectedEmployeeId == 0) selectedEmployeeId = null;
            }

            // Toplantıları filtreleyip DataGridView'e yükle
            LoadFilteredMeetingsToDataGridView(selectedCompanyId, selectedUserId, selectedAcademicId, selectedEmployeeId, startDate, endDate ,MeetingType.Text, isImportant.Checked);
        }

        private void reportConditions_Click(object sender, EventArgs e) {
            if (dgvMeetings.Rows.Count > 0) {
                // Yükleme ekranı göstermek için bir ProgressBar veya başka bir form kullanılabilir.
                using (ProgressForm progressForm = new ProgressForm(dgvMeetings.Rows.Count)) {
                    progressForm.Show();

                    for (int i = 0; i < dgvMeetings.Rows.Count; i++) {
                        DataGridViewRow row = dgvMeetings.Rows[i];
                        int meetingID = Convert.ToInt32(row.Cells["MeetingID"].Value);

                        try {
                            GenerateReport(meetingID);
                            progressForm.UpdateProgress(i + 1);
                        } catch (Exception ex) {
                            MessageBox.Show("Rapor oluşturulurken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }

                    MessageBox.Show("Tüm raporlar başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("Listelenecek faaliyet bulunmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void defDateRange() {
            // Günümüz tarihi
            dateTimeEnd.Value = DateTime.Now;

            // Bir ay öncesi tarihi
            dateTimeStart.Value = DateTime.Now.AddMonths(-1);
        }

        private void searchEvent_TextChanged(object sender, EventArgs e) {
            // Arama metni
            string searchValue = searchEvent.Text.ToLower(); // Küçük harfe çevir

            // Eğer arama metni boşsa filtreleme yapma
            if (string.IsNullOrWhiteSpace(searchValue)) {
                (dgvMeetings.DataSource as BindingSource).RemoveFilter();
            } else {
                // MeetingTitle kolonuna göre filtre uyguluyoruz
                (dgvMeetings.DataSource as BindingSource).Filter = $"MeetingTitle LIKE '%{searchValue}%'";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) {
                MeetingType.Enabled = true;
            } else {
                MeetingType.Enabled = false;
                MeetingType.SelectedItem = null;
            }  
        }


        private void dgvMeetings_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Satırın geçerli olup olmadığını kontrol et
            if (e.RowIndex >= 0) {
                // Çift tıklanan satırı al
                DataGridViewRow row = dgvMeetings.Rows[e.RowIndex];
              

                // "MeetingID" sütunundaki değeri al
                int selectedEventID = Convert.ToInt32(row.Cells["MeetingID"].Value);

                DateTime selectedEventDate = dbHelper.GetMeetingDateByID(selectedEventID); // Veritabanından tarih al

                if (selectedEventID > 0) {
                    UpdateMeeting eventForm = new UpdateMeeting(dbHelper, userID, FullName);

                    // MeetingID ve MeetingDate kontrolü ile manuel olarak ComboBox'tan seçimi ayarla
                    for (int i = 0; i < eventForm.listofMeetings.Items.Count; i++) {
                        var item = (KeyValuePair<int, string>)eventForm.listofMeetings.Items[i];

                        // Toplantı başlığı aynı olabilir, ancak ID ve tarih ile kontrol ediyoruz
                        if (item.Key == selectedEventID) {
                            DateTime itemDate = dbHelper.GetMeetingDateByID(item.Key); // Her item'in tarihini al

                            if (itemDate.Date == selectedEventDate.Date) {
                                eventForm.listofMeetings.SelectedIndex = i; // Doğru index'i bulduktan sonra seç
                                break;
                            }
                        }
                    }
                    eventForm.listofMeetings_SelectedIndexChanged(null, null);
                    eventForm.FormClosed += UpdateList_FormClosed;
                    eventForm.ShowDialog();

                }

            }
        }

        private void UpdateList_FormClosed(object sender, FormClosedEventArgs e) {
            renewMeetings_Click(null, null);
        }

        
    }
}

