using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class TrainingBookingsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: TrainingBookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: TrainingBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingBooking trainingBooking = db.Bookings.Find(id);
            if (trainingBooking == null)
            {
                return HttpNotFound();
            }
            return View(trainingBooking);
        }

        // GET: TrainingBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookingID,StartDate,EndDate")] TrainingBooking trainingBooking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(trainingBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingBooking);
        }

        // GET: TrainingBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingBooking trainingBooking = db.Bookings.Find(id);
            if (trainingBooking == null)
            {
                return HttpNotFound();
            }
            return View(trainingBooking);
        }

        // POST: TrainingBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookingID,StartDate,EndDate")] TrainingBooking trainingBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingBooking);
        }

        // GET: TrainingBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingBooking trainingBooking = db.Bookings.Find(id);
            if (trainingBooking == null)
            {
                return HttpNotFound();
            }
            return View(trainingBooking);
        }

        // POST: TrainingBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingBooking trainingBooking = db.Bookings.Find(id);
            db.Bookings.Remove(trainingBooking);
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
