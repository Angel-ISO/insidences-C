using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    private readonly IncidenceContext _context;
    public CountryRepository(IncidenceContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Countries.Include(p => p.Regions)
        .ToListAsync();
    }
}