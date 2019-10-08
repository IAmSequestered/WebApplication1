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
  //[DataContract]
  [Table("FHIRPractitioners")]
  public partial class FHIRPractitioner
  {
    //public FHIRPractitioner()
    //{
    //  FHIRLocations = new HashSet<FHIRLocation>();
    //}
    string _FHIRName;

    [DataMember]
    [Key]
    [DisplayName("Practitioner ID")]
    public string PractitionerId { get; set; }
    [DisplayName("Location Type ID")]
    public int LocationType { get; set; }
    [DisplayName("Practitioner ID in External System")]
    public string AlternateID { get; set; }

    [DataMember]
    [DisplayName("Practitioner Name")]
    public string Name { get; set; }
    [DisplayName("Practitioner Type ID")]
    public int PractitionerType { get; set; }
    [DisplayName("Takes Appointments")]
    public bool? TakesAppointments{ get; set; }
    [DisplayName("Is Active")]
    public bool IsActive { get; set; }
    [DisplayName(@"Record Created")]
    public DateTime DateCreated { get; set; }
    [DisplayName(@"Last Updated")]
    public DateTime LastUpdated { get; set; }

    //Navigation Properties

    //[DataMember]

    public virtual ICollection<FHIRLocation> FHIRLocations { get; set; }

    [XmlIgnore]
    public virtual ICollection<FHIRPractionerLocations> PractitionerLocations { get; set; }

    //public virtual ICollection<FHIRPractitionerTypes> PractitionerTypes { get; set; }

  }
  /// <summary>
  /// Takes the values in the fields and turns them into the results you get from a FHIR query/
  /// </summary>
  /// <example>"Practitioner/633867":"Adam West"</example>
  public partial class FHIRPractitioner
  {

    //[NotMapped()]
    public string FHIRName
    {
      get
      {
        return _FHIRName;
        ////"Location/633867":"Baseline West"
        //const string quote = @"""";
        //const string forwardSlash = @"/";

        //StringBuilder sb = new StringBuilder();

        //string temp = sb.Append(quote)
        //  .Append("Practitioner")
        //  .Append(forwardSlash)
        //  .Append(this.PractitionerId)
        //  .Append(quote)
        //  .Append(":")
        //  .Append(quote)
        //  .Append(this.Name)
        //  .Append(quote).ToString();
        //return temp;
      }
      set
      {
        if (value != null)
        {
          if (value != _FHIRName)
          {
            //Get the name and ID from the string.
            int separatorLocation = value.IndexOf(":");
            if (separatorLocation > 0)
            {
              int keyStart = "Practitioner/".Length + 1;
              string temp1 = value.Substring(keyStart, separatorLocation - keyStart - 1);
              if (this.PractitionerId != temp1)
              {
                this.PractitionerId = temp1;
              }

              int nameStart = separatorLocation + 2;

              int nameEnd = value.Length - 1;
              int nameLength = nameEnd - nameStart;
              string temp2 = value.Substring(nameStart, nameLength);

              if (this.Name != temp2)
              {
                this.Name = temp2;
              }
            }

            _FHIRName = value;
          }
        }
      }
    }
  }
}