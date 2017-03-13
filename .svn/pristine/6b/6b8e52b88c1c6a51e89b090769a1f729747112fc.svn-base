using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TradeBusiness;
using TradeBusiness.DAL;

namespace TradeBusiness.Controllers
{
    public class CompanyInfoesController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: CompanyInfoes
        public ActionResult Index()
        {
            var companyInfoes = db.CompanyInfoes.Include(c => c.UserInfo).Include(c => c.UserInfo1);
            return View(companyInfoes.ToList());
        }

        // GET: CompanyInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: CompanyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,CompanyName,CompanyLogo,CompanyAddress,CompanyPhone,CompanyFax,CompanyEmail,TradeLicense,TINCertificate,BSTIApproval,VATRegNumber,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] CompanyInfo companyInfo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                bool yesUploadedSuccess = false;

                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        companyInfo.CompanyLogo = reader.ReadBytes(upload.ContentLength);
                        yesUploadedSuccess = true;
                    }

                }
                if (!yesUploadedSuccess)
                {

                    companyInfo.CompanyLogo = Encoding.ASCII.GetBytes("0");

                }
                db.CompanyInfoes.Add(companyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", companyInfo.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", companyInfo.UpdatedBy);
            return View(companyInfo);
        }


        public ActionResult ImageShow(int CompanyId)
        {
            CompanyInfo companyInfo = db.CompanyInfoes.Find(CompanyId);
            if (companyInfo.CompanyLogo != null)
            {
                return File(companyInfo.CompanyLogo, "image/jpg");
            }
            else
            {
                byte[] arrayFalseUpload = Encoding.ASCII.GetBytes("0");
                return File(arrayFalseUpload, "image/jpg");
            }
        }


        public byte[] getImageByte(int CompanyId)
        {

            ExraconnectionConfig exConfig = new ExraconnectionConfig();
            DataSet dsCompanyLogo =  exConfig.GetData("select CompanyLogo from CompanyInfo where CompanyId =" + CompanyId);
            return (byte[])dsCompanyLogo.Tables[0].Rows[0][0];
        }




        // GET: CompanyInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);

            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", companyInfo.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", companyInfo.UpdatedBy);
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,CompanyName,CompanyLogo,CompanyAddress,CompanyPhone,CompanyFax,CompanyEmail,TradeLicense,TINCertificate,BSTIApproval,VATRegNumber,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] CompanyInfo companyInfo, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload == null)
                {
                     upload = (HttpPostedFileBase)new MemoryPostedFile(getImageByte(companyInfo.CompanyId));

                }

                if (upload != null)
                {
                    if (upload.ContentLength > 0)
                    {
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            companyInfo.CompanyLogo = reader.ReadBytes(upload.ContentLength);

                        }
                    }

                }



                db.Entry(companyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", companyInfo.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", companyInfo.UpdatedBy);
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyInfo companyInfo = db.CompanyInfoes.Find(id);
            db.CompanyInfoes.Remove(companyInfo);
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
