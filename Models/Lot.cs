using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPro.Models
{
    public class Lot
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zip Code required")]
        [StringLength(7, MinimumLength = 4)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber  { get; set; }

        [Required(ErrorMessage = "Manager Name required")]
        [Display(Name = "Manager Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string ManagerName { get; set; }


        //How to declare a CHILD
        public virtual ICollection<Car> Car { get; set; }
    }
}
