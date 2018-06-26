using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopStop_MVC.Data;
using LaptopStop_MVC.Models;
using LaptopStop_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopStop_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LaptopDbContext context;

        public CategoryController(LaptopDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<LaptopCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                LaptopCategory newCategory = new LaptopCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
    }
}