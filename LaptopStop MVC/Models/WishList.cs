using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.Models
{
    public class WishList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<LaptopWishList> LaptopsWishLists { get; set; }
    }
}
