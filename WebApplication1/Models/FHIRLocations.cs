using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace MAMC.BiPass.Web.Models
{

  //TODO: Add a check in the set for the parent so that only real parents can be used.
  [JsonObject(MemberSerialization.OptOut)]
  //[DataContract]
  [Table("FHIRLocations")]
  public partial class FHIRLocation
  {

    //public FHIRLocation()
    //{
    //  ParentFHIRLocation = new HashSet<FHIRLocation>();
    //}


    //The unique ID for the location in the data source it came from.
    //public int ID { get; set; }
    //The unique ID for the location in the data source it came from.
    [Key]
    [DisplayName("Location ID")]
    public int LocationId { get; set; }
    [DisplayName("Location ID in External System")]
    public string ExternalLocationId { get; set; }
    [DisplayName("Location Type ID")]
    public int LocationTypeId { get; set; }

    //Where this particular record came from. Would be FHIR, manual data entry, or another source.
    [ForeignKey("FHIRDataSources")]
    public int DataSourceId { get; set; }
    [ForeignKey("EHRTypes")]
    public int EHRTypeId { get; set; }

    [DisplayName("HOST ID")]
    public int HOST_ID { get; set; }

    [DisplayName("Location Name")]
    public string Name { get; set; }


    //[Column(Order = 3)]
    //Allows a parent-child relationship between entities of different types.
    [DisplayName("Parent Location ID")]
    public int? ParentFHIRLocationId { get; set; }

    [DisplayName("Active")]
    public bool IsActive { get; set; }
    [DisplayName(@"Record Created")]
    public DateTime DateCreated { get; set; }
    [DisplayName(@"Last Updated")]
    public DateTime LastUpdated { get; set; }

    //Navigation Properties
    [XmlIgnore]
    [Display(Name = "Parent Location")]
    public FHIRLocation ParentFHIRLocation { get; set; }

    [XmlIgnore]
    [Display(Name = "Location Type")]
    public FHIRLocationType FHIRLocationType { get; set; }

    [XmlIgnore]
    public ICollection<FHIRPractionerLocations> PractitionerLocations { get; set; }

    [XmlIgnore]
    public FHIRDataSource FHIRDataSources{ get; set; }
    [XmlIgnore]
    public EHRType EHRTypes { get; set; }

  }

  /// <summary>
  /// Takes the values in the fields and turns them into the results you get from a FHIR query/
  /// </summary>
  /// <example>"Location/633867":"Baseline West"</example>
  //[NotMapped()]
  public partial class FHIRLocation
  {

    public string FHIRName
    {
      get
      { 
        //"Location/633867":"Baseline West"
      const string quote = @"""";
      const string forwardSlash = @"/";

      StringBuilder sb = new StringBuilder();

      string temp = sb.Append(quote)
        .Append("Location")
        .Append(forwardSlash)
        .Append(this.ExternalLocationId)
        .Append(quote)
        .Append(":")
        .Append(quote)
        .Append(this.Name)
        .Append(quote).ToString();
      return temp;
      }
      set
      {
        if (value != null)
        {

          string startLocation = "Location/";

          //Get the name and ID from the string.
          int separatorLocation = value.LastIndexOf(":\"");
          int keyStart = startLocation.Length + 1;

          if (value.IndexOf(startLocation) > 0)
          {
            this.ExternalLocationId = value.Substring(keyStart, separatorLocation - keyStart - 1);

            int nameStart = separatorLocation + 2;

            int nameEnd = value.Length - 1;
            int nameLength = nameEnd - nameStart;
            this.Name = value.Substring(nameStart, nameLength);
          }
          
        }
      }
    }
  }
}