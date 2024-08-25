using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using MeetingApp.Models;

namespace MeetingApp
{
    public partial class ReportForm : Form
    {
        DatabaseHelper dbHelper;
        private MeetingReportGenerator reportGenerator;

        public ReportForm(DatabaseHelper dbHelper) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            reportGenerator = new MeetingReportGenerator(dbHelper);
            LoadMeetings();
            LoadCompanies();
            LoadUsers();
            LoadAcademics();
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
        private void LoadMeetings() {
            string query = "SELECT MeetingID, MeetingDate, MeetingTitle FROM Meetings ORDER BY MeetingDate DESC";
            System.Data.DataTable dt = dbHelper.ExecuteQuery(query);

            dgvMeetings.DataSource = dt;

            if (dgvMeetings.Columns["MeetingID"] != null) {
                dgvMeetings.Columns["MeetingID"].Visible = false;
            }

            if (dgvMeetings.Columns["MeetingDate"] != null) {
                dgvMeetings.Columns["MeetingDate"].HeaderText = "Toplantı Tarihi";
            }

            if (dgvMeetings.Columns["MeetingTitle"] != null) {
                dgvMeetings.Columns["MeetingTitle"].HeaderText = "Toplantı Başlığı";
            }

            dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMeetings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void LoadFilteredMeetingsToDataGridView(int? companyId, int? userId, int? academicId, DateTime? dateTimeStart, DateTime? dateTimeEnd) {
            // Toplantıları sorgulamak için GetMeetingsWithSelectedParticipantsAndDateRange fonksiyonunu çağırıyoruz
            List<Meeting> meetings = dbHelper.GetMeetingsWithSelectedParticipantsAndDateRange(companyId, userId, academicId, dateTimeStart, dateTimeEnd);

            // DataTable oluşturma ve kolonları ekleme
            var dt = new System.Data.DataTable();
            dt.Columns.Add("MeetingID", typeof(int));
            dt.Columns.Add("MeetingDate", typeof(DateTime));
            dt.Columns.Add("MeetingTitle", typeof(string));

            // Listeden DataTable'e veri ekleme
            foreach (var meeting in meetings) {
                dt.Rows.Add(meeting.MeetingID, meeting.Date, meeting.Title);
            }

            // DataGridView'e verileri yükleme
            dgvMeetings.DataSource = dt;

            // DataGridView sütun ayarları
            if (dgvMeetings.Columns["MeetingID"] != null) {
                dgvMeetings.Columns["MeetingID"].Visible = false;
            }

            if (dgvMeetings.Columns["MeetingDate"] != null) {
                dgvMeetings.Columns["MeetingDate"].HeaderText = "Toplantı Tarihi";
            }

            if (dgvMeetings.Columns["MeetingTitle"] != null) {
                dgvMeetings.Columns["MeetingTitle"].HeaderText = "Toplantı Başlığı";
            }

            dgvMeetings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMeetings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        }



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
                MessageBox.Show("Lütfen bir toplantı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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
                MessageBox.Show("Toplantı bilgileri alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadMeetings();
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

        private void chkCom_CheckedChanged(object sender, EventArgs e) {
            if (chkCom.Checked == false) {
                listCompany.Enabled = false;
                labelPArticipants.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listCompany.Enabled = true;
                labelPArticipants.BackColor = Color.MediumSeaGreen;
            }
        }

        private void chkUser_CheckedChanged(object sender, EventArgs e) {
            if (chkUser.Checked == false) {
                listUsers.Enabled = false;
                label2.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listUsers.Enabled = true;
                label2.BackColor = Color.MediumSeaGreen;
            }
        }

        private void chkEmp_CheckedChanged(object sender, EventArgs e) {
            if (chkAcd.Checked == false) {
                listAcedemics.Enabled = false;
                label3.BackColor = Color.FromArgb(0, 122, 204);
            } else {
                listAcedemics.Enabled = true;
                label3.BackColor = Color.MediumSeaGreen;
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

            // Toplantıları filtreleyip DataGridView'e yükle
            LoadFilteredMeetingsToDataGridView(selectedCompanyId, selectedUserId, selectedAcademicId, startDate, endDate);
        }


    }
}

