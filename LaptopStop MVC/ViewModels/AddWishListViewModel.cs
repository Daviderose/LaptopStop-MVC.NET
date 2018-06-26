using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.ViewModels
{
    public class AddWishListViewModel
    {

    [Required]
    [Display(Name = "WishList Name")]
    public string Name { get; set; }

}
}
