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
        public override async Task<(int totalRegistros, IEnumerable<Country> registros)> GetAllAsync(int pageIndex, int pageSize, string Search)
        {
            var query = _context.Countries as IQueryable<Country>;
            if (!string.IsNullOrEmpty(Search))
                query = query.Where(p => p.NameCountry.ToLower().Contains(Search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Regions)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }

    public override async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _context.Countries.Include(p => p.Regions)
        .ToListAsync();
    }
}