using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class TypeIncidence
{
    [Key]
    public int Id_TypeIncidence { get; set; }
        public ICollection<DetailIncidence> ?DetailIncidences { get; set; }
    public string ?Name_TypeIncidence { get; set; }
    public string ?Description_TypeIncidence { get; set; }
}