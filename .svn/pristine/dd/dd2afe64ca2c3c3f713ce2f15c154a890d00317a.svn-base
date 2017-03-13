using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradeBusiness;
using System.IO;
using System.Text;
using TradeBusiness.DAL;

namespace TradeBusiness.Controllers
{
    public class ProductsController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Brand).Include(p => p.Category).Include(p => p.UserInfo).Include(p => p.UserInfo1);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductDescription,CategoryId,BrandId,ProductImage,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                bool yesUploadedSuccess = false;

                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        product.ProductImage = reader.ReadBytes(upload.ContentLength);
                        yesUploadedSuccess = true;
                    }

                }
                if (!yesUploadedSuccess)
                {

                    product.ProductImage = Encoding.ASCII.GetBytes("0");

                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", product.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", product.UpdatedBy);
            return View(product);
        }


        public ActionResult ImageShow(int ProductId)
        {
            Product product = db.Products.Find(ProductId);
            if (product.ProductImage != null)
            {
                return File(product.ProductImage, "image/jpg");
            }
            else
            {
                byte[] arrayFalseUpload = Encoding.ASCII.GetBytes("0");
                return File(arrayFalseUpload, "image/jpg");
            }
        }

        public byte[] getImageByte(int ProductId)
        {

            ExraconnectionConfig exConfig = new ExraconnectionConfig();
            DataSet dsProductImage = exConfig.GetData("select ProductImage from Product where ProductId =" + ProductId);
            return (byte[])dsProductImage.Tables[0].Rows[0][0];
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", product.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", product.UpdatedBy);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductDescription,CategoryId,BrandId,ProductImage,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload == null)
                {
                    upload = (HttpPostedFileBase)new MemoryPostedFile(getImageByte(product.ProductId));

                }

                if (upload != null)
                {
                    if (upload.ContentLength > 0)
                    {
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            product.ProductImage = reader.ReadBytes(upload.ContentLength);

                        }
                    }

                }


                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandName", product.BrandId);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", product.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", product.UpdatedBy);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        public class MemoryPostedFile : HttpPostedFileBase
        {
            private readonly byte[] fileBytes;
            private Stream inputStream;

            public MemoryPostedFile(byte[] fileBytes, string fileName = null)
            {
                this.fileBytes = fileBytes;
                this.FileName = fileName;
                this.InputStream = new MemoryStream(fileBytes);

            }

            public override int ContentLength => fileBytes.Length;

            public override string FileName { get; }

            public override Stream InputStream { get; }

            public override string ContentType
            {
                get { return "image/jpg"; }
            }
        }
    }
}
