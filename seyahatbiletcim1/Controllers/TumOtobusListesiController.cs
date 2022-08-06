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
    public class TumOtobusListesiController : Controller
    {
        private BiletContext db = new BiletContext();

        // GET: TumOtobusListesi
       public ActionResult Index(string NeredenArama, string NereyeArama, DateTime? TarihArama, int? FiyatOtoArama)
       {
            var otobuslar = from s in db.TumOtobusListesi
                            select s;

            if (!String.IsNullOrEmpty(NeredenArama))
            {
                otobuslar = otobuslar.Where(s => s.Nereden.ToUpper().Contains(NeredenArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(NereyeArama))
            {
                otobuslar = otobuslar.Where(s => s.Nereye.ToUpper().Contains(NereyeArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(TarihArama.ToString()))
            {
                otobuslar = otobuslar.Where(s => s.Tarih.ToString().Contains(TarihArama.ToString()));
            }
            if (!String.IsNullOrEmpty(FiyatOtoArama.ToString()))
            {
                otobuslar = otobuslar.Where(s => s.FiyatOto.ToString().ToUpper().Contains(FiyatOtoArama.ToString().ToUpper()));
            }

            return View(otobuslar.ToList());
        }

        // GET: TumOtobusListesi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TumOtobusListesi tumOtobusListesi = db.TumOtobusListesi.Find(id);
            if (tumOtobusListesi == null)
            {
                return HttpNotFound();
            }
            return View(tumOtobusListesi);
        }

        // GET: TumOtobusListesi/Create
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TumOtobusListesi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "TumOtobuslarID,Nereden,Nereye,Tarih,OtobusFirmaAdi,FiyatOto,YolcuKapasitesi")] TumOtobusListesi tumOtobusListesi)
        {
            if (ModelState.IsValid)
            {
                db.TumOtobusListesi.Add(tumOtobusListesi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tumOtobusListesi);
        }

        // GET: TumOtobusListesi/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TumOtobusListesi tumOtobusListesi = db.TumOtobusListesi.Find(id);
            if (tumOtobusListesi == null)
            {
                return HttpNotFound();
            }
            return View(tumOtobusListesi);
        }

        // POST: TumOtobusListesi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "TumOtobuslarID,Nereden,Nereye,Tarih,OtobusFirmaAdi,FiyatOto,YolcuKapasitesi")] TumOtobusListesi tumOtobusListesi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tumOtobusListesi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tumOtobusListesi);
        }

        // GET: TumOtobusListesi/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TumOtobusListesi tumOtobusListesi = db.TumOtobusListesi.Find(id);
            if (tumOtobusListesi == null)
            {
                return HttpNotFound();
            }
            return View(tumOtobusListesi);
        }

        // POST: TumOtobusListesi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            TumOtobusListesi tumOtobusListesi = db.TumOtobusListesi.Find(id);
            db.TumOtobusListesi.Remove(tumOtobusListesi);
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
