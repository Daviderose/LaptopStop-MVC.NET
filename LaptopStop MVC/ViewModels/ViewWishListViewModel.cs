using LaptopStop_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.ViewModels
{
    public class ViewWishListViewModel      
    {
        public IList<LaptopWishList> Items { get; set; }
        public WishList WishList { get; set; }
    }
}
