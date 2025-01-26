using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class NewRequestForm : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;


        public NewRequestForm(DatabaseHelper dbHelper, int userID, string fullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            FullName = fullName;
            GetMyRequests(dgvMyRequests);
        }
        private void GetMyRequests(DataGridView dgv) {
            
            try {
                // Kullanıcının taleplerini al
                List<Tuple<DateTime, string, bool>> requests = dbHelper.GetRequest(userID);

                // DataGridView'in sütunlarını kontrol et ve ekle
                if (dgv.Columns.Count == 0) {
                    dgv.Columns.Add("CreateTime", "Tarih");
                    dgv.Columns.Add("Note", "Talep");
                    dgv.Columns.Add("IsComplete", "Durum");
                    dgv.Columns["IsComplete"].Visible = false; // Durum sütununu gizle
                    dgvMyRequests.Columns[0].Frozen = true;
                }

                // DataGridView'i temizle
                dgv.Rows.Clear();

                // Eğer kayıt varsa ekle
                if (requests.Count > 0) {
                    foreach (var request in requests) {
                        // Satır ekle
                        int rowIndex = dgv.Rows.Add(request.Item1.ToString("yyyy-MM-dd HH:mm"), request.Item2, request.Item3 ? "Tamamlandı" : "Tamamlanmadı");

                        // Durumuna göre satırı yeşil veya normal yap
                        if (request.Item3) {
                            dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen; // Tamamlandıysa yeşil yap
                        } else {
                            dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Salmon; // Tamamlanmadıysa normal bırak
                        }
                    }
                } else {
                    dgv.Rows.Add("Herhangi bir talebiniz bulunmamaktadır.", "", "");
                }
            } catch (Exception ex) {
                MessageBox.Show("Talepler getirilirken hata oluştu: " + ex.Message);
            }
        }





        private void btnSendRequest_Click(object sender, EventArgs e) {
            // Kullanıcının girdisini kontrol et
            if (txtRequest.TextLength <= 50) {
                MessageBox.Show("Talebiniz 50 karakterden uzun olmalı.");
                return;
            }
            if (txtRequest.TextLength >= 254) {
                MessageBox.Show("Talebiniz 255 karakterden kısa olmalı.");
                return;
            }

            // Talebi veritabanına ekleme işlemi
            bool success = dbHelper.InsertRequest(userID, txtRequest);

            if (success) {
                MessageBox.Show("Talep başarıyla gönderildi.");
                dbHelper.AddLog("Ekleme", $"Kullanıcı {FullName} talep oluşturdu.");
            } else {
                MessageBox.Show("Talep gönderilirken hata oluştu.");
                dbHelper.AddLog("Hata", $"Kullanıcı {FullName} talep oluştururken hata oluştu.");
            }
            GetMyRequests(dgvMyRequests);
        }

        private void dgvMyRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) { // Ensure the clicked row is valid
                                   // Get the value from the second column (Note)
                string requestNote = dgvMyRequests.Rows[e.RowIndex].Cells[1].Value.ToString();

                // Show the request note in a message box or use it as needed
                MessageBox.Show("Talep: " + requestNote);
            }
        }
    }
}
