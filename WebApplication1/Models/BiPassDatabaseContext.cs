using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace MAMC.BiPass.Web.Models
{
  public partial class BiPassDatabase_Context : DbContext
  {
    public BiPassDatabase_Context()
      : base("name=" + ConfigurationManager.AppSettings["DbConnectionToUse"])
    {
      //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BiPassDatabase_Context, System.Data.Entity.Migrations.DbMigrationsConfiguration<BiPassDatabase_Context>>);
      //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BiPassDatabase_Context, MigrateDBConfiguration<BiPassDatabase_Context>>());
      if (ConfigurationManager.AppSettings["DoDatabaseSchemaUpdate"].ToLower() == "true")
      {
        Database.SetInitializer(new BiPassDatabaseContextSeeder());
      }
      else
      {
        Database.SetInitializer<BiPassDatabase_Context>(null);
      }
    }

    public virtual DbSet<FHIRLocation> FHIRLocations { get; set; }
    public virtual DbSet<FHIRPractitioner> FHIRPractitioners { get; set; }

    public virtual DbSet<FHIRLocationType> FHIRLocationTypes { get; set; }

    public virtual DbSet<FHIRDataSource> FHIRDataSource { get; set; }
    public virtual DbSet<EHRType> FHIREHRType { get; set; }

    public DbSet<FHIRPractionerLocations> FHIRPractionerLocations { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //Create the table for the many-to-many Location to Practioner relationship
      //modelBuilder.Entity<FHIRLocation>()
      //  .HasMany(t => t.Practitioners)
      //  .WithMany(t => t.FHIRLocations)
      //  .Map(m =>
      //  {
      //    m.ToTable("FHIRPractionerLocations");
      //    m.MapLeftKey("LocationId");
      //    m.MapRightKey("PractitionerId");
      //  })

      //;

      //Above is how I oirginally did it but I couldn't get from Locations to Practitioners when attempting to 
      // query between them. I found this: https://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration

      modelBuilder.Entity<FHIRPractionerLocations>()
        .HasKey(l => new { l.LocationId, l.PractitionerId });
      modelBuilder.Entity<FHIRPractionerLocations>()
          .HasRequired(l => l.FHIRLocation)
          .WithMany(pl => pl.PractitionerLocations)
          .HasForeignKey(l => l.LocationId);
      modelBuilder.Entity<FHIRPractionerLocations>()
          .HasRequired(p => p.FHIRPractitioner)
          .WithMany(pl => pl.PractitionerLocations)
          .HasForeignKey(p => p.PractitionerId);


      modelBuilder.Entity<FHIRLocation>()
      .HasRequired(p => p.FHIRLocationType)
      .WithMany()
      .HasForeignKey(Ty => Ty.LocationTypeId);


      modelBuilder.Entity<FHIRLocation>()
        .HasOptional(p => p.ParentFHIRLocation)
        .WithMany()
        .HasForeignKey(pl => pl.ParentFHIRLocationId);

      modelBuilder.Entity<FHIRLocationType>()
        .HasOptional(p => p.ParentFHIRLocationType)
        .WithMany()
        .HasForeignKey(pl => pl.ParentFHIRLocationTypeId);

      base.OnModelCreating(modelBuilder);
    }

    //public System.Data.Entity.DbSet<MAMC.BiPass.Web.Models.ViewModels.LocationListViewModel> LocationListViewModels { get; set; }
  }
}