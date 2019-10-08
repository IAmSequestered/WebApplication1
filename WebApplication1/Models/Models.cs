using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class Book
  {

    //public Book()
    //{
    //  //this.Categories = new HashSet<Category>();
    //  this.BookCategories = new HashSet<BookCategory>();
    //}

    public int BookId { get; set; }
    public string Title { get; set; }

    [DisplayName("Book Categories")]
    public ICollection<BookCategory> BookCategories { get; set; }

    //public ICollection<Category> Categories { get; set; }

  }
  public class Category
  {

    //public Category()
    //{
    //  //this.Books = new HashSet<Book>();
    //  this.BookCategories = new HashSet<BookCategory>();
    //}

    public int CategoryId { get; set; }

    [DisplayName("Category Name")]
    public string CategoryName { get; set; }
    public ICollection<BookCategory> BookCategories { get; set; }

    //public ICollection<Book> Books { get; set; }
  }


  public class BookCategory
  {
  //  public BookCategory()
  //{
  //  this.Categories = new HashSet<Category>();
  //    this.Books = new HashSet<Book>();
  //  }


    public int BookId { get; set; }
    public Book Book { get; set; }
    public int CategoryId { get; set; }
    [DisplayName("Book Category")]
    public Category Category { get; set; }

    //public ICollection<Category> Categories { get; set; }

    //public ICollection<Book> Books { get; set; }
  }

 
}