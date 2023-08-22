namespace Dominio;

public class Country : BaseEntity
{
    public ICollection<Region> ?Regions { get; set; }
    public string ? NameCountry { get; set; }
}