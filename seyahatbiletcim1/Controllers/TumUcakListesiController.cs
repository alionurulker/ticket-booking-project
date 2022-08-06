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

namespace seyahatbiletcim1.Controllers
{
    public class TumUcakListesiController : Controller
    {
        private BiletContext db = new BiletContext();

        // GET: TumUcakListesi
        public ActionResult Index(string NeredenArama, string NereyeArama, string Sinif, DateTime? GidisTarihArama, int? FiyatUcakArama)
        {
            var Ucaklar = from s in db.TumUcakListesi
                            select s;

            if (!String.IsNullOrEmpty(NeredenArama))
            {
                Ucaklar = Ucaklar.Where(s => s.Nereden.ToUpper().Contains(NeredenArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(NereyeArama))
            {
                Ucaklar = Ucaklar.Where(s => s.Nereye.ToUpper().Contains(NereyeArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(Sinif))
            {
                Ucaklar = Ucaklar.Where(s => s.Sinif.ToUpper().Contains(Sinif.ToUpper()));
            }
            if (!String.IsNullOrEmpty(GidisTarihArama.ToString()))
            {
                Ucaklar = Ucaklar.Where(s => s.GidisTarihi.ToString().Contains(GidisTarihArama.ToString()));
            }
            if (!String.IsNullOrEmpty(FiyatUcakArama.ToString()))
            {
                Ucaklar = Ucaklar.Where(s => s.FiyatUcak.ToString().ToUpper().Contains(FiyatUcakArama.ToString().ToUpper()));
            }

            return View(Ucaklar.ToList());
        }

        // GET: TumUcakListesi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TumUcakListesi tumUcakListesi = db.TumUcakListesi.Find(id);
            if (tumUcakListesi == null)
            {
                return HttpNotFound();
            }
            return View(tumUcakListesi);
        }

        // GET: TumUcakListesi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TumUcakListesi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "TumUcaklarID,Nereden,Nereye,KalkısTarihi,UcakFirmaAdi,FiyatUcak,YolcuKapasitesi")] TumUcakListesi tumUcakListesi)
        {
            if (ModelState.IsValid)
            {
                db.TumUcakListesi.Add(tumUcakListesi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tumUcakListesi);
        }

        // GET: TumUcakListesi/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TumUcakListesi tumUcakListesi = db.TumUcakListesi.Find(id);
            if (tumUcakListesi == null)
            {
                return HttpNotFound();
            }
            return View(tumUcakListesi);
        }

        // POST: TumUcakListesi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "TumUcaklarID,Nereden,Nereye,DonusTarihi,GidisTarihi,Sinif,UcakFirmaAdi,FiyatUcak,YolcuKapasitesi")] TumUcakListesi tumUcakListesi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tumUcakListesi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tumUcakListesi);
        }

        // GET: TumUcakListesi/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TumUcakListesi tumUcakListesi = db.TumUcakListesi.Find(id);
            if (tumUcakListesi == null)
            {
                return HttpNotFound();
            }
            return View(tumUcakListesi);
        }

        // POST: TumUcakListesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            TumUcakListesi tumUcakListesi = db.TumUcakListesi.Find(id);
            db.TumUcakListesi.Remove(tumUcakListesi);
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
