﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.Models
{
    public class Laptop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<LaptopWishList> LaptopsWishLists { get; set; }

        public int CategoryID { get; set; }
        public LaptopCategory Category { get; set; }    

    }
}
