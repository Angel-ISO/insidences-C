using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    public AddressRepository(IncidenceContext context) : base(context)
    {
        
    }
}