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
    public class BrandsController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        


        // GET: Brands
        public ActionResult Index()
        {
            var brands = db.Brands.Include(b => b.UserInfo).Include(b => b.UserInfo1);
            return View(brands.ToList());
        }

        // GET: Brands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandId,BrandName,BrandDescription,IsActive")] Brand brand)
        {
            if (ModelState.IsValid)
            {


                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", brand.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", brand.UpdatedBy);
            return View(brand);
        }

        // GET: Brands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", brand.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", brand.UpdatedBy);
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandId,BrandName,BrandDescription,IsActive")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", brand.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", brand.UpdatedBy);
            return View(brand);
        }

        // GET: Brands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
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
