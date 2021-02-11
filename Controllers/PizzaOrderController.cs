using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOrderingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrder.Controllers
{
    public class PizzaOrderController : Controller
    {
        private readonly PizzaOrderingDBContext _context;
        public PizzaOrderController(PizzaOrderingDBContext context)
        {
            _context = context;
        }
        // GET: LaptopController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Pizza.ToListAsync());
        }

        // GET: LaptopController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pizza = await _context.Pizza.FirstOrDefaultAsync(x => x.serialNo == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }
    }
}