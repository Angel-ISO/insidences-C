using Dominio;

namespace InsidenceAPI.Dtos;

    public class CountryXRegDto
    {
        public string Id {get; set;}
        public string NameCountry {get; set;}
        public List<RegionDto> Regions {get; set;}
    }
