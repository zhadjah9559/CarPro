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
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(20, MinimumLength = 5)]
        public string Make { get; set; }

        [Required(ErrorMessage = "Model required")]
        [StringLength(20, MinimumLength = 6)]
        public string Model { get; set; }

        [Display(Name = "Model Year")]
        [Required(ErrorMessage = "Model Year required")]
        [StringLength(4)]
        public int ModelYear { get; set; }

        [Required(ErrorMessage = "Mileage required")]
        [StringLength(20, MinimumLength = 3)]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Price required")]
        [RegularExpression(@"\$\d+\.\d{2}")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Color required")]
        [StringLength(20, MinimumLength = 4)]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Drive Train")]
        public string DriveTrain { get; set; }
       
      
        public virtual Lot Lot { get; set; }
    }
}
