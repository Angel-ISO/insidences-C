using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class User : BaseEntity
{
   
    public string ?Name_User { get; set; }
    public string ?Password { get; set; }
    public string ?Email { get; set; }
    public ICollection<Rol> ?Rols { get; set; } = new HashSet<Rol>();
    public ICollection<UserRol> ?UserRols { get; set; } 

}