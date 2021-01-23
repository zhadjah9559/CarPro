using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPro.Models
{
    public class Car
    {
        public int Id { get; set; }
        //How to declare a PARENT (Foreign Key)
        public int LotId { get; set; }

        [Required(ErrorMessage = "Make required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long and less than 20 characters.")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be 4 charaters long, less than 20 characters.")]
        public string Model { get; set; }

        [Display(Name = "Model Year")]
        [Required(ErrorMessage = "Model Year required")]
        [StringLength(4, ErrorMessage = "Must be 4 characters long")]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Mileage required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be three characters long, less than 20 characters.")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Price required")]
        [RegularExpression(@"\$\d+\.\d{2}", ErrorMessage = "Must be in $$$$.$$ Format")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Color required")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters, less than 20 characters")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Drive Train")]
        [StringLength(13, MinimumLength = 2, ErrorMessage = "Must be at least 2 characters long, less than 13.")]
        public string DriveTrain { get; set; }
       
      
        public virtual Lot Lot { get; set; }
    }
}
