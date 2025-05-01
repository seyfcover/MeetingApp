
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace MeetingApp
{
    public partial class TTOAdmin : Form
    {
        private int userID;
        private string FullName;
        private DatabaseHelper dbHelper;
        private CompanyForm companyForm;
        private AcademicForm academicForm;
        private MeetingForm meetingForm;
        private ReportForm reportForm;
        private UpdateCompanyForm updateCompanyForm;
        private UpdateEmployee updateEmployeeForm;
        private UpdateAcedemic updateAcedemicForm;
        private UpdateUsers updateUsersForm;
        private RegisterForm registerForm;
        private UpdateMeeting updateMeetingForm;
        private CandidateCompanies candidateCompaniesForm;
        private Statistic statisticForm;
        private WeeklyCalendarForm weeklyCalendarForm;
        private SearchAceCom searchAceComForm;
        private UpdateInventory UpdateInventoryForm;
        private InventoryStatus InventoryStatusForm;
        private UserInformationEditForm userInformationEditForm;
        private Form calendarForm = null;
        private Form viewMeetingsForm = null;
        private Timer notificationBlinkTimer;
        private bool isBlinking = false;
        private List<object> selectedItems = new List<object>();


        public TTOAdmin(DatabaseHelper dbHelper, int userID, string FullName) {
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.FullName = FullName;
            InitializeComponent();
            UpdateFormTitle();
            LoadCalendarForm();
            Alert(userID);
        }
        private void Alert(int userID) {
            dbHelper.CheckUpcomingMeetingsForNextWeek(userID);
            AddNotificationToMenu(dbHelper.GetReminds(userID));
        }
        private void AddNotificationToMenu(List<string> messages) {
            // Menüde 'Bildirimler' adında bir ToolStripMenuItem varsa
            var notificationsMenu = bildirimlerToolStripMenuItem;

            if (notificationsMenu != null) {
                // Duruma göre renk belirle
                foreach (string message in messages) {
                    // Bildirimi ekleyeceğimiz yeni bir ToolStripMenuItem oluştur
                    ToolStripMenuItem newNotification = new ToolStripMenuItem();
                    newNotification.Text = message;

                    // Menüye ekle
                    notificationsMenu.DropDownItems.Add(newNotification);
                }

                // Eğer bildirim varsa, yanıp sönme başlat
                if (messages.Count > 0 && !isBlinking) {
                    isBlinking = true;
                    StartBlinking();
                }
            }
        }

        // Yanıp sönme işlemi için metod
        private void StartBlinking() {
            // Timer'ı başlatıyoruz
            if (notificationBlinkTimer == null) {
                notificationBlinkTimer = new Timer();
                notificationBlinkTimer.Interval = 500;  // 500 ms aralıklarla yanıp sönecek
                notificationBlinkTimer.Tick += NotificationBlinkTimer_Tick;
            }

            notificationBlinkTimer.Start();
        }

        // Timer'ın tick event'inde yapılacak işlemler
        private void NotificationBlinkTimer_Tick(object sender, EventArgs e) {
            // Menüde 'Bildirimler' ToolStripMenuItem'i varsa
            if (bildirimlerToolStripMenuItem != null) {
                // Yanıp sönme efekti: arka plan rengini değiştir
                if (bildirimlerToolStripMenuItem.BackColor == Color.DarkOrange) {
                    bildirimlerToolStripMenuItem.BackColor = Color.Transparent;
                    bildirimlerToolStripMenuItem.ForeColor = Color.Black;// Arka planı normal yap
                } else {
                    bildirimlerToolStripMenuItem.BackColor = Color.DarkOrange;
                    bildirimlerToolStripMenuItem.ForeColor = Color.White;// Arka planı sarı yap (yanıp söner gibi)
                }
            }
        }

        // Bildirimler okunduğunda yanıp sönmeyi durdurma
        private void StopBlinking() {
            if (notificationBlinkTimer != null) {
                notificationBlinkTimer.Stop();
                bildirimlerToolStripMenuItem.BackColor = Color.Transparent;
                bildirimlerToolStripMenuItem.ForeColor = Color.Black;
                // Arka planı normal yap
                isBlinking = false;
            }
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

        private void CloseOpenForms() {
            // Açık olan formları kapat
            if (companyForm != null && !companyForm.IsDisposed) companyForm.Close();
            if (academicForm != null && !academicForm.IsDisposed) academicForm.Close();
            if (meetingForm != null && !meetingForm.IsDisposed) meetingForm.Close();
            if (reportForm != null && !reportForm.IsDisposed) reportForm.Close();
            if (updateCompanyForm != null && !updateCompanyForm.IsDisposed) updateCompanyForm.Close();
            if (updateEmployeeForm != null && !updateEmployeeForm.IsDisposed) updateEmployeeForm.Close();
            if (updateAcedemicForm != null && !updateAcedemicForm.IsDisposed) updateAcedemicForm.Close();
            if (updateUsersForm != null && !updateUsersForm.IsDisposed) updateUsersForm.Close();
            if (registerForm != null && !registerForm.IsDisposed) registerForm.Close();
            if (updateMeetingForm != null && !updateMeetingForm.IsDisposed) updateMeetingForm.Close();
            if (candidateCompaniesForm != null && !candidateCompaniesForm.IsDisposed) candidateCompaniesForm.Close();
            if (statisticForm != null && !statisticForm.IsDisposed) statisticForm.Close();
            if (searchAceComForm != null && !searchAceComForm.IsDisposed) searchAceComForm.Close();
            if (UpdateInventoryForm != null && !UpdateInventoryForm.IsDisposed) UpdateInventoryForm.Close();
            if (InventoryStatusForm != null && !InventoryStatusForm.IsDisposed) InventoryStatusForm.Close();
            if (userInformationEditForm != null && !userInformationEditForm.IsDisposed) userInformationEditForm.Close();
        }
        private void UpdateFormTitle() {
            this.Text = $"Teknokent - {FullName} - Yönetici";
        }

        private void ShowOrCreateForm<T>(ref T form, Func<T> createForm) where T : Form {
            if (form == null || form.IsDisposed) {
                form = createForm();
                form.Show();
            } else {
                form.BringToFront();
            }
        }

        private void addCompany_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref companyForm, () => new CompanyForm(dbHelper, userID, FullName));
        }
        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref registerForm, () => new RegisterForm(dbHelper, userID, FullName));
        }
        private void addAcademian_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref academicForm, () => new AcademicForm(dbHelper, userID, FullName));
        }

        private void addMeeting_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref meetingForm, () => new MeetingForm(dbHelper, userID, FullName));
            meetingForm.FormClosed += updateCalendar;
        }

        private void makeReport_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref reportForm, () => new ReportForm(dbHelper, userID, FullName));
            reportForm.FormClosed += updateCalendar;
        }
        private void updateCalendar(object sender, FormClosedEventArgs e) {
            calendarForm = null;
            LoadCalendarForm();
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
        private void kullanıcıToolStripMenuItem1_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateUsersForm, () => new UpdateUsers(dbHelper, userID, FullName));
        }
        private void şirketToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref updateMeetingForm, () => new UpdateMeeting(dbHelper, userID, FullName));
            updateMeetingForm.FormClosed += updateCalendar;
        }

        private void adayŞirketlerToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref candidateCompaniesForm, () => new CandidateCompanies(dbHelper));
        }
        private void istatistiklerToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref statisticForm, () => new Statistic(dbHelper));
        }
   
        private void şirketAkademisyenToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref searchAceComForm, () => new SearchAceCom(dbHelper, userID, FullName));
        }
        private void bİlgilerimToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowOrCreateForm(ref userInformationEditForm, () => new UserInformationEditForm(dbHelper, userID, FullName));
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
        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e) {
            CloseOpenForms();
            dbHelper.AddLog("Çıkış", "Admin " + FullName + " Sistemden çıkış yaptı.");
        }

        private void bildirimlerToolStripMenuItem_Click(object sender, EventArgs e) {
            StopBlinking();
        }
    }
}