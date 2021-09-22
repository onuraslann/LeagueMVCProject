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
                Teams = db.Teams.ToList(),
                Fixtures = new Fixtures()
            };
            return View("Yeni", model);

        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Fixtures fixtures)
        {
            if (!ModelState.IsValid)
            {
                var model = new FixtureViewModels()
                {
                    Teams = db.Teams.ToList(),
                    Fixtures=fixtures
                };
                return View("Yeni", model);
            }
            if (fixtures.Id == 0)
            {
                db.Fixtures.Add(fixtures);
            }
            else
            {
                var updatedEntity = db.Entry(fixtures);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Update(int id)
        {
            var model = new FixtureViewModels()
            {
                Teams = db.Teams.ToList(),
                Fixtures = db.Fixtures.Find(id)
            };
            return View("Yeni", model);
        }
        public ActionResult Delete(int id)
        {
            var deletedFixture = db.Fixtures.Find(id);
            if (deletedFixture == null)
            {
                return HttpNotFound();
            }
            db.Fixtures.Remove(deletedFixture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
        
  

}