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
    public class WishListController : Controller
    {

        private readonly LaptopDbContext context;

        public WishListController(LaptopDbContext dbContext)
        {
            context = dbContext;
        }
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<WishList> WishLists = context.WishLists.ToList();
            return View();
        }

        public IActionResult Add()
        {
            AddWishListViewModel addWishListViewModel = new AddWishListViewModel();
            return View(addWishListViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddWishListViewModel addWishListViewModel)
        {
            if (ModelState.IsValid)
            {
                WishList newWishList = new WishList
                {
                    Name = addWishListViewModel.Name
                };

                context.WishLists.Add(newWishList);
                context.SaveChanges();

                return Redirect("/WishList");

            }

            return View(addWishListViewModel);
        }

        public IActionResult ViewWishList(int id)
        {
            List<LaptopWishList> items = context
                .LaptopWishLists
                .Include(item => item.Laptop)
                .Where(lw => lw.WishListID == id)
                .ToList();

            WishList wishList = context.WishLists.Single(w => w.ID == id);

            ViewWishListViewModel viewModel = new ViewWishListViewModel
            {
                WishList = wishList,
                Items = items
            };

            return View(viewModel);
        }

        public IActionResult AddItem(int id)
        {
            WishList wishList = context.WishLists.Single(w => w.ID == id);
            List<Laptop> laptops = context.Laptops.ToList();
            return View(new AddWishListItemViewModel(wishList,laptops));
        }

        [HttpPost]
        public IActionResult AddItem(AddWishListItemViewModel addWishListItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var laptopID = addWishListItemViewModel.LaptopID;
                var wishListID = addWishListItemViewModel.WishListID;

                IList<LaptopWishList> existingItems = context.LaptopWishLists
                    .Where( lw => lw.LaptopID == laptopID)
                    .Where( lw => lw.WishListID == wishListID).ToList();

                if (existingItems.Count == 0)
                {
                    LaptopWishList wishListItem = new LaptopWishList
                    {
                        Laptop = context.Laptops.Single(l => l.ID == laptopID),
                        WishList = context.WishLists.Single(w => w.ID == wishListID)
                    };

                    context.LaptopWishLists.Add(wishListItem);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/WishList/ViewWishList/{0}", addWishListItemViewModel.WishListID));
            }

            return View(addWishListItemViewModel);
        }
    }
}