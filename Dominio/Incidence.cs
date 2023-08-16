using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class Incidence
{
    [Key]
    public int Id_Incidence { get; set; }
    
    public int Id_User { get; set; }
    public User ? User { get; set; }

    public int Id_State { get; set; }
    public State ? State { get; set; }

    public int Id_Area { get; set; }
     public Area ? Area { get; set; }


    public int Id_Place { get; set; }
    public Place ? Place { get; set; }

    public DateTime Date { get; set; }
    public string ?Description_Incidence { get; set; }

    public string ?Detail_Incidence { get; set; }
    public ICollection<DetailIncidence> ? DetailIncidences  { get; set; }

}