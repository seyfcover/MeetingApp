﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public byte IsAdmin { get; set; }

        public string FullName { get; set; }
    }
}
