using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Rol : BaseEntity
{
 
    public string ?Name_Rol { get; set; }
     public ICollection<User> ?Users { get; set; }
    public string ?Description_Rol { get; set; }
}