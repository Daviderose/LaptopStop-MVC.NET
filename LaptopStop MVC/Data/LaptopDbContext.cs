using LaptopStop_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStop_MVC.Data
{
    public class LaptopDbContext : DbContext 
    {
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<LaptopCategory> Categories { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<LaptopWishList> LaptopWishLists { get; set; }

        public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaptopWishList>()
                .HasKey(l => new { l.LaptopID, l.WishListID });
        }

    }
}
