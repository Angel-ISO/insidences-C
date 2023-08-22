namespace Dominio;

public class City : BaseEntity
{
public ICollection<Address> ? Addresses { get; set; }

public string ?NameCity { get; set; }
public int ?Id_Region { get; set; }
public Region ? Region { get; set; }

}