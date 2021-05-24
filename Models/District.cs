using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntryApplication.Models
{
    public class District
    {
        public int id { get; set; }

        public string name { get; set; }
        public string code { get; set; }

        public int laborRatePerHour { get; set; }

        public Boolean isActive { get; set; }

        [Key, ForeignKey("Country")]
        public int countryId { get; set; }
    }
}
