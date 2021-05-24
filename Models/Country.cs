using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntryApplication.Models
{
    public class Country
    {
        public int id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public Boolean isActive { get; set; }

      public List<District> district { get; set; }

        public Country()
        {
            district = new List<District>();
        }
    }
}
