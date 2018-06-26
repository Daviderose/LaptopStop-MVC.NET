using LaptopStop_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddLaptopViewModel(IEnumerable<LaptopCategory> categories)
        {
            Categories = new List<SelectListItem>();

            // <option value="0">Hard</option>
            foreach (var category in categories)

            {
                Categories.Add(new SelectListItem
                {
                    Value = category.ID.ToString(),
                    Text = category.Name.ToString()
                });
            }
        }

        public AddLaptopViewModel() { }
            
            /*
            LaptopTypes.Add(new SelectListItem
            {
                Value = ((int)LaptopType.Gaming).ToString(),
                Text = LaptopType.Gaming.ToString()
            });

            LaptopTypes.Add(new SelectListItem
            {
                Value = ((int)LaptopType.Ultrabook).ToString(),
                Text = LaptopType.Ultrabook.ToString()
            });

            LaptopTypes.Add(new SelectListItem
            {
                Value = ((int)LaptopType.Workstation).ToString(),
                Text = LaptopType.Workstation.ToString()
            }); */
        
    }
}
