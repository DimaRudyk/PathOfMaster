using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DimaMaster.Models;

namespace DimaMaster.Controllers
{
    public class CarServicesController : Controller
    {
        private Model1 db = new Model1();

        // GET: CarServices
        public ActionResult Index()
        {
            var carServices = db.CarServices.Include(c => c.Place);
            return View(carServices.ToList());
        }

        // GET: CarServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarService carService = db.CarServices.Find(id);
            if (carService == null)
            {
                return HttpNotFound();
            }
            return View(carService);
        }

        // GET: CarServices/Create
        public ActionResult Create()
        {
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Address");
            return View();
        }

        // POST: CarServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarServiceId,Name,ShiftStart,ShiftEnd,PlaceId")] CarService carService)
        {
            if (ModelState.IsValid)
            {
                db.CarServices.Add(carService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Address", carService.PlaceId);
            return View(carService);
        }

        // GET: CarServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarService carService = db.CarServices.Find(id);
            if (carService == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Address", carService.PlaceId);
            return View(carService);
        }

        // POST: CarServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarServiceId,Name,ShiftStart,ShiftEnd,PlaceId")] CarService carService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceId = new SelectList(db.Places, "PlaceId", "Address", carService.PlaceId);
            return View(carService);
        }

        // GET: CarServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarService carService = db.CarServices.Find(id);
            if (carService == null)
            {
                return HttpNotFound();
            }
            return View(carService);
        }

        // POST: CarServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarService carService = db.CarServices.Find(id);
            db.CarServices.Remove(carService);
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
