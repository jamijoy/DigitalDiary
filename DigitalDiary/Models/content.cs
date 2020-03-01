using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DigitalDiary.Models
{
    public class Content
    {
        public int Nid { get; set; }
        public int Uid { get; set; }
        public string Nname { get; set; }
        public string Ntext { get; set; }
        public string Ndate { get; set; }
        public int Npriority { get; set; }

        [DisplayName("Upload File")]
        public string Nimage { get; set; }
        public HttpPostedFileBase imageFile { get; set; }
    }
}