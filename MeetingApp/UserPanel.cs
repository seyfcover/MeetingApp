
using System;
using System.Data;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UserPanel : Form
    {
        private DatabaseHelper dbHelper;
        private CompanyForm companyForm;
        private AcademicForm academicForm;
        private MeetingForm meetingForm;
        private ReportForm reportForm;
        private UpdateMeeting UpdateMeetingForm;
        private Statistic statisticForm;
        private UpdateCompanyForm updateCompanyForm;
        private UpdateEmployee updateEmployeeForm;
        private UpdateAcedemic updateAcedemicForm;
        private Form calendarForm = null;
        private Form viewMeetingsForm = null;
        private int userID;
        public UserPanel(DatabaseHelper databaseHelper, int UserID) {
            this.dbHelper = databaseHelper;
            this.userID = UserID;
            InitializeComponent();
            UpdateFormTitle(userID);
            LoadCalendarForm();
        }

        private void LoadCalendarForm() {
            // Takvim formunu oluştur ve panelde göster
            if (calendarForm == null || calendarForm.IsDisposed) {
                calendarForm = new WeeklyCalendarForm(dbHelper, userID);
                calendarForm.TopLevel = false;
                calendarForm.FormBorderStyle = FormBorderStyle.None;
                calendarForm.Dock = DockStyle.Fill;

                panelofMeetings.SuspendLayout();
                panelofMeetings.Controls.Clear();
                panelofMeetings.Controls.Add(calendarForm);
                panelofMeetings.ResumeLayout();

                // Form kapandığında formu null yap
                calendarForm.FormClosed += (s, args) => { calendarForm = null; };
            }

            // Formu görünür yap ve panelde göster
            panelofMeetings.Visible = true;
            calendarForm.BringToFront();
            calendarForm.Visible = true;
        }
        private void ShowOrCreateForm<T>(ref T form, Func<T> createForm) where T : Form {
            if (form == null || form.IsDisposed) {
                form = createForm();
                form.Show();
            } else {
                form.BringToFront();
            }
        }

        private void UpdateFormTitle(int userID) {
            // Kullanıcı bilgilerini al
            DataTable userDetail = dbHelper.GetDetailUser(userID);

            // Eğer kullanıcı bilgileri başarıyla alındıysa
            if (userDetail != null && userDetail.Rows.Count > 0) {
                DataRow row = userDetail.Rows[0]; // İlk satırı al

                // Ad ve soyad bilgilerini al
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();

                // Formun başlığını güncelle
                this.Text = $"Teknokent - {firstName} {lastName}";
            } else {
                MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
            }
        }

        private void CloseOpenForms() {
            // Açık olan formları kapat
            if (companyForm != null && !companyForm.IsDisposed) companyForm.Close();
            if (academicForm != null && !academicForm.IsDisposed) academicForm.Close();
            if (meetingForm != null && !meetingForm.IsDisposed) meetingForm.Close();
            if (reportForm != null && !reportForm.IsDisposed) reportForm.Close();
            if (statisticForm != null && !statisticForm.IsDisposed) statisticForm.Close();
            if (updateAcedemicForm != null && !updateAcedemicForm.IsDisposed) updateAcedemicForm.Close();
            if (updateCompanyForm != null && !updateCompanyForm.IsDisposed) updateCompanyForm.Close();
            if (updateEmployeeForm != null && !updateEmployeeForm.IsDisposed) updateEmployeeForm.Close();
        }
        private void aramaToolStripMenuItem_Click(object sender, EventArgs e) {
            // Diğer form açıksa kapat
            if (calendarForm != null && !calendarForm.IsDisposed) {
                calendarForm.Close();
                calendarForm = null;
            }

            // Arama formunu kontrol et ve aç
            if (viewMeetingsForm == null || viewMeetingsForm.IsDisposed) {
                viewMeetingsForm = new viewMeetings(dbHelper, userID);
                viewMeetingsForm.TopLevel = false;
                viewMeetingsForm.FormBorderStyle = FormBorderStyle.None;
                viewMeetingsForm.Dock = DockStyle.Fill;

                panelofMeetings.SuspendLayout();
                panelofMeetings.Controls.Clear();
                panelofMeetings.Controls.Add(viewMeetingsForm);
                panelofMeetings.ResumeLayout();

                // Form kapandığında formu null yap
                viewMeetingsForm.FormClosed += (s, args) => { viewMeetingsForm = null; };
            }

            // Formu göster
            viewMeetingsForm.BringToFront();
            viewMeetingsForm.Visible = true;
        }
        private void ViewMeetingsForm_FormClosed(object sender, FormClosedEventArgs e) {
            // Form kapandığında formun referansını sıfırla
            viewMeetingsForm = null;

            // Panelde formu gizle
            panelofMeetings.Visible = false;
        }

        private void şirketToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref companyForm, () => new CompanyForm(dbHelper, userID));
        }

        private void akedemisyenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref academicForm, () => new AcademicForm(dbHelper, userID));
        }

        private void toplantıToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref meetingForm, () => new MeetingForm(dbHelper, userID));
        }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref reportForm, () => new ReportForm(dbHelper));
        }

        private void toplantıToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref UpdateMeetingForm, () => new UpdateMeeting(dbHelper, userID));
        }

        private void UserPanel_FormClosing(object sender, FormClosingEventArgs e) {
            CloseOpenForms();
        }

        private void istatistiklerToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref statisticForm, () => new Statistic(dbHelper));
        }

        private void şirketToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateCompanyForm, () => new UpdateCompanyForm(dbHelper, userID));
        }
        private void personelToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateEmployeeForm, () => new UpdateEmployee(dbHelper, userID));
        }
        private void akademisyenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateAcedemicForm, () => new UpdateAcedemic(dbHelper, userID));
        }
        private void takvimToolStripMenuItem_Click(object sender, EventArgs e) {
            // Diğer form açıksa kapat
            if (viewMeetingsForm != null && !viewMeetingsForm.IsDisposed) {
                viewMeetingsForm.Close();
                viewMeetingsForm = null;
            }

            // Takvim formunu kontrol et ve aç
            LoadCalendarForm();
        }
    }
}
