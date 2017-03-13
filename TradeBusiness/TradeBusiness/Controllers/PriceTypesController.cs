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
    public class PriceTypesController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: PriceTypes
        public ActionResult Index()
        {
            return View(db.PriceTypes.ToList());
        }

        // GET: PriceTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = db.PriceTypes.Find(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }
            return View(priceType);
        }

        // GET: PriceTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceTypeId,PriceType1")] PriceType priceType)
        {
            if (ModelState.IsValid)
            {
                db.PriceTypes.Add(priceType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priceType);
        }

        // GET: PriceTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = db.PriceTypes.Find(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }
            return View(priceType);
        }

        // POST: PriceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceTypeId,PriceType1")] PriceType priceType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priceType);
        }

        // GET: PriceTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceType priceType = db.PriceTypes.Find(id);
            if (priceType == null)
            {
                return HttpNotFound();
            }
            return View(priceType);
        }

        // POST: PriceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceType priceType = db.PriceTypes.Find(id);
            db.PriceTypes.Remove(priceType);
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
