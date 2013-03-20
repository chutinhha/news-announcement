using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class News
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public String Content { get; set; }
        public String ImageUrl { get; set; }
        public byte[] ImageByte { get; set;}
    }
}
