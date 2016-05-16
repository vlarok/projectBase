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
    public class BookController : Controller
    {
        private BookService _service;
        private PublisherService _publisher;
        public BookController(BookService service, PublisherService publisher)
        {
            _service = service;
            _publisher = publisher;
        }
        // GET: Book
        public ActionResult Index()
        {
          //  var books = db.Books.Include(b => b.Publisher);
            return View(_service.All());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _service.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.PublisherId = new SelectList(_publisher.All(), "PublisherId", "PublisherName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _service.Add(book);
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(_publisher.All(), "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _service.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherId = new SelectList(_publisher.All(), "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,PublisherId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _service.Update(book);
                return RedirectToAction("Index");
            }
            ViewBag.PublisherId = new SelectList(_publisher.All(), "PublisherId", "PublisherName", book.PublisherId);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _service.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
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
