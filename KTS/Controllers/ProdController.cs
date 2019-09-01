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
    public class ProdController : Controller
    {
        private ktsContext db = new ktsContext();

        // GET: Prod
        public ActionResult Index()
        {
            var product = db.product.Include(p => p.productsTypes);
            return View(product.ToList());
        }

        // GET: Prod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.product.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Prod/Create
        public ActionResult Create()
        {
            ViewBag.ProductTy = new SelectList(db.Ptype, "productTy", "productSupplier");
            return View();
        }

        // POST: Prod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductDescription,Price,StockAmt,ProductTy")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.product.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductTy = new SelectList(db.Ptype, "productTy", "productSupplier", products.ProductTy);
            return View(products);
        }

        // GET: Prod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.product.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTy = new SelectList(db.Ptype, "productTy", "productSupplier", products.ProductTy);
            return View(products);
        }

        // POST: Prod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductDescription,Price,StockAmt,ProductTy")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductTy = new SelectList(db.Ptype, "productTy", "productSupplier", products.ProductTy);
            return View(products);
        }

        // GET: Prod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.product.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.product.Find(id);
            db.product.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       


    }
}
