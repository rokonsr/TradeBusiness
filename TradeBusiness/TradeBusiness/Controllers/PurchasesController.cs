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
    public class PurchasesController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: Purchases
        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.PurchaseInvoiceFile).Include(p => p.Supplier).Include(p => p.UserInfo).Include(p => p.UserInfo1);
            return View(purchases.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceFileId = new SelectList(db.PurchaseInvoiceFiles, "InvoiceFileId", "FileName");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseId,SupplierId,SupplierInvoiceNumber,PurchaseInvoice,InvoiceFileId,PurchaseDate,TotalAmount,AdjustmentAmount,DiscountRate,TotalDiscountAmount,PaidAmount,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();
                Int32 getMaxId = db.Purchases.Max(m => m.PurchaseId);
                Session["PurchaseIdForProductStock"] = getMaxId;
                return Redirect("/ProductStocks/Create");
            }

            ViewBag.InvoiceFileId = new SelectList(db.PurchaseInvoiceFiles, "InvoiceFileId", "FileName", purchase.InvoiceFileId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchase.SupplierId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", purchase.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", purchase.UpdatedBy);
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceFileId = new SelectList(db.PurchaseInvoiceFiles, "InvoiceFileId", "FileName", purchase.InvoiceFileId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchase.SupplierId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", purchase.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", purchase.UpdatedBy);
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseId,SupplierId,SupplierInvoiceNumber,PurchaseInvoice,InvoiceFileId,PurchaseDate,TotalAmount,AdjustmentAmount,DiscountRate,TotalDiscountAmount,PaidAmount,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceFileId = new SelectList(db.PurchaseInvoiceFiles, "InvoiceFileId", "FileName", purchase.InvoiceFileId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchase.SupplierId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", purchase.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", purchase.UpdatedBy);
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            db.Purchases.Remove(purchase);
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
