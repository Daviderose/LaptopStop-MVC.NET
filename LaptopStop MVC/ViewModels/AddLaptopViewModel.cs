using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.ViewModels
{
    public class AddLaptopViewModel
    {
        [Required]
        [Display(Name = "Laptop Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your laptop a description")]    
        public string Description { get; set; }
    }
}
