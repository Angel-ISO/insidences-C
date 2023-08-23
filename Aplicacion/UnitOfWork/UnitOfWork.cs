using Dominio.Interfaces;
using Persistencia;
using Aplicacion.Repository;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly IncidenceContext _context;
    AddressRepository _Address;
     private AreaRepository _Area;
    private AreaUserRepository _AreaUser;
    private CategoryContactRepository _CategoryContact;
    private CityRepository _City;
    private ContactRepository _Contact;
    private CountryRepository _Country;
    private DetailIncidenceRepository _DetailIncidence;
    private DocumentTypeRepository _DocumentType;
    private IncidenceRepository _Incidence;
    private LevelIncidenceRepository _LevelIncidence;
    private PeripheralRepository _Peripheral;
    private PlaceRepository _Place;
    private RegionRepository _Region;
    private RolRepository _Rol;
    private StateRepository _State;
    private TypeIncidenceRepository _TypeIncidence;
    private UserRepository _User;

    public UnitOfWork(IncidenceContext context)
    {
        _context = context;
    }



    public IAddressRepository Addresses
    {
        get
        {
            if (_Address is not null)
            {
                return _Address;
            }
            return _Address = new AddressRepository(_context);
        }
    }



    public IDetailIncidenceRepository DetailIncidences
    {
        get
        {
            if (_DetailIncidence is not null)
            {
                return _DetailIncidence;
            }
            return _DetailIncidence = new DetailIncidenceRepository(_context);
        }
    }


    public IAreaRepository Areas
    {
        get
        {
            if (_Area is not null)
            {
                return _Area;
            }
            return _Area = new AreaRepository(_context);
        }
    }

    IAreaRepository IUnitOfWork.Areas => throw new NotImplementedException();

    public IAreaUserRepository AreaUsers
    {
        get
        {
            if (_AreaUser is not null)
            {
                return _AreaUser;
            }
            return _AreaUser = new AreaUserRepository(_context);
        }
    }

    public ICategoryContactRepository CategoryContacts
    {
        get
        {
            if (_CategoryContact is not null)
            {
                return _CategoryContact;
            }
            return _CategoryContact = new CategoryContactRepository(_context);
        }
    }

    public ICityRepository Cities
    {
        get
        {
            if (_City is not null)
            {
                return _City;
            }
            return _City = new CityRepository(_context);
        }
    }

    public IContactRepository Contacts
    {
        get
        {
            if (_Contact is not null)
            {
                return _Contact;
            }
            return _Contact = new ContactRepository(_context);
        }
    }

    public ICountryRepository Countries
    {
        get
        {
            if (_Country is not null)
            {
                return _Country;
            }
            return _Country = new CountryRepository(_context);
        }
    }
    public IDocumentTypeRepository DocumentTypes
    {
        get
        {
            if (_DocumentType is not null)
            {
                return _DocumentType;
            }
            return _DocumentType = new DocumentTypeRepository(_context);
        }
    }
    public IIncidenceRepository Incidences
    {
        get
        {
            if (_Incidence is not null)
            {
                return _Incidence;
            }
            return _Incidence = new IncidenceRepository(_context);
        }
    }

    public ILevelIncidenceRepository LevelIncidences
    {
        get
        {
            if (_LevelIncidence is not null)
            {
                return _LevelIncidence;
            }
            return _LevelIncidence = new LevelIncidenceRepository(_context);
        }
    }

    public IPeripheralRepository Peripherals
    {
        get
        {
            if (_Peripheral is not null)
            {
                return _Peripheral;
            }
            return _Peripheral = new PeripheralRepository(_context);
        }
    }

    public IPlaceRepository Places
    {
        get
        {
            if (_Place is not null)
            {
                return _Place;
            }
            return _Place = new PlaceRepository(_context);
        }
    }
    public IRegionRepository Regions
    {
        get
        {
            if (_Region is not null)
            {
                return _Region;
            }
            return _Region = new RegionRepository(_context);
        }
    }

    public IRolRepository Rols
    {
        get
        {
            if (_Rol is not null)
            {
                return _Rol;
            }
            return _Rol = new RolRepository(_context);
        }
    }

    public IStateRepository States
    {
        get
        {
            if (_State is not null)
            {
                return _State;
            }
            return _State = new StateRepository(_context);
        }
    }

    public ITypeIncidenceRepository TypeIncidences
    {
        get
        {
            if (_TypeIncidence is not null)
            {
                return _TypeIncidence;
            }
            return _TypeIncidence = new TypeIncidenceRepository(_context);
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_User is not null)
            {
                return _User;
            }
            return _User = new UserRepository(_context);
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync(){
        return await _context.SaveChangesAsync();
    }

}