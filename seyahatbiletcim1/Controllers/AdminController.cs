using seyahatbiletcim1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace seyahatbiletcim1.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index(int? page)
        {
            int pageIndex = page ?? 1;
            int dataCount = 4;
            var result = db.Users.OrderByDescending(x => x.Id).ToPagedList(pageIndex, dataCount);
            return View(result);
        }
        public ActionResult Login()
        {
            return View();
        }
       
    }
}