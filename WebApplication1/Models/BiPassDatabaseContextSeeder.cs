using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MAMC.BiPass.Web.Models
{
  public class BiPassDatabaseContextSeeder : DropCreateDatabaseIfModelChanges<BiPassDatabase_Context>
  {

    protected override void Seed(BiPassDatabase_Context context)
    {
      #region LocationsTypesTree
      //List<FHIRLocationType> fHIRLocationTypes = new List<FHIRLocationType>();

      FHIRLocationType fHIRLocationTypesTree = new FHIRLocationType()
      {

        LocationTypeId = 30,
        Name = "Clinic",
        Level = 30,
        ParentFHIRLocationTypeId = 20,
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now,


        //Create a Medical Facility Type within the region type.
        ParentFHIRLocationType = new FHIRLocationType()
        {
          Name = "Medical Facility",
          Level = 20,

          IsActive = true,
          DateCreated = DateTime.Now,
          LastUpdated = DateTime.Now,
          //Now, add a couple of locations within that facility.
          //    FHIRLocations = new List<FHIRLocation>()
          //    {

          //      new FHIRLocation()
          //      {
          //        LocationId = "20", 
          //        Name = "Medical Facility 20",              
          //        IsActive = true,
          //        DateCreated = DateTime.Now,
          //        LastUpdated = DateTime.Now,

          //      },

          //      new FHIRLocation()
          //      {
          //        LocationId = "21",
          //        Name = "Medical Facility 21",
          //        IsActive = true,
          //        DateCreated = DateTime.Now,
          //        LastUpdated = DateTime.Now,

          //      }

          //                ////Create a clinic in a facility 
          ////FHIRLocation fHIRLocation101 = new FHIRLocation()
          ////{
          ////  LocationId = "4048128",
          ////  Name = "Baseline East",
          ////  ParentFHIRLocationId = "21",
          ////  LocationType = 30,
          ////  IsActive = true,
          ////  DateCreated = DateTime.Now,
          ////  LastUpdated = DateTime.Now

          //    },

          //Create the next level up, the Region
          ParentFHIRLocationType = new FHIRLocationType()
          {
            Name = "Region",
            Level = 10,
            IsActive = true,
            DateCreated = DateTime.Now,
            LastUpdated = DateTime.Now,

            //Create the top level Location Type of Country
            ParentFHIRLocationType = new FHIRLocationType()
            {
              Name = "Country",
              Level = 5,
              ParentFHIRLocationTypeId = null,
              IsActive = true,
              DateCreated = DateTime.Now,
              LastUpdated = DateTime.Now
            }
          }
        }

      };

      #region  Example crap I want to hide

      //  FHIRLocationType fHIRLocationType05 = new FHIRLocationType()
      //  {
      //    LocationTypeId = 5,
      //    Name = "Country",
      //    Level = 5,
      //    ParentFHIRLocationTypeId = null,
      //    IsActive = true,
      //    DateCreated = DateTime.Now,
      //    LastUpdated = DateTime.Now,

      //    FHIRLocations = new ICollection<FHIRLocationType>()
      //    {
      //      new FHIRLocationType()
      //      {
      //        Name = "Region",
      //        Level = 10,
      //        IsActive = true,
      //        DateCreated = DateTime.Now,
      //        LastUpdated = DateTime.Now
      //      }
      //    }

      //};
      #endregion  Example crap I want to hide

      context.FHIRLocationTypes.Add(fHIRLocationTypesTree);

      #endregion LocationsTypesTree


      IList<FHIRDataSource> FHIRDataSources = new List<FHIRDataSource>();

      FHIRDataSources.Add(new FHIRDataSource
      {
        Name = "FHIRServer",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });

      FHIRDataSources.Add(new FHIRDataSource
      {
        Name = "Manual",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });

      FHIRDataSources.Add(new FHIRDataSource
      {
        Name = "KCDS",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });

      context.FHIRDataSource.AddRange(FHIRDataSources);


      IList<EHRType> FHIREHRTypes = new List<EHRType>();

      FHIREHRTypes.Add(new EHRType
      {
        Name = "Unknown",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });
      FHIREHRTypes.Add(new EHRType
      {
        Name = "N/A",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });

      FHIREHRTypes.Add(new EHRType
      {
        Name = "FHIRServer",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });

      FHIREHRTypes.Add(new EHRType
      {
        Name = "KCDS",
        IsActive = true,
        DateCreated = DateTime.Now,
        LastUpdated = DateTime.Now
      });

      context.FHIREHRType.AddRange(FHIREHRTypes);

      //context.EHRType.AddRange(FHIREHRTypes);

      base.Seed(context);
    }


  }
}