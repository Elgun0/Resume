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
    public class Expertises1hController : Controller
    {
        private ResumeDBEntities db = new ResumeDBEntities();

        // GET: AdminArea/Expertises1h
        public ActionResult Index()
        {
            return View(db.Expertises1h.ToList());
        }

        // GET: AdminArea/Expertises1h/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises1h expertises1h = db.Expertises1h.Find(id);
            if (expertises1h == null)
            {
                return HttpNotFound();
            }
            return View(expertises1h);
        }

        // GET: AdminArea/Expertises1h/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/Expertises1h/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Header,Middle,Description")] Expertises1h expertises1h)
        {
            if (ModelState.IsValid)
            {
                db.Expertises1h.Add(expertises1h);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expertises1h);
        }

        // GET: AdminArea/Expertises1h/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises1h expertises1h = db.Expertises1h.Find(id);
            if (expertises1h == null)
            {
                return HttpNotFound();
            }
            return View(expertises1h);
        }

        // POST: AdminArea/Expertises1h/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Header,Middle,Description")] Expertises1h expertises1h)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expertises1h).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expertises1h);
        }

        // GET: AdminArea/Expertises1h/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises1h expertises1h = db.Expertises1h.Find(id);
            if (expertises1h == null)
            {
                return HttpNotFound();
            }
            return View(expertises1h);
        }

        // POST: AdminArea/Expertises1h/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expertises1h expertises1h = db.Expertises1h.Find(id);
            db.Expertises1h.Remove(expertises1h);
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
