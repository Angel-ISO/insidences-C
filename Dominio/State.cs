using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class State : BaseEntity
{
 
    public ICollection<DetailIncidence> ?DetailIncidences { get; set; }

     public DetailIncidence ? DetailIncidence { get; set; }
    public ICollection<Incidence> ?Incidences { get; set; }
    public string ?Description_State { get; set; }
}