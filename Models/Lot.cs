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

        [Display(Name = "Full Name")]
        public string Name { get; set; }
        public int ZipCode { get; set; }

        [Display(Name = "(123) 456-7890")]
        public string PhoneNumber  { get; set; }

        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }



    }
}
