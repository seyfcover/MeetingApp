using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class Participants
    {
        public string DisplayName { get; set; }
        public int ID { get; set; }
        public string Type { get; set; }

        public override string ToString() {
            return DisplayName;
        }
    }
}
