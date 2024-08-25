using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class Participant
    {
        public string DisplayName { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }

        public Participant(int id, string name) {
            ID = id;
            Name = name;
        }

        public override string ToString() {
            return Name;
        }
    }


}
