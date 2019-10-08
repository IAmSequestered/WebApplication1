using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

  public partial class MyDB_ContextSeeder : DropCreateDatabaseIfModelChanges<MyDB_Context>
  {

    #region Categories
    protected override void Seed(MyDB_Context context)
    {

      IList<Category> myCategories = new List<Category>();

      myCategories.Add(new Category
      {
        CategoryId = 1,
        CategoryName = "My Books"
      });

      myCategories.Add(new Category
      {
        CategoryId = 2,
        CategoryName = "Good Books"
      });

      myCategories.Add(new Category
      {
        CategoryId = 3,
        CategoryName = "Bad Books"
      });


      context.Category.AddRange(myCategories);

      #endregion Categories

      #region Books

      IList<Book> myBooks = new List<Book>();

      myBooks.Add(new Book
      {
        BookId = 1,
        Title = "Book 1"
    });

      myBooks.Add(new Book
      {
        BookId = 2,
        Title = "Book 2"
      });

      myBooks.Add(new Book
      {
        BookId = 3,
        Title = "Book 3"
      });


      context.Book.AddRange(myBooks);

      #endregion Books

      #region Book Categories
      
      IList<BookCategory> myBCList = new List<BookCategory>();

      myBCList.Add(new BookCategory
      {
        BookId = myBooks.FirstOrDefault(c => c.Title == "Book 1").BookId,
        CategoryId = myCategories.FirstOrDefault(c => c.CategoryName == "My Books").CategoryId
      });

      myBCList.Add(new BookCategory
      {
        BookId = myBooks.FirstOrDefault(c => c.Title == "Book 1").BookId,
        CategoryId = myCategories.FirstOrDefault(c => c.CategoryName == "Good Books").CategoryId
      });

      myBCList.Add(new BookCategory
      {
        BookId = myBooks.FirstOrDefault(c => c.Title == "Book 2").BookId,
        CategoryId = myCategories.FirstOrDefault(c => c.CategoryName == "My Books").CategoryId
      });

      myBCList.Add(new BookCategory
      {
        BookId = myBooks.FirstOrDefault(c => c.Title == "Book 2").BookId,
        CategoryId = myCategories.FirstOrDefault(c => c.CategoryName == "Bad Books").CategoryId
      });

      myBCList.Add(new BookCategory
      {
        BookId = myBooks.FirstOrDefault(c => c.Title == "Book 3").BookId,
        CategoryId = myCategories.FirstOrDefault(c => c.CategoryName == "Good Books").CategoryId
      });

      myBCList.Add(new BookCategory
      {
        BookId = myBooks.FirstOrDefault(c => c.Title == "Book 3").BookId,
        CategoryId = myCategories.FirstOrDefault(c => c.CategoryName == "Bad Books").CategoryId
      });

      context.BookCategories.AddRange(myBCList);

      #endregion Book Categories
    }
  }
}

