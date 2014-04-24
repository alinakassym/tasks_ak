using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private usersDBEntities db = new usersDBEntities();

        public ActionResult Index()
        {
            return View(db.usertbl.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int iduser = 0)
        {
            usertbl usertbl = db.usertbl.Find(iduser);
            if (usertbl == null)
            {
                return HttpNotFound();
            }
            return View(usertbl);
        }

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

        public ActionResult Delete(int iduser = 0)
        {
            usertbl usertbl = db.usertbl.Find(iduser);
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
        public ActionResult DeleteConfirmed(int iduser)
        {
            usertbl usertbl = db.usertbl.Find(iduser);
            db.usertbl.Remove(usertbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
