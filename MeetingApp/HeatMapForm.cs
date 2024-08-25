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
        public HeatMapForm(DatabaseHelper dbHelper,DateTime start, DateTime end) {
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
            var model = new PlotModel { Title = "Isı Haritası" };

           
           

            // Isı Haritası serisini oluşturun
            var heatMapSeries = new HeatMapSeries {
                X0 = 0,
                X1 = 6, // Haftanın günleri (0-6)
                Y0 = 0,
                Y1 = 23, // Saatler (0-23)
                Interpolate = false,
                Data = data
            };

            // Renk eksenini tanımlayın
            var colorAxis = new LinearColorAxis {
                Position = AxisPosition.Right,
                Minimum = 0,
                Maximum = data.Cast<double>().Max(),
                Title = "Toplantı Sayısı"
            };

            // X eksenini (Günler) tanımlayın
            var xAxis = new CategoryAxis {
                Position = AxisPosition.Bottom,
                Title = "Günler",
                ItemsSource = new[] { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" },
                LabelFormatter = value => {
                    // Günler ekseninde değerler 0-6 arasında olacak
                    int index = (int)value;
                    return index >= 0 && index < 7 ? new[] { "Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi" }[index] : "";
                }
            };

            // Y eksenini (Saatler) tanımlayın
            var yAxis = new CategoryAxis {
                Position = AxisPosition.Left,
                Title = "Saatler",
                ItemsSource = Enumerable.Range(0, 24).Select(h => h.ToString("D2") + ":00").ToArray(),
                LabelFormatter = value => {
                    // Saatler ekseninde değerler 0-23 arasında olacak
                    int index = (int)value;
                    return index >= 0 && index < 24 ? Enumerable.Range(0, 24).Select(h => h.ToString("D2") + ":00").ToArray()[index] : "";
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
            double[,] data = new double[7, 24];

            foreach (DataRow row in dt.Rows) {
                int weekDay = Convert.ToInt32(row["WeekDay"]) - 1; // Haftanın günleri (1-7) -> (0-6)
                int hour = Convert.ToInt32(row["Hour"]);
                int count = Convert.ToInt32(row["MeetingCount"]);

                data[weekDay, hour] = count;
            }

            return data;
        }
    }
}
