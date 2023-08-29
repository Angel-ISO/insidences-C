using InsidenceAPI.Dtos;
using Dominio;
using AutoMapper;




namespace InsidenceAPI.Profiles;

    public class MappingPofiles : Profile
    {
      public MappingPofiles(){
        CreateMap<Country, CountryDto>().ReverseMap().ForMember(o => o.Regions,d => d.Ignore());
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();

        CreateMap<Country, CountryXRegDto>().ReverseMap();
      }
    }
