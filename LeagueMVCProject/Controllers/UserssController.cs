using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeagueMVCProject.Models.EntityFramework;

namespace LeagueMVCProject.Controllers
{
    public class UserssController : Controller
    {
        private SuperLigEntities db = new SuperLigEntities();

        // GET: Userss
        public ActionResult Index()
        {
            return View(db.Userss.ToList());
        }

        // GET: Userss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userss userss = db.Userss.Find(id);
            if (userss == null)
            {
                return HttpNotFound();
            }
            return View(userss);
        }

        // GET: Userss/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Userss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Password,Role")] Userss userss)
        {
            if (ModelState.IsValid)
            {
                db.Userss.Add(userss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userss);
        }

        // GET: Userss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userss userss = db.Userss.Find(id);
            if (userss == null)
            {
                return HttpNotFound();
            }
            return View(userss);
        }

        // POST: Userss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password,Role")] Userss userss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userss);
        }

        // GET: Userss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Userss userss = db.Userss.Find(id);
            if (userss == null)
            {
                return HttpNotFound();
            }
            return View(userss);
        }

        // POST: Userss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userss userss = db.Userss.Find(id);
            db.Userss.Remove(userss);
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
