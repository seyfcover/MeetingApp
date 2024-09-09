using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class WeeklyCalendarForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;
        private DateTime currentWeekStart;
        private Timer blinkTimer;
        private bool isBlinking = false;
        private Label lblEvent;

        public WeeklyCalendarForm(DatabaseHelper dbHelper, int userID , string FullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            this.FullName = FullName;
            currentWeekStart = GetStartOfWeek(DateTime.Now); // Başlangıç olarak bu haftanın ilk günü 
        }

    


        private void WeeklyCalendarForm_Load(object sender, EventArgs e) {
            DisplayWeekDays();
            LoadWeeklyEvents();
        }

        private void DisplayWeekDays() {
            // Haftanın günlerini tanımlayın
            string[] daysOfWeek = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };

            tableLayoutPanelDays.Controls.Clear();
            tableLayoutPanelDays.ColumnCount = 7;
            tableLayoutPanelDays.RowCount = 2; // Üst satır gün başlıkları, alt satır gün içerikleri

            // Haftanın başlangıcı ve bitişini hesaplayın
            DateTime firstDayOfWeek = currentWeekStart.Date;
            DateTime firstDayOfMonth = new DateTime(firstDayOfWeek.Year, firstDayOfWeek.Month, 1);
            DateTime lastDayOfMonth = new DateTime(firstDayOfWeek.Year, firstDayOfWeek.Month, DateTime.DaysInMonth(firstDayOfWeek.Year, firstDayOfWeek.Month));

            // Gün başlıklarını ekleyin
            for (int i = 0; i < daysOfWeek.Length; i++) {
                DateTime dayDate = firstDayOfWeek.AddDays(i);
                Label lblDayOfWeek = new Label {
                    Text = $"{daysOfWeek[i]} {dayDate.Day}",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Arial", 13, FontStyle.Bold),
                    BackColor = Color.SteelBlue,
                    ForeColor = Color.White,
                    Height = 30
                };
                lblDayOfWeek.Click += LblDay_Click;
                lblDayOfWeek.Tag = dayDate;
                tableLayoutPanelDays.Controls.Add(lblDayOfWeek, i, 0);
            }

            // Gün panellerini ekleyin
            for (int i = 0; i < 7; i++) {
                DateTime dayDate = firstDayOfWeek.AddDays(i);

                TableLayoutPanel dayPanel = new TableLayoutPanel {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 13, // 13 satır oluşturun
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    Padding = new Padding(2),
                    BackColor = Color.Transparent
                };

                // Panell oluşturun
            
                    Panel eventPanel = new Panel {
                        Dock = DockStyle.Fill,
                        Height = 800,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(1),
                        Tag = dayDate
                    };

                    dayPanel.Controls.Add(eventPanel,1,0);
                

                tableLayoutPanelDays.Controls.Add(dayPanel, i, 1); // Gün panellerini 1. satıra ekleyin
            }

            lblWeekRange.Text = $"{currentWeekStart:dd MMMM yyyy} - {currentWeekStart.AddDays(6):dd MMMM yyyy}";
        }


        private void LoadWeeklyEvents() {
            DataTable eventsTable = dbHelper.LoadEventsForWeek(currentWeekStart, currentWeekStart.AddDays(6));
            var eventsByDate = eventsTable.AsEnumerable()
                .GroupBy(row => ((DateTime)row["MeetingDate"]).Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var dateGroup in eventsByDate) {
                DateTime eventDate = dateGroup.Key;
                List<DataRow> events = dateGroup.Value;

                foreach (Control control in tableLayoutPanelDays.Controls) {
                    if (control is TableLayoutPanel dayPanel) {
                        foreach (Control panel in dayPanel.Controls) {
                            if (panel is Panel eventPanel) {
                                // Tag özelliğini kontrol et ve null olup olmadığını doğrula
                                if (eventPanel.Tag is DateTime tagDate && tagDate == eventDate) {
                                    int eventIndex = 0;
                                    int maxEventsPerPanel = 14; // Her panelde gösterilebilecek maksimum etkinlik sayısı
                                    int panelCount = dayPanel.Controls.OfType<Panel>().Count();

                                    foreach (DataRow row in events) {
                                        if (eventIndex >= maxEventsPerPanel) {
                                            // Eğer etkinlik sayısı sınırı aşarsa döngüyü kırın
                                            break;
                                        }

                                        // Etkinlik için bir label oluşturun ve mevcut panelin içine ekleyin
                                        Panel currentPanel = dayPanel.Controls.OfType<Panel>()
                                            .Skip((eventIndex / maxEventsPerPanel) % panelCount)
                                            .First();

                                        Label lblEvent = new Label {
                                            Text = row["MeetingTitle"].ToString(),
                                            Dock = DockStyle.Top,
                                            TextAlign = ContentAlignment.MiddleCenter,
                                            BackColor = GetColorForEvent(row["MeetingType"].ToString()),
                                            ForeColor = Color.WhiteSmoke,
                                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                            Tag = new KeyValuePair<int, string>(Convert.ToInt32(row["MeetingID"]), row["MeetingTitle"].ToString()),
                                            Height = 50
                                        };

                                        // Eğer toplantı önemliyse yanıp sönme özelliğini ekleyin
                                        if (Convert.ToBoolean(row["isImportant"])) {
                                            lblEvent.BackColor = GetColorForEvent(row["MeetingType"].ToString()); // Başlangıç rengi
                                            InitializeBlinking(lblEvent, GetColorForEvent(row["MeetingType"].ToString())); // Her bir label için yanıp sönme işlevini başlat
                                        }

                                        lblEvent.Click += LblEvent_Click;
                                        currentPanel.Controls.Add(lblEvent);

                                        eventIndex++;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }





        // Her bir Label için yanıp sönme işlevini başlatmak için
        private void InitializeBlinking(Label lblEvent, Color originalColor) {
            Timer blinkTimer = new Timer {
                Interval = 500 // Yanıp sönme aralığı (milisaniye cinsinden)
            };
            blinkTimer.Tick += (sender, e) => BlinkTimer_Tick(sender, e, lblEvent, originalColor);
            blinkTimer.Start();
        }

        // Timer'ın Tick olayında rengi değiştirirse
        private void BlinkTimer_Tick(object sender, EventArgs e, Label lblEvent, Color originalColor) {
            Timer timer = (Timer)sender;
            if (lblEvent != null) {
                // Yanıp sönme durumunu kontrol et
                if (lblEvent.BackColor == originalColor) {
                    lblEvent.BackColor = Color.Transparent;
                    lblEvent.ForeColor = Color.Black;
                    // İlk durumda şeffaf yap
                } else {
                    lblEvent.BackColor = originalColor;
                    lblEvent.ForeColor = Color.WhiteSmoke;// Şeffaflıktan sonra orijinal renge döner
                }
            }
        }

        private void LblEvent_Click(object sender, EventArgs e) {
            if (sender is Label lblEvent && lblEvent.Tag is KeyValuePair<int, string> eventDetails) {
                int selectedEventID = eventDetails.Key;
                if (selectedEventID > 0) {
                    UpdateMeeting eventForm = new UpdateMeeting(dbHelper, userID , FullName) {
                        _selectedMeetingID = selectedEventID
                    };
                    eventForm.listofMeetings_SelectedIndexChanged(null, null);
                    eventForm.dtpDate.Value = Convert.ToDateTime(eventForm.dtpDate.Value);
                    eventForm.FormClosed += UpdateMeeting_FormClosed;
                    eventForm.ShowDialog();
                }
            }
        }
        private Color GetColorForEvent(string type) {
            // Renkler listesini tanımlayın
            var eventColors = new Dictionary<string, Color> {
                { "üsi", Color.DarkBlue },          // Açık Mavi
                { "girişimcilik", Color.OrangeRed },   // Açık Yeşil
                { "fsmh", Color.Maroon }, // Açık Sarı
                { "süreç yönetimi", Color.ForestGreen }, // Açık Turuncu
                { "etkinlik", Color.Purple },
                { "uluslararasılaşma", Color.DarkSlateGray },
                { "genel/tto", Color.Teal }  // Açık Mor
            };

            // `type` değerine göre uygun renk döndürme
            return eventColors.TryGetValue(type.ToLower(), out var color) ? color : Color.LightGray;
        }


        private void btnPreviousWeek_Click(object sender, EventArgs e) {
            currentWeekStart = currentWeekStart.AddDays(-7);
            DisplayWeekDays();
            LoadWeeklyEvents();
        }

        private void btnNextWeek_Click(object sender, EventArgs e) {
            currentWeekStart = currentWeekStart.AddDays(7);
            DisplayWeekDays();
            LoadWeeklyEvents();
        }

        public void refCalendar_Click(object sender, EventArgs e) {
            DisplayWeekDays();
            LoadWeeklyEvents();
        }

        private DateTime GetStartOfWeek(DateTime date) {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        private void UpdateMeeting_FormClosed(object sender, FormClosedEventArgs e) {
            refCalendar_Click(null, null);
        }

        private void LblDay_Click(object sender, EventArgs e) {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null) {
                DateTime dayDate = (DateTime)clickedLabel.Tag;
                string dateText = dayDate.ToString("dd MMMM yyyy");

                MeetingForm newMeeting = new MeetingForm(dbHelper, userID, FullName) {
                    dtpDate = { Text = dateText },
                    dtpTime = { Text = "09:00" }
                };
                newMeeting.FormClosed += UpdateMeeting_FormClosed;
                newMeeting.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
