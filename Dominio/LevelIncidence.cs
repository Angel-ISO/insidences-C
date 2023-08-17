using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class LevelIncidence : BaseEntity
{
  
    public string ?Name_LevelIncidence { get; set; }
    public ICollection<DetailIncidence> ?DetailIncidences { get; set; }
    public string ?Description_LevelIncidence { get; set; }
}