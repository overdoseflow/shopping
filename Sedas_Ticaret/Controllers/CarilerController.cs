using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sedas_Ticaret.Models;

namespace Sedas_Ticaret.Controllers
{
    public class CarilerController : Controller
    {
        private STicaretEntities db = new STicaretEntities();

        // GET: Cariler
        public ActionResult Index()
        {
            var carilers = db.Carilers.Include(c => c.Musteriler).Include(c => c.Stoklar);
            return View(carilers.ToList());
        }

        // GET: Cariler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cariler cariler = db.Carilers.Find(id);
            if (cariler == null)
            {
                return HttpNotFound();
            }
            return View(cariler);
        }

        // GET: Cariler/Create
        public ActionResult Create()
        {
            ViewBag.MusteriID = new SelectList(db.Musterilers, "MusteriID", "MusteriAdi");
            ViewBag.StokID = new SelectList(db.Stoklars, "StokID", "StokAdi");
            return View();
        }

        // POST: Cariler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CariID,StokID,MusteriID,Tarih,Miktar,Tutar")] Cariler cariler)
        {
            if (ModelState.IsValid)
            {
                db.Carilers.Add(cariler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriID = new SelectList(db.Musterilers, "MusteriID", "MusteriAdi", cariler.MusteriID);
            ViewBag.StokID = new SelectList(db.Stoklars, "StokID", "StokAdi", cariler.StokID);
            return View(cariler);
        }

        // GET: Cariler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cariler cariler = db.Carilers.Find(id);
            if (cariler == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriID = new SelectList(db.Musterilers, "MusteriID", "MusteriAdi", cariler.MusteriID);
            ViewBag.StokID = new SelectList(db.Stoklars, "StokID", "StokAdi", cariler.StokID);
            return View(cariler);
        }

        // POST: Cariler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CariID,StokID,MusteriID,Tarih,Miktar,Tutar")] Cariler cariler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cariler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriID = new SelectList(db.Musterilers, "MusteriID", "MusteriAdi", cariler.MusteriID);
            ViewBag.StokID = new SelectList(db.Stoklars, "StokID", "StokAdi", cariler.StokID);
            return View(cariler);
        }

        // GET: Cariler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cariler cariler = db.Carilers.Find(id);
            if (cariler == null)
            {
                return HttpNotFound();
            }
            return View(cariler);
        }

        // POST: Cariler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cariler cariler = db.Carilers.Find(id);
            db.Carilers.Remove(cariler);
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
