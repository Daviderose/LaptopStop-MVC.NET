using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.Models
{
    public class LaptopData
    {
        static private List<Laptop> laptops = new List<Laptop>();

        // GetAll
        public static List<Laptop> GetAll()
        {
            return laptops;
        }

        // Add
        public static void Add(Laptop newLaptop)
        {
            laptops.Add(newLaptop);
        }
        
        // Remove
        public static void Remove(int id)
        {
            Laptop laptopToRemove = GetById(id);
            laptops.Remove(laptopToRemove);
        }
        
        // GetById
        public static Laptop GetById(int id)
        {
            return laptops.Single(x => x.LaptopId == id);
        }
    }
}
