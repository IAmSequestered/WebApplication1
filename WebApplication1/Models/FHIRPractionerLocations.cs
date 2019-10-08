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
  [Table("FHIRPractionerLocations")]
  public partial class FHIRPractionerLocations
  {

    //The unique ID for the location in the data source it came from.
    //public int ID { get; set; }
    //The unique ID for the location in the data source it came from.

    //[Key("FHIRLocations")]
    [DisplayName("Location ID")]
   // [ForeignKey("FHIRLocations")]
    public int LocationId { get; set; }

    public FHIRLocation FHIRLocation { get; set; }

    //[Key("FHIRPractitioners")]
    [DisplayName("Practitioner ID")]
  //  [ForeignKey("FHIRPractitioners")]
    public string PractitionerId { get; set; }

    public FHIRPractitioner FHIRPractitioner { get; set; }


    //Navigation Properties

    [XmlIgnore]
    [DisplayName("Locations")]
    public virtual ICollection<FHIRLocation> FHIRLocations { get; set; }

    [XmlIgnore]
    [DisplayName("Practitioners")]
    public virtual ICollection<FHIRPractitioner> FHIRPractitioners { get; set; }

  }
}