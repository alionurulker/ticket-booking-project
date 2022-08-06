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
    public class UcakController : Controller
    {
        private BiletContext db = new BiletContext();

        // GET: Ucak
        public ActionResult Index(int? page)
        {

            int pageIndex = page ?? 1;
            int dataCount = 4;
            var result = db.Ucaklar1.OrderByDescending(x => x.UcakID).ToPagedList(pageIndex, dataCount);
            

            return View(result);
        }

        // GET: Ucak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucak ucak = db.Ucaklar1.Find(id);
            if (ucak == null)
            {
                return HttpNotFound();
            }
            return View(ucak);
        }

        // GET: Ucak/Create
        public ActionResult Create()
        {
            var Sehir = db.TumOtobusListesi.Select(x => new { x.OtobusFirmaAdi, x.TumOtobuslarID });
            ViewBag.UlkeListesi = new SelectList(Sehir.AsEnumerable(), "OtobusFirmaAdi", "OtobusFirmaAdi");
            return View();
        }

        // POST: Ucak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UcakID,Nereden,Nereye,Gtarih,Dtarih,UcakFirmaAdi,UFiyat,TekYon,YolcuSayisi,Sinif")] Ucak ucak)
        {
            if (ModelState.IsValid)
            {
                db.Ucaklar1.Add(ucak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ucak);
        }

        // GET: Ucak/Edit/5
        public ActionResult Edit(int? id)
        {
            var Sehir = db.TumOtobusListesi.Select(x => new { x.OtobusFirmaAdi, x.TumOtobuslarID });
            ViewBag.UlkeListesi = new SelectList(Sehir.AsEnumerable(), "OtobusFirmaAdi", "OtobusFirmaAdi");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucak ucak = db.Ucaklar1.Find(id);
            if (ucak == null)
            {
                return HttpNotFound();
            }
            return View(ucak);
        }

        // POST: Ucak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UcakID,Nereden,Nereye,Gtarih,Dtarih,UcakFirmaAdi,UFiyat,TekYon,YolcuSayisi,Sinif")] Ucak ucak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ucak);
        }

        // GET: Ucak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucak ucak = db.Ucaklar1.Find(id);
            if (ucak == null)
            {
                return HttpNotFound();
            }
            return View(ucak);
        }

        // POST: Ucak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ucak ucak = db.Ucaklar1.Find(id);
            db.Ucaklar1.Remove(ucak);
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
