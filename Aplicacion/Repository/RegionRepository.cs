using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class RegionRepository : GenericRepository<Region>, IRegionRepository
{
    private readonly IncidenceContext _context;

    public RegionRepository(IncidenceContext context) : base(context)
    {
         _context = context;
    }

            public override async Task<(int totalRegistros, IEnumerable<Region> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Regions as IQueryable<Region>;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.NameRegion.ToLower().Contains(search));
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Cities)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (totalRegistros, registros);
        }

     public override async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _context.Regions.Include(p => p.Cities)
        .ToListAsync();
    }
}