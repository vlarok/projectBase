using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class AuthorBookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AuthorBook
        public ActionResult Index()
        {
            var autohorBooks = db.AutohorBooks.Include(a => a.Author).Include(a => a.Book);
            return View(autohorBooks.ToList());
        }

        // GET: AuthorBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AutohorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // GET: AuthorBook/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "FirstName");
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title");
            return View();
        }

        // POST: AuthorBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorBookId,AuthorId,BookId")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                db.AutohorBooks.Add(authorBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // GET: AuthorBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AutohorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // POST: AuthorBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorBookId,AuthorId,BookId")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(db.Books, "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // GET: AuthorBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = db.AutohorBooks.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // POST: AuthorBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorBook authorBook = db.AutohorBooks.Find(id);
            db.AutohorBooks.Remove(authorBook);
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
