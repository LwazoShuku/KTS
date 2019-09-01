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
    public class ProductTypesController : Controller
    {
        private ktsContext db = new ktsContext();

        // GET: ProductTypes
        public ActionResult Index()
        {
            return View(db.Ptype.ToList());
        }

        // GET: ProductTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.Ptype.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // GET: ProductTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productTy")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                db.Ptype.Add(productType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productType);
        }

        // GET: ProductTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.Ptype.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productTy")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        // GET: ProductTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType productType = db.Ptype.Find(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductType productType = db.Ptype.Find(id);
            db.Ptype.Remove(productType);
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
