using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class User
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string Upassword { get; set; }
    }
}