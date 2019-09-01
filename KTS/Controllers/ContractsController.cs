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
    public class ContractsController : Controller
    {
        private ktsContext db = new ktsContext();

        // GET: Contracts
        public ActionResult Index()
        {
            var contracts = db.contracts.Include(c => c.Employee);
            return View(contracts.ToList());
        }

        // GET: Contracts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create()
        {
            var types = new List<SelectType>();
            types.Add(new SelectType() { Value = "", Text = "Select a Type" });
            types.Add(new SelectType() { Value = "Permanent", Text = "Permanent" });
            types.Add(new SelectType() { Value = "Part-Time", Text = "PArt-Time" });
            ViewBag.PartialTypes = types;

            ViewBag.EmpNO = new SelectList(db.Emp, "EmpNo", "EName");
            ViewBag.Ctype = types;
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractID,ContractType,ContractDesc,JobTitle,RPH,ContractStart,status,EmpNO")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpNO = new SelectList(db.Emp, "EmpNo", "EName", contract.EmpNO);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpNO = new SelectList(db.Emp, "EmpNo", "EName", contract.EmpNO);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractID,ContractType,ContractDesc,JobTitle,RPH,ContractStart,status,EmpNO")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpNO = new SelectList(db.Emp, "EmpNo", "EName", contract.EmpNO);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Contract contract = db.contracts.Find(id);
            db.contracts.Remove(contract);
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
