using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MeetingApp
{
    internal static class Program
    {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (IsConfigurationValid()) {
                // Eğer bağlantı ayarları geçerliyse, ana formu başlat
                Application.Run(new LoginForm());
            } else {
                // Bağlantı ayarları geçerli değilse, yapılandırma formunu başlat
                Application.Run(new ConfigurationForm());
            }
        }

        private static bool IsConfigurationValid() {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            if (connectionStringsSection != null) {
                var settings = connectionStringsSection.ConnectionStrings["MyDbConnectionString"];
                if (settings != null) {
                    string connectionString = settings.ConnectionString;
                    return TestDatabaseConnection(connectionString);
                } else {
                    MessageBox.Show("Connection string 'MyDbConnectionString' could not be found in the configuration file.");
                }
            }
            return false;
        }

        private static bool TestDatabaseConnection(string connectionString) {
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
