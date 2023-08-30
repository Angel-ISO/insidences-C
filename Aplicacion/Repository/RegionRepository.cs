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
     public override async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _context.Regions.Include(p => p.Cities)
        .ToListAsync();
    }
}