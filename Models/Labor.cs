using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntryApplication.Models
{
    public class Labor
    {
        public int id { get; set; }
        public string laborName { get; set; }
        public string country { get; set; }
        public string district { get; set; }
        public string taskDetail { get; set; }
        public int workHours { get; set; }

        public Boolean isActive { get; set; }
    }
}
