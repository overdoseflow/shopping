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
    public class MusterilerController : Controller
    {
        private STicaretEntities db = new STicaretEntities();

        // GET: Musteriler
        public ActionResult Index()
        {
            return View(db.Musterilers.ToList());
        }

        // GET: Musteriler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musterilers.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // GET: Musteriler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Musteriler/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriID,MusteriAdi,MusteriSoyadi,Adresi,TelNo,Telno2")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Musterilers.Add(musteriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteriler);
        }

        // GET: Musteriler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musterilers.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musteriler/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusteriID,MusteriAdi,MusteriSoyadi,Adresi,TelNo,Telno2")] Musteriler musteriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musteriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteriler);
        }

        // GET: Musteriler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteriler musteriler = db.Musterilers.Find(id);
            if (musteriler == null)
            {
                return HttpNotFound();
            }
            return View(musteriler);
        }

        // POST: Musteriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteriler musteriler = db.Musterilers.Find(id);
            db.Musterilers.Remove(musteriler);
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
