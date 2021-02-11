using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrderingApp.Models
{
    public class PizzaOrderingDBContext : IdentityDbContext
    {
        public PizzaOrderingDBContext(DbContextOptions<PizzaOrderingDBContext> options)
            : base(options)
        {

        }
        public DbSet<PizzaApp> Pizza { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PizzaApp>().HasData(
                new PizzaApp { serialNo = 1, Image = "/barbecueChickenPizza.jpg", PizzaName = "Barbeque Chicken Pizza",  Size = "Small", Price = 100 },
                new PizzaApp { serialNo = 2, Image = "/BBQFriesPizza.jpg", PizzaName = "BBQ Fries Pizza", Size = "Regular", Price = 150 },
                new PizzaApp { serialNo = 3, Image = "/ChilliPaneerPizza.jpg", PizzaName = "Chilli Paneer Pizza", Size = "Regular", Price = 230 },
                new PizzaApp { serialNo = 4, Image = "/Corn and olive pizza.jpg", PizzaName = "Corn and Olive Pizza", Size = "Medium", Price = 160 },
                new PizzaApp { serialNo = 5, Image = "/DragonPaneerPizza.jpg", PizzaName = "Dragon Paneer Pizza", Size = "Small", Price = 120 },
                new PizzaApp { serialNo = 6, Image = "/MacAndCheesePizza.jpg", PizzaName = "Mac And Cheese Pizza", Size = "Medium", Price = 240 },
                new PizzaApp { serialNo = 7, Image = "/Oniumcapsigumpizza.jpg", PizzaName = "Onium capsicum Pizza", Size = "Regular", Price = 300 },
                new PizzaApp { serialNo = 8, Image = "/pepperoni.jpg", PizzaName = "Pepperoni Pizza", Size = "Regular", Price = 189 },
                new PizzaApp { serialNo = 9, Image = "/spicyChickenPizza.jpg", PizzaName = "Spicy Chicken Pizza", Size = "Regular", Price = 199 }
                );
        }
        //public Laptops find(string id)
        //{
        //    List<Laptops> laptop=();
        //    var lap = laptop.Where(a => a.serialNo == id).FirstOrDefault();
        //    return lap;

        //}
    }
}
