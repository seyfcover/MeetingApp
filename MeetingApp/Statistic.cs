using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MeetingApp.Models;


namespace MeetingApp
{
    public partial class Statistic : Form
    {
        private DatabaseHelper dbHelper;
        private Form heatMapForm = null;

        public Statistic(DatabaseHelper databaseHelper) {
            InitializeComponent();
            dbHelper = databaseHelper;
            InitializeHeatMap();
        }

        private void Statistic_Load(object sender, EventArgs e) {
            LoadAttendanceRateChart();
            LoadParticipantMeetingData();


        }
        private void InitializeHeatMap() {
            if (heatMapForm == null || heatMapForm.IsDisposed) {
                // HeatMapForm'u oluştur
                DateTime startDate = dtpStart.Value.Date;
                DateTime endDate = dptEnd.Value.Date.AddDays(1).AddTicks(-1);
                heatMapForm = new HeatMapForm(dbHelper,startDate, endDate);
                heatMapForm.TopLevel = false; // Form'u panel içinde göstermek için
                heatMapForm.FormBorderStyle = FormBorderStyle.None; // Kenarlık ve başlık çubuğu yok
                heatMapForm.Dock = DockStyle.Fill; // Panel içinde formu doldur
                
                // Panel düzenlemelerini geçici olarak durdur
                panel1.SuspendLayout();
                // Panel içeriğini temizle
                panel1.Controls.Clear();
                // Form'u panel içine ekle
                panel1.Controls.Add(heatMapForm);
                // Panel düzenlemelerini yeniden başlat
                panel1.ResumeLayout();

                // Form'u panel'in üstünde göster
                heatMapForm.BringToFront();
                // Form'u göster
                heatMapForm.Show();
            }
        }
        private void LoadParticipantMeetingData() {
            try {
                DateTime startDate = dtpStart.Value.Date;
                DateTime endDate = dptEnd.Value.Date.AddDays(1).AddTicks(-1);
                // Verileri al
                List<ParticipantMeetingData> data = dbHelper.GetParticipantMeetingDataForUsers(startDate,endDate);

                // DataGridView'i temizle
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Kolonları ekle
                dataGridView1.Columns.Add("FullName", "İsim");
                dataGridView1.Columns.Add("MeetingCount", "Katıldığı Toplantı Sayısı");

                // Verileri DataGridView'e ekle
                foreach (var item in data) {
                    dataGridView1.Rows.Add(item.FullName, item.MeetingCount);
                }

                // DataGridView ayarlarını yap
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Kolonları doldur
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırları hücre içeriğine göre ayarla
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Başlıkları otomatik boyutlandır
            } catch (Exception ex) {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void LoadAttendanceRateChart() {
            try {
                DateTime startDate = dtpStart.Value.Date;
                DateTime endDate = dptEnd.Value.Date.AddDays(1).AddTicks(-1);
                // Yalnızca kullanıcı verilerini yükle
                List<ParticipantMeetingData> data = dbHelper.GetParticipantMeetingDataForUsers(startDate,endDate);

                // Toplam toplantı sayısını hesapla
                int totalMeetings = dbHelper.GetTotalMeetingCount(startDate, endDate);

                // Katılım oranını hesapla
                foreach (var item in data) {
                    item.MeetingCount = totalMeetings > 0 ? (item.MeetingCount / (float)totalMeetings) * 100f : 0f;
                }

                // Chart kontrolünü temizle
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Legends.Clear();

                // Grafik alanı oluştur
                ChartArea chartArea = new ChartArea {
                    Name = "AttendanceRateChartArea",
                    AxisX = {
             Title = "Kullanıcılar",
             Interval = 1,
             TitleFont = new Font("Century Gothic", 12F, FontStyle.Bold),
             TitleForeColor = Color.Black
         },
                    AxisY = {
             Title = "Katılım Oranı (%)",
             Interval = 10,
             Minimum = 0,
             Maximum = 100,
             TitleFont = new Font("Century Gothic", 12F, FontStyle.Bold),
             TitleForeColor = Color.Black
         },
                    AxisX2 = { Enabled = AxisEnabled.False },
                    BackColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 2
                };

                // Grafik alanını ekle
                chart1.ChartAreas.Add(chartArea);

                // Legend (açıklama) oluştur
                Legend legend = new Legend {
                    Name = "AttendanceRateLegend",
                    Alignment = StringAlignment.Center,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black
                };

                // Legend'ı ekle
                chart1.Legends.Add(legend);

                // Seri oluştur
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series {
                    Name = "Katılım Oranı",
                    ChartType = SeriesChartType.Column, // Dikey sütun grafik türü
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Single, // Yüzde değeri
                    BorderColor = Color.Black,
                    BorderWidth = 2,
                    IsValueShownAsLabel = true
                };

                // Rastgele renkler için bir renk listesi oluştur
                Random random = new Random();

                // Seri için veri ekle
                foreach (var item in data) {
                    DataPoint dataPoint = new DataPoint {
                        AxisLabel = item.FullName,
                        YValues = new[] { (double)item.MeetingCount } // Katılım oranını gösterir
                    };

                    // Rastgele renk seçimi
                    dataPoint.Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    dataPoint.IsValueShownAsLabel = true; // Değer etiketlerini göster
                    dataPoint.Label = $"{item.MeetingCount:F1}%"; // Katılım oranını formatlı olarak göster
                    dataPoint.LabelForeColor = Color.Black; // Etiket rengini ayarla
                    series.Points.Add(dataPoint);
                }

                // Seri grafiğe ekle
                chart1.Series.Add(series);

                // Grafik başlıklarını ayarla
                chart1.Titles.Clear();
                chart1.Titles.Add(new Title {
                    Text = "Kullanıcı Katılım Oranı",
                    Font = new Font("Century Gothic", 14, FontStyle.Bold),
                    ForeColor = Color.Black
                });
            } catch (Exception ex) {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            heatMapForm = null;
            // Tarih aralığının geçerliliğini kontrol et
            if (dtpStart.Value > dptEnd.Value) {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden sonra olamaz. Lütfen geçerli bir tarih aralığı seçin.", "Geçersiz Tarih Aralığı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Hatalı tarih aralığı durumunda işlemi durdur
            }
            LoadAttendanceRateChart();
            LoadParticipantMeetingData();
            InitializeHeatMap();
        }
    }
}
