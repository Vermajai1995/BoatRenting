using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoatProject.Models
{
    public class Boat
    {
        [Display(Name = "Boat Number")]
        public int Id { get; set; }
        [Display(Name = "Boat Name")]
        [Required]
        public string BoatName { get; set; }
        [DataType(DataType.Currency)]
        [Range(1, 100)]
        public decimal HourlyRate { get; set; }
        public bool isCurrentlyRented { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name ="Customer Name")]
        public string RentedByCustomerName { get; set; }
    }
}
