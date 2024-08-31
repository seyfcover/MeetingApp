using Mailjet.Client.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class CalenderForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private DateTime currentDate;

        public CalenderForm(DatabaseHelper dbHelper, int userID) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.currentDate = DateTime.Now;
        }

        private void CalenderForm_Load(object sender, EventArgs e) {
            DisplayDays();
            LoadEvents();
        }

        private void DisplayDays() {
            // Başlıklar için haftanın günlerini tanımlayın
            string[] daysOfWeek = { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" };

            // Ayın ilk günü ve gün sayısı
            DateTime startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            int startDayOfWeek = (int)startOfMonth.DayOfWeek;

            tableLayoutPanelDays.Controls.Clear();
            tableLayoutPanelDays.ColumnCount = 7; // Pazar'dan Cumartesi'ye kadar
            tableLayoutPanelDays.RowCount = (daysInMonth + startDayOfWeek) / 7 + 1;

            // Haftanın günlerini ekleyin
            for (int i = 0; i < daysOfWeek.Length; i++) {
                Label lblDayOfWeek = new Label {
                    Text = daysOfWeek[i],
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    Height = 17 // Başlıklar için uygun yükseklik
                };
                tableLayoutPanelDays.Controls.Add(lblDayOfWeek, i, 0);
            }

            // Gün panellerini ekle
            for (int i = 0; i < daysInMonth; i++) {
                Panel dayPanel = new Panel {
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Transparent,
                    Padding = new Padding(2)
                };

                Label lblDay = new Label {
                    Text = (i + 1).ToString(),
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    BackColor = Color.LightGray,
                    Height = 18 // Günler için uygun yükseklik
                };
                lblDay.Click += new EventHandler(LblDay_Click);
                // Günün tarih bilgisini `Tag` özelliğine ekleme
                DateTime dayDate = new DateTime(currentDate.Year, currentDate.Month, i + 1);
                lblDay.Tag = dayDate;


                dayPanel.Controls.Add(lblDay);

                // Etkinlikler için yer ayırma
                // ListBox'ı oluştur ve stilize et
                ListBox lstEvents = new ListBox {
                    Dock = DockStyle.Top,
                    Font = new Font("Century Gothic", 8),
                    IntegralHeight = false,
                    BackColor = Color.FromArgb(220, 230, 242),
                    ItemHeight = 18,
                    HorizontalScrollbar = true
                };

                // Etkinlik seçildiğinde tetiklenen olay
                lstEvents.SelectedIndexChanged += (s, e) => {
                    if (lstEvents.SelectedItem is KeyValuePair<int, string> selectedEvent) {
                        int selectedEventID = selectedEvent.Key;

                        if (selectedEventID > 0) {
                            // Yeni form oluştur ve aç
                            UpdateMeeting eventForm = new UpdateMeeting(dbHelper, userID);
                            eventForm._selectedMeetingID = selectedEventID;
                            eventForm.listofMeetings_SelectedIndexChanged(null, null);
                            eventForm.dtpDate.Value = Convert.ToDateTime(eventForm.listofMeetings.Text);
                            eventForm.FormClosed += UpdateMeeting_FormClosed;
                            eventForm.ShowDialog();
                            
                            // listofMeetings ComboBox'ında etkinliği seçili yap
                        }
                    }
                };

                // ListBox'ı panel'e ekle
                dayPanel.Controls.Add(lstEvents);


                int row = (i + startDayOfWeek) / 7 + 1; // Günlerin başladığı satırdan itibaren ayarlandı
                int column = (i + startDayOfWeek) % 7;
                tableLayoutPanelDays.Controls.Add(dayPanel, column, row);
            }

            lblMonthYear.Text = currentDate.ToString("MMMM yyyy");
        }
        private void UpdateMeeting_FormClosed(object sender, FormClosedEventArgs e) {
            refCalendar_Click(null, null);
        }
        private void LoadEvents() {
            DataTable eventsTable = dbHelper.LoadEvents(currentDate.Year, currentDate.Month);

            foreach (DataRow row in eventsTable.Rows) {
                DateTime eventDate = (DateTime)row["MeetingDate"];
                string eventTitle = row["MeetingTitle"].ToString();
                string eventDay = eventDate.Day.ToString();
                int MeetingID = Convert.ToInt32(row["MeetingID"]);
                var eventDetails = new KeyValuePair<int, string>(MeetingID, eventTitle);

                foreach (Control control in tableLayoutPanelDays.Controls) {
                    if (control is Panel panel && panel.Controls.Count > 1) {
                        // Paneldeki Label ve ListBox'ı bul
                        Label lblDay = panel.Controls[0] as Label;
                        ListBox lstEvents = panel.Controls[1] as ListBox;

                        if (lblDay != null && lblDay.Text == eventDay) {
                            // ListBox'a KeyValuePair ekle ve stilize et
                            lstEvents.Items.Add(eventDetails);
                            lstEvents.DisplayMember = "Value"; // Gösterilecek metin: Value kısmı
                            lstEvents.ValueMember = "Key"; // Seçilecek değer: Key kısmı
                            lstEvents.ForeColor = Color.White;
                            lstEvents.BackColor = Color.FromArgb(255, 153, 51);
                            lstEvents.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                            // Label'ı stilize et
                            lblDay.AutoEllipsis = true;

                            break;
                        }
                    }
                }
            }
        }

        private void LblDay_Click(object sender, EventArgs e) {
            // Tıklanan label'ı elde et
            Label clickedLabel = sender as Label;
            if (clickedLabel != null) {
                // Tıklanan günün bilgisini al
                string dayText = clickedLabel.Text;

                // Tarih bilgisini `Tag` özelliğinden al
                DateTime dayDate = (DateTime)clickedLabel.Tag;
                string dateText = dayDate.ToString("dd MMMM yyyy"); // Tarih formatını buradan ayarlayabilirsiniz

                MeetingForm newMeeting = new MeetingForm(dbHelper, userID);
                newMeeting.dtpDate.Text = dateText;
                newMeeting.dtpTime.Text = "09:00";
                newMeeting.FormClosed += UpdateMeeting_FormClosed;
                newMeeting.ShowDialog();
            }
        }


        private void btnPreviousMonth_Click(object sender, EventArgs e) {
            currentDate = currentDate.AddMonths(-1);
            DisplayDays();
            LoadEvents();
        }

        private void btnNextMonth_Click(object sender, EventArgs e) {
            currentDate = currentDate.AddMonths(1);
            DisplayDays();
            LoadEvents();
        }

        public void refCalendar_Click(object sender, EventArgs e) {
            DisplayDays();
            LoadEvents();
        }
       
        private void close_Viewpanel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
