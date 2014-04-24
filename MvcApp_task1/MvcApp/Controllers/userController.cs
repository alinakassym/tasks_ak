using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class userController : Controller
    {
        private usersDBEntities db = new usersDBEntities();

        //
        // GET: /user/

        public ActionResult Index()
        {
            return View(db.usertbl.ToList());
        }

        //
        // GET: /user/Details/5

        public ActionResult Details(int id = 0)
        {
            usertbl usertbl = db.usertbl.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        //
        // GET: /user/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /user/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usertbl usertbl)
        {
            if (ModelState.IsValid)
            {
                db.usertbl.Add(usertbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usertbl);
        }

        //
        // GET: /user/Edit/5

        public ActionResult Edit(int id = 0)
        {
            usertbl usertbl = db.usertbl.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        //
        // POST: /user/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usertbl usertbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usertbl);
        }

        //
        // GET: /user/Delete/5

        public ActionResult Delete(int id = 0)
        {
            usertbl usertbl = db.usertbl.Find(id);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

        //
        // POST: /user/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usertbl usertbl = db.usertbl.Find(id);
            db.usertbl.Remove(usertbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}