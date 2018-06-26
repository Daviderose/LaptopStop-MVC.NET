using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStop_MVC.Data;
using LaptopStop_MVC.Models;
using LaptopStop_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopStop_MVC.Controllers
{
    public class LaptopController : Controller
    {

        private LaptopDbContext context;

        public LaptopController(LaptopDbContext dbContext)
        {
            context = dbContext;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Laptop> laptops = context.Laptops.Include(c => c.Category).ToList();

            return View(laptops);
        }

        public IActionResult Add()
        {
            AddLaptopViewModel addLaptopViewModel = new AddLaptopViewModel(context.Categories.ToList());
            return View(addLaptopViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddLaptopViewModel addLaptopViewModel)
        {

            if (ModelState.IsValid)
            {

                LaptopCategory newLaptopCategory = context.Categories.Single(c => c.ID == addLaptopViewModel.CategoryID);

                // Add new laptop to the list of existing laptops
                Laptop newLaptop = new Laptop
                {
                    Name = addLaptopViewModel.Name,
                    Description = addLaptopViewModel.Description,
                    Category = newLaptopCategory
                };

                context.Laptops.Add(newLaptop);
                context.SaveChanges();

                return Redirect("/Laptop");
            }

            return View(addLaptopViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Laptops";
            ViewBag.laptops = context.Laptops.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] laptopIds)
        {
            
            foreach (int laptopId in laptopIds)
            {
                Laptop theLaptop = context.Laptops.Single(c => c.ID == laptopId);
                context.Laptops.Remove(theLaptop);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Edit(int laptopId)
        {
            ViewBag.laptop = context.Laptops.Single(c => c.ID == laptopId);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int laptopId, string name, string description)
        {
            Laptop foundLaptop = context.Laptops.Single(c => c.ID == laptopId);
            foundLaptop.Name = name;
            foundLaptop.Description = description;

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

            LaptopCategory theCategory = context.Categories.Include(cat => cat.Laptops).Single(cat => cat.ID == id);

            ViewBag.title = "Laptops in category: " + theCategory.Name;

            return View("Index", theCategory.Laptops);
        }



    }
}
