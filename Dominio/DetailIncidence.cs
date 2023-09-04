using System.ComponentModel.DataAnnotations;

namespace Dominio;

public class DetailIncidence : BaseEntity
{
     


        public int Id_Peripheral { get; set; }
        public ICollection<Peripheral> ?Peripherals { get; set; }

        public int Id_TypeIncidence { get; set; }
        public TypeIncidence ? TypeIncidence { get; set; }

        public int Id_LevelIncidence { get; set; }
        public LevelIncidence ? LevelOfIncidence { get; set; }

        public int Id_State { get; set; }
         public State ? State { get; set; }

        public string ?Description_DetailIncidence { get; set; }
        public Incidence ? Incidence { get; set; }
}