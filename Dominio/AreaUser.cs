using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class AreaUser
{
    [Key]
    public int Id_AreaUser { get; set; }
    public int Id_Area { get; set; }
    public Area ? Area { get; set; }
    public int Id_User { get; set; }
     public User ? User { get; set; }
}