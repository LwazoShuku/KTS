
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

        public ActionResult ProductsRe()
        {

            var product = db.product.Include(p => p.GetBrands);
            return View(product.ToList());



        }
        // GET: Products
        

        public ActionResult V()
        {
            // where is this one going?
            var search = db.product.Include(i => i.GetBrands).Where(p => p.ProductName == "Vulcanizing").ToList();

            return  View("ProductsRe",search);
        }

        public ActionResult B()
        {
            // where is this one going?
            var search = db.product.Include(i => i.GetBrands).Where(p => p.ProductName == "Balancing&Fitting").ToList();

            return View("ProductsRe", search);
        }

        public ActionResult W()
        {
            // where is this one going?
            var search = db.product.Include(i => i.GetBrands).Where(p => p.ProductName == "Wheel Alignment").ToList();

            return View("ProductsRe", search);
        }

        public ActionResult Tyres()
        {

            
            var tyre = db.product.Include(p => p.GetBrands).Where(p => p.GetBrands.productTy.ToString() == "Tyres").ToList();

            return View("ProductsRe", tyre);

        }





        public ActionResult Rims()
        {
           
            
               

           

                var r = db.product.Include(i => i.GetBrands).Where(p => p.GetBrands.productTy.ToString() == "Rims").ToList();
              return View("ProductsRe", r);

        }

        public ActionResult Lugs()
        {

          


            var Lug = db.product.Include(i => i.GetBrands).Where(p => p.GetBrands.productTy.ToString() == "Accessories").ToList();

            return View("ProductsRe", Lug);

        }


        public ActionResult Employee()
        {

            return View("Employee");
        }

    }
      
}