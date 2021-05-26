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

        [Required(ErrorMessage ="Labor Name is Required")]
        public string laborName { get; set; }
 
        [Required(ErrorMessage ="Task Detail is Required")]
        public string taskDetail { get; set; }

        [Required(ErrorMessage ="Work hous is Required")]
        [RegularExpression("^[0-9]{1,2}$",
                                ErrorMessage ="Work Hours Should be in Correct Pattern")]
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
