using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seyahatbiletcim1.DAL;
using seyahatbiletcim1.Models;
using PagedList;

namespace seyahatbiletcim1.Controllers
{
    [CustomAuthorize(Roles = "Kullanici")]
    public class OtobusController : Controller
    {
        private BiletContext db = new BiletContext();

        // GET: Otobus
        public ActionResult Index(int? page)
        {

            int pageIndex = page ?? 1;
            int dataCount = 4;
            var result = db.Otobuslar1.OrderByDescending(x => x.OtobusID).ToPagedList(pageIndex, dataCount);


            return View(result);
        }
        // GET: Otobus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otobus otobus = db.Otobuslar1.Find(id);
            if (otobus == null)
            {
                return HttpNotFound();
            }
            return View(otobus);
        }

        // GET: Otobus/Create
        public ActionResult Create()
        {
            var Sehir = db.TumOtobusListesi.Select(x => new { x.OtobusFirmaAdi, x.TumOtobuslarID });
            ViewBag.UlkeListesi = new SelectList(Sehir.AsEnumerable(), "OtobusFirmaAdi", "OtobusFirmaAdi");
            return View();
        }

        // POST: Otobus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OtobusID,Nereden,Nereye,Tarih,KoltukNo,FiyatOto,FirmaAdi,YolcuSayisiOto")] Otobus otobus)
        {
            if (ModelState.IsValid)
            {
                db.Otobuslar1.Add(otobus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otobus);
        }

        // GET: Otobus/Edit/5
        public ActionResult Edit(int? id)
        {
            var Sehir = db.TumOtobusListesi.Select(x => new { x.OtobusFirmaAdi, x.TumOtobuslarID });
            ViewBag.UlkeListesi = new SelectList(Sehir.AsEnumerable(), "OtobusFirmaAdi", "OtobusFirmaAdi");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otobus otobus = db.Otobuslar1.Find(id);
            if (otobus == null)
            {
                return HttpNotFound();
            }
            return View(otobus);
        }

        // POST: Otobus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OtobusID,Nereden,Nereye,Tarih,KoltukNo,FiyatOto,FirmaAdi,YolcuSayisiOto")] Otobus otobus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otobus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otobus);
        }

        // GET: Otobus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otobus otobus = db.Otobuslar1.Find(id);
            if (otobus == null)
            {
                return HttpNotFound();
            }
            return View(otobus);
        }

        // POST: Otobus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Otobus otobus = db.Otobuslar1.Find(id);
            db.Otobuslar1.Remove(otobus);
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
