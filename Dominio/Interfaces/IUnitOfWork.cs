namespace Dominio.Interfaces;
public interface IUnitOfWork
{
    IAreaRepository Areas {get;}     
    IAreaUserRepository AreaUsers {get;}        
    ICategoryContactRepository CategoryContacts {get;}      
    IContactRepository Contacts {get;}   
    IDetailIncidenceRepository DetailIncidences {get;}   
    IDocumentTypeRepository DocumentTypes {get;}   
    IIncidenceRepository Incidences  {get;}   
    ILevelIncidenceRepository LevelIncidences {get;}   
    IPeripheralRepository Peripherals {get;}   
    IPlaceRepository Places {get;}   
    IRolRepository Rols {get;}   
    IStateRepository States {get;}   
    ITypeIncidenceRepository TypeIncidences {get;}   
    IUserRepository Users {get;}   

    Task<int> SaveAsync();
}
