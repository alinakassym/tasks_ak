using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using MvcApp.Repositories;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository _userRepository;
        public HomeController()
        {
            this._userRepository = new HomeRepository(new usersDBEntities());
        }

        public ActionResult Index()
        {
            var users = from user in _userRepository.GetUsers()
                        select user;
            return View(users);
        }

        public ActionResult Create()
        {
            return View(new usertbl());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usertbl usertbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.InsertUser(usertbl);
                    _userRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Невозможно сохранить изменения. Убедитесь, что все поля заполнены верно");
            }
            return View(usertbl);
        }

        public ActionResult Edit(int iduser)
        {
            usertbl user = _userRepository.GetUserByID(iduser);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usertbl usertbl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.UpdateUser(usertbl);
                    _userRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Невозможно сохранить изменения");
            }
            return View(usertbl);
        }

        public ActionResult Delete(int iduser, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Невозможно сохранить изменения";
            }
            usertbl usertbl = _userRepository.GetUserByID(iduser);
            return View(usertbl);
        }

        //
        // POST: /user/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int iduser)
        {
            try
            {
                usertbl usertbl = _userRepository.GetUserByID(iduser);
                _userRepository.DeleteUser(iduser);
                _userRepository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                    new System.Web.Routing.RouteValueDictionary {
                        { "iduser", iduser },
                        { "SaveChangesError", true}});
            }
            return RedirectToAction("Index");
        }
    }
}
