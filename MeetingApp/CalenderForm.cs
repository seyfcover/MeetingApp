using System;
using System.Data;
using System.Drawing;
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
                ListBox lstEvents = new ListBox {
                    Dock = DockStyle.Top,
                    Font = new Font("Century Gothic", 8),
                    IntegralHeight = false,
                    BackColor = Color.FromArgb(220, 230, 242),
                    ItemHeight = 18,
                    HorizontalScrollbar = true
                };
                // ListBox'ın tıklama olayını bağlama

                dayPanel.Controls.Add(lstEvents);
      
                int row = (i + startDayOfWeek) / 7 + 1; // Günlerin başladığı satırdan itibaren ayarlandı
                int column = (i + startDayOfWeek) % 7;
                tableLayoutPanelDays.Controls.Add(dayPanel, column, row);
            }

            lblMonthYear.Text = currentDate.ToString("MMMM yyyy");
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

                MeetingForm newMeeting = new MeetingForm(dbHelper,userID);
                newMeeting.dtpDate.Text = dateText;
                newMeeting.dtpTime.Text = "09:00";
                newMeeting.ShowDialog();
            }
        }
        private void LoadEvents() {
            DataTable eventsTable = dbHelper.LoadEvents(currentDate.Year, currentDate.Month);

            foreach (DataRow row in eventsTable.Rows) {
                DateTime eventDate = (DateTime)row["MeetingDate"];
                string eventTitle = row["MeetingTitle"].ToString();
                string eventDay = eventDate.Day.ToString();
                string eventDetails = $"{eventTitle}";

                foreach (Control control in tableLayoutPanelDays.Controls) {
                    if (control is Panel panel && panel.Controls.Count > 1) {
                        // Panelin içindeki ListBox'ı ve Label'ı bul
                        ListBox lstEvents = panel.Controls[1] as ListBox;
                        Label lblDay = panel.Controls[0] as Label;

                        if (lblDay.Text == eventDay) {
                            // ListBox'ı stilize et
                            lstEvents.Items.Add(eventDetails);
                            lstEvents.ForeColor = Color.White; // Yazı rengi
                            lstEvents.BackColor = Color.FromArgb(255, 153, 51);
                            lstEvents.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Yazı tipi ve boyutu

                            // Label'ı stilize et
                            lblDay.AutoEllipsis = true;

                            break;
                        }
                    }
                }

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

        private void refCalendar_Click(object sender, EventArgs e) {
            DisplayDays();
            LoadEvents();
        }

        private void close_Viewpanel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
