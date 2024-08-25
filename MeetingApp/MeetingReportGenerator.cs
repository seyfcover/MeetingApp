using System;
using System.Data;
using System.Linq;
using Xceed.Words.NET;

namespace MeetingApp
{
    public class MeetingReportGenerator
    {


        private DatabaseHelper dbHelper;

        public MeetingReportGenerator(DatabaseHelper databaseHelper) {
            this.dbHelper = databaseHelper;
        }

        [Obsolete]
        public void GenerateMeetingReport(int meetingId, string templatePath, string outputDocxPath, string outputPdfPath) {
            DataTable meetingDetails = dbHelper.GetMeetingDetails(meetingId);
            if (meetingDetails.Rows.Count == 0) {
                throw new Exception("Meeting not found.");
            }

            DataTable participants = dbHelper.GetMeetingParticipants(meetingId);
            FillDocx(templatePath, outputDocxPath, meetingDetails, participants);
            //ConvertDocxToPdf(outputDocxPath, outputPdfPath);
        }

        [Obsolete]
        private void FillDocx(string templatePath, string outputPath, DataTable meetingDetails, DataTable participants) {
            using (DocX document = DocX.Load(templatePath)) {
                DataRow meeting = meetingDetails.Rows[0];

                // Toplantı bilgilerini yerleştir
                document.ReplaceText("{MeetingID}", meeting["MeetingID"].ToString());
                document.ReplaceText("{MeetingTitle}", meeting["MeetingTitle"].ToString());
                document.ReplaceText("{MeetingNotes}", meeting["MeetingNotes"].ToString());
                document.ReplaceText("{MeetingLocation}", meeting["MeetingLocation"].ToString());
                document.ReplaceText("{MeetingDate}", DateTime.Parse(meeting["MeetingDate"].ToString()).ToString("dd.MM.yyyy"));
                document.ReplaceText("{MeetingTime}", TimeSpan.Parse(meeting["MeetingTime"].ToString()).ToString(@"hh\:mm"));

                // Şirket katılımcılarını yerleştir
                var companyParticipants = participants.AsEnumerable().Where(r => r["ParticipantType"].ToString() == "Company");
                int companyCount = 1;
                foreach (var company in companyParticipants) {
                    document.ReplaceText($"{{CompanyName{companyCount}}}", company["CompanyName"].ToString());
                    document.ReplaceText($"{{CompanyInfo{companyCount}}}", company["CompanyFieldsOfActivity"].ToString());
                    companyCount++;
                }

                // Kalan şirket placeholder'larını temizle
                for (int i = companyCount; i <= 6; i++) { // 6, toplam boş olan placeholder sayısıdır. İhtiyaca göre değiştirilebilir.
                    document.ReplaceText($"{{CompanyName{i}}}", "");
                    document.ReplaceText($"{{CompanyInfo{i}}}", "");
                }

                // Diğer katılımcıları yerleştir
                var otherParticipants = participants.AsEnumerable().Where(r => r["ParticipantType"].ToString() != "Company");
                int participantCount = 1;
                foreach (var participant in otherParticipants) {
                    document.ReplaceText($"{{ParticipantName{participantCount}}}", participant["UserName"].ToString());
                    document.ReplaceText($"{{ParticipantTitle{participantCount}}}", participant["UserTitle"].ToString());
                    document.ReplaceText($"{{ParticipantPhone{participantCount}}}", participant["UserPhone"].ToString());
                    document.ReplaceText($"{{ParticipantEmail{participantCount}}}", participant["Email"].ToString());
                    document.ReplaceText($"{{ParticipantCompany{participantCount}}}", participant["EmployeeCompany"].ToString());
                    participantCount++;
                }

                // Kalan diğer katılımcı placeholder'larını temizle
                for (int i = participantCount; i <= 10; i++) { // 10, toplam boş olan placeholder sayısıdır. İhtiyaca göre değiştirilebilir.
                    document.ReplaceText($"{{ParticipantName{i}}}", "");
                    document.ReplaceText($"{{ParticipantTitle{i}}}", "");
                    document.ReplaceText($"{{ParticipantPhone{i}}}", "");
                    document.ReplaceText($"{{ParticipantEmail{i}}}", "");
                    document.ReplaceText($"{{ParticipantCompany{i}}}", "");
                }

                document.SaveAs(outputPath);
            }
        }

    }
}
