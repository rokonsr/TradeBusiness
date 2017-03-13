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
    public class SuppliersController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = db.Suppliers.Include(s => s.UserInfo).Include(s => s.UserInfo1);
            return View(suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,SupplierName,SupplierContactPerson,SupplierDescription,SupplierAddress,SupplierContactNo,SupplierEmail,SupplierReference,SupplierReferenceContactNo,TINCertificate,VatRegistration,Remarks")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", supplier.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", supplier.UpdatedBy);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", supplier.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", supplier.UpdatedBy);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,SupplierName,SupplierContactPerson,SupplierDescription,SupplierAddress,SupplierContactNo,SupplierEmail,SupplierReference,SupplierReferenceContactNo,TINCertificate,VatRegistration,Remarks")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", supplier.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", supplier.UpdatedBy);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
