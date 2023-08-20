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
using ContosoUniversity.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class VacationController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //// GET: Vacation
        //public ActionResult Index()
        //{
        //    var vacations = db.Vacations.Include(v => v.User);
        //    return View(vacations.ToList());
        //}
        // GET: Vacations
        public ActionResult Index()
        {
            var vacations = db.Vacations.Include(v => v.User)
                                .Select(v => new VacationViewModel
                                {
                                    Id = v.Id,
                                    DateFrom = v.DateFrom,
                                    DateTo = v.DateTo,
                                    Description = v.Description,
                                    UserId = v.UserId,
                                    UserName = v.User.FirstName + " " + v.User.LastName
                                }).ToList();

            return View(vacations);
        }

        // GET: Vacation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        //// GET: Vacation/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
        //    return View();
        //}
        //public ActionResult Create()
        //{
        //    var viewModel = new CreateVacationViewModel
        //    {
        //        UserDropdown = db.Users.Select(u => new SelectListItem
        //        {
        //            Value = u.Id.ToString(),
        //            Text = u.FirstName + " " + u.LastName
        //        }).ToList()
        //    };

        //    return View(viewModel);
        //}
        public ActionResult Create()
        {
            var viewModel = new CreateVacationViewModel
            {
                UserDropdown = new SelectList(db.Users, "Id", "FirstName")
            };
            return View(viewModel);
        }

        // POST: Vacation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,DateFrom,DateTo,Description,UserId")] Vacation vacation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Vacations.Add(vacation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", vacation.UserId);
        //    return View(vacation);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CreateVacationViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Map the ViewModel to the Vacation entity
        //        var vacation = new Vacation
        //        {
        //            DateFrom = viewModel.DateFrom,
        //            DateTo = viewModel.DateTo,
        //            Description = viewModel.Description,
        //            UserId = viewModel.SelectedUserId
        //        };

        //        db.Vacations.Add(vacation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    // If we reach here, something failed, redisplay form
        //    // Repopulate the dropdown in case of error
        //    viewModel.UserDropdown = new SelectList(db.Users, "Id", "FirstName", viewModel.SelectedUserId);
        //    return View(viewModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CreateVacationViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var vacation = new Vacation
        //        {
        //            DateFrom = viewModel.DateFrom,
        //            DateTo = viewModel.DateTo,
        //            Description = viewModel.Description,
        //            UserId = viewModel.SelectedUserId
        //        };

        //        db.Vacations.Add(vacation);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    viewModel.UserDropdown = new SelectList(db.Users, "Id", "FirstName", viewModel.SelectedUserId);
        //    return View(viewModel);
        //}

        // GET: Vacation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", vacation.UserId);
            return View(vacation);
        }

        // POST: Vacation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateFrom,DateTo,Description,UserId")] Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", vacation.UserId);
            return View(vacation);
        }

        // GET: Vacation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacation vacation = db.Vacations.Find(id);
            if (vacation == null)
            {
                return HttpNotFound();
            }
            return View(vacation);
        }

        // POST: Vacation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacation vacation = db.Vacations.Find(id);
            db.Vacations.Remove(vacation);
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
