using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MeetingApp
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            string server = txtServer.Text;
            string port = txtPort.Text;
            string database = txtDatabase.Text;
            string userId = txtUserId.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(database)) {
                MessageBox.Show("Don't forget to enter the database name");
                return;
            }

            // Önce bağlantı dizisini geçici olarak test 
            if (TestDatabaseConnection(server, port, database, userId, password)) {
                // Bağlantı başarılıysa, bağlantı dizisini güncelle veya oluştur
                if (UpdateConnectionString(server, port, database, userId, password)) {
                    // Şifreleme işlemi
                    EncryptConnectionStringsSection();

                    // Kullanıcıya uygulamayı yeniden başlatmaları gerektiğini bildirme
                    MessageBox.Show("Configuration saved successfully. Please restart the application to apply changes.");
                    Application.Exit(); // Uygulamayı kapat
                } else {
                    MessageBox.Show("Failed to save the configuration.");
                }
            } else {
                MessageBox.Show("Failed to connect to the database. Please check your settings.");
            }
        }

        private bool UpdateConnectionString(string server, string port, string database, string userId, string password) {
            try {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                if (connectionStringsSection != null) {
                    var settings = connectionStringsSection.ConnectionStrings["MyDbConnectionString"];

                    if (settings == null) {
                        // Eğer bağlantı dizesi mevcut değilse, yenisini ekleme
                        settings = new ConnectionStringSettings("MyDbConnectionString",
                            $"Server={server},{port};Database={database};User Id={userId};Password={password};");
                        connectionStringsSection.ConnectionStrings.Add(settings);
                    } else {
                        // Mevcut bağlantı dizisini güncelleme
                        settings.ConnectionString = $"Server={server},{port};Database={database};User Id={userId};Password={password};";
                    }

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");

                    return true;
                } else {
                    MessageBox.Show("Connection strings section could not be found in the configuration file.");
                    return false;
                }
            } catch (Exception ex) {
                MessageBox.Show($"Failed to save the configuration. Error: {ex.Message}");
                return false;
            }
        }

        private void EncryptConnectionStringsSection() {
            try {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

                if (connectionStringsSection != null) {
                    // Şifreleme işlemini yapın
                    if (!connectionStringsSection.SectionInformation.IsProtected) {
                        connectionStringsSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("connectionStrings");
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"Failed to encrypt the connection strings. Error: {ex.Message}");
            }
        }

        private bool TestDatabaseConnection(string server, string port, string database, string userId, string password) {
            string connectionString = $"Server={server},{port};Database={database};User Id={userId};Password={password};";

            try {
                using (var connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    return true; // Bağlantı başarılı
                }
            } catch (Exception ex) {
                MessageBox.Show($"Failed to connect to the database. Error: {ex.Message}");
                return false; // Bağlantı başarısız
            }
        }
    }
}
