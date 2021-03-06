using LeagueMVCProject.Models.EntityFramework;
using LeagueMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueMVCProject.Controllers
{
    [Authorize(Roles = "Botanik")]
    public class PlayerController : Controller
    {
        SuperLigEntities db = new SuperLigEntities();
        public ActionResult Index()
        {
            var model = db.Players.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new PlayerViewModels()
            {
                Leagues = db.Leagues.ToList(),
                Teams = db.Teams.ToList(),
                Players=new Players()
            };
            return View("Yeni", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Players players)
        {
            if (!ModelState.IsValid)
            {
                var model = new PlayerViewModels()
                {
                    Leagues = db.Leagues.ToList(),
                    Teams = db.Teams.ToList(),
                    Players=players
                };
                return View("Yeni", model);

            }
            if (players.Id == 0)
            {
                db.Players.Add(players);
            }
            else
            {
                var updatedEntity = db.Entry(players);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;

            
                    }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {

            var model = new PlayerViewModels()
            {
                Leagues = db.Leagues.ToList(),
                Teams = db.Teams.ToList(),
                Players = db.Players.Find(id)


            };
            return View("Yeni", model);
        }
        public ActionResult Delete(int id)
        {
            var deletePlayer = db.Players.Find(id);
            if (deletePlayer == null)
            {
                return HttpNotFound();
            }
            db.Players.Remove(deletePlayer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}