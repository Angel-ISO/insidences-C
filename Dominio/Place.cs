using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Place
{
    [Key]
    public int Id_Place { get; set; }

    public string ?Name_Place { get; set; }
    public ICollection<Incidence> ?Incidences { get; set; }
    public int ?Id_AreaOrigin { get; set; }
    public Area ? Area { get; set; }
    public string ?Description_Place { get; set; }
}