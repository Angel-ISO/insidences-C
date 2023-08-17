using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Place : BaseEntity
{
    

    public string ?Name_Place { get; set; }
    public ICollection<Incidence> ?Incidences { get; set; }
    public int ?Id_AreaOrigin { get; set; }
    public Area ? Area { get; set; }
    public string ?Description_Place { get; set; }
}