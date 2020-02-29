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
        ContentRepository noteRepo = new ContentRepository();
        // GET: Home
        public ActionResult Index(int id)
        {
            return View(noteRepo.GetAll(id));
        }
    }
}