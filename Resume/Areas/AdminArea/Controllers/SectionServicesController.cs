using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Resume.Models;

namespace Resume.Areas.AdminArea.Controllers
{
    public class SectionServicesController : Controller
    {
        private ResumeDBEntities db = new ResumeDBEntities();

        // GET: AdminArea/SectionServices
        public ActionResult Index()
        {
            return View(db.SectionServices.ToList());
        }

        // GET: AdminArea/SectionServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionService sectionService = db.SectionServices.Find(id);
            if (sectionService == null)
            {
                return HttpNotFound();
            }
            return View(sectionService);
        }

        // GET: AdminArea/SectionServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/SectionServices/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhotoUrl,BtnName,Icon,Header,Description")] SectionService sectionService)
        {
            if (ModelState.IsValid)
            {
                db.SectionServices.Add(sectionService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sectionService);
        }

        // GET: AdminArea/SectionServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionService sectionService = db.SectionServices.Find(id);
            if (sectionService == null)
            {
                return HttpNotFound();
            }
            return View(sectionService);
        }

        // POST: AdminArea/SectionServices/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhotoUrl,BtnName,Icon,Header,Description")] SectionService sectionService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sectionService);
        }

        // GET: AdminArea/SectionServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionService sectionService = db.SectionServices.Find(id);
            if (sectionService == null)
            {
                return HttpNotFound();
            }
            return View(sectionService);
        }

        // POST: AdminArea/SectionServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionService sectionService = db.SectionServices.Find(id);
            db.SectionServices.Remove(sectionService);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
