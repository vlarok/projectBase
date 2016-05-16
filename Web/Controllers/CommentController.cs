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
    public class CommentController : Controller
    {
        private CommentService _service;
        private AuthorService _author;
        private BookService _book;

        public CommentController(CommentService service, AuthorService author, BookService book)
        {
            _service = service;
            _book = book;
            _author = author;
        }
        // GET: Comment
        public ActionResult Index()
        {
           // var comments = db.Comments.Include(c => c.Author).Include(c => c.Book);
            return View(_service.All());
        }

        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _service.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName");
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title");
            return View();
        }

        // POST: Comment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,CommentText,AuthorId,BookId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _service.Add(comment);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName", comment.AuthorId);
            ViewBag.BookId = new SelectList(_author.All(), "BookId", "Title", comment.BookId);
            return View(comment);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _service.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName", comment.AuthorId);
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title", comment.BookId);
            return View(comment);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,CommentText,AuthorId,BookId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _service.Update(comment);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_author.All(), "AuthorId", "FirstName", comment.AuthorId);
            ViewBag.BookId = new SelectList(_book.All(), "BookId", "Title", comment.BookId);
            return View(comment);
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _service.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
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
