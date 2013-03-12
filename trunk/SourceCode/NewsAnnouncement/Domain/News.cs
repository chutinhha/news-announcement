using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class News
    {
        public int ID { get; }
        public string Tittle { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public StringBuilder Content { get; set; }
        public String ImageUrl { get; set; }
    }
}
