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
    public class AboutController : Controller
    {
        ResumeDBEntities db = new ResumeDBEntities();
        // GET: AdminArea/About
        public ActionResult Index()
        {
            return View(db.SectionAbouts.First());
        }

        public ActionResult Edit(int? id)
        {
            return View(db.SectionAbouts.First());
        }

        [HttpPost]
        public ActionResult Edit(int? id,string header,string description,HttpPostedFileBase image )
        {
            SectionAbout sectAb = db.SectionAbouts.FirstOrDefault(x => x.ID == id);
            if (image !=null)
            {
                WebImage img = new WebImage(image.InputStream);
                FileInfo file = new FileInfo(image.FileName);
                string imgName = Guid.NewGuid() + file.Extension;
                img.Save("~/Uploads/" + imgName);
                sectAb.PhotoUrl = "/Uploads/" + imgName;
            }
            sectAb.Header = header;
            sectAb.Description = description;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}