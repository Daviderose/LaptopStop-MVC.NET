using LaptopStop_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.ViewModels
{
    public class AddWishListItemViewModel
    {
        public WishList WishList { get; set; }
        public List<SelectListItem> Laptops { get; set; }

        public int WishListID { get; set; }
        public int LaptopID { get; set; }

        public AddWishListItemViewModel() { }

        public AddWishListItemViewModel(WishList wishList, IEnumerable<Laptop> laptops)
        {
            Laptops = new List<SelectListItem>();

            foreach (var laptop in laptops)
            {
                Laptops.Add(new SelectListItem
                {
                    Value = laptop.ID.ToString(),
                    Text = laptop.Name
                });
            }

            WishList = wishList;
        }
    }
}
