using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(IncidenceContext context) : base(context)
    {
        _context = context;
    }
    public override <IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Countries.Include(p => p.Regions)
        .ToListAsync();
    }
}