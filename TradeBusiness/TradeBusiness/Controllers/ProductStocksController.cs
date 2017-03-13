using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TradeBusiness;

namespace TradeBusiness.Controllers
{
    public class ProductStocksController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: ProductStocks
        public ActionResult Index()
        {
            var productStocks = db.ProductStocks.Include(p => p.Measurement).Include(p => p.Product).Include(p => p.Purchase).Include(p => p.UserInfo).Include(p => p.UserInfo1).Include(p => p.PriceType);
            return View(productStocks.ToList());
        }

        // GET: ProductStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStock productStock = db.ProductStocks.Find(id);
            if (productStock == null)
            {
                return HttpNotFound();
            }
            return View(productStock);
        }

        private ProductStock GetProductStok(int ProductId, int MeasurementId)
        {
            string executbleQuery = @"select  * from TradeBusinessDb.dbo.ProductStock where ProductId=" + ProductId +
           " and MeasurementId =" + MeasurementId +
           "  and ProductStockId in (select  max( ProductStockId) from TradeBusinessDb.dbo.ProductStock where ProductId=" +
           ProductId + " and MeasurementId =" + MeasurementId + ") ";
            ProductStock tempProdstock = db.Database.SqlQuery<ProductStock>(executbleQuery).FirstOrDefault();

            if (tempProdstock == null)
            {
                tempProdstock = new ProductStock { StockBalance = Convert.ToDecimal(0.0) };

            }

            return tempProdstock;

        }

        [HttpPost]
        public JsonResult GetProductStockBy(int ProductId, int MeasurementId)
        {

            ProductStock prodStock = GetProductStok(ProductId, MeasurementId);

            return Json(new
            {
              prodStockQty = prodStock.StockBalance.ToString()
            });

        }

        // GET: ProductStocks/Create
        public ActionResult Create()
        {


            if (Session["PurchaseIdForProductStock"] != null)
            {
                int PurchaseId = Convert.ToInt32(Session["PurchaseIdForProductStock"].ToString());
                ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "SupplierInvoiceNumber", PurchaseId);
            }
            else
            {
                return Redirect("/Purchases/Create");
            }

            ViewBag.MeasurementId = new SelectList(db.Measurements, "MeasurementId", "MeasurementName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeId", "PriceTypeName");
            return View();
        }

        // POST: ProductStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductStockId,ProductId,MeasurementId,Barcode,PurchaseId,PurchaseQuantity,ProductVat,CommisionRate,DiscountRate,ProductBuyRetailPrice,ProductBuyWholeSalePrice,ProductSalePrice,ProductWholeSalePrice,PriceTypeId,StockBalance,TotalAmount,ProductExpireDate,WarrantyPeriod,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] ProductStock productStock)
        {
            int PurchaseIdTemp = Convert.ToInt32(Session["PurchaseIdForProductStock"].ToString());
            if (ModelState.IsValid)
            {
                productStock.PurchaseId = PurchaseIdTemp;
                ProductStock prodStockTemp = GetProductStok(productStock.ProductId, productStock.MeasurementId);
                productStock.StockBalance = prodStockTemp.StockBalance + productStock.PurchaseQuantity;



                db.ProductStocks.Add(productStock);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            ViewBag.MeasurementId = new SelectList(db.Measurements, "MeasurementId", "MeasurementName", productStock.MeasurementId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productStock.ProductId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "SupplierInvoiceNumber", productStock.PurchaseId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", productStock.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", productStock.UpdatedBy);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeId", "PriceTypeName", productStock.PriceTypeId);
            return View(productStock);
        }

        // GET: ProductStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStock productStock = db.ProductStocks.Find(id);
            if (productStock == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeasurementId = new SelectList(db.Measurements, "MeasurementId", "MeasurementName", productStock.MeasurementId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productStock.ProductId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "SupplierInvoiceNumber", productStock.PurchaseId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", productStock.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", productStock.UpdatedBy);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeId", "PriceTypeName", productStock.PriceTypeId);
            return View(productStock);
        }

        // POST: ProductStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductStockId,ProductId,MeasurementId,Barcode,PurchaseId,PurchaseQuantity,ProductVat,CommisionRate,DiscountRate,ProductBuyRetailPrice,ProductBuyWholeSalePrice,ProductSalePrice,ProductWholeSalePrice,PriceTypeId,StockBalance,TotalAmount,ProductExpireDate,WarrantyPeriod,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeasurementId = new SelectList(db.Measurements, "MeasurementId", "MeasurementName", productStock.MeasurementId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productStock.ProductId);
            ViewBag.PurchaseId = new SelectList(db.Purchases, "PurchaseId", "SupplierInvoiceNumber", productStock.PurchaseId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", productStock.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", productStock.UpdatedBy);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeId", "PriceTypeName", productStock.PriceTypeId);
            return View(productStock);
        }

        // GET: ProductStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStock productStock = db.ProductStocks.Find(id);
            if (productStock == null)
            {
                return HttpNotFound();
            }
            return View(productStock);
        }

        // POST: ProductStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductStock productStock = db.ProductStocks.Find(id);
            db.ProductStocks.Remove(productStock);
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
