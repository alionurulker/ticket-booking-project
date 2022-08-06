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
    public class OtelController : Controller
    {
        private BiletContext db = new BiletContext();
        // GET: Otel
        public ActionResult Index(string NeredeArama, string KonukArama, string YildizSayisiArama, string TesisTipiArama, string GecelikFiyatAraligiArama, int? page)
        {
            var oteller = from s in db.Oteller
                          select s;

            int pageIndex = page ?? 1;
            int dataCount = 4;
            if (!String.IsNullOrEmpty(NeredeArama))
            {
                oteller = oteller.Where(s => s.Nerede.ToUpper().Contains(NeredeArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(KonukArama))
            {
                oteller = oteller.Where(s => s.Konuk.ToUpper().Contains(KonukArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(YildizSayisiArama))
            {
                oteller = oteller.Where(s => s.YildizSayisi.ToString().Contains(YildizSayisiArama));
            }
            if (!String.IsNullOrEmpty(TesisTipiArama))
            {
                oteller = oteller.Where(s => s.TesisTipi.ToUpper().Contains(TesisTipiArama.ToUpper()));
            }
            if (!String.IsNullOrEmpty(GecelikFiyatAraligiArama))
            {
                oteller = oteller.Where(s => s.GecelikFiyatAraligi.ToUpper().Contains(GecelikFiyatAraligiArama.ToUpper()));
            }
            return View(oteller.OrderByDescending(x => x.OtelID).ToPagedList(pageIndex, dataCount));
        }
        [CustomAuthorize(Roles ="Admin")]
        public ActionResult IndexAdmin()
        {
            var oteller = from s in db.Oteller
                          select s;
            return View(oteller.OrderByDescending(x => x.OtelID).ToList());
        }

        // GET: Otel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otel otel = db.Oteller.Find(id);
            if (otel == null)
            {
                return HttpNotFound();
            }
            return View(otel);
        }

        // GET: Otel/Create
        [CustomAuthorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Otel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OtelID,Nerede,GirisTarih,CikisTarih,Konuk,YildizSayisi,TesisTipi,FiyatAraligi")] Otel otel)
        {
            if (ModelState.IsValid)
            {
                db.Oteller.Add(otel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otel);
        }

        // GET: Otel/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otel otel = db.Oteller.Find(id);
            if (otel == null)
            {
                return HttpNotFound();
            }
            return View(otel);
        }

        // POST: Otel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "OtelID,Nerede,GirisTarih,CikisTarih,Konuk,YildizSayisi,TesisTipi,FiyatAraligi")] Otel otel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otel);
        }

        // GET: Otel/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otel otel = db.Oteller.Find(id);
            if (otel == null)
            {
                return HttpNotFound();
            }
            return View(otel);
        }

        // POST: Otel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Otel otel = db.Oteller.Find(id);
            db.Oteller.Remove(otel);
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
