using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntryApplication.Models
{
    public class Labor
    {
        public int id { get; set; }
        public string laborName { get; set; }
 
        public string taskDetail { get; set; }
        public int workHours { get; set; }

        public Boolean isActive { get; set; }

        [Key, ForeignKey("District")]
        public int districtId { get; set; }

        public Labor()
        {
            isActive = true;
        }
    }
}
