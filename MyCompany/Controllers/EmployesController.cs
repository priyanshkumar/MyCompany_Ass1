using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCompany.Models;

namespace MyCompany.Controllers
{
    public class EmployesController : Controller
    {
        private MyCompanyModel db = new MyCompanyModel();

        // GET: Employes
        public ActionResult Index()
        {
            var employes = db.Employes.Include(e => e.Branch).Include(e => e.Manager);
            return View(employes.ToList());
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return RedirectToAction("Index");
            }
            return View(employe);
        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            ViewBag.Branch_Id = new SelectList(db.Branches, "Branch_ID", "Branch_Name");
            ViewBag.Manager_Id = new SelectList(db.Managers, "Manager_Id", "Manager_Name");
            return View();
        }

        // POST: Employes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_Id,Manager_Id,Branch_Id,Employee_Name,Employee_Job,Employee_Email,City,Provience")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Employes.Add(employe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Branch_Id = new SelectList(db.Branches, "Branch_ID", "Branch_Name", employe.Branch_Id);
            ViewBag.Manager_Id = new SelectList(db.Managers, "Manager_Id", "Manager_Name", employe.Manager_Id);
            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Branch_Id = new SelectList(db.Branches, "Branch_ID", "Branch_Name", employe.Branch_Id);
            ViewBag.Manager_Id = new SelectList(db.Managers, "Manager_Id", "Manager_Name", employe.Manager_Id);
            return View(employe);
        }

        // POST: Employes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_Id,Manager_Id,Branch_Id,Employee_Name,Employee_Job,Employee_Email,City,Provience")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branch_Id = new SelectList(db.Branches, "Branch_ID", "Branch_Name", employe.Branch_Id);
            ViewBag.Manager_Id = new SelectList(db.Managers, "Manager_Id", "Manager_Name", employe.Manager_Id);
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employe employe = db.Employes.Find(id);
            db.Employes.Remove(employe);
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
