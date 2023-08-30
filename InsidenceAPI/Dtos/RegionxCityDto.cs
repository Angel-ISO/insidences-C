using Dominio;

namespace InsidenceAPI.Dtos;

    public class RegionxCityDto
    {
         public string Id {get; set;}
        public string NameRegion {get; set;}
        public List<CityDto> Cities {get; set;}
    }
