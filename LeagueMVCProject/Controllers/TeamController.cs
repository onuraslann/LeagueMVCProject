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
                Leagues = db.Leagues.ToList()
            };
            return View( "Yeni");
        }
    }
}