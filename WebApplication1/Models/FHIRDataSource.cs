using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MAMC.BiPass.Web.Models
{
  public class FHIRDataSource
  {
    [DataMember]
    [Key]
    //[ForeignKey("FHIRLocations")]
    public int DataSourceId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }


    //Navigation Properties
    public IList<FHIRLocation> FHIRLocations { get; set; }

  }
}