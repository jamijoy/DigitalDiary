using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class Note
    {
        public int contentNumber { get; set; }
        public int userId { get; set; }
        public string contentText { get; set; }
        public string contentLink { get; set; }
        public string contentPriority { get; set; }
        public string contentDate { get; set; }
    }
}