using System.ComponentModel.DataAnnotations;

namespace Dominio;
public class Peripheral : BaseEntity
{
  
     public DetailIncidence ? DetailIncidence { get; set; }
    public string ?Name_Peripheral { get; set; }
}