using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class RequestManagement : Form
    {
        private DatabaseHelper dbHelper;
        private int userID;
        private string FullName;


        public RequestManagement(DatabaseHelper dbHelper, int userID, string fullName) {
            InitializeComponent();
            this.dbHelper = dbHelper;
            this.userID = userID;
            FullName = fullName;
            GetAllRequests(dgvMyRequests);
            Permissions(userID);
        }

        private void Permissions(int userID) {

            byte isAdmin = dbHelper.isAdmin(userID);
            if (isAdmin == 4 || isAdmin == 2) {
                btnDelRequest.Visible = true;
                btnDelRequest.Enabled = true;
            } 
        }
        private void GetAllRequests(DataGridView dgv) {
            try {
                // Tüm talepleri al
                List<Tuple<int, DateTime, string, string>> requests = dbHelper.GetAllRequests();

                // DataGridView'in sütunlarını kontrol et ve ekle
                if (dgv.Columns.Count == 0) {
                    dgv.Columns.Add("RequestID", "Talep ID");
                    dgv.Columns.Add("CreateTime", "Tarih");
                    dgv.Columns.Add("Note", "Talep");
                    dgv.Columns.Add("UserFullName", "Kullanıcı");
                    dgv.Columns.Add("Status", "Durum");

                    dgv.Columns["RequestID"].Visible = false; // Talep ID sütununu gizle
                    dgv.Columns[1].Frozen = true; // Tarih sütununu sabitle
                }

                // DataGridView'i temizle
                dgv.Rows.Clear();

                // Eğer kayıt varsa ekle
                if (requests.Count > 0) {
                    foreach (var request in requests) {
                        // Kullanıcı adı ve durum bilgisi ayrıştırılıyor
                        string[] userAndStatus = request.Item4.Split(new string[] { " - " }, StringSplitOptions.None);
                        string userFullName = userAndStatus[0];
                        string status = userAndStatus[1];

                        // Satır ekle
                        int rowIndex = dgv.Rows.Add(request.Item1,
                                                    request.Item2.ToString("yyyy-MM-dd HH:mm"),
                                                    request.Item3,
                                                    userFullName,
                                                    status);

                        // Durumuna göre satırı yeşil veya kırmızı yap
                        if (status == "Tamamlandı") {
                            dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen; // Tamamlandıysa yeşil yap
                        } else {
                            dgv.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Salmon; // Tamamlanmadıysa kırmızı yap
                        }
                    }
                } else {
                    dgv.Rows.Add("Herhangi bir talep bulunmamaktadır.", "", "", "", "");
                }
            } catch (Exception ex) {
                MessageBox.Show("Talepler getirilirken hata oluştu: " + ex.Message);
                dbHelper.AddLog("Hata", $"Talepler getirilirken hata oluştu. {ex.Message}");
            }
        }
        private void dgvMyRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) { // Ensure the clicked row is valid
                                   // Get the value from the second column (Note)
                string requestNote = dgvMyRequests.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Show the request note in a message box or use it as needed
                MessageBox.Show("Talep: " + requestNote);
            }
        }

        private void btnConfirmRequest_Click(object sender, EventArgs e) {
            if (dgvMyRequests.SelectedRows.Count > 0) {
                // Seçili satırdan RequestID değerini al ve geçerli bir sayı olup olmadığını kontrol et
                var requestIDValue = dgvMyRequests.SelectedRows[0].Cells["RequestID"].Value;
                string requestOwner = dgvMyRequests.SelectedRows[0].Cells["UserFullName"].Value.ToString();
                if (requestIDValue != null && int.TryParse(requestIDValue.ToString(), out int requestID)) {
                    // Talebi onayla
                    if (dbHelper.ConfirmRequest(requestID)) {
                        MessageBox.Show("Talep başarıyla onaylandı.");
                        dbHelper.AddLog("Güncelleme", $"{FullName} {requestOwner} adlı kullanıcının talebini onayladı");
                        GetAllRequests(dgvMyRequests); // DataGridView'i güncelle

                    } else {
                        MessageBox.Show("Talep onaylanırken hata oluştu.");
                        dbHelper.AddLog("Hata", $"{FullName} {requestOwner} adlı kullanıcının talebini onaylarken hata oluştu");
                    }
                } else {
                    MessageBox.Show("Geçersiz ID değeri. Lütfen geçerli bir talep seçin.");
                }
            } else {
                MessageBox.Show("Lütfen bir talep seçin.");
            }
        }


        private void btnDelRequest_Click(object sender, EventArgs e) {
            if (dgvMyRequests.SelectedRows.Count > 0) {
                // Seçili satırdan RequestID değerini al ve geçerli bir sayı olup olmadığını kontrol et
                var requestIDValue = dgvMyRequests.SelectedRows[0].Cells["RequestID"].Value;
                string requestOwner = dgvMyRequests.SelectedRows[0].Cells["UserFullName"].Value.ToString();

                if (requestIDValue != null && int.TryParse(requestIDValue.ToString(), out int requestID)) {
                    // Kullanıcıdan silme onayı al
                    DialogResult result = MessageBox.Show("Bu talebi silmek istediğinizden emin misiniz?",
                                                          "Talep Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes) {
                        // Veritabanından talebi sil
                        if (dbHelper.DeleteRequest(requestID)) {
                            MessageBox.Show("Talep başarıyla silindi.");
                            dbHelper.AddLog("Silme", $"{FullName} {requestOwner} adlı kullanıcının talebini sildi");
                            GetAllRequests(dgvMyRequests); // DataGridView'i güncelle
                        } else {
                            MessageBox.Show("Talep silinirken bir hata oluştu.");
                            dbHelper.AddLog("Hata", $"{FullName} {requestOwner} adlı kullanıcının talebini silerken hata oluştu");
                        }
                    }
                } else {
                    MessageBox.Show("Geçersiz ID değeri. Lütfen geçerli bir talep seçin.");
                }
            } else {
                MessageBox.Show("Lütfen silmek için bir talep seçin.");
            }
        }


        private void txtboxSearch_TextChanged(object sender, EventArgs e) {
            string searchText = txtboxSearch.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvMyRequests.Rows) {
                if (row.Cells["CreateTime"].Value != null &&
                    row.Cells["Note"].Value != null &&
                    row.Cells["UserFullName"].Value != null &&
                    row.Cells["Status"].Value != null) {
                    string createTime = row.Cells["CreateTime"].Value.ToString().ToLower();
                    string note = row.Cells["Note"].Value.ToString().ToLower();
                    string userFullName = row.Cells["UserFullName"].Value.ToString().ToLower();
                    string status = row.Cells["Status"].Value.ToString().ToLower();

                    // Arama kriteri CreateTime, Note, UserFullName veya Status alanlarından herhangi birinde bulunuyorsa göster
                    if (createTime.Contains(searchText) ||
                        note.Contains(searchText) ||
                        userFullName.Contains(searchText) ||
                        status.Contains(searchText)) {
                        row.Visible = true;
                    } else {
                        row.Visible = false;
                    }
                }
            }
        }

    }
}
