using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.Models
{
    public class LaptopWishList
    {
        public int WishListID { get; set; }
        public WishList WishList { get; set; }

        public int LaptopID { get; set; }
        public Laptop Laptop { get; set; }
    }
}
