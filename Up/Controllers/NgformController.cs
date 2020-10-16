using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Up.Models;

namespace Up.Controllers
{
    public class NgformController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Ngform/
        public ActionResult Index()
        {
            return View(db.Ngforms.ToList());
        }

        // GET: /Ngform/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ngform ngform = db.Ngforms.Find(id);
            if (ngform == null)
            {
                return HttpNotFound();
            }
            return View(ngform);
        }

        // GET: /Ngform/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ngform/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,নাম,পিতা,মাতা,গ্রাম,ডাকঘর,ওয়ার্ড")] Ngform ngform)
        {
            if (ModelState.IsValid)
            {
                db.Ngforms.Add(ngform);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = ngform.Id });
            }

            return View(ngform);
        }

        // GET: /Ngform/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ngform ngform = db.Ngforms.Find(id);
            if (ngform == null)
            {
                return HttpNotFound();
            }
            return View(ngform);
        }

        // POST: /Ngform/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,নাম,পিতা,মাতা,গ্রাম,ডাকঘর,ওয়ার্ড")] Ngform ngform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ngform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ngform);
        }

        // GET: /Ngform/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ngform ngform = db.Ngforms.Find(id);
            if (ngform == null)
            {
                return HttpNotFound();
            }
            return View(ngform);
        }

        // POST: /Ngform/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ngform ngform = db.Ngforms.Find(id);
            db.Ngforms.Remove(ngform);
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
