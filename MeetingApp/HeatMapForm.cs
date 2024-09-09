using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace MeetingApp
{
    public partial class HeatMapForm : Form
    {
        private DatabaseHelper dbHelper;
        private DateTime start, end;

        public HeatMapForm(DatabaseHelper dbHelper, DateTime start, DateTime end) {
            this.dbHelper = dbHelper;
            this.start = start;
            this.end = end;
            InitializeComponent();
            LoadHeatMap();
        }

        private void LoadHeatMap() {
            var startDate = start.Date; // Başlangıç tarihi
            var endDate = end.Date; // Bitiş tarihi

            var data = GetHeatMapData(startDate, endDate);
            var model = new PlotModel { Title = "Isı Haritası", Background = OxyColors.White }; // Arka planı beyaz yap

            // Isı Haritası serisini oluşturun
            var heatMapSeries = new HeatMapSeries {
                X0 = 0,
                X1 = 6, // Haftanın günleri (0-6)
                Y0 = 0,
                Y1 = 11, // Saatler 08:00-19:00 (0-11 aralığı)
                Interpolate = false,
                Data = data
            };

            // Özel renk paletini tanımlayın (beyazdan başlar, mavinin tonlarına geçiş yapar)
            var colorAxis = new LinearColorAxis {
                Position = AxisPosition.Right,
                Minimum = 0,
                Maximum = data.Cast<double>().Max(),
                Title = "Toplantı Sayısı",
                Palette = OxyPalette.Interpolate(100, OxyColors.White, OxyColors.LightBlue, OxyColors.Blue, OxyColors.DarkBlue), // Beyazdan maviye geçiş
                LowColor = OxyColors.White // Düşük değerler için beyaz renk
            };

            // X eksenini (Günler) tanımlayın
            var xAxis = new CategoryAxis {
                Position = AxisPosition.Bottom,
                Title = "Günler",
                ItemsSource = new[] { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" },
                LabelFormatter = value => {
                    int index = (int)value;
                    return index >= 0 && index < 7 ? new[] { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" }[index] : "";
                }
            };

            // Y eksenini (Saatler) 08:00-19:00 aralığına çekin
            var yAxis = new CategoryAxis {
                Position = AxisPosition.Left,
                Title = "Saatler",
                ItemsSource = Enumerable.Range(8, 12).Select(h => h.ToString("D2") + ":00").ToArray(),
                LabelFormatter = value => {
                    int index = (int)value;
                    return index >= 0 && index < 12 ? Enumerable.Range(8, 12).Select(h => h.ToString("D2") + ":00").ToArray()[index] : "";
                }
            };

            // Modeli güncelleyin
            model.Series.Add(heatMapSeries);
            model.Axes.Add(xAxis); // Günler eksenini modele ekleyin
            model.Axes.Add(yAxis); // Saatler eksenini modele ekleyin
            model.Axes.Add(colorAxis); // Renk eksenini modele ekleyin

            plotViewHeatMap.Model = model;
        }

        private double[,] GetHeatMapData(DateTime startDate, DateTime endDate) {
            DataTable dt = dbHelper.GetMeetingDataForHeatMap(startDate, endDate);
            double[,] data = new double[7, 12]; // 08:00-19:00 arası saatler (8'den 19'a kadar 12 saat)

            foreach (DataRow row in dt.Rows) {
                int weekDay = Convert.ToInt32(row["WeekDay"]) - 1; // Haftanın günleri (1-7) -> (0-6)
                int hour = Convert.ToInt32(row["Hour"]);
                if (hour >= 8 && hour <= 19) { // Sadece 08:00-19:00 saatleri arasında olan toplantılar
                    int adjustedHour = hour - 8; // Saat aralığını 0-11 yapmak için 8 çıkarıyoruz
                    int count = Convert.ToInt32(row["MeetingCount"]);
                    data[weekDay, adjustedHour] = count;
                }
            }

            return data;
        }
    }
}
