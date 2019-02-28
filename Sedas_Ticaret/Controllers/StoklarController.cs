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
    public class StoklarController : Controller
    {
        private STicaretEntities db = new STicaretEntities();

        // GET: Stoklar
        public ActionResult Index()
        {
            return View(db.Stoklars.ToList());
        }

        // GET: Stoklar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoklar stoklar = db.Stoklars.Find(id);
            if (stoklar == null)
            {
                return HttpNotFound();
            }
            return View(stoklar);
        }

        // GET: Stoklar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stoklar/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StokID,StokAdi,StokKodu,OlcuBirimi,GrupAdi,KDV,BirimFiyati,GirisMiktari")] Stoklar stoklar)
        {
            if (ModelState.IsValid)
            {
                db.Stoklars.Add(stoklar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stoklar);
        }

        // GET: Stoklar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoklar stoklar = db.Stoklars.Find(id);
            if (stoklar == null)
            {
                return HttpNotFound();
            }
            return View(stoklar);
        }

        // POST: Stoklar/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StokID,StokAdi,StokKodu,OlcuBirimi,GrupAdi,KDV,BirimFiyati,GirisMiktari")] Stoklar stoklar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stoklar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stoklar);
        }

        // GET: Stoklar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoklar stoklar = db.Stoklars.Find(id);
            if (stoklar == null)
            {
                return HttpNotFound();
            }
            return View(stoklar);
        }

        // POST: Stoklar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stoklar stoklar = db.Stoklars.Find(id);
            db.Stoklars.Remove(stoklar);
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
