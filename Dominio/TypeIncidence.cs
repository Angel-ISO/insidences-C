using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class TypeIncidence : BaseEntity
{
 
        public ICollection<DetailIncidence> ?DetailIncidences { get; set; }
    public string ?Name_TypeIncidence { get; set; }
    public string ?Description_TypeIncidence { get; set; }
}