using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Area : BaseEntity
{
    public ICollection<Place> ? Places { get; set; }
    public string ?Name_Area { get; set; }
    public ICollection<AreaUser> ? AreaUsers { get; set; }

    public int  ?Id_Description_Incidence { get; set; }
    public ICollection<Incidence> ? Incidences { get; set; }


    public string ?Description_Area { get; set; }

}