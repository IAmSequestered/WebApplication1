using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
  public class BookManagementViewModel
  {
    public IList<Book> Books { get; set; }
    public IList<Category> AvailableCategories { get; set; }

  }

 
}