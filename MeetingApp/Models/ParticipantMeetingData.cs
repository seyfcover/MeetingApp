using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class ParticipantMeetingData
    {
        public string FullName { get; set; }
        public string ParticipantID { get; set; }

        public string ParticipantType { get; set; }
        public float MeetingCount { get; set; }

    }
}
