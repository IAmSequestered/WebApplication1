using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MAMC.BiPass.Web.Models
{
  public class FHIRLocationType
  {
    [DataMember]
    [Key]
    [Display(Name = "Location Type ID")]
    public int LocationTypeId { get; set; }
    [Display(Name = "Location Type")]
    public string Name { get; set; }
    [Display(Name = "Location Type Level")]
    public int Level { get; set; }
    [Display(Name = "Active")]
    public bool IsActive { get; set; }
    [Display(Name = "Date Created")]
    public DateTime DateCreated { get; set; }
    [Display(Name = "Last Updated")]
    public DateTime LastUpdated { get; set; }
    [Display(Name = "Parent Location Type ID")]
    public int? ParentFHIRLocationTypeId { get; set; }

    [Display(Name = "Parent Location Type")]
    public FHIRLocationType ParentFHIRLocationType { get; set; }

    //Navigation Properties
    public virtual IList<FHIRLocation> FHIRLocations { get; set; }
  }
}