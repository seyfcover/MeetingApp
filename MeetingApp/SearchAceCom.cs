using MeetingApp;
using System;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class SearchAceCom : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;
        public SearchAceCom(DatabaseHelper databaseHelper, int userID, string fullName) {
            InitializeComponent();
            dbHelper = databaseHelper;
            this.userID = userID;
            FullName = fullName;
            // Başlangıçta kolon adlarını al ve göster
            DisplayAcademics();
            DisplayCompanies();
            
        }

        private void DisplayAcademics() {
            DataTable academics = dbHelper.GetAcademics();
            lstAcademics.Items.Clear();
            foreach (DataRow row in academics.Rows) {
                lstAcademics.Items.Add($"{row["FirstName"]} {row["LastName"]} - {row["keyWords"]}");
            }
        }

        private void DisplayCompanies() {
            DataTable companies = dbHelper.GetCompanies();
            lstCompanies.Items.Clear();
            foreach (DataRow row in companies.Rows) {
                lstCompanies.Items.Add($"{row["name"]} - {row["FieldsOfActivity"]}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string searchTerm = txtSearch.Text;
            DataTable results = dbHelper.SearchAcademicsAndCompanies(searchTerm);
            dataGridViewResults.DataSource = results;
            // ID sütununu gizle
            if (dataGridViewResults.Columns["ID"] != null) {
                dataGridViewResults.Columns["ID"].Visible = false;
            }
        }

        private void dataGridViewResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {  // Geçerli bir satır seçildiyse
                DataGridViewRow selectedRow = dataGridViewResults.Rows[e.RowIndex];

                string selectedType = selectedRow.Cells["Tip"].Value.ToString(); // 'Academic' ya da 'Company'
                string selectedId = selectedRow.Cells["ID"].Value.ToString();   // ID değerini al

                if (selectedType == "Academic") {
                    UpdateAcedemic updateAcedemic = new UpdateAcedemic(dbHelper,userID,FullName);
                    updateAcedemic.listofAcedemics.SelectedValue = selectedId;
                    updateAcedemic.FormClosed += btnSearch_Click;
                    updateAcedemic.ShowDialog();
                    
                    
                } else if (selectedType == "Company") {
                    UpdateCompanyForm updateCompany = new UpdateCompanyForm(dbHelper, userID, FullName);
                    updateCompany.cmbCompany.SelectedValue = selectedId;
                    updateCompany.FormClosed += btnSearch_Click;
                    updateCompany.ShowDialog();
                    
                }
            }
        }
        
    }
}
