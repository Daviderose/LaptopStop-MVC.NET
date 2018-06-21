using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStop_MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopStop_MVC.Controllers
{
    public class LaptopController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.laptops = LaptopData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Laptop/Add")]
        public IActionResult NewLaptop(string name, string description)
        {

            Laptop newLaptop = new Laptop
            {
                Description = description,
                Name = name
            };

            // Add new laptop to the list of existing laptops
            Laptops.Add(newLaptop);

            return Redirect("/Laptop");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Laptops";
            ViewBag.laptops = Laptops;
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] laptopIds)
        {
            
            foreach (int laptopId in laptopIds)
            {
                Laptops.RemoveAll(x => x.LaptopId == laptopId);
            }

            return Redirect("/");
        }



    }
}
