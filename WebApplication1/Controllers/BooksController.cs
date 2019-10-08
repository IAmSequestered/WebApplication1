using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  public class BooksController : Controller
  {
    private MyDB_Context db = new MyDB_Context();

    // GET: Books
    public ActionResult Index()
    {

      var MyBookList = db.Book;
        //.Include(bc => bc.BookCategories);

       

      var aCount = MyBookList.Count();

      var aList = MyBookList.ToList();

      return View(db.Book.ToList());
    }

    

    // GET: Books/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }


      //BookManagementViewModel

      // db.Category.Where(c => c. == categoryId).SelectMany(c => c.Articles) ?
      var myVal = db.Book.Where(b => b.BookId == id)
        .Include(bc => bc.BookCategories)
        .SelectMany(c => c.BookCategories)
        .ToList();

      Book book = db.Book.Find(id);

      Book book2 = db.Book.FirstOrDefault(b => b.BookId == id);

      var cow = book2.BookCategories.ToList();

      foreach (BookCategory myBookCategory in book2.BookCategories)
      {
        myBookCategory.Category = db.Category.FirstOrDefault(c => c.CategoryId == myBookCategory.CategoryId);
      }

      if (book == null)
      {
        return HttpNotFound();
      }
      return View(book);
    }

    // GET: Books/Details/5
    public ActionResult DetailsOriginal(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      // db.Category.Where(c => c. == categoryId).SelectMany(c => c.Articles) ?
      //var myVal = db.Book.Where(b => b.BookId == id)
      //  .Include(bc => bc.BookCategories)
      //  .SelectMany(c => c.BookCategories)
      //  .ToList();

      Book book = db.Book.Find(id);
      if (book == null)
      {
        return HttpNotFound();
      }
      return View(book);
    }


    // GET: Books/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Books/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "BookId,Title")] Book book)
    {
      if (ModelState.IsValid)
      {
        db.Book.Add(book);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(book);
    }

    // GET: Books/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Book book = db.Book.Find(id);
      if (book == null)
      {
        return HttpNotFound();
      }
      return View(book);
    }

    // POST: Books/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "BookId,Title")] Book book)
    {
      if (ModelState.IsValid)
      {
        db.Entry(book).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(book);
    }

    // GET: Books/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Book book = db.Book.Find(id);
      if (book == null)
      {
        return HttpNotFound();
      }
      return View(book);
    }

    // POST: Books/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Book book = db.Book.Find(id);
      db.Book.Remove(book);
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
