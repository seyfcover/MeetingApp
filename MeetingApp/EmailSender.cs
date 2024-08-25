using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MeetingApp;
using Newtonsoft.Json;

public class EmailSender
{
    private readonly string apiKey = "42fcbf4819b2b487c7a8c9cbe408e3d5"; // Mailjet API anahtarınız
    private readonly string apiSecret = "854b656df36ada13e7702384579b4a60"; // Mailjet API secret anahtarınız
    private DatabaseHelper dbHelper;
    private string username;

    public EmailSender(DatabaseHelper databaseHelper, string username) { 
        dbHelper = databaseHelper;
        this.username= username;
    }
    public async Task SendEmailAsync(string recipientEmail) {

        string userPassword = dbHelper.GetPassByUsername(username);
        using (var client = new HttpClient()) {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailjet.com/v3.1/send");

            // API anahtarlarını ve secret'ı ayarlayın
            var byteArray = Encoding.ASCII.GetBytes($"{apiKey}:{apiSecret}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var emailMessage = new {
                Messages = new[]
                {
                    new
                    {
                        From = new { Email = "teknokent.meeting@outlook.com", Name = "Teknokent Meeting" },
                        To = new[] { new { Email = recipientEmail } },
                        Subject = "Şifremi Unuttum",
                        TextPart = "Şifreniz : "+userPassword,
                    }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(emailMessage), Encoding.UTF8, "application/json");
            request.Content = content;

            try {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode) {
                } else {
                    System.Windows.Forms.MessageBox.Show("E-posta gönderilirken bir hata oluştu. Status code: " + response.StatusCode);
                }
            } catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
