using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOrderingApp.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Pizzaorder.Controllers
{
    public class PlaceOrderController : Controller
    {
        private readonly PizzaOrderingDBContext _context;
        public PlaceOrderController(PizzaOrderingDBContext context)
        {
            _context = context;
        }
        public ActionResult PlaceOrder(int id, string val)
        {
            List<PizzaApp> lstOlddata = null;
            if (val == "Add")
            {
                PizzaApp model = new PizzaApp();

                var pizza = _context.Pizza.Where(s => s.serialNo == id).ToList();
                if (pizza.Count > 0)
                    model = pizza[0];

                lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaApp>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                    lstOlddata = new List<PizzaApp>();

                if (pizza.Count > 0)
                    lstOlddata.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);
                // return View(lstOlddata);
            }
            else if (val == "Remove")
            {
                PizzaApp model = new PizzaApp();
                lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaApp>>(HttpContext.Session, "Placeorder");

                if (lstOlddata.Count > 0)
                {
                    var pizzalst = lstOlddata.Where(item => item.serialNo == id).ToList();
                    if (pizzalst.Count > 0)
                    {
                        PizzaApp lapmodel = pizzalst[0];
                        lstOlddata.Remove(lapmodel);
                    }
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


            }
            else
            {
                lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaApp>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                {
                    lstOlddata = new List<PizzaApp>();
                }

            }
            return View(lstOlddata);
        }

        public ActionResult ProceedToBuy(int id)
        {

            PizzaApp model = new PizzaApp();

            var pizza = _context.Pizza.Where(s => s.serialNo == id).ToList();
            if (pizza.Count > 0)
                model = pizza[0];

            List<PizzaApp> lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaApp>>(HttpContext.Session, "Placeorder");

            if (lstOlddata == null)
                lstOlddata = new List<PizzaApp>();

            if (pizza.Count > 0)
                lstOlddata.Add(model);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


            return RedirectToAction("Address", "Address");

        }

    }


    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}