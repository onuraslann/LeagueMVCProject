using LeagueMVCProject.Models.EntityFramework;
using LeagueMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueMVCProject.Controllers
{
    public class FixtureController : Controller
    {
        SuperLigEntities db = new SuperLigEntities();
        public ActionResult Index()
        {
            var model = db.Fixtures.ToList();
            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new FixtureViewModels()
            {
                Teams = db.Teams.ToList()
            };
            return View("Yeni", model);

        }
        public ActionResult Kaydet(Fixtures fixtures)
        {
            if (fixtures.Id == 0)
            {
                db.Fixtures.Add(fixtures);
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
        
  

}