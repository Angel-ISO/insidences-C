using System.ComponentModel.DataAnnotations;

namespace Dominio;

    public class BaseEntity
    {
        [Key]
        public int Id {get; set;}
    }
