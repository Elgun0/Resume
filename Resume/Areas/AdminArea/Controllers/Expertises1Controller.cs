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
    public class Expertises1Controller : Controller
    {
        private ResumeDBEntities db = new ResumeDBEntities();

        // GET: AdminArea/Expertises1
        public ActionResult Index()
        {
            return View(db.Expertises1.ToList());
        }

        // GET: AdminArea/Expertises1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises1 expertises1 = db.Expertises1.Find(id);
            if (expertises1 == null)
            {
                return HttpNotFound();
            }
            return View(expertises1);
        }

        // GET: AdminArea/Expertises1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminArea/Expertises1/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Header,Middle,Description")] Expertises1 expertises1)
        {
            if (ModelState.IsValid)
            {
                db.Expertises1.Add(expertises1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expertises1);
        }

        // GET: AdminArea/Expertises1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises1 expertises1 = db.Expertises1.Find(id);
            if (expertises1 == null)
            {
                return HttpNotFound();
            }
            return View(expertises1);
        }

        // POST: AdminArea/Expertises1/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Header,Middle,Description")] Expertises1 expertises1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expertises1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expertises1);
        }

        // GET: AdminArea/Expertises1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises1 expertises1 = db.Expertises1.Find(id);
            if (expertises1 == null)
            {
                return HttpNotFound();
            }
            return View(expertises1);
        }

        // POST: AdminArea/Expertises1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expertises1 expertises1 = db.Expertises1.Find(id);
            db.Expertises1.Remove(expertises1);
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
