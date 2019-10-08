using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{

  public partial class MyDB_Context : DbContext
  {

    public MyDB_Context() : base("name=MyDB_Context")
    {

      Database.SetInitializer(new MyDB_ContextSeeder());
    }

    public virtual DbSet<Book> Book { get; set; }
    public virtual DbSet<Category> Category { get; set; }
    public virtual DbSet<BookCategory> BookCategories { get; set; }


    //public virtual DbSet<FHIRLocation> FHIRLocation { get; set; }
    //public virtual DbSet<FHIRPractitioner> FHIRPractioner { get; set; }
    //public virtual DbSet<FHIRPractionerLocation> FHIRPractionerLocation { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BookCategory>()
          .HasKey(bc => new { bc.BookId, bc.CategoryId });

      modelBuilder.Entity<BookCategory>()
          .HasRequired(bc => bc.Book)
          .WithMany(b => b.BookCategories)
          .HasForeignKey(bc => bc.BookId);

      modelBuilder.Entity<BookCategory>()
          .HasRequired(bc => bc.Category)
          .WithMany(c => c.BookCategories)
          .HasForeignKey(bc => bc.CategoryId);



      //modelBuilder.Entity<FHIRPractionerLocation>()
      //  .HasKey(l => new { l.LocationId, l.PractitionerId });

      //modelBuilder.Entity<FHIRPractionerLocation>()
      //    .HasRequired(l => l.FHIRLocation)
      //    .WithMany(pl => pl.PractitionerLocations)
      //    .HasForeignKey(l => l.LocationId);

      //modelBuilder.Entity<FHIRPractionerLocation>()
      //    .HasRequired(p => p.FHIRPractitioner)
      //    .WithMany(pl => pl.PractitionerLocations)
      //    .HasForeignKey(p => p.PractitionerId);
    }
  }
}