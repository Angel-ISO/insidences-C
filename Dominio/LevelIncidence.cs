using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class LevelIncidence
{
    [Key]
    public int Id_LevelIncidence { get; set; }
    public string ?Name_LevelIncidence { get; set; }
    public ICollection<DetailIncidence> ?DetailIncidences { get; set; }
    public string ?Description_LevelIncidence { get; set; }
}