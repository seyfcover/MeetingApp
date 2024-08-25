using System;
using System.Data;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class CandidateCompanies : Form
    {
        private DatabaseHelper dbHelper;
        public CandidateCompanies(DatabaseHelper dbHelper) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            LoadCandidateCompanies();
        }

        private void LoadCandidateCompanies() {
            // DataSource null olarak ayarlandığında satırlar temizlenir, bu yüzden Rows.Clear() çağırmaya gerek yok.
            DataCompanies.DataSource = null;
            InitializeDataGridViewColumns();
            // Veritabanından şirket bilgilerini çekiyoruz
            DataTable companiesTable = dbHelper.GetCandidateCompanies();

            if (companiesTable != null) {
                // DataTable'ı sıralıyoruz
                DataView dataView = companiesTable.DefaultView;
                dataView.Sort = "Points DESC"; // 'Points' sütununa göre azalan sıralama

                // Performansı artırmak için DataGridView'in güncellenmesini durduruyoruz
                DataCompanies.SuspendLayout();

                // Sıralı DataView'den her bir DataRow için işlem yapıyoruz
                foreach (DataRowView rowView in dataView) {
                    DataRow row = rowView.Row;

                    // DataGridView'deki sütun sayısını kontrol ediyoruz
                    if (DataCompanies.ColumnCount < 4) {
                        MessageBox.Show("DataGridView'de yeterli sütun yok.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Yeni bir DataGridView satırı oluşturuyoruz
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(DataCompanies);

                    // Kolonlara verileri atıyoruz
                    dgvRow.Cells[0].Value = row["Name"];
                    dgvRow.Cells[1].Value = row["FieldsOfActivity"];
                    dgvRow.Cells[2].Value = row["Phone"];
                    dgvRow.Cells[3].Value = row["Points"];

                    // Satırı DataGridView'e ekliyoruz
                    DataCompanies.Rows.Add(dgvRow);
                }

                // Güncellemeyi yeniden başlatıyoruz
                DataCompanies.ResumeLayout();
            } else {
                MessageBox.Show("Şirket bilgileri alınamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void button1_Click(object sender, EventArgs e) {
            LoadCandidateCompanies();
        }
    }
}
