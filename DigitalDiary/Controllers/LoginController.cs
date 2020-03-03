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
        [HttpPost,ActionName("validate")]
        public ActionResult check(FormCollection fc)
        {
            int counting = userRepo.IsValidate(fc["Uname"].ToString(), fc["Upassword"].ToString());

            if (counting == 1)
            {
                User us = userRepo.GetDetailsByName(fc["Uname"].ToString());
                Session["uid"] = us.Uid;
                Session["uname"] = us.Uname;
                return RedirectToAction("Index", "Home", new { id=us.Uid });
            }
            else
            {
                ViewData["msg"] = "Wrong Credential";
                ViewBag.msg = "Wrong Credential";
                TempData["mgs"] = "Wrong Credential";
                return RedirectToAction("Index");
            }

        }
        [HttpPost, ActionName("register")]
        public ActionResult insertData(FormCollection fc)
        {
            userRepo.Insert(fc["RegName"].ToString(), fc["RegPassword"].ToString());
            TempData["mgs"] = "Registered Successfully";
            return RedirectToAction("Index");
        }
    }
}