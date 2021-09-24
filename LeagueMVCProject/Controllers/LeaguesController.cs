using LeagueMVCProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueMVCProject.Controllers
{
    [Authorize(Roles = "Admin,Botanik")]
    public class LeaguesController : Controller
    {
        SuperLigEntities db = new SuperLigEntities();
        public ActionResult Index()
        {
            var model = db.Leagues.ToList();
            return View(model);
        }
        public ActionResult Yeni( )
        {
            return View("Yeni",new Leagues());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Leagues leagues)
        {
            if (!ModelState.IsValid)
            {
                return View("Yeni");
            }
            if (leagues.Id == 0)
            {
                db.Leagues.Add(leagues);
            }
            else
            {
                var guncelenecekLig = db.Leagues.Find(leagues.Id);
                if (guncelenecekLig == null)
                {
                    return HttpNotFound();
                }
                guncelenecekLig.LeagueName = leagues.LeagueName;
            }
                                 
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            var silineceklig = db.Leagues.Find(id);
            if (silineceklig == null)
            {
                return HttpNotFound();
            }
            
            db.Leagues.Remove(silineceklig);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = db.Leagues.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Yeni", model);
        }
    }
}