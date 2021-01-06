using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        ResumeDBEntities db = new ResumeDBEntities();
        public ActionResult Index()
        {
            ViewBag.section1 = db.Section1.First();
            ViewBag.sectionAbout = db.SectionAbouts.First();
            ViewBag.sectionServices = db.SectionServices.ToList();
            ViewBag.expertises1 = db.Expertises1.ToList();
            ViewBag.expertises1h = db.Expertises1h.ToList();
            ViewBag.sectionWork = db.SectionWorks.ToList();
            ViewBag.sectionTestimonial = db.SectionTestimonials.ToList();
            ViewBag.sectionArticles = db.SectionArticles.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}