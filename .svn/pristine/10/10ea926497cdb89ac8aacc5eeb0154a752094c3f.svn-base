using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradeBusiness;

namespace TradeBusiness.Controllers
{
    public class MeasurementsController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: Measurements
        public ActionResult Index()
        {
            var measurements = db.Measurements.Include(m => m.UserInfo).Include(m => m.UserInfo1);
            return View(measurements.ToList());
        }

        // GET: Measurements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // GET: Measurements/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeasurementId,MeasurementName,MeasurementDescription")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Measurements.Add(measurement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", measurement.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", measurement.UpdatedBy);
            return View(measurement);
        }

        // GET: Measurements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", measurement.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", measurement.UpdatedBy);
            return View(measurement);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeasurementId,MeasurementName,MeasurementDescription")] Measurement measurement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", measurement.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", measurement.UpdatedBy);
            return View(measurement);
        }

        // GET: Measurements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return HttpNotFound();
            }
            return View(measurement);
        }

        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measurement measurement = db.Measurements.Find(id);
            db.Measurements.Remove(measurement);
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
