using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.Models
{
    public class Laptop
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LaptopId { get; set; }
        private static int nextId = 1;

        public Laptop() {
            LaptopId = nextId;
            nextId++;
        }
    }
}
