
using System;
using System.Data;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class UserPlusForm : Form
    {
        private DatabaseHelper dbHelper;
        private CompanyForm companyForm;
        private AcademicForm academicForm;
        private MeetingForm meetingForm;
        private ReportForm reportForm;
        private UpdateMeeting UpdateMeetingForm;
        private UpdateCompanyForm updateCompanyForm;
        private UpdateEmployee updateEmployeeForm;
        private UpdateAcedemic updateAcedemicForm;
        private SearchAceCom SearchAceComForm;
        private Form calendarForm = null;
        private Form viewMeetingsForm = null;
        private int userID;
        private string FullName;
        public UserPlusForm(DatabaseHelper databaseHelper, int UserID, string fullName) {
            dbHelper = databaseHelper;
            userID = UserID;
            FullName = fullName;
            InitializeComponent();
            UpdateFormTitle();
            LoadCalendarForm();
            Alert(userID);
        }

        private void Alert(int userID) {
            dbHelper.CheckUpcomingMeetingsForNextWeek(userID);
        }

        private void LoadCalendarForm() {
            // Takvim formunu oluştur ve panelde göster
            if (calendarForm == null || calendarForm.IsDisposed) {
                calendarForm = new WeeklyCalendarForm(dbHelper, userID, FullName);
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

        private void UpdateFormTitle() {
            this.Text = $"Teknokent - {FullName}";
        }

        private void CloseOpenForms() {
            // Açık olan formları kapat
            if (companyForm != null && !companyForm.IsDisposed) companyForm.Close();
            if (academicForm != null && !academicForm.IsDisposed) academicForm.Close();
            if (meetingForm != null && !meetingForm.IsDisposed) meetingForm.Close();
            if (reportForm != null && !reportForm.IsDisposed) reportForm.Close();
            if (updateAcedemicForm != null && !updateAcedemicForm.IsDisposed) updateAcedemicForm.Close();
            if (updateCompanyForm != null && !updateCompanyForm.IsDisposed) updateCompanyForm.Close();
            if (updateEmployeeForm != null && !updateEmployeeForm.IsDisposed) updateEmployeeForm.Close();
            if (SearchAceComForm != null && !SearchAceComForm.IsDisposed) SearchAceComForm.Close();
        }
        private void aramaToolStripMenuItem_Click(object sender, EventArgs e) {
            // Diğer form açıksa kapat
            if (calendarForm != null && !calendarForm.IsDisposed) {
                calendarForm.Close();
                calendarForm = null;
            }

            // Arama formunu kontrol et ve aç
            if (viewMeetingsForm == null || viewMeetingsForm.IsDisposed) {
                viewMeetingsForm = new viewMeetings(dbHelper, userID, FullName);
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
            ShowOrCreateForm(ref companyForm, () => new CompanyForm(dbHelper, userID, FullName));
        }

        private void updateCalendar(object sender, FormClosedEventArgs e) {
            calendarForm = null;
            LoadCalendarForm();
        }
        private void akedemisyenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref academicForm, () => new AcademicForm(dbHelper, userID, FullName));
        }

        private void toplantıToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref meetingForm, () => new MeetingForm(dbHelper, userID, FullName));
            meetingForm.FormClosed += updateCalendar;
        }

        private void raporToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref reportForm, () => new ReportForm(dbHelper, userID, FullName));
            reportForm.FormClosed += updateCalendar;
        }

        private void toplantıToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref UpdateMeetingForm, () => new UpdateMeeting(dbHelper, userID, FullName));
            UpdateMeetingForm.FormClosed += updateCalendar;
        }

        private void UserPanel_FormClosing(object sender, FormClosingEventArgs e) {
            CloseOpenForms();
            dbHelper.AddLog("Çıkış", FullName + " Sistemden çıkış yaptı.");
        }

        private void şirketToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateCompanyForm, () => new UpdateCompanyForm(dbHelper, userID, FullName));
        }
        private void personelToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateEmployeeForm, () => new UpdateEmployee(dbHelper, userID, FullName));
        }
        private void akademisyenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateAcedemicForm, () => new UpdateAcedemic(dbHelper, userID, FullName));
        }
        private void şirketAkademisyenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref SearchAceComForm, () => new SearchAceCom(dbHelper, userID, FullName));
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
