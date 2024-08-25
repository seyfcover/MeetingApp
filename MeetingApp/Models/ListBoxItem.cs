using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class ListBoxItem
    {
        public string Text { get; set; }
        public int UserID { get; set; }


        public override string ToString() {
            return Text;
        }
    }
}
