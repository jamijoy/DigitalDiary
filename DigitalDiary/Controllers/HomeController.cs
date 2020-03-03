using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class HomeController : Controller
    {
        public int id;
        ContentRepository noteRepo = new ContentRepository();
        UserRepository userRepo = new UserRepository();
        // GET: Home
        public ActionResult Index(int id)
        {
            if (Session["uname"] != null && Session["uid"] != null)
            {
                this.id = id;
                return View(noteRepo.GetAll(id));
            }
            else
            {
                return RedirectToAction("logout");
            }
        }

        public ActionResult Details(int id)
        {
            return View(noteRepo.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Session["newNoteId"] = id;
            return View(noteRepo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Content con)
        {
            //return con.Nid.ToString()+">>"+con.Uid.ToString() + ">>" + con.Nname + ">>" + con.Ntext + ">>" + con.Ndate + ">>" + con.Npriority.ToString() + ">>" + con.Nimage;

            con.Nid = Convert.ToInt32(Session["newNoteId"]);
            con.Uid = Convert.ToInt32(Session["uid"]);
            con.Ndate = DateTime.Now.ToString();

            try
            {
                string ext = Path.GetExtension(con.imageFile.FileName);
                string fileName = Session["newNoteId"].ToString() + ext;
                con.Nimage = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                con.imageFile.SaveAs(fileName);

                noteRepo.Update(con);
                return RedirectToAction("Index", new { id = con.Uid });
                //return con.Nimage.ToString();
            }
            catch (Exception ex)
            {
                //con.Nimage = "~/Image/" + "DigitalDiaryDefault.jpg";
                con.Nimage = noteRepo.GetImageLink(Convert.ToInt32(Session["newNoteId"]));
                noteRepo.Insert(con);
                return RedirectToAction("Index", new { id = con.Uid });
                //return con.Nimage.ToString();
            }
        }

        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            return View(userRepo.Get(id));
        }
        [HttpPost]
        public ActionResult EditProfile(User us)
        {
            us.Uid = Convert.ToInt32(Session["uid"]);
            userRepo.Update(us);
            return RedirectToAction("Index", new { id = this.id });
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
            return RedirectToAction("Index", new { id = Session["uid"] });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Content con)
        {
            con.Ndate = DateTime.Now.ToString();
            con.Uid = Convert.ToInt32(Session["uid"]);

            try {
                int nextNo = noteRepo.GetLastNoteNumber() + 1;

                string ext = Path.GetExtension(con.imageFile.FileName);
                string fileName = nextNo.ToString() + ext;
                con.Nimage = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                con.imageFile.SaveAs(fileName);


                noteRepo.Insert(con);
                return RedirectToAction("Index", new { id = con.Uid });
            }
            catch(Exception ex)
            {
                con.Nimage = "~/Image/" + "DigitalDiaryDefault.jpg";
                
                noteRepo.Insert(con);
                return RedirectToAction("Index", new { id = con.Uid });
            }
        }

        [HttpGet, ActionName("logout")]
        public ActionResult back()
        {
            Session["uname"] = null;
            Session["uid"] = null;
            Session["newNoteId"] = null;
            return RedirectToAction("Index","Login");
        }
    }
}