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
    public class SaleDetailsController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: SaleDetails
        public ActionResult Index()
        {
            var saleDetails = db.SaleDetails.Include(s => s.Product).Include(s => s.Sale);
            return View(saleDetails.ToList());
        }

        // GET: SaleDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleDetail saleDetail = db.SaleDetails.Find(id);
            if (saleDetail == null)
            {
                return HttpNotFound();
            }
            return View(saleDetail);
        }

        // GET: SaleDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "Remarks");
            return View();
        }

        // POST: SaleDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleDetailId,SaleId,ProductId,SellQuantity,VatRate,SellPrice,DiscountRate")] SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                db.SaleDetails.Add(saleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", saleDetail.ProductId);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "Remarks", saleDetail.SaleId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleDetail saleDetail = db.SaleDetails.Find(id);
            if (saleDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", saleDetail.ProductId);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "Remarks", saleDetail.SaleId);
            return View(saleDetail);
        }

        // POST: SaleDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleDetailId,SaleId,ProductId,SellQuantity,VatRate,SellPrice,DiscountRate")] SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", saleDetail.ProductId);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "Remarks", saleDetail.SaleId);
            return View(saleDetail);
        }

        // GET: SaleDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleDetail saleDetail = db.SaleDetails.Find(id);
            if (saleDetail == null)
            {
                return HttpNotFound();
            }
            return View(saleDetail);
        }

        // POST: SaleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleDetail saleDetail = db.SaleDetails.Find(id);
            db.SaleDetails.Remove(saleDetail);
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
