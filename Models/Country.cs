using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntryApplication.Models
{
    public class Country
    {
        public int id { get; set; }

        [Required(ErrorMessage ="Country Name is required")]
        public string name { get; set; }
        
        [Required(ErrorMessage ="Country Code is Required")]
        [RegularExpression("^[A-Z]{1,1}[0-9]{4,4}$", 
                            ErrorMessage ="Country Code Should be Correct Pattern")]
        public string code { get; set; }

        public Boolean isActive { get; set; }

      public List<District> district { get; set; }

        public Country()
        {
            district = new List<District>();
            isActive = true;

        }
    }
}
