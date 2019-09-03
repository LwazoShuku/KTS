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
    public class BrandsController : Controller
    {
        private ktsContext db = new ktsContext();

        // GET: Brands
        public ActionResult Index()
        {
            var pBrands = db.PBrands.Include(b => b.type);
            return View(pBrands.ToList());
        }

        // GET: Brands/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.PBrands.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            ViewBag.productTy = new SelectList(db.Ptype, "productTy", "productTy");
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "brandID,brandName,productTy")] Brands brands)
        {
            if (ModelState.IsValid)
            {
                db.PBrands.Add(brands);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productTy = new SelectList(db.Ptype, "productTy", "productTy", brands.productTy);
            return View(brands);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.PBrands.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            ViewBag.productTy = new SelectList(db.Ptype, "productTy", "productTy", brands.productTy);
            return View(brands);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "brandID,brandName,productTy")] Brands brands)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brands).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productTy = new SelectList(db.Ptype, "productTy", "productTy", brands.productTy);
            return View(brands);
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brands brands = db.PBrands.Find(id);
            if (brands == null)
            {
                return HttpNotFound();
            }
            return View(brands);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Brands brands = db.PBrands.Find(id);
            db.PBrands.Remove(brands);
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
