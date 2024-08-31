using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class ViewDocumentsForm : Form
    {
        // Listeleri burada tanımlayın
        private List<byte[]> documentDataList;
        private List<string> fileNames;
        private List<string> documentTypes;
        private string connectionString;
        
        public ViewDocumentsForm(int meetingId, string conn) {
            InitializeComponent();
            connectionString = conn;
            // Listeleri kurucuda başlatın
            documentDataList = new List<byte[]>();
            fileNames = new List<string>();
            documentTypes = new List<string>();

            // Belgeleri yükleyin
            LoadDocuments(meetingId);
        }

        private void LoadDocuments(int meetingId) {
            // Veritabanından document bilgilerini çekin ve listeleri doldurun
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                string query = "SELECT DocumentData, FileName, DocumentType FROM MeetingDocuments WHERE MeetingID = @MeetingID";
                using (SqlCommand command = new SqlCommand(query, conn)) {
                    command.Parameters.AddWithValue("@MeetingID", meetingId);

                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            byte[] documentData = (byte[])reader["DocumentData"];
                            string fileName = reader["FileName"].ToString();
                            string documentType = reader["DocumentType"].ToString();

                            documentDataList.Add(documentData);
                            fileNames.Add(fileName);
                            documentTypes.Add(documentType);

                            // ListBox'a dosya adını ekleyin
                            documentsListBox.Items.Add(fileName);
                        }
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void documentsListBox_DoubleClick(object sender, EventArgs e) {
            if (documentsListBox.SelectedIndex == -1) {
                MessageBox.Show("Lütfen açmak için bir döküman seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] documentData = documentDataList[documentsListBox.SelectedIndex];
            string fileName = fileNames[documentsListBox.SelectedIndex];
            string tempFilePath = Path.Combine(Path.GetTempPath(), fileName);

            // Dökümanı geçici dosya olarak kaydet
            File.WriteAllBytes(tempFilePath, documentData);

            // Dosyayı varsayılan uygulama ile aç
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(tempFilePath) { UseShellExecute = true });
        }
    }
}
