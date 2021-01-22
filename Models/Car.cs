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
        public string Make { get; set; }
        public string Model { get; set; }
        //validation annotation
        public int ModelYear { get; set; }

        public int Mileage { get; set; }

        [DisplayName("Price")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public Decimal Price { get; set; }

        public string Color { get; set; }

        //find annotation to properly display that
        public string WheelDrive { get; set; }



        //How to declare a Parent (Foreign Key)
        public int LotId { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
