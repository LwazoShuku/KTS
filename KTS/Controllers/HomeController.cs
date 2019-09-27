
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KTS.Models;
using KTS.data;

namespace KTS.Controllers
{
    public class HomeController : Controller
    {
        private ktsContext db = new ktsContext();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductsRe(string s)
        {
            if (s != null)
            {
                var i = (from d in db.InventoryT.Include(p => p.GetProducts).Where(y => y.ProductModelName.StartsWith(s)) select d);
                return View(i);
            }
            var inventoryT = (from d in db.InventoryT.Include(i => i.GetProducts) select d);
            return View(inventoryT.ToList());



        }
        // GET: Products
        

        public ActionResult V()
        {
            // where is this one going?
            var search = db.services.Where(p => p.Serviceid == "Vulcanizing").ToList();

            return  View("Service",search);
        }

        public ActionResult B()
        {
            // where is this one going?
            var search = db.services.Where(p =>p.Serviceid== "Balancing&Fitting").ToList();

            return View("Service", search);
        }

        public ActionResult W()
        {
            // where is this one going?
            var search = db.services.Where(p => p.Serviceid == "Wheel Alignment").ToList();

            return View("Service", search);
        }

        public ActionResult Tyres(string s)
        {
            if (s != null)
            {
                var t = db.InventoryT.Include(p => p.GetProducts).Where(p => p.GetProducts.GetBrands.productTy.StartsWith(s)).ToList();

                return View("ProductsRe", t);
            }
            
            var tyre = db.InventoryT.Include(p => p.GetProducts).Where(p => p.GetProducts.GetBrands.productTy == "Tyres").ToList();

            return View("ProductsRe", tyre);

        }





        public ActionResult Rims(string s)
        {
            if (s != null)
            {
                var e = db.InventoryT.Include(i => i.GetProducts).Where(p => p.GetProducts.GetBrands.productTy.StartsWith(s)).ToList();
                return View("ProductsRe", e);
            }
            
               

           

                var r = db.InventoryT.Include(i => i.GetProducts).Where(p => p.GetProducts.GetBrands.productTy == "Rims").ToList();
              return View("ProductsRe", r);

        }

        public ActionResult Lugs(string s)
        {

            if (s != null)
            {
                var L= db.InventoryT.Include(i => i.GetProducts).Where(p => p.GetProducts.GetBrands.productTy.StartsWith(s)).ToList();

                return View("ProductsRe", L);
            }


            var Lug = db.InventoryT.Include(i => i.GetProducts).Where(p => p.GetProducts.GetBrands.productTy == "Accessories").ToList();

            return View("ProductsRe", Lug);

        }


        public ActionResult Employee()
        {

            return View("Employee");
        }

    }
      
}