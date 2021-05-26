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

        [Required(ErrorMessage ="District Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "District Code is required")]
        [RegularExpression("^[A-Z]{1,1}[0-9]{4,4}$",
                            ErrorMessage ="District Code Should be in Correct Pattern")]
        public string code { get; set; }

        [Required(ErrorMessage = "Labor Rate is required")]
        [RegularExpression("^[0-9]{1,10}$",
                      ErrorMessage = "Labor Rate Should be in Correct Pattern")]
        public int laborRatePerHour { get; set; }

        public Boolean isActive { get; set; }

        [Key, ForeignKey("Country")]
        public int countryId { get; set; }

        public List<Labor> labor { get; set; }

        public District()
        {
            isActive = true;
            labor = new List<Labor>();
        }
    }
}
