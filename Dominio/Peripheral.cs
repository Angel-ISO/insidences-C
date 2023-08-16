using System.ComponentModel.DataAnnotations;

namespace Dominio;
public class Peripheral
{
    [Key]
    public int Id_Peripheral { get; set; }
     public DetailIncidence ? DetailIncidence { get; set; }
    public string ?Name_Peripheral { get; set; }
}