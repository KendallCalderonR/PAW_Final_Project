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
    public class LostReportsController : Controller
    {
        private PAW_FinalProyectEntities1 db = new PAW_FinalProyectEntities1();

        // GET: LostReports
        public ActionResult Index()
        {
            var lostReport = db.LostReport.Include(l => l.SubCategory).Include(l => l.Usuario);
            return View(lostReport.ToList());
        }

        // GET: LostReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostReport lostReport = db.LostReport.Find(id);
            if (lostReport == null)
            {
                return HttpNotFound();
            }
            return View(lostReport);
        }

        // GET: LostReports/Create
        public ActionResult Create()
        {
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory");
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name");
            return View();
        }

        // POST: LostReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Report,Id_User,Description,Status,Id_SubCategory")] LostReport lostReport)
        {
            if (ModelState.IsValid)
            {
                db.LostReport.Add(lostReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory", lostReport.Id_SubCategory);
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name", lostReport.Id_User);
            return View(lostReport);
        }

        // GET: LostReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostReport lostReport = db.LostReport.Find(id);
            if (lostReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory", lostReport.Id_SubCategory);
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name", lostReport.Id_User);
            return View(lostReport);
        }

        // POST: LostReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Report,Id_User,Description,Status,Id_SubCategory")] LostReport lostReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lostReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_SubCategory = new SelectList(db.SubCategory, "Id_SubCategory", "NameSubCategory", lostReport.Id_SubCategory);
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name", lostReport.Id_User);
            return View(lostReport);
        }

        // GET: LostReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LostReport lostReport = db.LostReport.Find(id);
            if (lostReport == null)
            {
                return HttpNotFound();
            }
            return View(lostReport);
        }

        // POST: LostReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LostReport lostReport = db.LostReport.Find(id);
            db.LostReport.Remove(lostReport);
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
