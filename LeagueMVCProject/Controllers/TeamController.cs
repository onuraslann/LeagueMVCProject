using LeagueMVCProject.Models.EntityFramework;
using LeagueMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueMVCProject.Controllers
{
    
    public class TeamController : Controller
    {
        SuperLigEntities db = new SuperLigEntities();
        public ActionResult Index()
        {
            var model = db.Teams.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new TeamViewModels()
            {
                Leagues = db.Leagues.ToList(),
                Teams=new Teams()
            };
            return View( "Yeni",model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Teams teams)
        {
            if (!ModelState.IsValid)
            {
                var model = new TeamViewModels()
                {
                    Leagues = db.Leagues.ToList(),
                     Teams=teams
                };
                return View("Yeni", model);
            }
            if (teams.Id == 0)
            {
                db.Teams.Add(teams);
            }
            else
            {
                var updatedEntity = db.Entry(teams);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deletedTeam = db.Teams.Find(id);
            if (deletedTeam == null)
            {
                return HttpNotFound();
            }
            db.Teams.Remove(deletedTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new TeamViewModels()
            {
                Leagues = db.Leagues.ToList(),
                Teams = db.Teams.Find(id)


            };
            return View("Yeni", model);
            
        }
    }
}