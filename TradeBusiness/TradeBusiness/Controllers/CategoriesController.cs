using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TradeBusiness;
using TradeBusiness.DAL;

namespace TradeBusiness.Controllers
{
    public class CategoriesController : Controller
    {
        private TradeBusinessDbEntities db = new TradeBusinessDbEntities();

        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.Category2).Include(c => c.UserInfo).Include(c => c.UserInfo1);
            return View(categories.ToList());
        }

        //public JsonResult savingStore(string strStoreValue)
        //{
        //    Session["hdValue"] = strStoreValue;

        //    return Json(strStoreValue);
        //}

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryParentId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CategoryDescription,CategoryParentId,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] Category category , bool chkIsParent)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryParentId == 0 || chkIsParent==true)
                {

                    var maxId = db.Database.SqlQuery<int>("select dbo.GetLastIdentity('Category')").SingleOrDefault();
                    if (Convert.ToInt32(maxId.ToString()) > 1)
                    {
                        maxId = Convert.ToInt32((Convert.ToInt32(maxId.ToString()) + 1).ToString());
                    }
                    category.CategoryParentId = maxId;
                }



                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryParentId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryParentId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", category.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", category.UpdatedBy);
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryParentId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryParentId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", category.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", category.UpdatedBy);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,CategoryDescription,CategoryParentId,IsActive,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,SortedBy,Remarks")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryParentId = new SelectList(db.Categories, "CategoryId", "CategoryName", category.CategoryParentId);
            ViewBag.CreatedBy = new SelectList(db.UserInfoes, "UserId", "Username", category.CreatedBy);
            ViewBag.UpdatedBy = new SelectList(db.UserInfoes, "UserId", "Username", category.UpdatedBy);
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Category category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
               
            }
            catch (Exception ex)
            {

            }
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
