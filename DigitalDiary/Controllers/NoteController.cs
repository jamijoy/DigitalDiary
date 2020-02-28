using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class NoteController : Controller
    {
        //
        // GET: /Note/
        NoteRepository noteRepo = new NoteRepository();
        public ActionResult Index()
        {
            return View(noteRepo.GetAllNote());
            //return "Note To Preview";
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note n)
        {
            noteRepo.Insert(n);
            return RedirectToAction("Index");
        }

    }
}
