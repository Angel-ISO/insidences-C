using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Area
{
    [Key]
    public int Id_Area { get; set; }
    public ICollection<Place> ? Places { get; set; }
    public string ?Name_Area { get; set; }
    public ICollection<AreaUser> ? AreaUsers { get; set; }

    public int  ?Description_Incidence { get; set; }
    public ICollection<Incidence> ? Incidences { get; set; }


    public string ?Description_Area { get; set; }

}