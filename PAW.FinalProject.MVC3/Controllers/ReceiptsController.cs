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
    public class ReceiptsController : Controller
    {
        private PAW_FinalProyectEntities1 db = new PAW_FinalProyectEntities1();

        // GET: Receipts
        public ActionResult Index()
        {
            var receipt = db.Receipt.Include(r => r.Item).Include(r => r.Usuario);
            return View(receipt.ToList());
        }

        // GET: Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Item, "Id_Item", "Description");
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name");
            return View();
        }

        // POST: Receipts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_receipt,Id_User,ItemID,Date")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Receipt.Add(receipt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Item, "Id_Item", "Description", receipt.ItemID);
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name", receipt.Id_User);
            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Item, "Id_Item", "Description", receipt.ItemID);
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name", receipt.Id_User);
            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_receipt,Id_User,ItemID,Date")] Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receipt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Item, "Id_Item", "Description", receipt.ItemID);
            ViewBag.Id_User = new SelectList(db.Usuario, "Id_User", "Name", receipt.Id_User);
            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receipt receipt = db.Receipt.Find(id);
            db.Receipt.Remove(receipt);
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
