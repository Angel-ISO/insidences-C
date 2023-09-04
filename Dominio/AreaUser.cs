using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class AreaUser : BaseEntity
{
  
    public int Id_Area { get; set; }
    public Area ? Area { get; set; }
    public int Id_Person { get; set; }
     public Person ? Person { get; set; }
}