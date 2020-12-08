using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoanWeb.Models;

namespace DoanWeb.Areas.Admin.Controllers
{
    public class RoleAccountsController : Controller
    {
        private DoanWebEntities db = new DoanWebEntities();

        // GET: Manager/RoleAccounts
        public ActionResult Index()
        {
            return View(db.RoleAccounts.ToList());
        }

        // GET: Manager/RoleAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleAccount roleAccount = db.RoleAccounts.Find(id);
            if (roleAccount == null)
            {
                return HttpNotFound();
            }
            return View(roleAccount);
        }

        // GET: Manager/RoleAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/RoleAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idroleAccount,roleName")] RoleAccount roleAccount)
        {
            if (ModelState.IsValid)
            {
                db.RoleAccounts.Add(roleAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleAccount);
        }

        // GET: Manager/RoleAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleAccount roleAccount = db.RoleAccounts.Find(id);
            if (roleAccount == null)
            {
                return HttpNotFound();
            }
            return View(roleAccount);
        }

        // POST: Manager/RoleAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idroleAccount,roleName")] RoleAccount roleAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleAccount);
        }

        // GET: Manager/RoleAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleAccount roleAccount = db.RoleAccounts.Find(id);
            if (roleAccount == null)
            {
                return HttpNotFound();
            }
            return View(roleAccount);
        }

        // POST: Manager/RoleAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleAccount roleAccount = db.RoleAccounts.Find(id);
            db.RoleAccounts.Remove(roleAccount);
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
