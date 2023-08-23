namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IAddressRepository Addresses {get;}   
    IAreaRepository Areas {get;}     
    IAreaUserRepository AreaUsers {get;}        
    ICategoryContactRepository CategoryContacts {get;}      
    IContactRepository Contacts {get;}   
    IDetailIncidenceRepository DetailIncidences {get;}   
    IContactTypeRepository ContactTypes {get;}   

    IDocumentTypeRepository DocumentTypes {get;}   
    IIncidenceRepository Incidences  {get;}   
    ILevelIncidenceRepository LevelIncidences {get;}   
    IPeripheralRepository Peripherals {get;}   
    IPlaceRepository Places {get;}   
    IRolRepository Rols {get;}   
    IStateRepository States {get;}   
    ITypeIncidenceRepository TypeIncidences {get;}   
    IUserRepository Users {get;}   
    ICityRepository Cities {get;}   
    IRegionRepository Regions {get;} 
    ICountryRepository Countries {get;} 

      
    Task<int> SaveAsync();
}
