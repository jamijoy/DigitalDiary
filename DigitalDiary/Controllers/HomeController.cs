using DigitalDiary.Models;
using DigitalDiary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class HomeController : Controller
    {
        UserRepository repo = new UserRepository();
        // GET: Person
        public ActionResult Index()
        {
            return View(repo.GetAll());
        }
        public ActionResult Details(int id)
        {
            return View(repo.Get(id));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(user u)
        {
            repo.Update(u);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            repo.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateNote()
        {
            return RedirectToAction("Index","Note");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(user u)
        {
            repo.Insert(u);
            return RedirectToAction("Index");
        }
    }
}
