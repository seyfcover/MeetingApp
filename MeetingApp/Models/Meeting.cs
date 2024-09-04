using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class Meeting
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Location { get; set; }
        public byte[] Documents { get; set; } // Belge eklemek isterseniz
        public int MeetingID { get; set; }
        public string MeetingType { get; set; }
        public bool isImportant { get; set; }
    }
}
