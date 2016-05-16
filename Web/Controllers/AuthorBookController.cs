using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL.Service;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class AuthorBookController : Controller
    {
        private AuhtorBookService _service;
        private AuthorService _author;
        private BookService _book;

        public AuthorBookController(AuhtorBookService service, AuthorService author, BookService book)
        {
            _service = service;
            _book = book;
            _author = author;
        }
        // GET: AuthorBook
        public ActionResult Index()
        {
           // var autohorBooks = db.AutohorBooks.Include(a => a.Author).Include(a => a.Book);
            return View(_service.All());
        }

        // GET: AuthorBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = _service.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // GET: AuthorBook/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName");
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title");
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
                _service.Add(authorBook);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // GET: AuthorBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = _service.Find(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title", authorBook.BookId);
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
                _service.Update(authorBook);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // GET: AuthorBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = _service.Find(id);
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
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
