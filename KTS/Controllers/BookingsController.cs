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
    public class BookingsController : Controller
    {
        private ktsContext db = new ktsContext();

        // GET: Bookings
        public ActionResult Index()
        {
            ViewBag.day = System.DateTime.Now.ToString("dddd");
            var bookings = db.bookings.Include(b => b.GetServices);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        [Authorize]
        public ActionResult Create()
        {
         
            ViewBag.Serviceid = new SelectList(db.services, "Serviceid", "Serviceid");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dateT,time,sessionUser,Serviceid,Name,Surname,vehicle_Registration")] Booking booking)
        {
            int i = db.bookings.Where(p => p.dateT == booking.dateT && p.time == booking.time && p.Serviceid == booking.Serviceid).Count();
            int w = -db.bookings.Where(p => p.dateT == booking.dateT && p.time == booking.time && p.sessionUser == booking.sessionUser).Count();
            if (i == 2)
            {


                return View("BookingExist");

            }
            else if (booking.dateT <= DateTime.Now)
            {
                return View("BookingA");
            }
            
            else if (booking.dateT.Date.DayOfWeek.ToString() =="Sunday")
            {
                return View("BookingA");
            }
            else if (i == 1)
            {


                return View("BookingExist");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    booking.sessionUser = this.HttpContext.User.Identity.Name;
                    db.bookings.Add(booking);
                    db.SaveChanges();
                    return View("Success");
                }
            }

          
            ViewBag.Serviceid = new SelectList(db.services, "Serviceid", "Serviceid", booking.Serviceid);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(string id,string dat)
        {  
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.bookings.Find(id,dat);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Serviceid = new SelectList(db.services, "Serviceid", "Serviceid", booking.Serviceid);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dateT,time,sessionUser,Serviceid,Name,Surname,vehicle_Registration")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Serviceid = new SelectList(db.services, "Serviceid", "Serviceid", booking.Serviceid);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Booking booking = db.bookings.Find(id);
            db.bookings.Remove(booking);
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
