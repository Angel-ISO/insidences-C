
using Dominio;

namespace InsidenceAPI.Dtos;

    public class PersonxIncidenceDto
    {
        public string Nombre {get; set; }
        public string Apellido {get; set; }
        public int SuIdDeDocumento {get; set; }
        public List <IncidenceDto> Incidencias {get; set;}
    }
