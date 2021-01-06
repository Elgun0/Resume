using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Areas.AdminArea.Controllers
{
    public class AHomeController : Controller
    {
        // GET: AdminArea/AHome
        public ActionResult Index()
        {
            return View();
        }
    }
}