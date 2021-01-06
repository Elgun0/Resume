using Resume.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Resume.Areas.AdminArea.Controllers
{
    public class MMenuController : Controller
    {
        ResumeDBEntities db = new ResumeDBEntities();

        // GET: AdminArea/MMenu
        public ActionResult Index()
        {
            return View(db.Section1.First());
        }
        public ActionResult Edit(int? id)
        {
            return View(db.Section1.First());
        }

        [HttpPost]
        public ActionResult Edit(int? id, string header, string description, HttpPostedFileBase image)
        {
            Section1 sect1 = db.Section1.FirstOrDefault(x => x.ID == id);
            if (image != null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo file = new FileInfo(image.FileName);
                string imgName = Guid.NewGuid() + file.Extension;
                img.Save("~/Uploads/" + imgName);
                sect1.PhotoUrl = "/Uploads/" + imgName;
            }
            sect1.Header = header;
            sect1.Description = description;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}