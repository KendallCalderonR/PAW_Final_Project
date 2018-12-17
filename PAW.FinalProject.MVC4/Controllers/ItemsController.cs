using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PAW.FinalProject.DB;

namespace PAW.FinalProject.MVC.Controllers
{
    public class ItemsController : Controller
    {
        private PAW_FinalProyectEntities1 db = new PAW_FinalProyectEntities1();

        // GET: Items
        public ActionResult Index()
        {
            var item = db.Item.Include(i => i.Status).Include(i => i.SubCategory);
            return View(item.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Name");
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory");
            return View();
        }

        // POST: Items/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Item,Id_Status,Id_SubCategory,Description,Picture,Date,Comments")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Item.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Name", item.Id_Status);
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory", item.Id_SubCategory);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Name", item.Id_Status);
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory", item.Id_SubCategory);
            return View(item);
        }

        // POST: Items/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Item,Id_Status,Id_SubCategory,Description,Picture,Date,Comments")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Name", item.Id_Status);
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory", item.Id_SubCategory);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
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
