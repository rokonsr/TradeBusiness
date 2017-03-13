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
    public class SalesController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Customer).Include(s => s.UserInfo).Include(s => s.UserInfo1);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerUsername");
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleId,CustomerId,InvoiceNumber,TotalAmount,VatAmount,AdjustmentAmount,DiscountRate,DiscountAmountTotal,PaidAmount,PaymentMethod,IsActive,Remarks")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerUsername", sale.CustomerId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", sale.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", sale.UpdatedBy);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerUsername", sale.CustomerId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", sale.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", sale.UpdatedBy);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleId,CustomerId,InvoiceNumber,TotalAmount,VatAmount,AdjustmentAmount,DiscountRate,DiscountAmountTotal,PaidAmount,PaymentMethod,IsActive,Remarks")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerUsername", sale.CustomerId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", sale.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", sale.UpdatedBy);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
