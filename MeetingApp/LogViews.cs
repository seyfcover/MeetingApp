using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace MeetingApp
{
    public partial class LogViews : Form
    {
        private DatabaseHelper dbHelper;

        public LogViews(DatabaseHelper dbHelper) {
            InitializeComponent();
            this.dbHelper = dbHelper;
        }

        private void LogViews_Load(object sender, EventArgs e) {
            LoadLogs(); // İlk başta 200 log getir
            LoadLogTypes(); // Log türlerini ComboBox'a yükle
            InitializeDatePickers(); // Tarih aralığını belirle
            dataGridViewLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Kolonları doldur
            dataGridViewLogs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırları hücre içeriğine göre ayarla
            dataGridViewLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dataGridViewLogs.CellFormatting += dataGridViewLogs_CellFormatting;
        }

        // LogType'a göre renklendirme yapmak için CellFormatting event'i
        private void dataGridViewLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            // Sadece "LogType" sütununu işlemek için kontrol edin
            if (dataGridViewLogs.Columns[e.ColumnIndex].Name == "LogType") {
                // Hücredeki değeri al
                var cellValue = dataGridViewLogs.Rows[e.RowIndex].Cells["LogType"].Value;

                // Hücre değeri null değilse ve boş değilse işleme devam edin
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString())) {
                    string logType = cellValue.ToString();

                    // LogType'a göre renklendirme yap
                    if (logType == "Ekleme") {
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;  // Açık Mavi
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    } else if (logType == "Düzenleme") {
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;  // Açık Turuncu
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    } else if (logType == "Silme") {
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkRed;  // Koyu Kırmızı
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Giriş") {
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;  // Açık Yeşil
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    } else if (logType == "Çıkış") {
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DimGray;  // Koyu Gri
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    } else if (logType == "Hata") {
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;  // Parlak Kırmızı
                        dataGridViewLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void LoadLogs(string logType = "", DateTime? startDate = null, DateTime? endDate = null) {
            // SQL sorgusunu oluştur
            string query = "SELECT TOP 300 LogType, LogDate, LogDescription FROM Logs WHERE 1=1";

            // Parametreleri ekle
            var parameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(logType) && logType != "Tümü") {
                query += " AND LogType = @LogType";
                parameters.Add(new SqlParameter("@LogType", logType));
            }

            if (startDate.HasValue && endDate.HasValue) {
                query += " AND LogDate BETWEEN @StartDate AND @EndDate";
                parameters.Add(new SqlParameter("@StartDate", startDate.Value));
                parameters.Add(new SqlParameter("@EndDate", endDate.Value));
            }
            query += " ORDER BY LogDate DESC";

            // DatabaseHelper sınıfını kullanarak veriyi getir
            DataTable dt = dbHelper.ExecuteQuery(query, parameters.ToArray());
            dataGridViewLogs.DataSource = dt; // Veriyi DataGridView'e yükle
        }

        private void LoadLogTypes() {
            // Log türlerini almak için SQL sorgusu
            string query = "SELECT DISTINCT LogType FROM Logs";

            DataTable dt = dbHelper.ExecuteQuery(query);
            comboBoxLogType.Items.Clear();
            comboBoxLogType.Items.Add("Tümü");

            foreach (DataRow row in dt.Rows) {
                comboBoxLogType.Items.Add(row["LogType"].ToString());
            }

            comboBoxLogType.SelectedIndex = 0; // Varsayılan olarak "Tümü" seçili olacak
        }

        private void InitializeDatePickers() {
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1); // Varsayılan olarak son 1 ay
            dateTimePickerEnd.Value = DateTime.Now; // Varsayılan olarak bugün
        }

        private void btnFilter_Click(object sender, EventArgs e) {
            string selectedLogType = comboBoxLogType.SelectedItem.ToString();
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;

            LoadLogs(selectedLogType, startDate, endDate); // Logları seçilen tür ve tarih aralığına göre yükle
        }

        private void btnClearFilter_Click(object sender, EventArgs e) {
            comboBoxLogType.SelectedIndex = 0; // "Tümü" seçeneğini seç
            InitializeDatePickers(); // Tarih aralıklarını sıfırla
            LoadLogs(); // Tüm logları tekrar yükle (varsayılan tarih aralığı ile)
        }
    }
}
