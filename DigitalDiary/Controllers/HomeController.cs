using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class HomeController : Controller
    {
        public int id;
        ContentRepository noteRepo = new ContentRepository();
        // GET: Home
        public ActionResult Index(int id)
        {
            this.id = id;
            return View(noteRepo.GetAll(id));
        }

        public ActionResult Details(int id)
        {
            return View(noteRepo.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(noteRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Content con)
        {
            noteRepo.Update(con);
            return RedirectToAction("Index", new { id=this.id });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(noteRepo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            noteRepo.Remove(id);
            return RedirectToAction("Index", new { id = this.id });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Content con)
        {
            noteRepo.Insert(con);
            return RedirectToAction("Index", new { id = this.id });
        }

        [HttpGet, ActionName("logout")]
        public ActionResult back()
        {
            Session["username"] = null;
            Session["uid"] = null;
            return RedirectToAction("Index","Login");
        }
    }
}