using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class LoginController : Controller
    {
        UserRepository userRepo = new UserRepository();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            int counting = userRepo.IsValidate(fc["Uname"].ToString(), fc["Upassword"].ToString());

            if (counting == 1)
            {
                User us = userRepo.GetDetailsByName("jami");
                Session["uid"] = us.Uid;
                Session["uname"] = us.Uname;
                return RedirectToAction("Index", "Home", new { id=us.Uid });
            }
            else
            {
                ViewBag.msg = "Wrong Credential";
                return RedirectToAction("Index");
            }

        }
    }
}