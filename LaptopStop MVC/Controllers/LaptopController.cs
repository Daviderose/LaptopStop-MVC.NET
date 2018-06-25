using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStop_MVC.Models;
using LaptopStop_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopStop_MVC.Controllers
{
    public class LaptopController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Laptop> laptops = LaptopData.GetAll();

            return View(laptops);
        }

        public IActionResult Add()
        {
            AddLaptopViewModel addLaptopViewModel = new AddLaptopViewModel();
            return View(addLaptopViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddLaptopViewModel addLaptopViewModel)
        {

            if (ModelState.IsValid)
            {
                // Add new laptop to the list of existing laptops
                Laptop newLaptop = new Laptop
                {
                    Name = addLaptopViewModel.Name,
                    Description = addLaptopViewModel.Description
                };

                LaptopData.Add(newLaptop);

                return Redirect("/Laptop");
            }

            return View(addLaptopViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Laptops";
            ViewBag.laptops = LaptopData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] laptopIds)
        {
            
            foreach (int laptopId in laptopIds)
            {
                LaptopData.Remove(laptopId);
            }

            return Redirect("/");
        }

        public IActionResult Edit(int laptopId)
        {
            ViewBag.laptop = LaptopData.GetById(laptopId);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int laptopId, string name, string description)
        {
            Laptop foundLaptop = LaptopData.GetById(laptopId);
            foundLaptop.Name = name;
            foundLaptop.Description = description;
            return Redirect("/");
        }



    }
}
