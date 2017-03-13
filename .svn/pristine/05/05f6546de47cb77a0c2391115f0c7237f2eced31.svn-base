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
    public class PurchaseInvoiceFilesController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: PurchaseInvoiceFiles
        public ActionResult Index()
        {
            return View(db.PurchaseInvoiceFiles.ToList());
        }

        // GET: PurchaseInvoiceFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoiceFile purchaseInvoiceFile = db.PurchaseInvoiceFiles.Find(id);
            if (purchaseInvoiceFile == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoiceFile);
        }

        // GET: PurchaseInvoiceFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseInvoiceFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceFileId,FileName,FileSize,InvoiceFile")] PurchaseInvoiceFile purchaseInvoiceFile)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseInvoiceFiles.Add(purchaseInvoiceFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseInvoiceFile);
        }

        // GET: PurchaseInvoiceFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoiceFile purchaseInvoiceFile = db.PurchaseInvoiceFiles.Find(id);
            if (purchaseInvoiceFile == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoiceFile);
        }

        // POST: PurchaseInvoiceFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceFileId,FileName,FileSize,InvoiceFile")] PurchaseInvoiceFile purchaseInvoiceFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseInvoiceFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseInvoiceFile);
        }

        // GET: PurchaseInvoiceFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoiceFile purchaseInvoiceFile = db.PurchaseInvoiceFiles.Find(id);
            if (purchaseInvoiceFile == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoiceFile);
        }

        // POST: PurchaseInvoiceFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseInvoiceFile purchaseInvoiceFile = db.PurchaseInvoiceFiles.Find(id);
            db.PurchaseInvoiceFiles.Remove(purchaseInvoiceFile);
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
